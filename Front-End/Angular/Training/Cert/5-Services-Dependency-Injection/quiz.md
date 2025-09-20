# Quiz section 5 DI & Services

**Question**: In Angular, which of the following decorators is used to register a class as a service?

- **@Inject** ❌ - Incorrect, `@Inject` is used to specify dependencies for injection, not to register a class as a service.
- **@NgService** ❌ - Incorrect, `@NgService` is not a valid Angular decorator.
- **@Injectable** ✅ - Correct, `@Injectable` is used to mark a class as a service that can be injected into other components or services.
- **@Service** ❌ - Incorrect, `@Service` is not a valid Angular decorator; it may be confused with other frameworks like NestJS.

**Summary**: The `@Injectable` decorator is used in Angular to register a class as a service.

> 2 

**Question**: Can the following class be injected into a component as-is?

```typescript
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CartService {

    constructor(private http: HttpClient) {}

    getCartContents() {
        // Some code
    }

}
```

### Angular Provider Injection: Correcting Common Misconceptions

| Option | Status | Explanation |
| :--- | :--- | :--- |
| No, it has to be added to an array of providers first | ✅ Correct | While the class is decorated with `@Injectable()`, it must be registered in a module's or component's `providers` array, or configured with `providedIn: 'root'` in the `@Injectable` decorator, to be discoverable by the dependency injection system. |
| Yes | ❌ Incorrect | The class cannot be injected as-is without being registered. The `@Injectable()` decorator alone marks it as a potential injectable, but doesn't automatically make it available to the entire application. |
| No, it does not have the `@Service` decorator | ❌ Incorrect | Angular uses `@Injectable`, not `@Service`. The decorator used in the code (`@Injectable`) is the correct one. |
| No, that code does not compile | ❌ Incorrect | The code is syntactically valid and will compile, assuming all dependencies (like `HttpClient`) are correctly imported and configured in the project. |

---

**Summary:** The `CartService` class, despite having the `@Injectable()` decorator, cannot be injected immediately. It requires being explicitly registered within the dependency injection system, either via a `providers` array or by using the `providedIn: 'root'` option for application-wide availability.

> 3
**Question**: According to the following code, how many instances of `TokenService` can we have in an Angular application? (assuming there's no other dependency injection configuration anywhere else for that service)

```typescript
@Injectable({
  providedIn: 'root'
})
export class TokenService {
  // ... (rest of the class implementation)
}
```
* One - ❌ Correct, when providedIn: 'root' is specified in @Injectable, Angular creates a single singleton instance of the service shared across the entire application.
* Zero or one ✅  - Incorrect, the service is always provided and instantiated as a singleton; there's no option for zero instances.
* One per module - Incorrect, providedIn: 'root' provides a single instance application-wide, not per module.
* It could be any number of instances ❌ - Incorrect, the root provider ensures exactly one instance, not multiple.

Summary: With providedIn: 'root', the TokenService is provided as a singleton, resulting in exactly one instance throughout the Angular application.

> 4 
**Question**: One of the following syntaxes is correct for injecting a `LoginService` in `LoginComponent`. Which one is it?

- **`loginservice = create(LoginService)`** ❌ - Incorrect, there is no `create` function for dependency injection in Angular.
- **`loginService = constructor(loginService: LoginService);`** ❌ - Incorrect, this is not valid syntax; the `constructor` requires a proper declaration within the class, not an assignment.
- **`myService = inject(LoginService);`** ✅ - Correct, the `inject` function is the proper syntax for injecting a service in Angular (introduced in Angular 14 for functional injection contexts or when using injection outside constructors).
- **`@Injectable() loginService: LoginService;`** ❌ - Incorrect, `@Injectable` is used to mark a service as injectable, not for injecting a service into a component.

**Summary**: The correct syntax for injecting `LoginService` in `LoginComponent` is `myService = inject(LoginService);`.