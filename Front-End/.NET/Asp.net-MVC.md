# ASP.NET MVC - Catto Developer Handbook

**ASP.NET MVC** is a **web application framework developed by Microsoft** that implements the **Model-View-Controller (MVC) pattern**. It allows developers to build structured, maintainable web applications using **C# and the .NET Framework**.

---

## Overview and History

- **Introduced in 2007** as an alternative to **ASP.NET Web Forms**.  
- Emphasized **separation of concerns** with Models (data), Views (UI), and Controllers (logic).  
- Popular for building **server-rendered web applications** using the .NET Framework.  
- Gradually considered “older” with the rise of **ASP.NET Core, Blazor, and modern frontend frameworks**.  
- Still used in legacy enterprise applications and for maintaining existing projects.

---

## Why ASP.NET MVC is Considered Older

- Runs primarily on the **Windows-only .NET Framework** (not cross-platform).  
- Requires **server-side rendering**, which can be slower compared to modern SPAs.  
- Limited support for **modern frontend tooling** compared to Blazor, React, or Angular.  
- ASP.NET Core MVC and Blazor are now **recommended for new projects**.  

---

## Key Features of ASP.NET MVC

- **MVC Pattern**: Clear separation of concerns between Models, Views, and Controllers.  
- **Routing**: URL patterns map to controller actions.  
- **Razor Views**: Server-side HTML rendering with embedded C# code.  
- **Model Binding**: Automatically maps form values or query strings to C# objects.  
- **Validation**: Data annotations for input validation.  
- **Extensibility**: Filters, custom model binders, and dependency injection support.  

---

## Common Use Cases

- **Legacy enterprise web applications** that need maintenance or incremental upgrades.  
- Applications requiring **server-side rendering** for SEO or internal tools.  
- Projects using **existing .NET Framework infrastructure**.  

---

## Example: Simple ASP.NET MVC Controller and View

**Controller (HomeController.cs):**
```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Message = "Welcome to ASP.NET MVC!";
        return View();
    }
}
```

```razor
@{
    ViewBag.Title = "Home Page";
}

<h2>@ViewBag.Message</h2>
```