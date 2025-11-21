# NumberWordAnalyzer API

A simple ASP.NET Core Web API that analyzes strings of characters and counts number words. Built with clean architecture principles.

---

## Features

- Analyze input strings to count number words.
- ASP.NET Core 8 Web API.
- Dependency Injection for services.
- Memory caching for performance.
- Swagger documentation for API endpoints.

---

## Project Structure

NumberWordAnalyzer.API/ # API project
NumberWordAnalyzer.Application/ # Application layer with services and interfaces
NumberWordAnalyzer.Domain/ # Domain layer (business models)
NumberWordAnalyzer.Tests/ # Unit tests

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 or VS Code

### Run Locally

Clone the repository: git clone https://github.com/lebogangMatlala/NumberWordAnalyzerAPI.git

Navigate to the API project: cd NumberWordAnalyzer.API
Restore dependencies: dotnet restore
Run the API:dotnet run

Open Swagger UI in your browser:
https://localhost:5012/swagger/index.html

Deployment
The app can be deployed to Azure Web App. GitHub Actions workflow handles build and deployment automatically when pushing to main.

Access your API in production:
https://<your-app-name>.azurewebsites.net/swagger/index.html





