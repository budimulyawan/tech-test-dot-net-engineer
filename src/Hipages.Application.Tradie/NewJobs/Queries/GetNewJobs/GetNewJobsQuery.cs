using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hipages.Application.Tradie.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hipages.Application.Tradie.NewJobs.Queries.GetNewJobs
{
    public class GetNewJobsQuery : IRequest<NewJobsVm>
    {
    }

    public class GetAcceptedJobsQueryHandler : IRequestHandler<GetNewJobsQuery, NewJobsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAcceptedJobsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NewJobsVm> Handle(GetNewJobsQuery request, CancellationToken cancellationToken)
        {
            return new NewJobsVm()
            {
                Lists = await _context.Jobs.Where(j => j.JobStatus == Domain.Tradie.Enums.JobStatusEnum.New)
                .ProjectTo<NewJobDto>(_mapper.ConfigurationProvider)
                .OrderBy(j => j.Created)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
