using DeskEntity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeskData.Data
{
    public class DeskDbContext:DbContext
    {
        public DeskDbContext()
        {

        }
        public DeskDbContext(DbContextOptions<DeskDbContext> options) : base(options)
        {

        }
     
        public DbSet<BookingSeat> bookingSeats { get; set; }
        public DbSet<ReservedSeat> reservedseats { get; set; }
       
        public DbSet<Seat> seats { get; set; }
       
        public DbSet<Floor> floors { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {

           dbContextOptionsBuilder.UseSqlServer("Data Source=DESKTOP-SCHFIU6\\SQLEXPRESS;Initial Catalog=deskayushi54; Integrated Security=true; ");

        }
    }
}
