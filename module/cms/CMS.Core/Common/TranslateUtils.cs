using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public class TranslateUtils
    {
        /// <summary>
        /// 转换为int
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int ToInt(object obj)
        {
            return ToInt(obj, 0);
        }
        public static int ToInt(object obj, int defaultVal)
        {
            if (obj == null)
            {
                return defaultVal;
            }
            else
            {
                int result = defaultVal;
                if (int.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return defaultVal;
            }
        }
    }
}
