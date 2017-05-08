using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels.Extensions
{
    public static class Helper
    {
        public static string[] FormatString(this string input, string[] separators)
        {
            var output = new List<string>();
            //string[] stringSeparators = new string[] { "[split]" };
            var splits = input.Split(separators, StringSplitOptions.None);

            for (var i = 0; i < splits.Length; i++)
            {
                output.Add(splits[i]);
            }

            return output.ToArray();
        }
    }
}
