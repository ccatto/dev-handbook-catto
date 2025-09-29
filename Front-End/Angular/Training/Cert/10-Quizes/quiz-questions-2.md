# Angular Framework Quiz - Part 2 🅰️

Test your advanced Angular knowledge with these questions! 🚀✨

## Question 1 🔄
**Which @for block option is required?**

- `trackBy`
- `count`
- `track`
- `$index`

---

## Question 2 🏷️
**Which of the following options is not a valid Angular selector?**

- `ng-header`
- `app-header`
- `.header`
- `[header]:not(div)`

---

## Question 3 📥
**What is the decorator used to pass data to a component?**

- `@Prop()`
- `@Data()`
- `@Input()`
- `@Model()`

---

## Question 4 🔄
**Which of these HTML template examples would automatically render the latest value of `data` when `data` changes?**

**Option A:**
```javascript
([ngModel])="data"
```

**Option B:**
```javascript
[value]="data"
```

**Option C:**
```javascript
{data}
```

**Option D:**
```javascript
(click)="data"
```

---

## Question 5 🏗️
**The following syntax does not compile:**

```html
<div *ngIf="showItems" *ngFor="let item of items">{{item}}</div>
```

**Which alternative syntax would generate the exact same DOM structure as intended above?**

**Option A:**
```html
<ng-template *ngIf="showItems">
  <div *ngFor="let item of items">{{item}}</div>
</ng-template>
```

**Option B:**
```html
<div [hidden]="! showItems" *ngFor="let item of items">{{item}}</div>
```

**Option C:**
```html
<ng-container *ngIf="showItems">
  <div *ngFor="let item of items">{{item}}</div>
</ng-container>
```

**Option D:**
```html
<div *ngIf="showItems">
  <span *ngFor="let item of items">{{item}}</span>
</div>
```

---

## Question 6 👁️
**What is the purpose of the ViewChild decorator in this component example?**

```typescript
@Component({
  ...
  template: '<p #test></p>'
})
export class UserDetailsComponent {
  @ViewChild('test') test;
}
```

- It provides access from within the component class to the ElementRef object for the `<p>` tag that has the test template reference variable.
- It makes the `<p>` tag in the template support content projection.
- It makes the `<p>` tag visible in the final render. If @ViewChild was not used in the class, then Angular would automatically hide the `<p>` tag that has #test on it.
- It indicates that the `<p>` tag be rendered as a child of the parent view that uses this component.

---

## Question 7 📡
**Which of the following functions is not a part of the Signals API?**

- `computed()`
- `effect()`
- `observable()`
- `signal()`

---

Good luck with your advanced Angular quiz! 🎯💪

Part 2 Answers 🅰️
Q1 Answer: track 🎯
Because: In Angular's new control flow @for syntax, the track expression is required for performance optimization. It helps Angular identify which items have changed. Example: @for (item of items; track item.id) { ... }
Q2 Answer: ng-header ❌
Because: Angular selectors starting with ng- are reserved for Angular's own components and directives. Custom components should use prefixes like app-, class selectors (.header), and attribute selectors ([header]:not(div)) are all valid.
Q3 Answer: @Input() 📥
Because: @Input() is Angular's decorator for receiving data from parent components. The other decorators (@Prop(), @Data(), @Model()) don't exist in Angular - @Prop() is from Vue.js.
Q4 Answer: [value]="data" 🔄
Because: Property binding [value]="data" creates a one-way data binding that automatically updates when data changes. The other options are invalid: ([ngModel]) has wrong syntax, {data} should be {{data}} for interpolation, and (click) is for event binding.
Q5 Answer: <ng-container *ngIf="showItems"><div *ngFor="let item of items">{{item}}</div></ng-container> 🏗️
Because: You can't use two structural directives on the same element. ng-container is a logical container that doesn't create extra DOM elements, making it perfect for wrapping structural directives. The other options either change the DOM structure or use different logic ([hidden] vs *ngIf).
Q6 Answer: It provides access from within the component class to the ElementRef object for the <p> tag that has the test template reference variable. 👁️
Because: @ViewChild('test') gives you programmatic access to DOM elements or child components in your TypeScript code. It finds the element with template reference variable #test and makes it accessible as this.test in the component class.
Q7 Answer: observable() 📡
Because: Angular Signals API includes signal(), computed(), and effect() functions. observable() is from RxJS, not the Signals API. Signals are Angular's new reactivity system, separate from RxJS observables.

Key Takeaways: 💡

Angular has specific syntax requirements (arrays, decorators, selectors)
TypeScript is the preferred language for better tooling
Structural directives have limitations and workarounds
New features like Signals and control flow are modernizing Angular
Understanding the difference between Angular concepts and external libraries is crucial


[Section 2 Answers](https://github.com/ccatto/dev-handbook-catto/blob/main/Front-End/Angular/Training/Cert/2-Components/d-quiz.md)

