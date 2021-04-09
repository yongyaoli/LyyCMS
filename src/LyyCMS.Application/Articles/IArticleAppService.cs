using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using LyyCMS.Articles.Dtos;
using System.Threading.Tasks;

namespace LyyCMS.Articles
{
    public interface IArticleAppService :
         IAsyncCrudAppService<ArticleDto, int, PagedArticleResultRequestDto, CreateArticleDto, ArticleDto>
    {

        /// <summary>
        /// 启用文章
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ActiveArticle(Entity<int> input);


        Task<PagedResultDto<ArticleListDto>> GetPagedArticleAsync(GetArticleInput input);


        Task<ArticleDto> CreateArticleAsync(CreateArticleDto input);

    }

}
