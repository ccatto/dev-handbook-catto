# Quiz

# TypeScript / JavaScript Quiz with Answers

---

### 1️⃣ What's the value of `a` in this example?

```ts
let a = otherValue ?? 21;
```
Correct Answer:
D) 12 if otherValue === 12, 21 if otherValue is null or undefined

Explanation:
The nullish coalescing operator (??) only returns the right-hand side if the left-hand side is null or undefined. Other falsy values like 0 or '' are preserved.


> 2 2️⃣ According to the following function signature:
```ts
function setCurrency(value: number, currency: 'USD' | 'GBP') {}
```


Which of the following code examples would compile?

setCurrency('10', 'GBP');

setCurrency(10);

None of the above, the function syntax is incorrect

setCurrency(10, 'USD'); ✅

Explanation:
The function expects a number as the first argument and either 'USD' or 'GBP' as the second. Only setCurrency(10, 'USD') satisfies both types.


> 3
```ts
function test(a, b, ...c) {
   // ...
}
```
a → first parameter

b → second parameter

...c → rest parameter, which collects all remaining arguments into an array

✅ Answer: The function expects at least 2 parameters (a and b). Any additional arguments will be captured in the rest parameter c.

So in short:

Mandatory parameters: 2 (a and b)

Optional/variable parameters: 0 or more (c)

You could call it like this:


> 4  What does the following code output to the console?
```ts
enum UserResponse {
  No = 0,
  Yes = 1,
}

console.log(UserResponse.Yes);
```


Correct Answer:
D) 1

Explanation:
UserResponse.Yes refers to the numeric value assigned to that enum member, which is 1.

