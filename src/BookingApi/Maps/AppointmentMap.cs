
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApi.Maps
{
    public class AppointmentMap
    {
        public AppointmentMap(EntityTypeBuilder<Appointment> entityBuilder)
        {
            entityBuilder.HasKey(x => x.BookingNumber);
            entityBuilder.ToTable("appointment");

            entityBuilder.Property(x => x.BookingNumber).HasColumnName("booking_number");
            entityBuilder.Property(x => x.PatientId).HasColumnName("patient_id");
            entityBuilder.Property(x => x.RoomId).HasColumnName("room_id");

            entityBuilder.Property(x => x.BookingStartDate).HasColumnName("booking_start_date");
            entityBuilder.Property(x => x.BookingEndDate).HasColumnName("booking_end_date");
            entityBuilder.Property(x => x.RequestedFixedDuration).HasColumnName("requested_fixed_duration");
            entityBuilder.Property(x => x.RequestedExtraDuration).HasColumnName("requested_extra_duration");

        }
    }
}