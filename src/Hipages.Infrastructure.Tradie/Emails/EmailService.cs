using Hipages.Application.Tradie.Common.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hipages.Infrastructure.Tradie.Emails
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }
        public void Send(string destination, string message)
        {
            // Integration with email service.
            _logger.LogInformation("Send email to {destination} with message {message}", destination, message);
            return;
        }
    }
}
