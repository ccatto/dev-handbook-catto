# Forms

# Angular Forms Tutorial: The Basics 📚

The Angular Forms module brings a lot of features to the table to handle form validation, form submission, and error management. In this lesson, let's cover the basics of form controls, access, and validation state.

## 🎯 What You'll Learn

* The **FormControl** class
* **Basic form validation with Angular**
* Using **template reference variables to access input values**

---

## 1. The FormControl Class 🎮

The `FormControl` class is the foundation of Angular reactive forms. It tracks the value and validation status of an individual form control.

### Setting Up FormControl

First, make sure to import the necessary modules:

```typescript
import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-my-form',
  templateUrl: './my-form.component.html'
})
export class MyFormComponent {
  // Create a FormControl instance
  emailControl = new FormControl('', [Validators.required, Validators.email]);
  nameControl = new FormControl('John Doe');
}
```

### Using FormControl in Templates

```html
<!-- Bind FormControl to input -->
<input [formControl]="emailControl" type="email" placeholder="Enter email">
<input [formControl]="nameControl" type="text" placeholder="Enter name">

<!-- Display current values -->
<p>Email: {{ emailControl.value }}</p>
<p>Name: {{ nameControl.value }}</p>
```

### Key FormControl Properties 📋

- `value` - Current value of the control
- `valid` - Boolean indicating if the control is valid
- `invalid` - Boolean indicating if the control is invalid
- `touched` - Boolean indicating if the control has been touched
- `untouched` - Boolean indicating if the control hasn't been touched
- `dirty` - Boolean indicating if the value has changed
- `pristine` - Boolean indicating if the value hasn't changed

---

## 2. Basic Form Validation with Angular ✅

Angular provides built-in validators and allows you to create custom validators for comprehensive form validation.

### Built-in Validators

```typescript
import { Validators } from '@angular/forms';

export class MyFormComponent {
  // Using multiple validators
  emailControl = new FormControl('', [
    Validators.required,
    Validators.email,
    Validators.minLength(5)
  ]);
  
  passwordControl = new FormControl('', [
    Validators.required,
    Validators.minLength(8),
    Validators.pattern(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$/)
  ]);
  
  ageControl = new FormControl('', [
    Validators.required,
    Validators.min(18),
    Validators.max(65)
  ]);
}
```

### Common Built-in Validators 🔧

| Validator | Description | Example |
|-----------|-------------|---------|
| `required` | Field must have a value | `Validators.required` |
| `email` | Must be valid email format | `Validators.email` |
| `minLength(n)` | Minimum character length | `Validators.minLength(8)` |
| `maxLength(n)` | Maximum character length | `Validators.maxLength(50)` |
| `min(n)` | Minimum numeric value | `Validators.min(18)` |
| `max(n)` | Maximum numeric value | `Validators.max(65)` |
| `pattern(regex)` | Must match regex pattern | `Validators.pattern(/^\d+$/)` |

### Displaying Validation Errors

```html
<div class="form-group">
  <input [formControl]="emailControl" type="email" placeholder="Email">
  
  <!-- Show errors conditionally -->
  <div class="error-messages" *ngIf="emailControl.invalid && emailControl.touched">
    <small *ngIf="emailControl.errors?.['required']">❌ Email is required</small>
    <small *ngIf="emailControl.errors?.['email']">❌ Please enter a valid email</small>
    <small *ngIf="emailControl.errors?.['minlength']">❌ Email must be at least 5 characters</small>
  </div>
</div>
```

### Custom Validator Example

```typescript
import { AbstractControl, ValidationErrors } from '@angular/forms';

// Custom validator function
export function forbiddenNameValidator(control: AbstractControl): ValidationErrors | null {
  const forbidden = /admin|root|test/.test(control.value);
  return forbidden ? { forbiddenName: true } : null;
}

// Usage in component
nameControl = new FormControl('', [
  Validators.required,
  forbiddenNameValidator
]);
```

---

## 3. Using Template Reference Variables to Access Input Values 🔗

Template reference variables provide a simple way to access input values without using reactive forms, especially useful for small forms.

### Basic Template Reference Variables

```html
<!-- Create template reference variable with #variableName -->
<input #emailInput type="email" placeholder="Enter email">
<input #nameInput type="text" placeholder="Enter name">

<!-- Access values directly -->
<button (click)="handleSubmit(emailInput.value, nameInput.value)">
  Submit 🚀
</button>

<!-- Display current values -->
<p>Current email: {{ emailInput.value }}</p>
<p>Current name: {{ nameInput.value }}</p>
```

### Component Method

```typescript
export class MyFormComponent {
  handleSubmit(email: string, name: string) {
    console.log('Email:', email);
    console.log('Name:', name);
    
    // Process form data
    if (email && name) {
      // Submit logic here
      alert(`Form submitted! Welcome, ${name}! 🎉`);
    }
  }
}
```

### Template Reference Variables with Validation

```html
<form #myForm="ngForm" (ngSubmit)="onSubmit(myForm)">
  <div>
    <input 
      #emailInput="ngModel" 
      [(ngModel)]="user.email" 
      name="email" 
      type="email" 
      required 
      email
      placeholder="Email">
    
    <!-- Show validation state -->
    <div *ngIf="emailInput.invalid && emailInput.touched">
      <small *ngIf="emailInput.errors?.['required']">❌ Email is required</small>
      <small *ngIf="emailInput.errors?.['email']">❌ Invalid email format</small>
    </div>
  </div>
  
  <button type="submit" [disabled]="myForm.invalid">
    Submit {{ myForm.valid ? '✅' : '❌' }}
  </button>
</form>
```

### Accessing Template Variables in Component

```typescript
import { ViewChild, ElementRef } from '@angular/core';

export class MyFormComponent {
  @ViewChild('emailInput') emailInputRef!: ElementRef;
  
  focusEmail() {
    this.emailInputRef.nativeElement.focus();
  }
  
  clearEmail() {
    this.emailInputRef.nativeElement.value = '';
  }
}
```

---

## 💡 Pro Tips

### When to Use Each Approach

**✅ Use FormControl/Reactive Forms when:**
- Complex validation logic
- Dynamic form fields
- Cross-field validation
- Programmatic form manipulation
- Testing requirements

**✅ Use Template Reference Variables when:**
- Simple forms (login, search, contact)
- Minimal validation needs
- Quick prototypes
- Read-only form interactions

### Best Practices 🌟

1. **Always validate on both client and server side** 🔒
2. **Provide clear, user-friendly error messages** 💬
3. **Use proper HTML input types** (email, tel, url, etc.)
4. **Implement accessibility features** (labels, ARIA attributes)
5. **Test your forms thoroughly** 🧪

### Quick Comparison Table

| Feature | FormControl | Template Reference |
|---------|-------------|-------------------|
| Complexity | High ⚡ | Low 🌱 |
| Validation | Advanced ✅ | Basic ✅ |
| Testing | Easy 🧪 | Moderate 🧪 |
| Performance | Better 🚀 | Good 👍 |
| Learning Curve | Steeper 📈 | Gentle 📉 |

---

## 🎉 Conclusion

Angular Forms provide powerful tools for handling user input, whether you need the full power of reactive forms with FormControl or the simplicity of template reference variables. Choose the right approach based on your form's complexity and requirements.

**Remember:** Very small forms (login, search, etc.) don't even need the Angular Forms module and can rely on template-reference variables instead! 🎯

---

**Happy Coding! 🚀**
