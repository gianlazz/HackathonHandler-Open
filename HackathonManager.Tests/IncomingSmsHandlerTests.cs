using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackathonManager.RepositoryPattern;
using HackathonManager.Interfaces;
using HackathonManager;

namespace HackathonManager.Tests
{
    [TestFixture]
    public class IncomingSmsHandlerTests
    {
        [Test]
        public void test()
        {
            //Arrange


            //Act

            //Assert
        }

        #region Helper Methods
        private IRepository GetMockRepository()
        {
            return null;
        }

        private ISmsService GetMockSmsService()
        {
            return null;
        }

        private ILogger GetMockLogger()
        {
            return null;
        }
        #endregion
    }
}
