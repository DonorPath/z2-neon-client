using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z2Systems.Neon.NeonService;

namespace Z2Systems.Neon
{
    internal static class Helpers
    {

        public static string GetValue(this NameValuePair[] data, string name)
        {
            var item = data.SingleOrDefault(x => x.name == name);
            if (item == null)
                return "";
            else
                return item.value;
        }
    }
}
