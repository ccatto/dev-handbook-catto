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

### Angular API Consumption Flow
```mermaid
flowchart TD
    A[Component (UI)] -->|calls| B[Angular Service]
    B -->|REST: HttpClient / GraphQL: Apollo| C[API Request]
    C -->|Response JSON / GraphQL Data| D[Service Processing]
    D -->|Observable/Stream| A

```
> 🔑 **Explanation:**

- Component triggers data fetch.
- Service wraps HttpClient (REST) or Apollo client (GraphQL).
- API request goes to backend.
- Response is transformed/returned.
- Component subscribes and updates UI.


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

# More Angular REST vs GraphQL Consumption and Dependency Injection

## 1. Consuming a REST API in Angular

For REST, it’s typical to have a **services folder** under `src/app/` where you keep Angular services that wrap `HttpClient`.

### Example Folder Structure (REST)
```
src/app/
 ├── services/
 │    └── user.service.ts
 ├── models/
 │    └── user.model.ts
 └── components/
      └── user-list/
          └── user-list.component.ts
```

### Example: `user.service.ts` (REST)
```ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'https://api.example.com/users';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  getUser(id: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }
}
```

### Example: Using it in a Component
```ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-list',
  template: `
    <div *ngFor="let user of users">{{ user.name }}</div>
  `
})
export class UserListComponent implements OnInit {
  users: User[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getUsers().subscribe(data => this.users = data);
  }
}
```

---

## 2. Consuming a GraphQL API in Angular

When using **GraphQL**, Angular projects usually add **Apollo Angular** (`@apollo/client` and `apollo-angular`).

The convention is:
- Keep a **graphql folder** for queries & mutations (`.graphql` or `.ts` files).
- Keep services that inject Apollo client and call those queries.
- Still often have `models/` for typed responses.

### Example Folder Structure (GraphQL)
```
src/app/
 ├── graphql/
 │    ├── user.queries.ts
 │    └── user.mutations.ts
 ├── services/
 │    └── user.service.ts
 ├── models/
 │    └── user.model.ts
 └── components/
      └── user-list/
          └── user-list.component.ts
```

### Example: `user.queries.ts`
```ts
import { gql } from 'apollo-angular';

export const GET_USERS = gql`
  query {
    users {
      id
      name
      email
    }
  }
`;

export const GET_USER = gql`
  query($id: ID!) {
    user(id: $id) {
      id
      name
      email
    }
  }
`;
```

### Example: `user.service.ts` (GraphQL)
```ts
import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { GET_USERS, GET_USER } from '../graphql/user.queries';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private apollo: Apollo) {}

  getUsers(): Observable<any[]> {
    return this.apollo.watchQuery<any>({
      query: GET_USERS
    }).valueChanges.pipe(map(result => result.data.users));
  }

  getUser(id: string): Observable<any> {
    return this.apollo.watchQuery<any>({
      query: GET_USER,
      variables: { id }
    }).valueChanges.pipe(map(result => result.data.user));
  }
}
```

### Example: Component Usage
```ts
import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user-list',
  template: `
    <div *ngFor="let user of users">{{ user.name }} - {{ user.email }}</div>
  `
})
export class UserListComponent implements OnInit {
  users: any[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getUsers().subscribe(data => this.users = data);
  }
}
```

---

## 🔑 Differences in Files Needed

- **REST**:
  - `services/` → holds API wrapper services
  - `models/` → (optional but common) define response interfaces

- **GraphQL**:
  - `graphql/` → queries & mutations
  - `services/` → wrap Apollo client & import queries
  - `models/` → typed responses (often auto-generated with GraphQL Codegen)

---

# Angular Dependency Injection with `@Injectable`

## 1. `@Injectable()` Decorator
```ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
```
- Marks a class as **available to Angular's Dependency Injection (DI) system**.
- Tells Angular **how to provide (create and share) an instance** of that class when another class asks for it.

---

## 2. `providedIn: 'root'`
- Means Angular will create **a single shared instance** of the service at the **root injector level**.
- In practice → one instance is created for the entire application (singleton service).
- Any component, directive, or other service that needs it can inject it without manually registering it in `AppModule`.

---

## 3. How DI Works

### Example Service
```ts
@Injectable({
  providedIn: 'root'
})
export class UserService {
  getMessage() {
    return 'Hello from UserService!';
  }
}
```

### Example Component Using the Service
```ts
import { Component } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-hello',
  template: `{{ message }}`
})
export class HelloComponent {
  message: string = '';

  // 👇 Angular injects UserService automatically
  constructor(private userService: UserService) {}

  ngOnInit() {
    this.message = this.userService.getMessage();
  }
}
```

- `HelloComponent` **does not create UserService with `new UserService()`**.  
- Instead, Angular sees that the constructor needs a `UserService` and **injects the existing instance** (from the DI container).  

---

## 4. Why This Matters
- Promotes **loose coupling** (components don’t manually construct dependencies).
- Makes **testing easier** (replace real services with mocks).
- Ensures **consistency** (e.g., one shared service managing state across components).

---

# ✅ Summary
- `@Injectable({ providedIn: 'root' })` **registers the class with Angular’s Dependency Injection system**.  
- Anywhere you write `constructor(private xyz: XyzService)`, Angular will **inject the service instance** for you.  
- This is one of the core patterns that makes Angular applications modular, testable, and maintainable.

> In Angular, the best practice for data access is to consume APIs with HttpClient, not to use ORMs directly. ORMs like Prisma belong on the backend. On the frontend, focus on services, models, interceptors, and state management for a clean, scalable architecture.
