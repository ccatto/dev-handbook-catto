# Angular Router Quiz - Chapter 6 🛣️

Test your knowledge of Angular routing! 🚀✨

## Question 1 🎯
**In Angular, what is the purpose of the `router-outlet` tag?**

- It indicates where routed components will be rendered
- It's a way to embed an iframe in an Angular application
- It specifies navigation links for the user
- It defines the root component of the application

---

## Question 2 🔗
**Considering the following router config, which component will be rendered when a user navigates to /products/21?**

```javascript
RouterModule.forRoot([
     { path: '', component: ProductListComponent },
     { path: 'products/:productId', component: ProductDetailsComponent }
])
```

- `ProductListComponent`
- None; there is no mapping for that route
- A 404 page would show up
- `ProductDetailsComponent`

---

## Question 3 🛡️
**Which of the following is not an existing guard function that can be used with the Angular router?**

- `CanActivateChild`
- `CanLoad`
- `CanDeactivate`
- `CanNavigate`

---

## Question 4 ⚡
**What is one requirement for this syntax to work?**

```javascript
loadComponent:
    () => import('./admin/admin.component').then(comp => comp.AdminComponent)
```

- `AdminComponent` must be the default export in its source file
- `AdminComponent` must be a standalone component
- `AdminComponent` must be in a lazy-loaded module
- This syntax does not work

---

## Answer Key 🔑

**Q1 Answer: It indicates where routed components will be rendered** 🎯  
**Because:** `<router-outlet>` is a placeholder directive that tells Angular where to display the routed components in the template. When navigation occurs, Angular dynamically loads the appropriate component and renders it inside the `router-outlet`. It's not related to iframes, navigation links, or root components.

**Q2 Answer: `ProductDetailsComponent`** 🔗  
**Because:** The route `/products/21` matches the pattern `products/:productId` where `:productId` is a route parameter. The value `21` becomes the `productId` parameter that can be accessed in `ProductDetailsComponent` via `ActivatedRoute`. The empty path `''` only matches the root route.

**Q3 Answer: `CanNavigate`** ❌  
**Because:** `CanNavigate` is not a real Angular router guard. The actual router guards are: `CanActivate`, `CanActivateChild`, `CanDeactivate`, `CanLoad`, and `Resolve`. These guards control different aspects of navigation like route activation, child route access, leaving routes, and lazy loading.

**Q4 Answer: `AdminComponent` must be a standalone component** ⚡  
**Because:** The `loadComponent` syntax is specifically for lazy-loading standalone components introduced in Angular 14+. Standalone components don't need to be declared in NgModules and can be imported directly. This syntax won't work with traditional module-based components - those require `loadChildren` with module imports.

---

**Key Concepts:** 💡
- **Router Outlet:** Acts as a placeholder for dynamically rendered routed components
- **Route Parameters:** Use `:paramName` syntax to capture dynamic route segments
- **Router Guards:** Different guards control various aspects of navigation lifecycle
- **Lazy Loading:** `loadComponent` is for standalone components, `loadChildren` for modules
- **Standalone Components:** Modern Angular pattern that eliminates the need for NgModules
