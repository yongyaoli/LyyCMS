using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Articles;
using LyyCMS.Articles.Dtos;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyyCMS.SysManage
{
    public class SysDictItemAppService : AsyncCrudAppService<SysDictItem, SysDictItemDto, int, PagedUserResultRequestDto, CreateSysDictItemDto, SysDictItemDto>, ISysDictItemAppService
    {
        private readonly IRepository<SysDictItem> _respository;

        public SysDictItemAppService(IRepository<SysDictItem> repository) : base(repository)
        {
            _respository = repository;
        }

        public Task<List<SysDictItemListDto>> GetAllSysDictItemListAsync()
        {
            throw new System.NotImplementedException();
        }

        //public Task<List<SysDictItemListDto>> GetAllSysDictItemListAsync()
        //{
        //    //var articleCate = await _respository.GetAllIncluding(x => x.Children).ToListAsync();
        //    //var dtos = ObjectMapper.Map<List<ArticleCategoryListDto>>(articleCate);
        //    //return dtos;
        //}
    }
}
