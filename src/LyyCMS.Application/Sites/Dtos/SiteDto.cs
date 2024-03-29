﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LyyCMS.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Sites.Dtos
{
    [AutoMapFrom(typeof(Site))]
    public class SiteDto : EntityDto<int>
    {
        public string guid { get; set; }

        public string extendValues { get; set; }
        public string siteDir { get; set; }
        public string siteName { get; set; }
        public string siteType { get; set; }

        public string imageUrl { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string tableName { get; set; }
        public string root { get; set; }
        public int parentId { get; set; }

        public int OrderNum { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
    }
}
