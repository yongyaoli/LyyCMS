using System.ComponentModel.DataAnnotations;

namespace LyyCMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}