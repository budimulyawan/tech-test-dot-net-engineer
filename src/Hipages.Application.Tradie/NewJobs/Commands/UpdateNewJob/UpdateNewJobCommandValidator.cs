using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Application.Tradie.NewJobs.Commands.UpdateNewJob
{
    class UpdateNewJobCommandValidator : AbstractValidator<UpdateNewJobCommand>
    {
        public UpdateNewJobCommandValidator()
        {
            RuleFor(v => v.JobStatus).IsInEnum();
        }
    }
}
