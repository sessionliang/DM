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
            public const string ADMIN_VIEW_Url = "~/App/Main/views/";
            public const string ADMIN_CONTROLLER_URL = CMSConsts.AdminName;
        }

        public static string GetCMSAdminViewUrl(string relatedUrl)
        {
            if (string.IsNullOrEmpty(relatedUrl))
                relatedUrl = "home/home.cshtml";
            relatedUrl = relatedUrl.Trim("/".ToCharArray());
            return Path.Combine(CMSAdmin.ADMIN_VIEW_Url, relatedUrl);
        }

        public static string GetCMSAdminControllerUrl(string relatedUrl)
        {
            if (string.IsNullOrEmpty(relatedUrl))
                relatedUrl = "home/index";
            relatedUrl = relatedUrl.Trim("/".ToCharArray());
            return Path.Combine(CMSAdmin.ADMIN_CONTROLLER_URL, "/", relatedUrl).Replace("//", "/");
        }
    }
}
