# Consuming APIs in Angular

🔹 **Overview**

In Angular applications, data is typically accessed via REST APIs or GraphQL APIs exposed by the backend. Unlike backend services, Angular does not use ORMs (like Prisma, TypeORM, or Sequelize). Instead, Angular uses `HttpClient` to make HTTP requests and handle responses.

🔹 **Common Practices**

- **Use Angular HttpClient**
  - Provided in `@angular/common/http`.
  - Simplifies making GET, POST, PUT, DELETE requests.
  - Returns `Observable<T>` for reactive patterns.

- **Strongly Typed Models**
  - Define TypeScript interfaces or classes for API responses.
  - Ensures type safety across the application.

- **Services for API Calls**
  - Encapsulate API logic in Angular services.
  - Keep components clean and focused on UI.

- **Error Handling & Interceptors**
  - Use `HttpInterceptor` for authentication tokens, logging, or global error handling.

- **State Management (Optional)**
  - Use NgRx, NGXS, or Akita for managing global state and caching API results.

- **Code Generation**
  - Use Swagger/OpenAPI generator for REST.
  - Use GraphQL Code Generator for GraphQL schemas.
  - Reduces manual work and improves type safety.

🔹 **Folder Structure Example**

```graphql
/src/app
│
├─ services
│   ├─ user.service.ts       # Handles user-related API calls
│   └─ auth.service.ts       # Handles authentication API calls
│
├─ models
│   ├─ user.model.ts         # TypeScript interface for User
│   └─ auth.model.ts         # TypeScript interface for Auth responses
│
├─ interceptors
│   └─ auth.interceptor.ts   # Attaches JWT tokens to requests

```
### 🔹 Example: Using HttpClient

```typescript
// user.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  private apiUrl = '/api/users';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }
}
```

Consuming APIs in Angular
🔹 Why This Approach?

- Separation of concerns → Services handle API logic, components handle UI.
- Scalable → Works for small apps and enterprise-level projects.
- Type-safe → TypeScript interfaces ensure consistency.
- Extensible → Can plug into state management libraries or code generation tools.

# REST vs GraphQL in Angular

Both REST and GraphQL are widely used with Angular. The choice depends on the project’s requirements.

| Feature              | REST                                              | GraphQL                                          |
|----------------------|--------------------------------------------------|-------------------------------------------------|
| **Data Fetching**    | Multiple endpoints (e.g., `/users`, `/orders`)    | Single endpoint (`/graphql`)                     |
| **Over/Under Fetching** | Possible: may return too much or too little data | Avoided: request exactly the fields you need     |
| **Typing**           | Often documented with Swagger/OpenAPI            | Strong typing with GraphQL schema               |
| **Caching**          | Handled manually or with interceptors/state management | Built-in tools like Apollo Client provide caching |
| **Tooling**          | Simple, widely supported                         | Rich ecosystem (Apollo, GraphQL Codegen)        |
| **Best Use Cases**   | Simpler APIs, microservices, resource-oriented designs | Complex data with many relationships, flexible queries |

## REST in Angular

- Built-in `HttpClient` makes REST consumption straightforward.
- Use interceptors for auth headers, logging, retry logic.
- Good for simple CRUD operations.

## GraphQL in Angular

- Typically use Apollo Angular (`apollo-angular` package).
- Queries and mutations are defined in `.graphql` files or inline.
- Great for complex UIs that need to pull multiple related entities in one request.
- Works well with GraphQL Code Generator for auto-generated TypeScript types and services.

🔹 Summary
In Angular, the best practice for data access is to consume APIs with HttpClient, not to use ORMs directly. ORMs like Prisma belong on the backend. On the frontend, focus on services, models, interceptors, and state management for a clean, scalable architecture.
