using LDW.Domain.Constants;
using LDW.Domain.Resources;
using System.ComponentModel.DataAnnotations;

namespace LDW.WebAPI.Models
{
    public class LoginUserApiModel
    {
        [RegularExpression(ValidationConstants.EmailRegex,
            ErrorMessageResourceName = nameof(Translations.INVALID_EMAIL),
            ErrorMessageResourceType = typeof(Translations))]
        public string Email { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Translations.PASSWORD_REQUIRED),
            ErrorMessageResourceType = typeof(Translations))]
        [MaxLength(ValidationConstants.PasswordMaxLength)]
        [MinLength(ValidationConstants.PasswordMinLength)]
        public string Password { get; set; }
    }
}
