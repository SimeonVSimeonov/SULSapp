using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;
using SULS.App.BindingModels.Problems;
using SULS.App.ViewModels.Problems;
using SULS.Models;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemService problemService;
        private readonly ISubmissionsService submissionsService;

        public ProblemsController(IProblemService problemService, 
            ISubmissionsService submissionsService)
        {
            this.problemService = problemService;
            this.submissionsService = submissionsService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProblemInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            Problem problem = ModelMapper.ProjectTo<Problem>(input);
            this.problemService.Create(problem);
            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var name = this.problemService.GetById(id).Name;

            var submission = this.submissionsService.GetAllSubmissions(id)
                .Select(x => new ProblemsDetailViewModel()
                {
                    SubmissionId = x.Id,
                    AchievedResult = x.AchievedResult,
                    MaxPoints = x.Problem.Points,
                    CreatedOn = x.CreatedOn,
                    Username = x.User.Username
                }).ToList();

            var all = new ProblemSubmissionsViewModel() {Name = name, Submissions = submission };
                

            return this.View(all);
        }
    }
}
