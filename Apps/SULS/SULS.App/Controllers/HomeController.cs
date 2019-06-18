using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Problems;
using SULS.Services;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemService problemService;
        public HomeController(IProblemService problemService)
        {
            this.problemService = problemService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {

            if (this.IsLoggedIn())
            {
                var problems = problemService.GetAllproblems()
                    .Select(x => new ProblemsViewModel()
                    {
                        Name = x.Name,
                        Id = x.Id,
                        Count = x.Submissions.Count
                    }).ToList();

                return this.View(problems, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}