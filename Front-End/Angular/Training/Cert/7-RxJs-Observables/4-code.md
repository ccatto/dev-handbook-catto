# Code: 

# 🎬 Use RxJS Observables to Display Data

## Challenge Description
In this challenge, our lead developer decided to update `movies.service.ts` to return **Observables** instead of **Signals**. As a result, we need to update our components to work with Observables. 🔄

---

## Requirements ✅
- Update `src/home/home.component.ts` to handle the new Observable and render the list of all movies.  
  💡 **HINT:** Remember the `async` pipe? Now is a perfect time to use it! ⏳  

- Update `MovieDetailsComponent` to handle the new Observable and render movie details.  

- The app should function just like before with **no visible difference** to the user. 👀

---

## Other Considerations ⚠️
- Do **not** remove any `data-test` attributes present in the boilerplate.

---

## Example of Finished Application 🎉
The finished app should work identically to the previous version, but now it uses **Observables** internally for reactive data handling.  

---

## Summary 📝
By completing this challenge, you learn how to:  
- Convert components from using Signals to **Observables**  
- Use the Angular `async` pipe to automatically subscribe and render Observable data  
- Keep your app reactive without changing the user experience 🚀


--- 

> 0 Solution recommended 

  // src/app/home/home.component.ts
  ```ts
// add 
import {Observable} from 'rxjs';
import {AsyncPipe} from '@angular/common';

    imports: [
        HighlightDirective,
        MovieItemComponent
        // add in imports
        , AsyncPipe

export class HomeComponent {

  // change from:
  // protected movies: Signal<Movie[]> = inject(MoviesService).getMovies();
  // protected favoritesService = inject(FavoritesService);

  // change to: 
  protected movies$: Observable<Movie[]> = inject(MoviesService).getMovies();
  protected favoritesService = inject(FavoritesService);
``

movie-details.component.ts
in the template we devin movie var and change from movie() function to movie var
```ts
    @let movie = movie$ | async;
    <h1>{{ movie?.title }}</h1>
    <div class="details">
      @if (movie?.poster) {
        <img [ngSrc]="movie?.poster || ''" width="200" height="100" alt="Poster">
      }
      <div>
        <p>
          <span>Summary: </span>
          <span>{{ movie?.summary }}</span>


  // // original:
  // template: `
  //   @let movie = movie$ | async;
  //   <h1>{{ movie()?.title }}</h1>
  //   <div class="details">
  //     @if (movie()?.poster) {
  //       <img [ngSrc]="movie()?.poster || ''" width="200" height="100" alt="Poster">
  //     }
  //     <div>
  //       <p>
  //         <span>Summary: </span>
  //         <span>{{ movie()?.summary }}</span>
  //       </p>

// add async to both imports:
  imports: [ NgOptimizedImage, MillionDollarPipe, MinToDurationPipe
    , AsyncPipe

```


---

> 1st attempt Solution:
Here are the key changes I made to update both components to work with RxJS Observables:
Home Component Changes:

Added AsyncPipe import - Required to handle Observables in templates
Changed property name - From movies to movies$ (following Observable naming convention)
Updated type - From Signal<Movie[]> to Observable<Movie[]>
Removed Signal import - No longer needed

Movie Details Component Changes:

Added AsyncPipe import - Required to handle Observables in templates
Changed property name - From movie to movie$ (following Observable naming convention)
Updated type - From Signal to Observable<MovieDetails>
Updated template - Used @if (movie$ | async; as movie) pattern to:

Subscribe to the Observable using the async pipe
Create a local template variable movie for easier access
Handle the asynchronous nature of the data



Template Usage:
You'll need to update your home.component.html template to use the async pipe with the new movies$ property:
```html
<!-- Replace movies() with movies$ | async in your template -->
@for (movie of movies$ | async; track movie.id) {
  <!-- your movie items -->
}
```
The async pipe automatically:

Subscribes to the Observable when the component initializes
Unsubscribes when the component is destroyed
Updates the view when new data is emitted
Handles the loading state gracefully

Both components will now work seamlessly with the updated MoviesService that returns Observables instead of Signals, maintaining the same user experience as before. 