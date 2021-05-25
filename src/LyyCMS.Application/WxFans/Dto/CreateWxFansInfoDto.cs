using Abp.AutoMapper;
using LyyCMS.WeChat;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.WeChat.Dto;

namespace LyyCMS.WxFans.Dto
{
    [AutoMapTo(typeof(WxFansInfo))]
    public class CreateWxFansInfoDto
    {
        [Required]
        public int weChaId { get; set; }

        public virtual WeChatAccount weCha { get; set; }

        [Required]
        public string openid { get; set; }
        [Required]
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
