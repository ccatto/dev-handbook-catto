# Use the Router to Display Movie Details

## Challenge Description
In this challenge, we want to be able to display movie details by clicking on the "Details" button of any movie displayed on the screen, using the component router and lazy-loading.

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

