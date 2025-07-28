using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentConfirmation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentConfirmationController : ControllerBase
    {
        // Simple in-memory store for confirmed appointments
        private static readonly List<ConfirmedAppointment> _confirmedAppointments = new();

        [HttpPost("confirm")]
        public IActionResult Confirm([FromBody] ConfirmedAppointment appointment)
        {
            appointment.ConfirmedAt = DateTime.UtcNow;
            _confirmedAppointments.Add(appointment);
            return Ok(new { Message = "Appointment confirmed." });
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_confirmedAppointments);
        }
    }

    public class ConfirmedAppointment
    {
        public Guid AppointmentId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime ConfirmedAt { get; set; }
    }
}
