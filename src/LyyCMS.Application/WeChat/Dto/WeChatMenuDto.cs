using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace LyyCMS.WeChat.Dto
{
    [AutoMapFrom(typeof(WeChatMenu))]
    public class WeChatMenuDto : EntityDto<int>
    {
        /// <summary>
        /// 公众号ID
        /// </summary>
        [Required]
        public int WxId { get; set; }

        /// <summary>
        /// 公众号
        /// </summary>
        public WeChatAccount WeChatAccount { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// 菜单内容 包含图片和media以及返回菜单的文字内容
        /// </summary>
        public string value { get; set; }

        /// <summary>
        /// 菜单类型:1 URl;2回复文字类型；3回复图片类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// view菜单对应的url或者是图片对应的url
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 菜单对应的eventkey
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 左到右顺序:1,2,3
        /// </summary>
        public int wOrder { get; set; }

        /// <summary>
        /// 上到下顺序
        /// </summary>
        public int hOrder { get; set; }

        /// <summary>
        /// 是否底部菜单
        /// </summary>
        public bool footMenu { get; set; }

        /// <summary>
        /// 1表示作为子菜单,2表示其他选项
        /// </summary>
        public int useType { get; set; }
    }
}
