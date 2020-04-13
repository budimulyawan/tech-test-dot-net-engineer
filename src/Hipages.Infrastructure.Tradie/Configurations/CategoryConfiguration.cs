using Hipages.Domain.Tradie.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Infrastructure.Tradie.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasOne(c => c.ParentCategory)
                 .WithMany()
                .HasForeignKey(c => c.ParentCategoryId);
            builder.ToTable("category");
        }
    }
}
