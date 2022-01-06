using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace AzureFunctionsWithTwilioBindings
{
    public class SendSmsTimerOut
    {
        [FunctionName("SendSmsTimerOut")]
        public void Run(
            [TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, 
            ILogger log, 
            [TwilioSms(AccountSidSetting = "TwilioAccountSid",AuthTokenSetting = "TwilioAuthToken")]
            out CreateMessageOptions message
        )
        {
            log.LogInformation($"SendSmsTimerOut executed at: {DateTime.Now}");

            string toPhoneNumber = Environment.GetEnvironmentVariable("ToPhoneNumber", EnvironmentVariableTarget.Process);
            string fromPhoneNumber = Environment.GetEnvironmentVariable("FromPhoneNumber", EnvironmentVariableTarget.Process);
            message = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            {
                From = new PhoneNumber(fromPhoneNumber),
                Body = "Hello from SendSmsTimerOut!"
            };
        }
    }
}