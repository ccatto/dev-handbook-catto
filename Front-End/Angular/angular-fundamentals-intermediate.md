# Angular Fundamentals -- Intermediate

## Basics of Angular

Angular is a powerful front-end framework for building scalable
single-page applications. It leverages TypeScript and provides a
structured way to build modular and maintainable apps.

### Angular CLI

The Angular CLI helps scaffold projects, generate files, and run
development servers efficiently.

``` bash
ng new my-app
ng serve
ng generate component my-component
```

### Difference Between Angular and AngularJS

  Feature          Angular (2+)                                 AngularJS (1.x)
  ---------------- -------------------------------------------- -----------------
  Language         TypeScript                                   JavaScript
  Architecture     Component-based                              MVC-based
  Performance      High, uses Ahead-of-Time (AOT) compilation   Slower
  Mobile Support   Yes                                          Limited

### Conventions and Style Guide

-   Use **kebab-case** for selectors, **PascalCase** for
    components/classes.
-   Keep components small and focused on one task.
-   Follow Angular's official style guide for consistency.

### Features of the Framework

-   Component-based architecture
-   Dependency Injection
-   RxJS Observables for reactivity
-   Directives, Pipes, Routing, Forms, and more

------------------------------------------------------------------------

## Basics of Components

Components control a portion of the UI.

### Component Selector

``` ts
@Component({
  selector: 'app-hero',
  templateUrl: './hero.component.html'
})
export class HeroComponent {}
```

### One-way & Two-way Data Binding

``` html
<!-- One-way -->
<p>{{ heroName }}</p>

<!-- Two-way -->
<input [(ngModel)]="heroName">
```

### Common Decorators

``` ts
@Input() heroName: string;
@Output() heroSelected = new EventEmitter<string>();
```

### Template Expressions

``` html
<p>{{ heroName.toUpperCase() }}</p>
<button (click)="selectHero()">Select</button>
```

------------------------------------------------------------------------

## Signals

Signals provide fine-grained reactivity.

### Creating and Updating a Signal

``` ts
import { signal } from '@angular/core';

count = signal(0);
increment() {
  this.count.set(this.count() + 1);
}
```

### computed() and effect()

``` ts
import { computed, effect } from '@angular/core';

total = computed(() => this.count() * 2);
constructor() {
  effect(() => console.log(this.total()));
}
```

### RxJS Interoperability

Signals can interop with Observables via `toSignal()` and
`toObservable()`.

------------------------------------------------------------------------

## Intermediate Components

-   **Template Reference Variables:** `#myInput`
-   **Lifecycle Hooks:** `ngOnInit()`, `ngOnDestroy()`, etc.
-   **ViewChild & ContentChild:**

``` ts
@ViewChild('myInput') inputElement!: ElementRef;
```

-   **ng-template vs ng-container:** Use `ng-template` for template
    blocks, `ng-container` for grouping elements without extra DOM.
-   **Standalone Components:** Components that don't require inclusion
    in an NgModule.

------------------------------------------------------------------------

## TypeScript Basics

``` ts
let age: number = 30;
let names: string[] = ['Alice', 'Bob'];

class Person {
  constructor(public name: string) {}
}

const greeting = `Hello, ${names[0]}`;
```

## Intermediate TypeScript

-   **Union Types:** `let value: string | number;`
-   **Utility Types:** `Partial<T>`, `Pick<T, K>`
-   **Enums:**

``` ts
enum Status { Active, Inactive }
```

-   **Nullish Coalescing:** `let result = input ?? 'default';`

------------------------------------------------------------------------

## Intermediate JavaScript

-   `let` and `const` provide block scope.
-   Destructuring:

``` ts
const {name, age} = person;
```

-   Arrow functions:

``` ts
const add = (a: number, b: number) => a + b;
```

------------------------------------------------------------------------

## Services

``` ts
@Injectable({ providedIn: 'root' })
export class DataService {
  getData() { return ['A', 'B', 'C']; }
}
```

Inject service into component:

``` ts
constructor(private dataService: DataService) {}
```

------------------------------------------------------------------------

## Basics of Directives

``` html
<p *ngIf="isVisible">Visible</p>
<li *ngFor="let item of items">{{ item }}</li>
```

## Intermediate Directives

-   **HostListener & HostBinding:**

``` ts
@HostListener('click') onClick() { console.log('Clicked!'); }
@HostBinding('class.active') isActive = true;
```

------------------------------------------------------------------------

## Basics of Routing

``` ts
const routes: Routes = [
  { path: 'home', component: HomeComponent },
];
```

## Intermediate Routing

-   **Lazy Loading:** Load modules only when needed.
-   **Functional Guards:** `canActivate: [() => isLoggedIn()]`
-   **HashLocationStrategy:** for hash-based URLs.
-   **Route Parameters:** `this.route.snapshot.paramMap.get('id')`

------------------------------------------------------------------------

## RxJS

-   **Observables:** Streams of data that can be subscribed to.
-   **Operators:** `map`, `filter`, `switchMap`

``` ts
this.http.get('/api/data').pipe(map(res => res.items));
```

-   Always unsubscribe to avoid memory leaks.

------------------------------------------------------------------------

## Basics of Pipes

``` html
<p>{{ birthday | date:'shortDate' }}</p>
```

### Custom Pipe Example

``` ts
@Pipe({ name: 'capitalize' })
export class CapitalizePipe implements PipeTransform {
  transform(value: string): string {
    return value.charAt(0).toUpperCase() + value.slice(1);
  }
}
```

------------------------------------------------------------------------

## Forms

-   **CSS Classes:** `ng-valid`, `ng-invalid`
-   **Reactive Forms:** Use `FormControl` and `FormGroup`.

``` ts
this.form = new FormGroup({
  name: new FormControl('')
});
```

------------------------------------------------------------------------

## NgModules

``` ts
@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, FormsModule],
  bootstrap: [AppComponent]
})
export class AppModule {}
```
