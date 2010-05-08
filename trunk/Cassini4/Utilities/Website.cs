/* **********************************************************************************
 *
 * Copyright (c) Microsoft Corporation and Tanzim Saqib. URL: http://www.TanzimSaqib.com
 * All rights reserved.
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
    using Configuration;

    public class Website
    {
        public string PhysicalPath { get; set; }
        public int Port { get; set; }
        public string VirtualRoot { get; set; }
        public bool IsRunning { get; set; }

        public string Url
        {
            get
            {
                return (Port != 80) ? "http://localhost:" + Port + VirtualRoot : "http://localhost" + VirtualRoot;
            }
        }

        public CassiniWebsiteConfig ToConfiguration()
        {
            return new CassiniWebsiteConfig
                       {
                           PhysicalPath = PhysicalPath,
                           Port = Port,
                           VirtualRoot = VirtualRoot,
                           Url = Url,
                           IsRunning = IsRunning
                       };
        }

    }
}
