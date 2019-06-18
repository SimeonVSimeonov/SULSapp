using SIS.MvcFramework.Attributes.Validation;
using SULS.App.Common;

namespace SULS.App.BindingModels.Submissions
{
    public class CreateSubmissionsInputModel
    {
        [RequiredSis]
        [StringLengthSis(30, 800, ExamConstants.CodeLenghtErorr)]
        public string Code { get; set; }

        [RequiredSis]
        public string ProblemId { get; set; }

    }
}
