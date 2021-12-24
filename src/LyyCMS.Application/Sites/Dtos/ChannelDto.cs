using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Sites.Dtos
{
    [AutoMapFrom(typeof(Channel))]
    public class ChannelDto : EntityDto<int>
    {
        public string guid { get; set; }
        public string extendValues { get; set; }
        public string channelName { set; get; }

        public int siteId { get; set; }

        public virtual Site site { get; set; }
        public string contentModelPluginId { get; set; }
        public string tableName { get; set; }
        [DefaultValue(0)]
        public int parentId { get; set; }
        public string parentsPath { get; set; }
        [DefaultValue(0)]
        public int parentsCount { get; set; }
        [DefaultValue(0)]
        public int childrenCount { get; set; }
        public string indexName { get; set; }
    }
}
