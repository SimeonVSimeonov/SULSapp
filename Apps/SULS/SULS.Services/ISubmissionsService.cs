using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        Submission Create(Submission submission);

        IQueryable<Submission> GetAllSubmissions(string id);

        void DeleteSubmission(string id);

    }
}
