using system:
using system.Collections.Generic;

namespace Clinic_APIs.Controllers{

public class Appointment{
    public int AppointmentId {get; set;}
    public int DoctorId {get; set;}
    public int PatientId {get; set;}
    public string? Notes {get; set;}
    public DateTime AppointmentDate {get; set;}
    public AppointmentStatus Status {get; set;} = AppointmentStatus.Scheduled; // Default status is Scheduled

public Doctor Doctor {get; set;}
public Patient Patient {get; set;}

}