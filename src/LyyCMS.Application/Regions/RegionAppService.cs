using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Dtos;
using LyyCMS.Regions.Dtos;

namespace LyyCMS.Regions
{
    public class RegionAppService : AsyncCrudAppService<Region, RegionDto, int, PagedSortedAndFilteredInputDto, CreateRegionDto, RegionDto>, IRegionAppService
    {
        public RegionAppService(IRepository<Region, int> repository) : base(repository)
        {
        }
    }
}
