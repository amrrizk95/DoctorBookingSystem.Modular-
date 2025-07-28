using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagement.Domain.Entities
{
    public class DoctorAppointment
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid AppointmentId { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public class UpdateStatusDto
    {
        public Guid Id { get; set; }
        public AppointmentStatus Status { get; set; }


    }
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Missed
    }
}
