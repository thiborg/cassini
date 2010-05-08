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

namespace Cassini.Configuration
{
    public class CassiniWebsitesConfig : XmlSerializableDictionary<string, CassiniWebsiteConfig>
    {
        public CassiniWebsitesConfig()
            : base(CassiniConfigConstants.WEBSITE)
        {
        }
    }
}
