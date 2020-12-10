using LDW.Domain.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LDW.Domain.Constants;

namespace LDW.WebAPI.Models
{
    public class RegisterUserApiModel
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
