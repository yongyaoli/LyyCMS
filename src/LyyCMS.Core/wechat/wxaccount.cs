using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.wechat
{
    /// <summary>
    /// 微信公众号
    /// </summary>
    public class wxaccount: FullAuditedEntity
    {
        [Required]
        public string name;

        public string originalid;

        public string wxcode;

        public string token;

        [Required]
        public string appid;

        [Required]
        public string appsecret;

        public string is_push;

        [Required]
        [DefaultValue(99)]
        public int sort_id;

        [Required]
        public DateTime add_time;
    }
}
