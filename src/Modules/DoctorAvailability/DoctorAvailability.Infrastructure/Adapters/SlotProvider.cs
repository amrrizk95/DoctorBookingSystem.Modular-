using DoctorAvailability.Application.Interfaces;
using DoctorBookingSystem.Shared.DTOs;
using DoctorBookingSystem.Shared.Interfaces.DoctorAvailability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.Infrastructure.Adapters
{
    public class SlotProvider : ISlotProvider
    {
        private readonly ISlotService _slotService;

        public SlotProvider(ISlotService slotService)
        {
            _slotService = slotService;
        }

        public List<SlotDto> GetAvailableSlots(Guid doctorId)
        {
            var slots = _slotService.GetAvailableSlots(); // Your real service call
            return slots
                .Where(s => s.DoctorId == doctorId)
                .Select(s => new SlotDto
                {
                    Id = s.Id,
                    DoctorId = s.DoctorId,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime
                })
                .ToList();
        }
        public bool IsSlotAvailable(Guid doctorId, DateTime time)
        {
            var slots = GetAvailableSlots(doctorId);
            return slots.Any(s => s.StartTime == time);
        }
    }
}
