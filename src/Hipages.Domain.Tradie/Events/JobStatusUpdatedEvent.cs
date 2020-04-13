using Hipages.Domain.Tradie.Entities;
using Hipages.Domain.Tradie.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Domain.Tradie.Events
{
    public class JobStatusUpdatedEvent : IDomainEvent
    {
        public Job Job { get; }
        public JobStatusUpdatedEvent(Job job)
        {
            this.Job = job;
        }
    }
}
