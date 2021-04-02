using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LyyCMS.Articles.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Abp.AutoMapper;
using Abp.UI;
using Abp.Application.Services;

namespace LyyCMS.Articles
{
    public class ArticleCategoryAppService : 
        IAsyncCrudAppService<ArticleCategoryDto, int, PagedArticleCategoryResultRequestDto, CreateArticleCategoryDto, ArticleCategoryDto>,
        IArticleCategoryAppService
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

        [Obsolete("use GetAllAsync")]
        public async Task<List<ArticleCategoryListDto>> GetAllArticleCategoryListAsync()
        {
            var query = _resposotory.GetAll();
            var persons = await query.ToListAsync();

            var dtos = persons.MapTo<List<ArticleCategoryListDto>>();
            foreach(ArticleCategoryListDto listDto in dtos){
                ArticleCategory parent = persons.FirstOrDefault(x => x.Id == listDto.Id).Parent;
                listDto.ParentId = parent == null ? 0 : parent.Id;
                listDto.ParentName = parent == null ? "无" : parent.Name;
            }
            //order
            dtos = dtos.OrderBy(x => x.OrderNum).OrderBy(x => x.ParentId).ToList();
            return dtos;
        }

        public async Task<ArticleCategoryDto> GetAsync(EntityDto<int> input)
        {
            var category = await _resposotory.GetAsync(input.Id);
            return category.MapTo<ArticleCategoryDto>();
        }

        public async Task<PagedResultDto<ArticleCategoryDto>> GetAllAsync(PagedArticleCategoryResultRequestDto input)
        {
            var query = _resposotory.GetAll();
            var count = await query.CountAsync();
            var persons = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = persons.MapTo<List<ArticleCategoryDto>>();
            var pagedReulstArticleCategory = new PagedResultDto<ArticleCategoryDto>(count, dtos);
            
            return pagedReulstArticleCategory;
        }

        public async Task<ArticleCategoryDto> CreateAsync(CreateArticleCategoryDto input)
        {
            int pid = input.ParentId;
            var category = await _resposotory.GetAsync(pid);
            ArticleCategory articleCategory = new ArticleCategory();
            articleCategory.Name = input.Name;
            articleCategory.OrderNum = input.OrderNum;
            articleCategory.Description = input.Description;
            articleCategory.Parent = category;

            await _resposotory.InsertAsync(articleCategory);
            return articleCategory.MapTo<ArticleCategoryDto>();
        }

        public async Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryEditDto input)
        {
            int pid = input.ParentId;
            var category = await _resposotory.GetAsync(pid);
            ArticleCategory articleCategory = new ArticleCategory();
            articleCategory.Name = input.Name;
            articleCategory.OrderNum = input.OrderNum;
            articleCategory.Description = input.Description;
            articleCategory.Parent = category;

            await _resposotory.UpdateAsync(articleCategory);

            return articleCategory.MapTo<ArticleCategoryDto>();
        }

        public async Task DeleteAsync(EntityDto<int> input)
        {
            var p = await _resposotory.GetAsync(input.Id);
            if (p == null)
            {
                throw new UserFriendlyException("数据不存在");
            }
            await _resposotory.DeleteAsync(input.Id);
        }

        public Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto input)
        {
            throw new NotImplementedException();
        }
    }
}
