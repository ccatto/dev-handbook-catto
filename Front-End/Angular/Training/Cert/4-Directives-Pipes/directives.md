# Directives and Pipes

Basics of directives
Directives are a very common feature of Angular applications, and *ngIf or *ngFor can be found in pretty much every single code base.

Yet, there’s more to directives than just these two, and that’s we’re diving into in this lesson:

* ngIf and ngFor directives
* What is a structural directive?
* What is an attribute directive?
* Common Angular directives

💡 Pro TIP

Remember to use the new control flow syntax over common Angular directives in modern Angular projects. The @for block was optimized for performance and is proven to be much faster than ngFor on large arrays.

# 🅰️ Angular Directives Guide

## 🔄 ngIf and ngFor Directives

### 🎭 *ngIf Directive
The `*ngIf` directive conditionally includes or excludes an element from the DOM based on a boolean expression.

```typescript
// Component
export class MyComponent {
  showContent = true;
  user = { name: 'John', isLoggedIn: false };
}
```

```html
<!-- Basic usage -->
<div *ngIf="showContent">
  This content will only show if showContent is true
</div>

<!-- With else clause -->
<div *ngIf="user.isLoggedIn; else loginPrompt">
  Welcome back, {{ user.name }}!
</div>
<ng-template #loginPrompt>
  <div>Please log in to continue</div>
</ng-template>

<!-- With then and else -->
<div *ngIf="user.isLoggedIn; then welcomeUser else loginPrompt"></div>
```

### 🔁 *ngFor Directive
The `*ngFor` directive repeats a template for each item in a collection.

```typescript
// Component
export class MyComponent {
  items = ['Apple', 'Banana', 'Orange'];
  users = [
    { id: 1, name: 'Alice', role: 'Admin' },
    { id: 2, name: 'Bob', role: 'User' },
    { id: 3, name: 'Charlie', role: 'Moderator' }
  ];
}
```

```html
<!-- Basic usage -->
<ul>
  <li *ngFor="let item of items">{{ item }}</li>
</ul>

<!-- With index and other variables -->
<div *ngFor="let user of users; let i = index; let isFirst = first; let isLast = last; trackBy: trackByUserId">
  <p>{{ i + 1 }}. {{ user.name }} ({{ user.role }})
    <span *ngIf="isFirst">👑 First!</span>
    <span *ngIf="isLast">🏁 Last!</span>
  </p>
</div>
```

```typescript
// TrackBy function for performance
trackByUserId(index: number, user: any): number {
  return user.id;
}
```

---

## 🏗️ What is a Structural Directive?

**Structural directives** are responsible for HTML layout by adding, removing, or manipulating DOM elements. They reshape the DOM's structure.

### ✨ Key Characteristics:
- **Prefixed with an asterisk (*)** in templates
- **Add or remove elements** from the DOM
- **Can only have one structural directive** per element
- **Change the DOM structure** rather than just element properties

### 📋 Examples:
```html
<!-- These are all structural directives -->
<div *ngIf="condition">Conditionally rendered</div>
<li *ngFor="let item of items">{{ item }}</li>
<div *ngSwitch="value">
  <p *ngSwitchCase="'option1'">Option 1 content</p>
  <p *ngSwitchDefault>Default content</p>
</div>
```

### 🔧 Behind the Scenes:
Angular transforms structural directive syntax into `<ng-template>` elements:

```html
<!-- This: -->
<div *ngIf="condition">Content</div>

<!-- Becomes: -->
<ng-template [ngIf]="condition">
  <div>Content</div>
</ng-template>
```

---

## 🎨 What is an Attribute Directive?

**Attribute directives** change the appearance, behavior, or properties of existing DOM elements without altering the DOM structure.

### 🎯 Key Characteristics:
- **No asterisk prefix** in templates
- **Modify element attributes** or properties
- **Multiple attribute directives** can be applied to the same element
- **Don't add or remove elements** from the DOM

### 📋 Examples:
```html
<!-- These are all attribute directives -->
<div [ngClass]="{ 'active': isActive, 'disabled': isDisabled }">
  Dynamic classes
</div>

<p [ngStyle]="{ 'color': textColor, 'font-size': fontSize + 'px' }">
  Dynamic styles
</p>

<input [ngModel]="userName" (ngModelChange)="userName = $event">
```

### 🔧 Custom Attribute Directive Example:
```typescript
@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective {
  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('yellow');
  }

  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }
}
```

---

## 🛠️ Common Angular Directives

### 🏗️ Structural Directives

| Directive | Purpose | Example |
|-----------|---------|---------|
| **`*ngIf`** | Conditionally include/exclude elements | `<div *ngIf="isVisible">Content</div>` |
| **`*ngFor`** | Repeat template for each item | `<li *ngFor="let item of items">{{ item }}</li>` |
| **`*ngSwitch`** | Switch between multiple templates | `<div *ngSwitch="status">` |

### 🎨 Attribute Directives

| Directive | Purpose | Example |
|-----------|---------|---------|
| **`ngClass`** | Dynamically set CSS classes | `[ngClass]="{ 'active': isActive }"` |
| **`ngStyle`** | Dynamically set inline styles | `[ngStyle]="{ 'color': textColor }"` |
| **`ngModel`** | Two-way data binding for forms | `[(ngModel)]="userName"` |

### 🔧 Form Directives

| Directive | Purpose | Example |
|-----------|---------|---------|
| **`ngSubmit`** | Handle form submission | `<form (ngSubmit)="onSubmit()">` |
| **`ngForm`** | Create form control group | Applied automatically to `<form>` |
| **`required`** | Mark field as required | `<input required>` |
| **`minlength`** | Set minimum length validation | `<input minlength="3">` |

### 🎯 Event Directives

| Directive | Purpose | Example |
|-----------|---------|---------|
| **`(click)`** | Handle click events | `<button (click)="onClick()">Click me</button>` |
| **`(keyup)`** | Handle keyup events | `<input (keyup)="onKeyUp($event)">` |
| **`(focus)`** | Handle focus events | `<input (focus)="onFocus()">` |

---

## 💡 Pro Tips

### 🚀 Performance Tips:
- Use `trackBy` functions with `*ngFor` for better performance with large lists
- Prefer `*ngIf` over CSS `display: none` for conditional content
- Combine multiple conditions in `*ngIf` rather than nesting

### 🎯 Best Practices:
```html
<!-- Good: Use trackBy for performance -->
<li *ngFor="let item of items; trackBy: trackByFn">{{ item.name }}</li>

<!-- Good: Combine conditions -->
<div *ngIf="user && user.isActive && user.hasPermission">Content</div>

<!-- Good: Use meaningful template variables -->
<div *ngFor="let product of products; let isLast = last">
  <hr *ngIf="!isLast">
</div>
```

Remember: Structural directives reshape your DOM, while attribute directives enhance your elements! 🎉

---

> Custom Directives and Advanced Usage

We’ve covered the basics of Angular directives in the previous lesson, so now let’s dive into some more advanced use cases with custom directive creation, how to implement bindings in custom directives, as well as some advanced syntax options for common directives:

* When should you create custom directives vs. using components?
* HostListener and HostBinding decorators
* 5 different syntax options for ngIf
* Local variables with ngFor

---

# 🚀 Advanced Angular Directives Guide

## 🤔 When to Create Custom Directives vs. Components

### 🎯 Use Custom Directives When:

#### ✨ **Enhancing Existing Elements**
```typescript
// Perfect for directives - adding behavior to existing elements
@Directive({
  selector: '[appTooltip]'
})
export class TooltipDirective {
  @Input() appTooltip: string = '';
  // Adds tooltip functionality to ANY element
}
```

```html
<!-- Enhances existing elements -->
<button appTooltip="Click me for action">Submit</button>
<span appTooltip="User information">👤</span>
<img appTooltip="Profile picture" src="avatar.jpg">
```

#### 🎨 **Cross-cutting Concerns**
- **Styling and theming** (highlight, animations)
- **DOM manipulation** (auto-focus, scroll behavior)
- **Event handling** (click outside, drag & drop)
- **Accessibility features** (ARIA attributes)
- **Validation logic** (custom validators)

#### 🔄 **Reusable Behavior**
```typescript
// Directive for reusable behavior
@Directive({
  selector: '[appAutoFocus]'
})
export class AutoFocusDirective implements AfterViewInit {
  ngAfterViewInit() {
    this.el.nativeElement.focus();
  }
}
```

### 🏗️ Use Components When:

#### 🎭 **Complex UI Structures**
```typescript
// Perfect for components - complex UI with template
@Component({
  selector: 'app-user-card',
  template: `
    <div class="card">
      <img [src]="user.avatar" [alt]="user.name">
      <h3>{{ user.name }}</h3>
      <p>{{ user.email }}</p>
      <button (click)="onEdit()">Edit</button>
    </div>
  `
})
export class UserCardComponent {
  @Input() user: User;
  @Output() edit = new EventEmitter<User>();
}
```

#### 🧩 **Encapsulated Features**
- **Data presentation** (cards, lists, tables)
- **Form controls** (date pickers, dropdowns)
- **Business logic** (shopping cart, user profile)
- **Navigation elements** (menus, breadcrumbs)
- **Complex interactions** (modals, wizards)

### 📊 Decision Matrix

| Factor | Custom Directive ✅ | Component ✅ |
|--------|-------------------|-------------|
| **Template needed** | ❌ Simple/None | ✅ Complex HTML |
| **Styling scope** | 🎯 Element-specific | 🏠 Self-contained |
| **Reusability** | 🔄 Any element | 🧩 Specific use case |
| **Business logic** | ❌ Minimal | ✅ Complex |
| **DOM manipulation** | ✅ Direct access | ❌ Avoid direct manipulation |
| **Cross-cutting** | ✅ Perfect fit | ❌ Overkill |

---

## 🎧 HostListener and HostBinding Decorators

### 🎤 @HostListener - Event Handling

The `@HostListener` decorator allows you to listen to events on the host element or global events.

#### 🎯 Basic Syntax
```typescript
@Directive({
  selector: '[appClickTracker]'
})
export class ClickTrackerDirective {
  
  // Listen to host element events
  @HostListener('click', ['$event'])
  onClick(event: MouseEvent) {
    console.log('Element clicked!', event.target);
  }
  
  // Listen to keyboard events
  @HostListener('keydown', ['$event'])
  onKeyDown(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      console.log('Enter pressed!');
    }
  }
  
  // Listen to global window events
  @HostListener('window:resize', ['$event'])
  onWindowResize(event: Event) {
    console.log('Window resized!', window.innerWidth);
  }
  
  // Listen to document events
  @HostListener('document:click', ['$event'])
  onDocumentClick(event: MouseEvent) {
    // Useful for "click outside" functionality
    if (!this.el.nativeElement.contains(event.target)) {
      console.log('Clicked outside!');
    }
  }
}
```

#### 🚀 Advanced Examples
```typescript
@Directive({
  selector: '[appDragDrop]'
})
export class DragDropDirective {
  
  @HostListener('dragover', ['$event'])
  onDragOver(event: DragEvent) {
    event.preventDefault();
    event.stopPropagation();
  }
  
  @HostListener('dragenter', ['$event'])
  onDragEnter(event: DragEvent) {
    event.preventDefault();
    this.highlight(true);
  }
  
  @HostListener('dragleave', ['$event'])
  onDragLeave(event: DragEvent) {
    this.highlight(false);
  }
  
  @HostListener('drop', ['$event'])
  onDrop(event: DragEvent) {
    event.preventDefault();
    const files = event.dataTransfer?.files;
    if (files) {
      this.handleFiles(files);
    }
  }
}
```

### 🎨 @HostBinding - Property Binding

The `@HostBinding` decorator allows you to bind to properties of the host element.

#### 🎯 Basic Syntax
```typescript
@Directive({
  selector: '[appHighlight]'
})
export class HighlightDirective {
  
  // Bind to CSS classes
  @HostBinding('class.highlighted') isHighlighted = false;
  @HostBinding('class.active') isActive = false;
  
  // Bind to style properties
  @HostBinding('style.backgroundColor') backgroundColor: string = '';
  @HostBinding('style.border') border: string = '';
  
  // Bind to attributes
  @HostBinding('attr.aria-label') ariaLabel: string = 'Highlighted element';
  @HostBinding('attr.role') role: string = 'button';
  
  // Bind to properties
  @HostBinding('disabled') isDisabled: boolean = false;
  
  @Input() 
  set highlight(color: string) {
    this.backgroundColor = color;
    this.isHighlighted = !!color;
  }
}
```

#### 🔥 Practical Example - Button Directive
```typescript
@Directive({
  selector: '[appSmartButton]'
})
export class SmartButtonDirective {
  private _loading = false;
  private _disabled = false;
  
  @Input() 
  set loading(value: boolean) {
    this._loading = value;
    this.updateState();
  }
  
  @Input()
  set disabled(value: boolean) {
    this._disabled = value;
    this.updateState();
  }
  
  // HostBindings
  @HostBinding('class.btn-loading') get isLoading() { 
    return this._loading; 
  }
  
  @HostBinding('class.btn-disabled') get isButtonDisabled() { 
    return this._disabled; 
  }
  
  @HostBinding('attr.disabled') get disabledAttribute() {
    return this._loading || this._disabled ? true : null;
  }
  
  @HostBinding('style.cursor') get cursor() {
    return this._loading || this._disabled ? 'not-allowed' : 'pointer';
  }
  
  // HostListeners
  @HostListener('click', ['$event'])
  onClick(event: MouseEvent) {
    if (this._loading || this._disabled) {
      event.preventDefault();
      event.stopPropagation();
    }
  }
  
  private updateState() {
    // Additional logic when state changes
  }
}
```

```html
<!-- Usage -->
<button appSmartButton 
        [loading]="isSubmitting" 
        [disabled]="form.invalid">
  Submit Form
</button>
```

---

## 🔀 5 Different Syntax Options for ngIf

### 1️⃣ **Basic ngIf**
```html
<!-- Simple conditional rendering -->
<div *ngIf="isLoggedIn">
  Welcome back, user!
</div>

<p *ngIf="items.length > 0">
  You have {{ items.length }} items
</p>
```

### 2️⃣ **ngIf with Else**
```html
<!-- if-else pattern -->
<div *ngIf="user; else noUser">
  <h2>Hello, {{ user.name }}!</h2>
  <p>Email: {{ user.email }}</p>
</div>

<ng-template #noUser>
  <div class="login-prompt">
    <h2>Please log in</h2>
    <button (click)="showLogin()">Login</button>
  </div>
</ng-template>
```

### 3️⃣ **ngIf with Then and Else**
```html
<!-- Explicit then and else templates -->
<div *ngIf="isLoading; then loadingTemplate else contentTemplate"></div>

<ng-template #loadingTemplate>
  <div class="spinner">
    🔄 Loading...
  </div>
</ng-template>

<ng-template #contentTemplate>
  <div class="content">
    <h1>{{ pageTitle }}</h1>
    <p>{{ pageContent }}</p>
  </div>
</ng-template>
```

### 4️⃣ **ngIf with as (Variable Assignment)**
```html
<!-- Assign result to template variable -->
<div *ngIf="getCurrentUser() as currentUser">
  <img [src]="currentUser.avatar" [alt]="currentUser.name">
  <span>{{ currentUser.name }}</span>
  <small>{{ currentUser.role }}</small>
</div>

<!-- Useful for async data -->
<div *ngIf="userService.getUser() | async as user">
  <h2>{{ user.firstName }} {{ user.lastName }}</h2>
  <p>Last login: {{ user.lastLogin | date }}</p>
</div>

<!-- Complex expressions -->
<div *ngIf="getComplexData() as data; else loading">
  <pre>{{ data | json }}</pre>
</div>
<ng-template #loading>Loading complex data...</ng-template>
```

### 5️⃣ **Expanded ngIf Form (ng-template)**
```html
<!-- Full template syntax - useful for complex scenarios -->
<ng-template [ngIf]="showAdvancedOptions" [ngIfElse]="basicOptions">
  <div class="advanced-panel">
    <h3>Advanced Settings</h3>
    <form [formGroup]="advancedForm">
      <input formControlName="customField" placeholder="Custom value">
      <select formControlName="advancedOption">
        <option value="option1">Advanced Option 1</option>
        <option value="option2">Advanced Option 2</option>
      </select>
    </form>
  </div>
</ng-template>

<ng-template #basicOptions>
  <div class="basic-panel">
    <h3>Basic Settings</h3>
    <button (click)="showAdvancedOptions = true">
      Show Advanced Options
    </button>
  </div>
</ng-template>
```

#### 🔥 Complex Real-World Example
```html
<!-- Combining multiple techniques -->
<ng-container *ngIf="apiService.getUserData() | async as userData; else loadingUser">
  <div *ngIf="userData.isActive; then activeUser else inactiveUser"></div>
  
  <ng-template #activeUser>
    <div class="user-dashboard">
      <h1>Welcome, {{ userData.name }}! 🎉</h1>
      <div *ngIf="userData.notifications?.length > 0 as notificationCount">
        You have {{ notificationCount }} new notifications
      </div>
    </div>
  </ng-template>
  
  <ng-template #inactiveUser>
    <div class="inactive-account">
      <h2>Account Inactive</h2>
      <p>Please contact support to reactivate your account.</p>
    </div>
  </ng-template>
</ng-container>

<ng-template #loadingUser>
  <div class="loading-skeleton">
    <div class="skeleton-header"></div>
    <div class="skeleton-content"></div>
  </div>
</ng-template>
```

---

## 🔢 Local Variables with ngFor

### 🎯 All Available Local Variables

```typescript
// Component data
export class MyComponent {
  users = [
    { id: 1, name: 'Alice', role: 'Admin', active: true },
    { id: 2, name: 'Bob', role: 'User', active: false },
    { id: 3, name: 'Charlie', role: 'Moderator', active: true },
    { id: 4, name: 'Diana', role: 'User', active: true }
  ];
}
```

### 📋 Complete Local Variables Reference

```html
<div *ngFor="let user of users; 
             let i = index;
             let f = first;
             let l = last;
             let e = even;
             let o = odd;
             let c = count;
             trackBy: trackByUserId">
             
  <div class="user-card" 
       [class.first-user]="f"
       [class.last-user]="l"
       [class.even-row]="e"
       [class.odd-row]="o">
    
    <h3>
      {{ i + 1 }}. {{ user.name }}
      <span *ngIf="f">👑 First!</span>
      <span *ngIf="l">🏁 Last!</span>
    </h3>
    
    <p>Role: {{ user.role }}</p>
    <p>Position: {{ i + 1 }} of {{ c }}</p>
    <p>Status: {{ user.active ? '✅ Active' : '❌ Inactive' }}</p>
    
    <div class="meta-info">
      <small>
        Index: {{ i }} | 
        First: {{ f }} | 
        Last: {{ l }} | 
        Even: {{ e }} | 
        Odd: {{ o }} | 
        Count: {{ c }}
      </small>
    </div>
  </div>
</div>
```

### 🎨 Styling with Local Variables

```css
.user-card.first-user {
  border-top: 3px solid gold;
}

.user-card.last-user {
  border-bottom: 3px solid silver;
}

.user-card.even-row {
  background-color: #f8f9fa;
}

.user-card.odd-row {
  background-color: #ffffff;
}
```

### 🔥 Advanced Usage Examples

#### 🎯 **Conditional Separators**
```html
<div *ngFor="let item of menuItems; let isLast = last">
  <a [routerLink]="item.path">{{ item.label }}</a>
  <span *ngIf="!isLast" class="separator">|</span>
</div>
```

#### 📊 **Progress Indicators**
```html
<div class="progress-steps">
  <div *ngFor="let step of steps; let i = index; let isFirst = first; let isLast = last; let count = count" 
       class="step"
       [class.active]="i <= currentStep"
       [class.completed]="i < currentStep">
    
    <div class="step-number">{{ i + 1 }}</div>
    <div class="step-label">{{ step.title }}</div>
    
    <!-- Progress line (except for last item) -->
    <div *ngIf="!isLast" class="step-line"
         [class.completed]="i < currentStep">
    </div>
    
    <!-- Progress percentage -->
    <div *ngIf="isLast" class="progress-info">
      {{ Math.round((currentStep / (count - 1)) * 100) }}% Complete
    </div>
  </div>
</div>
```

#### 🏷️ **Dynamic Grouping**
```html
<div *ngFor="let item of groupedItems; let i = index; let isFirst = first">
  
  <!-- Group header for first item or when group changes -->
  <h3 *ngIf="isFirst || item.category !== groupedItems[i-1]?.category" 
      class="group-header">
    {{ item.category }} 📁
  </h3>
  
  <div class="item">{{ item.name }}</div>
</div>
```

#### 🎭 **Complex Templates with Multiple Variables**
```html
<table>
  <tr *ngFor="let row of tableData; 
              let rowIndex = index;
              let isEvenRow = even;
              let isFirstRow = first;
              let rowCount = count;
              trackBy: trackByRowId"
      [class.stripe]="isEvenRow"
      [class.header-row]="isFirstRow">
    
    <td *ngFor="let cell of row.cells; 
                let colIndex = index;
                let isFirstCol = first;
                let isLastCol = last"
        [class.first-column]="isFirstCol"
        [class.last-column]="isLastCol">
      
      <!-- Special formatting for first row -->
      <strong *ngIf="isFirstRow">{{ cell.value }}</strong>
      <span *ngIf="!isFirstRow">{{ cell.value }}</span>
      
      <!-- Row and column indicators -->
      <small class="cell-info">
        R{{ rowIndex + 1 }}C{{ colIndex + 1 }}
      </small>
    </td>
    
    <!-- Row summary in last column -->
    <td class="row-summary">
      Row {{ rowIndex + 1 }} of {{ rowCount }}
    </td>
  </tr>
</table>
```

### 🚀 Performance Tips with TrackBy

```typescript
// Component
export class MyComponent {
  items = [/* your data */];
  
  // Efficient tracking by unique identifier
  trackByItemId(index: number, item: any): number {
    return item.id;
  }
  
  // Track by index for simple arrays
  trackByIndex(index: number): number {
    return index;
  }
  
  // Complex tracking function
  trackByMultipleFields(index: number, item: any): string {
    return `${item.id}-${item.lastModified}`;
  }
}
```

```html
<!-- Use trackBy for better performance -->
<div *ngFor="let item of items; trackBy: trackByItemId; let i = index">
  {{ i }}. {{ item.name }}
</div>
```

## 💡 Pro Tips

### 🎯 **Best Practices**
- Use **directives** for DOM manipulation and cross-cutting concerns
- Use **components** for complex UI and business logic
- Combine `@HostListener` and `@HostBinding` for powerful directive behavior
- Use `trackBy` functions with `*ngFor` for optimal performance
- Leverage local variables to avoid complex template expressions

### ⚡ **Performance Notes**
- `*ngIf` with `as` prevents multiple function calls
- TrackBy functions prevent unnecessary DOM updates
- Local variables are more efficient than method calls in templates

Remember: Choose the right tool for the right job! 🎯

---

