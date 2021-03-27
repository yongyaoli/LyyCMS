using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Members.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Members
{
    public interface ICategoryAppService: IApplicationService
    {
        /// <summary>
        /// 分页获取会员信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CategoryListDto>> GetPagedCategoryAsync(GetCategoryInput input);


        Task<CategoryListDto> GetCategoryByIdAsync(NullableIdDto input);

        Task CreateOrUpdateCategoryAsync(CreateOrUpdateCategoryDtoInput input);

        Task DeleteCategoryAsync(EntityDto input);

        Task<PagedResultDto<CategoryListDto>> GetPagedAllCategoryAsync();

    }
}
