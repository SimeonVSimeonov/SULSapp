using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public interface IProblemService
    {
        IQueryable<Problem> GetAllproblems();

        Problem Create(Problem problem);

        Problem GetById(string id);
    }
}
