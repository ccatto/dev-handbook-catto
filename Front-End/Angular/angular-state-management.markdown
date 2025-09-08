# Angular 20 State Management: Signals vs NgRx

In Angular 20, both **Signals** (including `SignalStore` and `signalState`) and **NgRx** continue to be widely used, but the context determines which is more suitable.

## Signals in Angular: The Rising Star

- **Native reactivity**: Introduced in Angular 16, Signals are a built-in reactive primitive that simplify state management with automatic dependency tracking and minimal boilerplate.  
- **Flexibility**: Use raw signal primitives in services or components for localized state, or opt for structured APIs like `signalState` or `SignalStore` (from `@ngrx/signals`) for scalable patterns.  
- **Modern enhancements**: Angular evolves its Signals ecosystem—NgRx v20 introduces features like `withLinkedState`, `withFeature`, and an experimental Events plugin for better reactivity.  
- **Simplicity & performance**: Signals offer fine-grained updates, lazy evaluation, and improved performance for simpler scenarios.

## NgRx: Still the Go-To for Complex Architecture

- **Battle-tested architecture**: NgRx Store remains the standard for large-scale apps, with Actions, Reducers, Selectors, Effects, and a single immutable store.  
- **Powerful tooling**: Offers time-travel debugging, strict unidirectional flows, and advanced side-effect handling for complex global state.  
- **Signal-enhanced NgRx**: `SignalStore` simplifies NgRx by replacing actions/reducers with direct methods and reactive signals.

## Community Sentiment

- **Reddit discussions**:
  - One user: “Signals, for sure! Moving forward, Angular will heavily integrate signals, making them foundational for state management.”
  - Another: “You really should know both.”

## Summary Table

| Situation / Scale | Signals (incl. SignalStore) | Classic NgRx Store (Redux-style) |
|-------------------|-----------------------------|----------------------------------|
| Small-to-medium apps, localized state | Ideal: lightweight, minimal setup | Often overkill |
| Large-scale, global app state | Viable via SignalStore | Preferred: scalable, structured, debuggable |
| Development experience | Cleaner, less boilerplate | Verbose but mature tooling |
| Future alignment | Emerging as Angular-first | Stable, proven, but evolving |
| Hybrid approach | Combine SignalStore locally + NgRx globally | Not typical; usually too heavy |

## Final Take

Signals (especially `SignalStore`) are becoming more common for new apps due to simplicity, performance, and Angular integration. For complex, enterprise-scale apps, classic NgRx or its Signal-flavored evolution remains powerful. A **hybrid strategy**—using NgRx/SignalStore for global state and pure Signals for localized concerns—often provides the best of both worlds.

---

## Example 1: Using Signals (Angular-native reactive state)

### counter.service.ts
```typescript
import { Injectable, signal } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class CounterService {
  // Define a signal for counter state
  counter = signal(0);

  increment() {
    this.counter.set(this.counter() + 1);
  }

  decrement() {
    this.counter.set(this.counter() - 1);
  }
}
```

### counter.component.ts
```typescript
import { Component, effect, inject } from '@angular/core';
import { CounterService } from './counter.service';

@Component({
  selector: 'app-counter',
  template: `
    <h2>Counter: {{ counterService.counter() }}</h2>
    <button (click)="counterService.increment()">+</button>
    <button (click)="counterService.decrement()">-</button>
  `,
})
export class CounterComponent {
  counterService = inject(CounterService);

  constructor() {
    // Optional: react to changes
    effect(() => console.log('Counter changed:', this.counterService.counter()));
  }
}
```

**Pros**:
- Minimal boilerplate.
- Reactive by default.
- Easy for localized state or small apps.

---

## Example 2: Using NgRx (Classic Redux-style)

### Install NgRx Packages
```bash
ng add @ngrx/store
ng add @ngrx/effects  # optional for async
```

### counter.actions.ts
```typescript
import { createAction } from '@ngrx/store';

export const increment = createAction('[Counter] Increment');
export const decrement = createAction('[Counter] Decrement');
export const reset = createAction('[Counter] Reset');
```

### counter.reducer.ts
```typescript
import { createReducer, on } from '@ngrx/store';
import { increment, decrement, reset } from './counter.actions';

export const initialState = 0;

export const counterReducer = createReducer(
  initialState,
  on(increment, state => state + 1),
  on(decrement, state => state - 1),
  on(reset, state => 0)
);
```

### app.module.ts
```typescript
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { counterReducer } from './counter.reducer';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    StoreModule.forRoot({ count: counterReducer })
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
```

### counter.component.ts
```typescript
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { increment, decrement } from './counter.actions';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-counter',
  template: `
    <h2>Counter: {{ counter$ | async }}</h2>
    <button (click)="increment()">+</button>
    <button (click)="decrement()">-</button>
  `
})
export class CounterComponent {
  counter$: Observable<number>;

  constructor(private store: Store<{ count: number }>) {
    this.counter$ = store.select('count');
  }

  increment() { this.store.dispatch(increment()); }
  decrement() { this.store.dispatch(decrement()); }
}
```

**Pros**:
- Predictable, centralized state.
- Scales well for large apps.
- Powerful tooling (DevTools, time-travel debugging).

---

## Key Comparison

| Feature | Signals | NgRx |
|---------|---------|------|
| Boilerplate | Minimal | More verbose (actions, reducer, store) |
| Reactivity | Built-in, fine-grained | Observable-based |
| Best for | Local or moderate app state | Large-scale apps with global state |
| Tooling | Lightweight | DevTools, effects, testing frameworks |

---

## Example 3: Cart Service Using Signals

### cart.service.ts
```typescript
import { Injectable, signal, computed } from '@angular/core';

// Simple cart item interface
export interface CartItem {
  id: number;
  name: string;
  price: number;
  quantity: number;
}

@Injectable({ providedIn: 'root' })
export class CartService {
  // Shared signal for cart items
  private itemsSignal = signal<CartItem[]>([]);

  // Expose a computed signal for total price
  totalPrice = computed(() =>
    this.itemsSignal().reduce((sum, item) => sum + item.price * item.quantity, 0)
  );

  // Getter for components
  get items() {
    return this.itemsSignal;
  }

  // Add or update an item
  addItem(item: CartItem) {
    const items = this.itemsSignal();
    const existing = items.find(i => i.id === item.id);
    if (existing) {
      existing.quantity += item.quantity;
      this.itemsSignal.set([...items]);
    } else {
      this.itemsSignal.set([...items, item]);
    }
  }

  removeItem(id: number) {
    this.itemsSignal.set(this.itemsSignal().filter(i => i.id !== id));
  }

  clearCart() {
    this.itemsSignal.set([]);
  }
}
```

### product-detail.component.ts
```typescript
import { Component, inject } from '@angular/core';
import { CartService, CartItem } from './cart.service';

@Component({
  selector: 'app-product-detail',
  template: `
    <h2>Product Detail</h2>
    <button (click)="addToCart()">Add to Cart</button>
  `
})
export class ProductDetailComponent {
  cartService = inject(CartService);

  addToCart() {
    const item: CartItem = {
      id: 1,
      name: 'Awesome Widget',
      price: 19.99,
      quantity: 1
    };
    this.cartService.addItem(item);
    console.log('Added to cart:', item);
  }
}
```

### cart.component.ts
```typescript
import { Component, effect, inject } from '@angular/core';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  template: `
    <h2>Shopping Cart</h2>
    <ul>
      <li *ngFor="let item of cartService.items()">
        {{ item.name }} - {{ item.quantity }} x ${{ item.price }}
        <button (click)="remove(item.id)">Remove</button>
      </li>
    </ul>
    <p>Total: ${{ cartService.totalPrice() }}</p>
  `
})
export class CartComponent {
  cartService = inject(CartService);

  constructor() {
    // Optional: log cart changes
    effect(() => {
      console.log('Cart updated:', this.cartService.items());
    });
  }

  remove(id: number) {
    this.cartService.removeItem(id);
  }
}
```

**How it works**:
- `CartService` holds a signal (`itemsSignal`) for cart items.
- `ProductDetailComponent` and `CartComponent` inject the same service, sharing state.
- Updates to `itemsSignal` trigger reactive UI updates.
- `computed` signals like `totalPrice` recalculate automatically.

---

## Example 4: Cart Service Using NgRx

### Install NgRx Packages
```bash
ng add @ngrx/store
ng add @ngrx/effects  # optional for async
```

### cart.actions.ts
```typescript
import { createAction, props } from '@ngrx/store';
import { CartItem } from './cart.model';

export const addItem = createAction(
  '[Cart] Add Item',
  props<{ item: CartItem }>()
);

export const removeItem = createAction(
  '[Cart] Remove Item',
  props<{ id: number }>()
);

export const clearCart = createAction('[Cart] Clear Cart');
```

### cart.reducer.ts
```typescript
import { createReducer, on } from '@ngrx/store';
import { addItem, removeItem, clearCart } from './cart.actions';
import { CartItem } from './cart.model';

export const initialState: CartItem[] = [];

export const cartReducer = createReducer(
  initialState,
  on(addItem, (state, { item }) => {
    const existing = state.find(i => i.id === item.id);
    if (existing) {
      return state.map(i =>
        i.id === item.id ? { ...i, quantity: i.quantity + item.quantity } : i
      );
    }
    return [...state, item];
  }),
  on(removeItem, (state, { id }) => state.filter(i => i.id !== id)),
  on(clearCart, () => [])
);
```

### cart.model.ts
```typescript
export interface CartItem {
  id: number;
  name: string;
  price: number;
  quantity: number;
}
```

### app.module.ts
```typescript
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { StoreModule } from '@ngrx/store';
import { cartReducer } from './cart.reducer';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    StoreModule.forRoot({ cart: cartReducer })
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
```

### product-detail.component.ts
```typescript
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { addItem } from './cart.actions';
import { CartItem } from './cart.model';

@Component({
  selector: 'app-product-detail',
  template: `
    <h2>Product Detail</h2>
    <button (click)="addToCart()">Add to Cart</button>
  `
})
export class ProductDetailComponent {
  constructor(private store: Store<{ cart: CartItem[] }>) {}

  addToCart() {
    const item: CartItem = {
      id: 1,
      name: 'Awesome Widget',
      price: 19.99,
      quantity: 1
    };
    this.store.dispatch(addItem({ item }));
    console.log('Dispatched addItem:', itemٔ);
  }
}
```

### cart.component.ts
```typescript
import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CartItem } from './cart.model';
import { removeItem } from './cart.actions';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-cart',
  template: `
    <h2>Shopping Cart</h2>
    <ul>
      <li *ngFor="let item of cart$ | async">
        {{ item.name }} - {{ item.quantity }} x ${{ item.price }}
        <button (click)="remove(item.id)">Remove</button>
      </li>
    </ul>
    <p>Total: ${{ total$ | async }}</p>
  `
})
export class CartComponent {
  cart$: Observable<CartItem[]>;
  total$: Observable<number>;

  constructor(private store: Store<{ cart: CartItem[] }>) {
    this.cart$ = store.select('cart');

    // Compute total price reactively
    this.total$ = this.cart$.pipe(
      map(items => items.reduce((sum, item) => sum + item.price * item.quantity, 0))
    );
  }

  remove(id: number) {
    this.store.dispatch(removeItem({ id }));
  }
}
```

**How NgRx Works**:
- Actions describe events (`addItem`, `removeItem`).
- Reducer updates the global store immutably.
- Store is injected into components, sharing state.
- Selectors/Observable streams enable reactive UI updates.

---

## Comparison: Signals vs NgRx for Cart

| Feature | Signals Approach | NgRx Approach |
|---------|------------------|---------------|
| Boilerplate | Minimal; just a service with signal() | Actions, reducers, store setup |
| State sharing | Simple: inject service anywhere | Simple: select from store, dispatch actions |
| Reactivity | Automatic; UI updates when signal changes | Observable streams (store.select) |
| Good for | Small-to-medium shared state like carts | Enterprise-scale state with strict patterns |
| Tooling | Dev-friendly, lightweight | Full NgRx DevTools, time-travel debugging |

---

## Signals Code Flow (Mermaid Diagram)

```mermaid
flowchart TD
    A[ProductDetailComponent] -->|addToCart()| B[CartService]
    B -->|updates signal itemsSignal| C[CartComponent]
    C -->|reactive UI update| D[Display Cart Items & Total Price]
    B -->|updates computed totalPrice| D

    style A fill:#f9f,stroke:#333,stroke-width:1px
    style B fill:#9f9,stroke:#333,stroke-width:1px
    style C fill:#9ff,stroke:#333,stroke-width:1px
    style D fill:#ff9,stroke:#333,stroke-width:1px
```

**Explanation**:
- `CartService` holds the signal for shared cart state.
- `ProductDetailComponent` updates the signal via service methods.
- `CartComponent` reacts automatically to signal changes.
- Computed signals like `totalPrice` update reactively.

---

## NgRx Code Flow (Mermaid Diagram)

```mermaid
flowchart TD
    A[ProductDetailComponent] -->|dispatch addItem action| B[Store (NgRx)]
    B -->|Reducer updates cart state| C[Cart State in Store]
    C -->|select cart$ observable| D[CartComponent]
    D -->|async pipe updates UI| E[Display Cart Items & Total Price]

    style A fill:#f9f,stroke:#333,stroke-width:1px
    style B fill:#9f9,stroke:#333,stroke-width:1px
    style C fill:#9ff,stroke:#333,stroke-width:1px
    style D fill:#ff9,stroke:#333,stroke-width:1px
    style E fill:#ffb,stroke:#333,stroke-width:_z
```

**Explanation**:
- `ProductDetailComponent` dispatches actions to the global NgRx store.
- The reducer handles state updates immutably.
- `CartComponent` subscribes via `store.select()` and updates reactively using the async pipe.
- Total price is calculated with a reactive observable stream.

---

These diagrams illustrate the reactive flow of state:
- **Signals**: Direct reactive updates via service signals.
- **NgRx**: State flows through actions → reducer → store → component.