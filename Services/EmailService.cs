using Microsoft.Extensions.Logging;

namespace DutchTreat.Services
{
   

    public class EmailService : IEmailService
    {
        private ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public void SendEmail(string to, string subject, string body)
        {
            _logger.LogInformation($"Email has been send to {to} with subject {subject} and body \n {body}");
        }
    }
}