using AutoFixture;
using DeskAPI.Controllers;
using DeskBusiness.Services;
using DeskData.Repository;
using DeskEntity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskAPITests.Controller.Tests
{
    [TestClass()]
    public class ChoicesControllerTests
    {
        ChoicesController choicesController;
        Fixture _fixture;
        Mock<IChoicesRepository> moq;

        public ChoicesControllerTests()
        {
            _fixture = new Fixture();
            moq = new Mock<IChoicesRepository>();
        }

        [TestMethod()]
        public async Task GetChoicesTest()
        {
            var choicelist = _fixture.CreateMany<Choices>(3).ToList();
            moq.Setup(x => x.GetAllChoices()).Returns(choicelist);
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.GetAllChoices();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public async Task GetChoicesNegativeTest()
        {
            List<Choices> choicelist = null;
            moq.Setup(x => x.GetAllChoices()).Returns(choicelist);
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            Assert.IsNull(choicesController.GetAllChoices());
        }

        [TestMethod()]
        public void DeleteChoiceTest()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.DeleteChoice(1));
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.DeleteChoice(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 200);
        }

        [TestMethod()]
        public void DeleteChoice_ThrowsException_IfIdNotFound()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.DeleteChoice(It.IsAny<int>())).
                 Throws(new Exception());
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.DeleteChoice(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }
        [TestMethod()]
        public void UpdateChoiceTest()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.UpdateChoice(choice));
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.UpdateChoice(choice);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }
        [TestMethod()]
        public void UpdateChoice_ThrowsException_IfIdNotFound()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.UpdateChoice(It.IsAny<Choices>())).
                 Throws(new Exception());
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.UpdateChoice(choice);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void GetChoiceByIdTest()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.GetChoiceById(1)).Returns(choice);
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            Assert.AreEqual(choicesController.GetChoiceById(1), choice);
        }

        [TestMethod()]
        public void GetChoiceById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.GetChoiceById(10)).Returns(choice);
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            // Act
            var okResult = choicesController.GetChoiceById(1);
            // Assert
            Assert.AreEqual(okResult, null);
        }

        [TestMethod()]
        public async Task AddChoiceTest()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.AddChoice(choice));
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.AddChoice(choice);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }

        [TestMethod()]
        public async Task AddChoiceNegativeTest()
        {
            var choice = _fixture.Create<Choices>();
            moq.Setup(x => x.AddChoice(It.IsAny<Choices>())).
                 Throws(new Exception());
            choicesController = new ChoicesController(new ChoicesService(moq.Object));
            var result = choicesController.AddChoice(choice);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

    }
}
