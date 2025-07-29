using DoctorBookingSystem.Shared.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentConfirmation.API.Handlers
{
    public class AppointmentBookedHandler : INotificationHandler<AppointmentBookedEvent>
    {
        public Task Handle(AppointmentBookedEvent notification, CancellationToken cancellationToken)
        {
            // Confirmation logic (e.g., send email, log, etc.)
            Console.WriteLine($"Confirming appointment for Doctor {notification.DoctorId} at {notification.SlotTime}");
            return Task.CompletedTask;
        }
    }
}
