using DeskEntity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeskUI.Controllers
{
    public class ReservedRoomController : Controller
    {
        private IConfiguration _configuration;

        public ReservedRoomController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ReservedRoom> reservedRoomresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ReservedRoom/GetAllReservedRooms";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        reservedRoomresult = JsonConvert.DeserializeObject<IEnumerable<ReservedRoom>>(result);
                    }
                }
            }
            return View(reservedRoomresult);
        }



        public IActionResult AddReservedRooms()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddReservedRooms(ReservedRoom reservedRoom)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservedRoom), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ReservedRoom/AddReservedRoom";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ReservedRoom details saved sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> EditReservedRoom(int reservedRoomId)
        {
            ReservedRoom reservedRoom = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ReservedRoom/GetReservedRoomById?Id=" + reservedRoomId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        reservedRoom = JsonConvert.DeserializeObject<ReservedRoom>(result);
                    }
                }
            }
            return View(reservedRoom);
        }

        [HttpPost]
        public async Task<IActionResult> EditReservedRoom(ReservedRoom reservedRoom)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservedRoom), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "ReservedRoom/UpdateReservedRoom";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ReservedRoom details updated sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
        public IActionResult DeleteReservedRooms()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservedRooms(int reservedRoomId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "ReservedRoom/DeleteReservedRoom?Id=" + reservedRoomId;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "ReservedRoom details deleted sucessfully!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}
