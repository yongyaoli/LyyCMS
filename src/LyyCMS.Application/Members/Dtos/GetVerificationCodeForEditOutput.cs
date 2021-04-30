
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using LyyCMS.Members;

namespace LyyCMS.Members.Dtos
{
	/// <summary>
	/// 读取可编辑验证码的Dto
	/// </summary>
    public class GetVerificationCodeForEditOutput
    {

        public VerificationCodeEditDto VerificationCode { get; set; }

							//// custom codes		
							

							//// custom codes end
    }
}