using Clinic_APIs.DTOs;
namespace Clinic_APIs.Services{


public interface IDoctorService{

Task<DoctorRegiResponesDTO> DoctorServices (DoctorRegstirationDTO dto);
 

}

}