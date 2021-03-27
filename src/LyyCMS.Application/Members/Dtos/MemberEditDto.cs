using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Members.Dtos
{
    [AutoMapTo(typeof(Member))]
    public class MemberEditDto:FullAuditedEntityDto
    {

        public int? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LoginName { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string LoginPass { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Phone]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress]
        [MaxLength(80)]
        public string Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(250)]
        public string Address { get; set; }

        /// <summary>
        /// 会员分类
        /// </summary>
        public Category category { get; set; }
    }
}
