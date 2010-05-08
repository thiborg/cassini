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
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripStop = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.txtVirRoot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.digitalDisplayControl1 = new Owf.Controls.DigitalDisplayControl();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Url = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PhysicalPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOptions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnHost = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.uptimeCounter = new Owf.Controls.DigitalDisplayControl();
            this.btnStartServer = new VistaControls.CommandLink();
            this.contextMenuNotify.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notify
            // 
            this.notify.BalloonTipTitle = "Cassini 4.0";
            this.notify.ContextMenuStrip = this.contextMenuNotify;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Cassini 4.0";
            this.notify.Visible = true;
            this.notify.DoubleClick += new System.EventHandler(this.notify_DoubleClick);
            // 
            // contextMenuNotify
            // 
            this.contextMenuNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStart,
            this.toolStripSep,
            this.toolStripStop});
            this.contextMenuNotify.Name = "contextMenuNotify";
            this.contextMenuNotify.ShowImageMargin = false;
            this.contextMenuNotify.Size = new System.Drawing.Size(85, 58);
            // 
            // toolStripStart
            // 
            this.toolStripStart.Name = "toolStripStart";
            this.toolStripStart.Size = new System.Drawing.Size(84, 24);
            this.toolStripStart.Text = "Start";
            this.toolStripStart.Click += new System.EventHandler(this.toolStripStart_Click);
            // 
            // toolStripSep
            // 
            this.toolStripSep.Name = "toolStripSep";
            this.toolStripSep.Size = new System.Drawing.Size(81, 6);
            // 
            // toolStripStop
            // 
            this.toolStripStop.Name = "toolStripStop";
            this.toolStripStop.Size = new System.Drawing.Size(84, 24);
            this.toolStripStop.Text = "Exit";
            this.toolStripStop.Click += new System.EventHandler(this.toolStripStop_Click);
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.a1Panel1.Controls.Add(this.txtVirRoot);
            this.a1Panel1.Controls.Add(this.label5);
            this.a1Panel1.Controls.Add(this.label4);
            this.a1Panel1.Controls.Add(this.digitalDisplayControl1);
            this.a1Panel1.Controls.Add(this.btnLogs);
            this.a1Panel1.Controls.Add(this.btnSettings);
            this.a1Panel1.Controls.Add(this.grid);
            this.a1Panel1.Controls.Add(this.btnHost);
            this.a1Panel1.Controls.Add(this.txtPort);
            this.a1Panel1.Controls.Add(this.label3);
            this.a1Panel1.Controls.Add(this.btnFolderBrowse);
            this.a1Panel1.Controls.Add(this.txtPath);
            this.a1Panel1.Controls.Add(this.label2);
            this.a1Panel1.Controls.Add(this.label1);
            this.a1Panel1.Controls.Add(this.lblUptime);
            this.a1Panel1.Controls.Add(this.uptimeCounter);
            this.a1Panel1.Controls.Add(this.btnStartServer);
            this.a1Panel1.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.LightSteelBlue;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(1, 1);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.Size = new System.Drawing.Size(1005, 653);
            this.a1Panel1.TabIndex = 1;
            // 
            // txtVirRoot
            // 
            this.txtVirRoot.Location = new System.Drawing.Point(126, 173);
            this.txtVirRoot.Name = "txtVirRoot";
            this.txtVirRoot.Size = new System.Drawing.Size(131, 25);
            this.txtVirRoot.TabIndex = 4;
            this.txtVirRoot.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(35, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 106;
            this.label5.Text = "Virtual Root:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(830, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 19);
            this.label4.TabIndex = 105;
            this.label4.Text = "Server-side Exceptions:";
            // 
            // digitalDisplayControl1
            // 
            this.digitalDisplayControl1.BackColor = System.Drawing.Color.Transparent;
            this.digitalDisplayControl1.DigitColor = System.Drawing.Color.Crimson;
            this.digitalDisplayControl1.DigitText = "0";
            this.digitalDisplayControl1.Location = new System.Drawing.Point(913, 189);
            this.digitalDisplayControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.digitalDisplayControl1.Name = "digitalDisplayControl1";
            this.digitalDisplayControl1.Size = new System.Drawing.Size(75, 22);
            this.digitalDisplayControl1.TabIndex = 104;
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(828, 255);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(75, 23);
            this.btnLogs.TabIndex = 103;
            this.btnLogs.Text = "Logs";
            this.btnLogs.UseCompatibleTextRendering = true;
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(903, 255);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 102;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseCompatibleTextRendering = true;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Url,
            this.PhysicalPath,
            this.Status,
            this.btnOptions});
            this.grid.Location = new System.Drawing.Point(21, 284);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 24;
            this.grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid.Size = new System.Drawing.Size(957, 344);
            this.grid.TabIndex = 100;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // Url
            // 
            this.Url.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Url.Frozen = true;
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Url.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Url.Width = 52;
            // 
            // PhysicalPath
            // 
            this.PhysicalPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PhysicalPath.FillWeight = 6.849319F;
            this.PhysicalPath.HeaderText = "PhysicalPath";
            this.PhysicalPath.Name = "PhysicalPath";
            this.PhysicalPath.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 72;
            // 
            // btnOptions
            // 
            this.btnOptions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnOptions.FillWeight = 193.1507F;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOptions.HeaderText = "Action";
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Text = "Options";
            this.btnOptions.UseColumnTextForButtonValue = true;
            this.btnOptions.Width = 54;
            // 
            // btnHost
            // 
            this.btnHost.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHost.Location = new System.Drawing.Point(126, 215);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(81, 25);
            this.btnHost.TabIndex = 5;
            this.btnHost.Text = "Host!";
            this.btnHost.UseCompatibleTextRendering = true;
            this.btnHost.UseVisualStyleBackColor = true;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(126, 138);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(79, 25);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "8000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(82, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Port:";
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.Location = new System.Drawing.Point(441, 100);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(81, 25);
            this.btnFolderBrowse.TabIndex = 2;
            this.btnFolderBrowse.Text = "Browse";
            this.btnFolderBrowse.UseCompatibleTextRendering = true;
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            this.btnFolderBrowse.Click += new System.EventHandler(this.btnFolderBrowse_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(126, 100);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(309, 25);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "c:\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(28, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Physical Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Host a Website";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.BackColor = System.Drawing.Color.Transparent;
            this.lblUptime.Location = new System.Drawing.Point(921, 99);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(57, 19);
            this.lblUptime.TabIndex = 99;
            this.lblUptime.Text = "Uptime:";
            // 
            // uptimeCounter
            // 
            this.uptimeCounter.BackColor = System.Drawing.Color.Transparent;
            this.uptimeCounter.DigitColor = System.Drawing.Color.Navy;
            this.uptimeCounter.DigitText = "";
            this.uptimeCounter.Location = new System.Drawing.Point(862, 109);
            this.uptimeCounter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uptimeCounter.Name = "uptimeCounter";
            this.uptimeCounter.Size = new System.Drawing.Size(116, 50);
            this.uptimeCounter.TabIndex = 99;
            // 
            // btnStartServer
            // 
            this.btnStartServer.AccessibleDescription = "";
            this.btnStartServer.AccessibleName = "";
            this.btnStartServer.AutoEllipsis = true;
            this.btnStartServer.BackColor = System.Drawing.Color.Transparent;
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStartServer.Location = new System.Drawing.Point(828, 24);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(150, 56);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Stop Server";
            this.btnStartServer.UseCompatibleTextRendering = true;
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 650);
            this.Controls.Add(this.a1Panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cassini 4.0";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.contextMenuNotify.ResumeLayout(false);
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Owf.Controls.A1Panel a1Panel1;
        private VistaControls.CommandLink btnStartServer;
        private Owf.Controls.DigitalDisplayControl uptimeCounter;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotify;
        private System.Windows.Forms.ToolStripMenuItem toolStripStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSep;
        private System.Windows.Forms.ToolStripMenuItem toolStripStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHost;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label4;
        private Owf.Controls.DigitalDisplayControl digitalDisplayControl1;
        private System.Windows.Forms.TextBox txtVirRoot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewLinkColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhysicalPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn btnOptions;

    }
}

