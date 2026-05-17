using System.Collections.Generic;

namespace Clinic_APIs.controllers{

public class Doctors{
    

    public int DoctorId {get; set;}
    public string DoctorName {get; set;}
    public string PhoneNumber {get; set;}
    public string Specialization {get; set;}
    public string Email {get; set;}  
    public bool IsAvailable {get; set;} = true;// Indicates if the doctor is currently available for appointments

    public List<Appointment> Appointments {get; set;} = new List<Appointment>(); // List of appointments for the doctor

}

}