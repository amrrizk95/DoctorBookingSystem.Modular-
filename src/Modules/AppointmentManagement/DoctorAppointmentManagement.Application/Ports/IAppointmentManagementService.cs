using DoctorAppointmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Application.Ports
{
    public interface IAppointmentManagementService
    {
        IEnumerable<DoctorAppointment> GetByDoctorId(Guid doctorId);
        void UpdateStatus(Guid id, AppointmentStatus newStatus);
        void Add(DoctorAppointment appointment);
    }
}
