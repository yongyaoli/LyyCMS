﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using LyyCMS.Articles.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Extensions;

namespace LyyCMS.Articles
{
    public class ArticleCategoryAppService :
        AsyncCrudAppService<ArticleCategory, ArticleCategoryDto, int, PagedArticleCategoryResultRequestDto, CreateArticleCategoryDto, ArticleCategoryDto, ArticleCategoryListDto>,
        IArticleCategoryAppService
    {

        private readonly IRepository<ArticleCategory> _respository;

        private readonly IRepository<Article> _repositoryArticle;

        public ArticleCategoryAppService(IRepository<ArticleCategory> repository, IRepository<Article> repositoryArticle) : base(repository)
        {
            _respository = repository;
            _repositoryArticle = repositoryArticle;
        }

        public async Task<PagedResultDto<ArticleCategoryListDto>> GetPagedArticleCategoryAsync(GetArticleCategoryInput input)
        {
            var query = _respository.GetAll();
            var personcount = await query.CountAsync();

            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = ObjectMapper.Map<List<ArticleCategoryListDto>>(persons);
            var pagedReulstArticleCategory = new PagedResultDto<ArticleCategoryListDto>(personcount, dtos);

            return pagedReulstArticleCategory;
        }

        public async Task<ArticleCategoryDto> CreateEntityAsync(CreateArticleCategoryDto input)
        {
            int pid = input.ParentId;
            ArticleCategory category = null;
            if (pid > 0)
            {
                category = await _respository.GetAsync(pid);
            }

            ArticleCategory articleCategory = new ArticleCategory();
            articleCategory.Name = input.Name;
            articleCategory.OrderNum = input.OrderNum;
            articleCategory.Description = input.Description;
            articleCategory.Parent = pid == 0 ? null : category;

            await _respository.InsertAsync(articleCategory);
            return MapToEntityDto(articleCategory);
        }

        public async Task<ArticleCategoryDto> UpdateEntryAsync(ArticleCategoryEditDto input)
        {

            var articleCategory = await GetEntityByIdAsync(input.Id);

            ObjectMapper.Map(input, articleCategory);
            var parent = await GetEntityByIdAsync(input.ParentId);
            articleCategory.Parent = parent;
            await _respository.UpdateAsync(articleCategory);
            return MapToEntityDto(articleCategory);
        }

        public async Task DeleteEntityAsync(EntityDto<int> input)
        {
            var articleCategory = await Repository.GetAllIncluding(x => x.Children).FirstOrDefaultAsync(x => x.Id == input.Id);
            if (null == articleCategory)
            {
                throw new UserFriendlyException("数据不存在");
            }
            if (articleCategory.Children.Count > 0)
            {
                throw new UserFriendlyException("请选删除子级分类");
            }
            var articles = _repositoryArticle.GetAllListAsync().Result.Where(x => x.articleCategoryId == input.Id).ToList();
            if (null != articles && articles.Count > 0)
            {
                throw new UserFriendlyException("文章分类下存在文章，不能进行删除");
            }
            await Repository.DeleteAsync(articleCategory);
        }


        //public override async Task<ArticleCategory> GetEntityByIdAsync(int id)
        //{
        //    var user = await _respository.GetAllIncluding(x => x.Children).FirstOrDefaultAsync(x => x.Id == id);

        //    if (user == null)
        //    {
        //        throw new EntityNotFoundException(typeof(ArticleCategory), id);
        //    }

        //    return user;
        //}

        public async Task<List<ArticleCategoryListDto>> GetAllArticleCategoryListAsync()
        {
            var articleCate = await _respository.GetAllIncluding(x => x.Children).ToListAsync();
            var dtos = ObjectMapper.Map<List<ArticleCategoryListDto>>(articleCate);
            return dtos;
        }
    }
}
