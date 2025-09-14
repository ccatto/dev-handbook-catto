# Angular Technical Documentation

## Basics of Angular

Angular is a **TypeScript-based open-source framework** developed and
maintained by Google. It is used for building dynamic, single-page
applications (SPAs). Angular provides powerful tools for dependency
injection, data binding, and component-driven architecture.

### Angular CLI

The Angular CLI (`@angular/cli`) is a command-line interface that helps
create, develop, scaffold, and maintain Angular applications.

**Common Commands:**

``` bash
npm install -g @angular/cli   # Install globally
ng new my-app                 # Create a new Angular project
ng serve                     # Run the application locally
ng generate component my-comp # Generate a new component
```

### Difference between Angular and AngularJS

  Aspect                 Angular (2+)                              AngularJS (1.x)
  ---------------------- ----------------------------------------- -----------------
  Language               TypeScript                                JavaScript
  Architecture           Component-based                           MVC-based
  Performance            Faster due to Ahead-of-Time compilation   Slower
  Mobile Support         Yes                                       Limited
  Dependency Injection   Built-in and robust                       Limited

### Conventions and Style Guide

-   Use **PascalCase** for components, classes, and interfaces.
-   Use **kebab-case** for file names and selectors.
-   Keep components small and focused.

### Features of the Framework

-   **Two-way data binding**
-   **Dependency injection**
-   **Reactive programming with RxJS**
-   **Directives & Pipes**
-   **Routing and lazy loading**
-   **Testing support**

------------------------------------------------------------------------

## Components

Components are the building blocks of Angular apps. Each component
controls a portion of the UI.

### Component Selector

A selector is the HTML tag you use to include the component in
templates.

``` ts
@Component({
  selector: 'app-hello',
  templateUrl: './hello.component.html'
})
export class HelloComponent {}
```

### One-way and Two-way Data Bindings

-   **One-way binding:** `{{ variableName }}` -- reads data from
    component to view.
-   **Two-way binding:** `[(ngModel)]="property"` -- syncs data between
    view and component.

### Common Decorators

-   **@Input()** -- pass data from parent to child component.
-   **@Output()** -- emit events from child to parent component.

``` ts
@Input() title: string;
@Output() clicked = new EventEmitter<string>();
```

### Template Expressions & Syntax

``` html
<p>{{ title }}</p>
<button (click)="onClick()">Click</button>
```

------------------------------------------------------------------------

## Signals

Signals are a new reactivity model in Angular.

### Creating a Signal

``` ts
import { signal } from '@angular/core';

count = signal(0);

increment() {
  this.count.set(this.count() + 1);
}
```

### Characteristics of Signals

-   Reactive state containers
-   Push-based updates
-   Easy debugging and tracking

------------------------------------------------------------------------

## TypeScript

TypeScript is a superset of JavaScript that adds static typing.

### Syntax Examples

``` ts
let age: number = 25;
let names: string[] = ['Alice', 'Bob'];

class Person {
  constructor(public name: string) {}
}

const greeting = `Hello, ${names[0]}`;
```

------------------------------------------------------------------------

## Services

Services provide reusable logic that can be injected into components.

### Dependency Injection Basics

``` ts
@Injectable({ providedIn: 'root' })
export class DataService {
  getData() { return ['Item 1', 'Item 2']; }
}
```

### Injecting a Service

``` ts
constructor(private dataService: DataService) {}
```

### When to Use Services

-   Business logic
-   API calls
-   Shared state

------------------------------------------------------------------------

## Directives

Directives are used to manipulate the DOM.

### ngIf and ngFor

``` html
<p *ngIf="isVisible">Visible</p>
<li *ngFor="let item of items">{{ item }}</li>
```

### Structural vs Attribute Directives

-   **Structural:** Change DOM structure (e.g., `*ngIf`, `*ngFor`).
-   **Attribute:** Change appearance or behavior (e.g., `[ngClass]`).

### Common Directives

-   `ngIf`
-   `ngFor`
-   `ngClass`
-   `ngStyle`

------------------------------------------------------------------------

## Router

Angular Router enables navigation between views.

### Route Configuration

``` ts
const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];
```

### Router Outlet and Router Links

``` html
<router-outlet></router-outlet>
<a routerLink="/home">Home</a>
```

### Router Guards

Guards control navigation.

``` ts
canActivate(): boolean {
  return this.authService.isLoggedIn();
}
```

------------------------------------------------------------------------

## Pipes

Pipes transform data in templates.

### Common Pipes

-   `date`
-   `currency`
-   `json`
-   `async`

### Pipe Syntax

``` html
<p>{{ birthday | date:'shortDate' }}</p>
```

### When to Use Pipes

-   Formatting data for display
-   Avoid using them for heavy computations

------------------------------------------------------------------------

## Forms

Angular supports two approaches: template-driven and reactive forms.

### CSS Classes in Forms

-   `ng-valid`, `ng-invalid`, `ng-touched`, `ng-untouched`

### AbstractControl Class

Base class for form controls providing validation state.

### Template-Driven vs Reactive Forms

  Template-Driven        Reactive
  ---------------------- ------------------------------
  Simple setup           More control
  Two-way binding        Explicit FormControl objects
  Best for small forms   Best for complex forms

------------------------------------------------------------------------

## NgModules

NgModules organize related components, services, and directives.

### NgModule Decorator

``` ts
@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
```

### AppModule

The root module that bootstraps the Angular application.
