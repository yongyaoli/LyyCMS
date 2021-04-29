using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using LyyCMS.Members.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Abp.Application.Services;
using LyyCMS.Articles.Dtos;
using LyyCMS.Articles;

namespace LyyCMS.Members
{
    public class CategoryAppService :
        AsyncCrudAppService<Category, CategoryDto, int, PagedArticleResultRequestDto, CategoryEditDto, CategoryDto, CategoryListDto>,
        ICategoryAppService
    {
        private readonly IRepository<Category> _resposotory;

        public CategoryAppService(IRepository<Category> repository) : base(repository)
        {
            _resposotory = repository;
        }


        public async Task CreateOrUpdateCategoryAsync(CreateOrUpdateCategoryDtoInput input)
        {
            if (input.edit.Id.HasValue)
            {
                await UpdateCategoryAsync(input.edit);
            }
            else
            {
                await CreateCategoryAsync(input.edit);
            }


            throw new NotImplementedException();
        }

        public async Task DeleteCategoryAsync(EntityDto input)
        {
            var p = await _resposotory.GetAsync(input.Id);
            if (p == null)
            {
                throw new UserFriendlyException("数据不存在");
            }
            await _resposotory.DeleteAsync(input.Id);
        }

        public async Task<CategoryListDto> GetCategoryByIdAsync(NullableIdDto input)
        {
            var category = await _resposotory.GetAsync(input.Id.Value);
            return category.MapTo<CategoryListDto>();
        }

        public async Task<PagedResultDto<CategoryListDto>> GetPagedCategoryAsync(GetCategoryInput input)
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var categories = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            //var dtos = AutoMapperObjectMapper.
            var dtos = categories.MapTo<List<CategoryListDto>>();
            var pagedReulstMember = new PagedResultDto<CategoryListDto>(personcount, dtos);

            return pagedReulstMember;
        }


        public async Task<PagedResultDto<CategoryListDto>> GetPagedAllCategoryAsync()
        {
            var query = _resposotory.GetAll();
            var personcount = await query.CountAsync();

            var persons = await query.ToListAsync();

            var dtos = persons.MapTo<List<CategoryListDto>>();
            var pagedReulstMember = new PagedResultDto<CategoryListDto>(personcount, dtos);

            return pagedReulstMember;
        }



        protected async Task UpdateCategoryAsync(CategoryEditDto input)
        {
            var p = await _resposotory.GetAsync(input.Id.Value);
            await _resposotory.UpdateAsync(input.MapTo(p));

        }

        protected async Task CreateCategoryAsync(CategoryEditDto input)
        {
            await _resposotory.InsertAsync(input.MapTo<Category>());
        }
    }
}
