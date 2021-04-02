using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyyCMS.Articles
{
    //IApplicationService
    public interface IArticleCategoryAppService :
        IAsyncCrudAppService<ArticleCategoryDto, int, PagedArticleCategoryResultRequestDto, CreateArticleCategoryDto, ArticleCategoryDto>
    {

        Task<PagedResultDto<ArticleCategoryListDto>> GetPagedArticleCategoryAsync(GetArticleCategoryInput input);

        [Obsolete]
        Task<List<ArticleCategoryListDto>> GetAllArticleCategoryListAsync();


    }
}
