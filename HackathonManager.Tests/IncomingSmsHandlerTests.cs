using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.RepositoryPattern;
using HackathonManager.Interfaces;
using HackathonManager;
using HackathonManager.DTO;
using Moq;

namespace HackathonManager.Tests
{
    [TestFixture]
    public class IncomingSmsHandlerTests
    {
        [Test]
        public void test()
        {
            //Arrange
            var smsMock = MockSmsService();
            var repositoryMock = MockRepository();
            var loggerMock = MockLogger();
            var incomingSmsHandler = new IncomingSmsHandler(smsMock.Object, repositoryMock.Object, loggerMock.Object);
            var recievedSms = new SmsDto();
            recievedSms.FromPhoneNumber = "5555555555";
            recievedSms.ToPhoneNumber = "2222222222";

            //Act
            incomingSmsHandler.Process(recievedSms);

            //Assert
            //Assert.That(() smsMock.);
        }

        #region Helper Methods
        private Mock<IRepository> MockRepository()
        {
            Mock<IRepository> mock = new Mock<IRepository>();
            //mock.Setup(x => x.Add(new Object)).
            return mock;
        }

        private Mock<ISmsService> MockSmsService()
        {
            Mock<ISmsService> mock = new Mock<ISmsService>();
            //mock.Setup(x => x.SendSms(null, ""))
            return mock;
        }

        private Mock<ILogger> MockLogger()
        {
            Mock<ILogger> mock = new Mock<ILogger>();
            return mock;
        }
        #endregion
    }
}
