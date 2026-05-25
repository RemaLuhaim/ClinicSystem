using Clinic_APIs.DTOs; //namespace

namespace Clinic_APIs.Services{

    public interface IPatientService{

Task<PatientRegistrationResponseDTO> RegisterPatient (PatiantsRegstirationDTO dto); // Task means we have async method 

    }
}
