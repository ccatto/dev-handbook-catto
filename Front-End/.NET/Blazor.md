# Blazor

# Blazor - Developer Handbook

**Blazor** is a modern **web framework from Microsoft** that allows developers to build **interactive web applications using C# instead of JavaScript**. It runs in the browser via **WebAssembly** or on the server via **SignalR**, enabling full-stack .NET development with a single language.

---

## Why Blazor is Important

- Enables **full-stack C# development** for both frontend and backend.  
- Reduces the need to switch between **JavaScript and C#**, simplifying the developer workflow.  
- Supports **modern web features**: components, routing, data binding, and event handling.  
- Integrates seamlessly with **.NET Core / .NET 5+ APIs**.  
- Ideal for **enterprise applications**, internal dashboards, and SPAs (Single Page Applications).  

---

## Types of Blazor

1. **Blazor WebAssembly (WASM)**
   - Runs entirely in the **browser** using WebAssembly.  
   - No server dependency for UI rendering.  
   - Supports **offline and client-heavy applications**.  

2. **Blazor Server**
   - Runs on the **server**, sending UI updates to the browser via **SignalR**.  
   - Smaller payloads and faster initial load.  
   - Ideal for **enterprise apps** that require server-side control and security.  

3. **Blazor Hybrid (MAUI)**
   - Uses **.NET MAUI** to embed Blazor components in **desktop or mobile apps**.  
   - Combines web UI with **native device capabilities**.  

---

## Key Features of Blazor

- **Component-based architecture**: Build reusable UI components.  
- **Two-way data binding**: Synchronize UI and model seamlessly.  
- **Routing**: Built-in navigation for SPAs.  
- **Dependency Injection (DI)**: Use the same DI patterns as in .NET backend.  
- **Event handling**: Capture UI events using C# methods.  
- **Interop with JavaScript**: Call JS functions when needed.  
- **Full debugging support**: Debug both server and client code in Visual Studio or VS Code.  
- **Works with modern .NET**: Compatible with .NET 6/7/8 LTS.  

---

## Common Use Cases

- Internal **enterprise dashboards** and portals.  
- **Single Page Applications (SPAs)** with C# logic.  
- **Forms-heavy apps** with real-time updates.  
- **Hybrid apps** using Blazor components in desktop or mobile applications.  

---

## Example: Simple Blazor Component

```razor
@page "/counter"

<h3>Counter</h3>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```