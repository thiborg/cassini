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

namespace Cassini.Configuration
{
    using System.Xml.Serialization;

    public class CassiniWebsiteConfig
    {
        [XmlAttribute(CassiniConfigConstants.PHYSICAL_PATH)]
        public string PhysicalPath { get; set; }

        [XmlAttribute(CassiniConfigConstants.PORT)]
        public int Port { get; set; }

        [XmlAttribute(CassiniConfigConstants.URL)]
        public string Url { get; set; }

        [XmlAttribute(CassiniConfigConstants.VIRTUAL_ROOT)]
        public string VirtualRoot { get; set; }

        [XmlAttribute(CassiniConfigConstants.IS_RUNNING)]
        public bool IsRunning { get; set; }

        public Website ToWebsite()
        {
            return new Website
                       {
                           PhysicalPath = PhysicalPath,
                           VirtualRoot = VirtualRoot,
                           Port = Port,
                           IsRunning = IsRunning
                       };
        }

        public WebsiteHost ToWebsiteHost()
        {
            return new WebsiteHost(ToWebsite());
        }
    }
}
