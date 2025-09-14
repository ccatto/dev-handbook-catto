# Angular Fundamentals -- Advanced

## Architecture

-   **Container vs Presentation Components:** Separate logic-heavy
    containers from UI-only components.
-   **Lazy-loading with the Router:** Load modules on demand for
    performance.
-   **Types of NgModules:** Feature modules, CoreModule, SharedModule,
    and when to use them.
-   **Dependency Injection Providers:** Configure singleton and scoped
    services.

------------------------------------------------------------------------

## Advanced Components

-   **Content Projection:** Using `<ng-content>` to project content.
-   **Custom Two-Way Data Bindings:** Using `@Input` and `@Output`
    together.
-   **ng-template and ng-container:** Advanced dynamic templates.
-   **Sanitization of HTML Content:** Use `DomSanitizer` to avoid XSS.

------------------------------------------------------------------------

## Intermediate Components Recap

-   Template reference variables (`#var`)
-   Lifecycle hooks (`ngOnInit`, `ngAfterViewInit`)
-   ViewChild & ContentChild decorators, and signal-based equivalents
-   Standalone components

------------------------------------------------------------------------

## Signals

-   Characteristics of Signals
-   `computed()` and `effect()`
-   RxJS interoperability (`toSignal()` / `toObservable()`)

------------------------------------------------------------------------

## Dependency Injection

-   Circular dependencies and how to handle them
-   Injector hierarchy: root, module, component
-   Injection tokens and custom providers
-   Injecting DOM elements
-   `inject()` function usage

------------------------------------------------------------------------

## Advanced JavaScript / TypeScript

-   Spread syntax (`...`) for objects and arrays
-   Interfaces for type enforcement
-   Generics and creating types from types

## Intermediate TypeScript Recap

-   Union types & utility types (`Partial`, `Pick`, `Omit`)
-   Constructor syntax options
-   Enums
-   Nullish coalescing operator (`??`)

------------------------------------------------------------------------

## Performance

-   Async pipe and template syntax improvements
-   `NgFor` trackBy function
-   Tree-shaking for smaller bundles
-   Change detection strategies and Zone.js implications

------------------------------------------------------------------------

## State Management

-   Core concepts of Redux: actions, reducers, store, selectors

------------------------------------------------------------------------

## Advanced Directives

-   Directive decorator options
-   CSS selector syntax for directives
-   Structural directives and shorthand syntax (`*`)

------------------------------------------------------------------------

## Advanced Routing

-   Child routes and nested routes
-   Router outlet API
-   Router guards and resolvers

## Intermediate Routing Recap

-   Lazy-loading modules
-   Functional router guards
-   HashLocationStrategy
-   Reading route parameters

------------------------------------------------------------------------

## Advanced RxJS

-   Advanced operators (`switchMap`, `mergeMap`, `combineLatest`)
-   Reading marble diagrams
-   Subjects: `BehaviorSubject`, `ReplaySubject`, `AsyncSubject`
-   Hot vs Cold observables

------------------------------------------------------------------------

## Pipes

-   Features of the async pipe
-   Chaining multiple pipes

------------------------------------------------------------------------

## Advanced Forms

-   CSS classes and properties of Angular forms
-   Using `FormControl` directive
-   Custom form validators

------------------------------------------------------------------------

## Security

-   Router guards for route protection
-   Best practices recommended by Angular team

------------------------------------------------------------------------

## Testing

-   Angular testing utilities: `TestBed`, `ComponentFixture`,
    `DebugElement`
-   Dependency injection custom providers for mocking/stubbing
