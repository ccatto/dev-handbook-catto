# 🔧 Important RxJS Operators

RxJs Operators allow Angular developers to manipulate Observables in various ways, such as filtering, mapping, combining, and error handling. Common operators include `map`, `filter`, `switchMap`, and `catchError`.

By leveraging RxJS operators, developers can write more concise, declarative, and maintainable code for handling complex asynchronous scenarios.

In this lesson, we highlight some of the most important operators to know about.

> **💡 Pro TIP**  
> Websites such as [rxmarbles.com](https://rxmarbles.com) are very helpful for learning more about operators. RxMarbles provides interactive diagrams that show how each operator transforms data streams over time - perfect for visual learners!

## 🎨 Map Operator

The `map` operator transforms each emitted value by applying a function to it. Think of it like `Array.map()` but for Observables.

### 🔍 Basic Usage

```typescript
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

// Transform numbers to their squares
const numbers$ = of(1, 2, 3, 4, 5);
const squares$ = numbers$.pipe(
  map(x => x * x)
);
// Emits: 1, 4, 9, 16, 25

squares$.subscribe(value => console.log(value));
```

### 🌟 Real-World Examples

```typescript
// Transform HTTP response data
@Injectable()
export class UserService {
  constructor(private http: HttpClient) {}
  
  getUsers(): Observable<User[]> {
    return this.http.get<ApiResponse>('/api/users').pipe(
      map(response => response.data), // Extract just the data array
      map(users => users.map(user => ({
        ...user,
        displayName: `${user.firstName} ${user.lastName}`,
        isActive: user.status === 'active'
      })))
    );
  }
}

// Transform form values
@Component({
  template: `
    <input #emailInput (input)="onEmailChange($event)" placeholder="Enter email">
    <div>Domain: {{ emailDomain$ | async }}</div>
  `
})
export class EmailComponent {
  emailDomain$ = new Subject<string>();
  
  onEmailChange(event: any) {
    const email = event.target.value;
    this.emailDomain$.next(email);
  }
  
  ngOnInit() {
    this.emailDomain$ = this.emailDomain$.pipe(
      map(email => {
        const parts = email.split('@');
        return parts.length > 1 ? parts[1] : '';
      })
    );
  }
}

// Transform coordinates to address
@Component({...})
export class LocationComponent {
  location$ = this.geolocationService.getCurrentPosition().pipe(
    map(position => ({
      lat: position.coords.latitude,
      lng: position.coords.longitude
    })),
    map(coords => `${coords.lat.toFixed(4)}, ${coords.lng.toFixed(4)}`)
  );
}
```

## 🎯 Filter Operator

The `filter` operator only emits values that pass a specified condition. It's like `Array.filter()` for Observables.

### 🔍 Basic Usage

```typescript
import { of } from 'rxjs';
import { filter } from 'rxjs/operators';

// Only emit even numbers
const numbers$ = of(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
const evenNumbers$ = numbers$.pipe(
  filter(x => x % 2 === 0)
);
// Emits: 2, 4, 6, 8, 10

evenNumbers$.subscribe(value => console.log(value));
```

### 🌟 Real-World Examples

```typescript
// Filter search results by minimum length
@Component({
  template: `
    <input #search placeholder="Search (min 3 characters)...">
    <div *ngFor="let result of searchResults$ | async">
      {{ result.title }}
    </div>
  `
})
export class SearchComponent implements AfterViewInit {
  @ViewChild('search') searchInput!: ElementRef;
  searchResults$!: Observable<SearchResult[]>;
  
  ngAfterViewInit() {
    this.searchResults$ = fromEvent(this.searchInput.nativeElement, 'input').pipe(
      map((event: any) => event.target.value),
      filter(query => query.length >= 3), // Only search if 3+ characters
      debounceTime(300),
      switchMap(query => this.searchService.search(query))
    );
  }
}

// Filter notifications by type
@Injectable()
export class NotificationService {
  private notifications$ = new Subject<Notification>();
  
  // Only show error notifications
  errorNotifications$ = this.notifications$.pipe(
    filter(notification => notification.type === 'error')
  );
  
  // Only show notifications for current user
  userNotifications$ = this.notifications$.pipe(
    filter(notification => notification.userId === this.currentUserId)
  );
  
  // Filter out dismissed notifications
  activeNotifications$ = this.notifications$.pipe(
    filter(notification => !notification.dismissed)
  );
}

// Filter valid form values
@Component({...})
export class FormComponent {
  form = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    age: [null, [Validators.required, Validators.min(18)]]
  });
  
  validFormValues$ = this.form.valueChanges.pipe(
    filter(() => this.form.valid), // Only emit when form is valid
    map(formValue => formValue)
  );
}
```

## 👀 Tap Operator

The `tap` operator performs side effects without modifying the stream. Perfect for debugging, logging, or triggering actions.

### 🔍 Basic Usage

```typescript
import { of } from 'rxjs';
import { tap, map } from 'rxjs/operators';

const numbers$ = of(1, 2, 3).pipe(
  tap(x => console.log('Before map:', x)), // Side effect: logging
  map(x => x * 2),
  tap(x => console.log('After map:', x))   // Side effect: logging
);

// Console output:
// Before map: 1
// After map: 2
// Before map: 2
// After map: 4
// Before map: 3
// After map: 6
```

### 🌟 Real-World Examples

```typescript
// Debugging HTTP requests
@Injectable()
export class ApiService {
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>('/api/users').pipe(
      tap(response => console.log('API Response:', response)),
      tap(users => console.log(`Loaded ${users.length} users`)),
      catchError(error => {
        console.error('API Error:', error);
        return throwError(error);
      })
    );
  }
}

// Show loading indicator
@Component({...})
export class DataComponent {
  loading = false;
  users$: Observable<User[]>;
  
  constructor(private userService: UserService) {
    this.users$ = this.userService.getUsers().pipe(
      tap(() => this.loading = true),           // Start loading
      finalize(() => this.loading = false)      // Stop loading (success or error)
    );
  }
}

// Cache data and trigger analytics
@Injectable()
export class ProductService {
  private cache = new Map<string, Product>();
  
  getProduct(id: string): Observable<Product> {
    return this.http.get<Product>(`/api/products/${id}`).pipe(
      tap(product => {
        // Side effect: cache the product
        this.cache.set(id, product);
      }),
      tap(product => {
        // Side effect: track analytics
        this.analytics.trackEvent('product_viewed', {
          productId: product.id,
          category: product.category
        });
      })
    );
  }
}

// Form validation feedback
@Component({
  template: `
    <input [(ngModel)]="username" placeholder="Username">
    <div class="validation-message">{{ validationMessage }}</div>
  `
})
export class UsernameComponent {
  username = '';
  validationMessage = '';
  
  username$ = new BehaviorSubject('');
  
  ngOnInit() {
    this.username$.pipe(
      debounceTime(500),
      tap(() => this.validationMessage = 'Checking availability...'),
      switchMap(username => this.checkUsernameAvailability(username)),
      tap(available => {
        // Side effect: update UI message
        this.validationMessage = available 
          ? '✅ Username available' 
          : '❌ Username taken';
      })
    ).subscribe();
  }
}
```

## 🔄 SwitchMap Operator

`switchMap` is a flattening operator that switches to a new inner Observable, canceling the previous one. Perfect for handling scenarios where you only care about the latest request.

### 🔍 Basic Usage

```typescript
import { of, interval } from 'rxjs';
import { switchMap, take } from 'rxjs/operators';

// Switch to different timer streams
const clicks$ = fromEvent(button, 'click');
const timers$ = clicks$.pipe(
  switchMap(() => interval(1000).pipe(take(3)))
);
// Each click cancels the previous timer and starts a new one
```

### 🌟 Real-World Examples

```typescript
// Search with automatic cancellation
@Component({
  template: `
    <input #search placeholder="Search products...">
    <div class="loading" *ngIf="loading">🔄 Searching...</div>
    <div *ngFor="let product of searchResults$ | async">
      {{ product.name }}
    </div>
  `
})
export class ProductSearchComponent implements AfterViewInit {
  @ViewChild('search') searchInput!: ElementRef;
  searchResults$!: Observable<Product[]>;
  loading = false;
  
  ngAfterViewInit() {
    this.searchResults$ = fromEvent(this.searchInput.nativeElement, 'input').pipe(
      map((event: any) => event.target.value),
      filter(query => query.length > 2),
      debounceTime(300),
      tap(() => this.loading = true),
      switchMap(query => 
        this.productService.searchProducts(query).pipe(
          finalize(() => this.loading = false)
        )
      )
    );
  }
}

// Route parameter handling
@Component({...})
export class ProductDetailComponent implements OnInit {
  product$!: Observable<Product>;
  
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}
  
  ngOnInit() {
    this.product$ = this.route.params.pipe(
      switchMap(params => {
        const id = params['id'];
        return this.productService.getProduct(id);
      })
    );
  }
}

// Dependent dropdown
@Component({
  template: `
    <select [(ngModel)]="selectedCountry" (change)="onCountryChange()">
      <option *ngFor="let country of countries" [value]="country.id">
        {{ country.name }}
      </option>
    </select>
    
    <select [(ngModel)]="selectedState">
      <option *ngFor="let state of states$ | async" [value]="state.id">
        {{ state.name }}
      </option>
    </select>
  `
})
export class LocationComponent {
  selectedCountry = '';
  countrySubject = new Subject<string>();
  
  states$ = this.countrySubject.pipe(
    filter(countryId => !!countryId),
    switchMap(countryId => 
      this.locationService.getStatesByCountry(countryId)
    )
  );
  
  onCountryChange() {
    this.countrySubject.next(this.selectedCountry);
  }
}
```

## 🤝 CombineLatest Operator

`combineLatest` waits for all source Observables to emit at least once, then emits whenever any source emits, combining the latest values from all sources.

### 🔍 Basic Usage

```typescript
import { combineLatest, of } from 'rxjs';
import { map } from 'rxjs/operators';

const name$ = of('John');
const age$ = of(30);
const city$ = of('New York');

const userProfile$ = combineLatest([name$, age$, city$]).pipe(
  map(([name, age, city]) => ({ name, age, city }))
);
// Emits: { name: 'John', age: 30, city: 'New York' }
```

### 🌟 Real-World Examples

```typescript
// Advanced search with multiple filters
@Component({
  template: `
    <div class="filters">
      <input #searchInput placeholder="Search...">
      <select #categorySelect>
        <option value="">All Categories</option>
        <option value="electronics">Electronics</option>
        <option value="clothing">Clothing</option>
      </select>
      <input #minPrice type="number" placeholder="Min Price">
      <input #maxPrice type="number" placeholder="Max Price">
    </div>
    
    <div class="results">
      <div *ngFor="let product of filteredProducts$ | async">
        {{ product.name }} - ${{ product.price }}
      </div>
    </div>
  `
})
export class AdvancedSearchComponent implements AfterViewInit {
  @ViewChild('searchInput') searchInput!: ElementRef;
  @ViewChild('categorySelect') categorySelect!: ElementRef;
  @ViewChild('minPrice') minPriceInput!: ElementRef;
  @ViewChild('maxPrice') maxPriceInput!: ElementRef;
  
  filteredProducts$!: Observable<Product[]>;
  
  ngAfterViewInit() {
    const searchTerm$ = fromEvent(this.searchInput.nativeElement, 'input').pipe(
      map((e: any) => e.target.value),
      startWith('')
    );
    
    const category$ = fromEvent(this.categorySelect.nativeElement, 'change').pipe(
      map((e: any) => e.target.value),
      startWith('')
    );
    
    const minPrice$ = fromEvent(this.minPriceInput.nativeElement, 'input').pipe(
      map((e: any) => Number(e.target.value) || 0),
      startWith(0)
    );
    
    const maxPrice$ = fromEvent(this.maxPriceInput.nativeElement, 'input').pipe(
      map((e: any) => Number(e.target.value) || Infinity),
      startWith(Infinity)
    );
    
    this.filteredProducts$ = combineLatest([
      searchTerm$,
      category$,
      minPrice$,
      maxPrice$
    ]).pipe(
      debounceTime(300),
      switchMap(([search, category, minPrice, maxPrice]) =>
        this.productService.searchProducts({
          search,
          category,
          minPrice,
          maxPrice
        })
      )
    );
  }
}

// Form validation with multiple fields
@Component({...})
export class RegistrationComponent {
  form = this.fb.group({
    username: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(8)]],
    confirmPassword: ['', Validators.required]
  });
  
  // Combine form validity with custom validations
  canSubmit$ = combineLatest([
    this.form.statusChanges.pipe(startWith(this.form.status)),
    this.form.get('username')!.valueChanges.pipe(
      startWith(''),
      debounceTime(500),
      switchMap(username => 
        username ? this.checkUsernameAvailable(username) : of(true)
      )
    ),
    this.form.valueChanges.pipe(
      startWith(this.form.value),
      map(form => form.password === form.confirmPassword)
    )
  ]).pipe(
    map(([formStatus, usernameAvailable, passwordsMatch]) =>
      formStatus === 'VALID' && usernameAvailable && passwordsMatch
    )
  );
}

// Dashboard with multiple data sources
@Component({
  template: `
    <div class="dashboard">
      <div class="stats" *ngIf="dashboardData$ | async as data">
        <div>Users: {{ data.userCount }}</div>
        <div>Orders: {{ data.orderCount }}</div>
        <div>Revenue: {{ data.revenue | currency }}</div>
        <div>Status: {{ data.systemStatus }}</div>
      </div>
    </div>
  `
})
export class DashboardComponent {
  dashboardData$ = combineLatest([
    this.apiService.getUserCount(),
    this.apiService.getOrderCount(), 
    this.apiService.getRevenue(),
    this.apiService.getSystemStatus()
  ]).pipe(
    map(([userCount, orderCount, revenue, systemStatus]) => ({
      userCount,
      orderCount, 
      revenue,
      systemStatus
    }))
  );
}
```

## ⚠️ Error Handling in RxJS

Proper error handling is crucial for robust Angular applications. RxJS provides several operators for handling errors gracefully.

### 🛡️ CatchError Operator

```typescript
import { catchError } from 'rxjs/operators';
import { of, throwError } from 'rxjs';

// Basic error handling
@Injectable()
export class UserService {
  getUser(id: string): Observable<User> {
    return this.http.get<User>(`/api/users/${id}`).pipe(
      catchError(error => {
        console.error('Failed to load user:', error);
        // Return fallback value
        return of({ id: '', name: 'Unknown User', email: '' });
      })
    );
  }
}
```

### 🔄 Retry Strategies

```typescript
import { retry, retryWhen, delay, take } from 'rxjs/operators';

// Simple retry
@Injectable()
export class ApiService {
  getData(): Observable<any> {
    return this.http.get('/api/data').pipe(
      retry(3), // Retry up to 3 times
      catchError(error => {
        console.error('Failed after 3 retries:', error);
        return throwError(error);
      })
    );
  }
  
  // Advanced retry with delay
  getDataWithRetry(): Observable<any> {
    return this.http.get('/api/data').pipe(
      retryWhen(errors => 
        errors.pipe(
          delay(1000),    // Wait 1 second between retries
          take(3)         // Maximum 3 retries
        )
      ),
      catchError(error => {
        console.error('Failed after retries with delay:', error);
        return of(null); // Return fallback
      })
    );
  }
}
```

### 🎯 Real-World Error Handling Examples

```typescript
// Comprehensive error handling service
@Injectable()
export class DataService {
  constructor(
    private http: HttpClient,
    private notificationService: NotificationService,
    private loadingService: LoadingService
  ) {}
  
  loadUserData(userId: string): Observable<User> {
    return this.http.get<User>(`/api/users/${userId}`).pipe(
      // Show loading indicator
      tap(() => this.loadingService.show()),
      
      // Retry on network errors
      retryWhen(errors => 
        errors.pipe(
          tap(error => console.log('Retrying request:', error)),
          delay(2000),
          take(2)
        )
      ),
      
      // Handle different error types
      catchError(error => {
        this.loadingService.hide();
        
        if (error.status === 404) {
          this.notificationService.showError('User not found');
          return of(null);
        } else if (error.status === 401) {
          this.notificationService.showError('Please log in again');
          this.router.navigate(['/login']);
          return throwError(error);
        } else if (error.status >= 500) {
          this.notificationService.showError('Server error. Please try again later.');
          return of(this.getDefaultUser());
        } else {
          this.notificationService.showError('Something went wrong');
          return throwError(error);
        }
      }),
      
      // Hide loading on success
      finalize(() => this.loadingService.hide())
    );
  }
  
  private getDefaultUser(): User {
    return { id: '', name: 'Guest User', email: '' };
  }
}

// Component error handling
@Component({
  template: `
    <div class="user-profile">
      <div *ngIf="loading">⏳ Loading...</div>
      <div *ngIf="error" class="error">
        ❌ {{ error }}
        <button (click)="retry()">Try Again</button>
      </div>
      <div *ngIf="user$ | async as user" class="user-info">
        <h2>{{ user.name }}</h2>
        <p>{{ user.email }}</p>
      </div>
    </div>
  `
})
export class UserProfileComponent implements OnInit {
  user$!: Observable<User>;
  loading = false;
  error = '';
  private retrySubject = new Subject<void>();
  
  ngOnInit() {
    this.user$ = merge(
      // Initial load
      of(null),
      // Retry trigger
      this.retrySubject
    ).pipe(
      tap(() => {
        this.loading = true;
        this.error = '';
      }),
      switchMap(() => this.userService.getCurrentUser()),
      tap(() => this.loading = false),
      catchError(error => {
        this.loading = false;
        this.error = 'Failed to load user profile';
        console.error('User profile error:', error);
        return of(null);
      }),
      share() // Share the subscription
    );
  }
  
  retry() {
    this.retrySubject.next();
  }
}
```

### 🔧 Global Error Handling

```typescript
// Global error handler
@Injectable()
export class GlobalErrorHandler implements ErrorHandler {
  constructor(private notificationService: NotificationService) {}
  
  handleError(error: any): void {
    console.error('Global error:', error);
    
    // Handle RxJS errors
    if (error instanceof Error && error.message.includes('Http failure')) {
      this.notificationService.showError('Network error. Please check your connection.');
    } else {
      this.notificationService.showError('An unexpected error occurred.');
    }
  }
}

// HTTP Interceptor for centralized error handling
@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred';
        
        if (error.error instanceof ErrorEvent) {
          // Client-side error
          errorMessage = `Client Error: ${error.error.message}`;
        } else {
          // Server-side error
          errorMessage = `Server Error: ${error.status} ${error.message}`;
        }
        
        console.error(errorMessage);
        return throwError(error);
      })
    );
  }
}
```

## 🎯 Operator Combination Patterns

### 🔄 Search Pattern

```typescript
// Complete search implementation
const searchPattern$ = searchInput$.pipe(
  map(event => event.target.value),           // Extract value
  filter(query => query.length > 2),          // Minimum length
  debounceTime(300),                          // Wait for pause
  distinctUntilChanged(),                     // Skip duplicates
  tap(query => this.loading = true),          // Show loading
  switchMap(query =>                          // Switch to search
    this.searchService.search(query).pipe(
      catchError(error => {                   // Handle errors
        console.error('Search failed:', error);
        return of([]);
      })
    )
  ),
  finalize(() => this.loading = false)        // Hide loading
);
```

### 🎭 Loading State Pattern

```typescript
// Track loading state for multiple operations
const withLoadingState = <T>(source$: Observable<T>) => {
  return source$.pipe(
    map(data => ({ loading: false, data, error: null })),
    startWith({ loading: true, data: null, error: null }),
    catchError(error => of({ loading: false, data: null, error }))
  );
};

// Usage
this.users$ = withLoadingState(this.userService.getUsers());
```

## 🎉 Quick Reference

```typescript
// Essential operators cheat sheet

// TRANSFORMATION
map(x => x * 2)                  // Transform each value
pluck('name')                    // Extract property
scan((acc, val) => acc + val)    // Accumulate over time

// FILTERING  
filter(x => x > 0)               // Only emit matching values
take(5)                          // Take first N values
takeWhile(x => x < 10)           // Take while condition true
distinctUntilChanged()           // Skip consecutive duplicates

// SIDE EFFECTS
tap(x => console.log(x))         // Perform side effect
finalize(() => cleanup())        // Cleanup on complete/error

// FLATTENING
switchMap(x => getStream(x))     // Switch to new stream (cancel previous)
mergeMap(x => getStream(x))      // Merge multiple streams  
concatMap(x => getStream(x))     // Wait for each to complete

// COMBINING
combineLatest([a$, b$])          // Combine latest from all
merge(a$, b$)                    // Merge emissions
startWith('initial')             // Start with initial value

// ERROR HANDLING
catchError(err => of('fallback')) // Handle and recover from errors
retry(3)                         // Retry N times
retryWhen(errors => errors.pipe(delay(1000))) // Retry with strategy

// TIME
debounceTime(300)                // Wait for pause
throttleTime(1000)               // Limit emission rate
delay(2000)                      // Delay emissions
```

---

*Master these operators and you'll be handling complex async scenarios like a pro! 🚀✨*
