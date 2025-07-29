using AppointmentBooking.Application.Interfaces;
using AppointmentBooking.Domain.Entities;
using DoctorBookingSystem.Shared.DTOs;
using DoctorBookingSystem.Shared.Events;
using DoctorBookingSystem.Shared.Interfaces.DoctorAvailability;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMediator _mediator;
        private readonly ISlotProvider _slotProvider;
        public AppointmentService(ISlotProvider slotProvider, IMediator mediator)
        {
            _slotProvider = slotProvider;
            _mediator = mediator;
        }
        private static readonly List<Appointment> _appointments = new();

        public void Book(Appointment appointment)
        {
            var isAvailable = _slotProvider.IsSlotAvailable(appointment.DoctorId, appointment.BookingDate);
            if (!isAvailable)
                return ;
            appointment.Id = Guid.NewGuid();
            appointment.BookingDate = DateTime.UtcNow;
            appointment.Status = AppointmentStatus.Pending;
            _appointments.Add(appointment);

            var @event = new AppointmentBookedEvent(appointment.Id, appointment.DoctorId, appointment.BookingDate);
            _mediator.Publish(@event);
        }

        public IEnumerable<Appointment> GetAll() => _appointments;

        public Appointment? GetById(Guid id) =>
            _appointments.FirstOrDefault(x => x.Id == id);

        public void Cancel(Guid id)
        {
            var appointment = GetById(id);
            if (appointment != null)
            {
                appointment.Status = AppointmentStatus.Cancelled;
            }
        }

        public IEnumerable<SlotDto> GetSlotsForDoctor(Guid doctorId)
        {
            return _slotProvider.GetAvailableSlots(doctorId);
        }
    }
}
