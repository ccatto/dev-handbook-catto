# Angular Lifecycle Hooks

# Overview of Lifecycle Hooks in Angular

Angular provides a set of lifecycle hooks that allow developers to tap into key moments in a component’s or directive’s lifecycle. These hooks are special methods that Angular calls automatically as the component is created, updated, and destroyed.

They are conceptually similar to **React Hooks**, but in Angular they are **class-based interfaces** that you implement.

---

## 🔹 Why Lifecycle Hooks?

* Run initialization logic when a component is created.
* Respond to changes in input properties.
* Handle async data subscriptions and clean up resources.
* Optimize performance by reacting to lifecycle events.

---

## 🔹 Common Lifecycle Hooks

| Hook | Purpose | When It Runs |
|------|---------|--------------|
| `ngOnChanges()` | Respond to input property changes | Before `ngOnInit`, whenever inputs update |
| `ngOnInit()` | Initialization logic | Once after first `ngOnChanges` |
| `ngDoCheck()` | Custom change detection logic | During every change detection cycle |
| `ngAfterContentInit()` | After content (ng-content) is projected | Once |
| `ngAfterContentChecked()` | After projected content is checked | On every check |
| `ngAfterViewInit()` | After component’s view and child views are initialized | Once |
| `ngAfterViewChecked()` | After component’s view and child views are checked | On every check |
| `ngOnDestroy()` | Cleanup logic (unsubscribe, detach listeners) | Just before Angular destroys component |

---

## 🔹 Example Component with Lifecycle Hooks

```ts
import { Component, OnInit, OnDestroy, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-sample',
  template: `<p>Sample works!</p>`
})
export class SampleComponent implements OnInit, OnDestroy, OnChanges {
  
  constructor() {
    console.log('Constructor called');
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('ngOnChanges', changes);
  }

  ngOnInit() {
    console.log('ngOnInit: Component initialized');
  }

  ngOnDestroy() {
    console.log('ngOnDestroy: Cleanup before destroy');
  }
}
```

🔹 Code Flow Diagram
```less
[ Component Created ]
        |
        v
[ Constructor ]
        |
        v
[ ngOnChanges (if inputs) ]
        |
        v
[ ngOnInit ]
        |
        v
[ ngDoCheck / ngAfterContent... / ngAfterView... ]
        |
        v
[ Component Lifecycle Loop (Change Detection) ]
        |
        v
[ ngOnDestroy (before removal) ]
```

Angular Lifecycle Hooks Best Practices
🔹 Best Practices

* Use ngOnInit instead of constructor for initialization logic.
* Always clean up subscriptions and listeners in ngOnDestroy.
* Avoid heavy logic in ngDoCheck (can hurt performance).
* Use ngOnChanges to react to input property changes.
* Keep lifecycle hooks lean — delegate heavy lifting to services.

🔹 Summary
Angular’s lifecycle hooks provide structured entry points into a component’s lifecycle. While React uses hooks as functions, Angular uses class-based lifecycle interfaces. Knowing when and how to use these hooks is essential for writing efficient, maintainable Angular applications.