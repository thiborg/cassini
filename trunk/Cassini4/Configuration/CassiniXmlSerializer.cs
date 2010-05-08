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
    using System.IO;
    using System.Xml.Serialization;

    public class CassiniXmlSerializer
    {
        public static void Serialize<T>(T obj, string fileName) 
        {
            using(var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof (T));
                serializer.Serialize(writer, obj);
                writer.Close();
            }
        }

        public static T Deserialize<T>(string fileName) where T : new()
        {
            var obj = new T();
            using (var reader = new StreamReader(fileName))
            {
                var serializer = new XmlSerializer(typeof(T));

                obj = (T) serializer.Deserialize(reader);
                reader.Close();
            }

            return obj;
        }
    }
}
