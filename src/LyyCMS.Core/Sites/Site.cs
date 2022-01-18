using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.Sites
{
    /// <summary>
    /// 站点
    /// </summary>
    public class Site : FullAuditedEntity
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
        public char root { get; set; }
        public int parentId { get; set; }
        [Required]
        [DefaultValue(99)]
        public int OrderNum { get; set; }

        public virtual ICollection<Channel> Channels { get; set; }
    }
}
