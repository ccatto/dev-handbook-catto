# Typescript Javascript

In order to write Angular code, we need to know about JavaScript. In this lesson, we focus on some features of modern JavaScript that are essential for Angular development.

Here are the topics you want to get up to speed with:

* Variable scope: [Differences between var, let, and const](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/let)
* [Backticks and template strings](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Template_literals)
* [Destructuring assignment syntax](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Destructuring)
* [Arrow function syntax](https://www.angulartraining.com/daily-newsletter/everything-you-need-to-know-about-arrow-functions/)
* [Nullish coalescing operator](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/Nullish_coalescing)

# 📚 Template Literals (Template Strings)

Template literals are strings enclosed by backticks **`` ` ``**.  
They allow:
- 📝 **Multi-line strings**
- 🔄 **String interpolation** with `${expression}`
- 🏷 **Tagged templates** for custom processing

---

## ✨ Syntax
```js
`string text`                     // basic
`line 1
line 2`                          // multi-line
`Hello ${name}!`                 // interpolation
tagFn`Hello ${name}!`            // tagged template
```

---

# 🔓 JavaScript Destructuring

Destructuring lets you **unpack values** from arrays or objects into variables in a concise way.  
It works with assignments, function params, loops, and more.

---

## ✨ Syntax

### 📦 Array Destructuring
```js
const [a, b] = [10, 20];          // a=10, b=20
const [x, , y] = [1, 2, 3];       // skip elements
const [a = 1, b] = [];            // default values
const [a, b, ...rest] = [1, 2, 3, 4]; // rest elements → [3, 4]
```

### 🏷 Object Destructuring
```js
const { a, b } = { a: 1, b: 2 };
const { a: x, b: y } = obj;       // rename props
const { a = 5, b = 10 } = {};     // default values
const { a, ...others } = { a: 1, b: 2, c: 3 }; // rest props
```

---

## 🔑 Key Features
- 📝 **Unpack arrays/objects** directly into variables  
- ♻️ **Swap values easily:**  
  ```js
  [a, b] = [b, a];
  ```
- 🎯 **Ignore values** with commas:
  ```js
  const [a, , b] = [1, 2, 3];
  ```
- 🧩 **Nested destructuring** for deep objects/arrays
- 🛠 Works with **any iterable** (arrays, maps, sets)
- 📥 **Function params** & `for...of` loops supported

---

## 💡 Example
```js
function f() {
  return [1, 2, 3];
}
const [first, , third] = f();
console.log(first, third); // 1, 3
```

---

✅ **Takeaway:**  
Destructuring makes code **cleaner, shorter, and more expressive** when working with structured data.

---

# 🚀 Everything You Need to Know About Arrow Functions (Summary)

Arrow functions are the modern, concise way to write functions in JavaScript.  
They make code **shorter, cleaner, and easier to read**, and they handle `this` differently than regular functions.

---

## ✨ Basic Syntax

```js
const add = (a, b) => a + b;
```

✅ **Key Points:**
- **Parentheses required** when there are multiple parameters.
- For **one-liners**, the return is **implicit** — no need for `return` keyword.
- For **no parameters**, parentheses are required:  
  ```js
  const greet = () => console.log("Hello!");
  ```

---

## 🧩 Zero or One Parameter Examples

```js
// One parameter (no parentheses needed)
const square = x => x * x;

// No parameter (parentheses required)
const sayHi = () => console.log("Hi!");
```

---

## 📜 Multiple Instructions

Use curly braces `{}` and a `return` statement for multi-line logic:

```js
const getUser = (id) => {
  const user = { id, name: "Alice" };
  return user;
};
```

---

## 🎯 Why Use Arrow Functions?

1. **Concise & Readable** – Less boilerplate, cleaner syntax.
2. **Lexical `this` Binding** – Arrow functions preserve the `this` context of where they were created.
   ```js
   class Counter {
     count = 0;
     
     increment = () => {
       this.count++;
       console.log(this.count);
     }
   }
   ```
   > Regular functions would lose `this` inside event handlers, but arrow functions don't.

---

✅ **In short:**  
Use arrow functions for **concise code** and when you want `this` to refer to the surrounding scope.  
Use regular functions when you specifically want your own `this` context or need the `function` keyword (e.g., constructors).

---

# 🟰 Nullish Coalescing Operator (`??`)

The **nullish coalescing operator (`??`)** is a logical operator that returns its **right-hand side operand** only when the **left-hand side operand** is `null` or `undefined`.  
Otherwise, it simply returns the **left-hand side operand**.

---

## 📝 Syntax

```js
leftExpr ?? rightExpr
```

💡 Key Points

* ✅ Similar to the || (OR) operator, but only considers null and undefined as "empty".
* ✅ Preserves falsy values like 0, false, or "" (unlike ||).
* 🔄 Short-circuits — if the left-hand side is not nullish, the right-hand side is not evaluated.
* 🧠 Cannot be directly combined with || or && without parentheses.

🔍 Comparison with ||

```js
const count = 0;

const orResult = count || 42;   // 42 (0 is falsy)
const nullishResult = count ?? 42; // 0 (preserved ✅)
```
✅ Summary

* Use ?? to provide safe default values only when a value is null or undefined.
* Prefer ?? over || when 0, "", or false should be preserved.
* Combine with ?. for safe optional property access.

----

