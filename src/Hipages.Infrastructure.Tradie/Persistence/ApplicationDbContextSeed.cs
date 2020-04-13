using Hipages.Domain.Tradie.Entities;
using Hipages.Domain.Tradie.Enums;
using Hipages.Domain.Tradie.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hipages.Infrastructure.Tradie.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed category, if necessary
            if (!context.Categories.Any())
            {
                var plumbing = new Category { Name = "Plumbing" };
                var electrical = new Category { Name = "Electrical" };
                var carpentry = new Category { Name = "Carpentry" };
                var handyman = new Category { Name = "Handyman" };
                var building = new Category { Name = "Building" };
                var bathRoomRenovation = new Category { Name = "Bathroom Renovation", ParentCategory = building };

                context.Categories.Add(plumbing);
                context.Categories.Add(electrical);
                context.Categories.Add(carpentry);
                context.Categories.Add(handyman);
                context.Categories.Add(building);
                context.Categories.Add(bathRoomRenovation);

                await context.SaveChangesAsync();
            }

            // Seed jobs, if necessary
            if (!context.Jobs.Any())
            {
                var suburbs = new Suburb[]
                {
                    new Suburb() { Name = "Sydney", PostCode = "2000" },
                    new Suburb() { Name = "Bondi", PostCode = "2026" },
                    new Suburb() { Name = "Manly", PostCode = "2095" },
                    new Suburb() { Name = "Surry Hills", PostCode = "2010" },
                    new Suburb() { Name = "Newtown", PostCode = "2042" },
                    new Suburb() { Name = "Killara", PostCode = "2071" },
                };
                var categories = context.Categories.ToArray();


                var job1 = new Job()
                {
                    Category = categories[0],
                    ContactEmail = "luke@mailinator.com",
                    ContactFirstName = "Luke",
                    ContactLastName = "Skywalker",
                    ContactPhone = "0412345678",
                    Price = 20,
                    Description = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex.",
                    Suburb = suburbs[0],
                };

              
                var job2 = new Job()
                {
                    Category = categories[1],
                    ContactEmail = "luke@mailinator.com",
                    ContactFirstName = "Luke",
                    ContactLastName = "Skywalker",
                    ContactPhone = "0412345678",
                    Price = 2000,
                    Description = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex.",
                    Suburb = suburbs[1],
                };

                var job3 = new Job()
                {
                    Category = categories[2],
                    ContactEmail = "luke@mailinator.com",
                    ContactFirstName = "Luke",
                    ContactLastName = "Skywalker",
                    ContactPhone = "0412345678",
                    Price = 30,
                    Description = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex.",
                    Suburb = suburbs[2],
                };

                var job4 = new Job()
                {
                    Category = categories[3],
                    ContactEmail = "luke@mailinator.com",
                    ContactFirstName = "Luke",
                    ContactLastName = "Skywalker",
                    ContactPhone = "0412345678",
                    Price = 200,
                    Description = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex.",
                    Suburb = suburbs[3],
                };

                var job5 = new Job()
                {
                    Category = categories[4],
                    ContactEmail = "luke@mailinator.com",
                    ContactFirstName = "Luke",
                    ContactLastName = "Skywalker",
                    ContactPhone = "0412345678",
                    Price = 20,
                    Description = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex.",
                    Suburb = suburbs[4],
                };


                context.Jobs.Add(job1);
                context.Jobs.Add(job2);
                context.Jobs.Add(job3);
                context.Jobs.Add(job4);
                context.Jobs.Add(job5);

                await context.SaveChangesAsync();
            }
        }
    }
}
