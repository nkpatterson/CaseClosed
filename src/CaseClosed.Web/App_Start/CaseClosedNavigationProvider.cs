using Abp.Application.Features;
using Abp.Application.Navigation;
using Abp.Localization;
using CaseClosed.Authorization;
using CaseClosed.Features;

namespace CaseClosed.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class CaseClosedNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(new MenuItemDefinition(
                    "Cases",
                    L("Cases"),
                    url: "/Cases",
                    requiresAuthentication: true)
                    .AddItem(new MenuItemDefinition(
                        "My Cases",
                        L("MyCases"),
                        url: "/Cases"))
                    .AddItem(new MenuItemDefinition(
                        "Establish Case",
                        L("EstablishCase"),
                        url: "/Cases/Create"))
                )
                .AddItem(new MenuItemDefinition(
                    "Operations",
                    L("Operations"),
                    url: "/Operations",
                    requiresAuthentication: true)
                    .AddItem(new MenuItemDefinition(
                        "My Operations",
                        L("MyOperations"),
                        url: "/Operations"))
                    .AddItem(new MenuItemDefinition(
                        "New Operation",
                        L("NewOperation"),
                        url: "/Operations/Create"))
                    .AddItem(new MenuItemDefinition(
                        "De-Confliction",
                        L("DeConfliction"),
                        url: "/Operations/DeConfliction"))
                    .AddItem(new MenuItemDefinition(
                        "Command Center",
                        L("CommandCenter"),
                        url: "/Operations/CommandCenter"))
                )
                .AddItem(new MenuItemDefinition(
                    "Subjects",
                    L("Subjects"),
                    url: "/Subjects",
                    requiresAuthentication: true)
                    .AddItem(new MenuItemDefinition(
                        "All Subjects",
                        L("AllSubjects"),
                        url: "/Subjects"))
                    .AddItem(new MenuItemDefinition(
                        "NewSubject",
                        L("NewSubject"),
                        url: "/Subject/Create"))
                    .AddItem(new MenuItemDefinition(
                        "De-Confliction",
                        L("DeConfliction"),
                        url: "/Operations/DeConfliction"))
                )
                .AddItem(new MenuItemDefinition(
                    "Inventory",
                    L("Inventory"),
                    url: "/Inventory",
                    requiresAuthentication: true)
                    .AddItem(new MenuItemDefinition(
                        "My Inventory",
                        L("MyInventory"),
                        url: "/Inventory"))
                    .AddItem(new MenuItemDefinition(
                        "Submit Inventory",
                        L("SubmitInventory"),
                        url: "/Inventory/Create"))
                    .AddItem(new MenuItemDefinition(
                        "Seizures",
                        L("Seizures"),
                        url: "/Inventory/Seizures"))
                    .AddItem(new MenuItemDefinition(
                        "Assets",
                        L("Assets"),
                        url: "/Inventory/Assets"))
                )
                .AddItem(new MenuItemDefinition(
                    "Reports",
                    L("Reports"),
                    url: "/Reports",
                    requiresAuthentication: true)
                )
                .AddItem(new MenuItemDefinition(
                    "Settings",
                    L("Settings"),
                    url: "/Settings",
                    icon: "fa fa-gear",
                    requiresAuthentication: true)
                    .AddItem(new MenuItemDefinition(
                        "Permissions",
                        L("Permissions"),
                        url: "/Settings/Permissions"))
                    .AddItem(new MenuItemDefinition(
                        "Users",
                        L("Users"),
                        url: "/Settings/Users"))
                    .AddItem(new MenuItemDefinition(
                        "Reference Data",
                        L("ReferenceData"),
                        url: "/Settings/ReferenceData"))
                    .AddItem(new MenuItemDefinition(
                        "Organization Data",
                        L("OrganizationData"),
                        url: "/Settings/OrganizationData"))
                    .AddItem(new MenuItemDefinition(
                        "Form Templates",
                        L("FormTemplates"),
                        url: "/Settings/FormTemplates"))
                    .AddItem(new MenuItemDefinition(
                        "Workflows",
                        L("Workflows"),
                        url: "/Settings/Workflows"))
                    .AddItem(new MenuItemDefinition(
                        "Smoke Tests",
                        L("SmokeTests"),
                        featureDependency: new SimpleFeatureDependency(FeatureNames.SmokeTests),
                        url: "/SmokeTests",
                        requiredPermissionName: PermissionNames.SmokeTests))
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CaseClosedConsts.LocalizationSourceName);
        }
    }
}
