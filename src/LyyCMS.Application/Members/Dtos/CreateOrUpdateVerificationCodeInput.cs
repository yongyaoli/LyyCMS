

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LyyCMS.Members;

namespace LyyCMS.Members.Dtos
{
    public class CreateOrUpdateVerificationCodeInput
    {
        [Required]
        public VerificationCodeEditDto VerificationCode { get; set; }
							
    }
}