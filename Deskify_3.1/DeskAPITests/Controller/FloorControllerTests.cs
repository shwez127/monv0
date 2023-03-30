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
    public class FloorControllerTests
    {
        FloorController floorController;
        Fixture _fixture;
        Mock<IFloorRepository> moq;

        public FloorControllerTests()
        {
            _fixture = new Fixture();
            moq = new Mock<IFloorRepository>();
        }

        [TestMethod()]
        public async Task GetFloorTest()
        {
            var floorlist = _fixture.CreateMany<Floor>(3).ToList();
            moq.Setup(x => x.GetFloor()).Returns(floorlist);
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.GetFloor();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public async Task GetFloorNegativeTest()
        {
            List<Floor> floorlist = null;
            moq.Setup(x => x.GetFloor()).Returns(floorlist);
            floorController = new FloorController(new FloorService(moq.Object));
            Assert.IsNull(floorController.GetFloor());
        }
        [TestMethod()]
        public void DeleteFloorTest()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.DeleteFloor(1));
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.DeleteFloor(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 200);
        }

        [TestMethod()]
        public void DeleteFloor_ThrowsException_IfIdNotFound()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.DeleteFloor(It.IsAny<int>())).
                 Throws(new Exception());
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.DeleteFloor(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }
        [TestMethod()]
        public void UpdateFloorTest()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.UpdateFloor(floor));
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.UpdateFloor(floor);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }
        [TestMethod()]
        public void UpdateFloor_ThrowsException_IfIdNotFound()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.UpdateFloor(It.IsAny<Floor>())).
                 Throws(new Exception());
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.UpdateFloor(floor);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }
        [TestMethod()]
        public void GetFloorByIdTest()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.GetFloorById(1)).Returns(floor);
            floorController = new FloorController(new FloorService(moq.Object));
            Assert.AreEqual(floorController.GetFloorById(1), floor);
        }
        [TestMethod()]
        public void GetFloorById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.GetFloorById(10)).Returns(floor);
            floorController = new FloorController(new FloorService(moq.Object));
            // Act
            var okResult = floorController.GetFloorById(1);
            // Assert
            Assert.AreEqual(okResult, null);
        }
        [TestMethod()]
        public async Task AddFloorTest()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.AddFloor(floor));
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.AddFloor(floor);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }
        [TestMethod()]
        public async Task AddFloorNegativeTest()
        {
            var floor = _fixture.Create<Floor>();
            moq.Setup(x => x.AddFloor(It.IsAny<Floor>())).
                 Throws(new Exception());
            floorController = new FloorController(new FloorService(moq.Object));
            var result = floorController.AddFloor(floor);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }
    }
}
