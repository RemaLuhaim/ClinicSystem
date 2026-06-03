using Clinic_APIs.DTOs;
using Clinic_APIs.Services;
using Microsoft.AspNetCore.Mvc;


namespace Clinic_APIs.Controllers{ //Controller is like a middleware between the client and the service layer, it receives the request from the client and calls the appropriate method in the service layer to process the request and return a response to the client BY TRANSFIRMING JSON TO DTO THEN CALL THE SERVICE LAYER TO PROCESS THE REQUEST AND RETURN A RESPONSE TO THE CLIENT IN JSON FORMAT


[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase{

private readonly IPatientService _patientService;//field 
public PatientController (IPatientService patientService){//constructor injection
    _patientService = patientService;//we will use this service to call the method in the service layer
}

[HttpPost("Register")]
public async Task<IActionResult> RegisterPatient (PatiantsRegstirationDTO dto){
    var result = await _patientService.RegisterPatient(dto);
    return Ok(result);
}



}

}