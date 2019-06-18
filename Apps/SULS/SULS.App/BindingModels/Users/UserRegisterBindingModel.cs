using SIS.MvcFramework.Attributes.Validation;
using SULS.App.Common;

namespace SULS.App.Users.BindingModels
{
    public class UserRegisterBindingModel
    {
        [RequiredSis(ExamConstants.UsernameMissingErrorMessage)]
        [StringLengthSis(5, 20, ExamConstants.UsernameLenghtErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ExamConstants.PasswordMissingErrorMessage)]
        [PasswordSis(ExamConstants.PasswordsNotEqualErrorMessage)]
        [StringLengthSis(6, 20, ExamConstants.PassworLenghtErrorMessage)]
        public string Password { get; set; }

        [RequiredSis(ExamConstants.ConfirmPasswordMissingErrorMessage)]
        public string ConfirmPassword { get; set; }

        [RequiredSis(ExamConstants.EmailMissingErrorMessage)]
        [EmailSis(ExamConstants.EmailNotCorrectFormatErrorMessage)]
        public string Email { get; set; }
    }
}
