# Angular 20 with PrimeNG - Tech Overview

This document provides an overview of commonly used **PrimeNG components** in Angular 20, with details on layouts, grids, and a deep dive into `DataView` and `DataTable`. It also covers simple component extension.

---

## 1. Common PrimeNG Components

PrimeNG offers a wide variety of UI components. Some of the most commonly used include:

| Component       | Description |
|-----------------|-------------|
| `Button`        | Standard clickable button with various styles. |
| `InputText`     | Single-line text input field. |
| `Dropdown`      | Select input with options. |
| `Checkbox`      | Standard checkbox. |
| `DataTable`     | Tabular display of data with sorting, filtering, and pagination. |
| `DataView`      | Flexible list/grid view for data items. |
| `Card`          | Container for content with header, footer, and body. |
| `Dialog`        | Modal pop-up for interactions or details. |
| `Grid` / `Grid CSS` | Layout system with a 12-column responsive grid. |

---

## 2. Simple Component Examples

### 2.1 Button

```html
<p-button label="Click Me" icon="pi pi-check"></p-button>
```

### 2.2 InputText

```html
<p-inputText type="text" placeholder="Enter your name"></p-inputText>
```

---

## 3. DataTable Example

### 3.1 TypeScript Component

```ts
import { Component } from '@angular/core';

interface User {
  id: number;
  name: string;
  email: string;
}

@Component({
  selector: 'app-user-table',
  templateUrl: './user-table.component.html',
})
export class UserTableComponent {
  users: User[] = [
    { id: 1, name: 'Alice', email: 'alice@example.com' },
    { id: 2, name: 'Bob', email: 'bob@example.com' },
    { id: 3, name: 'Charlie', email: 'charlie@example.com' },
  ];
}
```

### 3.2 HTML Template

```html
<p-table [value]="users">
  <ng-template pTemplate="header">
    <tr>
      <th>ID</th>
      <th>Name</th>
      <th>Email</th>
    </tr>
  </ng-template>
  <ng-template pTemplate="body" let-user>
    <tr>
      <td>{{user.id}}</td>
      <td>{{user.name}}</td>
      <td>{{user.email}}</td>
    </tr>
  </ng-template>
</p-table>
```

---

## 4. DataView Example (Grid/List)

### 4.1 TypeScript Component

```ts
import { Component } from '@angular/core';

interface Product {
  id: number;
  name: string;
  price: number;
  description: string;
}

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
})
export class ProductViewComponent {
  products: Product[] = [
    { id: 1, name: 'Product A', price: 29.99, description: 'High quality product A' },
    { id: 2, name: 'Product B', price: 49.99, description: 'Durable product B' },
    { id: 3, name: 'Product C', price: 19.99, description: 'Affordable product C' },
  ];

  layout: 'grid' | 'list' = 'grid'; // Toggle between layouts
}
```

### 4.2 HTML Template

```html
<p-toolbar>
  <div class="p-toolbar-group-left">
    <p-button label="Grid" icon="pi pi-th-large" (onClick)="layout='grid'"></p-button>
    <p-button label="List" icon="pi pi-bars" (onClick)="layout='list'"></p-button>
  </div>
</p-toolbar>

<p-dataView [value]="products" [layout]="layout">
  <ng-template pTemplate="grid" let-product>
    <div class="p-col-4">
      <p-card [header]="product.name">
        <p>{{product.description}}</p>
        <p><b>Price:</b> ${{product.price}}</p>
      </p-card>
    </div>
  </ng-template>

  <ng-template pTemplate="list" let-product>
    <div class="p-col-12">
      <p-card [header]="product.name">
        <p>{{product.description}}</p>
        <p><b>Price:</b> ${{product.price}}</p>
      </p-card>
    </div>
  </ng-template>
</p-dataView>
```

---

## 5. Page Layout Using Grid System

PrimeNG uses a **12-column responsive grid**.

```html
<div class="p-grid">
  <div class="p-col-3">
    <p-card header="Sidebar">Sidebar content</p-card>
  </div>
  <div class="p-col-9">
    <p-card header="Main Content">Main page content</p-card>
  </div>
</div>
```

---

## 6. Extending a Component

You can create a **custom component** based on a PrimeNG component to standardize styling or behavior.

### Example: `CattoButton`

#### 6.1 TypeScript Component

```ts
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-catto-button',
  template: `
    <p-button [type]="type" [label]="label" [icon]="icon" class="catto-button {{class}}"></p-button>
  `,
  styles: [`
    .catto-button {
      border-radius: 8px;
      font-weight: bold;
    }
  `]
})
export class CattoButtonComponent {
  @Input() label: string = '';
  @Input() icon?: string;
  @Input() type: 'button' | 'submit' | 'reset' = 'button';
  @Input() class?: string;
}
```

#### 6.2 Usage in HTML

```html
<app-catto-button label="Save" icon="pi pi-check" class="p-button-success"></app-catto-button>
<app-catto-button label="Cancel" icon="pi pi-times" class="p-button-secondary"></app-catto-button>
```

> Benefits:
> - Standardizes button styles across the app
> - Can extend functionality (tracking clicks, custom animations, etc.)
> - Reusable and TypeScript-safe

---

## 7. Summary

- **PrimeNG** provides both UI components and a flexible layout system.  
- **Grid** is for page structure, **DataView/DataTable** for dynamic content.  
- Components can be **extended** to create reusable, standardized versions.  
- All examples are **TypeScript safe**.  
- Combine **Grid + DataView + Cards + Buttons** for fully responsive and functional UI.

