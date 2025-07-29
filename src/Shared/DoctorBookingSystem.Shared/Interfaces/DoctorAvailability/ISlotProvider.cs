using DoctorBookingSystem.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBookingSystem.Shared.Interfaces.DoctorAvailability
{
    public interface ISlotProvider
    {
        List<SlotDto> GetAvailableSlots(Guid doctorId);
        bool IsSlotAvailable(Guid doctorId, DateTime time);
    }
}
