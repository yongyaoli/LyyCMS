

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace  LyyCMS.Dtos
{
    public class PagedAndFilteredInputDto : IPagedResultRequest
    {
        [Range(1, LyyCMSConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public string FilterText { get; set; }


		 
		 
         


        public PagedAndFilteredInputDto()
        {
            MaxResultCount = LyyCMSConsts.DefaultPageSize;
        }
    }
}