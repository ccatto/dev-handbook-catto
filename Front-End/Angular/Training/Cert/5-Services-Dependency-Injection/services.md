# Characteristics of Services

# 🛠️ Angular Services Characteristics Guide

> 🚀 **Angular services are singleton objects that share data and logic across different components in an Angular application. By encapsulating specific functionalities, they promote modularity, reusability, and maintainability of code.**

## 🎯 Basics of Angular Services

### 🧩 What is an Angular Service?

An **Angular service** is a class that encapsulates business logic, data access, or utility functions that can be shared across multiple components. Services help organize code by separating concerns and promoting the **Single Responsibility Principle**.

### 📦 Creating a Basic Service

```typescript
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'  // Makes service available app-wide
})
export class UserService {
  private users: User[] = [
    { id: 1, name: 'Alice Johnson', email: 'alice@example.com' },
    { id: 2, name: 'Bob Smith', email: 'bob@example.com' }
  ];
  
  // Business logic methods
  getUsers(): User[] {
    return [...this.users]; // Return copy to prevent mutation
  }
  
  getUserById(id: number): User | undefined {
    return this.users.find(user => user.id === id);
  }
  
  addUser(user: User): void {
    const newUser = { ...user, id: this.generateId() };
    this.users.push(newUser);
  }
  
  private generateId(): number {
    return Math.max(...this.users.map(u => u.id), 0) + 1;
  }
}
```

### 🎯 Key Characteristics of Services

#### ✅ **Encapsulation**
```typescript
@Injectable({ providedIn: 'root' })
export class AuthService {
  private _isAuthenticated = false;
  private _currentUser: User | null = null;
  
  // Public API
  get isAuthenticated(): boolean {
    return this._isAuthenticated;
  }
  
  get currentUser(): User | null {
    return this._currentUser;
  }
  
  // Business logic encapsulated
  login(credentials: LoginCredentials): Observable<User> {
    return this.http.post<User>('/api/login', credentials)
      .pipe(
        tap(user => {
          this._currentUser = user;
          this._isAuthenticated = true;
          this.saveTokenToStorage(user.token);
        })
      );
  }
  
  private saveTokenToStorage(token: string): void {
    // Private implementation details
    localStorage.setItem('auth_token', token);
  }
}
```

#### 🔄 **Reusability**
```typescript
// Same service used across multiple components
@Component({
  selector: 'app-user-list',
  template: `
    <div *ngFor="let user of users">
      {{ user.name }} - {{ user.email }}
    </div>
  `
})
export class UserListComponent {
  users = this.userService.getUsers();
  
  constructor(private userService: UserService) {}
}

@Component({
  selector: 'app-user-profile',
  template: `
    <div *ngIf="user">
      <h2>{{ user.name }}</h2>
      <p>{{ user.email }}</p>
    </div>
  `
})
export class UserProfileComponent {
  user?: User;
  
  constructor(
    private userService: UserService,
    private route: ActivatedRoute
  ) {
    const userId = +this.route.snapshot.paramMap.get('id')!;
    this.user = this.userService.getUserById(userId);
  }
}
```

#### 🌐 **Cross-Component Communication**
```typescript
@Injectable({ providedIn: 'root' })
export class NotificationService {
  private notificationSubject = new Subject<Notification>();
  
  // Observable for components to subscribe
  notifications$ = this.notificationSubject.asObservable();
  
  // Method for components to send notifications
  showNotification(message: string, type: 'success' | 'error' | 'info' = 'info'): void {
    this.notificationSubject.next({ message, type, timestamp: new Date() });
  }
  
  // Clear notifications
  clearNotifications(): void {
    this.notificationSubject.next(null);
  }
}

// Usage in components
@Component({
  selector: 'app-some-component'
})
export class SomeComponent {
  constructor(private notificationService: NotificationService) {}
  
  saveData(): void {
    // ... save logic
    this.notificationService.showNotification('Data saved successfully!', 'success');
  }
}

@Component({
  selector: 'app-notification-display'
})
export class NotificationDisplayComponent {
  notifications$ = this.notificationService.notifications$;
  
  constructor(private notificationService: NotificationService) {}
}
```

---

## 🎯 Services are Singletons

### 🔄 Understanding Singleton Pattern

When a service is provided with `providedIn: 'root'`, Angular creates **only one instance** of that service for the entire application. This single instance is shared across all components that inject it.

### 🏠 **Root-Level Singleton**
```typescript
// Single instance across entire app
@Injectable({
  providedIn: 'root'
})
export class CounterService {
  private count = 0;
  
  increment(): void {
    this.count++;
    console.log(`Count is now: ${this.count}`);
  }
  
  getCount(): number {
    return this.count;
  }
}

// Component A
@Component({
  selector: 'app-counter-a',
  template: `
    <p>Counter A: {{ count }}</p>
    <button (click)="increment()">Increment</button>
  `
})
export class CounterAComponent {
  get count() { return this.counterService.getCount(); }
  
  constructor(private counterService: CounterService) {}
  
  increment(): void {
    this.counterService.increment(); // Affects global count
  }
}

// Component B
@Component({
  selector: 'app-counter-b',
  template: `
    <p>Counter B: {{ count }}</p>
    <button (click)="increment()">Increment</button>
  `
})
export class CounterBComponent {
  get count() { return this.counterService.getCount(); }
  
  constructor(private counterService: CounterService) {}
  
  increment(): void {
    this.counterService.increment(); // Same instance, same count!
  }
}
```

### 🔍 **Demonstrating Singleton Behavior**
```typescript
@Injectable({ providedIn: 'root' })
export class SingletonDemoService {
  private instanceId = Math.random().toString(36).substr(2, 9);
  private creationTime = new Date();
  
  getInstanceInfo(): string {
    return `Instance ID: ${this.instanceId}, Created: ${this.creationTime.toISOString()}`;
  }
}

// Every component will get the same instance info
@Component({
  selector: 'app-demo',
  template: `<p>{{ instanceInfo }}</p>`
})
export class DemoComponent {
  instanceInfo = this.singletonService.getInstanceInfo();
  
  constructor(private singletonService: SingletonDemoService) {}
}
```

### 🧩 **Component-Level Instances (Non-Singleton)**
```typescript
// Each component gets its own instance
@Component({
  selector: 'app-local-counter',
  template: `
    <p>Local Counter: {{ count }}</p>
    <button (click)="increment()">Increment</button>
  `,
  providers: [CounterService] // New instance per component!
})
export class LocalCounterComponent {
  get count() { return this.counterService.getCount(); }
  
  constructor(private counterService: CounterService) {}
  
  increment(): void {
    this.counterService.increment(); // Only affects this component's instance
  }
}
```

### 🏢 **Module-Level Singletons**
```typescript
// Singleton within the module scope
@NgModule({
  providers: [
    FeatureService  // Singleton within this module
  ]
})
export class FeatureModule {
  constructor(
    @Optional() @SkipSelf() parentModule: FeatureModule
  ) {
    // Prevent multiple instances in lazy-loaded modules
    if (parentModule) {
      throw new Error('FeatureModule is already loaded. Import only once.');
    }
  }
}
```

---

## ♻️ Lifecycle of Angular Services

### 🚀 **Service Creation and Initialization**

```typescript
@Injectable({ providedIn: 'root' })
export class LifecycleService {
  private startupTime = new Date();
  private initializationComplete = false;
  
  constructor(
    private http: HttpClient,
    private logger: LoggerService
  ) {
    this.logger.log('LifecycleService constructor called');
    this.initialize();
  }
  
  private async initialize(): Promise<void> {
    this.logger.log('Service initialization starting...');
    
    try {
      // Async initialization logic
      await this.loadConfiguration();
      await this.validateEnvironment();
      
      this.initializationComplete = true;
      this.logger.log('Service initialization completed');
    } catch (error) {
      this.logger.error('Service initialization failed', error);
    }
  }
  
  private loadConfiguration(): Promise<void> {
    // Simulate async configuration loading
    return new Promise(resolve => setTimeout(resolve, 100));
  }
  
  private validateEnvironment(): Promise<void> {
    // Environment validation logic
    return Promise.resolve();
  }
  
  isReady(): boolean {
    return this.initializationComplete;
  }
  
  getUptime(): number {
    return Date.now() - this.startupTime.getTime();
  }
}
```

### 🔄 **Service Lifecycle Phases**

#### 1️⃣ **Lazy Creation**
```typescript
// Service is created when first injected
@Injectable({ providedIn: 'root' })
export class LazyService {
  constructor() {
    console.log('LazyService created!'); // Only logs when first used
  }
}

@Component({
  template: `<button (click)="useLazyService()">Use Service</button>`
})
export class TestComponent {
  constructor() {
    // LazyService not created yet
    console.log('Component created');
  }
  
  useLazyService(): void {
    // NOW LazyService gets created
    const lazyService = inject(LazyService);
    console.log('Service injected');
  }
}
```

#### 2️⃣ **Active Phase**
```typescript
@Injectable({ providedIn: 'root' })
export class ActiveService {
  private subscriptions: Subscription[] = [];
  
  constructor() {
    // Set up long-running operations
    this.setupPeriodicTasks();
    this.subscribeToGlobalEvents();
  }
  
  private setupPeriodicTasks(): void {
    const periodicTask = interval(30000).subscribe(() => {
      this.performMaintenanceTask();
    });
    
    this.subscriptions.push(periodicTask);
  }
  
  private subscribeToGlobalEvents(): void {
    const globalEvents = fromEvent(window, 'beforeunload').subscribe(() => {
      this.cleanup();
    });
    
    this.subscriptions.push(globalEvents);
  }
  
  private performMaintenanceTask(): void {
    console.log('Performing maintenance...');
  }
  
  private cleanup(): void {
    this.subscriptions.forEach(sub => sub.unsubscribe());
    console.log('Service cleanup completed');
  }
}
```

#### 3️⃣ **Memory Management**
```typescript
@Injectable({ providedIn: 'root' })
export class ManagedService implements OnDestroy {
  private cache = new Map<string, any>();
  private timers: number[] = [];
  
  constructor() {
    // Setup cleanup for memory leaks
    this.setupMemoryManagement();
  }
  
  private setupMemoryManagement(): void {
    // Periodic cache cleanup
    const cleanupTimer = window.setInterval(() => {
      this.cleanupExpiredCache();
    }, 60000);
    
    this.timers.push(cleanupTimer);
  }
  
  private cleanupExpiredCache(): void {
    const now = Date.now();
    const expiredKeys: string[] = [];
    
    this.cache.forEach((value, key) => {
      if (value.expiry && value.expiry < now) {
        expiredKeys.push(key);
      }
    });
    
    expiredKeys.forEach(key => this.cache.delete(key));
    console.log(`Cleaned up ${expiredKeys.length} expired cache entries`);
  }
  
  ngOnDestroy(): void {
    // Cleanup when service is destroyed (rare for root services)
    this.timers.forEach(timer => clearInterval(timer));
    this.cache.clear();
    console.log('ManagedService destroyed and cleaned up');
  }
}
```

### ⏰ **Service Lifecycle in Different Scopes**

```typescript
// Root service - lives for entire app lifetime
@Injectable({ providedIn: 'root' })
export class AppLifetimeService {
  constructor() {
    console.log('App service created - will live until app closes');
  }
}

// Module service - lives for module lifetime
@Injectable()
export class ModuleLifetimeService {
  constructor() {
    console.log('Module service created - lives until module destroyed');
  }
}

// Component service - lives for component lifetime
@Component({
  providers: [ComponentLifetimeService]
})
export class MyComponent implements OnDestroy {
  constructor(private componentService: ComponentLifetimeService) {
    console.log('Component service created - will die with component');
  }
  
  ngOnDestroy(): void {
    console.log('Component destroyed - service instance also destroyed');
  }
}

@Injectable()
export class ComponentLifetimeService implements OnDestroy {
  ngOnDestroy(): void {
    console.log('Component-level service destroyed');
  }
}
```

---

## 💾 Using Services to Cache Data: An Example

### 🗄️ **Basic Caching Service**

```typescript
interface CacheItem<T> {
  data: T;
  timestamp: number;
  expiry?: number;
}

@Injectable({ providedIn: 'root' })
export class CacheService {
  private cache = new Map<string, CacheItem<any>>();
  private readonly DEFAULT_TTL = 5 * 60 * 1000; // 5 minutes
  
  set<T>(key: string, data: T, ttl?: number): void {
    const expiry = ttl ? Date.now() + ttl : Date.now() + this.DEFAULT_TTL;
    
    this.cache.set(key, {
      data,
      timestamp: Date.now(),
      expiry
    });
  }
  
  get<T>(key: string): T | null {
    const item = this.cache.get(key);
    
    if (!item) {
      return null;
    }
    
    // Check if expired
    if (item.expiry && Date.now() > item.expiry) {
      this.cache.delete(key);
      return null;
    }
    
    return item.data as T;
  }
  
  has(key: string): boolean {
    return this.get(key) !== null;
  }
  
  clear(): void {
    this.cache.clear();
  }
  
  clearExpired(): void {
    const now = Date.now();
    const expiredKeys: string[] = [];
    
    this.cache.forEach((value, key) => {
      if (value.expiry && value.expiry < now) {
        expiredKeys.push(key);
      }
    });
    
    expiredKeys.forEach(key => this.cache.delete(key));
  }
  
  getCacheStats(): { size: number, keys: string[] } {
    return {
      size: this.cache.size,
      keys: Array.from(this.cache.keys())
    };
  }
}
```

### 📊 **Data Service with Caching**

```typescript
export interface User {
  id: number;
  name: string;
  email: string;
  avatar?: string;
}

@Injectable({ providedIn: 'root' })
export class UserDataService {
  private readonly CACHE_KEYS = {
    ALL_USERS: 'users_all',
    USER_BY_ID: (id: number) => `user_${id}`,
    USER_PROFILE: (id: number) => `profile_${id}`
  };
  
  constructor(
    private http: HttpClient,
    private cacheService: CacheService,
    private logger: LoggerService
  ) {}
  
  // Get all users with caching
  getUsers(): Observable<User[]> {
    const cacheKey = this.CACHE_KEYS.ALL_USERS;
    const cachedUsers = this.cacheService.get<User[]>(cacheKey);
    
    if (cachedUsers) {
      this.logger.log('Returning users from cache');
      return of(cachedUsers);
    }
    
    this.logger.log('Fetching users from API');
    return this.http.get<User[]>('/api/users').pipe(
      tap(users => {
        this.cacheService.set(cacheKey, users, 10 * 60 * 1000); // 10 minutes
        this.logger.log(`Cached ${users.length} users`);
        
        // Also cache individual users
        users.forEach(user => {
          this.cacheService.set(this.CACHE_KEYS.USER_BY_ID(user.id), user);
        });
      }),
      catchError(error => {
        this.logger.error('Failed to fetch users', error);
        return throwError(() => error);
      })
    );
  }
  
  // Get single user with caching
  getUser(id: number): Observable<User> {
    const cacheKey = this.CACHE_KEYS.USER_BY_ID(id);
    const cachedUser = this.cacheService.get<User>(cacheKey);
    
    if (cachedUser) {
      this.logger.log(`Returning user ${id} from cache`);
      return of(cachedUser);
    }
    
    this.logger.log(`Fetching user ${id} from API`);
    return this.http.get<User>(`/api/users/${id}`).pipe(
      tap(user => {
        this.cacheService.set(cacheKey, user);
        this.logger.log(`Cached user ${id}`);
      })
    );
  }
  
  // Update user and invalidate cache
  updateUser(user: User): Observable<User> {
    return this.http.put<User>(`/api/users/${user.id}`, user).pipe(
      tap(updatedUser => {
        // Update cache with new data
        this.cacheService.set(this.CACHE_KEYS.USER_BY_ID(user.id), updatedUser);
        
        // Invalidate related caches
        this.invalidateUserCaches();
        
        this.logger.log(`Updated and cached user ${user.id}`);
      })
    );
  }
  
  // Delete user and invalidate cache
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`/api/users/${id}`).pipe(
      tap(() => {
        // Remove from cache
        this.cacheService.get(this.CACHE_KEYS.USER_BY_ID(id));
        this.invalidateUserCaches();
        
        this.logger.log(`Deleted user ${id} from cache`);
      })
    );
  }
  
  private invalidateUserCaches(): void {
    // Clear related caches when users are modified
    const cacheKey = this.CACHE_KEYS.ALL_USERS;
    this.cacheService.get(cacheKey); // Remove all users cache
  }
  
  // Manual cache refresh
  refreshUsersCache(): Observable<User[]> {
    this.invalidateUserCaches();
    return this.getUsers();
  }
  
  // Get cache statistics
  getCacheInfo(): any {
    return this.cacheService.getCacheStats();
  }
}
```

### 🔄 **Advanced Caching with RxJS**

```typescript
@Injectable({ providedIn: 'root' })
export class SmartCacheService {
  private cache$ = new BehaviorSubject(new Map<string, any>());
  private readonly CACHE_TTL = 5 * 60 * 1000; // 5 minutes
  
  constructor() {
    // Auto-cleanup expired entries
    interval(60000).subscribe(() => {
      this.cleanupExpired();
    });
  }
  
  // Get or fetch data with automatic caching
  getOrFetch<T>(
    key: string, 
    fetchFn: () => Observable<T>,
    ttl: number = this.CACHE_TTL
  ): Observable<T> {
    const cached = this.getCachedValue<T>(key);
    
    if (cached) {
      return of(cached);
    }
    
    return fetchFn().pipe(
      tap(data => this.setCachedValue(key, data, ttl)),
      shareReplay(1)
    );
  }
  
  private getCachedValue<T>(key: string): T | null {
    const currentCache = this.cache$.value;
    const item = currentCache.get(key);
    
    if (!item || (item.expiry && Date.now() > item.expiry)) {
      return null;
    }
    
    return item.data;
  }
  
  private setCachedValue<T>(key: string, data: T, ttl: number): void {
    const currentCache = new Map(this.cache$.value);
    currentCache.set(key, {
      data,
      expiry: Date.now() + ttl,
      timestamp: Date.now()
    });
    this.cache$.next(currentCache);
  }
  
  private cleanupExpired(): void {
    const currentCache = new Map(this.cache$.value);
    const now = Date.now();
    let cleaned = 0;
    
    currentCache.forEach((value, key) => {
      if (value.expiry && value.expiry < now) {
        currentCache.delete(key);
        cleaned++;
      }
    });
    
    if (cleaned > 0) {
      this.cache$.next(currentCache);
      console.log(`Cleaned up ${cleaned} expired cache entries`);
    }
  }
  
  // Observable of cache state
  getCacheState$(): Observable<Map<string, any>> {
    return this.cache$.asObservable();
  }
  
  clearCache(): void {
    this.cache$.next(new Map());
  }
}
```

### 🎯 **Using the Caching Service in Components**

```typescript
@Component({
  selector: 'app-user-dashboard',
  template: `
    <div class="dashboard">
      <div class="cache-stats">
        <h3>Cache Stats</h3>
        <p>Cached items: {{ cacheInfo.size }}</p>
        <button (click)="clearCache()">Clear Cache</button>
      </div>
      
      <div class="user-list">
        <h3>Users</h3>
        <button (click)="refreshUsers()" [disabled]="loading">
          {{ loading ? 'Loading...' : 'Refresh' }}
        </button>
        
        <div *ngFor="let user of users$ | async">
          <p>{{ user.name }} - {{ user.email }}</p>
        </div>
      </div>
    </div>
  `
})
export class UserDashboardComponent implements OnInit {
  users$ = new Observable<User[]>();
  loading = false;
  cacheInfo = { size: 0, keys: [] };
  
  constructor(private userDataService: UserDataService) {}
  
  ngOnInit(): void {
    this.loadUsers();
    this.updateCacheInfo();
  }
  
  loadUsers(): void {
    this.users$ = this.userDataService.getUsers();
  }
  
  refreshUsers(): void {
    this.loading = true;
    this.userDataService.refreshUsersCache().subscribe({
      next: () => {
        this.loadUsers();
        this.updateCacheInfo();
        this.loading = false;
      },
      error: (error) => {
        console.error('Failed to refresh users:', error);
        this.loading = false;
      }
    });
  }
  
  clearCache(): void {
    // Clear specific cache or implement global clear
    this.updateCacheInfo();
  }
  
  private updateCacheInfo(): void {
    this.cacheInfo = this.userDataService.getCacheInfo();
  }
}
```

## 💡 Pro Tips & Anti-Patterns

### 💡 **Pro Tip: When Services Become Anti-Patterns**

> **Services are great but using too many of them can become an anti-pattern over time. Sometimes, a simple function can do the work of a service.**

#### ❌ **Over-Engineering with Services**
```typescript
// ❌ Unnecessary service for simple utility
@Injectable({ providedIn: 'root' })
export class StringUtilService {
  capitalize(str: string): string {
    return str.charAt(0).toUpperCase() + str.slice(1);
  }
  
  truncate(str: string, length: number): string {
    return str.length > length ? str.substring(0, length) + '...' : str;
  }
}

// ✅ Simple utility functions instead
export function capitalize(str: string): string {
  return str.charAt(0).toUpperCase() + str.slice(1);
}

export function truncate(str: string, length: number): string {
  return str.length > length ? str.substring(0, length) + '...' : str;
}

// Usage in component
@Component({
  template: `<p>{{ capitalize(userName) }}</p>`
})
export class MyComponent {
  userName = 'john doe';
  
  capitalize = capitalize; // Make function available in template
}
```

#### ✅ **When to Use Services vs Functions**

| Use **Service** when: | Use **Function** when: |
|----------------------|------------------------|
| 🔄 Sharing state across components | 🛠️ Pure utility operations |
| 💾 Managing complex data operations | 📐 Mathematical calculations |
| 🌐 HTTP requests and caching | 🔤 String/array transformations |
| 🔔 Event communication between components | 🎯 Simple formatting logic |
| 💉 Dependency injection needed | ⚡ Stateless operations |

#### 🎯 **Best Practice Examples**

```typescript
// ✅ Good use of service - manages state and HTTP
@Injectable({ providedIn: 'root' })
export class ShoppingCartService {
  private items$ = new BehaviorSubject<CartItem[]>([]);
  
  addItem(item: CartItem): void { /* ... */ }
  removeItem(id: string): void { /* ... */ }
  checkout(): Observable<Order> { /* ... */ }
}

// ✅ Good use of functions - stateless utilities
export const DateUtils = {
  formatDate: (date: Date) => date.toLocaleDateString(),
  isWeekend: (date: Date) => date.getDay() === 0 || date.getDay() === 6,
  addDays: (date: Date, days: number) => new Date(date.getTime() + days * 24 * 60 * 60 * 1000)
};

// ✅ Hybrid approach - service for state, functions for utilities
@Injectable({ providedIn: 'root' })
export class TaskService {
  private tasks$ = new BehaviorSubject<Task[]>([]);
  
  getTasks(): Observable<Task[]> { return this.tasks$; }
  
  addTask(task: Omit<Task, 'id'>): void {
    const newTask: Task = {
      ...task,
      id: generateId(), // Utility function
      createdAt: new Date()
    };
    this.tasks$.next([...this.tasks$.value, newTask]);
  }
}

// Simple utility function - no service needed
function generateId(): string {
  return Math.random().toString(36).substring(2, 15);
}
```

### 🚨 **Common Service Anti-Patterns to Avoid**

#### 1️⃣ **God Services**
```typescript
// ❌ Service doing too much
@Injectable({ providedIn: 'root' })
export class EverythingService {
  // Authentication
  login(credentials: any) { /* ... */ }
  
  // Data fetching
  getUsers() { /* ... */ }
  getPosts() { /* ... */ }
  
  // UI state
  showModal() { /* ... */ }
  
  // Utilities
  formatDate(date: Date) { /* ... */ }
  
  // Business logic
  calculateTax() { /* ... */ }
}

// ✅ Split into focused services
@Injectable({ providedIn: 'root' })
export class AuthService { /* ... */ }

@Injectable({ providedIn: 'root' })
export class UserService { /* ... */ }

@Injectable({ providedIn: 'root' })
export class UIStateService { /* ... */ }
```

#### 2️⃣ **Stateless Services**
```typescript
// ❌ Service with no state - just use functions
@Injectable({ providedIn: 'root' })
export class MathService {
  add(a: number, b: number): number {
    return a + b;
  }
  
  multiply(a: number, b: number): number {
    return a * b;
  }
}

// ✅ Simple functions
export const MathUtils = {
  add: (a: number, b: number) => a + b,
  multiply: (a: number, b: number) => a * b
};
```

Remember: **Services are powerful tools for managing state and shared logic, but don't overuse them. Sometimes a simple function is all you need!** 🎯

