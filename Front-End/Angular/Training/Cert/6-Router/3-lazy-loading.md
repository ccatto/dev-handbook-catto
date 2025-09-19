# 🚀 Lazy Loading

When we use lazy-loading, instead of building our application as one single bundle of code that gets downloaded as soon as our user accesses the app in a browser, we divide our code into several different pieces that get downloaded **on-demand when they are needed**.

Such lazy loading depends on the Angular Router, as bundles of code get downloaded when new URLs get activated.

In this section, learn more about lazy-loading, why it matters, and how to use it, as well as the new approach using the `@defer` block.

> **🚨 Pro TIP** Lazy-loading is the most important feature of Angular to improve the performance of large applications by dividing your application code into smaller chunks. If you're building a medium to large Angular app, consider using lazy-loading.

## 📦 What You Need to Know About Lazy-Loading

### 🤔 Why Lazy Loading Matters

Lazy loading is crucial for application performance because it:

- **Reduces initial bundle size** 📉 - Faster app startup
- **Improves Time to Interactive (TTI)** ⚡ - Users can interact sooner
- **Better user experience** 🎯 - Especially on slow networks
- **Saves bandwidth** 💰 - Only downloads what's needed
- **Scales with app size** 📈 - Larger apps benefit more

### 🏗️ How Lazy Loading Works

```typescript
// Traditional approach - everything loads at once
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'orders', component: OrdersComponent },
  { path: 'admin', component: AdminComponent }
];
```

```typescript
// Lazy loading approach - modules load on-demand
const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'products',
    loadChildren: () => import('./products/products.module').then(m => m.ProductsModule)
  },
  {
    path: 'orders', 
    loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule)
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  }
];
```

### 📊 Bundle Analysis

```bash
# Before lazy loading
main.js (2.5MB) - Contains everything

# After lazy loading
main.js (800KB) - Core app
products-module.js (400KB) - Loads when /products visited
orders-module.js (350KB) - Loads when /orders visited
admin-module.js (600KB) - Loads when /admin visited
```

## 🎯 Lazy-Loading Standalone Components

With Angular's standalone components (v14+), lazy loading becomes even simpler and more flexible.

### 🔧 Basic Standalone Component Lazy Loading

```typescript
// app.routes.ts
export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: 'products',
    loadComponent: () => import('./products/products.component').then(c => c.ProductsComponent)
  },
  {
    path: 'profile',
    loadComponent: () => import('./profile/profile.component').then(c => c.ProfileComponent)
  }
];
```

### 🌟 Lazy Loading with Child Routes

```typescript
// products.routes.ts
export const PRODUCTS_ROUTES: Routes = [
  { path: '', component: ProductListComponent },
  { path: ':id', component: ProductDetailComponent },
  { path: 'categories/:category', component: CategoryComponent }
];

// app.routes.ts
export const routes: Routes = [
  {
    path: 'products',
    loadChildren: () => import('./products/products.routes').then(r => r.PRODUCTS_ROUTES)
  }
];
```

### 🎨 Advanced Standalone Lazy Loading

```typescript
// Feature with dependencies
export const routes: Routes = [
  {
    path: 'dashboard',
    loadComponent: () => import('./dashboard/dashboard.component'),
    providers: [
      DashboardService,
      provideHttpClient(),
      // Feature-specific providers
    ]
  }
];
```

## ⚡ Lazy-Loading with @defer

The `@defer` block (v17+) enables lazy loading at the template level, not just route level.

### 🎯 Basic @defer Usage

```typescript
@Component({
  template: `
    <div>
      <h1>Dashboard</h1>
      
      <!-- Heavy chart component loads only when needed -->
      @defer {
        <heavy-chart-component [data]="chartData" />
      } @placeholder {
        <div class="chart-skeleton">📊 Loading chart...</div>
      } @loading {
        <div class="spinner">⏳ Preparing chart...</div>
      } @error {
        <div class="error">❌ Failed to load chart</div>
      }
    </div>
  `
})
export class DashboardComponent {}
```

### 🎪 Defer Triggers

```typescript
@Component({
  template: `
    <!-- Load when user hovers -->
    @defer (on hover) {
      <expensive-component />
    }
    
    <!-- Load when element comes into view -->
    @defer (on viewport) {
      <lazy-image src="large-image.jpg" />
    }
    
    <!-- Load on user interaction -->
    @defer (on interaction) {
      <interactive-widget />
    } @placeholder {
      <button>Click to load widget</button>
    }
    
    <!-- Load after delay -->
    @defer (after 2s) {
      <non-critical-content />
    }
    
    <!-- Load when condition is met -->
    @defer (when userLoggedIn) {
      <user-dashboard />
    }
    
    <!-- Combine multiple triggers -->
    @defer (on viewport; after 1s) {
      <analytics-widget />
    }
  `
})
export class MyComponent {
  userLoggedIn = false;
}
```

### 🔥 Advanced @defer Patterns

```typescript
@Component({
  template: `
    <!-- Lazy load heavy third-party widgets -->
    @defer (on viewport) {
      <google-maps [location]="location" />
    } @placeholder (minimum 500ms) {
      <div class="map-placeholder">
        🗺️ Map loading...
      </div>
    } @loading (after 100ms; minimum 1s) {
      <div class="map-loading">
        📍 Initializing map...
      </div>
    }
    
    <!-- Progressive enhancement -->
    @defer (on idle) {
      <enhanced-search-component />
    } @placeholder {
      <basic-search-component />
    }
  `
})
export class PageComponent {}
```

## 🛠️ Implementation Strategies

### 📋 Route-Based Lazy Loading Checklist

```typescript
// 1. Feature module structure
feature/
├── feature.module.ts
├── feature-routing.module.ts
├── components/
├── services/
└── models/
```

```typescript
// 2. Feature routing module
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeatureRoutingModule {}

// 3. Feature module
@NgModule({
  imports: [
    CommonModule,
    FeatureRoutingModule,
    // Feature-specific imports
  ],
  providers: [
    // Feature-specific services
  ]
})
export class FeatureModule {}
```

### 🎯 Performance Optimization Tips

```typescript
// Preload strategies
@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      // Preload all lazy modules after initial load
      preloadingStrategy: PreloadAllModules,
      
      // Or use selective preloading
      preloadingStrategy: SelectivePreloadingStrategy
    })
  ]
})
export class AppModule {}

// Custom preloading strategy
@Injectable()
export class SelectivePreloadingStrategy implements PreloadingStrategy {
  preload(route: Route, fn: () => Observable<any>): Observable<any> {
    // Only preload routes marked with data.preload
    return route.data && route.data['preload'] ? fn() : of(null);
  }
}
```

## 📊 Measuring Success

### 🔍 Bundle Analysis

```bash
# Analyze your bundles
ng build --stats-json
npx webpack-bundle-analyzer dist/your-app/stats.json
```

### 📈 Key Metrics to Track

- **First Contentful Paint (FCP)** 🎨
- **Largest Contentful Paint (LCP)** 📏
- **Time to Interactive (TTI)** ⚡
- **Bundle sizes** 📦
- **Network requests** 🌐

## 🚀 Best Practices

### ✅ Do's

- **Use lazy loading** for feature modules 🎯
- **Implement @defer** for heavy components ⚡
- **Preload critical routes** 🏃‍♂️
- **Monitor bundle sizes** 📊
- **Test on slow networks** 🐌
- **Use standalone components** for simpler lazy loading 🎨

### ❌ Don'ts

- **Don't lazy load** tiny modules (overhead not worth it)
- **Don't forget** error handling in @defer blocks
- **Don't over-defer** everything (some content should be immediate)
- **Don't ignore** the loading states
- **Don't lazy load** critical above-the-fold content

## 🎉 Real-World Example

```typescript
// E-commerce app structure
const routes: Routes = [
  // Immediate load - critical
  { path: '', component: HomeComponent },
  { path: 'search', component: SearchComponent },
  
  // Lazy load - secondary features  
  {
    path: 'products',
    loadChildren: () => import('./products/products.module').then(m => m.ProductsModule),
    data: { preload: true } // Preload this one
  },
  {
    path: 'cart',
    loadComponent: () => import('./cart/cart.component').then(c => c.CartComponent)
  },
  {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canActivate: [adminGuard] // Only admins can trigger this load
  }
];
```

---

*Start small, measure impact, and watch your app performance soar! 🚀📈*

