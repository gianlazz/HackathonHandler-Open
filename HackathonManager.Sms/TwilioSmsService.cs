using HackathonManager.DTO;
using HackathonManager.Interfaces;
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
    public class TwilioSmsService : ISmsService
    {
        // Find your Account Sid and Auth Token at twilio.com/console
        const string accountSid = TwilioCredentials.accountSid;
        const string authToken = TwilioCredentials.authToken;
        const string fromNumber = TwilioCredentials.fromTwilioNumber;


        public SmsDto SendSms(uint toPhoneNumber, string messageBody)
        {
            string preparedNumber;
            TwilioClient.Init(accountSid, authToken);
            if (toPhoneNumber.ToString().StartsWith("+1"))
                preparedNumber = toPhoneNumber.ToString();
            else
            {
                preparedNumber = "+1" + toPhoneNumber.ToString();
            }

            var to = new PhoneNumber(preparedNumber);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber($"+1{fromNumber}"),
                body: messageBody);

            SmsDto smsDto = new SmsDto();
            smsDto.DateCreated = DateTime.Now;
            smsDto.ToPhoneNumber = $"+1{toPhoneNumber}";
            smsDto.FromPhoneNumber = $"+1{fromNumber}";
            smsDto.MessageBody = messageBody;
            smsDto.Sid = message.Sid;

            return smsDto;
        }

    }
}
