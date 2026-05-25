using Clinic_APIs.Data; //using means "use the namespace of '' so you can see their classes name"
using Microsoft.EntityFrameworkCore; // labrariy called EFC that has DbContext, DbSet, UseSqlite, migrations, LINQ

var builder = WebApplication.CreateBuilder(args); // create obj called bulider that will read appsetting.json
builder.Services.AddControllers(); // add services to the container, in this case we want to add controllers
builder.Services.AddDbContext<ClinicDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection"))); //

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); // build the app, this will create the pipeline
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // redirect http to https
app.UseAuthorization(); // use authorization, this will check if the user is authorized to access the resource

app.MapControllers(); // map the controllers to the endpoints, this will allow us to access the controllers

app.Run(); // run the app, this will start the server and listen for requests

