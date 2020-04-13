using Hipages.Domain.Tradie.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hipages.Application.Tradie.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Job> Jobs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
