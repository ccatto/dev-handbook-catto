# RxJs and Observables

# 🌊 Basics of RxJS

RxJS (Reactive Extensions for JavaScript) is a library that helps Angular development by providing tools for handling asynchronous operations and event-based programming. At its core, RxJS introduces the concept of Observables, streams of data that emit values over time.

These Observables represent anything from user input and HTTP responses to timers and complex data transformations. RxJS also offers a vast array of operators, allowing you to filter, transform, combine, and manipulate data streams with ease.

In this lesson, we dive into the basics of RxJS to get you started with the library.

## 🎯 What Are Observables?

Think of Observables as **streams of data over time** 🌊. Unlike promises that handle a single async value, Observables can emit multiple values, making them perfect for handling ongoing events.

### 🔍 Observable vs Promise Comparison

```typescript
// Promise - Single value, one time
const promise = fetch('/api/user/1');
promise.then(response => console.log(response)); // Fires once

// Observable - Multiple values over time
const observable$ = new Observable(observer => {
  observer.next('First value');
  observer.next('Second value');
  observer.next('Third value');
  observer.complete();
});
```

### 🏗️ Creating Observables

```typescript
import { Observable, of, from, interval, fromEvent } from 'rxjs';

// 1. Basic Observable creation
const basic$ = new Observable<string>(observer => {
  observer.next('Hello');
  observer.next('World');
  observer.complete();
});

// 2. Create from values
const fromValues$ = of(1, 2, 3, 4, 5);

// 3. Create from array
const fromArray$ = from([10, 20, 30]);

// 4. Create from events
const clicks$ = fromEvent(document, 'click');

// 5. Create timer/interval
const timer$ = interval(1000); // Emits every second: 0, 1, 2, 3...
```

### 📡 Subscribing to Observables

```typescript
// Basic subscription
const subscription = observable$.subscribe({
  next: (value) => console.log('Received:', value),
  error: (error) => console.error('Error:', error),
  complete: () => console.log('Stream completed!')
});

// Shorthand for next only
observable$.subscribe(value => console.log(value));

// Don't forget to unsubscribe!
subscription.unsubscribe();
```

### 🎪 Real-World Observable Examples

```typescript
// HTTP requests (Angular HttpClient returns Observables)
@Component({
  template: `
    <div>
      <h2>Users</h2>
      <div *ngFor="let user of users$ | async">
        {{ user.name }}
      </div>
    </div>
  `
})
export class UsersComponent {
  users$ = this.http.get<User[]>('/api/users');
  
  constructor(private http: HttpClient) {}
}

// Form input changes
@Component({
  template: `
    <input #searchInput placeholder="Search...">
    <div *ngFor="let result of searchResults$ | async">
      {{ result }}
    </div>
  `
})
export class SearchComponent implements AfterViewInit {
  @ViewChild('searchInput') searchInput!: ElementRef;
  searchResults$!: Observable<string[]>;
  
  ngAfterViewInit() {
    this.searchResults$ = fromEvent(this.searchInput.nativeElement, 'input').pipe(
      map((event: any) => event.target.value),
      filter(text => text.length > 2),
      debounceTime(300),
      switchMap(query => this.searchService.search(query))
    );
  }
}
```

## 🔧 What Are Operators?

Operators are **pure functions** that transform, filter, combine, or manipulate Observable streams. Think of them as a pipeline where data flows through and gets transformed at each step.

### 🎨 Transformation Operators

```typescript
import { map, pluck, scan } from 'rxjs/operators';

// MAP - Transform each value
const numbers$ = of(1, 2, 3, 4, 5);
const doubled$ = numbers$.pipe(
  map(x => x * 2)
); // Emits: 2, 4, 6, 8, 10

// PLUCK - Extract property from objects
const users$ = of(
  { name: 'John', age: 30 },
  { name: 'Jane', age: 25 }
);
const names$ = users$.pipe(
  pluck('name')
); // Emits: 'John', 'Jane'

// SCAN - Accumulate values (like Array.reduce but over time)
const runningTotal$ = numbers$.pipe(
  scan((acc, curr) => acc + curr, 0)
); // Emits: 1, 3, 6, 10, 15
```

### 🎯 Filtering Operators

```typescript
import { filter, take, takeWhile, distinctUntilChanged } from 'rxjs/operators';

// FILTER - Only emit values that pass a test
const evenNumbers$ = numbers$.pipe(
  filter(x => x % 2 === 0)
); // Emits: 2, 4

// TAKE - Take only first N values
const firstThree$ = numbers$.pipe(
  take(3)
); // Emits: 1, 2, 3 then completes

// TAKE WHILE - Take values while condition is true
const lessThanFour$ = numbers$.pipe(
  takeWhile(x => x < 4)
); // Emits: 1, 2, 3

// DISTINCT UNTIL CHANGED - Skip duplicate consecutive values
const input$ = of('a', 'a', 'b', 'b', 'b', 'c');
const unique$ = input$.pipe(
  distinctUntilChanged()
); // Emits: 'a', 'b', 'c'
```

### ⏱️ Time-Based Operators

```typescript
import { debounceTime, throttleTime, delay } from 'rxjs/operators';

// DEBOUNCE TIME - Wait for silence period
const searchInput$ = fromEvent(input, 'keyup').pipe(
  debounceTime(300), // Wait 300ms after last keystroke
  map(event => event.target.value)
);

// THROTTLE TIME - Limit emission rate
const button$ = fromEvent(button, 'click').pipe(
  throttleTime(1000) // Max one click per second
);

// DELAY - Delay emissions
const delayed$ = of('Hello').pipe(
  delay(2000) // Wait 2 seconds before emitting
);
```

### 🔗 Combination Operators

```typescript
import { combineLatest, merge, concat } from 'rxjs';
import { switchMap, mergeMap, concatMap } from 'rxjs/operators';

// COMBINE LATEST - Combine multiple streams
const name$ = of('John');
const age$ = of(30);
const combined$ = combineLatest([name$, age$]).pipe(
  map(([name, age]) => ({ name, age }))
);

// MERGE - Combine streams as they emit
const fast$ = interval(1000);
const slow$ = interval(2000);
const merged$ = merge(fast$, slow$);

// SWITCH MAP - Switch to new Observable, canceling previous
const searchQuery$ = fromEvent(searchInput, 'input').pipe(
  map(e => e.target.value),
  switchMap(query => this.http.get(`/search?q=${query}`))
);
```

### 🎭 Complex Operator Chain Example

```typescript
// Real-world search with type-ahead
@Component({
  template: `
    <input #search placeholder="Search users..." />
    <div class="results">
      <div *ngFor="let user of searchResults$ | async" class="user-card">
        <img [src]="user.avatar" [alt]="user.name">
        <span>{{ user.name }}</span>
      </div>
    </div>
    <div *ngIf="loading$ | async" class="loading">🔄 Searching...</div>
  `
})
export class UserSearchComponent implements AfterViewInit {
  @ViewChild('search') searchInput!: ElementRef;
  
  searchResults$!: Observable<User[]>;
  loading$!: Observable<boolean>;
  
  ngAfterViewInit() {
    const searchQuery$ = fromEvent(this.searchInput.nativeElement, 'input').pipe(
      map((event: any) => event.target.value.trim()),
      filter(query => query.length > 2), // Only search if > 2 chars
      distinctUntilChanged(), // Skip if same as previous
      debounceTime(300) // Wait for 300ms pause in typing
    );
    
    this.searchResults$ = searchQuery$.pipe(
      switchMap(query => 
        this.userService.searchUsers(query).pipe(
          catchError(error => {
            console.error('Search failed:', error);
            return of([]); // Return empty array on error
          })
        )
      )
    );
    
    this.loading$ = searchQuery$.pipe(
      switchMap(query => 
        merge(
          of(true), // Start loading
          this.userService.searchUsers(query).pipe(
            map(() => false), // Stop loading on success
            catchError(() => of(false)) // Stop loading on error
          )
        )
      ),
      startWith(false)
    );
  }
}
```

## 🚫 Strategies to Unsubscribe

Memory leaks are a common issue when working with Observables. Here are the best strategies to handle unsubscription.

### 💥 The Problem - Memory Leaks

```typescript
// ❌ BAD - Creates memory leak
@Component({...})
export class BadComponent implements OnInit {
  ngOnInit() {
    // This subscription never gets cleaned up!
    interval(1000).subscribe(value => {
      console.log('Timer:', value);
    });
  }
}
```

### 1️⃣ Manual Unsubscribe

```typescript
import { Subscription } from 'rxjs';

@Component({...})
export class ManualComponent implements OnInit, OnDestroy {
  private subscription = new Subscription();
  
  ngOnInit() {
    // Single subscription
    this.subscription = interval(1000).subscribe(value => {
      console.log('Timer:', value);
    });
    
    // Multiple subscriptions
    this.subscription.add(
      fromEvent(document, 'click').subscribe(event => {
        console.log('Click:', event);
      })
    );
  }
  
  ngOnDestroy() {
    this.subscription.unsubscribe(); // Clean up all subscriptions
  }
}
```

### 2️⃣ takeUntil Pattern (Recommended) 🏆

```typescript
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';

@Component({...})
export class TakeUntilComponent implements OnInit, OnDestroy {
  private destroy$ = new Subject<void>();
  
  ngOnInit() {
    // All subscriptions automatically unsubscribe when component destroys
    interval(1000).pipe(
      takeUntil(this.destroy$)
    ).subscribe(value => {
      console.log('Timer:', value);
    });
    
    fromEvent(document, 'click').pipe(
      takeUntil(this.destroy$)
    ).subscribe(event => {
      console.log('Click:', event);
    });
    
    this.userService.getUsers().pipe(
      takeUntil(this.destroy$)
    ).subscribe(users => {
      this.users = users;
    });
  }
  
  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
```

### 3️⃣ Async Pipe (Best for Templates) 🌟

```typescript
@Component({
  template: `
    <div>
      <!-- Async pipe automatically subscribes/unsubscribes -->
      <div *ngFor="let user of users$ | async">{{ user.name }}</div>
      <div>Timer: {{ timer$ | async }}</div>
      <div>Current time: {{ currentTime$ | async | date:'medium' }}</div>
    </div>
  `
})
export class AsyncPipeComponent {
  users$ = this.userService.getUsers();
  timer$ = interval(1000);
  currentTime$ = interval(1000).pipe(
    map(() => new Date())
  );
  
  constructor(private userService: UserService) {}
  
  // No ngOnDestroy needed! 🎉
}
```

### 4️⃣ DestroyRef (Angular 16+) 🚀

```typescript
import { DestroyRef } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';

@Component({...})
export class ModernComponent implements OnInit {
  private destroyRef = inject(DestroyRef);
  
  ngOnInit() {
    // Automatically unsubscribes when component is destroyed
    interval(1000).pipe(
      takeUntilDestroyed(this.destroyRef)
    ).subscribe(value => {
      console.log('Timer:', value);
    });
    
    // Can also be used in constructor
    this.userService.getUsers().pipe(
      takeUntilDestroyed() // Uses injected DestroyRef automatically
    ).subscribe(users => {
      this.users = users;
    });
  }
}
```

### 5️⃣ Finite Observables (Auto-complete)

```typescript
@Component({...})
export class HttpComponent {
  loadUsers() {
    // HTTP requests complete automatically - no unsubscribe needed
    this.http.get<User[]>('/api/users').subscribe(users => {
      this.users = users;
    });
    
    // But be careful with error handling
    this.http.get<User[]>('/api/users').pipe(
      catchError(error => {
        console.error('Failed to load users:', error);
        return of([]); // Return fallback value
      })
    ).subscribe(users => {
      this.users = users;
    });
  }
}
```

## 🎯 Best Practices Summary

### ✅ Do's

- **Use async pipe** in templates whenever possible 🌟
- **Use takeUntilDestroyed()** for Angular 16+ 🚀
- **Use takeUntil pattern** for older Angular versions 🏆
- **Handle errors** with catchError operator ⚠️
- **Use operators** to transform data streams 🔧
- **Keep subscriptions** in service layer when possible 🏢

### ❌ Don'ts

- **Don't forget** to unsubscribe from infinite Observables
- **Don't subscribe** in templates (use async pipe instead)
- **Don't nest** subscriptions (use switchMap, mergeMap, etc.)
- **Don't ignore** errors (always handle with catchError)
- **Don't create** Observables in templates 
- **Don't mutate** data in operators (keep them pure)

## 🎉 Quick Reference

```typescript
// Creating
of(1, 2, 3)                    // From values
from([1, 2, 3])                // From array
interval(1000)                 // Timer
fromEvent(element, 'click')    // From events

// Transforming
map(x => x * 2)                // Transform each value
filter(x => x > 0)             // Filter values
scan((acc, val) => acc + val)  // Accumulate

// Timing
debounceTime(300)              // Wait for pause
throttleTime(1000)             // Limit rate
delay(2000)                    // Delay emission

// Combining
combineLatest([a$, b$])        // Combine latest values
merge(a$, b$)                  // Merge streams
switchMap(val => newStream$)   // Switch to new stream

// Unsubscribing
takeUntil(destroy$)            // Until signal
takeUntilDestroyed()           // Until component destroyed
// Or use async pipe in templates!
```

---

*Master these RxJS basics and you'll handle async data like a pro! 🌊✨*

