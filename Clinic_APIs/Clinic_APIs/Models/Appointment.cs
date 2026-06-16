

using System.Collections.Generic;

namespace Clinic_APIs.Models{

public class Appointment{
   
    public int AppointmentId {get; set;}
    public int DoctorId {get; set;}
    public AppointmentStatus Status {get; set;} 
      public int PatientId {get; set;}
    public string? Notes {get; set;}
    public DateTime AppointmentDate {get; set;}
    

public Doctor Doctor {get; set;}
public Patient Patient {get; set;}

}
}