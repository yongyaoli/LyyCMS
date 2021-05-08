using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;

namespace LyyCMS.WeChat.Dto
{
    [AutoMapTo(typeof(WeChatAccount))]
    public class CreateWxAccountDto
    {
        /// <summary>
        /// 公众号名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 公众号原始ID
        /// </summary>
        public string Originalid { get; set; }

        /// <summary>
        /// 公众平台微信号
        /// </summary>
        public string WechatCode { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        [Required]
        public string AppId { get; set; }

        /// <summary>
        /// AppSecret
        /// </summary>
        [Required]
        public string AppSecret { get; set; }

        /// <summary>
        /// 内容推送 网站内容 推送到微信
        /// </summary>
        public bool Push { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        [DefaultValue(99)]
        public int SortId { get; set; }
    }
}
