using Clinic_APIs.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic_APIs.Data{

public class ClinicDbContext : DbContext // This class represents the database context for the clinic application. It inherits from DbContext, which is part of Entity Framework Core. The ClinicDbContext class is responsible for managing the connection to the database and providing access to the data through DbSet properties.
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patient { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
}




}