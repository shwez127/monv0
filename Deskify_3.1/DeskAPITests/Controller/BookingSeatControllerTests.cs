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
    public class BookingSeatControllerTests
    {
        BookingSeatController bookingSeatController;
        Fixture _fixture;
        Mock<IBookingSeatRepository> moq;
        public BookingSeatControllerTests()
        {
            _fixture = new Fixture();
            moq = new Mock<IBookingSeatRepository>();
        }

        [TestMethod()]
        public async Task GetBookingSeatsTest()
        {
            var bookingSeatlist = _fixture.CreateMany<BookingSeat>(3).ToList();
            moq.Setup(x => x.GetAllBookingSeats()).Returns(bookingSeatlist);
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            var result = bookingSeatController.GetAllBookingSeats();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public async Task GetBookingSeatsNegativeTest()
        {
            List<BookingSeat> bookingSeatlist = null;
            moq.Setup(x => x.GetAllBookingSeats()).Returns(bookingSeatlist);
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            Assert.IsNull(bookingSeatController.GetAllBookingSeats());
        }

        [TestMethod()]
        public void DeleteBookingSeatTest()
        {
            var bookingSeat = _fixture.Create<BookingSeat>();
            moq.Setup(x => x.DeleteSeatBooking(1));
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            var result = bookingSeatController.DeleteSeatBooking(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 200);
        }

        [TestMethod()]
        public void DeleteBookingSeat_ThrowsException_IfIdNotFound()
        {
            var bookingSeat = _fixture.Create<BookingSeat>();
            moq.Setup(x => x.DeleteSeatBooking(It.IsAny<int>())).
                 Throws(new Exception());
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            var result = bookingSeatController.DeleteSeatBooking(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void UpdateBookingSeatTest()
        {
            var bookingSeat = _fixture.Create<BookingSeat>();
            moq.Setup(x => x.UpdateSeatBooking(bookingSeat));
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            var result = bookingSeatController.UpdateSeatBooking(bookingSeat);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }

        [TestMethod()]
        public void UpdateBookingSeat_ThrowsException_IfIdNotFound()
        {
            var bookingSeat = _fixture.Create<BookingSeat>();
            moq.Setup(x => x.UpdateSeatBooking(It.IsAny<BookingSeat>())).
                 Throws(new Exception());
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            var result = bookingSeatController.UpdateSeatBooking(bookingSeat);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void GetBookingSeatByIdTest()
        {
            var bookingSeat = _fixture.Create<BookingSeat>();
            moq.Setup(x => x.GetSeatBookingById(1)).Returns(bookingSeat);
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            Assert.AreEqual(bookingSeatController.GetSeatBookingById(1), bookingSeat);
        }

        [TestMethod()]
        public void GetBookingSeatById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var bookingSeat = _fixture.Create<BookingSeat>();
            moq.Setup(x => x.GetSeatBookingById(10)).Returns(bookingSeat);
            bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
            // Act
            var okResult = bookingSeatController.GetSeatBookingById(1);
            // Assert
            Assert.AreEqual(okResult, null);
        }

        //[TestMethod()]
        //public async Task AddBookingSeatTest()
        //{
        //    var bookingSeat = _fixture.Create<BookingSeat>();
        //    moq.Setup(x => x.AddSeatBooking(bookingSeat));
        //    bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
        //    var result = bookingSeatController.AddSeatBooking(bookingSeat);
        //    var Obj = result as ObjectResult;
        //    Assert.AreEqual(200, Obj.StatusCode);
        //}

        //[TestMethod()]
        //public async Task AddBookingSeatNegativeTest()
        //{
        //    var bookingSeat = _fixture.Create<BookingSeat>();
        //    moq.Setup(x => x.AddSeatBooking(It.IsAny<BookingSeat>())).
        //         Throws(new Exception());
        //    bookingSeatController = new BookingSeatController(new BookingSeatService(moq.Object));
        //    var result = bookingSeatController.AddSeatBooking(bookingSeat);
        //    var Obj = result as ObjectResult;
        //    Assert.AreEqual(Obj.StatusCode, 400);
        //}
    }
}
