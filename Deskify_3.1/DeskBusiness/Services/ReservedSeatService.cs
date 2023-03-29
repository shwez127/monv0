using DeskData.Repository;
using DeskEntity.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskBusiness.Services
{
    public class ReservedSeatService
    {
       
        IReservedSeatRepository _reservedseatRepository;

        public ReservedSeatService(IReservedSeatRepository reservedseatRepository)
        {
            _reservedseatRepository = reservedseatRepository;
        }

        public void AddReservedSeat(ReservedSeat reservedseat)
        {
            _reservedseatRepository.AddReservedSeat(reservedseat);
        }

        public void DeleteReservedSeat(int reservedseatId)
        {
            _reservedseatRepository.DeleteReservedSeat(reservedseatId);
        }

        public void UpdateReservedSeat(ReservedSeat reservedseat)
        {
            _reservedseatRepository.UpdateReservedSeat(reservedseat);
        }

        public ReservedSeat GetReservedSeatsById(int reservedseatId)
        {
            return _reservedseatRepository.GetReservedSeatsById(reservedseatId);
        }

        public IEnumerable<ReservedSeat> GetAllReservedSeats()
        {
            return _reservedseatRepository.GetAllReservedSeats();
        }
    }
}
