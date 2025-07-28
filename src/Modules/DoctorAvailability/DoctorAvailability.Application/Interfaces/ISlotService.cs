using DoctorAvailability.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.Application.Interfaces
{
    public interface ISlotService
    {
        void AddSlot(Slot slot);
        IEnumerable<Slot> GetAvailableSlots();
    }
}
