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
    public class SeatControllerTests
    {
        SeatController seatController;
        Fixture _fixture;
        Mock<ISeatRepository> moq;
        public SeatControllerTests()
        {
            _fixture = new Fixture();
            moq = new Mock<ISeatRepository>();
        }

        [TestMethod()]
        public async Task GetSeatsTest()
        {
            var seatlist = _fixture.CreateMany<Seat>(3).ToList();
            moq.Setup(x => x.GetAllSeats()).Returns(seatlist);
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.GetAllSeats();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public async Task GetSeatsNegativeTest()
        {
            List<Seat> seatlist = null;
            moq.Setup(x => x.GetAllSeats()).Returns(seatlist);
            seatController = new SeatController(new SeatService(moq.Object));
            Assert.IsNull(seatController.GetAllSeats());
        }

        [TestMethod()]
        public void DeleteSeatTest()
        {
            var seat = _fixture.Create<Seat>();
            moq.Setup(x => x.DeleteSeat(1));
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.DeleteSeat(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 200);
        }

        [TestMethod()]
        public void DeleteSeat_ThrowsException_IfIdNotFound()
        {
            var seat = _fixture.Create<Seat>();
            moq.Setup(x => x.DeleteSeat(It.IsAny<int>())).
                 Throws(new Exception());
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.DeleteSeat(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void UpdateSeatTest()
        {
            var Seat = _fixture.Create<Seat>();
            moq.Setup(x => x.UpdateSeat(Seat));
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.UpdateSeat(Seat);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }

        [TestMethod()]
        public void UpdateSeat_ThrowsException_IfIdNotFound()
        {
            var seat = _fixture.Create<Seat>();
            moq.Setup(x => x.UpdateSeat(It.IsAny<Seat>())).
                 Throws(new Exception());
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.UpdateSeat(seat);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void GetSeatByIdTest()
        {
            var Seat = _fixture.Create<Seat>();
            moq.Setup(x => x.GetSeatsById(1)).Returns(Seat);
            seatController = new SeatController(new SeatService(moq.Object));
            Assert.AreEqual(seatController.GetSeatById(1), Seat);
        }

        [TestMethod()]
        public void GetSeatById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var seat = _fixture.Create<Seat>();
            moq.Setup(x => x.GetSeatsById(10)).Returns(seat);
            seatController = new SeatController(new SeatService(moq.Object));
            // Act
            var okResult = seatController.GetSeatById(1);
            // Assert
            Assert.AreEqual(okResult, null);
        }

        [TestMethod()]
        public async Task AddSeatTest()
        {
            var seat = _fixture.Create<Seat>();
            moq.Setup(x => x.AddSeat(seat));
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.AddSeat(seat);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }

        [TestMethod()]
        public async Task AddSeatNegativeTest()
        {
            var seat = _fixture.Create<Seat>();
            moq.Setup(x => x.AddSeat(It.IsAny<Seat>())).
                 Throws(new Exception());
            seatController = new SeatController(new SeatService(moq.Object));
            var result = seatController.AddSeat(seat);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

    }
}
