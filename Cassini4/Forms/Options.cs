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

    public partial class Options : Form
    {
        private Website _Website { get; set; }
        private string Url { get; set; }

        public Options()
        {
            InitializeComponent();
        }

        public Options(string url) : this()
        {
            Url = url;
            _Website = App.Config.Websites[url].ToWebsite();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            chkRunning.Checked = _Website.IsRunning;

            txtPath.Text = _Website.PhysicalPath;
            txtPort.Text = _Website.Port.ToString();
            txtVirRoot.Text = _Website.VirtualRoot;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this website?", App.APP_NAME,
                                         MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                new ProgressForm(new DeleteSiteCommand(_Website),
                                 () =>
                                     {
                                         Close();
                                     }).ShowDialog(this);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnStopWebsite_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var isReturnPending = false;
            var newWebSite = new Website()
                                 {
                                     PhysicalPath =
                                         txtPath.Text.EndsWith("\\", StringComparison.Ordinal)
                                             ? txtPath.Text
                                             : txtPath.Text + "\\",
                                     Port = int.Parse(txtPort.Text),
                                     VirtualRoot = txtVirRoot.Text,
                                     IsRunning = chkRunning.Checked
                                 };

            FormValidationUtility.ValidateHostSiteForm(txtPath, txtPort, txtVirRoot, this,
                () =>
                {
                    new ProgressForm(new ChangeSiteCommand(
                        _Website,
                         newWebSite),
                     (results) =>
                     {
                         _Website = newWebSite;
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

                             isReturnPending = true;
                         }),
                     () =>
                     {
                     }).ShowDialog(this);
                });
            
            if(isReturnPending)
                return;

            if(App.Config.IsRunning)
            {
                if (!chkRunning.Checked)
                {
                    if (App.Config.Websites[_Website.Url].IsRunning)
                    {
                        new ProgressForm(new StopSiteCommand(_Website),
                            () =>
                            {
                                Close();
                            }).ShowDialog(this);
                    }
                }
                else if (!App.Config.Websites[_Website.Url].IsRunning)
                {
                    new ProgressForm(new StartSiteCommand(_Website),
                        () =>
                        {
                            Close();
                        }).ShowDialog(this);
                }
            }

            Dispose();
        }

        private void chkRunning_CheckedChanged(object sender, EventArgs e)
        {

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


    }
}
