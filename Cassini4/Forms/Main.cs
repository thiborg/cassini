/* **********************************************************************************
 *
 * Copyright (c) Tanzim Saqib. URL: http://www.TanzimSaqib.com. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Public
 * License (Ms-PL). A copy of the license can be found in the license.htm file
 * included in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * **********************************************************************************/

namespace Cassini
{
    using System;
    using System.Windows.Forms;
    using Commands;
    using VistaControls.TaskDialog;

    public partial class Main : Form
    {
        private DateTime _UptimeStarted = DateTime.Now;

        public Main()
        {
            InitializeComponent();

            #region Event Subscription

            App.SubscribeEvent(EventKeys.WEBSITE_CREATED, (publisher, args) =>
                {
                    this.BeginInvoke(new EventHandler(ChangeWebsitesInGrid), new object[] { this, args });
                });

            App.SubscribeEvent(EventKeys.WEBSITE_CHANGED, (publisher, args) =>
                {
                    this.BeginInvoke(new EventHandler(ChangeWebsitesInGrid), new object[] { this, args });
                });

            App.SubscribeEvent(EventKeys.WEBSITE_DELETED, (publisher, args) =>
                {
                    this.BeginInvoke(new EventHandler(ChangeWebsitesInGrid), new object[] { this, args });
                });

            App.SubscribeEvent(EventKeys.SERVER_STOPPED, (publisher, args) =>
            {
                this.BeginInvoke(new EventHandler(UptimeCounterReset), new object[] { this, args });
            });

            App.SubscribeEvent(EventKeys.SERVER_STARTED, (publisher, args) =>
            {
                this.BeginInvoke(new EventHandler(UptimeCounterReset), new object[] { this, args });
            });

            #endregion
        }

        #region Event Handlers

        private void ChangeWebsitesInGrid(object o, EventArgs e)
        {
            RefreshGrid();
        }

        private void UptimeCounterReset(object o, EventArgs e)
        {
            _UptimeStarted = DateTime.Now;
        }

        #endregion

        #region Form Event Handlers

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(App.Config.IsRunning)
            {
                var uptime = DateTime.Now.Subtract(_UptimeStarted);
                uptimeCounter.DigitText = uptime.ToString(@"dd\.hh\:mm\:ss");
            }
            else
            {
                uptimeCounter.DigitText = "00.00:00:00";
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            btnStartServer.Text = App.Config.IsRunning ? "Stop Server" : "Start Server";
            RefreshGrid();

            //old = new TimeSpan(2, 3, 4, 5);
            //prev = DateTime.Now.Subtract(old);
            //var websites = new List<Website> { new Website { Path = "C:\\Path\\ahsdnai uhbibh fiuhs ifhiushdifhsdiufhdsif", Port = 9000, Url = "http://localhost:9000/", Status = WebsiteStatus.Running } };
            //grid.DataSource = websites;
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var url = grid.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (e.ColumnIndex == 0)
            {
                System.Diagnostics.Process.Start(url);
            }
            else if (e.ColumnIndex == 3)
            {
                new Options(grid.Rows[e.RowIndex].Cells[0].Value.ToString()).ShowDialog(this);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notify.ShowBalloonTip(3000, "Cassini 4.0",
                        "Cassini is running.",
                        ToolTipIcon.Info);
            }
        }

        private void notify_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }

            // Activate the form.
            this.Activate();
            this.Focus();
        }

        private void toolStripStart_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStop_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowNewFolderButton = false;

            DialogResult result = folderBrowser.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderBrowser.SelectedPath;
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if(App.Config.IsRunning)
            {
                new ProgressForm(new StopServerCommand(),
                        () =>
                        {
                            btnStartServer.Text = "Start Server";

                        }).ShowDialog(this);                
            }
            else
            {
                new ProgressForm(new StartServerCommand(),
                    () =>
                    {
                        btnStartServer.Text = "Stop Server";

                    }).ShowDialog(this);
            }
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            FormValidationUtility.ValidateHostSiteForm(txtPath, txtPort, txtVirRoot, this,
                () =>
                    {
                        new ProgressForm(new HostSiteCommand(
                             new Website()
                             {
                                 PhysicalPath =
                                     txtPath.Text.EndsWith("\\", StringComparison.Ordinal)
                                         ? txtPath.Text
                                         : txtPath.Text + "\\",
                                 Port = int.Parse(txtPort.Text),
                                 VirtualRoot = txtVirRoot.Text,
                                 IsRunning = true
                             }),
                         (results) =>
                         {
                             txtPort.Text = txtPath.Text = string.Empty;
                             txtVirRoot.Text = "/";
                         },
                         (exceptions) => exceptions.ForEach(
                             exception =>
                             {
                                 if (exception is PortInUseException || exception is WebsiteExistsAtTheSameUrl)
                                 {
                                     TaskDialog.Show(
                                         exception.Message,
                                         App.APP_NAME,
                                         string.Empty,
                                         TaskDialogButton.OK,
                                         TaskDialogIcon.Stop);
                                 }
                                 else
                                 {
                                     TaskDialog.Show(
                                        "Unhandled Exception.",
                                        App.APP_NAME,
                                        exception.StackTrace,
                                        TaskDialogButton.OK,
                                        TaskDialogIcon.Stop);
                                 }
                             }),
                         () =>
                         {
                         }).ShowDialog(this);
                    });

        }

        #endregion

        #region Methods

        private void RefreshGrid()
        {
            if (App.Config.Websites.Count > 0)
            {
                grid.Rows.Clear();

                foreach (var website in App.Config.Websites)
                {
                    grid.Rows.Add(website.Value.Url, website.Value.PhysicalPath, website.Value.IsRunning ? "Running" : "Stopped");
                }
            }
        }

        #endregion

    }

}
