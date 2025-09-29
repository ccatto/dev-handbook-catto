# Angular Directives and Pipes Quiz - Chapter 4 🎯

Test your knowledge of Angular directives and pipes! 🚀✨

## Question 1 📦
**Which of the following is not an Angular directive from `@angular/common`?**

- `ngFor`
- `ngSwitch`
- `ngBind`
- `ngClass`

---

## Question 2 💰
**Which of these options is the correct syntax for pipe parameters?**

- None of the above - all are incorrect

**Option A:**
```javascript
{{ amount | currency :: '$' }}
```

**Option B:**
```javascript
{{ amount | currency | 'USD' }}
```

**Option C:**
```javascript
{{ amount | currency : 'USD' }}
```

---

## Question 3 🎨
**What is the `HostBinding` decorator doing in this directive?**

```javascript
@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective {
  @HostBinding('class.highlighted') highlight = true;
}
```

- `HostBinding` does not do anything on directives, it only works with components.
- It is creating an inline style on the host element with a CSS property named `highlighted` set to true.
- It is adding the CSS class named `highlighted` to any DOM element for which the tag name is `appHighlight`.
- It is adding the CSS class named `highlighted` to any DOM element that has the `appHighlight` attribute on it.

---

## Question 4 📝
**What is the proper syntax to display a list of names in `div` elements when `display` is true?**

**Option A:**
```html
<ng-container *ngIf="display">
  <div *ngFor="let name of names">{{name}}</div>
</ng-container>
```

**Option B:**
```html
<div *ngIf="display" *ngFor="let name of names">
    {{name}}
</div>
```

**Option C:**
```html
<ng-switch *ngSwitchCase="display">
<div *ngFor="let name of names">{{name}}</div>
</ng-switch>
```

**Option D:**
```html
<ng-template *ngIf="display">
  <div *ngFor="let name of names">{{name}}</div>
</ng-template>
```

---

## Answer Key 🔑

**Q1 Answer: `ngBind`** ❌  
**Because:** `ngBind` is not a standard Angular directive from `@angular/common`. The other options (`ngFor`, `ngSwitch`, `ngClass`) are all built-in structural and attribute directives. `ngBind` was used in AngularJS (version 1.x) but is not part of modern Angular.

**Q2 Answer: `{{ amount | currency : 'USD' }}`** ✅  
**Because:** Pipe parameters use a single colon (`:`) to separate the pipe from its parameters. Multiple parameters are separated by additional colons. The syntax `currency :: '$'` uses double colons (incorrect), and `currency | 'USD'` tries to chain pipes instead of passing parameters.

**Q3 Answer: It is adding the CSS class named `highlighted` to any DOM element that has the `appHighlight` attribute on it.** 🎨  
**Because:** `@HostBinding('class.highlighted')` binds to the CSS class on the host element (the element that has the directive applied). When `highlight = true`, it adds the `highlighted` class. The directive selector `[appHighlight]` means it applies to elements with the `appHighlight` attribute.

**Q4 Answer: `<ng-container *ngIf="display"><div *ngFor="let name of names">{{name}}</div></ng-container>`** 📝  
**Because:** You cannot use two structural directives (`*ngIf` and `*ngFor`) on the same element. `ng-container` is a logical wrapper that doesn't create extra DOM elements, making it perfect for this scenario. `ng-template` would also work but `ng-container` is more appropriate here since we want the content to render directly.

---

**Key Concepts:** 💡
- **Built-in Directives:** Know which directives are part of `@angular/common`
- **Pipe Syntax:** Single colon (`:`) for parameters, double colon for chaining is incorrect
- **Host Binding:** `@HostBinding` affects the element that hosts the directive
- **Structural Directive Limitations:** Cannot combine multiple structural directives on one element
- **ng-container vs ng-template:** `ng-container` renders content directly, `ng-template` needs explicit rendering
