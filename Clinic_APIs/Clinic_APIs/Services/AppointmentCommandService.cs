using Clinic_APIs.DTOs;
using Clinic_APIs.Data;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;

namespace Clinic_APIs.Services{

public class AppointmentCommandService : IAppointmentCommandService{
public readonly ClinicDbcontext _context;

public async Task<AppointmentResponseDTO> CreateAppointment (CreateAppointmentDTO dto){

var findDoctor = await _context.Doctor.FirstOrDefaultAsync(d => d.DoctorId == dto.DoctorId);{
if (findDoctor == null || !findDoctor.IsAvailable){
    throw new Exception("Doctor not available or does not exist");

}
}

var findPatient = await _context.Patient.FirstOrDefaultAsync (p => p.PatientId == dto.PatientId);{
if (findPatient == null){
    throw new Exception("Patient not found");
}
}
var appointment = new Appointment{

    DoctorId = dto.DoctorId,
    AppointmentId = dto.AppointmentId,
    PatientId = dto.PatientId,
    AppointmentDate = dto.AppointementDate,
    StatusApp = AppointmentStatus.Scheduled,
    Notes = dto.Notes
};

_context.Appointment.Add(appointment);
await _context.SaveChangesAsync();

return new AppointmentResponseDTO{
    AppointmentId = appointment.AppointmentId,
    DoctorName = findDoctor.DoctorName,
    PatientName = findPatient.PatientName,
    AppointmentDate = appointment.AppointmentDate,
    Status = appointment.StatusApp.ToString()

}; }




public async Task<AppointmentResponseDTO> CancelAppointment (int AppointmentId){
var appointment = await _context.Appointment.FirstOrDefaultAsync(a => a.AppointmentId == AppointmentId);
if (appointment == null){
    throw new Exception("Appointment not found");
}

appointment.StatusApp = AppointmentStatus.Canceled;
await _context.SaveChangesAsync();

return new AppointmentResponseDTO{
    AppointmentId = appointment.AppointmentId,
    DoctorName = appointment.Doctor.DoctorName,
    PatientName = appointment.Patient.PatientName,
    AppointmentDate = appointment.AppointmentDate,
    Status = appointment.StatusApp.ToString()
};






}


}
}





