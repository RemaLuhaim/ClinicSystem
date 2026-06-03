using Clinic_APIs.DTOs;
using Clinic_APIs.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_APIs.Controllers{

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase {

private readonly IAppointmentCommandService _appointmentCommandService;
private readonly IAppointmentQueryService _appointmentQueryService;

public AppointmentController (IAppointmentCommandService appointmentCommandService, IAppointmentQueryService appointmentQueryService){
    _appointmentCommandService = appointmentCommandService;
    _appointmentQueryService = appointmentQueryService;
}

[HttpPost("Create")]
public async Task<IActionResult> CreateAppointment (CreateAppointmentDTO dto){
 var createAppointment = await _appointmentCommandService.CreateAppointment(dto);
 if (createAppointment == null){
    return BadRequest("Failed to create an appointment");
 }
 return Ok(createAppointment);
}

[HttpPut("Cancel/{id}")]
public async Task<IActionResult> CancelAppointment (int id){
 var cancelAppointment = await _appointmentCommandService.CancelAppointment(id);
 if (cancelAppointment == null){
    return BadRequest($"Failed to cancel {id} can not be canceled");
 }
 return Ok(cancelAppointment);
}

[HttpGet("GetById/{id}")]
public async Task<IActionResult> GetUserAppointmentById (int id){

var appointmentID = await _appointmentQueryService.GetUserAppointmentById(id);
if (appointmentID == null){
return NotFound($"Appointment with the ID {id} can not be found");
}
return Ok(appointmentID);
}

}

}