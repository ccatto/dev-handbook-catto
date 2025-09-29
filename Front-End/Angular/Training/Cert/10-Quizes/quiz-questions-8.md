# Angular Forms Quiz - Chapter 8 📝

Test your knowledge of Angular Forms! ✅✨

## Question 1 🎛️
**Which of the following properties is NOT a valid property of an Angular `FormControl`:**

- `dirty`
- `untouched`
- `valid`
- `async`

---

## Question 2 🏗️
**What is the name of the Angular service used to create reactive forms?**

- `FormBuilder`
- `FormService`
- `FormControl`
- `FormFactory`

---

**Note:** This quiz appears to be incomplete with only 2 out of 4 questions provided. If you have the remaining questions, I'd be happy to add them!

---

## Answer Key 🔑

**Q1 Answer: `async`** ❌  
**Because:** `async` is not a valid property of `FormControl`. The valid properties include: `dirty` (form has been interacted with), `untouched` (form hasn't been touched), `valid` (passes all validation), plus others like `pristine`, `touched`, `invalid`, `pending`, `disabled`, `enabled`, `errors`, and `value`.

**Q2 Answer: `FormBuilder`** 🏗️  
**Because:** `FormBuilder` is the Angular service that provides convenient methods to create reactive form controls, groups, and arrays. It simplifies form creation with methods like `group()`, `control()`, and `array()`. The other options don't exist: `FormService`, `FormControl` (this is a class, not a service), and `FormFactory` are not real Angular services.

---

**Key Concepts:** 💡
- **FormControl Properties:** Understanding state properties like `dirty`, `touched`, `valid`, etc.
- **FormBuilder Service:** The primary service for creating reactive forms programmatically
- **Reactive vs Template-driven:** FormBuilder is specifically for reactive forms
- **Form State Management:** How Angular tracks form interaction and validation states
