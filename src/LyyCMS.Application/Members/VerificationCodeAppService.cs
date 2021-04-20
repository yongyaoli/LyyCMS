
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.Domain.Repositories;
//using L._52ABP.Application.Dtos;
//using L._52ABP.Common.Extensions.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using LyyCMS.Members;
using LyyCMS.Members.Dtos;
using LyyCMS.Members.DomainService;
using LyyCMS.Authorization;
using Abp.Application.Services;

namespace LyyCMS.Members
{
    /// <summary>
    /// 验证码应用层服务的接口实现方法
    ///</summary>
    //[AbpAuthorize]
    public class VerificationCodeAppService :
        AsyncCrudAppService<VerificationCode, VerificationCodeDto, int, PagedCommonResultRequestDto, CreateVerificationCodeDto, VerificationCodeDto>,
        IVerificationCodeAppService
    {
        private readonly IRepository<VerificationCode> _resposotory;
        /// <summary>
        /// 构造函数
        /// </summary>
        public VerificationCodeAppService(IRepository<VerificationCode> repository) : base(repository)
        {
            _resposotory = repository;
        }


        /// <summary>
        /// 获取验证码的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(VerificationCodePermissions.VerificationCode_Query)]
        public async Task<PagedResultDto<VerificationCodeListDto>> GetPaged(GetVerificationCodesInput input)
        {

            var query = _resposotory.GetAll()
            .WhereIf(!input.FilterText.IsNullOrWhiteSpace(), a =>
                          //模糊搜索member
                          a.member.Contains(input.FilterText) ||
                          a.Code.Contains(input.FilterText)
            );


            var count = await query.CountAsync();

            var verificationCodeList = await query
            .OrderBy(input.Sorting).AsNoTracking()
            .PageBy(input)
            .ToListAsync();

            var verificationCodeListDtos = ObjectMapper.Map<List<VerificationCodeListDto>>(verificationCodeList);

            return new PagedResultDto<VerificationCodeListDto>(count, verificationCodeListDtos);
        }


        /// <summary>
        /// 通过指定id获取VerificationCodeListDto信息
        /// </summary>
        //[AbpAuthorize(VerificationCodePermissions.VerificationCode_Query)]
        public async Task<VerificationCodeListDto> GetById(EntityDto<int> input)
        {
            var entity = await _resposotory.GetAsync(input.Id);

            var dto = ObjectMapper.Map<VerificationCodeListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        //[AbpAuthorize(VerificationCodePermissions.VerificationCode_Create, VerificationCodePermissions.VerificationCode_Edit)]
        public async Task<GetVerificationCodeForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetVerificationCodeForEditOutput();
            VerificationCodeEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _resposotory.GetAsync(input.Id.Value);
                editDto = ObjectMapper.Map<VerificationCodeEditDto>(entity);
            }
            else
            {
                editDto = new VerificationCodeEditDto();
            }
            output.VerificationCode = editDto;
            return output;
        }


        /// <summary>
        /// 添加或者修改验证码的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Create, VerificationCodePermissions.VerificationCode_Edit)]
        public async Task CreateOrUpdate(CreateOrUpdateVerificationCodeInput input)
        {

            if (input.VerificationCode.Id.HasValue)
            {
                await Update(input.VerificationCode);
            }
            else
            {
                await Create(input.VerificationCode);
            }
        }


        /// <summary>
        /// 新增验证码
        /// </summary>
        protected virtual async Task<VerificationCodeEditDto> Create(VerificationCodeEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<VerificationCode>(input);
            //调用领域服务
            await _resposotory.InsertAsync(entity);

            var dto = ObjectMapper.Map<VerificationCodeEditDto>(entity);
            return dto;
        }

        /// <summary>
        /// 编辑验证码
        /// </summary>
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Edit)]
        protected virtual async Task Update(VerificationCodeEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _resposotory.GetAsync(input.Id.Value);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _resposotory.UpdateAsync(entity);
        }



    }
}


