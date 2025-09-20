# Angular Reactive and Template-Driven Forms Tutorial 🚀

Angular has two main approaches to forms:
* **Template-driven forms:** Use Angular's intuitive template syntax, directives, and two-way data bindings. Perfect for most use cases.
* **Reactive forms:** Use RxJS for complex, dynamic forms with tricky validation rules.

## 🎯 What You'll Learn

* Set-up of a **reactive form** and a **template-driven form**
* **How to create custom validation functions that work with both approaches**
* **How to choose between reactive and template-driven forms?**
* **Reactive forms Observables**
* **Template-driven example with Signals**

---

## 1. Setting Up Reactive Forms ⚛️

Reactive forms provide a model-driven approach to handling form inputs whose values change over time.

### Module Setup

```typescript
// app.module.ts
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule // Import this for reactive forms
  ],
  // ...
})
export class AppModule { }
```

### Basic Reactive Form Setup

```typescript
// user-form.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html'
})
export class UserFormComponent {
  userForm: FormGroup;

  constructor(private fb: FormBuilder) {
    // Method 1: Using FormBuilder (Recommended)
    this.userForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      age: ['', [Validators.required, Validators.min(18)]]
    });

    // Method 2: Manual FormGroup creation
    // this.userForm = new FormGroup({
    //   firstName: new FormControl('', [Validators.required]),
    //   lastName: new FormControl('', [Validators.required]),
    //   email: new FormControl('', [Validators.required, Validators.email])
    // });
  }

  onSubmit() {
    if (this.userForm.valid) {
      console.log('Form Data:', this.userForm.value);
      console.log('Form Valid:', this.userForm.valid);
    } else {
      console.log('Form is invalid');
      this.markFormGroupTouched();
    }
  }

  private markFormGroupTouched() {
    Object.keys(this.userForm.controls).forEach(key => {
      this.userForm.get(key)?.markAsTouched();
    });
  }
}
```

### Reactive Form Template

```html
<!-- user-form.component.html -->
<form [formGroup]="userForm" (ngSubmit)="onSubmit()" class="user-form">
  <h2>Reactive Form 🎛️</h2>
  
  <div class="form-group">
    <label for="firstName">First Name:</label>
    <input 
      id="firstName"
      type="text" 
      formControlName="firstName"
      placeholder="Enter first name">
    
    <div class="error-messages" *ngIf="userForm.get('firstName')?.invalid && userForm.get('firstName')?.touched">
      <small *ngIf="userForm.get('firstName')?.errors?.['required']">
        ❌ First name is required
      </small>
      <small *ngIf="userForm.get('firstName')?.errors?.['minlength']">
        ❌ First name must be at least 2 characters
      </small>
    </div>
  </div>

  <div class="form-group">
    <label for="email">Email:</label>
    <input 
      id="email"
      type="email" 
      formControlName="email"
      placeholder="Enter email">
    
    <div class="error-messages" *ngIf="userForm.get('email')?.invalid && userForm.get('email')?.touched">
      <small *ngIf="userForm.get('email')?.errors?.['required']">
        ❌ Email is required
      </small>
      <small *ngIf="userForm.get('email')?.errors?.['email']">
        ❌ Please enter a valid email
      </small>
    </div>
  </div>

  <button type="submit" [disabled]="userForm.invalid">
    Submit {{ userForm.valid ? '✅' : '❌' }}
  </button>

  <!-- Debug Info -->
  <div class="debug-info">
    <p><strong>Form Status:</strong> {{ userForm.status }}</p>
    <p><strong>Form Value:</strong> {{ userForm.value | json }}</p>
  </div>
</form>
```

---

## 2. Setting Up Template-Driven Forms 📝

Template-driven forms use directives in the template to create and manipulate the underlying object model.

### Module Setup

```typescript
// app.module.ts
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule // Import this for template-driven forms
  ],
  // ...
})
export class AppModule { }
```

### Basic Template-Driven Form Setup

```typescript
// user-template-form.component.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-user-template-form',
  templateUrl: './user-template-form.component.html'
})
export class UserTemplateFormComponent {
  user = {
    firstName: '',
    lastName: '',
    email: '',
    age: null
  };

  onSubmit(form: any) {
    if (form.valid) {
      console.log('Form Data:', this.user);
      console.log('Form Valid:', form.valid);
    } else {
      console.log('Form is invalid');
    }
  }

  resetForm(form: any) {
    form.resetForm();
    this.user = {
      firstName: '',
      lastName: '',
      email: '',
      age: null
    };
  }
}
```

### Template-Driven Form Template

```html
<!-- user-template-form.component.html -->
<form #userForm="ngForm" (ngSubmit)="onSubmit(userForm)" class="user-form">
  <h2>Template-Driven Form 📋</h2>
  
  <div class="form-group">
    <label for="firstName">First Name:</label>
    <input 
      #firstNameInput="ngModel"
      id="firstName"
      type="text" 
      name="firstName"
      [(ngModel)]="user.firstName"
      required
      minlength="2"
      placeholder="Enter first name">
    
    <div class="error-messages" *ngIf="firstNameInput.invalid && firstNameInput.touched">
      <small *ngIf="firstNameInput.errors?.['required']">
        ❌ First name is required
      </small>
      <small *ngIf="firstNameInput.errors?.['minlength']">
        ❌ First name must be at least 2 characters
      </small>
    </div>
  </div>

  <div class="form-group">
    <label for="email">Email:</label>
    <input 
      #emailInput="ngModel"
      id="email"
      type="email" 
      name="email"
      [(ngModel)]="user.email"
      required
      email
      placeholder="Enter email">
    
    <div class="error-messages" *ngIf="emailInput.invalid && emailInput.touched">
      <small *ngIf="emailInput.errors?.['required']">
        ❌ Email is required
      </small>
      <small *ngIf="emailInput.errors?.['email']">
        ❌ Please enter a valid email
      </small>
    </div>
  </div>

  <div class="form-actions">
    <button type="submit" [disabled]="userForm.invalid">
      Submit {{ userForm.valid ? '✅' : '❌' }}
    </button>
    <button type="button" (click)="resetForm(userForm)">
      Reset 🔄
    </button>
  </div>

  <!-- Debug Info -->
  <div class="debug-info">
    <p><strong>Form Status:</strong> {{ userForm.status }}</p>
    <p><strong>Form Value:</strong> {{ user | json }}</p>
  </div>
</form>
```

---

## 3. Custom Validation Functions for Both Approaches 🎨

Create reusable validation functions that work with both reactive and template-driven forms.

### Custom Validator Functions

```typescript
// validators/custom-validators.ts
import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

// Age range validator
export function ageRangeValidator(min: number, max: number): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (control.value === null || control.value === '') {
      return null; // Don't validate empty values
    }
    
    const age = parseInt(control.value, 10);
    if (isNaN(age) || age < min || age > max) {
      return { 
        ageRange: { 
          min, 
          max, 
          actual: age 
        } 
      };
    }
    return null;
  };
}

// Username availability validator (async example)
export function usernameValidator(): ValidatorFn {
  const forbiddenUsernames = ['admin', 'root', 'user', 'test'];
  
  return (control: AbstractControl): ValidationErrors | null => {
    if (!control.value) {
      return null;
    }
    
    const username = control.value.toLowerCase();
    if (forbiddenUsernames.includes(username)) {
      return { forbiddenUsername: true };
    }
    
    return null;
  };
}

// Password strength validator
export function passwordStrengthValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    if (!control.value) {
      return null;
    }

    const password = control.value;
    const hasNumber = /[0-9]/.test(password);
    const hasUpper = /[A-Z]/.test(password);
    const hasLower = /[a-z]/.test(password);
    const hasSpecial = /[!@#$%^&*(),.?":{}|<>]/.test(password);
    const minLength = password.length >= 8;

    const errors: any = {};
    
    if (!hasNumber) errors.requiresNumber = true;
    if (!hasUpper) errors.requiresUppercase = true;
    if (!hasLower) errors.requiresLowercase = true;
    if (!hasSpecial) errors.requiresSpecialChar = true;
    if (!minLength) errors.requiresMinLength = true;

    return Object.keys(errors).length ? { passwordStrength: errors } : null;
  };
}

// Cross-field validator (password confirmation)
export function passwordMatchValidator(passwordField: string, confirmPasswordField: string): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const password = control.get(passwordField);
    const confirmPassword = control.get(confirmPasswordField);

    if (!password || !confirmPassword) {
      return null;
    }

    return password.value === confirmPassword.value ? null : { passwordMismatch: true };
  };
}
```

### Using Custom Validators in Reactive Forms

```typescript
// reactive-form-with-custom-validators.component.ts
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ageRangeValidator, passwordStrengthValidator, passwordMatchValidator } from './validators/custom-validators';

@Component({
  selector: 'app-reactive-custom-form',
  template: `
    <form [formGroup]="registrationForm" (ngSubmit)="onSubmit()">
      <div class="form-group">
        <label>Age:</label>
        <input type="number" formControlName="age">
        <div *ngIf="registrationForm.get('age')?.invalid && registrationForm.get('age')?.touched">
          <small *ngIf="registrationForm.get('age')?.errors?.['ageRange']">
            ❌ Age must be between {{ registrationForm.get('age')?.errors?.['ageRange'].min }} 
            and {{ registrationForm.get('age')?.errors?.['ageRange'].max }}
          </small>
        </div>
      </div>

      <div class="form-group">
        <label>Password:</label>
        <input type="password" formControlName="password">
        <div *ngIf="registrationForm.get('password')?.invalid && registrationForm.get('password')?.touched">
          <div *ngIf="registrationForm.get('password')?.errors?.['passwordStrength']">
            <small *ngIf="registrationForm.get('password')?.errors?.['passwordStrength'].requiresNumber">
              ❌ Password must contain a number
            </small>
            <small *ngIf="registrationForm.get('password')?.errors?.['passwordStrength'].requiresUppercase">
              ❌ Password must contain an uppercase letter
            </small>
            <!-- Add other password strength error messages -->
          </div>
        </div>
      </div>

      <div class="form-group">
        <label>Confirm Password:</label>
        <input type="password" formControlName="confirmPassword">
        <div *ngIf="registrationForm.errors?.['passwordMismatch'] && registrationForm.get('confirmPassword')?.touched">
          <small>❌ Passwords do not match</small>
        </div>
      </div>

      <button type="submit" [disabled]="registrationForm.invalid">Submit ✅</button>
    </form>
  `
})
export class ReactiveCustomFormComponent {
  registrationForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.registrationForm = this.fb.group({
      age: ['', [Validators.required, ageRangeValidator(18, 65)]],
      password: ['', [Validators.required, passwordStrengthValidator()]],
      confirmPassword: ['', Validators.required]
    }, { validators: passwordMatchValidator('password', 'confirmPassword') });
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      console.log('Form submitted:', this.registrationForm.value);
    }
  }
}
```

### Using Custom Validators in Template-Driven Forms

```typescript
// custom-validators.directive.ts
import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl, ValidationErrors } from '@angular/forms';
import { ageRangeValidator } from './validators/custom-validators';

@Directive({
  selector: '[ageRange]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: AgeRangeValidatorDirective,
      multi: true
    }
  ]
})
export class AgeRangeValidatorDirective implements Validator {
  @Input() ageRangeMin!: number;
  @Input() ageRangeMax!: number;

  validate(control: AbstractControl): ValidationErrors | null {
    return ageRangeValidator(this.ageRangeMin, this.ageRangeMax)(control);
  }
}
```

```html
<!-- template-driven-with-custom-validators.component.html -->
<form #userForm="ngForm" (ngSubmit)="onSubmit(userForm)">
  <div class="form-group">
    <label>Age:</label>
    <input 
      #ageInput="ngModel"
      type="number" 
      name="age"
      [(ngModel)]="user.age"
      required
      [ageRangeMin]="18"
      [ageRangeMax]="65"
      ageRange>
    
    <div *ngIf="ageInput.invalid && ageInput.touched">
      <small *ngIf="ageInput.errors?.['required']">❌ Age is required</small>
      <small *ngIf="ageInput.errors?.['ageRange']">
        ❌ Age must be between {{ ageInput.errors?.['ageRange'].min }} 
        and {{ ageInput.errors?.['ageRange'].max }}
      </small>
    </div>
  </div>

  <button type="submit" [disabled]="userForm.invalid">Submit ✅</button>
</form>
```

---

## 4. How to Choose Between Reactive and Template-Driven Forms? 🤔

### Decision Matrix

| Factor | Reactive Forms | Template-Driven Forms | Winner |
|--------|---------------|--------------------|--------|
| **Complexity** | Better for complex forms | Better for simple forms | Depends 🤷‍♂️ |
| **Validation** | Programmatic, flexible | Declarative, simpler | Reactive 🏆 |
| **Testing** | Easier to unit test | Harder to test | Reactive 🏆 |
| **Performance** | Better performance | Good for small forms | Reactive 🏆 |
| **Learning Curve** | Steeper | Gentler | Template-Driven 🏆 |
| **Code Reusability** | High | Moderate | Reactive 🏆 |
| **Real-time Updates** | Excellent with Observables | Limited | Reactive 🏆 |

### Use Reactive Forms When: ⚛️

✅ **Complex validation logic** (cross-field validation, async validation)  
✅ **Dynamic forms** (adding/removing fields at runtime)  
✅ **Real-time form updates** and reactive programming  
✅ **Extensive unit testing** requirements  
✅ **Performance is critical** (large forms)  
✅ **Programmatic form control** (setValue, patchValue, etc.)  
✅ **Complex user interactions** (wizards, multi-step forms)

```typescript
// Example: Dynamic form that adds/removes fields
addField() {
  const control = new FormControl('', Validators.required);
  (this.myForm.get('items') as FormArray).push(control);
}
```

### Use Template-Driven Forms When: 📝

✅ **Simple forms** (login, contact, search)  
✅ **Quick prototyping** and MVP development  
✅ **Team is familiar with Angular templates**  
✅ **Minimal validation requirements**  
✅ **Straightforward user input** scenarios  
✅ **Two-way data binding is preferred**

```html
<!-- Simple contact form - perfect for template-driven -->
<form #contactForm="ngForm">
  <input name="name" [(ngModel)]="contact.name" required>
  <input name="email" [(ngModel)]="contact.email" required email>
  <textarea name="message" [(ngModel)]="contact.message" required></textarea>
</form>
```

---

## 5. Reactive Forms Observables 🔄

Reactive forms provide powerful Observable streams for real-time form monitoring.

### Form Control Observables

```typescript
// reactive-observables.component.ts
import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { takeUntil, debounceTime, distinctUntilChanged, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-reactive-observables',
  template: `
    <form [formGroup]="searchForm">
      <input formControlName="searchTerm" placeholder="Search users...">
      <div class="search-results">
        <p>Search term: {{ currentSearchTerm }}</p>
        <p>Form status: {{ formStatus }}</p>
        <p>Search executed: {{ searchCount }} times</p>
      </div>
    </form>
  `
})
export class ReactiveObservablesComponent implements OnInit, OnDestroy {
  searchForm: FormGroup;
  currentSearchTerm = '';
  formStatus = '';
  searchCount = 0;
  
  private destroy$ = new Subject<void>();

  constructor(private fb: FormBuilder) {
    this.searchForm = this.fb.group({
      searchTerm: ['', [Validators.minLength(2)]]
    });
  }

  ngOnInit() {
    // 1. Value Changes Observable
    this.searchForm.get('searchTerm')?.valueChanges
      .pipe(
        takeUntil(this.destroy$),
        debounceTime(300), // Wait 300ms after user stops typing
        distinctUntilChanged(), // Only emit if value actually changed
        startWith('') // Start with empty string
      )
      .subscribe(value => {
        this.currentSearchTerm = value;
        if (value && value.length >= 2) {
          this.performSearch(value);
        }
      });

    // 2. Status Changes Observable
    this.searchForm.statusChanges
      .pipe(takeUntil(this.destroy$))
      .subscribe(status => {
        this.formStatus = status;
        console.log('Form status changed to:', status);
      });

    // 3. Combined Observables Example
    this.searchForm.valueChanges
      .pipe(
        takeUntil(this.destroy$),
        debounceTime(500)
      )
      .subscribe(formValue => {
        console.log('Entire form value:', formValue);
        // Auto-save functionality could go here
        this.autoSaveForm(formValue);
      });
  }

  private performSearch(term: string) {
    this.searchCount++;
    console.log(`Searching for: ${term}`);
    // Implement your search logic here
  }

  private autoSaveForm(formValue: any) {
    // Auto-save logic
    console.log('Auto-saving form...', formValue);
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
```

### Advanced Observable Patterns

```typescript
// advanced-reactive-patterns.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { combineLatest, merge } from 'rxjs';
import { map, filter, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-advanced-patterns',
  template: `
    <form [formGroup]="userForm">
      <!-- Personal Info -->
      <div formGroupName="personal">
        <input formControlName="firstName" placeholder="First Name">
        <input formControlName="lastName" placeholder="Last Name">
      </div>

      <!-- Address -->
      <div formGroupName="address">
        <select formControlName="country">
          <option value="">Select Country</option>
          <option value="US">United States</option>
          <option value="CA">Canada</option>
        </select>
        <input formControlName="city" placeholder="City">
      </div>

      <!-- Dynamic Skills Array -->
      <div formArrayName="skills">
        <div *ngFor="let skill of skillsArray.controls; index as i" [formGroupName]="i">
          <input formControlName="name" placeholder="Skill name">
          <input formControlName="level" type="number" placeholder="Level (1-10)">
          <button type="button" (click)="removeSkill(i)">Remove</button>
        </div>
        <button type="button" (click)="addSkill()">Add Skill</button>
      </div>

      <div class="form-summary">
        <p>Full Name: {{ fullName$ | async }}</p>
        <p>Address Complete: {{ isAddressComplete$ | async ? '✅' : '❌' }}</p>
        <p>Total Skills: {{ totalSkills$ | async }}</p>
      </div>
    </form>
  `
})
export class AdvancedPatternsComponent implements OnInit {
  userForm: FormGroup;

  // Computed observables
  fullName$ = combineLatest([
    this.fb.group({}).valueChanges, // Will be replaced in ngOnInit
  ]).pipe(
    map(([personal]) => `${personal.firstName || ''} ${personal.lastName || ''}`.trim())
  );

  isAddressComplete$ = this.fb.group({}).valueChanges.pipe( // Will be replaced in ngOnInit
    map(address => address.country && address.city)
  );

  totalSkills$ = this.fb.array([]).valueChanges.pipe( // Will be replaced in ngOnInit
    map(skills => skills.length)
  );

  constructor(private fb: FormBuilder) {
    this.userForm = this.fb.group({
      personal: this.fb.group({
        firstName: [''],
        lastName: ['']
      }),
      address: this.fb.group({
        country: [''],
        city: ['']
      }),
      skills: this.fb.array([])
    });
  }

  ngOnInit() {
    // Set up observables after form is created
    this.fullName$ = this.userForm.get('personal')!.valueChanges.pipe(
      map(personal => `${personal.firstName || ''} ${personal.lastName || ''}`.trim())
    );

    this.isAddressComplete$ = this.userForm.get('address')!.valueChanges.pipe(
      map(address => address.country && address.city)
    );

    this.totalSkills$ = this.skillsArray.valueChanges.pipe(
      map(skills => skills.length)
    );

    // Complex validation based on multiple fields
    combineLatest([
      this.userForm.get('personal.firstName')!.valueChanges,
      this.userForm.get('address.country')!.valueChanges
    ]).pipe(
      filter(([firstName, country]) => firstName && country)
    ).subscribe(([firstName, country]) => {
      console.log(`${firstName} is from ${country}`);
      // Trigger country-specific validations or data loading
    });
  }

  get skillsArray(): FormArray {
    return this.userForm.get('skills') as FormArray;
  }

  addSkill() {
    const skillGroup = this.fb.group({
      name: [''],
      level: [1]
    });
    this.skillsArray.push(skillGroup);
  }

  removeSkill(index: number) {
    this.skillsArray.removeAt(index);
  }
}
```

---

## 6. Template-Driven Example with Signals 📡

Angular Signals provide a new way to handle reactive state in template-driven forms.

```typescript
// template-driven-signals.component.ts
import { Component, signal, computed, effect } from '@angular/core';

interface User {
  name: string;
  email: string;
  age: number | null;
  preferences: {
    newsletter: boolean;
    notifications: boolean;
  };
}

@Component({
  selector: 'app-template-signals',
  template: `
    <form #userForm="ngForm" (ngSubmit)="onSubmit(userForm)">
      <h2>Template-Driven Form with Signals 📡</h2>
      
      <!-- User Basic Info -->
      <div class="form-group">
        <label for="name">Name:</label>
        <input 
          #nameInput="ngModel"
          id="name"
          type="text" 
          name="name"
          [ngModel]="user().name"
          (ngModelChange)="updateUser('name', $event)"
          required
          minlength="2">
        
        <div *ngIf="nameInput.invalid && nameInput.touched">
          <small>❌ Name is required (min 2 characters)</small>
        </div>
      </div>

      <div class="form-group">
        <label for="email">Email:</label>
        <input 
          #emailInput="ngModel"
          id="email"
          type="email" 
          name="email"
          [ngModel]="user().email"
          (ngModelChange)="updateUser('email', $event)"
          required
          email>
        
        <div *ngIf="emailInput.invalid && emailInput.touched">
          <small>❌ Valid email is required</small>
        </div>
      </div>

      <div class="form-group">
        <label for="age">Age:</label>
        <input 
          #ageInput="ngModel"
          id="age"
          type="number" 
          name="age"
          [ngModel]="user().age"
          (ngModelChange)="updateUser('age', $event)"
          required
          min="18"
          max="100">
        
        <div *ngIf="ageInput.invalid && ageInput.touched">
          <small>❌ Age must be between 18 and 100</small>
        </div>
      </div>

      <!-- Preferences -->
      <fieldset class="preferences">
        <legend>Preferences</legend>
        
        <div class="checkbox-group">
          <label>
            <input 
              type="checkbox" 
              name="newsletter"
              [ngModel]="user().preferences.newsletter"
              (ngModelChange)="updatePreference('newsletter', $event)">
            Subscribe to newsletter 📧
          </label>
        </div>

        <div class="checkbox-group">
          <label>
            <input 
              type="checkbox" 
              name="notifications"
              [ngModel]="user().preferences.notifications"
              (ngModelChange)="updatePreference('notifications', $event)">
            Enable notifications 🔔
          </label>
        </div>
      </fieldset>

      <!-- Computed Values Display -->
      <div class="computed-info">
        <h3>Computed Information 🧮</h3>
        <p><strong>Display Name:</strong> {{ displayName() }}</p>
        <p><strong>Age Group:</strong> {{ ageGroup() }}</p>
        <p><strong>Email Domain:</strong> {{ emailDomain() }}</p>
        <p><strong>Profile Complete:</strong> {{ isProfileComplete() ? '✅ Yes' : '❌ No' }}</p>
        <p><strong>Marketing Allowed:</strong> {{ marketingAllowed() ? '✅ Yes' : '❌ No' }}</p>
      </div>

      <!-- Form Actions -->
      <div class="form-actions">
        <button type="submit" [disabled]="userForm.invalid">
          Submit {{ userForm.valid ? '✅' : '❌' }}
        </button>
        <button type="button" (click)="resetUser()">
          Reset 🔄
        </button>
        <button type="button" (click)="loadSampleData()">
          Load Sample Data 📝
        </button>
      </div>

      <!-- Real-time Form State -->
      <div class="form-state">
        <h3>Real-time Form State 📊</h3>
        <p><strong>Form Valid:</strong> {{ userForm.valid ? '✅' : '❌' }}</p>
        <p><strong>Form Dirty:</strong> {{ userForm.dirty ? '✅' : '❌' }}</p>
        <p><strong>Form Touched:</strong> {{ userForm.touched ? '✅' : '❌' }}</p>
      </div>

      <!-- Debug Info -->
      <div class="debug-info">
        <h4>Debug Information 🐛</h4>
        <pre>{{ user() | json }}</pre>
      </div>
    </form>
  `
})
export class TemplateSignalsComponent {
  // Signal for user data
  user = signal<User>({
    name: '',
    email: '',
    age: null,
    preferences: {
      newsletter: false,
      notifications: false
    }
  });

  // Computed signals based on user data
  displayName = computed(() => {
    const currentUser = this.user();
    return currentUser.name || 'Anonymous User';
  });

  ageGroup = computed(() => {
    const age = this.user().age;
    if (!age) return 'Not specified';
    if (age < 25) return 'Young Adult';
    if (age < 40) return 'Adult';
    if (age < 60) return 'Middle-aged';
    return 'Senior';
  });

  emailDomain = computed(() => {
    const email = this.user().email;
    if (!email || !email.includes('@')) return 'Invalid';
    return email.split('@')[1] || 'Unknown';
  });

  isProfileComplete = computed(() => {
    const currentUser = this.user();
    return !!(currentUser.name && currentUser.email && currentUser.age);
  });

  marketingAllowed = computed(() => {
    const prefs = this.user().preferences;
    return prefs.newsletter && prefs.notifications;
  });

  // Effect to log changes
  constructor() {
    effect(() => {
      console.log('User data changed:', this.user());
    });

    effect(() => {
      console.log('Profile completeness:', this.isProfileComplete());
    });
  }

  // Methods to update user data
  updateUser(field: keyof User, value: any) {
    this.user.update(current => ({
      ...current,
      [field]: value
    }));
  }

  updatePreference(preference: keyof User['preferences'], value: boolean) {
    this.user.update(current => ({
      ...current,
      preferences: {
        ...current.preferences,
        [preference]: value
      }
    }));
  }

  resetUser() {
    this.user.set({
      name: '',
      email: '',
      age: null,
      preferences: {
        newsletter: false,
        notifications: false
      }
    });
  }

  loadSampleData() {
    this.user.set({
      name: 'John Doe',
      email: 'john.doe@example.com',
      age: 28,
      preferences: {
        newsletter: true,
        notifications: true
      }
    });
  }

  onSubmit(form: any) {
    if (form.valid) {
      console.log('Form submitted with user data:', this.user());
      // Process form submission
      alert(`Welcome, ${this.displayName()}! 🎉`);
    } else {
      console.log('Form is invalid');
    }
  }
}
```

### Signals vs Observables in Forms 📡 vs 🔄

| Aspect | Signals | Observables |
|--------|---------|------------|
| **Learning Curve** | Simpler | More complex |
| **Performance** | Excellent | Good |
| **Real-time Updates** | Automatic | Manual subscription |
| **Memory Management** | Automatic | Manual unsubscribe |
| **Debugging** | Easier | More complex |
| **Angular Integration** | Native (v16+) | Library-based |

---

## 🎯 Quick Decision Guide

### Choose **Reactive Forms** when you need:
- 🔧 Complex validation logic
- 🔄 Real-time form monitoring with Observables
- 🧪 Extensive unit testing
- ⚡ High performance requirements
- 🔀 Dynamic form fields

### Choose **Template-Driven Forms** when you need:
- 📝 Simple, straightforward forms
- 🚀 Quick development and prototyping
- 💡 Familiar template-based approach
- 📡 Modern reactivity with Signals (Angular 16+)
- 🎯 Minimal learning curve

---

## 🌟 Best Practices Summary

### For Both Approaches:
1. **Always validate on both client and server** 🔒
2. **Provide clear error messages** 💬
3. **Use proper accessibility attributes** ♿
4. **Implement loading states** ⏳
5. **Handle form submission gracefully** ✨

### Reactive Forms Specific:
- Use FormBuilder for cleaner code
- Implement proper unsubscription patterns
- Leverage Observables for real-time features
- Create reusable validators

### Template-Driven Specific:
- Use template reference variables effectively
- Consider Signals for modern reactivity
- Keep validation logic simple
- Focus on two-way data binding benefits

---

## 🎉 Conclusion

Both reactive and template-driven forms have their place in Angular development. The choice depends on your specific requirements, team expertise, and project complexity. 

**Remember:** Start simple with template-driven forms for basic needs, then migrate to reactive forms as complexity grows! 🚀

**Happy Form Building! 🎯**