using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemSubmissionsViewModel
    {
        public ProblemSubmissionsViewModel()
        {
            this.Submissions = new List<ProblemsDetailViewModel>();
        }

        public string Name { get; set; }

        public List<ProblemsDetailViewModel> Submissions { get; set; }
    }
}
