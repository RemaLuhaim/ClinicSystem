using System.Collections.Generic;
namespace Clinic_APIs.Controllers
{
   public class Patients{

public int PatientId {get; set;}
public string PatientName {get; set;}
public string PhoneNumber {get; set;}
public string Email {get; set;}
public string Gender {get; set;}
public DateTime DateOfBirth {get; set;}


public List<Appointment> Appointments {get; set;} = new List<Appointment>(); // List of appointments for the doctor

   } 

}
