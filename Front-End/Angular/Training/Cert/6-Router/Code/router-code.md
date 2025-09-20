# Use the Router to Display Movie Details

## Challenge Description
In this challenge, we want to be able to display movie details by clicking on the "Details" button of any movie displayed on the screen, using the component router and lazy-loading.

---



---

## Requirements

1. **Edit the provided file:** `src/home/home.component.ts`  
   - Make it the new landing page that displays the list of movies.  

2. **Update `app.component.ts`**  
   - Display just a `<router-outlet />`.  
   - The entire page will be controlled by the router.  

3. **Update the router configuration** in `app.routes.ts` by adding two routes:  
   - Default path `""` goes to `HomeComponent` (landing page with movies list)  
   - Path `"details/:id"` lazy-loads `MovieDetailsComponent` (page with details for a single movie)  
   💡 **HINT:** Not sure how to use lazy-loading? Head back to the lesson section on lazy-loading.  

4. **Update the "Details" button** in `MovieItemComponent`  
   - Use a `routerLink` to navigate to the proper movie details.  

---

## Other Considerations

- If you see the `data-test` attribute anywhere in the boilerplate, **don't remove it**.

---

## Example of Finished Application

This is an example of what the functionality should look like for the completed exercise.  
If you’d like to mimic this style, feel free to do so, but it is not required.


----  

> Key Changes Made:

HomeComponent (src/app/home/home.component.ts):

Moved all the movie-related logic from AppComponent
Now serves as the landing page with the movies list


AppComponent (src/app/app.component.ts):

Simplified to just contain <router-outlet></router-outlet>
Imports RouterOutlet for navigation


Routes Configuration (src/app/app.routes.ts):

Added route for default path "" → HomeComponent
Added route for "details/:id" with lazy-loading using loadComponent()


MovieItemComponent (src/app/movie-item/movie-item.component.ts):

Added RouterLink import
Updated the Details button to use [routerLink]="['/details', movie().id]"


New MovieDetailsComponent:

Created as a lazy-loaded component
Displays movie details based on route parameter
Includes navigation back to home
Handles case when movie is not found
Styled for a clean, professional look



Features Implemented:

✅ Lazy-loading for MovieDetailsComponent using loadComponent()
✅ Route parameters to pass movie ID
✅ Navigation using RouterLink
✅ Error handling for non-existent movies
✅ Responsive design with clean styling
✅ Back navigation to return to movie list
✅ Preserved all data-test attributes

The app now properly routes between the home page (movie list) and individual movie details pages, with the Details component being lazy-loaded for better performance!