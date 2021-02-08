namespace BookingApi.Controllers
{
    public class AppointmentRequest
    {
        public string PatientCode { get; set; }
        
        public string RoomCode { get; set; }

        public string BookingStartDate { get; set; }

        public string BookingEndDate { get; set; }

        public int RequestedFixedDuration { get; set; }
        public int RequestedExtraDuration { get; set; }

    }
}