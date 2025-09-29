# Angular Basics 


* Angular JS vs Angular - Angular JS is old version 1 not supported any longer and Angular is the modern anything after v2;

* The Angular CLI is the go-to command line interface to generate, compile, build, and deploy Angular code.
[CLI Reference](https://angular.dev/cli)
[Angular CLI](https://angular.dev/tools/cli)

* Conventions and Style Guide

The official Angular style guide is a mine of information about best practices and how to organize your code in files and folders.

[Angular coding style guide](https://angular.dev/style-guide)

# ⚡ Angular Coding Style Guide

## 📌 Introduction

This guide covers **Angular-specific conventions** to keep your code consistent, readable, and maintainable.

> Not mandatory for Angular to work, but consistency makes collaboration easier.

**Rule of thumb:** When in doubt, follow **existing file/project style**.

---

## 🏷 Naming

* Use **hyphens** in file names: `user-profile.ts`
* Test files: append `.spec.ts` → `user-profile.spec.ts`
* Match TypeScript class names: `UserProfile` → `user-profile.ts`
* Components’ TS, HTML, CSS share the same base name
* Avoid generic names like `utils.ts` or `helpers.ts`

---

## 🗂 Project Structure

* All code lives in `src/`
* Bootstrap in `src/main.ts`
* Group **related files** together (component + template + styles + tests)
* Organize by **feature**, not type (`components/` vs `services/`)
* One main concept per file

**Example:**

```
src/
├─ movie-reel/
│ ├─ show-times/
│ │ ├─ film-calendar/
│ │ ├─ film-details/
│ ├─ reserve-tickets/
│ │ ├─ payment-info/
│ │ ├─ purchase-confirmation/
```

---

## 🧩 Dependency Injection

* Prefer `inject()` over constructor injection
* Advantages: cleaner syntax, better type inference, easier comments

---

## 🏗 Components & Directives

### Selectors

* Use application-specific prefix: `[mrTooltip]`
* Input/output properties: meaningful names

### Class Members

* Group Angular-specific properties first (inputs, outputs, DI)
* `protected` for members used only in templates
* `readonly` for immutable properties

### Templates

* Keep logic **simple** → move complex code to TS
* Prefer `[class]`/`[style]` over `ngClass`/`ngStyle`
* Event handlers: name **what they do**, not the event

### Lifecycle

* Keep hooks like `ngOnInit` simple → call helper methods
* Implement lifecycle interfaces (`OnInit`, `OnDestroy`, etc.)

---

✅ Consistency, readability, and maintainability are key.


---

# ❓ Angular Style-Guide Question

Which of the following file names **does NOT follow the Angular style-guide conventions**?

- `app.component.ts` ✅  
- `highlight-all.directive.ts` ✅  
- `uppercase-pipe.ts` ❌  
- `name.service.ts` ✅  

---

## 💡 Answer: `uppercase-pipe.ts`

### Explanation:
- Angular style-guide recommends **kebab-case** for file names: all lowercase, words separated by hyphens (`-`).  
- Pipes should follow the pattern: `[name].pipe.ts`.  

So the correct kebab-case version would be:  
```text
uppercase.pipe.ts
```

# ❓ Angular CLI Question

Which one of the following is **not a valid Angular CLI command**?

- `ng add` ✅  
- `ng fix` ❌  
- `ng build` ✅  
- `ng test` ✅  

---

## 💡 Answer: `ng fix`

### Explanation:
- Angular CLI commands allow developers to generate, build, test, and add features to Angular projects.  
- Valid commands include:
  - `ng add` → Adds a package and its dependencies to your project  
  - `ng build` → Builds your Angular project  
  - `ng test` → Runs unit tests for the project  
- ❌ `ng fix` is **not a recognized CLI command** in Angular.

> ✅ Remember: Use `ng help` to see all valid Angular CLI commands.

---

> Features of the framework
Angular is made up of many concepts, features, and APIs. In this section, we want to ensure you know the basic definitions of a component, directive, pipe, and service and that you understand how Angular differs from other technologies.

Learn about the main concepts of Angular with these resources:

[Overview of the Angular framework](https://angular.dev/overview)
[Directives vs. components: How to decide which one to use?](https://www.angulartraining.com/daily-newsletter/when-to-create-a-directive-vs-a-component/)
[Creating custom pipes](https://www.angulartraining.com/daily-newsletter/how-to-create-custom-pipes/)
[When to use services](https://www.angulartraining.com/daily-newsletter/using-services-to-cache-data/)

---

> ⚡ When to Create a Directive vs. a Component

- **Components** 🧩  
  - Used for **UI building blocks** with their own templates.  
  - Ideal when the element has **complex structure or HTML content**.  
  - Example: A card, form, or custom modal.

- **Directives** 🔧  
  - Used to **add behavior or modify existing elements**.  
  - Ideal for **small logic, attribute changes, or reusable behavior**.  
  - Example: Adding `isActive` state or a `disabled` toggle to buttons or any element.  

---

## 📝 Key Points
- Directives are **more flexible & reusable** for behavior across elements.  
- Components are **better for full templates and UI structure**.  
- Angular Material uses **directives** like `mat-button` to work with `<button>` or `<a>` tags.  
- Rule of thumb: if your "component" is just 1–2 lines of HTML with behavior, **use a directive instead**.  

# ⚡ When to Create a Directive vs. a Component

- **Components** 🧩  
  - Used for **UI building blocks** with their own templates.  
  - Ideal when the element has **complex structure or HTML content**.  
  - Example: A card, form, or custom modal.

- **Directives** 🔧  
  - Used to **add behavior or modify existing elements**.  
  - Ideal for **small logic, attribute changes, or reusable behavior**.  
  - Example: Adding `isActive` state or a `disabled` toggle to buttons or any element.  

---

## 📝 Key Points
- Directives are **more flexible & reusable** for behavior across elements.  
- Components are **better for full templates and UI structure**.  
- Angular Material uses **directives** like `mat-button` to work with `<button>` or `<a>` tags.  
- Rule of thumb: if your "component" is just 1–2 lines of HTML with behavior, **use a directive instead**.  

In Angular, many “UI elements” you see from libraries like Angular Material or PrimeNG are actually directives, not full components.

---

> 🔌 Creating Custom Pipes in Angular

- **Purpose:** Format data (strings, numbers, dates, etc.) in templates.  

---

## 1. Generate a Pipe
```bash
ng generate pipe [name]   # or ng g p [name]
ng generate pipe [name] --standalone  # for standalone pipe

---

> 🛎 Using Services to Cache Data

Services in Angular are singletons and can **cache shared data** using **BehaviorSubjects or Signals**, making it easily accessible to multiple components, directives, or pipes. ⚡

---

Angular Modules and Standalone
Angular modules (or NgModules) can be tricky to understand and are often confusing. In this lesson, let’s learn why Angular modules exist in the first place and what’s in store for them in the future with the apparition of standalone features, the default mode in new applications built with Angular 17+:

[What you need to know about Angular modules](https://www.angulartraining.com/daily-newsletter/what-you-need-to-know-about-ngmodules/)
[Config options of the NgModule decorator](https://angular.dev/api/core/NgModule)
[What are standalone components?](https://www.angulartraining.com/daily-newsletter/what-are-standalone-components/)
[PDF DOWNLOAD: Standalone components cheatsheet](https://www.angulartraining.com/daily-newsletter/what-are-standalone-components/)

---

# 📦 NgModule Decorator

**Purpose:** Marks a class as an Angular module and provides configuration metadata. ⚡

**Key Properties:**
- `providers` – Services available for DI. 🛎  
- `declarations` – Components, directives, and pipes that belong to the module. 🧩  
- `imports` – Other modules whose exported features are needed. 🔗  
- `exports` – Components, directives, and pipes to make available outside the module. 📤  
- `bootstrap` – Components to bootstrap in the app (usually only in `AppModule`). 🚀  
- `schemas` – Schema metadata for template validation. 📝  
- `id` – Optional module ID. 🆔  
- `jit` – Enables JIT compilation for this module. ⚡

**Example:**
```ts
@NgModule({
  declarations: [MyComponent],
  imports: [CommonModule],
  providers: [MyService],
  bootstrap: [AppComponent]
})
export class MyModule {}

---

> 📦 What You Need to Know About ngModules

**Summary:** ngModules were used to provide dependencies for Angular templates, but with standalone components, they are often unnecessary. ⚡

- **Purpose:** Expose components, directives, and pipes to the template compiler so features like `ngIf` and `ngFor` work. 🧩  
- **When Needed:** Historically for **shared libraries** or **lazy-loading multiple features**, but standalone components now handle both. 🔧  
- **Guidelines:** Core, shared, and feature modules are optional; too many ngModules can cause complexity and circular dependencies. ⚠️

 ---

> 🏷 Standalone Components

* Standalone components in Angular are **components, directives, or pipes that don’t belong to any NgModule**, can be imported individually, and help reduce bundle size and improve performance. ⚡

