using Abp.Application.Services;
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


    }

}
