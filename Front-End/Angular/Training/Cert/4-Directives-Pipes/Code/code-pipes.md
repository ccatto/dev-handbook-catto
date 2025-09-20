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

Solution Code: 

```ts
// src/app/pipes/million-dollar.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'millionDollar',
  standalone: true
})
export class MillionDollarPipe implements PipeTransform {
  // before
  //transform(value: unknown): unknown {
  // return null;

  // solution:
  transform(amount?: string | number): string {
    let range = ""+amount;
    let split = range?.split("-") ?? [];
    if (split.length > 1) {
      range = split[0] + " to $" + split[1];
    }
    return `$${ range } million`
  }
}
```

* duration pipe: 
```ts
//src/app/pipes/min-to-duration.pipe.ts
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'minToDuration',
  standalone: true
})
export class MinToDurationPipe implements PipeTransform {
  transform(minutes?: string): string {
    if (!minutes) return '';
    const hours = Math.floor(+minutes / 60);
    const min = +minutes % 60;
    return `${hours}h ${min}min`
  }
}
```

* Movie item 
```ts
// src/app/movie-item/movie-item.component.ts
import {MillionDollarPipe} from '../pipes/million-dollar.pipe';
import {MinToDurationPipe} from '../pipes/min-to-duration.pipe';

  <span>Budget:  {{ movie().budget | millionDollar }} </span>
  <span>Duration: {{ movie().duration | minToDuration }}</span>

// need to add the imports:
  imports: [
    MillionDollarPipe,
    MinToDurationPipe
  ],
```
