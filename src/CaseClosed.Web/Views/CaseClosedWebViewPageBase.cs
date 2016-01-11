using Abp.Web.Mvc.Views;

namespace CaseClosed.Web.Views
{
    public abstract class CaseClosedWebViewPageBase : CaseClosedWebViewPageBase<dynamic>
    {

    }

    public abstract class CaseClosedWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected CaseClosedWebViewPageBase()
        {
            LocalizationSourceName = CaseClosedConsts.LocalizationSourceName;
        }
    }
}