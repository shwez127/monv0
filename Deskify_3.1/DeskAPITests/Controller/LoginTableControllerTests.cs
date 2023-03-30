using AutoFixture;
using DeskAPI.Controllers;
using DeskBusiness.Services;
using DeskData.Repository;
using DeskEntity.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskAPITests.Controller.Tests
{
    [TestClass()]
    public class LoginTableControllerTests
    {
        LoginTableController loginTableController;
        Fixture _fixture;
        Mock<ILoginTableRepository> moq;
        public LoginTableControllerTests()
        {
            _fixture = new Fixture();
            moq = new Mock<ILoginTableRepository>();
        }

        [TestMethod()]
        public void LoginTest()
        {
            var loginTable = _fixture.Create<LoginTable>();
            moq.Setup(x => x.Login(loginTable)).Returns( new int[10] );
            loginTableController = new LoginTableController(new LoginTableService(moq.Object));
            var result = loginTableController.Login(loginTable);
            Assert.IsTrue(result.Length>0); 
        }

    }
}
