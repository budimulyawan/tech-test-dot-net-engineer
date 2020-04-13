using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hipages.Domain.Tradie.Events
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
    }
}
