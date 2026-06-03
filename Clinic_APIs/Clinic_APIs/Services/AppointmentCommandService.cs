using Clinic_APIs.DTOs;
using Clinic_APIs.Data;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;

namespace Clinic_APIs.Services{

public class AppointmentCommandService : IAppointmentCommandService{ // Write
private  readonly ClinicDbContext _context;

public AppointmentCommandService (ClinicDbContext context){// DI Constrcuter
    _context = context;
    
}
public async Task<AppointmentResponseDTO> CreateAppointment (CreateAppointmentDTO dto){

var findDoctor = await _context.Doctor.FirstOrDefaultAsync(d => d.DoctorId == dto.DoctorId);{// Fetch تقارن القيمه اللي جايه من الداتا بيس مع القيمه اللي جايه من الريكويست
if (findDoctor == null || !findDoctor.IsAvailable){
    throw new Exception("Doctor not available or does not exist");

}
}

var findPatient = await _context.Patient.FirstOrDefaultAsync (p => p.PatientId == dto.PatientId);{ // we will validate if findPatient AND findDoctor do exisit or not 
if (findPatient == null){
    throw new Exception("Patient not found");
}
}
var appointment = new Appointment{ // عبينا البينات من ال dto  لاوبجطت الابوينتمت

    DoctorId = dto.DoctorId,
    PatientId = dto.PatientId,
    AppointmentDate = dto.AppointmentDate,
    Status = AppointmentStatus.Scheduled,
    Notes = dto.Notes
};

_context.Appointment.Add(appointment);
await _context.SaveChangesAsync();// لازم تخلص اول ثم تروح للريترن لكن الفكره انها ما تعلق السيرفر كامل عشان هالعمليه 

return new AppointmentResponseDTO{
    AppointmentId = appointment.AppointmentId,// الداتا بيس تولد اي دي تلقائيا
    DoctorName = findDoctor.DoctorName,
    PatientName = findPatient.PatientName,
    AppointmentDate = appointment.AppointmentDate,
    Status = appointment.Status

}; }




public async Task<AppointmentResponseDTO> CancelAppointment (int AppointmentId){

 var appointment = await _context.Appointment
        .Include(a => a.Doctor)
        .Include(a => a.Patient)
        .FirstOrDefaultAsync(a => a.AppointmentId == AppointmentId);

if (appointment == null){
    throw new Exception("Appointment not found");
}

appointment.Status = AppointmentStatus.Canceled;
await _context.SaveChangesAsync();// LINQ the EF work is to translate this query into a sql lang so the db can understand 

return new AppointmentResponseDTO{
    AppointmentId = appointment.AppointmentId,
    DoctorName = appointment.Doctor.DoctorName,
    PatientName = appointment.Patient.PatientName,
    AppointmentDate = appointment.AppointmentDate,
    Status = appointment.Status
};






}


}
}





