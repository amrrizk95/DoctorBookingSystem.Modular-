using AppointmentBooking.Domain.Entities;
using DoctorBookingSystem.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Application.Interfaces
{
    public interface IAppointmentService
    {
        void Book(Appointment appointment);
        IEnumerable<Appointment> GetAll();
        Appointment? GetById(Guid id);
        void Cancel(Guid id);
        IEnumerable<SlotDto> GetSlotsForDoctor(Guid doctorId);
    }
}
