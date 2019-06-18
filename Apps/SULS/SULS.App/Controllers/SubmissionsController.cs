using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Submissions;
using SULS.App.ViewModels.Submissions;
using SULS.Models;
using SULS.Services;
using System;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemService problemService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemService problemService)
        {
            this.submissionsService = submissionsService;
            this.problemService = problemService;
        }

        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetById(id);

            if (problem == null)
            {
                this.Redirect("/");
            }

            var subView = new CreateSubmissionsViewModel()
            {
                Name = problem.Name,
                ProblemId = problem.Id
            };

            return this.View(subView);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateSubmissionsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Submission/Create?id=" + input.ProblemId);
            }

            var problem = this.problemService.GetById(input.ProblemId);

            if (problem == null)
            {
                return this.Redirect("/Submission/Create");
            }

            var rnd = new Random();
            var rndScore = rnd.Next(0, problem.Points);

            var submission = new Submission()
            {
                AchievedResult = rndScore,
                Code = input.Code,
                CreatedOn = DateTime.UtcNow,
                ProblemId = input.ProblemId,
                UserId = this.User.Id
            };

            this.submissionsService.Create(submission);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.submissionsService.DeleteSubmission(id);

            return this.Redirect("/");
        }
    }
}
