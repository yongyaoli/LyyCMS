using Abp.Application.Services;
using LyyCMS.Dtos;
using LyyCMS.Regions.Dtos;

namespace LyyCMS.Regions
{


    public interface IRegionAppService: IAsyncCrudAppService<RegionDto, int, PagedSortedAndFilteredInputDto, CreateRegionDto, RegionDto>
    {

    }
}
