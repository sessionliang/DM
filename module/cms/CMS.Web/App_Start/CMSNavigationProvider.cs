using Abp.Application.Navigation;
using Abp.Localization;
using CMS.Common;

namespace CMS.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class CMSNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", CMSConsts.LocalizationSourceName),
                        url: PageUtils.GetCMSAdminControllerUrl("/"),
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Channel",
                        new LocalizableString("Channel", CMSConsts.LocalizationSourceName),
                        url: PageUtils.GetCMSAdminControllerUrl("/channel"),
                        icon: "fa fa-columns"
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Channels",
                                new LocalizableString("channel", CMSConsts.LocalizationSourceName),
                                url: PageUtils.GetCMSAdminControllerUrl("/channel/index"),
                                icon: "fa fa-info")
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Content",
                        new LocalizableString("Content", CMSConsts.LocalizationSourceName),
                        url: PageUtils.GetCMSAdminControllerUrl("/content"),
                        icon: "fa fa-envelope"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Template",
                        new LocalizableString("Template", CMSConsts.LocalizationSourceName),
                        url: PageUtils.GetCMSAdminControllerUrl("/template"),
                        icon: "fa fa-edit"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Create",
                        new LocalizableString("Create", CMSConsts.LocalizationSourceName),
                        url: PageUtils.GetCMSAdminControllerUrl("/create"),
                        icon: "fa fa-cutlery"
                        )
                );
        }
    }
}
