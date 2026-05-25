
using System.ComponentModel.DataAnnotations;


namespace Clinic_APIs.DTOs{

public class PatiantsRegstirationDTO{

[Required]
public string PatientName {get; set;}
[Required]
public string PhoneNumber {get; set;}
[Required]
public string Email {get; set;}
[Required]
public string Gender {get; set;}
[Required]
public DateTime DateOfBirth {get; set;}

}

}