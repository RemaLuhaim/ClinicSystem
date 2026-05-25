using System;
using System.ComponentModel.DataAnnotations;


namespace Clinic_APIs.DTOs {

public class DoctorRegstirationDTO{

[Required]
public string DoctorName {get; set;}
[Required]

public string PhoneNumber {get; set;}
[Required]

public string Email {get; set;}
[Required]

public string Specialization {get; set;}
[Required]

public bool IsAvailable {get; set;}


}



    }