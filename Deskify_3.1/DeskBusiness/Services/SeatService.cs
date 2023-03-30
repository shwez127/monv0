using DeskData.Repository;
using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskBusiness.Services
{
    public class SeatService
    {
        ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public void AddSeat(Seat seat)
        {
            _seatRepository.AddSeat(seat);
        }

        public void DeleteSeat(int seatId)
        {
            _seatRepository.DeleteSeat(seatId);
        }

        public void UpdateSeat(Seat seat)
        {
            _seatRepository.UpdateSeat(seat);
        }

        public Seat GetSeatsById(int seatId)
        {
            return _seatRepository.GetSeatsById(seatId);
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            return _seatRepository.GetAllSeats();
        }

        public IEnumerable<Seat> GetAllSeatsByFloorId(int floorId)
        {
            return _seatRepository.GetSeatsByFloorId(floorId);
        }
    }
}
