using Hipages.Domain.Tradie.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hipages.Application.Tradie.Common.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DomainEventDispatcher> _log;
        public DomainEventDispatcher(IMediator mediator, ILogger<DomainEventDispatcher> log)
        {
            _mediator = mediator;
            _log = log;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {

            var domainEventNotification = _createDomainEventNotification(domainEvent);
            _log.LogDebug("Dispatching Domain Event as MediatR notification.  EventType: {eventType}", domainEvent.GetType());
            await _mediator.Publish(domainEventNotification);
        }

        private INotification _createDomainEventNotification(IDomainEvent domainEvent)
        {
            var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
            return (INotification)Activator.CreateInstance(genericDispatcherType, domainEvent);
        }
    }
}
