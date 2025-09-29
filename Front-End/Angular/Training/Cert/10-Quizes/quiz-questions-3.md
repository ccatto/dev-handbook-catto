# JavaScript & TypeScript Quiz - Section 3 📝

Test your JavaScript and TypeScript knowledge! 💻✨

## Question 1 ❓
**What's the value of `a` in this example?**

```javascript
let a = otherValue ?? 21
```

- `12` if `otherValue === 12`, 21 if `otherValue` is `null` or `undefined`
- `"otherValue"`
- `12` if `otherValue === 12`, 21 if `otherValue` is `{}` or `undefined`
- `12` if `otherValue == 12`, 21 if `otherValue` is `null`

---

## Question 2 🔧
**According to the following function signature:**

```javascript
function setCurrency(value: number, currency: 'USD' | 'GBP')
```

**Which of the following code examples would compile:**

**Option A:**
```javascript
setCurrency('10', 'GBP');
```

**Option B:**
```javascript
setCurrency(10, 'USD');
```

**Option C:**
```javascript
setCurrency(10);
```

- None of the above, the function syntax is incorrect

---

## Question 3 📊
**What does the following code output to the console?**

```javascript
enum UserResponse {
  No = 0,
  Yes = 1,
}

console.log(UserResponse.Yes);
```

- `Yes`
- `UserResponse.Yes`
- `[object Object]`
- `1`

---

## Question 4 🔢
**How many parameters does the following function expect?**

```javascript
function test(a, b, ...c) {
   // ...
}
```

- 2 to 5
- None, this function signature is incorrect
- exactly 3
- at least 2

---

## Answer Key 🔑

**Q1 Answer: `12` if `otherValue === 12`, 21 if `otherValue` is `null` or `undefined`** ✅  
**Because:** The nullish coalescing operator (`??`) only returns the right-hand side (21) when the left-hand side is `null` or `undefined`. Unlike the logical OR (`||`), it doesn't treat falsy values like `0`, `false`, or empty string as triggers for the fallback.

**Q2 Answer: `setCurrency(10, 'USD');`** ✅  
**Because:** This matches the TypeScript signature perfectly - `10` is a number and `'USD'` is one of the allowed string literal types. Option A fails because `'10'` is a string, not a number. Option C fails because it's missing the required `currency` parameter.

**Q3 Answer: `1`** 🔢  
**Because:** TypeScript/JavaScript enums with numeric values output their numeric value when logged. `UserResponse.Yes` is explicitly set to `1`, so `console.log(UserResponse.Yes)` outputs `1`, not the string `"Yes"`.

**Q4 Answer: at least 2** 📈  
**Because:** The function has two required parameters (`a` and `b`) and uses rest parameters (`...c`) to collect any additional arguments. So it needs a minimum of 2 parameters but can accept unlimited additional ones through the rest parameter.

---

**Key Concepts:** 💡
- **Nullish Coalescing (`??`):** Only triggers on `null`/`undefined`, not all falsy values
- **TypeScript Union Types:** String literals create strict type constraints  
- **Enums:** Numeric enums output their numeric values, not their names
- **Rest Parameters:** Allow functions to accept variable numbers of arguments beyond required ones