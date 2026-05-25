using Clinic_APIs.DTOs;
using Clinic_APIs.Data;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;

namespace Clinic_APIs.Services{

public class DoctorService : IDoctorService{

private readonly ClinicDbContext _context;


public DoctorService (ClinicDbContext context){
    _context = context; 
}

public async Task<DoctorRegiResponesDTO> DoctorServices (DoctorRegstirationDTO dto){


var doctor = new Doctor{

DoctorName = dto.DoctorName,
PhoneNumber = dto.PhoneNumber,
Email = dto.Email,
Specialization = dto.Specialization,
IsAvailable = dto.IsAvailable

};

_context.Doctor.Add(doctor);
await _context.SaveChangesAsync();

return new DoctorRegiResponesDTO{
DoctorName = doctor.DoctorName,
PhoneNumber = doctor.PhoneNumber,
Email = doctor.Email,
Specialization = doctor.Specialization,
    
};

}




}




}