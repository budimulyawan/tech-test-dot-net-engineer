using Hipages.Domain.Tradie.Common;
using Hipages.Domain.Tradie.Enums;
using Hipages.Domain.Tradie.Events;
using Hipages.Domain.Tradie.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Domain.Tradie.Entities
{
    public class Job : BaseEntity
    {
        public Job()
        {
            JobStatus = JobStatusEnum.New;
        }

        public int Id { get; set; }
        public Suburb Suburb { get; set; }

        public Category Category { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }
        
        public string ContactPhone { get; set; }
        
        public string ContactEmail { get; set; }
        
        public decimal Price { get; set; }

        public decimal? DiscountAmount { get; set; }

        public string Description { get; set; }

        public JobStatusEnum JobStatus { get; private set; }

        public void SetJobStatus(JobStatusEnum jobStatusEnum)
        {
            this.JobStatus = jobStatusEnum;
            this.PublishEvent(new JobStatusUpdatedEvent(this));
        }
    }
}
