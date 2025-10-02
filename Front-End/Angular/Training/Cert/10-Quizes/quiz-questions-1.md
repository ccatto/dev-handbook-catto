Angular Framework Quiz 🅰️

> Section 1

Test your knowledge of the Angular framework with these questions! 🧠✨
Question 1 🤔
Which one of these concepts does not exist in the Angular framework?

- Structural directives
- Redux reducers
- NgModules
- Standalone components


Question 2 📊
Which of the following statements is true?

- Pipes are used to format data such as dates and numbers
- Component libraries cannot be customized to our needs
- Services link components to server-side HTML templates
- Directives are a way to interact with server-side APIs


Question 3 💻
What's the main language of the Angular framework?

- TypeScript
- AppScript
- JavaScript
- JSP


Question 4 ⚙️
Which @NgModule decorator option defines the main component of an Angular application?
Option A:
```js
bootstrap: [AppComponent]
```
Option B:
```js
start: AppComponent
```
Option C:
```js
main: [AppComponent]
```
Option D:
```js
bootstrap: AppComponent
```
[Section 2 Quiz answers](https://github.com/ccatto/dev-handbook-catto/blob/main/Front-End/Angular/Training/Cert/2-Components/d-quiz.md)





# Angular Framework Quiz - Answer Key 📋

Complete explanations for each question! 🎯✨

## Question 1 ❌
**Which one of these concepts does not exist in the Angular framework?**

### Answer: Redux reducers

**Explanation:**
Redux reducers are part of the Redux state management library, which originated in the React ecosystem. While you *can* use Redux with Angular (through libraries like NgRx), Redux reducers are not a native Angular concept.

**The other options are all core Angular concepts:**
- **Structural directives** - Built-in directives like `*ngIf`, `*ngFor` that change DOM structure
- **NgModules** - Angular's module system for organizing applications
- **Standalone components** - Modern Angular components that don't require NgModules (Angular 14+)

---

## Question 2 ✅
**Which of the following statements is true?**

### Answer: Pipes are used to format data such as dates and numbers

**Explanation:**
Angular pipes transform data for display in templates. Common examples include:
```typescript
{{ date | date:'short' }}        // Formats dates
{{ price | currency:'USD' }}     // Formats currency
{{ name | uppercase }}           // Transforms text
```

**Why the other options are false:**
- **Component libraries CAN be customized** - Most libraries provide theming and customization options
- **Services don't link to server-side HTML** - They handle business logic and data, not server templates
- **Directives manipulate DOM elements** - They don't interact with server-side APIs directly

---

## Question 3 📝
**What's the main language of the Angular framework?**

### Answer: TypeScript

**Explanation:**
While Angular applications *can* be written in JavaScript, TypeScript is the primary and recommended language because:

- **Angular itself is built in TypeScript**
- **All official documentation uses TypeScript**
- **Better tooling and IDE support**
- **Static type checking prevents runtime errors**
- **Enhanced developer experience with autocompletion**

JavaScript works but lacks the type safety and developer experience benefits that make Angular development more productive.

---

## Question 4 🚀
**Which @NgModule decorator option defines the main component of an Angular application?**

### Answer: `bootstrap: [AppComponent]`

**Explanation:**
The `bootstrap` property tells Angular which component(s) to load when the application starts. Key points:

**Why the brackets `[]` are required:**
- The `bootstrap` property expects an **array** of components
- Even with one component, you need: `bootstrap: [AppComponent]`
- Angular supports multiple bootstrap components: `bootstrap: [AppComponent, AnotherComponent]`

**Why other options are wrong:**
- `start: AppComponent` - Not a valid NgModule property
- `main: [AppComponent]` - Not a valid NgModule property  
- `bootstrap: AppComponent` - Missing required array brackets, will cause runtime error

**Example of complete NgModule:**
```typescript
@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule],
  providers: [],
  bootstrap: [AppComponent]  // Array is required!
})
export class AppModule { }
```

---

## Key Takeaways 💡

1. **Know the difference between Angular and external libraries** (Redux vs NgRx)
2. **Pipes are for data transformation** in templates
3. **TypeScript provides better development experience** than plain JavaScript
4. **NgModule properties have specific syntax requirements** - arrays where expected

Understanding these fundamentals is crucial for Angular development! 🎯

Whew some good questions;

