using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Linq;

namespace LyyCMS.SysManage
{
    public class SysDictAppService : AsyncCrudAppService<SysDict, SysDictDto, int, PagedUserResultRequestDto, CreateSysDictDto, SysDictDto>, ISysDictAppService
    {
        private readonly IRepository<SysDict> _sysDictRepository;
        private readonly IRepository<SysDictItem> _sysDictItemRepository;

        public SysDictAppService(IRepository<SysDict> repository, IRepository<SysDictItem> itemRepository) : base(repository)
        {
            _sysDictItemRepository = itemRepository;
            _sysDictRepository = repository; 
        }

        public async Task<PagedResultDto<SysDictListDto>> GetPagedSysDictAsync(GetSysDictInput input)
        {
            var dict = _sysDictRepository.GetAll();
            var item = _sysDictItemRepository.GetAll();
            var count = await dict.CountAsync();

            #region 第一种 直接关联查询 然后 清空子表
            var dictPage = await dict.Include(x=>x.SysDictItems).OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtoDict = ObjectMapper.Map<List<SysDictListDto>>(dictPage);
            foreach(var _item in dtoDict)
            {
                foreach(var _item2 in item)
                {
                    _item2.SysDict = null;
                }
            }
            #endregion


            #region  第二种另外查询
            //var dictPage = await dict.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            //var dtoDict = ObjectMapper.Map<List<SysDictListDto>>(dictPage);
            //foreach (var _item in dtoDict)
            //{
            //    var itemDto = await item.Where(x => x.SysDictId == _item.Id).ToListAsync();
            //    var itemListDto = ObjectMapper.Map<List<SysDictItemListDto>>(itemDto);
            //    _item.SysDictItems = itemListDto;
            //}
            #endregion
            var pagedSysDict = new PagedResultDto<SysDictListDto>(count, dtoDict);
            return pagedSysDict;

        }
    }
}
