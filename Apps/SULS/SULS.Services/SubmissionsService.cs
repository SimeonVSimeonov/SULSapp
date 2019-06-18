using SULS.Data;
using SULS.Models;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext context;

        public SubmissionsService(SULSContext context)
        {
            this.context = context;
        }
        public Submission Create(Submission submission)
        {
            submission = context.Submissions.Add(submission).Entity;
            context.SaveChanges();

            return submission;
        }

        public void DeleteSubmission(string id)
        {
            var submission =  this.context.Submissions.FirstOrDefault(x => x.Id == id);

            this.context.Submissions.Remove(submission);
            this.context.SaveChanges();
        }

        public IQueryable<Submission> GetAllSubmissions(string id)
        {
            var submissions = this.context.Submissions.Where(x => x.ProblemId == id);

            return submissions;
        }
    }
}
