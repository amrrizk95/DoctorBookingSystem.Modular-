using AppointmentBooking.Application.Interfaces;
using AppointmentBooking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public IActionResult Book(Appointment appointment)
        {

            _appointmentService.Book(appointment);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _appointmentService.GetAll();
            return Ok(result);
        }

        [HttpPost("cancel/{id}")]
        public IActionResult Cancel(Guid id)
        {
            _appointmentService.Cancel(id);
            return Ok();
        }
    }
}
