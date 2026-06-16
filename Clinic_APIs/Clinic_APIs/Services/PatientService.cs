using AutoMapper;
using Clinic_APIs.Data;
using Clinic_APIs.DTOs;
using Clinic_APIs.Models;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore;

namespace Clinic_APIs.Services
{
    public class PatientService : IPatientService
    {
        private readonly ClinicDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(ClinicDbContext context, IMapper mapper)
        { // constructor to inject the database context into the service. This allows the service to interact with the database through the ClinicDbContext instance.
            _context = context;
            _mapper = mapper;
        }

        public async Task<PatientRegistrationResponseDTO> RegisterPatient(
            PatiantsRegstirationDTO dto
        )
        {
            //     var patient = new Patient{ // input

            // PatientName = dto.PatientName,
            // PhoneNumber = dto.PhoneNumber,
            // Email = dto.Email,
            // Gender = dto.Gender,
            // DateOfBirth = dto.DateOfBirth

            //     };

            try
            {
                var patient = _mapper.Map<Patient>(dto);

                _context.Patient.Add(patient);
                await _context.SaveChangesAsync();

                return _mapper.Map<PatientRegistrationResponseDTO>(patient);
            }
            catch (Exception)
            {
                throw;
            }
            // return new PatientRegistrationResponseDTO{ // respones
            // PatientName = patient.PatientName,
            //  PatientId = patient.PatientId,
            // PhoneNumber = patient.PhoneNumber,
            // Email = patient.Email

            //  };
        }
    }
}
