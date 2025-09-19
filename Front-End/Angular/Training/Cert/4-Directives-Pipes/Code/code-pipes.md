# 🎬 Movie Budget & Duration Formatting Challenge

## Challenge Description
In this challenge, we want to display **movie budgets** and **durations** using custom Angular pipes.

### Budget Formatting
- If the budget is `"175"`, render it as:  
  **`$175 million`**
- If the budget is a range such as `"175-200"`, render it as:  
  **`$175 to $200 million`**

### Duration Formatting
- Convert movie duration in minutes to a human-readable format:  
  `"92"` → **`1h 32min`**

---

## Requirements

### 1️⃣ MillionDollarPipe
- Edit: `src/pipes/million-dollar.pipe.ts`
- Implement the `transform` method to handle both single values and ranges:
  - Single value: `"175"` → `$175 million`
  - Range: `"175-200"` → `$175 to $200 million`
- 💡 **Hint:** Use `string.split()` to parse ranges.

- Add the pipe to the template in `movie-item.component.ts` so the movie budgets are displayed correctly.

### 2️⃣ MinToDurationPipe
- Edit: `src/pipes/min-to-duration.pipe.ts`
- Implement the `transform` method to convert minutes to `Xh Ymin` format:
  - Example: `"92"` → `1h 32min`

- Add the pipe to the template in `movie-item.component.ts` so the movie durations are displayed correctly.
- 💡 **Hint:** You can use modern JS features like template strings, the `??` operator, and arithmetic operations.

---

## Other Considerations
- If you see the `data-test` attribute anywhere in the boilerplate, **do not remove it**.
- Focus on the formatting logic; exact styling is optional.

---

## Example of Finished Application
This is an example of what the functionality should look like for the completed exercise.  
You may mimic this style, but it is **not required**.

