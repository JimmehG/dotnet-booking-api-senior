namespace BookingApi.Models
{
    public class Appointment
    {
        public int BookingNumber { get; set; }
        
        public int PatientId { get; set; }
        public int RoomId { get; set; }

        public System.DateTime BookingStartDate { get; set; }
        public System.DateTime BookingEndDate { get; set; }

        public int RequestedFixedDuration { get; set; }
        public int RequestedExtraDuration { get; set; }
        public Room Room { get; set; }
        public Patient Patient { get; set; }
    }
}