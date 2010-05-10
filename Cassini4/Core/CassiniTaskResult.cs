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

using System;
using System.Collections;
using System.Collections.Generic;

namespace Cassini
{
    public class CassiniTaskResult
    {
        public const string NoResult = null;

        public bool Success { get; set; }
        public ArrayList Results = new ArrayList();
        public List<Exception> Exceptions = new List<Exception>();

        public CassiniTaskResult()
        {
            Success = false;
        }
    }
}
