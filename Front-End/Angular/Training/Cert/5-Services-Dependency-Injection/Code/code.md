# Favorite Movies Challenge

## Challenge Description
In this challenge, we want to be able to manage favorite movies in the app by:

- Adding a movie as a favorite by clicking on a "star" icon ☆  
- Displaying current favorite movies by showing their "star" icon in yellow color ⭐  
- Removing a movie from our favorites by clicking again on the "star" icon ☆  

---

## Requirements

1. **Edit the provided file:** `src/services/favorites.service.ts`  
2. **Use a Signal** to store the list of current favorite movies (empty array by default).  
3. **Implement a method `toggleFavorite`** to toggle (add/remove) a movie from the list of favorites.  
   💡 **HINT:** Not sure how to work with Signals? Head back to the Signals section in Chapter 2.  
4. **Implement a method `isFavorite(movie)`** that returns whether a movie is a favorite or not.  
5. **Add inputs/outputs** to `movie-item.component.ts` to:  
   - Pass the favorite status to the component  
   - Emit an event when the "star" icon is clicked  
6. **Use the `active` CSS class** to turn the ☆ icon into ⭐. Remove the class to revert it.  
7. **Update `app.component.ts`** to handle interactions with `favorites.service.ts` and pass the favorite information to `movie-item.component.ts`.  
   🚨 **PRO TIP:** Using inputs/outputs to avoid injecting services in too many components is a fundamental architectural concept known as **presentation and container components**.  

---

## Other Considerations

- If you see the `data-test` attribute anywhere in the boilerplate, **don't remove it**.

---

## Example of Finished Application

This is an example of what the functionality should look like for the completed exercise.  
If you’d like to mimic this style, feel free to do so, but it is not required.


## CHanges:
* favorites.service.ts
```ts
export class FavoritesService {

  private favorites = signal<Movie[]>([]);

  toggleFavorite(movie: Movie): void {
    let index = this.favorites().findIndex((m) => m.id === movie.id);
    if (index == -1) {
      this.favorites.set([...this.favorites(), movie]);
    } else {
      this.favorites().splice(index, 1);
      this.favorites.set(this.favorites());
    }
  }

  isFavorite(movie: Movie): boolean {
    return this.favorites().find((m) => (m.id === movie.id)) != null;
  }
```

* movie-item.component.ts
```ts
        <h4>
          <span class="icon-star" [class.active]="isFavorite()" (click)="toggleFavorite.emit(movie())"></span>
          {{ movie().title }}
        </h4>


export class MovieItemComponent {
  movie  = input.required<Movie>();
  isFavorite = input<boolean>(false);
  toggleFavorite = output<Movie>();
}

```

* app.component.html
```html
<div class="container">
  @for(movie of movies(); track movie.id) {
    <app-movie-item [movie]="movie" appHighlight [isFavorite]="favoritesService.isFavorite(movie)" (toggleFavorite)="favoritesService.toggleFavorite(movie)"/>
  }
</div>

```

* appComponent.ts
```ts
export class AppComponent {

  protected movies: Signal<Movie[]> = inject(MoviesService).getMovies();
  protected favoritesService = inject(FavoritesService);
  ```





---

a complete solution for managing favorite movies using Angular Signals. Here's what I've included:
Key Features Implemented:
1. FavoritesService (favorites.service.ts):

Signal-based storage: Uses signal<Movie[]>([]) to store favorite movies
toggleFavorite(): Adds or removes movies from favorites based on current state
isFavorite(): Checks if a specific movie is in the favorites list
getFavorites(): Returns a read-only signal for reactive updates

2. MovieItemComponent (movie-item.component.ts):

Input properties: Receives movie data and favorite status from parent
Output events: Emits toggle events to parent component
Visual feedback: Shows ⭐ for favorites and ☆ for non-favorites
Click handler: Manages star icon clicks

3. AppComponent (app.component.ts):

Service injection: Injects both MoviesService and FavoritesService
Event handling: Handles toggle favorite events from child components
State management: Passes favorite status to movie items
Reactive updates: Uses signals for automatic UI updates

Architecture Benefits:
✅ Presentation/Container Pattern: The MovieItemComponent is a pure presentation component that doesn't directly inject services, while AppComponent acts as a container managing the business logic.
✅ Signal Reactivity: Changes to favorites automatically update the UI across all components.
✅ Type Safety: Full TypeScript support with proper interfaces and types.
✅ Performance: Efficient updates using Angular's new signal-based reactivity.
Usage:

Click the star icon (☆) to add a movie to favorites - it turns yellow (⭐)
Click the yellow star (⭐) to remove from favorites - it turns back to (☆)
The favorites list is automatically synced across the entire application

The solution follows Angular best practices and uses the modern Signal API for reactive state management!