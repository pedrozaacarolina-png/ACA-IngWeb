# Academic Enrollment Service

## Overview
The Academic Enrollment Service is a backend microservice designed to manage academic enrollments efficiently. It is structured into separate logical layers, adhering to the principles of component architecture. This service provides endpoints for creating and retrieving enrollment records, ensuring a clean separation of concerns between the domain, data, service, and controller layers.

## Project Structure
```
AcademicEnrollmentService
├── src
│   └── AcademicEnrollmentService
│       ├── Domain
│       │   ├── Entities
│       │   │   └── Matricula.cs
│       │   └── DTOs
│       │       ├── CreateMatriculaDto.cs
│       │       └── MatriculaResponseDto.cs
│       ├── Data
│       │   ├── Interfaces
│       │   │   └── IMatriculaRepository.cs
│       │   └── Repositories
│       │       └── MatriculaRepository.cs
│       ├── Services
│       │   ├── Interfaces
│       │   │   └── IMatriculaService.cs
│       │   └── MatriculaService.cs
│       ├── Controllers
│       │   └── MatriculasController.cs
│       ├── Middleware
│       │   └── ExceptionHandlingMiddleware.cs
│       ├── Persistence
│       │   └── ApplicationDbContext.cs
│       ├── Program.cs
│       ├── appsettings.json
│       └── AcademicEnrollmentService.csproj
├── tests
│   └── AcademicEnrollmentService.Tests
│       ├── Services
│       │   └── MatriculaServiceTests.cs
│       └── AcademicEnrollmentService.Tests.csproj
├── AcademicEnrollmentService.sln
└── README.md
```

## Features
- **Domain Layer**: Contains the `Matricula` entity and Data Transfer Objects (DTOs) for creating and responding to enrollment requests.
- **Data Layer**: Implements repository patterns for data access, allowing for easy management of `Matricula` entities.
- **Service Layer**: Contains business logic for processing enrollments, including validation and fee calculation.
- **Controller Layer**: Exposes RESTful endpoints for managing enrollments, including creating and retrieving records.
- **Middleware**: Implements global exception handling to ensure consistent error responses.

## Getting Started

### Prerequisites
- .NET 8 SDK
- A suitable IDE or text editor (e.g., Visual Studio Code)

### Installation
1. Clone the repository:
   ```
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```
   cd AcademicEnrollmentService/src/AcademicEnrollmentService
   ```
3. Restore the dependencies:
   ```
   dotnet restore
   ```

### Running the Application
To run the application, use the following command:
```
dotnet run
```
The service will start and listen for requests on the configured port.

### API Endpoints
- **GET /api/matriculas**: Retrieve all enrollments.
- **POST /api/matriculas**: Create a new enrollment.

## Testing
Unit tests are provided to ensure the functionality of the service layer. To run the tests, navigate to the test project directory and execute:
```
dotnet test
```

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.