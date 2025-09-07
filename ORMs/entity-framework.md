# EF - Entity Framework 

# Entity Framework Core (.NET) Overview for C# Web API + Angular Frontend

**Entity Framework (EF) Core** is a lightweight, extensible, cross-platform version of Microsoft’s popular ORM (Object-Relational Mapper) for .NET. It simplifies database access by mapping C# classes to database tables and generating SQL queries automatically.

---

## 🔹 Overview

* EF Core enables **CRUD operations** without writing raw SQL.
* Supports **LINQ** queries for strongly typed querying.
* Works with multiple databases: SQL Server, PostgreSQL, MySQL, SQLite, etc.
* Fully integrates with **ASP.NET Core**, **dependency injection**, and **migrations**.
* Supports **change tracking**, **lazy loading**, **eager loading**, and **explicit loading**.

---

## 🔹 Common Uses

* Database access layer for **C# Web APIs**.
* Rapid development of **data-driven applications**.
* CRUD operations with **DTOs** for Angular frontends.
* Database migrations and schema evolution.
* Querying relational data with **LINQ**.

---

## 🔹 Best Practices / Patterns

* **Repository Pattern** → Encapsulate EF Core operations for testability.
* **Unit of Work Pattern** → Manage transactions across multiple repositories.
* **Dependency Injection** → Inject `DbContext` into services.
* **DTOs & AutoMapper** → Map entities to lightweight objects for API responses.
* **Migrations** → Use `Add-Migration` and `Update-Database` to track schema changes.
* **AsNoTracking()** → Improve read-only query performance.

---

## 🔹 Folder Structure Example

```
/MyWebApi
│
├─ Data
│   └─ AppDbContext.cs
│
├─ Models
│   └─ User.cs
│
├─ Repositories
│   └─ UserRepository.cs
│
├─ Services
│   └─ UserService.cs
│
├─ Controllers
│   └─ UserController.cs
```

* **DbContext** → Manages EF Core database connection.
* **Models** → Entity classes representing tables.
* **Repositories** → CRUD operations.
* **Services** → Business logic.
* **Controllers** → Handle HTTP requests.

---

## 🔹 Simple Code Example

```csharp
// Models/User.cs
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
}

// Repositories/UserRepository.cs
public class UserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context) { _context = context; }

    public async Task<List<User>> GetAllUsersAsync() => await _context.Users.ToListAsync();

    public async Task AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
```

---

## 🔹 Code Flow Diagram

```
[ Client (Angular) ]
        |
        v
[ Controller ]
        |
        v
[ Service Layer ]
        |
        v
[ Repository ]
        |
        v
[ DbContext / EF Core ]
        |
        v
[ Database (SQL Server / PostgreSQL) ]
```

---

## 🔹 Why It's Popular

* Eliminates boilerplate SQL and reduces errors.
* Strongly typed queries with **LINQ**.
* Cross-platform and open-source.
* Integrated with **ASP.NET Core**, DI, and migrations.
* Supports **complex relationships**, navigation properties, and eager/lazy loading.

---

## 🔹 Summary

EF Core is a robust ORM that simplifies database operations in .NET applications. It integrates seamlessly with C# Web APIs, supports multiple databases, and works well with Angular frontends. Using EF Core with best practices like repositories, unit of work, and migrations ensures maintainable and scalable applications.
