# Signals
Signals are the new Angular recommendation to handle data in our applications. They’re easier to learn than RxJs, lightweight, and they’re more performant as they enable a [new type of change detection](https://www.angulartraining.com/daily-newsletter/angular-change-detection-illustrated/) that didn’t exist in Angular before.

Let’s dive into into Signals with these topics:

* [Creating a signal and setting its value](https://angular.dev/guide/signals#writable-signals)
* [Official definition of Signals](https://angular.dev/guide/signals#what-are-signals)
* [The computed() function](https://www.angulartraining.com/daily-newsletter/signals-computed/)
* [The effect() function](https://www.angulartraining.com/daily-newsletter/signals-effect/)
* [RxJs interoperability with Signals](https://www.angulartraining.com/daily-newsletter/rxjs-and-signals-interoperability/)
* [Signal-based components tutorial](https://blog.angulartraining.com/angular-signal-based-components-tutorial-4e4b4b1dfa96)


> Angular Signals Summary 🚀

## What are Signals? 📡

Angular Signals is a **granular state tracking system** that optimizes rendering updates by tracking how and where state is used throughout your application.

🔹 **Signal Definition**: A wrapper around a value that notifies consumers when the value changes  
🔹 **Usage**: Read values by calling the getter function `signal()`  
🔹 **Types**: Can be writable or read-only  
🔹 **Content**: Can contain any value (primitives to complex data structures)

---

## Writable Signals ✏️

Create and modify signals directly:

### Creating Writable Signals 🆕
```typescript
const count = signal(0);
console.log('The count is: ' + count()); // Reading the value
```

### Updating Values 🔄
- **Direct assignment**: `count.set(3)` 
- **Update operation**: `count.update(value => value + 1)`

**Type**: `WritableSignal`

---

## Computed Signals 🧮

Read-only signals that derive values from other signals:

### Key Features ⭐
- 🔒 **Read-only** - Cannot be directly assigned
- 🦥 **Lazy evaluation** - Only computed when first read
- 💾 **Memoized** - Cached values for performance
- 🔗 **Dynamic dependencies** - Only tracks actually read signals

### Example 📝
```typescript
const count: WritableSignal<number> = signal(0);
const doubleCount: Signal<number> = computed(() => count() * 2);
```

### Dynamic Dependencies Example 🎯
```typescript
const showCount = signal(false);
const count = signal(0);
const conditionalCount = computed(() => {
  if (showCount()) {
    return `The count is ${count()}.`;
  } else {
    return 'Nothing to see here!';
  }
});
```

---

## OnPush Components Integration 🔄

When reading signals in OnPush component templates:
- 📊 Angular automatically tracks signal dependencies
- 🔄 Components update when signal values change
- ⚡ Optimized change detection

---

## Effects 🌊

Operations that run when signal values change:

### Creating Effects 🛠️
```typescript
effect(() => {
  console.log(`The current count is: ${count()}`);
});
```

### Key Characteristics 🎯
- ✅ Always run at least once
- 🔍 Track signal dependencies dynamically
- ⏰ Execute asynchronously during change detection

### Good Use Cases ✅
- 📊 **Logging** data changes for analytics/debugging
- 💾 **localStorage** synchronization
- 🎨 **Custom DOM** behavior beyond templates
- 📈 **Third-party UI** library rendering (Canvas, charts)

### What to Avoid ❌
- 🚫 Don't use for state propagation (use computed signals instead)
- 🚫 Avoid to prevent circular updates and detection errors

---

## Injection Context 💉

### Default Usage 🏗️
Effects must be created within injection context:
```typescript
@Component({...})
export class EffectiveCounterComponent {
  readonly count = signal(0);
  constructor() {
    effect(() => {
      console.log(`The count is: ${this.count()}`);
    });
  }
}
```

### Alternative: Field Assignment 📋
```typescript
private loggingEffect = effect(() => {
  console.log(`The count is: ${this.count()}`);
});
```

### Manual Injector 🔧
```typescript
effect(() => {
  console.log(`The count is: ${this.count()}`);
}, {injector: this.injector});
```

---

## Effect Lifecycle 🔄

### Automatic Destruction 🗑️
- Effects destroyed when enclosing context is destroyed
- Component/directive/service destruction automatically cleans up effects

### Manual Destruction 🎮
```typescript
const effectRef = effect(() => {...});
effectRef.destroy(); // Manual cleanup
```

---

## Advanced Features 🚀

### Signal Equality Functions ⚖️
```typescript
import _ from 'lodash';
const data = signal(['test'], {equal: _.isEqual});
// Deep equality prevents unnecessary updates
data.set(['test']); // Won't trigger updates
```

**Default**: Uses `Object.is()` referential equality

### Untracked Reads 🚫📊
Prevent dependency tracking for specific signal reads:
```typescript
effect(() => {
  console.log(`User: ${currentUser()}, Counter: ${untracked(counter)}`);
  // Only currentUser changes trigger this effect
});
```

### Effect Cleanup Functions 🧹
Handle long-running operations:
```typescript
effect((onCleanup) => {
  const user = currentUser();
  const timer = setTimeout(() => {
    console.log(`1 second ago, the user became ${user}`);
  }, 1000);
  
  onCleanup(() => {
    clearTimeout(timer); // Cleanup on effect destruction/re-run
  });
});
```

---

## Summary Checklist ✅

- 📡 **Signals** wrap values and notify on changes
- ✏️ **Writable signals** use `.set()` and `.update()`
- 🧮 **Computed signals** are lazy, memoized, and read-only
- 🌊 **Effects** run when dependencies change
- 🔄 **OnPush components** automatically track signal dependencies
- 💉 **Injection context** required for effect creation
- 🚀 **Advanced features** include equality functions, untracked reads, and cleanup

Angular Signals provide a powerful, efficient way to manage reactive state in your applications! 🎉

--- 

### ⚡ Signals: `computed()`  
`computed()` creates a reactive Signal that automatically updates its value when one or more dependent Signals change, making it easy to derive new state without manually combining Observables. 🔄✨

### ⚡ Signals: `effect()`  
`effect()` registers a side effect that runs automatically when dependent Signals change, perfect for logging, debugging, or running code that doesn't produce a new Signal. 🔄📝

----

> Angular Signals and RxJs can interoperate: `toObservable()` turns a Signal into an Observable, and `toSignal()` turns an Observable into a Signal. 🔄

---

> ⚡ Angular Signal-Based Components

With Angular 17.3, we can now create **signal-based components**, where inputs, outputs, and queries use Angular Signals instead of RxJs. This improves **performance** and **change detection** because Angular knows exactly which parts of the DOM to update when a signal changes. 🌟

## Example: Traditional vs Signal-Based Component

```ts
// Traditional Angular Component
@Component({...})
export class HelloComponent {
  @Input() name = 'World';
  @Output() greetingClicked = new EventEmitter<string>();
  @ViewChild(ProfileComponent) profileComponent: ProfileComponent;
}

// Signal-Based Angular Component
@Component({...})
export class HelloComponent {
  name = input<string>('World');
  greetingClicked = output<string>();
  profileComponent = viewChild(ProfileComponent);
}
```

✅ Key Points

* @Input → input()
* @Output → output() (still uses .emit())
* @ViewChild → viewChild(), @ContentChild → contentChild()
* model() is available for two-way bindings 🔄

Works independently of RxJs but can interoperate using toSignal() / toObservable()

Summary: Signal-based components make Angular simpler, faster, and RxJs-free while keeping precise change detection. 🚀

----

> Lifecycle Hooks
Lifecycle hooks allow us to be notified by Angular when a component/directive reaches a specific state in its lifecycle.

Here are the most useful lifecycle hooks we need to learn about:

* [Lifecycle of Angular applications](https://www.angulartraining.com/daily-newsletter/lifecycle-of-angular-applications/)
* [ngOnDestroy lifecycle hook](https://www.angulartraining.com/daily-newsletter/ngondestroy-lifecycle-hook/)
* [ngOnChanges lifecycle hook](https://www.angulartraining.com/daily-newsletter/ngonchanges-lifecycle-hook/)
* [ngOnInit lifecycle hook](https://www.angulartraining.com/daily-newsletter/ngoninit-lifecycle-hook/)

💡 Pro TIP

Always use ngOnDestroy to unsubscribe from your RxJs Observables and prevent memory leaks. This also applies to setTimeout or setInterval, which must be canceled in ngOnDestroy.**

> 🌀 Angular Application Lifecycle

Angular components, directives, and pipes are **created when displayed** and **destroyed when removed**, while services are **singleton instances** that persist as long as the app/tab is open. 🛠️🧠 Each browser tab runs a **separate Angular app instance**, so memory and state are isolated. 🚀

> 🧹 ngOnDestroy Lifecycle Hook

The `ngOnDestroy` hook runs when a component/directive/pipe is **removed from the DOM** or the app is destroyed. 🛠️ It's perfect for **cleanup tasks** like unsubscribing from Observables, closing sockets, or clearing timers to avoid memory leaks. ⏱️🚀

> 🔄 ngOnChanges Lifecycle Hook

The `ngOnChanges` hook runs whenever a component’s **input properties change**. It provides a `SimpleChanges` object with `previousValue`, `currentValue`, and `firstChange` ✅, allowing the component to react to updates, such as fetching new data when an ID changes. 📥➡️📤

> 🚀 ngOnInit Lifecycle Hook

The `ngOnInit` hook runs **once after all `@Input()` properties are set**. Use it to perform initialization that depends on input values, while general setup can still go in the constructor. 🏁📥

---

### Other Important Topics
Some Angular component topics didn’t really fit in the previous categories (or they’d fit in several of them!) but are still important to know about for the Angular certification.

Here are these additional topics to know about:

* [Signal-based equivalents of query decorators](https://www.angulartraining.com/daily-newsletter/viewchild-and-contentchild-for-signal-based-queries/)
* [Signal-based functions for inputs, outputs, and model](https://www.angulartraining.com/daily-newsletter/whats-new-in-angular-17-1/)
* [What is ng-template?](https://blog.angulartraining.com/what-is-ng-template-and-when-to-use-it-f875b46aa078)
* [What is ng-container?]()
* [Standalone components (also covered in Angular Modules and Standalone Lesson in Chapter 1)]()


---

> 🔍 viewChild() and contentChild() for Signal-based Queries

In Angular 17+, `viewChild()` and `contentChild()` replace the old `@ViewChild` and `@ContentChild` decorators, returning **Signals** instead of undefined values.  

- `viewChild()` queries elements inside the component template.  
- `contentChild()` queries elements projected via `<ng-content>` from the parent.  

These Signals can be used with `computed()` or `effect()` to run side-effects without relying on lifecycle hooks. ⚡✨

---

# 📝 ng-template in Angular

`ng-template` is an Angular element **invisible in the DOM by default** that allows you to define reusable or conditional template blocks.  

- Often used under the hood with `*ngIf` and `*ngFor`.  
- Lets you render multiple sibling elements conditionally **without extra wrappers**.  
- Can be passed to child components as a dynamic template. ✨

**Example:**

```html
<ng-template [ngIf]="user.isLoggedIn">
  <div>Welcome to our app, {{userName}}!</div>
  <menu>Here are your options for today...</menu>
</ng-template>
```

