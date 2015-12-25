using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common
{
    public static class PageUtils
    {
        public static class CMSAdmin
        {
            public const string ADMIN_Url = "~/App/Main/views/";
        }

        public static string GetCMSAdminUrl(string relatedUrl)
        {
            if (string.IsNullOrEmpty(relatedUrl))
                relatedUrl = "home/index";
            relatedUrl = relatedUrl.Trim("/".ToCharArray());
            return Path.Combine(CMSAdmin.ADMIN_Url, relatedUrl);
        }
    }
}
