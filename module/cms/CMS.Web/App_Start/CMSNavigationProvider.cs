using Abp.Application.Navigation;
using Abp.Localization;

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
                        url: "/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Channel",
                        new LocalizableString("Channel", CMSConsts.LocalizationSourceName),
                        url: "/channel",
                        icon: "fa fa-columns"
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Channels",
                                new LocalizableString("Channels", CMSConsts.LocalizationSourceName),
                                url: "/channel/channels",
                                icon: "fa fa-info")
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Content",
                        new LocalizableString("Content", CMSConsts.LocalizationSourceName),
                        url: "/content",
                        icon: "fa fa-envelope"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Template",
                        new LocalizableString("Template", CMSConsts.LocalizationSourceName),
                        url: "/template",
                        icon: "fa fa-edit"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Create",
                        new LocalizableString("Create", CMSConsts.LocalizationSourceName),
                        url: "/create",
                        icon: "fa fa-cutlery"
                        )
                );
        }
    }
}
