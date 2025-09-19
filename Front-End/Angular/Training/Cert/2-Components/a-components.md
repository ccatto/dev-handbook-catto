# Components

Component Selector and Decorators
Angular components require a selector, which is how Angular knows when to render a given component.

Learn about some conventions and tips and tricks around selectors:

[Choosing a selector and using prefixes](https://angular.dev/guide/components/selectors#choosing-a-selector)
[Angular selectors are CSS selectors](https://www.angulartraining.com/daily-newsletter/the-power-of-angular-selectors/)

> 🎯 The Power of Angular Selectors

Angular selectors let directives automatically apply to **all elements that match a CSS-style selector**, making code more reusable and reducing manual attribute assignments. ⚡ You can use element names, classes, attributes, or combinations, and even exclude certain elements with exception attributes for fine-grained control. 🚀



Decorators are a way for Angular to add functionality to a class, a function, a method, or a class property. For instance, inputs and outputs are a very important feature of the framework to pass data between components:

[Accepting data with input properties](https://angular.dev/guide/components/inputs)

> 🔗 Accepting Data with Input Properties

- **Purpose:** Input properties let a component **accept data from its parent** and optionally support **two-way binding**. 🧩  
- **Signal-based Inputs:** Use `input()` or `model()` to declare properties, optionally with **default values, types, transforms, or aliases**. ⚡  
- **Decorator-based Inputs:** Use `@Input()` with optional **config, alias, getters/setters, or required enforcement**. 🎯  
- **Two-way Binding:** Model inputs automatically create a corresponding change output (`valueChange`) to sync data with the parent. 🔄  
- **Best Practices:** Avoid DOM collisions, prefer signal-based inputs, and use transforms for clean, type-safe data. ✅

[Emitting data with outputs](https://angular.dev/guide/components/outputs)

> 🎉 Custom Events with Outputs

- **Purpose:** Outputs let Angular components **emit custom events** that parents can listen to, similar to native browser events. ⚡  
- **Signal-based Outputs:** Use `output()` to declare an event property, then call `.emit()` to send data. 📨  
- **Decorator-based Outputs:** Use `@Output()` with `EventEmitter` for the same functionality. 🎯  
- **Aliases:** You can rename events for templates with the `alias` option. 🔄  

**Example (signal-based):**
```ts
@Component({/*...*/})
export class ExpandablePanel {
  panelClosed = output<void>();

  closePanel() {
    this.panelClosed.emit(); // emit the event
  }
}
```
Usage in template:
```html
<expandable-panel (panelClosed)="savePanelState()"></expandable-panel>
```


[View queries with @ViewChild](https://angular.dev/guide/components/queries#view-queries)
[Content queries with @ContentChild](https://angular.dev/guide/components/queries#content-queries)

> Angular Queries: ViewChild & ContentChild

* **View Queries:** Access elements defined in a component's own template using `viewChild()` or `viewChildren()`.

  * Updates automatically if elements change in the view.
  * Example:

  ```ts
  @Component({ template: '<child-comp></child-comp>' })
  export class ParentComp {
    header = viewChild(ChildComp);
    headerText = computed(() => this.header()?.text);
  }
  ```

* **Content Queries:** Access elements projected **inside** a component (ng-content) using `contentChild()` or `contentChildren()`.

  * Only finds elements in the **component's content**, not inside nested components.
  * Example:

  ```ts
  @Component({ template: '<ng-content></ng-content>' })
  export class ExpandoComp {
    toggle = contentChild(ToggleComp);
  }
  ```

* **Required Queries:** Use `.required` to enforce the presence of a child element.

* **QueryList:** `viewChildren` and `contentChildren` return an array-like object with `forEach`, `map`, and `changes` to react to updates.

* **Decorators:** Old-school API: `@ViewChild`, `@ViewChildren`, `@ContentChild`, `@ContentChildren`. Can use `{static: true}` to access elements earlier in lifecycle.

> Queries never cross component boundaries, and Angular keeps them updated automatically as the view or content changes.

---

## Expressions and Data Bindings
Component templates are how we display data and control when the DOM structure gets updated using expressions and data bindings. In this section, let’s refresh our knowledge of component template features:

[Understanding bindings](https://angular.dev/guide/templates/binding)
[Expressions (or interpolations)](http://angular.dev/guide/templates/binding)
[Template reference variables](https://angular.dev/guide/templates/binding#render-dynamic-text-with-text-interpolation)

💡 Pro TIP

Calling methods inside Angular expressions can have a negative impact on performance. It’s an anti-pattern.

# 🔗 Angular Bindings Overview

In Angular, **bindings** create dynamic connections between a component's template and its data. Changes in data automatically update the DOM. There are several types of bindings, but we’ll focus on **text interpolation**, **property/attribute bindings**, and **template reference variables**.

---

## 📝 Text Interpolation (Expressions)

* Use **double curly braces `{{ ... }}`** to bind dynamic text.
* Angular tracks the expressions and updates them automatically.

```ts
@Component({
  template: `<p>Your theme is {{ theme() }}.</p>`
})
export class AppComponent {
  theme = signal('dark');
}
```

**Rendered Output:**

```html
<p>Your theme is dark.</p>
```

* Interpolation works anywhere text is used and automatically converts values to strings.

---

## ⚡ Property & Attribute Bindings

* Use **square brackets `[property]="expression"`** to bind values dynamically.
* Works for **native DOM properties**, **component inputs**, and **directive properties**.

```ts
<button [disabled]="isFormValid()">Save</button>
<my-listbox [value]="mySelection()"></my-listbox>
<img [ngSrc]="profilePhotoUrl()" alt="User photo">
```

* Bind HTML attributes that don't have corresponding DOM properties with **`attr.`**:

```ts
<ul [attr.role]="listRole()">...</ul>
```

* Text interpolation can also be used in properties/attributes:

```ts
<img alt="Profile of {{ firstName() }}">
<button attr.aria-label="Save {{ objectType() }}">
```

---

## 🎨 CSS Class & Style Bindings

* Add/remove classes dynamically:

```ts
<ul [class.expanded]="isExpanded()"></ul>
<section [style.height.px]="sectionHeight()"></section>
```

* Bind multiple classes or styles using objects or arrays.

---

## 🔖 Template Reference Variables

* Template reference variables (`#varName`) allow you to **reference DOM elements** in the template.

```ts
<!-- Template -->
<input #usernameInput type="text">
<button (click)="logValue(usernameInput.value)">Log</button>
```

* These are useful for **direct DOM access** or passing elements to event handlers.

---

## ✅ Key Points

* Bindings **automatically update the DOM** when underlying signals or data change.
* **Interpolation** is best for text, **property/attribute bindings** for dynamic element/configuration changes.
* **Template reference variables** let you interact with DOM elements directly within the template.
* Angular supports **reactive updates**, ensuring the UI always reflects the current state.

---

✨ Angular makes it easy to create reactive, dynamic UIs using **bindings**, **signals**, and **template references**!

---

### Control Flow with Blocks
Control flow blocks have been introduced in Angular 17 and became stable in Angular 18. They are a great alternative to Angular directives and improve the readability of your HTML templates.

Let’s learn more about these new syntax options for control flow, called blocks:

[Introduction to the new control flow and comparison with directives](https://blog.angulartraining.com/angular-17-new-control-flow-syntax-4fbec4772d04)
[@let for local variables in Angular views](https://www.angulartraining.com/daily-newsletter/let-for-local-variables-in-angular-views/)
[@if block documentation](https://angular.dev/guide/templates/control-flow#if-block-conditionals)
[@for block documentation](https://angular.dev/guide/templates/control-flow#for-block---repeaters)
[@switch block documentation](https://angular.dev/guide/templates/control-flow#switch-block---selection)
💡 Pro TIP

Using the new control flow syntax improves performance because it relies on native Javascript code instead of importing Angular directives. Also, the @for block was optimized for performance and is proven to be much faster than *ngFor on large arrays

# Angular Control Flow Summary

Angular templates support **control flow blocks** to conditionally show, hide, or repeat elements.

## ✨ Conditional Rendering
Use `@if`, `@else-if`, `@else`:
```html
@if (a > b) {
  <p>{{a}} is greater than {{b}}</p>
} @else {
  <p>{{a}} is not greater than {{b}}</p>
}
```

You can also store results for reuse:
```html
@if (user.profile.settings.startDate; as startDate) {
  {{ startDate }}
}
```

## 🔁 Looping with @for
Loop through collections with performance optimizations:
```html
@for (item of items; track item.id) {
  {{ item.name }}
}
```

Tracking helps Angular update only necessary DOM elements. Use a unique key like `id`.

### Contextual Variables
Inside `@for`, these variables are available:
- `$count`, `$index`, `$first`, `$last`, `$even`, `$odd`

You can alias them:
```html
@for (item of items; track item.id; let idx = $index) {
  <p>Item #{{ idx }}: {{ item.name }}</p>
}
```

Provide fallback with `@empty`:
```html
@for (item of items; track item.id) {
  <li>{{ item.name }}</li>
} @empty {
  <li>No items found.</li>
}
```

## 🔀 Switch Case
Use `@switch` for multiple conditional branches:
```html
@switch (role) {
  @case ('admin') { <app-admin /> }
  @case ('user') { <app-user /> }
  @default { <app-guest /> }
}
```

---

# Angular `@for` Block – Required Option

The `@for` block in Angular requires a **`track`** expression to uniquely identify each item for efficient DOM updates.

## Example

```angular
@for (item of items; track item.id) {
  {{ item.name }}
}
```

- ✅ **`track` is required**
- 🆗 `$index`, `$count`, `$first`, `$last`, `$even`, `$odd` → optional contextual variables
- ❌ `trackBy` → old `*ngFor` syntax, **not used** in `@for`

---

**Summary:** `track` is the only required option inside `@for`, ensuring Angular can efficiently update the DOM.

---

### ❓ Question  
Which of the following options is **not** a valid Angular selector?  

- `app-header`  
- `ng-header`  
- `[header]:not(div)`  
- `.header`  

---

### ✅ Correct Answer  
**`ng-header`**  

---

### 💡 Explanation  
Angular selectors can be:  
- **Element selectors** → `app-header`  
- **Class selectors** → `.header`  
- **Attribute selectors** → `[header]` and even with pseudo-classes like `:not(div)`  

But **`ng-header`** is **not** a valid selector because Angular does not use `ng-` as a reserved element prefix (only `ng-container`, `ng-template`, etc. are special built-ins).  

---

### ❓ Question  
What is the decorator used to **pass data to a component**?  

- `@Data()`  
- `@Input()`  
- `@Prop()`  
- `@Model()`  

---

### ✅ Correct Answer  
**`@Input()`**  

---

### 💡 Explanation  
In Angular, `@Input()` is used to define a **property binding** that allows data to be passed **from a parent component to a child component**.  

Example:  

```ts
@Component({
  selector: 'child-comp',
  template: `<p>{{ title }}</p>`
})
export class ChildComponent {
  @Input() title!: string; // ✅ receives data from parent
}
```
usage: 
```html
<child-comp [title]="'Hello from Parent!'"></child-comp>
```
This makes title in the child component dynamically update whenever the parent's value changes.

---

### ❓ Question  
Which of these HTML template examples would **automatically render the latest value of `data` when `data` changes**?  

- `{data}`  
- `(click)="data"`  
- `([ngModel])="data"`  
- `[value]="data"`  

---

### ✅ Correct Answer  
**`[value]="data"`**  

---

### 💡 Explanation  
In Angular, `[value]="data"` is **property binding**.  
It binds the `value` property of the element to the component's `data` property.  
When `data` changes in the component, the UI automatically updates to reflect the new value.  

Example:  

```ts
@Component({
  selector: 'app-demo',
  template: `<input [value]="data" />`
})
export class DemoComponent {
  data = "Hello!";
}
```

✅ When this.data updates (e.g., this.data = "Updated!"), the input value updates automatically.

📝 One-Sentence Summary

Use property binding [value]="..." when you want the UI to always reflect the latest value from your component.

---

