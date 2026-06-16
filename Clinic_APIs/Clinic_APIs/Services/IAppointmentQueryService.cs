using Clinic_APIs.DTOs;

namespace Clinic_APIs.Services
{
    public interface IAppointmentQueryService
    {
        Task<AppointmentResponseDTO> GetUserAppointmentById(int appointmentID);
    }
}
