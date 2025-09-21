# 🎯 Add Filters to our Movies App

## Challenge Description
In this challenge, we want to **add filters** to the UI so users can search for specific movies by **title** and **year of release**. 🔍

---

## Requirements ✅
- Capture user input in the form using tools discussed in the lesson.  
  💡 **HINT:** Is this a complex form or a simple one? Use the easiest approach to get form values! ✏️  

- Use the `filterMovieList` method from `movies.service` to get an **Observable** of filtered movies based on user input.  

- Display the filtered list of movies to the user. 🎬

---

## Other Considerations ⚠️
- Do **not** remove any `data-test` attributes in the boilerplate.

---

## Example of Finished Application 🎉
The app should dynamically show the list of movies that match the user's search criteria, providing a smooth **filtering experience**.

---

## Summary 📝
By completing this challenge, you learn how to:  
- Capture user input from forms in Angular  
- Use **Observables** to filter and display data reactively  
- Dynamically update the UI based on user input 🔄

---
> official code alters from solution: 
```ts
// src/app/home/home.component.ts
export class HomeComponent {
  // old code
  // protected movies$: Observable<Movie[]> = inject(MoviesService).getMovies();
  protected favoritesService = inject(FavoritesService);

  // new code 
  private moviesService = inject(MoviesService);
  protected movies$: Observable<Movie[]> = this.moviesService.getMovies();

  filter(title: string, year: string) {
     this.movies$ = this.moviesService.filterMovieList(title, year);
  }
}


      <!-- src/app/home/home.component.html -->
      <input type="text" name="title"/>
      
      <!-- <input #titleFilter type="text" name="title"
             (input)="filter(titleFilter.value, yearFilter.value)"/> -->
      <label for="releaseDate">Release year</label>
      <!-- <input #yearFilter type="number" name="releaseDate"
             (input)="filter(titleFilter.value, yearFilter.value)"/> -->

```



----

> Attempt of updates mine: 

<!-- src/app/home/home.component.html -->
<div class="container">
  <form>
    <fieldset>
      <legend>Filters</legend>
      <label for="title">Title</label>
      <input 
        type="text" 
        id="title" 
        name="title"
        [(ngMoI've updated your Movies App to include filtering functionality. Here's what I've implemented:
Key Changes:
1. Component Updates (home.component.ts)

* Added FormsModule import for template-driven forms support
* Created filter properties (titleFilter, yearFilter) to bind to form inputs
* Implemented reactive filtering using BehaviorSubject to track filter changes
* Used combineLatest to combine both filter streams and trigger the filterMovieList service method
* Added event handler methods (onTitleChange, onYearChange) to update filters

2. Template Updates (home.component.html)

* Added proper form binding with [(ngModel)] for two-way data binding
* Added event handlers with (input) to capture user input changes
* Added proper id attributes to match the for attributes in labels
* Preserved data-test attributes as requested

How It Works:

1. User Input Capture: The form uses ngModel for two-way binding (the simple approach for basic forms as hinted)
2. Reactive Filtering: Changes to inputs trigger the BehaviorSubject streams
3. Service Integration: The component uses the existing filterMovieList method from MoviesService
4. Real-time Updates: The filtered movie list updates automatically as users type

Features:

* Real-time filtering as users type
* Title search (case-insensitive)
* Year filtering based on release date
* Maintains existing functionality for favorites and highlighting
* Preserves all data-test attributes for testing

The solution follows Angular best practices by using reactive programming with observables and maintains the existing component structure while adding the requested filtering functionality.