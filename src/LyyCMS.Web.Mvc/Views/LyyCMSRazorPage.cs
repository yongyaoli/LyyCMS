using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LyyCMS.Web.Views
{
    public abstract class LyyCMSRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LyyCMSRazorPage()
        {
            LocalizationSourceName = LyyCMSConsts.LocalizationSourceName;
        }
    }
}
