# Quiz

> 1 
# Angular Forms: Question

**Which of the following properties is NOT a valid property of an Angular `FormControl`?**

- valid  
- untouched  
- dirty  
- ❌ async  

---

## Key Point
Angular `FormControl` has state properties like `valid`, `invalid`, `dirty`, `pristine`, `touched`, and `untouched` — but not `async`.

## Summary
The invalid property here is `async`, which is not part of Angular’s `FormControl` API.

----

> 2 # Angular Forms: Question

**What is the name of the Angular service used to create reactive forms?**

- FormControl  
- FormService  
- FormFactory  
- ✅ FormBuilder  

---

## Key Point
`FormBuilder` is an Angular service that simplifies creating `FormGroup`, `FormControl`, and `FormArray` instances.

### further info:
FormControl is part of Angular reactive forms, but it’s not a service — it’s a class used to represent and manage the value and state of a single form field.

The question specifically asks:

What is the name of the Angular service used to create reactive forms?

FormControl → a class for individual controls (e.g., an input). You instantiate it with new FormControl(...).

FormBuilder → a service that helps you create FormControl, FormGroup, and FormArray objects more concisely, usually injected into components.

✅ So the correct answer is FormBuilder because it’s the service designed for building forms.

## Summary
The Angular service for creating reactive forms is `FormBuilder`.  

---

> 3 
# Angular Forms: Question

**Which event is emitted when the value of a form control changes in Angular reactive forms?**

- update ❌ Not an Angular reactive forms event — Angular doesn’t emit an `update` event directly.  
- controlChanges ❌ No such event exists in Angular’s reactive forms API.  
- input ❌ This is a DOM event, not the reactive forms API event.  
- ✅ valueChanges ✔ Emits an observable stream whenever the value of the control changes.  

---

## Key Point
Reactive form controls in Angular expose a `valueChanges` observable that emits whenever the control’s value is updated.

## Summary
The correct event is `valueChanges`, as it emits whenever a form control’s value changes.

---

> 4 # Angular Forms: Question

**Which syntax is used to access the underlying `NgForm` instance in a template-driven form?**

- Turning an Observable into a Signal ❌ Not related to Angular forms at all — this belongs to Angular Signals, not forms.  
- #model="ngModel" ❌ This creates a local reference to a `NgModel` directive, not the entire `NgForm`.  
- [ngForm]="value" ❌ This is invalid syntax — `ngForm` is a directive, not an input binding.  
- ✅ #form="ngForm" ✔ Correct — this creates a template reference variable that gives access to the `NgForm` instance.  

---

## Key Point
In template-driven forms, you use `#form="ngForm"` to reference and interact with the `NgForm` instance.

## Summary
The correct syntax is `#form="ngForm"`, which provides access to the underlying `NgForm` object.
