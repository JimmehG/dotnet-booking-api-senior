using BookingApi.Maps;
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApi
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
       : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new RoomMap(modelBuilder.Entity<Room>());

            new PatientMap(modelBuilder.Entity<Patient>());

            new AppointmentMap(modelBuilder.Entity<Appointment>());

            modelBuilder.Entity<Appointment>().HasOne(a => a.Room).WithMany().HasForeignKey(a => a.RoomId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany().HasForeignKey(a => a.PatientId);
        }
    }
}