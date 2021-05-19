using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LyyCMS.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.WxFans.Dto
{
    [AutoMapFrom(typeof(WxFansGroup))]
    public class WxFansGroupDto : EntityDto<int>
    {
        public WeChatAccount WeChatAccount { get; set; }

        public string name { get; set; }

        public int count { get; set; }

        public int groupId { get; set; }
    }
}
