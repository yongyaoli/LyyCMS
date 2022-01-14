using Abp.Application.Services;
using LyyCMS.Authorization.Roles;
using LyyCMS.Roles.Dto;
using LyyCMS.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.Regions.Dtos;
using LyyCMS.Dtos;
using Abp.Domain.Repositories;

namespace LyyCMS.Regions
{
    public class RegionAppService : AsyncCrudAppService<Region, RegionDto, int, PagedSortedAndFilteredInputDto, CreateRegionDto, RegionDto>, IRegionAppService
    {
        public RegionAppService(IRepository<Region, int> repository) : base(repository)
        {
        }
    }
}
