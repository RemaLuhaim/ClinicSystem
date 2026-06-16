using Clinic_APIs.Data;
using Clinic_APIs.DTOs;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace Clinic_APIs.Services
{
    public class AppointmentQueryService : IAppointmentQueryService
    {
        private readonly ClinicDbContext _context;
                        private readonly IMapper _mapper;


        public AppointmentQueryService(ClinicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AppointmentResponseDTO> GetUserAppointmentById(int AppointmentId)
        {
            var appointment = await _context
                .Appointment
                // retrieves an appointment from the database based on the provided appointment ID. It includes related doctor and patient information using the Include method to ensure that the returned appointment object contains all necessary details for constructing the response DTO.
                .Include(a => a.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(c => c.AppointmentId == AppointmentId);

            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            return new AppointmentResponseDTO
            { // This line creates and returns a new instance of the AppointmentResponseDTO class, which is used to encapsulate the response data for an appointment query operation. The properties of this DTO are being set based on the values from the appointment object that was retrieved from the database, including the appointment ID, doctor name, patient name, appointment date, and status.
                AppointmentId = appointment.AppointmentId,
                DoctorName = appointment.Doctor.DoctorName,
                PatientName = appointment.Patient.PatientName,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status.ToString(),
            };
        }
    }
}
