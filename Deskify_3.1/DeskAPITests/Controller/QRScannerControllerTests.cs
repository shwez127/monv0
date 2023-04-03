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
    public class QRScannerControllerTests
    {
        QRScannerController qRScannerController;
        Fixture _fixture;
        Mock<IQRScannerRepository> moq;

        public QRScannerControllerTests()
        {
            _fixture = new Fixture();
            moq = new Mock<IQRScannerRepository>();
        }

        [TestMethod()]
        public async Task GetQRScannersTest()
        {
            var qRScannerlist = _fixture.CreateMany<QRScanner>(3).ToList();
            moq.Setup(x => x.GetQScanner()).Returns(qRScannerlist);
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.GetQScanner();
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public async Task GetQRScannersNegativeTest()
        {
            List<QRScanner> qRScannerlist = null;
            moq.Setup(x => x.GetQScanner()).Returns(qRScannerlist);
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            Assert.IsNull(qRScannerController.GetQScanner());
        }
        [TestMethod()]
        public void DeleteQRScannerTest()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.DeleteQScanner(1));
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.DeleteQScanner(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 200);
        }

        [TestMethod()]
        public void DeleteQRScanner_ThrowsException_IfIdNotFound()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.DeleteQScanner(It.IsAny<int>())).
                 Throws(new Exception());
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.DeleteQScanner(1);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void UpdateQRScannerTest()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.UpdateQScanner(qRScanner));
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.UpdateQScanner(qRScanner);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }
        [TestMethod()]
        public void UpdateQRScanner_ThrowsException_IfIdNotFound()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.UpdateQScanner(It.IsAny<QRScanner>())).
                 Throws(new Exception());
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.UpdateQScanner(qRScanner);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

        [TestMethod()]
        public void GetQRScannerByIdTest()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.GetQScannerById(1)).Returns(qRScanner);
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            Assert.AreEqual(qRScannerController.GetQScannerById(1), qRScanner);
        }

        [TestMethod()]
        public void GetQRScannerById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.GetQScannerById(10)).Returns(qRScanner);
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            // Act
            var okResult = qRScannerController.GetQScannerById(1);
            // Assert
            Assert.AreEqual(okResult, null);
        }

        [TestMethod()]
        public async Task AddQRScannerTest()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.AddQScanner(qRScanner));
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.AddQScanner(qRScanner);
            var Obj = result as ObjectResult;
            Assert.AreEqual(200, Obj.StatusCode);
        }

        [TestMethod()]
        public async Task AddQRScannerNegativeTest()
        {
            var qRScanner = _fixture.Create<QRScanner>();
            moq.Setup(x => x.AddQScanner(It.IsAny<QRScanner>())).
                 Throws(new Exception());
            qRScannerController = new QRScannerController(new QRScannerService(moq.Object));
            var result = qRScannerController.AddQScanner(qRScanner);
            var Obj = result as ObjectResult;
            Assert.AreEqual(Obj.StatusCode, 400);
        }

    }
}
