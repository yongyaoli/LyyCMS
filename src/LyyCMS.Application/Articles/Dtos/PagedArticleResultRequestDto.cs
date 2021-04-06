using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles.Dtos
{
    public class PagedArticleResultRequestDto : PagedAndSortedResultRequestDto, IShouldNormalize
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
