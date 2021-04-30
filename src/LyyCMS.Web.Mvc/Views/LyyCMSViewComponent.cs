using Abp.AspNetCore.Mvc.ViewComponents;

namespace LyyCMS.Web.Views
{
    public abstract class LyyCMSViewComponent : AbpViewComponent
    {
        protected LyyCMSViewComponent()
        {
            LocalizationSourceName = LyyCMSConsts.LocalizationSourceName;
        }
    }
}
