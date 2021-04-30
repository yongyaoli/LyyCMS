using System.ComponentModel.DataAnnotations;

namespace LyyVueCMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}