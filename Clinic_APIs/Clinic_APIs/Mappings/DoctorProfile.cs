using AutoMapper;
using Clinic_APIs.DTOs;
using Clinic_APIs.Models;

namespace Clinic_APIs.Mappings
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<DoctorRegstirationDTO, Doctor>();
            CreateMap<Doctor, DoctorRegiResponesDTO>();
        }
    }
}
