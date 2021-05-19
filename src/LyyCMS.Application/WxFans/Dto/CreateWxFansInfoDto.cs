using Abp.AutoMapper;
using LyyCMS.WeChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.WeChat.Dto;

namespace LyyCMS.WxFans.Dto
{
    [AutoMapTo(typeof(WxFansInfo))]
    public class CreateWxFansInfoDto
    {
        public WeChatAccountDto weCha { get; set; }

        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string language { get; set; }
        public string headimgurl { get; set; }
        public DateTime subscribe_time { get; set; }
        public string unionid { get; set; }
    }
}
