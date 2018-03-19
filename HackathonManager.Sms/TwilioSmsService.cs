using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;


namespace HackathonManager.Sms
{
    public class TwilioSmsService
    {
        // Find your Account Sid and Auth Token at twilio.com/console
        const string accountSid = TwilioCredentials.accountSid;
        const string authToken = TwilioCredentials.authToken;

        public static string SendSms(int fromPhoneNumber, int toPhoneNumber)
        {
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+1" + fromPhoneNumber);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+1" + toPhoneNumber),
                body: "This is the ship that made the Kessel Run in fourteen parsecs?");

            return message.Sid;
        }
    }
}
