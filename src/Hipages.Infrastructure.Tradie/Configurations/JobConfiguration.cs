using Hipages.Domain.Tradie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Infrastructure.Tradie.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Suburb);
        }
    }
}
