using Abp.Application.Features;
using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using CaseClosed.Features;

namespace CaseClosed.Authorization
{
    public class CaseClosedAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var smokeTests = context.CreatePermission(PermissionNames.SmokeTests, L("SmokeTests"), featureDependency: new SimpleFeatureDependency(FeatureNames.SmokeTests));
            smokeTests.CreateChildPermission(PermissionNames.SmokeTests_Create, L("Create"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CaseClosedConsts.LocalizationSourceName);
        }
    }
}
