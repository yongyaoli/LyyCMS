using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using LyyCMS.Articles.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace LyyCMS.Articles
{
    public class ArticleAppService :
        AsyncCrudAppService<Article, ArticleDto, int, PagedArticleResultRequestDto, CreateArticleDto, ArticleDto>,
        IArticleAppService
    {

        private readonly IRepository<Article> _resposotory;
        private readonly IRepository<ArticleCategory> _categoryRepository;

        public ArticleAppService(IRepository<Article> repository, IRepository<ArticleCategory> categoryRepository) : base(repository)
        {
            _resposotory = repository;
            _categoryRepository = categoryRepository;

        }

        public async Task ActiveArticle(Entity<int> input)
        {
            await Repository.UpdateAsync(input.Id, async (entity) =>
            {
                entity.status = 1;
            });
        }

        public async Task<PagedResultDto<ArticleListDto>> GetPagedArticleAsync(GetArticleInput input)
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = ObjectMapper.Map<List<ArticleListDto>>(persons);
            foreach(var d in dtos){
                d.categoryId = d.articleCategoryId;
                var category = _categoryRepository.FirstOrDefaultAsync(x => x.Id == d.articleCategoryId).Result;
                d.categoryName = category == null ? "无" : category.Name;
            }
            var pagedReulstArticle = new PagedResultDto<ArticleListDto>(personcount, dtos);

            return pagedReulstArticle;


        }
    }
}
