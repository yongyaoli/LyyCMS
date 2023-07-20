﻿using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace LyyCMS.SysManage.Dto
{
    public class GetSysDictInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public string FilterText { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
