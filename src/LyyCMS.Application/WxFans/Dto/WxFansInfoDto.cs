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
    [AutoMapFrom(typeof(WxFansInfo))]
    public class WxFansInfoDto : EntityDto<int>
    {

        public virtual WeChatAccount weCha { get; set; }

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

        public int groupid { get; set; }

        /// <summary>
        /// 是否关注,值为0时，代表此用户没有关注该公众号
        /// </summary>
        public int subscribe { get; set; }

        public string remark { get; set; }

        /// <summary>
        /// 关注的渠道
        /// </summary>
        public string subscribe_scene { get; set; }

        public string qr_scene { get; set; }

        public string qr_scene_str { get; set; }
    }
}
