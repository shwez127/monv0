using DeskBusiness.Services;
using DeskEntity.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DeskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRScannerController : ControllerBase
    {
        //Private member
        QRScannerService _qScannerService;

        //Constructor
        public QRScannerController(QRScannerService qScannerService)
        {
            _qScannerService = qScannerService;
        }

        #region QScanner adding action
        [HttpPost("AddQScanner")]
        public IActionResult AddQScanner(QRScanner qScanner)
        {
            try
            {
                _qScannerService.AddQScanner(qScanner);
                return Ok("QScanner Added Successfully");
            }
            catch
            {
                return BadRequest(400);
            }
        }
        #endregion

        #region QScanner updation action
        [HttpPut("UpdateQScanner")]
        public IActionResult UpdateQScanner([FromBody] QRScanner qScanner)
        {
            try
            {
                _qScannerService.UpdateQScanner(qScanner);
                return Ok("QScanner updated successfully");
            }
            catch
            {
                return BadRequest(400);
            }
            
        }
        #endregion

        #region QScanner deletion action
        [HttpDelete("DeleteQScanner")]
        public IActionResult DeleteQScanner(int qScannerId)
        {
            try
            {
                _qScannerService.DeleteQScanner(qScannerId);
                return Ok("Department deleted successfully");
            }
            catch
            {
                return BadRequest(400);
            }
            
        }
        #endregion

        #region Getting all qScanners
        [HttpGet("GetQScanner")]
        public IEnumerable<QRScanner> GetQScanner()
        {
            return _qScannerService.GetQScanner();

        }
        #endregion

        #region Search QScannerById
        [HttpGet("GetQScannerById")]
        public QRScanner GetQScannerById(int qScannerId)
        {
            return _qScannerService.GetQScannerById(qScannerId);
        }
        #endregion
    }
}
