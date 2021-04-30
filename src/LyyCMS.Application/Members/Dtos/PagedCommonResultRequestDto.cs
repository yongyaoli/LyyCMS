using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace LyyCMS.Members.Dtos
{
    public class PagedCommonResultRequestDto : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public string Keyword { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
