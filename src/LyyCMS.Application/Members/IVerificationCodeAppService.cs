
using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
//using L._52ABP.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using LyyCMS.Members.Dtos;
using LyyCMS.Members;



namespace LyyCMS.Members
{
    /// <summary>
    /// 验证码应用层服务的接口方法
    ///</summary>
    public interface IVerificationCodeAppService :
        IAsyncCrudAppService<VerificationCodeDto, int, PagedCommonResultRequestDto, CreateVerificationCodeDto, VerificationCodeDto>
    {
        


    }
}
