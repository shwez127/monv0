using DeskEntity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using DeskData.Data;
using System.Linq;

namespace DeskUI.Controllers
{
    public class AdminController : Controller
    {
        #region AddSeat
        private IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AllSeats()
        {
            IEnumerable<Seat> seatresult = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Seat/GetAllSeats";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        seatresult = JsonConvert.DeserializeObject<IEnumerable<Seat>>(result);
                    }
                }
            }
            return View(seatresult);
        }

        public IActionResult AddSeats()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeats(Seat seat)

        {

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(seat), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Seat/AddSeat";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Seat Booked!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteSeats(int SeatId)
        {
            Seat seat = new Seat();
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Seat/GetSeatsById?seatId=" + SeatId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        seat = JsonConvert.DeserializeObject<Seat>(result);
                    }

                }
            }
            return View(seat);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSeats(Seat seat)

        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Seat/DeleteSeat?seatId=" + seat.SeatId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Seat details deleted successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }



        public async Task<IActionResult> EditSeats(int SeatId)
        {
            Seat seat = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Seat/GetSeatsById?seatId=" + SeatId;

                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        seat = JsonConvert.DeserializeObject<Seat>(result);
                    }

                }
            }
            return View(seat);
        }


        [HttpPost]
        public async Task<IActionResult> EditSeats(Seat seat)

        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(seat), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Seat/UpdateSeat";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Seat Updated!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries";
                    }
                }
            }
            return View();
        }

        #endregion AddSeat

        #region AddFloor

        [HttpGet]
        public async Task<IActionResult> AllFloors()
        {
            IEnumerable<Floor> floorresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Floor/GetFloor";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        floorresult = JsonConvert.DeserializeObject<IEnumerable<Floor>>(result);
                    }
                }
            }
            return View(floorresult);
        }



        public IActionResult AddFloors()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddFloors(Floor floor)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(floor), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Floor/AddFloor";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Floor details saved sucessfully!!";
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

        public async Task<IActionResult> UpdateFloors(int floorId)
        {
            Floor floor = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Floor/GetFloorById?Id=" + floorId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        floor = JsonConvert.DeserializeObject<Floor>(result);
                    }
                }
            }
            return View(floor);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFloors(Floor floor)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(floor), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Floor/UpdateFloor";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Floor details updated sucessfully!!";
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
        public IActionResult DeleteFloors()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFloors(int floorID)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Floor/DeleteFloor?floorId=" + floorID;

                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Floor details deleted sucessfully!!";
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
        #endregion AddFloor

        #region Room View-Edit-Delete Actions
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            IEnumerable<Room> roomresult = null;
            using (HttpClient client = new HttpClient())
            {
                // LocalHost Adress in endpoint
                string endPoint = _configuration["WebApiBaseUrl"] + "Room/GetAllRooms";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //It will deserilize the object in the form of JSON
                        roomresult = JsonConvert.DeserializeObject<IEnumerable<Room>>(result);
                    }
                }
            }
            return View(roomresult);
        }

        public IActionResult AddRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            ViewBag.status = "";
            //it will update the room details after Admin Changes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Room/AddRoom";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Room Details Added Successfully!";
                        //return RedirectToAction("Index", "Room");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> UpdateRoom(int roomId)
        {
            if (roomId != 0)
            {
                //We are Storing Doctor Id  temporary to avoid the error. Now it will show the room details after the update also
                TempData["UpdateroomId"] = roomId;
                TempData.Keep();
            }
            Room room = null;
            //it will fetch the room Details by using DoctorID
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Room/GetRoomsById?roomId=" + Convert.ToInt32(TempData["EditroomId"]);
                TempData.Keep();
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        //It will deserilize the object in the form of JSON
                        room = JsonConvert.DeserializeObject<Room>(result);
                    }
                }
            }
            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(Room room)
        {
            ViewBag.status = "";
            //it will update the room details after Admin Changes
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Room/UpdateRoom";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Room Details Updated Successfully!";
                        //return RedirectToAction("GetAllRooms", "Room");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            ViewBag.status = "";
            //it will Delete the doctor Details by using doctor Id
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Room/DeleteRoom?roomId=" + roomId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Room Details Deleted Successfully!";
                        return RedirectToAction("Index", "Room");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entries!";
                    }
                }
            }
            return View();

        }

        #endregion

        public IActionResult AddEmployee()
        {
            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            #region Adding employee Post Method
            try
            {
                ViewBag.status = "";

                //using grabage collection only for inbuilt classes
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/AddEmployee";//api controller name and its function

                    using (var response = await client.PostAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {   //dynamic viewbag we can create any variable name in run time
                            ViewBag.status = "Ok";
                            ViewBag.message = "Employee Added Successfull!!";
                        }

                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Entries";
                        }

                    }


                }
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.ToString());

            }


            return View();
            #endregion
        }
        public async Task<IActionResult> EditEmployee(int employeeId)
        {
            #region Editing/Updating Employee Get Mthod to View

            Employee employee = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetEmployeeById?employeeId=" + employeeId;
                    //EmployeeId is apicontroleer passing argument name//api controller name and httppost name given inside httppost in Employeecontroller of api
                    using (var response = await client.GetAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {   //dynamic viewbag we can create any variable name in run time
                            var result = await response.Content.ReadAsStringAsync();
                            employee = JsonConvert.DeserializeObject<Employee>(result);
                        }
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.ToString());

            }
            return View(employee);
            #endregion
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {
            #region Editing Employee Post method
            ViewBag.status = "";
            try
            {
                //using grabage collection only for inbuilt classes
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/UpdateEmployee";
                    //api controller name and its function
                    using (var response = await client.PutAsync(endPoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {   //dynamic viewbag we can create any variable name in run time
                            ViewBag.status = "Ok";
                            ViewBag.message = "Employees Details Updated Successfully!!";
                        }

                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Entries";
                        }

                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.ToString());

            }
            return View();
            #endregion
        }
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            #region Deleting Employee with id from database

            ViewBag.status = "";
            //using grabage collection only for inbuilt classes
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/DeleteEmployee?employeeId=" + employeeId;  //api controller name and its function

                    using (var response = await client.DeleteAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {   //dynamic viewbag we can create any variable name in run time
                            ViewBag.status = "Ok";
                            ViewBag.message = "Employees Details Deleted Successfull!!";

                        }

                        else
                        {
                            ViewBag.status = "Error";
                            ViewBag.message = "Wrong Entries";
                        }

                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.ToString());

            }
            return View();
            #endregion
        }
        public IActionResult GetAllEmployees()
        {
            #region  Index of all  the employee present
            return View();
            #endregion
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(Employee employee)
        {
            #region Getting all Employees List from database

            IEnumerable<Employee> employeeresult = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string endPoint = _configuration["WebApiBaseUrl"] + "Employee/GetAllEmployees";//api controller name and httppost name given inside httppost in moviecontroller of api

                    using (var response = await client.GetAsync(endPoint))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {   //dynamic viewbag we can create any variable name in run time
                            var result = await response.Content.ReadAsStringAsync();
                            employeeresult = JsonConvert.DeserializeObject<IEnumerable<Employee>>(result);
                        }
                    }
                }
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.ToString());

            }
            return View(employeeresult);
            #endregion
        }
     


    }
}


        

    




        





