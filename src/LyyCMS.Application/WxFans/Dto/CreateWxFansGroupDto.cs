using Abp.AutoMapper;
using LyyCMS.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.WxFans.Dto
{
    [AutoMapTo(typeof(WxFansGroup))]
    public class CreateWxFansGroupDto
    {
        public WeChatAccount WeChatAccount { get; set; }

        public string name { get; set; }

        public int count { get; set; }

        public int groupId { get; set; }
    }
}
