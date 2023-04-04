using Microsoft.EntityFrameworkCore;
using DeskData.Data;
using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskData.Repository
{
    public class BookingRoomRepository : IBookingRoomRepository
    {
        DeskDbContext _db;
        public BookingRoomRepository(DeskDbContext db)
        {
            _db = db;
        }
        #region ADD BookingRoom
        public int AddBookingRoom(BookingRoom bookingRoom)
        {
            _db.bookingRooms.Add(bookingRoom);
            _db.SaveChanges();
            List<BookingRoom> list = new List<BookingRoom>();
            list = _db.bookingRooms.ToList();
            var booking1 = (from list1 in list
                            select list1).Last();
            return booking1.BookingRoomId;
        }
        #endregion         

        #region GET BookingRoom
        public IEnumerable<BookingRoom> GetBookingRoom()
        {
            return _db.bookingRooms.ToList();
        }
        #endregion  

        #region Get BookingRoomById
        public BookingRoom GetBookingRoomById(int bookingRoomId)
        {
            var result = _db.bookingRooms.Include(obj => obj.Employee).Include(obj => obj.Room).ToList();
            foreach (var bookingRoom in result)
            {
                if (bookingRoomId == bookingRoom.BookingRoomId)
                {
                    return bookingRoom;
                }
            }
            return null;
        }
        #endregion

        #region UPDATE BookingRoom
        public void UpdateBookingRoom(BookingRoom bookingRoom)
        {
            _db.Entry(bookingRoom).State = EntityState.Modified;
            _db.SaveChanges(); ;
        }
        #endregion

        #region DELETE BookingRoom
        public void DeleteBookingRoom(int bookingRoomId)
        {
            var rooms = _db.bookingRooms.Find(bookingRoomId);
            _db.bookingRooms.Remove(rooms);
            _db.SaveChanges();
        }
        #endregion
    }
}
