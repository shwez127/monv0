using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskData.Repository
{
    public interface IReservedSeatRepository
    {
        void AddReservedSeat(ReservedSeat reservedseat);
        void DeleteReservedSeat(int reservedseatId);
        void UpdateReservedSeat(ReservedSeat reservedseat);
        ReservedSeat GetReservedSeatsById(int reservedseatId);
        IEnumerable<ReservedSeat> GetAllReservedSeats();
    }
}
