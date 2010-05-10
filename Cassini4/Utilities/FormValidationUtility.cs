/* **********************************************************************************
 *
 * Copyright (c) Tanzim Saqib. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Public
 * License (Ms-PL). A copy of the license can be found in the license.htm file
 * included in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * For continued development:   http://www.TanzimSaqib.com
 * Source:                      http://cassini.googlecode.com/
 * License information:         http://www.opensource.org/licenses/ms-pl.html
 *
 * **********************************************************************************/

namespace Cassini
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using VistaControls.TaskDialog;

    public class FormValidationUtility
    {
        public static void ValidateHostSiteForm(TextBox txtPath, TextBox txtPort, TextBox txtVirRoot, Form form, Action successHandler)
        {
            if (!Directory.Exists(txtPath.Text))
            {
                TaskDialog.Show("Specified path does not exist.", form.Text, string.Empty, TaskDialogButton.OK,
                                TaskDialogIcon.Information);

                txtPath.Focus();
                return;
            }


            int port = 0;

            if (!int.TryParse(txtPort.Text, out port) || port < 0 || port > 65535)
            {
                TaskDialog.Show("Specified port is not possible.", form.Text, "Valid input: 0-65535", TaskDialogButton.OK,
                                TaskDialogIcon.Information);

                txtPort.Focus();
                return;
            }

            if (txtVirRoot.Text.Length == 0 || !txtVirRoot.Text.StartsWith("/"))
            {
                TaskDialog.Show("Invalid virtual root.", form.Text, "It should start with a forward slash (Default: /).", TaskDialogButton.OK,
                TaskDialogIcon.Information);

                txtVirRoot.Focus();
                return;
            }

            successHandler();
        }
    }
}
