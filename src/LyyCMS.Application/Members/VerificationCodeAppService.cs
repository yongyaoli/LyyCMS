
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

namespace LyyCMS.Members
{
    /// <summary>
    /// 验证码应用层服务的接口实现方法
    ///</summary>
    //[AbpAuthorize]
    public class VerificationCodeAppService : LyyCMSAppServiceBase, IVerificationCodeAppService
    {
        private readonly IRepository<VerificationCode, int>
            _verificationCodeRepository;

        //private readonly IVerificationCodeListExcelExporter _verificationCodeListExcelExporter;

        private readonly IVerificationCodeManager _verificationCodeManager;
        /// <summary>
        /// 构造函数
        /// </summary>
        public VerificationCodeAppService(
        IRepository<VerificationCode, int>
verificationCodeRepository
            , IVerificationCodeManager verificationCodeManager
            )
        {
            _verificationCodeRepository = verificationCodeRepository;
            _verificationCodeManager = verificationCodeManager;

        }


        /// <summary>
        /// 获取验证码的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Query)]
        public async Task<PagedResultDto<VerificationCodeListDto>> GetPaged(GetVerificationCodesInput input)
        {

            var query = _verificationCodeRepository.GetAll()
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
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Query)]
        public async Task<VerificationCodeListDto> GetById(EntityDto<int> input)
        {
            var entity = await _verificationCodeRepository.GetAsync(input.Id);

            var dto = ObjectMapper.Map<VerificationCodeListDto>(entity);
            return dto;
        }

        /// <summary>
        /// 获取编辑 验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Create, VerificationCodePermissions.VerificationCode_Edit)]
        public async Task<GetVerificationCodeForEditOutput> GetForEdit(NullableIdDto<int> input)
        {
            var output = new GetVerificationCodeForEditOutput();
            VerificationCodeEditDto editDto;

            if (input.Id.HasValue)
            {
                var entity = await _verificationCodeRepository.GetAsync(input.Id.Value);
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
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Create)]
        protected virtual async Task<VerificationCodeEditDto> Create(VerificationCodeEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = ObjectMapper.Map<VerificationCode>(input);
            //调用领域服务
            entity = await _verificationCodeManager.CreateAsync(entity);

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

            var entity = await _verificationCodeRepository.GetAsync(input.Id.Value);
            //  input.MapTo(entity);
            //将input属性的值赋值到entity中
            ObjectMapper.Map(input, entity);
            await _verificationCodeManager.UpdateAsync(entity);
        }



        /// <summary>
        /// 删除验证码信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _verificationCodeManager.DeleteAsync(input.Id);
        }



        /// <summary>
        /// 批量删除VerificationCode的方法
        /// </summary>
        [AbpAuthorize(VerificationCodePermissions.VerificationCode_BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:批量删除前的逻辑判断，是否允许删除
            await _verificationCodeManager.BatchDelete(input);
        }




        /// <summary>
        /// 导出验证码为excel文件
        /// </summary>
        /// <returns></returns>
        //[AbpAuthorize(VerificationCodePermissions.VerificationCode_ExportExcel)]
        //public async Task<FileDto> GetToExcelFile()
        //{
        //   var verificationCodes = await _verificationCodeManager.QueryVerificationCodes().ToListAsync();
        //          var verificationCodeListDtos = ObjectMapper.Map<List<VerificationCodeListDto>>(verificationCodes);
        //          return _verificationCodeListExcelExporter.ExportToExcelFile(verificationCodeListDtos);
        //}



        //// custom codes



        //// custom codes end

    }
}


