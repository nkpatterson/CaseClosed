using Abp.Application.Features;
using Abp.Localization;
using Abp.UI.Inputs;

namespace CaseClosed.Features
{
    public class AppFeatureProvider : FeatureProvider
    {
        public override void SetFeatures(IFeatureDefinitionContext context)
        {
            context.Create(
                FeatureNames.SmokeTests,
                "true",
                displayName: L("SmokeTests"),
                inputType: new CheckboxInputType());
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, CaseClosedConsts.LocalizationSourceName);
        }
    }
}
