/*
    Asido/EpubSharp is licensed under the
    Mozilla Public License 2.0
    https://github.com/Asido/EpubSharp
    asido4@gmail.com
    https://github.com/Asido
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace bs.EpubSharp
{
    internal static class XmlExt
    {
        public static ICollection<string> AsStringList(this IEnumerable<XElement> self)
        {
            return self.Select(elem => elem.Value).ToList();
        }

        public static ICollection<T> AsObjectList<T>(this IEnumerable<XElement> self, Func<XElement, T> factory)
        {
            return self.Select(factory).Where(value => value != null).ToList();
        }
    }
}
