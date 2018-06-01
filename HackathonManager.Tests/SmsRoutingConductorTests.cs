using HackathonManager.DTO;
using HackathonManager.Models;
using HackathonManager.Sms;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackathonManager.Tests
{
    [TestFixture]
    class SmsRoutingConductorTests
    {
        [Test]
        public void SmsRoutingConductorShouldProcessRequestsNotLeavingAny()
        {
            //Arrange
            var conductor = new SmsRoutingConductor(DIContext.Context.GetLocalMongoDbRepo(),
                DIContext.Context.GetTwilioSmsService());
            var outboundSms = new SmsDto();
            var mentorRequest = new MentorRequest();
            var inboundSms = new SmsDto();

            //Act
            conductor.ProcessMentorRequests();
            //SmsDaemon.Program.Main(new string[] { });
            //Thread.Sleep(1000);

            //Assert
            Assert.That(() => !SmsRoutingConductor.InboundMessages.Where(x => x.DateTimeWhenProcessed == null).Any());
            Assert.That(() => !SmsRoutingConductor.MentorRequests.Where(x => x.DateTimeWhenProcessed == null).Any());

        }
    }
}
