# Angular Services and Dependency Injection Quiz - Chapter 5 💉

Test your knowledge of Angular services and dependency injection! 🛠️✨

## Question 1 🏷️
**In Angular, which of the following decorators is used to register a class as a service?**

- `@Service`
- `@NgService`
- `@Injectable`
- `@Inject`

---

## Question 2 🔍
**Can the following class be injected into a component as-is?**

```javascript
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

- Yes
- No, it has to be added to an array of providers first
- No, that code does not compile
- No, it does not have the @Service decorator

---

## Question 3 🔢
**According to the following code, how many instances of TokenService can we have in an Angular application?**
*(assuming there's no other dependency injection configuration anywhere else for that service)*

```javascript
@Injectable({
  providedIn: 'root'
})
export class TokenService {
  // ... (rest of the class implementation)
}
```

- It could be any number of instances
- One per module
- Zero or one
- One

---

## Question 4 💡
**One of the following syntaxes is correct for injecting a `LoginService` in `LoginComponent`. Which one is it?**

**Option A:**
```javascript
@Injectable()
loginService: LoginService;
```

**Option B:**
```javascript
myService = inject(LoginService);
```

**Option C:**
```javascript
loginservice = create(LoginService)
```

**Option D:**
```javascript
loginService = constructor(loginService: LoginService);
```

---

## Answer Key 🔑

**Q1 Answer: `@Injectable`** ✅  
**Because:** `@Injectable()` is the correct decorator to make a class available for dependency injection in Angular. `@Service`, `@NgService`, and `@Inject` are not valid Angular decorators. `@Inject` is used for injection tokens, not for marking classes as injectable.

**Q2 Answer: No, it has to be added to an array of providers first** ⚠️  
**Because:** While the `@Injectable()` decorator makes the class injectable, it needs to be registered as a provider to be available for injection. Without `providedIn: 'root'` or being added to a providers array, Angular won't know how to create instances of this service.

**Q3 Answer: One** 🎯  
**Because:** `providedIn: 'root'` creates a singleton service at the application level. Angular's dependency injection system ensures only one instance exists throughout the entire application lifetime. This is the most common and recommended pattern for services.

**Q4 Answer: `myService = inject(LoginService);`** 💉  
**Because:** The `inject()` function is Angular's modern way to inject dependencies, especially useful in standalone components or when not using constructor injection. The other options are incorrect: `@Injectable()` is for marking services, `create()` doesn't exist, and the constructor syntax is malformed.

---

**Key Concepts:** 💡
- **@Injectable Decorator:** Required to make classes available for dependency injection
- **Provider Registration:** Services must be registered either via `providedIn` or providers arrays
- **Singleton Pattern:** `providedIn: 'root'` creates application-wide singletons
- **Modern Injection:** `inject()` function provides an alternative to constructor injection
- **Service Lifecycle:** Understanding when and how many instances are created