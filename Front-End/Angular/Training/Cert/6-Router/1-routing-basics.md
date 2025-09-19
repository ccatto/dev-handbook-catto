# Router

# 🧭 Angular Routing Basics Complete Guide

> 🚀 **The Angular Router allows users to move between components and views while maintaining the illusion of a traditional multi-page website, all in the browser without involving any server-side navigation.**

## 🎯 What is Angular Routing?

**Angular Routing** is a powerful navigation system that enables Single Page Application (SPA) functionality. It allows users to navigate between different views/components while keeping the application running in a single browser page, providing a seamless user experience.

### 🔄 **SPA Navigation Flow**
```
Traditional Multi-Page App:
User clicks link → Server request → New page loads → Full page refresh

Angular SPA with Routing:
User clicks link → Route change → Component swap → No page refresh ✨
```

---

## ⚙️ Basics of Route Configuration

### 🏗️ **Setting Up Basic Routes**

#### 📦 **App Routing Module (Traditional)**
```typescript
// app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { ProductsComponent } from './components/products/products.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

const routes: Routes = [
  { path: '', component: HomeComponent },                    // Default route
  { path: 'home', component: HomeComponent },                // Home page
  { path: 'about', component: AboutComponent },              // About page
  { path: 'contact', component: ContactComponent },          // Contact page
  { path: 'products', component: ProductsComponent },        // Products page
  { path: '**', component: NotFoundComponent }               // Wildcard route (404)
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
```

#### 🆕 **Standalone App Routing (Modern)**
```typescript
// main.ts
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter } from '@angular/router';
import { AppComponent } from './app.component';

const routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'products', component: ProductsComponent },
  { path: '**', component: NotFoundComponent }
];

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes)
    // Other providers...
  ]
});
```

### 🎯 **Route Configuration Options**

#### 🔗 **Path Patterns**
```typescript
const routes: Routes = [
  // Static paths
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  
  // Empty path - default route
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  
  // Path with parameters
  { path: 'user/:id', component: UserProfileComponent },
  { path: 'product/:id/:category', component: ProductDetailComponent },
  
  // Optional parameters
  { path: 'search/:term/:category?', component: SearchComponent },
  
  // Query parameters (handled automatically)
  // /products?category=electronics&sort=price
  { path: 'products', component: ProductsComponent },
  
  // Wildcard route - must be LAST
  { path: '**', component: NotFoundComponent }
];
```

#### 🏠 **Redirects and Aliases**
```typescript
const routes: Routes = [
  // Redirect to another route
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  
  // Multiple paths to same component
  { path: 'home', component: HomeComponent },
  { path: 'welcome', redirectTo: '/home' },
  
  // Legacy URL support
  { path: 'old-products', redirectTo: '/products' },
  { path: 'legacy/:id', redirectTo: '/product/:id' },
  
  // Conditional redirects with guards
  {
    path: 'admin',
    canActivate: [AdminGuard],
    component: AdminDashboardComponent
  }
];
```

#### 🔒 **Route Guards and Data**
```typescript
const routes: Routes = [
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [AuthGuard],                    // Guard before activation
    canDeactivate: [CanDeactivateGuard],         // Guard before leaving
    resolve: { user: UserResolver },             // Resolve data before activation
    data: { title: 'User Profile', roles: ['user'] } // Static data
  },
  
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canLoad: [AdminGuard],                       // Guard before loading module
    data: { preload: false }
  }
];
```

### 🏢 **Feature Module Routing**

#### 📱 **Feature Routes**
```typescript
// products-routing.module.ts
const routes: Routes = [
  {
    path: '',  // Relative to parent route
    component: ProductsLayoutComponent,
    children: [
      { path: '', component: ProductListComponent },           // /products
      { path: 'new', component: ProductCreateComponent },      // /products/new
      { path: ':id', component: ProductDetailComponent },      // /products/123
      { path: ':id/edit', component: ProductEditComponent }    // /products/123/edit
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)], // forChild for feature modules!
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
```

#### 🧩 **Nested Routes**
```typescript
const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardLayoutComponent,
    children: [
      { path: '', redirectTo: 'overview', pathMatch: 'full' },
      { path: 'overview', component: DashboardOverviewComponent },
      { path: 'analytics', component: DashboardAnalyticsComponent },
      { path: 'settings', component: DashboardSettingsComponent },
      {
        path: 'users',
        component: UsersLayoutComponent,
        children: [
          { path: '', component: UsersListComponent },
          { path: ':id', component: UserDetailComponent },
          { path: ':id/edit', component: UserEditComponent }
        ]
      }
    ]
  }
];

// URL structure:
// /dashboard/overview
// /dashboard/analytics  
// /dashboard/users
// /dashboard/users/123
// /dashboard/users/123/edit
```

---

## 🎪 Router Outlet and Router Links

### 🎭 **Router Outlet**

The `<router-outlet>` is where routed components are displayed. It acts as a placeholder that Angular fills with the component corresponding to the current route.

#### 🏠 **Primary Router Outlet**
```html
<!-- app.component.html -->
<div class="app-container">
  <!-- Navigation header -->
  <nav class="navbar">
    <div class="nav-brand">
      <a routerLink="/">My App</a>
    </div>
    <ul class="nav-links">
      <li><a routerLink="/home" routerLinkActive="active">Home</a></li>
      <li><a routerLink="/about" routerLinkActive="active">About</a></li>
      <li><a routerLink="/products" routerLinkActive="active">Products</a></li>
      <li><a routerLink="/contact" routerLinkActive="active">Contact</a></li>
    </ul>
  </nav>
  
  <!-- Main content area where routed components appear -->
  <main class="main-content">
    <router-outlet></router-outlet>  <!-- Components render here! -->
  </main>
  
  <!-- Footer -->
  <footer class="footer">
    <p>&copy; 2024 My App. All rights reserved.</p>
  </footer>
</div>
```

#### 🔧 **Named Router Outlets**
```typescript
// Route configuration with named outlets
const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      {
        path: '',
        component: DashboardMainComponent,
        outlet: 'main'  // Named outlet
      },
      {
        path: '',
        component: DashboardSidebarComponent,
        outlet: 'sidebar'  // Named outlet
      }
    ]
  }
];
```

```html
<!-- dashboard.component.html -->
<div class="dashboard-layout">
  <aside class="sidebar">
    <router-outlet name="sidebar"></router-outlet>  <!-- Named outlet -->
  </aside>
  
  <main class="main-content">
    <router-outlet name="main"></router-outlet>     <!-- Named outlet -->
  </main>
</div>

<!-- Navigation to named outlets -->
<a [routerLink]="[{ outlets: { sidebar: 'settings', main: 'overview' } }]">
  Dashboard Settings
</a>
```

#### 🔄 **Nested Router Outlets**
```html
<!-- parent.component.html -->
<div class="parent-layout">
  <header>Parent Component Header</header>
  
  <div class="content">
    <router-outlet></router-outlet>  <!-- Child components render here -->
  </div>
</div>
```

```html
<!-- child.component.html - can have its own outlets -->
<div class="child-layout">
  <nav class="child-nav">
    <a routerLink="./tab1">Tab 1</a>
    <a routerLink="./tab2">Tab 2</a>
  </nav>
  
  <div class="tab-content">
    <router-outlet></router-outlet>  <!-- Grandchild components render here -->
  </div>
</div>
```

### 🔗 **Router Links**

Router links provide declarative navigation within your Angular application.

#### 🎯 **Basic Router Links**
```html
<!-- Static routes -->
<a routerLink="/home">Home</a>
<a routerLink="/about">About Us</a>
<a routerLink="/contact">Contact</a>

<!-- Array syntax for complex routes -->
<a [routerLink]="['/products']">All Products</a>
<a [routerLink]="['/product', productId]">Product Details</a>
<a [routerLink]="['/user', userId, 'profile']">User Profile</a>

<!-- Relative navigation -->
<a routerLink="../">Go Back</a>
<a routerLink="./details">View Details</a>
<a routerLink="edit">Edit Item</a>
```

#### 🎨 **Router Link Active**
```html
<!-- Highlight active links -->
<nav class="navbar">
  <a routerLink="/home" 
     routerLinkActive="active"
     class="nav-link">Home</a>
     
  <a routerLink="/products" 
     routerLinkActive="active current"
     [routerLinkActiveOptions]="{ exact: true }"
     class="nav-link">Products</a>
     
  <a routerLink="/about" 
     routerLinkActive="active"
     #aboutLink="routerLinkActive"
     class="nav-link"
     [class.highlighted]="aboutLink.isActive">About</a>
</nav>
```

```css
/* CSS for active states */
.nav-link {
  color: #666;
  text-decoration: none;
  padding: 8px 16px;
  border-radius: 4px;
}

.nav-link.active {
  background-color: #007bff;
  color: white;
  font-weight: bold;
}

.nav-link.current {
  border-bottom: 2px solid #007bff;
}

.nav-link.highlighted {
  box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
}
```

#### 📋 **Advanced Router Link Examples**
```html
<!-- With query parameters -->
<a [routerLink]="['/products']" 
   [queryParams]="{ category: 'electronics', sort: 'price' }">
   Electronics (sorted by price)
</a>

<!-- With fragments (hash) -->
<a [routerLink]="['/about']" 
   fragment="team-section">
   Meet Our Team
</a>

<!-- Preserve query params and fragments -->
<a [routerLink]="['/products', 'electronics']"
   queryParamsHandling="preserve"
   preserveFragment="true">
   Electronics Section
</a>

<!-- Replace URL in history -->
<a [routerLink]="['/search']"
   [queryParams]="{ q: searchTerm }"
   replaceUrl="true">
   Search Results
</a>

<!-- Conditional routing -->
<a [routerLink]="user.isAdmin ? ['/admin'] : ['/dashboard']"
   routerLinkActive="active">
   {{ user.isAdmin ? 'Admin Panel' : 'Dashboard' }}
</a>

<!-- Dynamic route parameters -->
<div *ngFor="let product of products">
  <a [routerLink]="['/product', product.id]"
     [queryParams]="{ ref: 'list' }"
     routerLinkActive="selected">
    {{ product.name }}
  </a>
</div>
```

#### 🎛️ **Programmatic Navigation**
```typescript
// Using Router service for navigation
@Component({
  selector: 'app-product-list',
  template: `
    <div class="products">
      <button (click)="viewProduct(product.id)" 
              *ngFor="let product of products">
        {{ product.name }}
      </button>
      
      <button (click)="goBack()">Go Back</button>
      <button (click)="searchProducts()">Search</button>
    </div>
  `
})
export class ProductListComponent {
  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) {}
  
  viewProduct(productId: number): void {
    // Navigate to product details
    this.router.navigate(['/product', productId]);
    
    // Navigate with query parameters
    this.router.navigate(['/product', productId], {
      queryParams: { ref: 'list', timestamp: Date.now() },
      fragment: 'reviews'
    });
  }
  
  goBack(): void {
    // Relative navigation
    this.router.navigate(['../'], { relativeTo: this.route });
  }
  
  searchProducts(): void {
    // Navigate and replace current URL in history
    this.router.navigate(['/search'], {
      queryParams: { category: 'all' },
      replaceUrl: true
    });
  }
  
  conditionalNavigation(): void {
    // Navigate based on conditions
    const targetRoute = this.userService.isLoggedIn() 
      ? ['/dashboard'] 
      : ['/login'];
      
    this.router.navigate(targetRoute);
  }
}
```

---

## 🔗 Router HashLocationStrategy

### 🎯 **What is HashLocationStrategy?**

**HashLocationStrategy** uses the hash fragment (`#`) in the URL to handle client-side routing. This approach is useful for legacy browsers or scenarios where you can't configure your server to support HTML5 pushState.

### 🔄 **URL Format Comparison**

```
PathLocationStrategy (Default):
https://myapp.com/products/123
https://myapp.com/about
https://myapp.com/user/profile

HashLocationStrategy:
https://myapp.com/#/products/123
https://myapp.com/#/about  
https://myapp.com/#/user/profile
```

### ⚙️ **Configuring HashLocationStrategy**

#### 📦 **Module-Based Configuration**
```typescript
// app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'about', component: AboutComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: true  // Enable hash-based routing
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
```

#### 🆕 **Standalone Configuration**
```typescript
// main.ts
import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, withHashLocation } from '@angular/router';
import { AppComponent } from './app.component';

bootstrapApplication(AppComponent, {
  providers: [
    provideRouter(routes, withHashLocation())  // Enable hash location strategy
  ]
});
```

#### 🔧 **Manual Configuration with LocationStrategy**
```typescript
// app.module.ts
import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';

@NgModule({
  // ... other module configuration
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy }
  ]
})
export class AppModule { }
```

### 🎯 **When to Use HashLocationStrategy**

#### ✅ **Good Use Cases**

```typescript
// 1. Legacy browser support
const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'reports', component: ReportsComponent }
];

// URLs become: https://app.com/#/dashboard, https://app.com/#/reports
```

#### 🏢 **Corporate/Enterprise Environments**
```typescript
// When deploying to corporate environments with strict server configs
@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: true,
    // Additional enterprise-friendly options
    enableTracing: false,  // Disable for production
    initialNavigation: 'enabledBlocking'
  })]
})
export class AppRoutingModule { }
```

#### 📱 **Mobile/Hybrid Apps**
```typescript
// For mobile apps where server configuration is limited
import { isPlatformBrowser } from '@angular/common';

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: isPlatformBrowser(platformId), // Hash only in browser
    scrollPositionRestoration: 'top'
  })]
})
export class AppRoutingModule { }
```

### ⚖️ **PathLocationStrategy vs HashLocationStrategy**

| Feature | PathLocationStrategy | HashLocationStrategy |
|---------|---------------------|---------------------|
| **URL Format** | `/products/123` | `/#/products/123` |
| **SEO Friendly** | ✅ Yes | ❌ Limited |
| **Server Config** | ❌ Required | ✅ Not needed |
| **Legacy Browser** | ❌ Limited support | ✅ Full support |
| **Bookmarkable** | ✅ Yes | ✅ Yes |
| **Social Sharing** | ✅ Clean URLs | ⚠️ Hash in URLs |
| **Server Rendering** | ✅ Supported | ⚠️ Limited |

### 🔧 **Advanced HashLocationStrategy Configuration**

#### 🎯 **Conditional Strategy Selection**
```typescript
// app.module.ts
import { environment } from '../environments/environment';

const locationStrategy = environment.production 
  ? PathLocationStrategy  // Clean URLs in production
  : HashLocationStrategy; // Hash URLs in development

@NgModule({
  providers: [
    { provide: LocationStrategy, useClass: locationStrategy }
  ]
})
export class AppModule { }
```

#### 🌐 **Environment-Based Configuration**
```typescript
// environments/environment.prod.ts
export const environment = {
  production: true,
  useHashRouting: false  // Clean URLs for production
};

// environments/environment.ts
export const environment = {
  production: false,
  useHashRouting: true   // Hash URLs for development
};

// app-routing.module.ts
import { environment } from '../environments/environment';

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: environment.useHashRouting,
    enableTracing: !environment.production
  })]
})
export class AppRoutingModule { }
```

### 📋 **Server Configuration Examples**

#### 🚫 **Without Server Config (HashLocationStrategy)**
```html
<!-- No server configuration needed -->
<!-- All URLs work out of the box -->
https://myapp.com/#/home      ✅ Works
https://myapp.com/#/about     ✅ Works  
https://myapp.com/#/products  ✅ Works
```

#### ⚙️ **With Server Config (PathLocationStrategy)**
```nginx
# Nginx configuration for clean URLs
server {
  listen 80;
  server_name myapp.com;
  root /var/www/myapp;
  index index.html;

  # Handle Angular routing
  location / {
    try_files $uri $uri/ /index.html;
  }
}
```

```apache
# Apache .htaccess for clean URLs
<IfModule mod_rewrite.c>
  RewriteEngine On
  RewriteBase /
  RewriteRule ^index\.html$ - [L]
  RewriteCond %{REQUEST_FILENAME} !-f
  RewriteCond %{REQUEST_FILENAME} !-d
  RewriteRule . /index.html [L]
</IfModule>
```

### 🧪 **Testing with Different Location Strategies**

```typescript
// Testing hash location strategy
import { Location } from '@angular/common';
import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

describe('HashLocationStrategy Routing', () => {
  let router: Router;
  let location: Location;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [RouterTestingModule.withRoutes(routes, { useHash: true })]
    });
    
    router = TestBed.inject(Router);
    location = TestBed.inject(Location);
  });

  it('should use hash in URLs', async () => {
    await router.navigate(['/products']);
    expect(location.path()).toBe('/products');
    // In browser, this becomes: https://app.com/#/products
  });
});
```

## 💡 Pro Tips & Best Practices

### 🚀 **Route Configuration Best Practices**
- **Order matters** - more specific routes first, wildcard last
- Use **lazy loading** for feature modules to improve performance
- **Validate route parameters** in components
- **Handle route errors** gracefully

### 🎯 **Navigation Best Practices**
```typescript
// ✅ Good - Handle navigation errors
this.router.navigate(['/products']).then(
  success => console.log('Navigation successful'),
  error => console.error('Navigation failed', error)
);

// ✅ Good - Use relative navigation when possible
this.router.navigate(['../sibling'], { relativeTo: this.route });

// ✅ Good - Clean up subscriptions
ngOnDestroy(): void {
  this.routeSubscription?.unsubscribe();
}
```

### 🔧 **HashLocationStrategy Recommendations**
- Use **PathLocationStrategy** for new applications when possible
- Consider **HashLocationStrategy** for legacy environments
- **Test thoroughly** in target deployment environment  
- **Document** the choice for future developers

Remember: **Choose the right location strategy for your deployment enviro