using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class ChannelController : CMSControllerBase
    {

        /// <summary>
        /// 栏目列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(PageUtils.GetCMSAdminViewUrl("channel/index.cshtml"));
        }

        /// <summary>
        /// 创建栏目
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateNode()
        {
            return View(PageUtils.GetCMSAdminViewUrl("channel/createNode.cshtml"));
        }
    }
}