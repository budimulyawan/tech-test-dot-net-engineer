using AutoMapper;
using Hipages.Application.Tradie.Common.Mappings;
using Hipages.Domain.Tradie.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Application.Tradie.NewJobs.Queries.GetNewJobs
{
    public class NewJobDto : IMapFrom<Job>
    {
        public int Id { get; set; }
        public string SuburbName { get; set; }
        public string SuburbPostCode { get; set; }

        public string CategoryName { get; set; }

        public string ContactFirstName { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountAmount { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Job, NewJobDto>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.Name))
                .ForMember(d => d.SuburbName, opt => opt.MapFrom(s => s.Suburb.Name))
                .ForMember(d => d.SuburbPostCode, opt => opt.MapFrom(s => s.Suburb.PostCode));
        }
    }
}
