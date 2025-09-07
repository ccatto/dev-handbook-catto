Legacy

 Legacy ASP.NET, WinForms, WCF, WPF, XML, etc

 # Legacy .NET / .NET Framework 4.8 - Developer Handbook

**.NET Framework** is the **classic, Windows-only version of .NET**, first released in **2002**, with the latest version being **4.8** (released in 2019). It provides a **robust runtime, libraries, and tooling** for building desktop, web, and enterprise applications on Windows.

---

## Overview

- **Full framework for Windows applications**, including ASP.NET, Windows Forms, WPF, and WCF.  
- Supports **C#, VB.NET, and F#**.  
- Provides a **large class library** for networking, database access, security, and UI.  
- Integrated with **Visual Studio** for rich development tooling.  
- Still widely used in **enterprise applications**, legacy systems, and internal tooling.  

---

## Key Differences Between .NET Framework and .NET Core / .NET 5+

| Feature | .NET Framework 4.8 | .NET Core / .NET 5+ |
|---------|------------------|--------------------|
| Platform | Windows-only | Cross-platform (Windows, Linux, macOS) |
| Open Source | Partially | Fully open source |
| Performance | Good, but tied to Windows | Higher performance, lightweight |
| Deployment | Requires framework installed on machine | Self-contained deployment possible |
| Modern APIs | Limited modern APIs | Access to latest .NET APIs, async improvements, microservices support |
| Blazor / Web APIs | Only ASP.NET MVC / Web Forms | ASP.NET Core, Blazor, gRPC support |

---

## Common Use Cases

- **ASP.NET Web Forms and MVC 5** for legacy web apps.  
- **WPF / Windows Forms** for desktop applications.  
- **WCF** for enterprise service-oriented applications.  
- Internal **line-of-business applications** in enterprises.  
- Applications **tied to Windows APIs or legacy infrastructure**.  

---

## Example: Simple ASP.NET Web API in .NET Framework 4.8

**Controller Example:**
```csharp
public class UsersController : ApiController
{
    public IHttpActionResult Get(int id)
    {
        var user = UserRepository.GetUserById(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    public IHttpActionResult Post(User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        UserRepository.Add(user);
        return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
    }
}
```

#### Key Notes:

* Uses System.Web.Http.ApiController instead of ASP.NET Core ControllerBase.
* Routing is defined in WebApiConfig.cs using HttpRoute.
* Dependency injection is not built-in; often requires Unity, Ninject, or Autofac.

### Summary

Legacy .NET Framework 4.8 is still widely used for enterprise, desktop, and internal applications. However, .NET Core / .NET 5+ offers cross-platform capabilities, modern APIs, better performance, and is recommended for all new development projects.