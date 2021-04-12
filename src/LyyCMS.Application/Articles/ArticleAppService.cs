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
using Castle.Core.Logging;


namespace LyyCMS.Articles
{
    public class ArticleAppService :
        AsyncCrudAppService<Article, ArticleDto, int, PagedArticleResultRequestDto, CreateArticleDto, ArticleDto, ArticleListDto, ArticleDto>,
        IArticleAppService
    {
        public ILogger Logger { get; set; }

        private readonly IRepository<Article> _resposotory;
        private readonly IRepository<ArticleCategory> _categoryRepository;

        public ArticleAppService(IRepository<Article> repository, IRepository<ArticleCategory> categoryRepository) : base(repository)
        {
            _resposotory = repository;
            _categoryRepository = categoryRepository;
            Logger = NullLogger.Instance;
        }

        public async Task ActiveArticle(Entity<int> input)
        {
            await Repository.UpdateAsync(input.Id, async (entity) =>
            {
                entity.status = 1;
            });
        }

        public async Task<ArticleDto> CreateArticleAsync(CreateArticleDto input)
        {
            Logger.Info("start create article");
            var id = input.articleCategoryId;
            var cate = _categoryRepository.FirstOrDefaultAsync(x => x.Id == id).Result;
            input.category = cate;
            var dtos = ObjectMapper.Map<Article>(input);
            await _resposotory.InsertAsync(dtos);
            return MapToEntityDto(dtos);
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

        public async Task<ArticleDto> UpdateEntryAsync(ArticleEditDto input)
        {
            var article = await GetEntityByIdAsync(input.Id);

            ObjectMapper.Map(input, article);
            var cate = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == input.articleCategoryId);
            article.category = cate;
            await _resposotory.UpdateAsync(article);
            return MapToEntityDto(article);
        }


    }
}
