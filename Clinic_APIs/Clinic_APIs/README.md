# Clinic Management System API

A simple Clinic Management System built using ASP.NET Core Web API and Entity Framework Core.

The system allows managing:

- Patients
- Doctors
- Appointments

The project follows clean backend development practices including:

- DTO Pattern
- Dependency Injection (DI)
- Repository-like Service Layer
- CQRS Pattern for Appointment Operations
- Entity Framework Core
- Swagger Documentation

---

# Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite Database
- Swagger / OpenAPI
- Dependency Injection
- CQRS Pattern

---

# Project Structure

```text
Clinic_APIs
│
├── Controllers
├── Services
├── DTOs
├── Models
├── Data
├── Migrations
├── Program.cs
└── appsettings.json
```

---

# Features

## Patient Management

- Register Patient

## Doctor Management

- Register Doctor

## Appointment Management

### Commands (Write Operations)

- Create Appointment
- Cancel Appointment

### Queries (Read Operations)

- Get Appointment By Id

---

# CQRS Implementation

Appointments are implemented using the CQRS pattern.

### Command Side

Responsible for changing data:

- CreateAppointment()
- CancelAppointment()

Implemented in:

```text
AppointmentCommandService
```

### Query Side

Responsible for retrieving data:

- GetAppointmentById()

Implemented in:

```text
AppointmentQueryService
```

This separation improves maintainability and follows modern backend architecture principles.

---

# Database

The project uses SQLite as the local database.

Database file:

```text
clinic.db
```

Entity Framework Core Migrations are used to create and update the database schema.

---

# Required Installations

Before running the project make sure you have installed:

## .NET SDK

.NET 10 SDK (or your current SDK version)

Check installation:

```bash
dotnet --version
```

---

## Entity Framework Tools

Install EF Core CLI:

```bash
dotnet tool install --global dotnet-ef
```

Verify:

```bash
dotnet ef
```

---

# Running the Project

## 1. Clone Repository

```bash
git clone <repository-url>
```

---

## 2. Navigate to Project

```bash
cd Clinic_APIs
```

---

## 3. Restore Packages

```bash
dotnet restore
```

---

## 4. Apply Database Migrations

```bash
dotnet ef database update
```

This command creates:

```text
clinic.db
```

and applies all migrations.

---

## 5. Run the Application

```bash
dotnet run
```

---

# Swagger Documentation

After running the application open:

```text
http://localhost:5268/swagger
```

Swagger provides:

- API Documentation
- Request Testing
- Response Visualization

---

# API Endpoints

## Patient

### Register Patient

```http
POST /api/Patient/Register
```

Request:

```json
{
  "patientName": "John Doe",
  "phoneNumber": "0500000000",
  "email": "john@example.com",
  "gender": "Male",
  "dateOfBirth": "2000-01-01"
}
```

Response:

```json
{
  "patientId": 1,
  "patientName": "John Doe",
  "phoneNumber": "0500000000",
  "email": "john@example.com"
}
```

---

## Doctor

### Register Doctor

```http
POST /api/Doctor/Register
```

---

## Appointment

### Create Appointment

```http
POST /api/Appointment/Create
```

### Get Appointment By Id

```http
GET /api/Appointment/{appointmentId}
```

### Cancel Appointment

```http
PUT /api/Appointment/Cancel/{appointmentId}
```

---

# Design Patterns Used

## DTO Pattern

Used to separate API contracts from database entities.

Examples:

- PatientRegistrationDTO
- PatientRegistrationResponseDTO
- DoctorRegistrationDTO
- AppointmentResponseDTO

---

## Dependency Injection

Services are injected into controllers using ASP.NET Core's built-in DI container.

Example:

```csharp
private readonly IPatientService _patientService;
```

---

## CQRS

Commands and Queries are separated into different services.

Benefits:

- Better scalability
- Cleaner architecture
- Easier maintenance

---

# Author

Developed by:

**Rema Aluhaim - rema.luhaim@gmail.com**
ASP.NET Core | Full Stack Development | Backend Development