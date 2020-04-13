using Hipages.Domain.Tradie.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hipages.Application.Tradie.Common.Events
{
    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
    {
        public TDomainEvent DomainEvent { get; }

        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
