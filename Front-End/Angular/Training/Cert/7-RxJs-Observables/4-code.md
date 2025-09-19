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

