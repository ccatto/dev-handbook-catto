# 🛡️ Access Control with the Router

Route guards act as sentinels 🗡️, protecting access to specific routes within your Angular application.

In this section, we cover all you need to know about guards (both the legacy syntax and the new function-based, standalone-friendly approach), as well as how to access route parameters from the Angular Router.

## 🔐 What Are Router Guards?

Router guards are functions or classes that Angular calls to determine whether a route can be activated, deactivated, or loaded. They provide a way to control navigation and implement security, authentication, and authorization logic.

### Types of Guards

- **CanActivate** 🚪 - Controls if a route can be activated
- **CanActivateChild** 👶 - Controls if child routes can be activated  
- **CanDeactivate** 🚫 - Controls if a user can leave a route
- **CanLoad** 📦 - Controls if a module can be loaded lazily
- **Resolve** 🔍 - Pre-fetches data before route activation

## ⚖️ Legacy vs. New Function-Based Guards (v14+)

### Legacy Class-Based Guards (Pre-v14)

```typescript
// Old way - Class-based guard
@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}
  
  canActivate(): boolean {
    if (this.auth.isLoggedIn()) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}

// Route configuration
{
  path: 'dashboard',
  component: DashboardComponent,
  canActivate: [AuthGuard]
}
```

### ✨ New Function-Based Guards (v14+)

```typescript
// New way - Functional guard
export const authGuard: CanActivateFn = () => {
  const auth = inject(AuthService);
  const router = inject(Router);
  
  if (auth.isLoggedIn()) {
    return true;
  }
  router.navigate(['/login']);
  return false;
};

// Route configuration
{
  path: 'dashboard',
  component: DashboardComponent,
  canActivate: [authGuard]
}
```

### 🎯 Key Differences

| Aspect | Legacy (Class) | New (Function) |
|--------|----------------|----------------|
| **Syntax** | Class with interface | Simple function |
| **Dependencies** | Constructor injection | `inject()` function |
| **Bundle Size** | Larger | Smaller 📉 |
| **Standalone Support** | Limited | Full support ✅ |
| **Testing** | More complex | Easier to test 🧪 |

## 📖 How to Read Route Parameters

Angular provides multiple ways to access route parameters depending on your needs.

### 📍 Using ActivatedRoute

```typescript
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product',
  template: '<h1>Product: {{productId}}</h1>'
})
export class ProductComponent implements OnInit {
  productId: string = '';
  
  constructor(private route: ActivatedRoute) {}
  
  ngOnInit() {
    // Snapshot approach (for static values)
    this.productId = this.route.snapshot.params['id'];
    
    // Observable approach (for dynamic values)
    this.route.params.subscribe(params => {
      this.productId = params['id'];
    });
  }
}
```

### 🔗 Types of Parameters

#### Path Parameters
```typescript
// Route: /product/:id
// URL: /product/123
this.route.params.subscribe(params => {
  const id = params['id']; // "123"
});
```

#### Query Parameters
```typescript
// URL: /product/123?color=red&size=large
this.route.queryParams.subscribe(params => {
  const color = params['color']; // "red"
  const size = params['size'];   // "large"
});
```

#### Route Data
```typescript
// Route configuration
{
  path: 'about',
  component: AboutComponent,
  data: { title: 'About Us', breadcrumb: 'About' }
}

// Component
this.route.data.subscribe(data => {
  console.log(data['title']); // "About Us"
});
```

### 🎯 Modern Approach with Signals (v16+)

```typescript
import { Component, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';

@Component({
  selector: 'app-product',
  template: '<h1>Product: {{productId()}}</h1>'
})
export class ProductComponent {
  private route = inject(ActivatedRoute);
  
  // Convert route params to signal
  productId = toSignal(
    this.route.params.pipe(map(params => params['id'])),
    { initialValue: '' }
  );
}
```

## 🚀 Best Practices

- **Use functional guards** for new projects (v14+) 🆕
- **Combine multiple guards** when needed
- **Handle errors gracefully** in guards
- **Use `inject()`** instead of constructor injection in functional guards
- **Consider using signals** for reactive parameter handling
- **Always unsubscribe** from route observables (or use `async` pipe)

---

*Now you're ready to secure your Angular routes like a pro! 🏆*