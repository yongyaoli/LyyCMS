
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Abp.Domain.Entities.Auditing;
using System.Collections.ObjectModel;
using LyyCMS.Members;
using Abp.AutoMapper;

namespace LyyCMS.Members.Dtos
{
    /// <summary>
    /// 验证码的列表DTO
    /// <see cref="VerificationCode"/>
    /// </summary>
    [AutoMapTo(typeof(VerificationCode))]
    public class VerificationCodeEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }



        /// <summary>
        /// member
        /// </summary>
        [Required(ErrorMessage = "member不能为空")]
        public string member { get; set; }



        /// <summary>
        /// SendTime
        /// </summary>
        [Required(ErrorMessage = "SendTime不能为空")]
        public DateTime SendTime { get; set; }



        /// <summary>
        /// ExpireTime
        /// </summary>
        [Required(ErrorMessage = "ExpireTime不能为空")]
        public DateTime ExpireTime { get; set; }



        /// <summary>
        /// Code
        /// </summary>
        [MaxLength(6)]
        [Required(ErrorMessage = "Code不能为空")]
        public string Code { get; set; }



        /// <summary>
        /// Count
        /// </summary>
        [Required(ErrorMessage = "Count不能为空")]
        public int Count { get; set; }


    }
}