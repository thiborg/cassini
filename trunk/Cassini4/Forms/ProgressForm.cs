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
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class ProgressForm : Form
    {
        private ICommand Command { get; set; }
        private Action UICallback { get; set; }
        private Task _Task { get; set; }
        private Action<ArrayList> SuccessHandler { get; set; }
        private Action<List<Exception>> FailHandler { get; set; }

        public ProgressForm(ICommand command, Action uiCallback)
        {
            InitializeComponent();
            Command = command;
            UICallback = uiCallback;
            Visible = false;
        }

        public ProgressForm(ICommand command, Action<ArrayList> successHandler, Action<List<Exception>> failHandler, Action uiCallback)
            : this(command, uiCallback)
        {
            SuccessHandler = successHandler;
            FailHandler = failHandler;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            if(SuccessHandler != null && FailHandler != null)
            {
                CommandExecutor.Execute(Command, SuccessHandler, FailHandler);
                return;    
            }

            _Task = Task.Factory.StartNew(() => Command.Execute());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Command.GetStatus() != CommandStatus.Idle)
            {
                pb.Value = ((Command.GetProgressStep() + 1) * 100) / Command.GetTotalProgressSteps();

                if (Command.GetStatus() == CommandStatus.Completed || Command.GetStatus() == CommandStatus.Cancelled)
                {
                    timer1.Enabled = false;

                    if(UICallback != null)
                        UICallback();

                    Close();
                }

                lblStatus.Text = Command.GetProgressText();
            }
        }

    }
}
