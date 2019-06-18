using SULS.Data;
using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public class ProblemService : IProblemService
    {
        private readonly SULSContext context;
        private readonly IUserService userService;

        public ProblemService(SULSContext sulsContext)
        {
            this.context = sulsContext;
        }

        public Problem Create(Problem problem)
        {
            problem = context.Problems.Add(problem).Entity;
            context.SaveChanges();

            return problem;
        }

        public IQueryable<Problem> GetAllproblems()
        {
            return this.context.Problems;
        }

        public Problem GetById(string id)
        {
            var problem = this.context.Problems.FirstOrDefault(x => x.Id == id);

            return problem;
        }
    }
}
