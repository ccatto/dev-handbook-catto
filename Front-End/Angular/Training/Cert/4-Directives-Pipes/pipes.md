# 🔧 Angular Pipes Complete Guide

> 🚀 **Pipes are the recommended approach to format data in your component templates. They're optimized for change detection by default, so they don't re-render and re-format data if the pipe input hasn't changed.**

## 🛠️ Common Angular Pipes

### 📝 Text Formatting Pipes

#### 🔤 **Case Pipes**
```html
<!-- Original: "hello WORLD" -->
<p>{{ "hello WORLD" | uppercase }}</p>      <!-- HELLO WORLD -->
<p>{{ "hello WORLD" | lowercase }}</p>      <!-- hello world -->
<p>{{ "hello WORLD" | titlecase }}</p>      <!-- Hello World -->
```

#### ✂️ **Slice Pipe**
```html
<!-- Array slicing -->
<li *ngFor="let item of items | slice:0:3">{{ item }}</li>  <!-- First 3 items -->
<li *ngFor="let item of items | slice:2:5">{{ item }}</li>  <!-- Items 2-4 -->
<li *ngFor="let item of items | slice:-3">{{ item }}</li>   <!-- Last 3 items -->

<!-- String slicing -->
<p>{{ longText | slice:0:50 }}...</p>  <!-- First 50 characters -->
<p>{{ email | slice:0:-10 }}</p>      <!-- Remove last 10 chars -->
```

### 🔢 Number Formatting Pipes

#### 💰 **Number Pipes**
```typescript
// Component
export class MyComponent {
  price = 1234.56;
  percentage = 0.1234;
  largeNumber = 1234567.89;
}
```

```html
<!-- DecimalPipe -->
<p>{{ price | number }}</p>                    <!-- 1,234.56 -->
<p>{{ price | number:'1.0-0' }}</p>            <!-- 1,235 (rounded) -->
<p>{{ price | number:'3.1-2' }}</p>            <!-- 001,234.56 -->
<p>{{ price | number:'1.2-4' }}</p>            <!-- 1,234.56 -->

<!-- CurrencyPipe -->
<p>{{ price | currency }}</p>                  <!-- $1,234.56 -->
<p>{{ price | currency:'EUR' }}</p>            <!-- €1,234.56 -->
<p>{{ price | currency:'USD':'symbol':'1.0-0' }}</p>  <!-- $1,235 -->
<p>{{ price | currency:'EUR':'code' }}</p>     <!-- EUR 1,234.56 -->

<!-- PercentPipe -->
<p>{{ percentage | percent }}</p>              <!-- 12% -->
<p>{{ percentage | percent:'1.2-2' }}</p>      <!-- 12.34% -->
```

### 📅 Date Formatting Pipes

```typescript
// Component
export class MyComponent {
  today = new Date();
  birthday = new Date('1990-05-15');
  timestamp = 1609459200000; // Unix timestamp
}
```

```html
<!-- Basic date formats -->
<p>{{ today | date }}</p>                      <!-- Jan 15, 2024 -->
<p>{{ today | date:'short' }}</p>              <!-- 1/15/24, 3:30 PM -->
<p>{{ today | date:'medium' }}</p>             <!-- Jan 15, 2024, 3:30:45 PM -->
<p>{{ today | date:'long' }}</p>               <!-- January 15, 2024 at 3:30:45 PM GMT -->
<p>{{ today | date:'full' }}</p>               <!-- Monday, January 15, 2024 at 3:30:45 PM GMT -->

<!-- Custom date formats -->
<p>{{ today | date:'yyyy-MM-dd' }}</p>         <!-- 2024-01-15 -->
<p>{{ today | date:'dd/MM/yyyy HH:mm' }}</p>   <!-- 15/01/2024 15:30 -->
<p>{{ today | date:'EEEE, MMMM d, y' }}</p>    <!-- Monday, January 15, 2024 -->
<p>{{ today | date:'h:mm a' }}</p>             <!-- 3:30 PM -->

<!-- With timezone -->
<p>{{ today | date:'medium':'UTC' }}</p>       <!-- UTC timezone -->
<p>{{ today | date:'short':'EST' }}</p>        <!-- EST timezone -->

<!-- Relative time (requires additional setup) -->
<p>{{ birthday | date:'mediumDate' }}</p>      <!-- May 15, 1990 -->
```

### 🎛️ Data Structure Pipes

#### 🔄 **JSON Pipe**
```typescript
// Component
export class MyComponent {
  user = {
    name: 'Alice',
    age: 30,
    hobbies: ['reading', 'coding', 'gaming']
  };
}
```

```html
<!-- Debug object display -->
<pre>{{ user | json }}</pre>
<!-- Output:
{
  "name": "Alice",
  "age": 30,
  "hobbies": [
    "reading",
    "coding",
    "gaming"
  ]
}
-->
```

#### 🔑 **KeyValue Pipe**
```typescript
// Component
export class MyComponent {
  userStats = {
    posts: 42,
    followers: 156,
    following: 89,
    likes: 1234
  };
}
```

```html
<!-- Iterate over object properties -->
<div *ngFor="let stat of userStats | keyvalue">
  <strong>{{ stat.key | titlecase }}:</strong> {{ stat.value }}
</div>
<!-- Output:
Following: 89
Followers: 156
Likes: 1234
Posts: 42
-->

<!-- Custom key ordering -->
<div *ngFor="let stat of userStats | keyvalue:customCompare">
  {{ stat.key }}: {{ stat.value }}
</div>
```

### 🌐 Async Pipe

```typescript
// Component
export class MyComponent {
  user$ = this.userService.getCurrentUser();
  
  // Observable that emits every second
  timer$ = interval(1000).pipe(
    map(n => n + 1)
  );
  
  // Promise
  userData = this.fetchUserData();
}
```

```html
<!-- Subscribe to observables automatically -->
<div *ngIf="user$ | async as user">
  <h2>{{ user.name }}</h2>
  <p>{{ user.email }}</p>
</div>

<!-- Timer display -->
<p>Timer: {{ timer$ | async }} seconds</p>

<!-- Promise resolution -->
<div *ngIf="userData | async as data">
  <p>Loaded: {{ data.message }}</p>
</div>

<!-- Loading states -->
<div *ngIf="user$ | async as user; else loading">
  User: {{ user.name }}
</div>
<ng-template #loading>
  <div>Loading user...</div>
</ng-template>
```

---

## ⚙️ Pipe Syntax and Parameters

### 🎯 Basic Pipe Syntax

```html
<!-- Basic format -->
{{ value | pipeName }}

<!-- With parameters -->
{{ value | pipeName:parameter1:parameter2:parameter3 }}

<!-- Chaining pipes -->
{{ value | pipe1 | pipe2 | pipe3 }}
```

### 🔧 Parameter Examples

#### 📊 **Number Pipe Parameters**
```html
<!-- Format: number:'minIntegerDigits.minFractionDigits-maxFractionDigits' -->
{{ 123.456 | number:'1.0-0' }}    <!-- 123 -->
{{ 123.456 | number:'1.1-1' }}    <!-- 123.5 -->
{{ 123.456 | number:'1.2-2' }}    <!-- 123.46 -->
{{ 123.456 | number:'3.2-4' }}    <!-- 123.456 -->
{{ 5 | number:'3.0-0' }}          <!-- 005 -->
```

#### 💸 **Currency Pipe Parameters**
```html
<!-- Format: currency:currencyCode:display:digitsInfo:locale -->
{{ 1234.56 | currency:'USD':'symbol':'1.2-2' }}     <!-- $1,234.56 -->
{{ 1234.56 | currency:'EUR':'symbol-narrow' }}      <!-- €1,234.56 -->
{{ 1234.56 | currency:'GBP':'code' }}               <!-- GBP 1,234.56 -->
{{ 1234.56 | currency:'JPY':'symbol':'1.0-0' }}     <!-- ¥1,235 -->
```

#### 📅 **Date Pipe Parameters**
```html
<!-- Format: date:format:timezone:locale -->
{{ today | date:'short':'UTC' }}                    <!-- 1/15/24, 8:30 PM -->
{{ today | date:'yyyy-MM-dd':'EST' }}               <!-- 2024-01-15 -->
{{ today | date:'fullDate':'PST':'en-US' }}         <!-- Monday, January 15, 2024 -->
```

### 🔗 Chaining Pipes

```typescript
// Component
export class MyComponent {
  users = [
    { name: 'alice johnson', salary: 75000, joinDate: new Date('2020-03-15') },
    { name: 'bob smith', salary: 82000, joinDate: new Date('2019-07-22') },
    { name: 'charlie brown', salary: 68000, joinDate: new Date('2021-11-05') }
  ];
  
  searchTerm = 'john';
}
```

```html
<!-- Multiple pipe chaining -->
<div *ngFor="let user of users | slice:0:5 | async">
  <h3>{{ user.name | titlecase }}</h3>
  <p>Salary: {{ user.salary | currency:'USD':'symbol':'1.0-0' }}</p>
  <p>Joined: {{ user.joinDate | date:'mediumDate' }}</p>
</div>

<!-- Complex chaining -->
<p>{{ user.name | titlecase | slice:0:10 }}...</p>
<p>{{ user.salary | currency | lowercase }}</p> <!-- Note: Not practical, just example -->

<!-- With async data -->
<div *ngFor="let item of (dataService.getItems() | async | slice:0:3)">
  {{ item.name | titlecase }}
</div>
```

---

## 🎯 When to Use Pipes

### ✅ **Perfect Use Cases**

#### 🎨 **Data Formatting**
```html
<!-- Format display data without changing source -->
<div class="user-profile">
  <h1>{{ user.name | titlecase }}</h1>                    <!-- Display formatting -->
  <p>Joined: {{ user.joinDate | date:'longDate' }}</p>    <!-- Date formatting -->
  <p>Salary: {{ user.salary | currency:'USD' }}</p>       <!-- Currency formatting -->
  <div>Bio: {{ user.bio | slice:0:100 }}...</div>         <!-- Text truncation -->
</div>
```

#### 🔄 **Data Transformation**
```typescript
// Component - keep data in optimal format
export class ProductComponent {
  products = [
    { name: 'laptop', price: 999.99, category: 'electronics' },
    { name: 'book', price: 19.99, category: 'education' }
  ];
}
```

```html
<!-- Transform for display without changing source data -->
<div *ngFor="let product of products">
  <h3>{{ product.name | titlecase }}</h3>
  <p>{{ product.category | uppercase }}</p>
  <span>{{ product.price | currency:'USD':'symbol':'1.0-0' }}</span>
</div>
```

#### 🌊 **Async Data Handling**
```html
<!-- Automatically subscribe/unsubscribe -->
<div *ngIf="userService.getCurrentUser() | async as user">
  Welcome, {{ user.name }}!
</div>

<!-- Loading states -->
<div class="notifications">
  <div *ngFor="let notification of notifications$ | async">
    {{ notification.message }}
  </div>
</div>
```

#### 🎛️ **Template Logic Simplification**
```html
<!-- Instead of complex template expressions -->
<div *ngFor="let item of items | slice:startIndex:endIndex">
  {{ item.name }}
</div>

<!-- Instead of component methods for formatting -->
<p>{{ complexObject | json }}</p>
```

### ❌ **When NOT to Use Pipes**

#### 🚫 **Business Logic**
```typescript
// DON'T - Business logic belongs in component/service
@Pipe({ name: 'calculateTax' })
export class CalculateTaxPipe implements PipeTransform {
  transform(price: number): number {
    // Complex tax calculation logic - belongs in service!
    return price * this.getTaxRate() * this.getDiscountMultiplier();
  }
}

// DO - Keep business logic in services
@Injectable()
export class TaxService {
  calculateTax(price: number): number {
    return price * this.getTaxRate() * this.getDiscountMultiplier();
  }
}
```

#### 🚫 **Heavy Computations**
```typescript
// DON'T - Expensive operations in pipes
@Pipe({ name: 'expensiveCalculation' })
export class ExpensiveCalculationPipe implements PipeTransform {
  transform(data: any[]): any[] {
    // This runs on every change detection cycle!
    return data.map(item => this.performComplexCalculation(item));
  }
}

// DO - Pre-calculate in component
export class MyComponent {
  processedData = this.data.map(item => this.performComplexCalculation(item));
}
```

### 🎯 **Best Practices**

#### ✅ **Use Pipes For:**
- 🎨 **Display formatting** (dates, numbers, text)
- 🔄 **Data transformation** for presentation
- 🌊 **Async data handling**
- ✂️ **Simple filtering/slicing**
- 🔧 **Template utility functions**

#### ❌ **Avoid Pipes For:**
- 🏢 **Complex business logic**
- 💾 **Data manipulation** that changes source
- 🔄 **Heavy computations**
- 📡 **HTTP requests**
- 💾 **State management**

---

## 🔨 How to Create Custom Pipes

### 🏗️ Basic Custom Pipe Structure

```typescript
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'myCustomPipe',
  pure: true  // Default: true (pure pipe)
})
export class MyCustomPipe implements PipeTransform {
  transform(value: any, ...args: any[]): any {
    // Transform logic here
    return transformedValue;
  }
}
```

### 🎨 Simple Custom Pipes

#### 🔄 **Reverse String Pipe**
```typescript
@Pipe({ name: 'reverse' })
export class ReversePipe implements PipeTransform {
  transform(value: string): string {
    if (!value) return value;
    return value.split('').reverse().join('');
  }
}
```

```html
<!-- Usage -->
<p>{{ "Hello World" | reverse }}</p>  <!-- dlroW olleH -->
<p>{{ username | reverse }}</p>
```

#### ✂️ **Truncate Pipe with Ellipsis**
```typescript
@Pipe({ name: 'truncate' })
export class TruncatePipe implements PipeTransform {
  transform(value: string, limit: number = 50, trail: string = '...'): string {
    if (!value) return value;
    
    return value.length > limit 
      ? value.substring(0, limit) + trail
      : value;
  }
}
```

```html
<!-- Usage -->
<p>{{ longText | truncate:30 }}</p>                    <!-- 30 chars + ... -->
<p>{{ article.content | truncate:100:'... read more' }}</p>  <!-- Custom trail -->
```

#### 🔍 **Highlight Search Terms**
```typescript
@Pipe({ name: 'highlight' })
export class HighlightPipe implements PipeTransform {
  transform(value: string, searchTerm: string): string {
    if (!value || !searchTerm) return value;
    
    const regex = new RegExp(`(${searchTerm})`, 'gi');
    return value.replace(regex, '<mark>$1</mark>');
  }
}
```

```html
<!-- Usage -->
<div [innerHTML]="text | highlight:searchQuery"></div>
```

### 🔢 Advanced Custom Pipes

#### 📏 **File Size Pipe**
```typescript
@Pipe({ name: 'fileSize' })
export class FileSizePipe implements PipeTransform {
  transform(bytes: number, decimals: number = 2): string {
    if (bytes === 0) return '0 Bytes';
    
    const k = 1024;
    const dm = decimals < 0 ? 0 : decimals;
    const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    
    const i = Math.floor(Math.log(bytes) / Math.log(k));
    
    return parseFloat((bytes / Math.pow(k, i)).toFixed(dm)) + ' ' + sizes[i];
  }
}
```

```html
<!-- Usage -->
<p>{{ file.size | fileSize }}</p>        <!-- 1.23 MB -->
<p>{{ file.size | fileSize:0 }}</p>      <!-- 1 MB -->
```

#### ⏰ **Time Ago Pipe**
```typescript
@Pipe({ name: 'timeAgo' })
export class TimeAgoPipe implements PipeTransform {
  transform(value: Date | string | number): string {
    if (!value) return '';
    
    const now = new Date().getTime();
    const time = new Date(value).getTime();
    const diff = now - time;
    
    const seconds = Math.floor(diff / 1000);
    const minutes = Math.floor(seconds / 60);
    const hours = Math.floor(minutes / 60);
    const days = Math.floor(hours / 24);
    const months = Math.floor(days / 30);
    const years = Math.floor(months / 12);
    
    if (years > 0) return years === 1 ? '1 year ago' : `${years} years ago`;
    if (months > 0) return months === 1 ? '1 month ago' : `${months} months ago`;
    if (days > 0) return days === 1 ? '1 day ago' : `${days} days ago`;
    if (hours > 0) return hours === 1 ? '1 hour ago' : `${hours} hours ago`;
    if (minutes > 0) return minutes === 1 ? '1 minute ago' : `${minutes} minutes ago`;
    return 'Just now';
  }
}
```

```html
<!-- Usage -->
<p>Posted {{ post.createdAt | timeAgo }}</p>  <!-- Posted 2 hours ago -->
<span>{{ comment.timestamp | timeAgo }}</span>  <!-- Just now -->
```

### 🔄 Pure vs Impure Pipes

#### 🟢 **Pure Pipes (Default)**
```typescript
// Pure pipe - only runs when input changes
@Pipe({ 
  name: 'purePipe',
  pure: true  // Default
})
export class PurePipe implements PipeTransform {
  transform(value: any): any {
    console.log('Pure pipe executed'); // Only runs when value changes
    return value.toUpperCase();
  }
}
```

#### 🟡 **Impure Pipes**
```typescript
// Impure pipe - runs on every change detection cycle
@Pipe({ 
  name: 'impurePipe',
  pure: false  // Impure
})
export class ImpurePipe implements PipeTransform {
  transform(items: any[], filterBy: string): any[] {
    console.log('Impure pipe executed'); // Runs frequently!
    
    if (!filterBy) return items;
    return items.filter(item => 
      item.name.toLowerCase().includes(filterBy.toLowerCase())
    );
  }
}
```

#### ⚡ **Async Pipe Example (Impure)**
```typescript
// Custom async-like pipe
@Pipe({ 
  name: 'customAsync',
  pure: false 
})
export class CustomAsyncPipe implements PipeTransform {
  private cachedResult: any;
  private cachedInput: any;
  
  transform(observable: Observable<any>): any {
    if (observable !== this.cachedInput) {
      this.cachedInput = observable;
      observable.subscribe(result => {
        this.cachedResult = result;
      });
    }
    return this.cachedResult;
  }
}
```

### 📦 **Registering Custom Pipes**

#### 🏠 **Module Registration**
```typescript
import { NgModule } from '@angular/core';
import { ReversePipe } from './pipes/reverse.pipe';
import { TruncatePipe } from './pipes/truncate.pipe';
import { FileSizePipe } from './pipes/file-size.pipe';

@NgModule({
  declarations: [
    ReversePipe,
    TruncatePipe,
    FileSizePipe
  ],
  exports: [
    ReversePipe,
    TruncatePipe,
    FileSizePipe
  ]
})
export class SharedPipesModule { }
```

#### 🔧 **Standalone Pipes (Angular 14+)**
```typescript
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'standalone',
  standalone: true
})
export class StandalonePipe implements PipeTransform {
  transform(value: any): any {
    return value;
  }
}
```

```typescript
// Using in standalone component
import { Component } from '@angular/core';
import { StandalonePipe } from './standalone.pipe';

@Component({
  selector: 'app-my-component',
  standalone: true,
  imports: [StandalonePipe],
  template: `<p>{{ text | standalone }}</p>`
})
export class MyComponent { }
```

### 🧪 **Testing Custom Pipes**

```typescript
import { TruncatePipe } from './truncate.pipe';

describe('TruncatePipe', () => {
  let pipe: TruncatePipe;
  
  beforeEach(() => {
    pipe = new TruncatePipe();
  });
  
  it('should create', () => {
    expect(pipe).toBeTruthy();
  });
  
  it('should truncate long text', () => {
    const longText = 'This is a very long text that should be truncated';
    const result = pipe.transform(longText, 20);
    expect(result).toBe('This is a very long ...');
  });
  
  it('should not truncate short text', () => {
    const shortText = 'Short text';
    const result = pipe.transform(shortText, 20);
    expect(result).toBe('Short text');
  });
  
  it('should handle empty input', () => {
    expect(pipe.transform('', 10)).toBe('');
    expect(pipe.transform(null, 10)).toBe(null);
  });
});
```

## 💡 Pro Tips

### 🚀 **Performance Tips**
- Use **pure pipes** when possible (default behavior)
- Avoid **heavy computations** in pipe transform methods
- Consider **caching results** for expensive operations
- Use **TrackBy** functions with *ngFor when using pipes

### 🎯 **Best Practices**
- Keep pipes **focused** on single responsibility
- Make pipes **reusable** across components
- **Test pipes** thoroughly with edge cases
- Use **meaningful names** for custom pipes
- Document **complex pipe parameters**

### ⚡ **Common Patterns**
```html
<!-- Combine pipes for complex formatting -->
<p>{{ user.name | titlecase | truncate:20 }}</p>

<!-- Use with async data -->
<div *ngFor="let item of (items$ | async | slice:0:10)">
  {{ item.name }}
</div>

<!-- Safe navigation with pipes -->
<p>{{ user?.profile?.bio | truncate:50 }}</p>
```

Remember: Pipes are for **transformation and formatting**, not business logic! 🎯

