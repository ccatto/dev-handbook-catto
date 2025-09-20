# Highlight a Specific Movie in the List on Mouse Over

## Challenge Description
In this challenge, we want to highlight movies on mouse over by changing their background color to **gold**. We want to use a **custom directive** to do so.

---

## Requirements

1. **Edit the provided file:**  
   `src/highlight.directive.ts`

2. **Add functionality to the directive:**
   - Add a way for the directive to add the CSS class `highlight` to its host element on **mouse over**.  
     💡 *Hint: Review self-study content on Host Bindings and Host Listeners.*

   - Add a way for the directive to remove the CSS class `highlight` from its host element on **mouse out**.

3. **Apply the directive** on your `MovieItemComponent`.

---

## Other Considerations

- If you see the `data-test` attribute anywhere in the boilerplate, **do not remove it**.

---

## Example of Finished Application

This is an example of what the functionality should look like for the completed exercise.  
You can mimic this style if you want, but it is **not required**.

> Here is code updates: 

```ts
// src/app/highlight.directive.ts
import {Directive,HostBinding,HostListener} from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: true
})
export class HighlightDirective {

  // Added next 3:
  @HostBinding('class.highlight')
  highlight: boolean = false;

  @HostListener('mouseover')
  onMouseOver(): void {
    this.highlight = true;
  }

  @HostListener('mouseout')
  onMouseOut(): void {
    this.highlight = false;
  }
}
```

Added the appHighlight selector: 
```ts
<!-- src/app/app.component.html -->
<div class="container">
  @for(movie of movies(); track movie.id) {
    <app-movie-item [movie]="movie" appHighlight />
  }
</div>
```

