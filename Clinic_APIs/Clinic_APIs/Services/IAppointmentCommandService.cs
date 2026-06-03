using Clinic_APIs.DTOs;



namespace Clinic_APIs.Services{

public interface IAppointmentCommandService{

Task<AppointmentResponseDTO> CreateAppointment (CreateAppointmentDTO dto); 

Task<AppointmentResponseDTO> CancelAppointment (int AppointmentId); 


}



}