using DoctorAppointmentManagement.Application.Ports;
using DoctorAppointmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Infrastructure.Adapters
{
    public class InMemoryAppointmentService : IAppointmentManagementService
    {
        private static readonly List<DoctorAppointment> _appointments = new();

        public void Add(DoctorAppointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            appointment.Status = AppointmentStatus.Scheduled;
            _appointments.Add(appointment);
        }

        public IEnumerable<DoctorAppointment> GetByDoctorId(Guid doctorId) =>
            _appointments.Where(a => a.DoctorId == doctorId);

        public void UpdateStatus(Guid id, AppointmentStatus newStatus)
        {
            var app = _appointments.FirstOrDefault(x => x.Id == id);
            if (app != null) app.Status = newStatus;
        }
    }
}
