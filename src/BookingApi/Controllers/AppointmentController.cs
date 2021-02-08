using BookingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly BookingDbContext _context;

        public AppointmentController(BookingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        [HttpGet("{bookingNumber}")]
        public async Task<ActionResult<Appointment>> GetByBookingNumber(int bookingNumber)
        {
            return await _context.Appointments.FindAsync(bookingNumber);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> MakeAppointment(AppointmentRequest appointmentRequest)
        {
            var patient = await _context.Patients.Where(p => p.Code == appointmentRequest.PatientCode).FirstAsync();
            var preferredRoom = await _context.Rooms.Where(r => r.Code == appointmentRequest.RoomCode).FirstAsync();
            var startDate = DateTime.ParseExact(appointmentRequest.BookingStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var appointment = new Appointment
            {
                PatientId = patient.Id,
                BookingStartDate = startDate
            };
            if (!String.IsNullOrEmpty(appointmentRequest.BookingEndDate))
            {
                appointment.RoomId = preferredRoom.Id;
                appointment.BookingEndDate = DateTime.ParseExact(appointmentRequest.BookingEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                //auto booking
                //find rooms with the max days available
                //if preferred room available make appointment for that room otherwise choose the first one from the rest
                //repeat this but for a day less until the days remaining are less than the RequestedFixedDuration
                var maxDuration = appointmentRequest.RequestedFixedDuration + appointmentRequest.RequestedExtraDuration;
                appointment.RequestedFixedDuration = appointmentRequest.RequestedFixedDuration;
                appointment.RequestedExtraDuration = appointmentRequest.RequestedExtraDuration;
                for (int stayDays = maxDuration; stayDays >= appointmentRequest.RequestedFixedDuration; stayDays--)
                {
                    var endDate = startDate.AddDays(stayDays);
                    appointment.BookingEndDate = endDate;

                    //build list of rooms with no appointments overlapping desired time

                    var rooms = await _context.Rooms.ToListAsync();

                    //remove those with overlapping appointments

                    for (int i = rooms.Count - 1; i >= 0; i--)
                    {
                        var appts = await _context.Appointments.Where(a => a.RoomId == rooms[i].Id).ToListAsync();
                        foreach (var appt in appts)
                        {
                            if (InvalidCheck(appt.BookingStartDate, appt.BookingEndDate, startDate, endDate))
                            {
                                rooms.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    if (rooms.Contains(preferredRoom))
                    {
                        appointment.RoomId = preferredRoom.Id;
                        goto AddAppointment;
                    }
                    else if (rooms.Any())
                    {
                        appointment.RoomId = rooms.First().Id;
                        goto AddAppointment;
                    }
                }
                return BadRequest("No rooms available for these conditions. Booking Rejected.");
            }
        AddAppointment:
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByBookingNumber), new { appointment.BookingNumber }, appointment);
        }

        private bool InvalidCheck(DateTime apptStart, DateTime apptEnd, DateTime start, DateTime end)
        {
            return !((apptStart > start && apptStart >= end) || (apptEnd <= start && apptEnd < end));
        }

    }
}