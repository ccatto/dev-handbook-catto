# 🎬 Create a Component Driven by Inputs  

## 📝 Challenge Description  
In this challenge, let's **create a movie item component** that receives **Movie information** as an `@Input()` and displays it.  

---

## ✅ Requirements  
1. 📂 Open **`src/movie-item/movie-item.component.ts`**  
2. ➕ Add a **required input** of type `Movie`  
   - You can check the sample `movie` object in **`src/app.component.ts`**  
   - Use Angular's `@Input()` decorator:  
     ```ts
     @Input({ required: true }) movie!: Movie;
     ```
3. 🖊️ Update the **HTML template** to render:  
   - 🎥 **Title**  
   - 📅 **Release date** (no formatting needed)  
   - 💰 **Budget** → Display as: `$ {value} million` (e.g. `$ 50 million`)  
   - ⏱️ **Duration** → Display as: `{value} min` (e.g. `152 min`)  

4. 📄 Open **`src/app.component.html`**  
   - Pass the **sample movie** object as input to your component  

5. 👀 Verify that your component displays correctly on the screen  

---

## 💡 Hints  
- 🏗️ Use the `@Input()` decorator to make your component dynamic  
- 🧠 Review the **self-study content** if you get stuck at any step  
- 🎨 **Mini.css** is preinstalled – use it for basic styling if you want (not required)  
- ⚠️ Do **not remove any `data-test` attributes** if present in the boilerplate  

---

## 🎯 Example Finished Component  
```html
<article>
  <h2>{{ movie.title }}</h2>
  <p>📅 {{ movie.releaseDate }}</p>
  <p>💰 $ {{ movie.budget }} million</p>
  <p>⏱️ {{ movie.duration }} min</p>
</article>
```

✅ When you run the app, your movie-item component should display the correct movie details!

📝 One-Sentence Summary

Use @Input() to pass movie data from the parent component and dynamically render its details inside the movie-item component.

---

```ts
// src/app/movie-item/movie-item.component.ts

import { Component, input } from '@angular/core';
import { Movie } from '../model/movie.model';

@Component({
  selector: 'app-movie-item',
  template: `
    <div class="movie-item">
      <div>
        <h4>{{movie().title}}</h4>
        <small class="subtitle">
          <span>Release date: {{movie().release_date}}</span>
          <span>Budget: {{movie().budget}}</span>
          <span>Duration: {{movie().duration}}</span>
        </small>
      </div>
      <button>Details</button>
    </div>
  `,
  standalone: true,
  styleUrls: [ 'movie-item.component.scss' ]
})
export class MovieItemComponent {
  // @Input({required: true}) movie!: Movie;
  movie = input.required<Movie>();
}
```

Here are the key changes I made:
Updated movie-item.component.ts:

1. Added required input: Imported Input decorator and Movie model
2. Created required movie input: `@Input({ required: true }) movie!: Movie;`
3. Updated template:

* Replaced hardcoded "Test movie" with {{ movie.title }}
* Updated release date to use {{ movie.release_date }}
* Added budget display: $ {{ movie.budget }} million
* Added duration display: {{ movie.duration }} min

Updated app.component.html:

1. Added property binding: Changed <app-movie-item /> to <app-movie-item [movie]="movie" /> to pass the movie data from the parent component

The component will now display:

Title: "Harry Potter and the Philosopher's Stone"
Release date: "2001-11-04"
Budget: "$ 125 million"
Duration: "152 min"

The component properly receives the Movie object as a required input and renders all the movie information dynamically. The property binding ensures that the sample movie data from AppComponent is passed to the MovieItemComponent.


* Traditional Decorator Syntax (Angular 2+):
```ts
@Input({required: true}) movie!: Movie;
```

* New Signal-Based Syntax (Angular 17+):
```ts
movie = input.required<Movie>();
```

---
---



# 🎬 Angular Challenge: Display a List of Components

## Challenge Description
In this challenge, we display multiple instances of our `MovieItemComponent` using Angular Signals.

---

## Requirements
1. **Inject `MoviesService` into `AppComponent`.**  
   💡 HINT: Review self-study content on dependency injection if you're stuck.

2. **Retrieve a Signal of all movies** from the service.

3. **Use the `@for` block** to repeat `MovieItemComponent` as many times as needed.  
   💡 HINT: Remove any unnecessary code from your components if not needed.

---

## Other Considerations
- Do **not** remove the `data-test` attribute anywhere in the boilerplate.
- Mini.css is preinstalled and can help with styling (optional).

---

## Example of Finished Application
The completed application should dynamically render each `MovieItemComponent` for every movie in the service.  
You can mimic the style, but it’s not required. ✨


Here's the complete solution for displaying a list of components using Angular Signals:
Key Implementation Points:
🎯 Step 1: Dependency Injection
```typescript
//private moviesService = inject(MoviesService);
  protected movies: Signal<Movie[]> = inject(MoviesService).getMovies();
```

Uses the modern inject() function instead of constructor injection
Injects the MoviesService into AppComponent

🎯 Step 2: Retrieve Movies Signal
```typescript
//movies = this.moviesService.getMovies();
```

Calls the service method that returns a Signal<Movie[]>
The signal automatically updates when HTTP request completes

🎯 Step 3: @for Control Flow
```typescript
@for (movie of movies(); track movie.id) {
  <app-movie-item [movie]="movie">
  </app-movie-item>
}
```

🔧 Key Features:
✅ Signal Integration - Automatically reactive to data changes
✅ @for Control Flow - Modern Angular template syntax
✅ Track Function - Optimized rendering with track movie.id
✅ @empty Block - Handles empty state gracefully
✅ Data Test Attributes - Preserved for testing
✅ Responsive Design - Works with Mini.css grid system

