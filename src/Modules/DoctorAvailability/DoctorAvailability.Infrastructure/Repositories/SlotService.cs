using DoctorAvailability.Application.Interfaces;
using DoctorAvailability.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAvailability.Infrastructure.Repositories
{
    public class SlotService : ISlotService
    {
        private static readonly List<Slot> _slots = new();

        public void AddSlot(Slot slot)
        {
            _slots.Add(slot);
        }

        public IEnumerable<Slot> GetAvailableSlots()
        {
            return _slots.Where(s => !s.IsReserved).OrderBy(s => s.StartTime);
        }
    }
}
