# .NET Core - Catto Developer Handbook

**.NET Core** is a **cross-platform, open-source framework** developed by Microsoft for building modern applications. It allows developers to create web, desktop, mobile, cloud, and microservices applications that run on **Windows, macOS, and Linux**.  

.NET Core was first released in **June 2016** (announced in 2014), as a modern, modular alternative to the traditional .NET Framework, making it **cross-platform, lightweight, and high-performance**.

---

## Overview and Summary

- Cross-platform: Runs on **Windows, Linux, and macOS**.  
- Open-source: Community contributions via GitHub.  
- High performance: Optimized runtime and libraries.  
- Flexible: Supports **web APIs, console apps, microservices, Blazor, gRPC, and more**.  
- CLI-driven: Full support for **command-line interface (CLI)** operations.  
- Unified with **.NET 5+**: .NET Core became part of the unified .NET platform with .NET 5 (2020) and beyond.

---

## Latest .NET Versions (as of 2025)

| Version | Release Year | Key Features |
|---------|-------------|--------------|
| **.NET 6 LTS** | 2021 | Long-Term Support (LTS), improved performance, minimal APIs, C# 10 features, Blazor improvements |
| **.NET 7** | 2022 | Cloud-native enhancements, performance tuning, C# 11 features, MAUI support |
| **.NET 8 LTS** | 2023 | Latest LTS version, improved cloud & microservices support, Hot Reload, advanced AOT, Native AOT for console apps |

---

## Key Features of .NET Core

- **Cross-platform development** for web, console, cloud, and desktop apps.  
- **High-performance web APIs** with ASP.NET Core.  
- **Modular packages** via NuGet.  
- **Dependency Injection (DI) built-in**.  
- **Asynchronous programming** with async/await.  
- **Unified platform** starting from .NET 5 for libraries and runtime.  
- **Blazor** for full-stack C# web apps (client-side and server-side).  
- **Entity Framework Core** for cross-platform ORM.  

---

## .NET Core CLI Overview

The **.NET CLI** (`dotnet`) allows you to **create, build, run, test, and publish applications** from the command line.

### Common Commands

| Command | Description |
|---------|-------------|
| `dotnet new console -n MyApp` | Create a new console app named MyApp |
| `dotnet new webapi -n MyApi` | Create a new ASP.NET Core Web API project |
| `dotnet build` | Build the project |
| `dotnet run` | Run the application |
| `dotnet test` | Run unit tests |
| `dotnet add package <PackageName>` | Add a NuGet package to the project |
| `dotnet restore` | Restore NuGet dependencies |
| `dotnet publish -c Release -o ./publish` | Publish the app for deployment |
| `dotnet --list-sdks` | List installed .NET SDK versions |
| `dotnet --version` | Show current SDK version |

---

## Tips & Best Practices

1. Use **LTS versions** for production applications.  
2. Prefer **minimal APIs** for small Web API projects.  
3. Organize projects into **solution folders** for larger apps.  
4. Utilize **dependency injection** to keep code modular and testable.  
5. Use **async/await** for I/O operations to improve performance.  
6. Take advantage of **Hot Reload** for rapid development in supported IDEs.  
7. Use **Entity Framework Core migrations** for database version control.  

---
