using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.WeChat;

namespace LyyCMS.WxFans
{
    /// <summary>
    /// 粉丝分组
    /// </summary>
    public class WxFansGroup: FullAuditedEntity
    {

        public WeChatAccount weCha { get; set; }

        public string name { get; set; }

        public int count { get; set; }

        public int groupId { get; set; }
    }
}
