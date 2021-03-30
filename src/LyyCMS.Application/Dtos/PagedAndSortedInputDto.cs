

using Abp.Application.Services.Dto;

namespace LyyCMS.Dtos
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }


		 
		 
         

        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppLtmConsts.DefaultPageSize;
        }
    }
}