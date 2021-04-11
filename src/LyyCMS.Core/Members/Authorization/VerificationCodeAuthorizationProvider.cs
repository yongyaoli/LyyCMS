

using System.Linq;
using Abp;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using LyyCMS.Authorization;

// ReSharper disable once CheckNamespace
namespace LyyCMS.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="VerificationCodePermissions" /> for all permission names. VerificationCode
    ///</summary>
    public class VerificationCodeAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public VerificationCodeAuthorizationProvider()
        {

        }


        public VerificationCodeAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public VerificationCodeAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            // 在这里配置了VerificationCode 的权限。
            //var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //var administration = pages.Children.FirstOrDefault(p => p.Name == AppPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            //var verificationCode = administration.CreateChildPermission(VerificationCodePermissions.VerificationCode_Node, L("VerificationCode"));
            //verificationCode.CreateChildPermission(VerificationCodePermissions.VerificationCode_Query, L("QueryVerificationCode"));
            //verificationCode.CreateChildPermission(VerificationCodePermissions.VerificationCode_Create, L("CreateVerificationCode"));
            //verificationCode.CreateChildPermission(VerificationCodePermissions.VerificationCode_Edit, L("EditVerificationCode"));
            //verificationCode.CreateChildPermission(VerificationCodePermissions.VerificationCode_Delete, L("DeleteVerificationCode"));
            //verificationCode.CreateChildPermission(VerificationCodePermissions.VerificationCode_BatchDelete, L("BatchDeleteVerificationCode"));
            //verificationCode.CreateChildPermission(VerificationCodePermissions.VerificationCode_ExportExcel, L("ExportToExcel"));


            //// custom codes
            //context.CreatePermission(PermissionNames.Pages_Users, L("Users"));


            //// custom codes end
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpConsts.LocalizationSourceName);
        }
    }
}
