using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Members
{
    /// <summary>
    /// 验证码
    /// </summary>
    public class VerificationCode: Abp.Domain.Entities.Auditing.FullAuditedEntity
    {
        /// <summary>
        /// 账号： 邮箱/手机号
        /// </summary>
        [Required]
        public string member { get; set; }


        /// <summary>
        /// 发送时间
        /// </summary>
        [Required]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        [Required]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        [MaxLength(6)]
        public string Code { get; set; }

        [Required]
        public int Count { get; set; }

    }
}
