using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Members.Dtos
{
    [AutoMapFrom(typeof(VerificationCode))]
    public class VerificationCodeDto : EntityDto<int>
    {
        /// <summary>
        /// 账号： 邮箱/手机号
        /// </summary>
        public string member { get; set; }


        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }


        public int Count { get; set; }
    }
}
