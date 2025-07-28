using DoctorAvailability.Application.Interfaces;
using DoctorAvailability.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotsController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpPost]
        public IActionResult AddSlot([FromBody] Slot slot)
        {
            _slotService.AddSlot(slot);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAvailableSlots()
        {
            var slots = _slotService.GetAvailableSlots();
            return Ok(slots);
        }
    }
}
