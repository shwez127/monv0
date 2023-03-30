using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskData.Repository
{
    public interface IBookingSeatRepository
    {
        int AddSeatBooking(BookingSeat bookseat);
        void DeleteSeatBooking(int bookseatId);
        void UpdateSeatBooking(BookingSeat bookseat);
        BookingSeat GetSeatBookingById(int bookseatId);
        IEnumerable<BookingSeat> GetAllBookingSeats();
    }
}
