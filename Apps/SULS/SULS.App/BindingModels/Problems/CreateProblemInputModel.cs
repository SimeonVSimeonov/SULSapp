﻿using SIS.MvcFramework.Attributes.Validation;
using SULS.App.Common;

namespace SULS.App.BindingModels.Problems
{
    public class CreateProblemInputModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, ExamConstants.ProblemNameErrorLenght)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, ExamConstants.ProblemPointsErrorValue)]
        public int Points { get; set; }

        /*<h1 class="text-center suls-text-color">Create Problem</h1>
<form class="mx-auto half-width col-5" method="post" action="/Problems/Create">
    @Widgets.ValidationWidget
    <div class="top-border-line primary-separator"></div>
    <div class="form-group">
        <label for="name" class="suls-text-color">Name</label>
        <input type="text" class="form-control" id="name" placeholder="Name..." name="name">
    </div>
    <div class="form-group">
        <label for="points" class="suls-text-color">Total Points</label>
        <input type="number" class="form-control" id="points" placeholder="Total Points..." name="points">
    </div>
    <div class="top-border-line primary-separator"></div>
    <div class="button-holder d-flex justify-content-center">
        <button type="submit" class="btn suls-bg-color">Create</button>
    </div>
</form>*/
    }
}
