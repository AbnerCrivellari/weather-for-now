using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.API.Utils
{
    public static class Extensions
    {
        public static string ConvertToUrl(this string str)
        {
            var tst = str.Replace(' ', '+');
            StringBuilder result = new StringBuilder();
            var ts = tst.Split(',');
            for (int i = 0; i < ts.Length; i++)
            {
                if (i != 0)
                {
                    result.Append("%2C");
                }
                result.Append(ts[i]);
            }

            return result.ToString();
        }

    }
}
