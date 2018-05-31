using HackathonManager.DTO;
using HackathonManager.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace HackathonManager.WebMvc.Controllers
{
    public class InboundSmsController : Controller
    {
        // GET: InboundSms
        public ActionResult Index()
        {
            return View();
        }

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

            var Db = MvcApplication._dbRepo;

            Db.Add<SmsDto>(smsDto);
            SmsRoutingConductor.InboundMessages.Add(smsDto);
        }
    }
}