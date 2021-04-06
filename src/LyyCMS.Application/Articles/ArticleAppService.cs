using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using LyyCMS.Articles.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles
{
    public class ArticleAppService :
        AsyncCrudAppService<Article, ArticleDto, int, PagedArticleResultRequestDto, CreateArticleDto, ArticleDto>,
        IArticleAppService
    {

        private readonly IRepository<Article> _resposotory;

        public ArticleAppService(IRepository<Article> repository) : base(repository)
        {
            _resposotory = repository;

        }

        public async Task ActiveArticle(Entity<int> input)
        {
            await Repository.UpdateAsync(input.Id, async (entity) =>
            {
                entity.status = 1;
            });
        }
    }
}
