using DeskData.Data;
using DeskEntity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskData.Repository
{
    public class ReservedSeatRepository:IReservedSeatRepository
    {

        DeskDbContext _db;
        public ReservedSeatRepository(DeskDbContext db)
        {
            _db = db;
        }

        #region AddReservedSeat
        public void AddReservedSeat(ReservedSeat reservedseats)
        {
            _db.reservedSeats.Add(reservedseats);
            _db.SaveChanges();
        }
        #endregion AddReservedSeat

        #region DeleteReservedSeat
        public void DeleteReservedSeat(int reservedseatId)
        {
            var reservedseats = _db.reservedSeats.Find(reservedseatId);
            _db.reservedSeats.Remove(reservedseats);
            _db.SaveChanges();

        }
        #endregion DeleteReservedSeat

        #region  UpdateReservedSeat
        public void UpdateReservedSeat(ReservedSeat reservedseats)
        {
            _db.Entry(reservedseats).State = EntityState.Modified;
            _db.SaveChanges();

        }
        #endregion UpdateReservedSeat

        #region GetReservedSeatsById 
        public ReservedSeat GetReservedSeatsById(int reservedseatId)
        {
            return _db.reservedSeats.Find(reservedseatId);
        }
        #endregion GetReservedSeatsById

        #region GetAllReservedSeats
        public IEnumerable<ReservedSeat> GetAllReservedSeats()
        {
            return _db.reservedSeats.ToList();
        }
        #endregion GetAllReservedSeats
    }
}