# 🚗 Car Configurator: Model and Color

## Challenge Description
In this challenge, you will build a simplified version of [Tesla Model X Configurator](https://www.tesla.com/modelx/design).  
You will focus on **selecting a car model and color** and displaying the corresponding image. 🖼️

---

## Requirements ✅
- Retrieve **models** and **colors** from the API endpoint:  
  `http://localhost:4200/models` 🌐
- Data types are pre-generated in `src/app/models.type.ts` 📄
- A `configurator.service` is provided with a **Signal** holding all available car models. ⚡
- Images for all models and colors are available at:  
  `https://interstate21.com/tesla-app/images/` 🖼️
- Complete the `step1.component` to display the correct information in the two **select dropdowns**.
- When a **Model** and **Color** are selected, display the **corresponding image**.
💡 **HINT:** Use Signals as much as possible in `configurator.service` to store the current state (selected model, selected color).

---

## Other Considerations ⚠️
- Do **not** remove any `data-test` attributes in the boilerplate.
- The project uses **mini.css** for basic styling. 🎨

---

## Example of Finished Application 🎉
The app should display **dropdowns for model and color**, and the selected car image should update dynamically when selections change.

---

## Summary 📝
By completing this challenge, you will learn how to:  
- Fetch data from an API and display it in Angular components 🌐  
- Use **Signals** to store and update reactive state ⚡  
- Dynamically update the UI based on user selections 🔄  


> Official Solution

```ts
// src/app/configurator.service.ts
import {computed, inject, Injectable, signal, Signal} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {toSignal} from '@angular/core/rxjs-interop';
// import {CarModel} from './models.type';
import {CarModel, Color} from './models.type';

@Injectable({
  providedIn: 'root'
})
export class ConfiguratorService {

  private http = inject(HttpClient);
  readonly allModels: Signal<CarModel[]> = toSignal(
    this.http.get<CarModel[]>("models"), {initialValue: []}
  );

  // old given
  // readonly currentCar = signal<CarModel | undefined>(undefined);

  // new code for solution:
  readonly selectableColors = computed(() => this.currentCar()?.colors);

  readonly currentColor = signal<Color | undefined>(undefined);
  readonly currentCar = signal<CarModel | undefined>(undefined);
  readonly currentImage = computed(
    () => {
      const car = this.currentCar();
      const color = this.currentColor();
      if (car && color)
        return `https://interstate21.com/tesla-app/images/${car.code}/${color.code}.jpg`
      else return null;
    }
  );

  selectModel(code: CarModel["code"]) {
    const model = this.allModels().find(model => model.code === code);
    this.currentCar.set(model);
    this.currentColor.set(model?.colors[0]);
  }

  selectColor(code: Color["code"]) {
    const color = this.selectableColors()?.find(color => color.code === code);
    this.currentColor.set(color);
  }

}
```

```ts
// src/app/step1/step1.component.ts
import {Component, inject} from '@angular/core';
import {ReactiveFormsModule} from '@angular/forms';
import {ConfiguratorService} from '../configurator.service';

@Component({
  selector: 'app-step1',
  standalone: true,
    imports: [
        ReactiveFormsModule
    ],
  templateUrl: './step1.component.html',
  styleUrl: './step1.component.scss'
})
export class Step1Component {
  service = inject(ConfiguratorService);
}

// // src/app/step1/step1.component.ts
// import {Component, inject} from '@angular/core';
// import {ReactiveFormsModule} from '@angular/forms';

// @Component({
//   selector: 'app-step1',
//   standalone: true,
//     imports: [
//         ReactiveFormsModule
//     ],
//   templateUrl: './step1.component.html',
//   styleUrl: './step1.component.scss'
// })
// export class Step1Component {

// }
```

```html
<!-- src/app/step1/step1.component.html -->
 <h1>Step 1: Choose your Model and color</h1>
Model:
<select #model (change)="service.selectModel(model.value)">
  <option [value]="0">Choose...</option>
  @for(model of service.allModels(); track model.code) {
    <option [value]="model.code">{{model.description}}</option>
  }
</select>


@if (service.currentCar()) {
  Color:
  <select #color (change)="service.selectColor(color.value)">
    @for(color of service.selectableColors(); track color.code) {
      <option [value]="color.code">{{color.description}}</option>
    }
  </select>
}
<div>
  @if (service.currentImage()) {
    <img [src]="service.currentImage()" />
  }
</div>





<!-- <h1>Step 1: Choose your Model and color</h1>
Model:
<select>
  <option [value]="0">Choose...</option>
  <option>Model 3</option>
</select>

Color:
<select>
    <option>Deep Blue Metallic</option>
</select>
<div>
    <img src="https://interstate21.com/tesla-app/images/3/blue.jpg" />
</div> -->


```


> My 1st Attempt:

Summary of Changes Needed
Here's a concise breakdown of what needs to be updated in your project:
1. configurator.service.ts
Changes made:

Added new signals: selectedModel, selectedColor
Added computed signals: availableColors, imageUrl
Added methods: selectModel(), selectColor()
Fixed API URL to include full path: "http://localhost:4200/models"
Image URL generation uses model.code and color.code directly

2. step1.component.ts
Changes made:

Added CommonModule import for template control flow
Created reactive form with model and color form controls
Added form value change subscriptions to update service signals
Added effect to reset color when model changes
Exposed service signals to template
Updated to work with code properties instead of id

3. step1.component.html
Changes made:

Replaced static options with dynamic @for loops
Added proper form controls binding
Used model.code/color.code for values and description for display
Added conditional rendering for image and selection summary
Added proper data-test attributes
Shows color pricing when applicable
Displays car image when both model and color are selected

4. step1.component.scss
Changes made:

Added complete styling for form groups, selects, and labels
Added styling for car image display with hover effects
Added selection summary styling
Added responsive design
Added focus states and disabled states

Files that were NOT changed:

models.type.ts - Your existing interfaces are perfect as-is
Any other existing files in your project

The main transformation is from static dropdowns to a fully dynamic, reactive car configurator that uses Angular Signals throughout and integrates with your API structure.


Code Flow Explanation
Let me walk you through my thought process and how the code flows together to create this car configurator.
1. Understanding the Requirements
First, I analyzed what was needed:

Fetch car models from API endpoint
Display models and colors in dropdowns
Show car image when both are selected
Use Angular Signals (per the hint)
Keep existing data-test attributes

2. Service Design Decision
Why I restructured the service:
```typescript
// Original (incomplete)
readonly allModels: Signal<CarModel[]> = toSignal(
  this.http.get<CarModel[]>("models"), {initialValue: []}
);
readonly currentCar = signal<CarModel | undefined>(undefined);
``` 
Problems with original:

Only had models, no color selection
No image URL generation
No reactive relationship between model/color
Incomplete API URL

My solution:
```typescript
readonly selectedModel = signal<CarModel | undefined>(undefined);
readonly selectedColor = signal<Color | undefined>(undefined);
readonly availableColors = computed(() => {
  const model = this.selectedModel();
  return model ? model.colors : [];
});
readonly imageUrl = computed(() => {
  // Generate URL when both model and color exist
});
```
Why this approach:

Signals for state: Each selection is a signal that can trigger updates
Computed signals: Colors and image URL automatically update when dependencies change
Separation of concerns: Service handles state, component handles UI

3. Component Design Decision
The flow I designed:
User selects model → Form control changes → Component updates service → Service signals update → Template re-renders
Step-by-step code flow:
A. Form Setup
```ts
configForm = new FormGroup({
  model: new FormControl<string>(''),
  color: new FormControl<string>('')
});
```
Decision: Use reactive forms for better control and validation
B. Model Selection Flow
```typescript
this.configForm.get('model')?.valueChanges.subscribe(modelCode => {
  if (modelCode) {
    const model = this.allModels().find(m => m.code === modelCode);
    this.configuratorService.selectModel(model); // Updates service
  }
  this.configForm.get('color')?.setValue('', { emitEvent: false }); // Reset color
});
```
What happens:

User selects "Model 3"
Form emits "3" as modelCode
Component finds CarModel with code "3"
Service selectedModel signal updates
Service availableColors computed signal automatically recalculates
Color dropdown is reset and re-populated

C. Color Selection Flow
```typescript
this.configForm.get('color')?.valueChanges.subscribe(colorCode => {
  if (colorCode) {
    const color = this.availableColors().find(c => c.code === colorCode);
    this.configuratorService.selectColor(color); // Updates service
  }
});
```
What happens:

User selects "Deep Blue Metallic"
Form emits "blue" as colorCode
Component finds Color with code "blue"
Service selectedColor signal updates
Service imageUrl computed signal automatically recalculates
Image appears on screen

4. Template Reactivity
The magic of Signals in template:
```html
@for (model of allModels(); track model.code) {
  <option [value]="model.code">{{ model.description }}</option>
}

@for (color of availableColors(); track color.code) {
  <option [value]="color.code">{{ color.description }}</option>
}

@if (imageUrl()) {
  <img [src]="imageUrl()!" />
}
```
Why this works:

allModels() - Signal from HTTP call, updates when data loads
availableColors() - Computed signal, updates when model changes
imageUrl() - Computed signal, updates when model OR color changes
Angular's signal integration automatically triggers re-renders

5. Key Design Decisions
Decision 1: Service vs Component State
```typescript
// ❌ Could have done this (component-only):
selectedModel = signal<CarModel | undefined>(undefined);

// ✅ But chose this (service):
selectedModel = this.configuratorService.selectedModel;
```
Reasoning: Service allows sharing state across future Step2, Step3 components
Decision 2: Computed Signals vs Manual Updates
```typescript
// ❌ Could have done this:
selectModel(model: CarModel) {
  this.selectedModel.set(model);
  this.availableColors.set(model.colors); // Manual update
  this.updateImageUrl(); // Manual update
}

// ✅ But chose this:
readonly availableColors = computed(() => {
  const model = this.selectedModel();
  return model ? model.colors : [];
});
```
Reasoning: Computed signals automatically stay in sync, less bugs
Decision 3: Form Integration
```typescript
// ❌ Could have used template-driven:
<select [(ngModel)]="selectedModelCode">

// ✅ But chose reactive forms:
<select formControlName="model">
```
Reasoning: Better validation, more control, easier testing
6. The Complete Flow Diagram
```
API Call → allModels Signal → Model Dropdown Populated
    ↓
User Selects Model → Form Control → Component → Service.selectModel()
    ↓
selectedModel Signal Updates → availableColors Computed Signal Updates → Color Dropdown Updates
    ↓
User Selects Color → Form Control → Component → Service.selectColor()
    ↓
selectedColor Signal Updates → imageUrl Computed Signal Updates → Image Displays
```
7. Why This Architecture?

Reactive: Everything updates automatically through signals
Testable: Service can be tested independently
Scalable: Easy to add Step2, Step3 components
Maintainable: Clear separation between UI and business logic
Performance: Computed signals only recalculate when dependencies change

This approach turns a simple dropdown interaction into a fully reactive system that will scale well as the configurator grows!
