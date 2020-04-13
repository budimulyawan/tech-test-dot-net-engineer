using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hipages.Application.Tradie.Common.Interfaces
{
    public interface IEmailService
    {
        void Send(string destination, string message);
    }
}
