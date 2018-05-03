using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using HackathonManager.DTO;
using HackathonManager.RepositoryPattern;

namespace HackathonManager.TwilioBotWebMvc.Controllers
{
    public class HelloWorldController : TwilioController
    {
        // GET: HelloWorld
        //[HttpPost]
        //public TwiMLResult Index(SmsRequest request)
        //{
        //    var response = new MessagingResponse();
        //    response.Message("Hello World");
        //    return TwiML(response);
        //}

        //public void Index(SmsRequest request)
        //{
        //    var smsDto = new SmsDto();
        //    smsDto.DateCreated = DateTime.Now;
        //    smsDto.MessageBody = request.Body;
        //    smsDto.Sid = request.SmsSid;
        //    smsDto.ToPhoneNumber = "+12065086735";
        //    smsDto.FromPhoneNumber = String.Empty;

        //    var Db = MvcApplication.DbRepo;

        //    Db.Add<SmsDto>(smsDto);
        //}

        /* 
            <TwilioResponse>
                <SMSMessage>
                    <Sid>SM1f0e8ae6ade43cb3c0ce4525424e404f</Sid>
                    <DateCreated>Fri, 13 Aug 2010 01:16:24 +0000</DateCreated>
                    <DateUpdated>Fri, 13 Aug 2010 01:16:24 +0000</DateUpdated>
                    <DateSent/>
                    <AccountSid>AC228b97a5fe4138be081eaff3c44180f3</AccountSid>
                    <To>+13455431221</To>
                    <From>+15104564545</From>
                    <Body>A Test Message</Body>
                    <Status>queued</Status>
                    <Flags>
                        <Flag>outbound</Flag>
                    </Flags>
                    <ApiVersion>2010-04-01</ApiVersion>
                    <Price/>
                    <Uri>
                        /2010-04-01/Accounts/AC228b97a5fe4138be081eaff3c44180f3/SMS/Messages/SM1f0e8ae6ade43cb3c0ce4525424e404f
                    </Uri>
                </SMSMessage>
            </TwilioResponse>
         */

        [HttpPost]
        public void Index(SmsRequest request, string To, string From, string Body)
        {
            var smsDto = new SmsDto();
            smsDto.Sid = request.SmsSid;
            smsDto.DateCreated = DateTime.Now;
            smsDto.ToPhoneNumber = To;
            smsDto.FromPhoneNumber = From;
            smsDto.MessageBody = Body;

            //smsDto.DateCreated = DateTime.Now;
            //smsDto.MessageBody = Body;
            ////smsDto.Sid = request.SmsSid;
            //smsDto.ToPhoneNumber = "+12065086735";
            //smsDto.FromPhoneNumber = From;

            var Db = MvcApplication.DbRepo;

            Db.Add<SmsDto>(smsDto);
        }
    }
}