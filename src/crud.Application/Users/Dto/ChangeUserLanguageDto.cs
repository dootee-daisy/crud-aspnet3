using System.ComponentModel.DataAnnotations;

namespace crud.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}