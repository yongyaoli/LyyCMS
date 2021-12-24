using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using LyyCMS.Authorization;

namespace LyyCMS.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class LyyCMSNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("Member"),
                        url: "Member",
                        icon: "fas fa-info-circle"
                    )
                )
                .AddItem( 
                    new MenuItemDefinition(
                        "Article",
                        L("Article"),
                        icon: "fas fa-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.ArticleCategory,
                            L("ArticleCategory"),
                            url: "ArticleCategory",
                            icon: "fa fa-tags"
                        )
                        ).AddItem(
                        new MenuItemDefinition(
                            "Article",
                            L("Article"),
                            url: "Article",
                            icon: "fa fa-book"
                        )
                        )
                    )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Slide,
                        L("Slide"),
                        url: "Slide",
                        icon: "fas fa-image"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "WeChat",
                        L("WeChat"),
                        icon: "fas fa-tags"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.WeChatAccount,
                            L("WeChatAccount"),
                            url: "WeChatAccount",
                            icon: "fa fa-tags"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "WeChatMenu",
                            L("WeChatMenu"),
                            url: "WeChatMenu",
                            icon: "fa fa-book"
                        )
                    )
                )
                 .AddItem(
                    new MenuItemDefinition(
                        "Site",
                        L("Site"),
                        icon: "fas fa-tags"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.WeChatAccount,
                            L("Site"),
                            url: "Site",
                            icon: "fa fa-tags"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "Channel",
                            L("Channel"),
                            url: "Channel",
                            icon: "fa fa-book"
                        )
                    )
                )
                .AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "MultiLevelMenu",
                        L("MultiLevelMenu"),
                        icon: "fas fa-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetBoilerplate",
                            new FixedLocalizableString("ASP.NET Boilerplate"),
                            icon: "far fa-circle"
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetboilerplate.com?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateTemplates",
                                new FixedLocalizableString("Templates"),
                                url: "https://aspnetboilerplate.com/Templates?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateSamples",
                                new FixedLocalizableString("Samples"),
                                url: "https://aspnetboilerplate.com/Samples?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetZero",
                            new FixedLocalizableString("ASP.NET Zero"),
                            icon: "far fa-circle"
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetzero.com?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFeatures",
                                new FixedLocalizableString("Features"),
                                url: "https://aspnetzero.com/Features?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroPricing",
                                new FixedLocalizableString("Pricing"),
                                url: "https://aspnetzero.com/Pricing?ref=abptmpl#pricing",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFaq",
                                new FixedLocalizableString("Faq"),
                                url: "https://aspnetzero.com/Faq?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetzero.com/Documents?ref=abptmpl",
                                icon: "far fa-dot-circle"
                            )
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LyyCMSConsts.LocalizationSourceName);
        }
    }
}
