# TypeScript
TypeScript brings a lot of features to the table, and Angular relies on quite a few of these features such as decorators and class constructors.

In this lesson, we focus on the essentials of TypeScript for Angular development:

* [Definition of what is TypeScript](https://www.typescriptlang.org/)
* [Syntax for classes](https://www.typescriptlang.org/docs/handbook/2/classes.html)
* [Everyday types](https://www.typescriptlang.org/docs/handbook/2/everyday-types.html)
* [Union types and utility types](https://blog.angulartraining.com/union-types-in-typescript-2517a82a1ea0)
* [Constructor syntax options](https://www.typescriptlang.org/docs/handbook/2/classes.html#constructors)
* [Enums](https://www.typescriptlang.org/docs/handbook/enums.html#handbook-content)

---

Definition of what is TypeScript

📘 What is TypeScript?

TypeScript is an open-source programming language developed and maintained by Microsoft.

It is a superset of JavaScript, meaning all valid JavaScript code is also valid TypeScript.
The main difference is that TypeScript adds static typing, interfaces, and modern JavaScript features — making it easier to build large, scalable, and maintainable applications.

✨ Key Features

- Static Typing 🏷 – Add explicit types for variables, parameters, and return values.
- Type Inference 🔍 – TypeScript can often guess the type automatically.
- Compile-Time Error Checking 🛡 – Catches many errors before running the code.
- Modern JavaScript Features 🚀 – Supports ESNext features and transpiles them down for older browsers.
- Tooling Support 🧰 – Works seamlessly with IDEs like VS Code, providing autocompletion, refactoring, and navigation.

🧑‍💻 Example
// Example of TypeScript code

```ts
function greet(name: string): string {
  return `Hello, ${name}!`;
}
```

console.log(greet("Chris")); // ✅ Works
console.log(greet(42));      // ❌ Compile-time error

✅ Summary

TypeScript helps you write safer, more reliable, and maintainable code by catching errors early and improving the developer experience.
It compiles (or "transpiles") into plain JavaScript that runs anywhere JavaScript does — in the browser, Node.js, or other JS environments.

---

> Classes 

TypeScript enhances JavaScript classes with type annotations, supporting fields, readonly properties, constructors, methods, getters/setters, and index signatures. The strictPropertyInitialization ensures fields are initialized, and super() is required in derived classes before accessing this.
markdown# TypeScript Classes

* TypeScript supports ES2015 classes with type annotations, enabling fields, readonly properties, constructors, methods, getters/setters, and index signatures.

```ts
class Point {
  readonly x: number = 0;
  y: number;

  constructor(y = 0) {
    this.y = y;
  }

  scale(n: number): void {
    this.y *= n;
  }

  get coords(): string {
    return `${this.x}, ${this.y}`;
  }
}
```

* Fields: Public, writable, with optional initializers; strictPropertyInitialization requires constructor initialization or !.
* Readonly: Prevents reassignment outside constructor.
* Constructors: Support parameters, defaults, overloads; no type parameters or return annotations.
* Super Calls: Mandatory in derived classes before this.
* Methods: Typed like functions, use this for class members.
* Getters/Setters: Control property access; get-only is readonly.
* Index Signatures: Allow dynamic properties but are complex.

---

Everyday Types in TypeScript
TypeScript provides types for common JavaScript values, forming the basis for more complex types.
Primitives

🧵 string: Represents strings like "Hello, world".
🔢 number: Covers all numbers like 42 (no int or float).
✅ boolean: For true or false.

Use lowercase string, number, boolean instead of String, Number, Boolean.
Arrays
Use number[] or Array<number> for arrays (e.g., [1, 2, 3]). Works for any type (e.g., string[]).
any
🃏 any disables type checking, allowing any operation:
let obj: any = { x: 0 };
obj.foo();
obj = "hello";

Enable noImplicitAny to flag implicit any as errors.
Variable Type Annotations
Add type annotations after variables:
let myName: string = "Alice";

TypeScript often infers types automatically, so annotations are optional:
let myName = "Alice"; // Inferred as string

Functions
Specify parameter and return types:
function greet(name: string): void {
  console.log("Hello, " + name.toUpperCase() + "!!");
}

TypeScript checks argument types:
greet(42); // Error: Argument of type 'number' is not assignable to parameter of type 'string'.



---

> 🔗 Union & Utility Types in TypeScript

**Union Types** allow a variable to hold more than one type using the `|` operator.  
**Utility Types** are built-in helpers (like `Partial`, `Pick`, `Omit`) that transform existing types for reuse.  
They make your code safer, more flexible, and easier to maintain.

```ts
type Status = "loading" | "success" | "error"; // Union type
interface User { id: number; name: string; email?: string; }
type PartialUser = Partial<User>; // Utility type making all fields optional
```
---

# 🏗️ Constructors & Methods in TypeScript

Constructors in TypeScript initialize class instances, can have parameters with defaults, and may be overloaded, but cannot have return types or type parameters.  
For derived classes, `super()` must be called before accessing `this`.  
Methods are functions attached to class instances and support type annotations like regular functions.

```ts
class Point {
  x: number;
  y: number;

  constructor(x: number = 0, y: number = 0) {
    this.x = x;
    this.y = y;
  }

  scale(n: number): void {
    this.x *= n;
    this.y *= n;
  }
}

class DerivedPoint extends Point {
  constructor() {
    super(); // Must call before using 'this'
  }
}

```

---

# 🟢 Enums in TypeScript

Enums allow you to define a set of named constants, making code easier to read and maintain.  
TypeScript supports numeric, string, and heterogeneous enums for different use cases.

```ts
enum Direction {
  Up = "UP",
  Down = "DOWN",
  Left = "LEFT",
  Right = "RIGHT",
}

function move(dir: Direction) {
  console.log(`Moving ${dir}`);
}

move(Direction.Up); // "Moving UP"
```

