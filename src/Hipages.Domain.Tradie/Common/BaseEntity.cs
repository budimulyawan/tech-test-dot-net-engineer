using Hipages.Domain.Tradie.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hipages.Domain.Tradie.Common
{
    public abstract class BaseEntity 
    {
        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        [NotMapped]
        private readonly ConcurrentQueue<IDomainEvent> _domainEvents = new ConcurrentQueue<IDomainEvent>();

        [NotMapped]
        public IProducerConsumerCollection<IDomainEvent> DomainEvents => _domainEvents;

        protected void PublishEvent(IDomainEvent @event)
        {
            _domainEvents.Enqueue(@event);
        }

    }
}
