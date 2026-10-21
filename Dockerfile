# Etapa 1: Compilación de la solución completa
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiar proyectos y restaurar dependencias
COPY ["src/backend/AcademicEnrollmentService/AcademicEnrollmentService.Api/AcademicEnrollmentService.Api.csproj", "AcademicEnrollmentService.Api/"]
COPY ["src/backend/AcademicEnrollmentService/AcademicEnrollmentService.Core/AcademicEnrollmentService.Core.csproj", "AcademicEnrollmentService.Core/"]
COPY ["src/backend/AcademicEnrollmentService/AcademicEnrollmentService.Infrastructure/AcademicEnrollmentService.Infrastructure.csproj", "AcademicEnrollmentService.Infrastructure/"]

RUN dotnet restore "AcademicEnrollmentService.Api/AcademicEnrollmentService.Api.csproj"

# Copiar todo el código fuente
COPY src/backend/AcademicEnrollmentService/ .

# Publicar la API
RUN dotnet publish "AcademicEnrollmentService.Api/AcademicEnrollmentService.Api.csproj" -c Release -o /app/publish

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV PORT=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "AcademicEnrollmentService.Api.dll"]