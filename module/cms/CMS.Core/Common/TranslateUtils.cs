using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public class TranslateUtils
    {
        public static string GetStringValueFromNullable(Nullable<string> value)
        {
            if (value.HasValue)
            {
                return (string)Convert.ChangeType(value.Value, typeof(string));
            }
            else
            {
                return string.Empty;
            }
        }

        public static long GetInt64ValueFromNullable(Nullable<long> value)
        {
            if (value.HasValue)
            {
                return (long)Convert.ChangeType(value.Value, typeof(long));
            }
            else
            {
                return 0;
            }
        }
    }
}
