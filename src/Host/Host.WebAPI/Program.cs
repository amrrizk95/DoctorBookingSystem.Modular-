using AppointmentBooking.API.Controllers;
using AppointmentBooking.Application.Interfaces;
using AppointmentBooking.Infrastructure.Services;
using AppointmentConfirmation.API.Controllers;
using AppointmentConfirmation.API.Handlers;
using DoctorAppointmentManagement.API.Controllers;
using DoctorAppointmentManagement.Application.Ports;
using DoctorAppointmentManagement.Infrastructure.Adapters;
using DoctorAvailability.API.Controllers;
using DoctorAvailability.Application.Interfaces;
using DoctorAvailability.Infrastructure.Adapters;
using DoctorAvailability.Infrastructure.Repositories;
using DoctorBookingSystem.Shared.Interfaces.DoctorAvailability;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly); // still needed for Host commands/queries
    cfg.RegisterServicesFromAssembly(typeof(AppointmentBookedHandler).Assembly); // add this for handlers
});
builder.Services.AddScoped<ISlotService, SlotService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentManagementService, InMemoryAppointmentService>();
builder.Services.AddScoped<ISlotProvider, SlotProvider>();

var mvcBuilder = builder.Services.AddControllers();
mvcBuilder.AddApplicationPart(typeof(SlotsController).Assembly);
mvcBuilder.AddApplicationPart(typeof(AppointmentsController).Assembly);
mvcBuilder.AddApplicationPart(typeof(AppointmentConfirmationController).Assembly);
mvcBuilder.AddApplicationPart(typeof(DoctorAppointmentsController).Assembly); //
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName.Replace("+", ".")); // ?? Fix
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();





app.Run();


