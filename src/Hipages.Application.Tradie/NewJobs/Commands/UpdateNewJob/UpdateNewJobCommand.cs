using Hipages.Application.Tradie.Common.Exceptions;
using Hipages.Application.Tradie.Common.Interfaces;
using Hipages.Domain.Tradie.Entities;
using Hipages.Domain.Tradie.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hipages.Application.Tradie.NewJobs.Commands.UpdateNewJob
{
    public class UpdateNewJobCommand : IRequest
    {
        public int Id { get; set; }

        public JobStatusEnum JobStatus { get; set; }
    }

    public class UpdateNewJobCommandHandler : IRequestHandler<UpdateNewJobCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateNewJobCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateNewJobCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Jobs.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Job), request.Id);
            }

            entity.SetJobStatus(request.JobStatus);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
