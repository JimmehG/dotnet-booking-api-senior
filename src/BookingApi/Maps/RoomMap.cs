
using BookingApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApi.Maps{
       public class RoomMap
    {
        public RoomMap(EntityTypeBuilder<Room> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("room");

            entityBuilder.Property(x => x.Id).HasColumnName("id");
            entityBuilder.Property(x => x.Code).HasColumnName("code");
            entityBuilder.Property(x => x.Description).HasColumnName("description");
        }
    }
}