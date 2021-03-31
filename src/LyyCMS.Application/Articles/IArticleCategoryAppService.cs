using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles
{
    public interface IArticleCategoryAppService : IApplicationService
    {

        Task<PagedResultDto<ArticleCategoryListDto>> GetPagedArticleCategoryAsync(GetArticleCategoryInput input);

        Task<List<ArticleCategoryListDto>> GetAllArticleCategoryListAsync();

    }
}
