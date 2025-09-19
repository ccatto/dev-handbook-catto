# DI


# 💉 Angular Dependency Injection Complete Guide

> 🚀 **Dependency injection (DI) is one of the fundamental concepts in Angular. DI is wired into the Angular framework and allows classes with Angular decorators, such as Components, Directives, Pipes, and Injectables, to configure dependencies that they need.**

## 🎯 What is Dependency Injection?

**Dependency Injection** is a design pattern where dependencies are provided to a class rather than the class creating them itself. Angular's DI system manages the creation and sharing of service instances throughout your application.

### 🔄 Without DI vs With DI

```typescript
// ❌ Without DI - Tight coupling, hard to test
class UserComponent {
  private userService: UserService;
  
  constructor() {
    this.userService = new UserService(); // Creates dependency directly
  }
}

// ✅ With DI - Loose coupling, easy to test
@Component({
  selector: 'app-user',
  template: `<div>{{ user.name }}</div>`
})
class UserComponent {
  constructor(private userService: UserService) {
    // Angular provides the dependency
  }
}
```

---

## 🔧 How to Provide a Dependencies

### 🏠 **Application-Level Providers (Root)**

#### 📦 **Using @Injectable with providedIn: 'root'**
```typescript
// Most common approach - Creates singleton service
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private users: User[] = [];
  
  getUsers(): User[] {
    return this.users;
  }
  
  addUser(user: User): void {
    this.users.push(user);
  }
}

// Available throughout the entire application
// Single instance shared across all components
```

#### 🌟 **Using bootstrapApplication (Standalone)**
```typescript
// main.ts - For standalone applications
import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { UserService } from './services/user.service';
import { HttpClient } from '@angular/common/http';

bootstrapApplication(AppComponent, {
  providers: [
    UserService,
    // or with custom configuration
    { provide: UserService, useClass: UserService },
    // Import other providers
    importProvidersFrom(HttpClientModule)
  ]
});
```

#### 🏢 **Using Module Providers (Legacy)**
```typescript
// app.module.ts - For module-based applications
@NgModule({
  declarations: [AppComponent],
  providers: [
    UserService,
    DataService,
    // Multiple services
    { provide: API_URL, useValue: 'https://api.example.com' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
```

### 🧩 **Component-Level Providers**

```typescript
// Each component instance gets its own service instance
@Component({
  selector: 'app-user-profile',
  template: `
    <div>{{ user.name }}</div>
    <button (click)="updateUser()">Update</button>
  `,
  providers: [
    UserService,  // New instance for this component
    { provide: ConfigService, useClass: UserConfigService }
  ]
})
export class UserProfileComponent {
  constructor(private userService: UserService) {
    // Gets component-specific instance
  }
}
```

### 🎯 **Feature Module Providers**

```typescript
// Scoped to feature module
@NgModule({
  declarations: [
    ProductListComponent,
    ProductDetailComponent
  ],
  providers: [
    ProductService,  // Available to all components in this module
    { provide: PRODUCT_CONFIG, useValue: { itemsPerPage: 10 } }
  ]
})
export class ProductModule { }
```

### 🔄 **Lazy-Loaded Module Providers**

```typescript
// Creates new injector scope for lazy-loaded module
@NgModule({
  declarations: [AdminComponent],
  providers: [
    AdminService,  // Only available in this lazy-loaded module
    { provide: ADMIN_CONFIG, useFactory: createAdminConfig }
  ]
})
export class AdminModule { }
```

---

## 🎯 How to Inject Dependencies with inject()

### 🆕 **Modern inject() Function (Angular 14+)**

The `inject()` function is the modern way to inject dependencies, especially useful in functional contexts.

#### 🏗️ **Basic Usage in Components**
```typescript
import { Component, inject } from '@angular/core';
import { UserService } from './user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  template: `
    <div *ngFor="let user of users">
      <h3>{{ user.name }}</h3>
      <button (click)="viewProfile(user.id)">View Profile</button>
    </div>
  `
})
export class UserComponent {
  // Modern inject() approach
  private userService = inject(UserService);
  private router = inject(Router);
  
  users = this.userService.getUsers();
  
  viewProfile(userId: number): void {
    this.router.navigate(['/profile', userId]);
  }
}
```

#### 🎨 **In Functional Contexts**

```typescript
// Route guards
export const authGuard = () => {
  const authService = inject(AuthService);
  const router = inject(Router);
  
  if (authService.isAuthenticated()) {
    return true;
  }
  
  router.navigate(['/login']);
  return false;
};

// Route resolvers
export const userResolver = (route: ActivatedRouteSnapshot) => {
  const userService = inject(UserService);
  const userId = route.paramMap.get('id');
  return userService.getUser(+userId);
};

// Interceptors
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService);
  const token = authService.getToken();
  
  if (token) {
    req = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    });
  }
  
  return next(req);
};
```

#### 🏗️ **In Services**
```typescript
@Injectable({
  providedIn: 'root'
})
export class DataService {
  private http = inject(HttpClient);
  private logger = inject(LoggerService);
  
  getData(): Observable<Data[]> {
    this.logger.log('Fetching data...');
    return this.http.get<Data[]>('/api/data');
  }
}
```

#### 🎯 **With Injection Context**
```typescript
export class MyComponent {
  private injector = inject(Injector);
  
  ngOnInit() {
    // Use injector to get services dynamically
    runInInjectionContext(this.injector, () => {
      const userService = inject(UserService);
      const data = userService.getUsers();
    });
  }
  
  // Or create injection context
  loadData() {
    const environmentInjector = inject(EnvironmentInjector);
    
    runInInjectionContext(environmentInjector, () => {
      const dataService = inject(DataService);
      return dataService.loadData();
    });
  }
}
```

#### 🔧 **Optional and Custom Injection**
```typescript
export class ConfigurableComponent {
  // Optional injection - won't throw if not found
  private optionalService = inject(OptionalService, { optional: true });
  
  // Custom injection token
  private apiUrl = inject(API_URL);
  
  // Self injection (from component's own providers)
  private localService = inject(LocalService, { self: true });
  
  // Skip self and look in parent
  private parentService = inject(ParentService, { skipSelf: true });
  
  ngOnInit() {
    if (this.optionalService) {
      this.optionalService.doSomething();
    }
  }
}
```

---

## 🏗️ How to Inject Dependencies Using Constructor

### 🎯 **Traditional Constructor Injection**

Constructor injection is the classic Angular approach and is still widely used.

#### 📦 **Basic Constructor Injection**
```typescript
@Component({
  selector: 'app-product',
  template: `
    <div *ngFor="let product of products">
      <h3>{{ product.name }}</h3>
      <p>{{ product.price | currency }}</p>
    </div>
  `
})
export class ProductComponent implements OnInit {
  products: Product[] = [];
  
  constructor(
    private productService: ProductService,
    private logger: LoggerService,
    private router: Router
  ) {
    // Dependencies injected by Angular
  }
  
  ngOnInit(): void {
    this.logger.log('ProductComponent initialized');
    this.loadProducts();
  }
  
  private loadProducts(): void {
    this.productService.getProducts().subscribe(products => {
      this.products = products;
    });
  }
}
```

#### 🎨 **With Access Modifiers**
```typescript
@Component({
  selector: 'app-user-dashboard',
  template: `
    <h1>Welcome, {{ currentUser?.name }}!</h1>
    <button (click)="logout()">Logout</button>
  `
})
export class UserDashboardComponent {
  currentUser?: User;
  
  constructor(
    private userService: UserService,      // private - internal use only
    protected authService: AuthService,    // protected - available to subclasses
    public themeService: ThemeService      // public - accessible in template
  ) {
    this.currentUser = this.userService.getCurrentUser();
  }
  
  logout(): void {
    this.authService.logout();
  }
}
```

#### 🔧 **Optional and Conditional Injection**
```typescript
import { Optional, Inject, Self, SkipSelf } from '@angular/core';

@Component({
  selector: 'app-configurable',
  template: `<div>{{ message }}</div>`
})
export class ConfigurableComponent {
  message = '';
  
  constructor(
    // Optional injection - service may not exist
    @Optional() private analyticsService?: AnalyticsService,
    
    // Injection token
    @Inject(API_URL) private apiUrl?: string,
    
    // Self - only from this component's providers
    @Self() private localService?: LocalService,
    
    // Skip self - look in parent injectors
    @SkipSelf() private parentConfig?: ParentConfigService,
    
    // Multiple decorators
    @Optional() @Inject(THEME_CONFIG) private themeConfig?: ThemeConfig
  ) {
    if (this.analyticsService) {
      this.analyticsService.track('component-loaded');
    }
    
    this.message = this.apiUrl || 'No API URL configured';
  }
}
```

#### 🎯 **Service Constructor Injection**
```typescript
@Injectable({
  providedIn: 'root'
})
export class OrderService {
  constructor(
    private http: HttpClient,
    private logger: LoggerService,
    private userService: UserService
  ) {}
  
  createOrder(orderData: OrderData): Observable<Order> {
    const user = this.userService.getCurrentUser();
    this.logger.log(`Creating order for user ${user.id}`);
    
    return this.http.post<Order>('/api/orders', {
      ...orderData,
      userId: user.id,
      timestamp: new Date()
    });
  }
}
```

### 🔄 **inject() vs Constructor: When to Use Which?**

| Scenario | inject() ✅ | Constructor ✅ |
|----------|------------|----------------|
| **Functional guards/resolvers** | ✅ Perfect | ❌ Can't use |
| **Conditional injection** | ✅ Clean syntax | ⚠️ More verbose |
| **Inside methods** | ✅ With context | ❌ Constructor only |
| **Class inheritance** | ⚠️ Manual setup | ✅ Automatic |
| **Angular < 14** | ❌ Not available | ✅ Only option |
| **Testing** | ✅ Easy to mock | ✅ Easy to mock |

---

## ⚙️ Provider Configuration Options

### 🏗️ **Basic Provider Types**

#### 🎯 **Class Providers**
```typescript
// Standard class provider
{ provide: UserService, useClass: UserService }

// Alternative implementation
{ provide: UserService, useClass: MockUserService }

// Interface-based provider
{ provide: 'IDataService', useClass: ApiDataService }
```

#### 🔧 **Value Providers**
```typescript
// Configuration values
{ provide: API_URL, useValue: 'https://api.example.com' }

// Feature flags
{ provide: FEATURE_FLAGS, useValue: { newUI: true, beta: false } }

// Complex configuration objects
{ provide: APP_CONFIG, useValue: {
  apiUrl: 'https://api.example.com',
  timeout: 5000,
  retryAttempts: 3,
  features: ['auth', 'analytics']
} }
```

#### 🏭 **Factory Providers**
```typescript
// Simple factory
{ 
  provide: LoggerService, 
  useFactory: () => new LoggerService(console) 
}

// Factory with dependencies
{
  provide: DataService,
  useFactory: (http: HttpClient, config: AppConfig) => {
    return new DataService(http, config.apiUrl);
  },
  deps: [HttpClient, APP_CONFIG]
}

// Conditional factory
{
  provide: StorageService,
  useFactory: (platform: PlatformService) => {
    return platform.isBrowser() 
      ? new LocalStorageService() 
      : new MemoryStorageService();
  },
  deps: [PlatformService]
}
```

#### 🔄 **Existing Providers (Aliases)**
```typescript
// Create alias for existing service
{ provide: 'UserApi', useExisting: UserService }

// Multiple tokens for same service
providers: [
  UserService,
  { provide: 'IUserService', useExisting: UserService },
  { provide: USER_SERVICE_TOKEN, useExisting: UserService }
]
```

### 🎯 **Injection Tokens**

#### 🏷️ **String Tokens (Not Recommended)**
```typescript
// Avoid - can cause collisions
{ provide: 'apiUrl', useValue: 'https://api.example.com' }

@Component({})
export class MyComponent {
  constructor(@Inject('apiUrl') private apiUrl: string) {}
}
```

#### 🎫 **InjectionToken (Recommended)**
```typescript
// Create typed injection tokens
export const API_URL = new InjectionToken<string>('API URL');
export const RETRY_COUNT = new InjectionToken<number>('Retry Count');
export const FEATURE_CONFIG = new InjectionToken<FeatureConfig>('Feature Config');

// Provide values
providers: [
  { provide: API_URL, useValue: 'https://api.example.com' },
  { provide: RETRY_COUNT, useValue: 3 },
  { provide: FEATURE_CONFIG, useValue: { enableBeta: true } }
]

// Inject values
@Component({})
export class ApiComponent {
  constructor(
    @Inject(API_URL) private apiUrl: string,
    @Inject(RETRY_COUNT) private retryCount: number,
    @Inject(FEATURE_CONFIG) private config: FeatureConfig
  ) {}
}
```

#### 🎯 **Token with Default Values**
```typescript
export const THEME_CONFIG = new InjectionToken<ThemeConfig>('Theme Config', {
  providedIn: 'root',
  factory: () => ({ 
    primaryColor: '#007bff',
    darkMode: false,
    animations: true
  })
});

// Usage - gets default if not provided
@Component({})
export class ThemeComponent {
  private config = inject(THEME_CONFIG); // Gets default values
}
```

### 🔧 **Advanced Provider Patterns**

#### 🏭 **Multi Providers**
```typescript
// Multiple values for same token
export const HTTP_INTERCEPTORS = new InjectionToken<HttpInterceptor[]>('HTTP Interceptors');

providers: [
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: LoggingInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true }
]

// All interceptors injected as array
@Injectable()
export class HttpService {
  constructor(@Inject(HTTP_INTERCEPTORS) private interceptors: HttpInterceptor[]) {
    // interceptors is an array of all provided interceptors
  }
}
```

#### 🔄 **Conditional Providers**
```typescript
// Environment-based providers
const providers = [
  // Common providers
  UserService,
  DataService,
  
  // Conditional providers
  environment.production 
    ? { provide: LoggerService, useClass: ProductionLogger }
    : { provide: LoggerService, useClass: DevelopmentLogger },
    
  // Platform-specific
  ...(isPlatformBrowser(platformId) 
    ? [{ provide: StorageService, useClass: BrowserStorageService }]
    : [{ provide: StorageService, useClass: ServerStorageService }])
];
```

#### 🎯 **Provider Hierarchies**
```typescript
// Root level
@Injectable({ providedIn: 'root' })
export class GlobalService { }

// Module level
@NgModule({
  providers: [
    FeatureService  // Available to this module and children
  ]
})
export class FeatureModule { }

// Component level
@Component({
  providers: [
    LocalService  // New instance for this component tree
  ]
})
export class LocalComponent { }
```

### 🧪 **Testing with Providers**

```typescript
describe('UserComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserComponent],
      providers: [
        // Mock services
        { provide: UserService, useClass: MockUserService },
        
        // Spy objects
        { provide: LoggerService, useValue: jasmine.createSpyObj('LoggerService', ['log']) },
        
        // Test values
        { provide: API_URL, useValue: 'http://test-api.com' },
        
        // Factory for complex setup
        {
          provide: DataService,
          useFactory: () => new MockDataService(['test-data']),
        }
      ]
    }).compileComponents();
  });
});
```

## 💡 Pro Tips & Best Practices

### 🚀 **Performance Tips**
- Use `providedIn: 'root'` for singleton services
- Prefer **lazy loading** for feature-specific services
- Use **factory providers** for expensive object creation
- Consider **tree-shaking** with injection tokens

### 🎯 **Best Practices**
```typescript
// ✅ Good - Clear dependencies
@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(
    private http: HttpClient,
    private logger: LoggerService
  ) {}
}

// ❌ Avoid - Circular dependencies
// UserService depends on OrderService
// OrderService depends on UserService
```

### 🔐 **Security Considerations**
```typescript
// ✅ Secure - Validate injected values
@Injectable()
export class ApiService {
  constructor(@Inject(API_URL) private apiUrl: string) {
    if (!apiUrl || !apiUrl.startsWith('https://')) {
      throw new Error('Invalid API URL');
    }
  }
}

// ✅ Type safety with injection tokens
export const SECURE_CONFIG = new InjectionToken<SecureConfig>('Secure Config');
```

### 🧪 **Testing Best Practices**
- **Mock services** at the right level
- Use **TestBed.overrideProvider()** for specific test cases
- Create **test utilities** for common provider setups
- Test both **success and error** scenarios

### 🎨 **Code Organization**
```typescript
// Group related providers
export const USER_PROVIDERS = [
  UserService,
  UserRepository,
  { provide: USER_CONFIG, useValue: defaultUserConfig }
];

// Feature module
@NgModule({
  providers: [...USER_PROVIDERS]
})
export class UserModule { }
```

Remember: DI makes your code **testable, maintainable, and loosely coupled**! 🎯
