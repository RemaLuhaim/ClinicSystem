using AutoMapper;
using Clinic_APIs.Data;
using Clinic_APIs.DTOs;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;


namespace Clinic_APIs.Services
{
    public class DoctorService : IDoctorService{
    
        private readonly ClinicDbContext _context;


        private readonly IMapper _mapper;
        public DoctorService(ClinicDbContext context, IMapper mapper)
        {
               _context = context;
            _mapper = mapper;
        

        }

        public async Task<DoctorRegiResponesDTO> DoctorServices(DoctorRegstirationDTO dto)
        {

            var doctor = _mapper.Map<Doctor>(dto);
            _context.Doctor.Add(doctor);
            await _context.SaveChangesAsync();

            return _mapper.Map<DoctorRegiResponesDTO>(doctor);
                                //Generic type        //THE obj
        }
    }
}
