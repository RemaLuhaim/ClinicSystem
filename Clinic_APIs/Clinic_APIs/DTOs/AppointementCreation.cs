using System;
using System.ComponentModel.DataAnnotations;

namespace Clinic_APIs.DTOs{

public class CreateAppointmentDTO{


[Required]
public int DoctorId {get; set;}
[Required]
public int PatientId {get; set;}
[Required]
public DateTime AppointmentDate {get; set;}
[MaxLength(500)]
public string? Notes {get; set;}


}



}