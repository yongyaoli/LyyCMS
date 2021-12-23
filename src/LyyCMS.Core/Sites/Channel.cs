using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Sites
{
    public class Channel : FullAuditedEntity
    {
        public string guid { get; set; }

        public string extendValues { get; set; }
        [Required]
        public string channelName { set; get; }

        [Required]
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

        public string groupNames { set; get; }

        public string imageUrl { get; set; }
        public string content { get; set; }
        public string filePath { get; set; }
        public string channelFilePathRule { get; set; }
        public string contentFilePathRule { get; set; }
        public string linkUrl { get; set; }
        public string linkType { get; set; }
        [DefaultValue(0)]
        public int channelTemplteId { get; set; }
        [DefaultValue(0)]
        public int contentTemplateId { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }

        [Required]
        [DefaultValue(99)]
        public int OrderNum { get; set; }

    }
}
