

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace LyyCMS.Dtos
{
    public class PagedInputDto : IPagedResultRequest
    {
        [Range(1, LyyCMSConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }



		 
		 
         


        public PagedInputDto()
        {
            MaxResultCount = LyyCMSConsts.DefaultPageSize;
        }
    }
}