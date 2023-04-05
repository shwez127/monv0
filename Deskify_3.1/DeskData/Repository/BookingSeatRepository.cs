using DeskData.Data;
using DeskEntity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskData.Repository
{
    public class BookingSeatRepository:IBookingSeatRepository
    {
        DeskDbContext _db;
        public BookingSeatRepository(DeskDbContext db)
        {
            _db = db;
        }
        #region AddBookingSeat
        public int AddSeatBooking(BookingSeat bookseat)
        {
            _db.bookingSeats.Add(bookseat);
            _db.SaveChanges();
            List<BookingSeat> list = new List<BookingSeat>();
            list = _db.bookingSeats.ToList();
            var booking1 = (from list1 in list
                            select list1).Last();
            return booking1.BookingSeatId;
        }
        #endregion AddBookingSeat

        #region DeleteBookingSeat
        public void DeleteSeatBooking(int bookseatId)
        {
            var seat = _db.bookingSeats.Find(bookseatId);
            _db.bookingSeats.Remove(seat);
            _db.SaveChanges();

        }
        #endregion DeleteBookingSeat

        #region  UpdateBookingSeat
        public void UpdateSeatBooking(BookingSeat bookseat)
        {
            _db.Entry(bookseat).State = EntityState.Modified;
            _db.SaveChanges();

        }
        #endregion UpdateBookingSeat


        #region GetSeatBookingById 
        public BookingSeat GetSeatBookingById(int bookseatId)
        {

            /*return _db.bookingSeats.Find(bookseatId);*/
            var result = _db.bookingSeats.Include(obj => obj.Employee).Include(obj => obj.Seat).ToList();
            foreach (var bookingSeat in result)
            {
                if (bookseatId == bookingSeat.BookingSeatId)
                {
                    return bookingSeat;
                }
            }
            return null;


        }
        #endregion GetSeatBookingById


        #region GetAllBookingSeats
        public IEnumerable<BookingSeat> GetAllBookingSeats()
        {
            return _db.bookingSeats;
        }
        #endregion GetAllBookingSeats

       public BookingSeat GetBookingSeatByEmployeeId(int employeeid)
        {
            List<BookingSeat> bookingSeats= new List<BookingSeat>();
            var result = _db.bookingSeats.Include(obj => obj.Employee).Include(obj => obj.Seat).ToList();
            foreach (var bookingSeat in result)
            {
                if (employeeid == bookingSeat.EmployeeID)
                {
                     bookingSeats.Add(bookingSeat);
                }
            }
            return bookingSeats.Last();
            
        }
    }



      
    }


