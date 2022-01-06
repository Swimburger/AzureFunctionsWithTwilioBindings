using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AzureFunctionsWithTwilioBindings
{
    public class SendSmsTimer
    {
        [FunctionName("SendSmsTimer")]
        [return: TwilioSms(
            AccountSidSetting = "TwilioAccountSid",
            AuthTokenSetting = "TwilioAuthToken"
        )]
        public CreateMessageOptions Run([TimerTrigger("*/15 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"SendSmsTimer executed at: {DateTime.Now}");

            string toPhoneNumber = Environment.GetEnvironmentVariable("ToPhoneNumber", EnvironmentVariableTarget.Process);
            string fromPhoneNumber = Environment.GetEnvironmentVariable("FromPhoneNumber", EnvironmentVariableTarget.Process);
            var message = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(fromPhoneNumber),
                Body = "Hello from SendSmsTimer!"
            };

            return message;
        }
    }
}