using Hipages.Application.Tradie.Common.Events;
using Hipages.Domain.Tradie.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hipages.Application.Tradie.Common.Interfaces;
using Hipages.Application.Tradie.NewJobs.Discount;

namespace Hipages.Application.Tradie.NewJobs.Events
{
    public class JobStatusUpdatedEventHandler : INotificationHandler<DomainEventNotification<JobStatusUpdatedEvent>>
    {
        private readonly ILogger<JobStatusUpdatedEventHandler> _log;
        private readonly IEmailService _emailService;
        private readonly IDiscountStrategy _discountStrategy;

        public JobStatusUpdatedEventHandler(ILogger<JobStatusUpdatedEventHandler> log, IEmailService emailService, IDiscountStrategy discountStrategy)
        {
            _log = log;
            _emailService = emailService;
            _discountStrategy = discountStrategy;
        }

        public Task Handle(DomainEventNotification<JobStatusUpdatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;
            try
            {
                _log.LogDebug("Handling Domain Event. Id: {jobId}  JobStatus: {jobStatus}", domainEvent.Job.Id, domainEvent.Job.JobStatus);
                if (domainEvent.Job.JobStatus == Domain.Tradie.Enums.JobStatusEnum.Accepted)
                {
                    var discount = _discountStrategy.CalculateDiscount(domainEvent.Job);
                    domainEvent.Job.DiscountAmount = discount;
                    _emailService.Send("sales@techtest.com)", String.Format($"Id: {domainEvent.Job.Id}  JobStatus: {domainEvent.Job.JobStatus}"));
                }

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Error handling domain event {domainEvent}", domainEvent.GetType());
                throw;
            }
        }
    }
}
