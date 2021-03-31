using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LyyCMS.Articles.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Abp.AutoMapper;

namespace LyyCMS.Articles
{
    public class ArticleCategoryAppService : IArticleCategoryAppService
    {

        private readonly IRepository<ArticleCategory> _resposotory;

        public ArticleCategoryAppService(IRepository<ArticleCategory> repository)
        {
            _resposotory = repository;
        }

        public async Task<PagedResultDto<ArticleCategoryListDto>> GetPagedArticleCategoryAsync(GetArticleCategoryInput input)
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var dtos = persons.MapTo<List<ArticleCategoryListDto>>();
            var pagedReulstArticleCategory = new PagedResultDto<ArticleCategoryListDto>(personcount, dtos);

            return pagedReulstArticleCategory;
        }

        public async Task<List<ArticleCategoryListDto>> GetAllArticleCategoryListAsync()
        {
            var query = _resposotory.GetAll();
            var persons = await query.ToListAsync();

            var dtos = persons.MapTo<List<ArticleCategoryListDto>>();

            return dtos;
        }
    }
}
