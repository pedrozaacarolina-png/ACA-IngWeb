# Etapa 1: Compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["AcademicEnrollmentService.Api.csproj", "./"]
RUN dotnet restore "AcademicEnrollmentService.Api.csproj"
COPY . .
RUN dotnet publish "AcademicEnrollmentService.Api.csproj" -c Release -o /app/publish

# Etapa 2: Ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV PORT=8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "AcademicEnrollmentService.Api.dll"]