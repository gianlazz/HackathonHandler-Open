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

        public void Index(SmsRequest request)
        {
            var smsDto = new SmsDto();
            smsDto.DateCreated = DateTime.Now;
            smsDto.MessageBody = request.Body;
            smsDto.Sid = request.SmsSid;
        }
    }
}