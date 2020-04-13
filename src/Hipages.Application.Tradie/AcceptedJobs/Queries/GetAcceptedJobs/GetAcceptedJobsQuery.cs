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

namespace Hipages.Application.Tradie.AcceptedJobs.Queries.GetAcceptedJobs
{
    public class GetAcceptedJobsQuery : IRequest<AcceptedJobsVm>
    {
    }

    public class GetAcceptedJobsQueryHandler : IRequestHandler<GetAcceptedJobsQuery, AcceptedJobsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAcceptedJobsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AcceptedJobsVm> Handle(GetAcceptedJobsQuery request, CancellationToken cancellationToken)
        {
            return new AcceptedJobsVm()
            {
                Lists = await _context.Jobs.Where(j => j.JobStatus == Domain.Tradie.Enums.JobStatusEnum.Accepted)
                .ProjectTo<AcceptedJobDto>(_mapper.ConfigurationProvider)
                .OrderBy(j => j.Created)
                .ToListAsync(cancellationToken)
            };
        }
    }
}
