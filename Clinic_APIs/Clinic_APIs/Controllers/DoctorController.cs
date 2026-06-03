using Clinic_APIs.DTOs;
using Clinic_APIs.Services;
using Microsoft.AspNetCore.Mvc;



namespace Clinic_APIs.Controllers{

[ApiController]
[Route("api/[Controller]")] //     api/Doctor
public class DoctorController : ControllerBase{

private readonly IDoctorService _Doctor;

public DoctorController (IDoctorService Doctor){
    _Doctor = Doctor;

}

[HttpPost ("DoctorRegister")]
public async Task<IActionResult> DoctorServices (DoctorRegstirationDTO dto){

var result = await _Doctor.DoctorServices(dto);
return Ok(result);

}


}

}
