using SIS.MvcFramework.Attributes.Validation;
using SULS.App.Common;

namespace SULS.App.Users.BindingModels
{
    public class UserLoginBindingModel
    {
        [RequiredSis(ExamConstants.UsernameMissingErrorMessage)]
        [StringLengthSis(5, 20, ExamConstants.UsernameLenghtErrorMessage)]
        public string Username { get; set; }

        [RequiredSis(ExamConstants.PasswordMissingErrorMessage)]
        [StringLengthSis(6, 20, ExamConstants.PassworLenghtErrorMessage)]
        public string Password { get; set; }
    }
}
