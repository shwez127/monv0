using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskData.Repository
{
    public interface ISeatRepository
    {
        void AddSeat(Seat seat);
        void DeleteSeat(int seatId);
        void UpdateSeat(Seat seat);
        Seat GetSeatsById(int seatId);
        IEnumerable<Seat> GetAllSeats();

        IEnumerable<Seat> GetSeatsByFloorId(int floorId);
    }
}
