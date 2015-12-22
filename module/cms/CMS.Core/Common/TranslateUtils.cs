using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public class TranslateUtils
    {
        public static T GetValueFromNullable<T>(object value)
        {
            if (value != null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            else
            {
                return default(T);
            }
        }
    }
}
