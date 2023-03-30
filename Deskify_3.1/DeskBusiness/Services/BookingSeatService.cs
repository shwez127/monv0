using DeskData.Repository;
using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskBusiness.Services
{
    public class BookingSeatService
    {
        IBookingSeatRepository _bookseatRepository;

        public BookingSeatService(IBookingSeatRepository bookseatRepository)
        {
            _bookseatRepository = bookseatRepository;
        }

        public int AddSeatBooking(BookingSeat bookseat)
        {
            return _bookseatRepository.AddSeatBooking(bookseat);
        }

        public void DeleteSeatBooking(int bookseatId)
        {
            _bookseatRepository.DeleteSeatBooking(bookseatId);
        }

        public void UpdateSeatBooking(BookingSeat bookseat)
        {
            _bookseatRepository.UpdateSeatBooking(bookseat);
        }

        public BookingSeat GetSeatBookingById(int bookseatId)
        {
            return _bookseatRepository.GetSeatBookingById(bookseatId);
        }

        public IEnumerable<BookingSeat> GetAllBookingSeats()
        {
            return _bookseatRepository.GetAllBookingSeats();
        }
    }
}
