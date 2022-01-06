using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AzureFunctionsWithTwilioBindings
{
    public class SendMultilpeAsyncSmsTimer
    {
        [FunctionName("SendMultilpeAsyncSmsTimer")]
        public void Run(
            [TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, 
            ILogger log, 
            [TwilioSms(AccountSidSetting = "TwilioAccountSid",AuthTokenSetting = "TwilioAuthToken")]
            IAsyncCollector<CreateMessageOptions> messageCollector
        )
        {
            log.LogInformation($"SendMultilpeAsyncSmsTimer executed at: {DateTime.Now}");
            
            string toPhoneNumber = Environment.GetEnvironmentVariable("ToPhoneNumber", EnvironmentVariableTarget.Process);
            string fromPhoneNumber = Environment.GetEnvironmentVariable("FromPhoneNumber", EnvironmentVariableTarget.Process);
            for (int i = 1; i <= 2; i++)
            {
                var message = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
                {
                    From = new PhoneNumber(fromPhoneNumber),
                    Body = $"Hello from SendMultilpeAsyncSmsTimer #{i}!"
                };
                messageCollector.AddAsync(message);
            }
        }
    }
}