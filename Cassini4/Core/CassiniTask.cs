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

    public class CassiniTask : ICassiniTask
    {
        public Guid ID = new Guid();
        public string Text { get; set; }
        public Func<dynamic, dynamic> Work { get; set; }
        public dynamic Argument { get; set; }

        public virtual dynamic Execute()
        {
            return (Work as Func<dynamic, dynamic>).Invoke(Argument);
        }
    }
}
