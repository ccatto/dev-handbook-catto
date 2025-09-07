# Architecture Patterns

# Architecture & Design Patterns - Developer Handbook

Architecture and design patterns provide **proven solutions** for common software problems, improving **scalability, maintainability, and readability**. They guide developers in structuring systems and components effectively.

---

## Overview

- **Design patterns**: Reusable solutions to common software design problems.  
- **Architectural patterns**: High-level strategies for organizing system structure and behavior.  
- **Benefits**:
  - Promotes **code reuse and flexibility**.  
  - Improves **communication among developers**.  
  - Provides **scalable and maintainable system designs**.  
  - Facilitates **best practices and consistent architecture**.

---

## Popular Patterns

### Atomic Design / UI Architecture
- **Type**: UI / Architectural  
- **Purpose**: Hierarchical approach to building interfaces from fundamental components.  
- **Use Case**: Frontend frameworks like **React, Angular, Vue**.  
- **Key Concept**: Build UI as **Atoms → Molecules → Organisms → Templates → Pages**.

---

### Factory Pattern
- **Type**: Creational  
- **Purpose**: Creates objects **without specifying exact classes**, promoting flexibility and decoupling.  
- **Use Case**: Dynamic object creation where the exact type isn’t known at compile time.  
- **Example (C#)**:
```csharp
public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing Circle");
}

public class Square : IShape
{
    public void Draw() => Console.WriteLine("Drawing Square");
}

public class ShapeFactory
{
    public static IShape GetShape(string shapeType)
    {
        return shapeType.ToLower() switch
        {
            "circle" => new Circle(),
            "square" => new Square(),
            _ => throw new ArgumentException("Invalid shape type")
        };
    }
}

// Usage
var shape = ShapeFactory.GetShape("circle");
shape.Draw();
```

# Key Design Patterns Overview



## Factory Pattern
**Type:** Creational  
**Purpose:** Decouples object creation from usage.  
**Key Benefits:**  
- Supports open/closed principle (easy to extend with new types).  
- Useful in dependency injection and plugin systems.  
**Use Case:** Creating objects without specifying the exact class.

# DI 

### Dependency Injection (DI) Pattern
- **Type**: Creational / Structural  
- **Purpose**: Decouples object creation from usage by **injecting dependencies** rather than creating them internally.  
- **Benefits**:
  - Promotes **loose coupling** between classes and modules.  
  - Improves **testability** by allowing mocking or stubbing dependencies.  
  - Encourages **flexible and maintainable architecture**.  
- **Use Case**: Web APIs, microservices, enterprise applications, or any system where components depend on other services.  

#### Example (C#)
```csharp
// Service interface
public interface IMessageService
{
    void SendMessage(string message);
}

// Concrete implementation
public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

// Consumer class using DI
public class NotificationController
{
    private readonly IMessageService _messageService;

    // Dependency injected via constructor
    public NotificationController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Notify(string message)
    {
        _messageService.SendMessage(message);
    }
}

// Usage with manual DI
var emailService = new EmailService();
var controller = new NotificationController(emailService);
controller.Notify("Hello DI!");

// Usage in ASP.NET Core (automatic DI via built-in container)
// builder.Services.AddTransient<IMessageService, EmailService>();
```

# Key Notes on Dependency Injection (DI)

- **Constructor Injection**: Most common and preferred method.
- **Property Injection**: Dependencies set via public properties.
- **Method Injection**: Dependencies passed as method parameters.
- Often used with **IoC (Inversion of Control)** containers, e.g., ASP.NET Core built-in DI, Autofac, Unity.
- Improves **unit testing**, **mocking**, and **modular design**.
- DI is a foundational pattern in modern software development, especially in **C#**, **.NET Core**, **Java Spring**, and **Node.js** frameworks like **NestJS**.


## Singleton Pattern
**Type:** Creational  
**Purpose:** Ensures a single instance with a global access point.  
**Use Case:** Logging, configuration management, database connections.

## Observer Pattern
**Type:** Behavioral  
**Purpose:** Defines one-to-many dependencies for automatic state notifications.  
**Use Case:** Event-driven UIs, publish-subscribe systems, real-time updates.

## MVP Pattern
**Type:** Architectural  
**Purpose:** Separates UI logic through Model-View-Presenter architecture.  
**Use Case:** Desktop apps, mobile apps, and maintainable UI design.

## Microservices Pattern
- **Type:** Architectural  
- **Purpose:** Decomposes applications into **independent, loosely coupled services**, each responsible for a specific business capability.  
- **Use Case:** Cloud-native applications, scalable backend services, enterprise systems, and modern web APIs.

---

## Key Concepts

1. **Service Independence**
   - Each microservice owns its **domain logic, data, and deployment cycle**.  
   - Services communicate over **APIs or messaging systems** (HTTP/REST, gRPC, Kafka, RabbitMQ).

2. **Decentralized Data Management**
   - Each service can have its **own database or schema**.  
   - Avoids tight coupling to a single database; enables **polyglot persistence**.

3. **Domain-Driven Design (DDD)**
   - Organize services around **business capabilities** or domains.  
   - Encourages bounded contexts to **reduce inter-service dependencies**.

4. **Scalability**
   - Services can **scale independently** based on demand.  
   - Example: A billing service can scale differently than a notification service.

5. **Deployment & CI/CD**
   - Each microservice can be deployed **independently**, supporting continuous delivery.  
   - Containers (Docker) and orchestration (Kubernetes, ECS, Azure AKS) are common.

6. **Fault Isolation**
   - Failures in one service **do not necessarily affect other services**.  
   - Patterns like **circuit breaker** or **bulkhead** improve resilience.

7. **Communication Patterns**
   - **Synchronous:** REST APIs or gRPC calls.  
   - **Asynchronous:** Message queues or event buses for decoupled communication.

---

## Benefits

- **Modularity:** Easier to understand, maintain, and extend.  
- **Independent Scaling:** Allocate resources where needed, reducing cost.  
- **Faster Deployments:** Small teams can own separate services and release independently.  
- **Resilience:** Failures are isolated, and the system can continue functioning.  
- **Technology Diversity:** Different services can use **different languages or frameworks** suited to the task.

---

## Challenges / Considerations

- **Complexity:** Multiple services introduce **networking, deployment, and monitoring challenges**.  
- **Data Consistency:** Managing **transactions across services** requires patterns like **sagas**.  
- **Observability:** Logging, monitoring, and tracing across services are critical.  
- **Testing:** Integration testing requires **multiple service environments**.  
- **Latency & Communication Overhead:** Remote calls may introduce delays.

---

## Example

Imagine an **e-commerce system** broken into microservices:



## Layered Architecture (N-Tier)
**Type:** Architectural  
**Purpose:** Organizes code into layers for separation of concerns (Presentation → Business → Data Access).  
**Use Case:** Enterprise applications, maintainable backend APIs.

## Client-Server Pattern
**Type:** Architectural  
**Purpose:** Divides systems into clients requesting services and servers providing them.  
**Use Case:** Web applications, mobile apps connecting to APIs.

## Event-Driven Architecture
**Type:** Architectural  
**Purpose:** Enables asynchronous communication through events and messaging.  
**Use Case:** Microservices, IoT systems, real-time notifications, serverless workflows.

## Additional Common Patterns
- **Decorator Pattern (Structural):** Dynamically add behavior to objects without modifying their code.  
- **Adapter Pattern (Structural):** Allows incompatible interfaces to work together.  
- **Strategy Pattern (Behavioral):** Defines interchangeable algorithms or behaviors.  
- **Repository Pattern (Architectural):** Encapsulates data access, promoting decoupling between business logic and database.  
- **CQRS (Command Query Responsibility Segregation):** Separates read and write operations for scalability.