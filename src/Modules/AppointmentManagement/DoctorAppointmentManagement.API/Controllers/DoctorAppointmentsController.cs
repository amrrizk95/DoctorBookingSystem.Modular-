using DoctorAppointmentManagement.Application.Ports;
using DoctorAppointmentManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorAppointmentsController : ControllerBase
    {
        private readonly IAppointmentManagementService _service;

        public DoctorAppointmentsController(IAppointmentManagementService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Add(DoctorAppointment appointment)
        {
            _service.Add(appointment);
            return Ok();
        }

        [HttpGet("{doctorId}")]
        public IActionResult GetByDoctor(Guid doctorId)
        {
            var data = _service.GetByDoctorId(doctorId);
            return Ok(data);
        }

        [HttpPost("status")]
        public IActionResult UpdateStatus(UpdateStatusDto message)
        {
            _service.UpdateStatus(message.Id, message.Status);
            return Ok();
        }
    }
}
