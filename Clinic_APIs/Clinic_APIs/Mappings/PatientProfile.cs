using AutoMapper;
using Clinic_APIs.DTOs;
using Clinic_APIs.Models;

namespace Clinic_APIs.Mappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        { //consts
            CreateMap<PatiantsRegstirationDTO, Patient>();
            CreateMap<Patient, PatientRegistrationResponseDTO>();
            
        }
    }
}
