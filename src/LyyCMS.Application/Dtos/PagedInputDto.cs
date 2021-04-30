

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace LyyCMS.Dtos
{
    public class PagedInputDto : IPagedResultRequest
    {
        [Range(1, AppLtmConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }



		 
		 
         


        public PagedInputDto()
        {
            MaxResultCount = AppLtmConsts.DefaultPageSize;
        }
    }
}