using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorBookingSystem.Shared.Events
{
    public class AppointmentBookedEvent : INotification
    {
        public Guid AppointmentId { get; }
        public Guid DoctorId { get; }
        public DateTime SlotTime { get; }

        public AppointmentBookedEvent(Guid appointmentId, Guid doctorId, DateTime slotTime)
        {
            AppointmentId = appointmentId;
            DoctorId = doctorId;
            SlotTime = slotTime;
        }
    }
}
