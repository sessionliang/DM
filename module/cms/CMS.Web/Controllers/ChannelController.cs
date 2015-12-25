using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class ChannelController : Controller
    {

        /// <summary>
        /// 栏目列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(PageUtils.GetCMSAdminUrl("channel/channels.cshtml"));
        }

        /// <summary>
        /// 栏目列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Channels()
        {
            return Index();
        }
    }
}