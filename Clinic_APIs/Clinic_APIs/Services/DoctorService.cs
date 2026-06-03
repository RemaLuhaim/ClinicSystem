using Clinic_APIs.DTOs;
using Clinic_APIs.Data;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;

namespace Clinic_APIs.Services{

public class DoctorService : IDoctorService{

private readonly ClinicDbContext _context;// This line declares a private readonly field named _context of type ClinicDbContext. This field will be used to interact with the database context throughout the service.


public DoctorService (ClinicDbContext context){// This is the constructor for the DoctorService class. It takes a ClinicDbContext object as a parameter and assigns it to the _context field. This allows the service to use the database context for performing operations related to doctors.
    _context = context; 
}

public async Task<DoctorRegiResponesDTO> DoctorServices (DoctorRegstirationDTO dto){// This method is responsible for handling the registration of a doctor. It takes a DoctorRegstirationDTO object as input, which contains the necessary information for registering a doctor. The method creates a new Doctor object based on the provided DTO, adds it to the database context, and saves the changes asynchronously. Finally, it returns a DoctorRegiResponesDTO object containing the details of the registered doctor.


var doctor = new Doctor{// This line creates a new instance of the Doctor class and initializes its properties using the values from the provided DoctorRegstirationDTO (dto). The properties being set include DoctorName, PhoneNumber, Email, Specialization, and IsAvailable.

DoctorName = dto.DoctorName,// This line sets the DoctorName property of the doctor object to the value of DoctorName from the dto (DoctorRegstirationDTO) that was passed as a parameter to the DoctorServices method.
PhoneNumber = dto.PhoneNumber,
Email = dto.Email,
Specialization = dto.Specialization,
IsAvailable = dto.IsAvailable

};

_context.Doctor.Add(doctor);
await _context.SaveChangesAsync();

return new DoctorRegiResponesDTO{// This line creates and returns a new instance of the DoctorRegiResponesDTO class, which is used to encapsulate the response data for a doctor registration operation. The properties of this DTO are being set based on the values from the doctor object that was just created and saved to the database.
DoctorName = doctor.DoctorName,
DoctorId = doctor.DoctorId,
PhoneNumber = doctor.PhoneNumber,
Email = doctor.Email,
Specialization = doctor.Specialization,
    
};

}




}




}