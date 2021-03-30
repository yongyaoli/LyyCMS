
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
    public interface IVerificationCodeAppService : IApplicationService
    {
        /// <summary>
		/// 获取验证码的分页列表集合
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<VerificationCodeListDto>> GetPaged(GetVerificationCodesInput input);


		/// <summary>
		/// 通过指定id获取验证码ListDto信息
		/// </summary>
		Task<VerificationCodeListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体验证码的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetVerificationCodeForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改验证码的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateVerificationCodeInput input);


        /// <summary>
        /// 删除验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);

		
        /// <summary>
        /// 批量删除验证码
        /// </summary>
        Task BatchDelete(List<int> input);


		
		
		/// <summary>
		/// 导出验证码为excel文件
		/// </summary>
		/// <returns></returns>
		//Task<FileDto> GetToExcelFile();

    }
}
