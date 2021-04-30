
using Abp.Runtime.Validation;
using LyyCMS.Dtos;
using LyyCMS.Members;

namespace LyyCMS.Members.Dtos
{
	/// <summary>
	/// 获取验证码的传入参数Dto
	/// </summary>
    public class GetVerificationCodesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
