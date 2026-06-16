using AutoMapper;
using Clinic_APIs.Mappings;
using Clinic_APIs.Data;
using Clinic_APIs.Services;
using Microsoft.EntityFrameworkCore; // labrariy called EFC that has DbContext, DbSet, UseSqlite, migrations, LINQ
using Serilog;

Log.Logger = new LoggerConfiguration()
.WriteTo.Console()
.WriteTo.Seq("http://localhost:5341")
.CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddControllers();//

builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlite( // configure the database context to use SQLite as the database provider.
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
); //

builder.Services.AddScoped<IPatientService, PatientService>(); // add services to the container, in this case we want to add patient service, this will allow us to use the patient service in the controllers
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>(); // add services to the container
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>(); // add services to the container
builder.Services.AddScoped<IDoctorService, DoctorService>(); // add services to the container
builder.Services.AddAutoMapper(cfg =>
{
   cfg.AddProfile<PatientProfile>();
   cfg.AddProfile<DoctorProfile>();
  
});

builder.Services.AddEndpointsApiExplorer(); // add services to the container, in this case we want to add endpoints api explorer, this will allow us to explore the endpoints in swagger
builder.Services.AddSwaggerGen(); // add services to the container, in this case we want to add swagger gen, this will allow us to generate swagger documentation for our API


var app = builder.Build(); // build the app, this will create the pipeline
Log.Information("Log is starting..");
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // redirect http to https
app.UseAuthorization(); // use authorization, this will check if the user is authorized to access the resource
app.MapControllers(); // map the controllers to the endpoints, this will allow us to access the controllers

app.Run(); // run the app, this will start the server and listen for requests
