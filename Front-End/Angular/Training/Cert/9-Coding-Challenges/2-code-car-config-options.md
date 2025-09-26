# 🚗 Car Configurator: Config Options

## Challenge Description
Update the simplified Tesla Model X Configurator ([Tesla Design](https://www.tesla.com/modelx/design)) to allow users to select **car configurations and options** that affect **range, maximum speed, and total cost**. ⚡💰

---

## Requirements ✅
- Update the **router** to add the following routes:
  - `http://localhost:4200/step1` → `step1.component`
  - `http://localhost:4200/step2` → `step2.component` 🛣️
- Add **router links** in the navigation bar to both steps for easy navigation. 🔗
- Disallow navigation to **Step 2** until **car and color** are selected on Step 1. ⛔
- Complete `configurator.service` to handle **car configuration and options**, including different prices for different models. 💾
- On **Step 2**, use the `/options/:modelCode` API endpoint to fetch available options for the selected car. 🌐
- Display **two optional add-ons** ($1,000 each) if available:
  - Yoke steering wheel
  - Tow hitch package
- When a config is selected, display its **range, max speed, and cost**.
- Complete `step2.component` to display correct **dropdowns and checkboxes**.  
💡 **HINT:** Use **Signals** as much as possible to store the current state (selected config, selected options) ⚡

---

## Other Considerations ⚠️
- Do **not** remove any `data-test` attributes in the boilerplate.
- The project uses **mini.css** for basic styling. 🎨

---

## Example of Finished Application 🎉
The app should dynamically display **available configurations and options**, update **range, max speed, and cost** based on selections, and prevent navigating forward until necessary selections are made.

---

## Summary 📝
By completing this challenge, you will learn how to:  
- Use **Angular router** for multi-step navigation 🛣️  
- Dynamically fetch and display **configuration options** based on user selections 🌐  
- Maintain reactive **state using Signals** to manage selections ⚡  
- Update the UI dynamically with **dropdowns, checkboxes, and computed values** 🔄


> Official Solution: 

Files: 
1. app.routes.ts
2. step2.component.ts
3. src/app/app.component.html
4. src/app/configurator.service.ts
5. step2.component.html
6. app.component.html
7. app.component.ts


<!-- src/app/step2/step2.component.html -->
<h1>Step 2: Select your config and options</h1>
Config:
<select #config (change)="service.selectConfig(config.value)">
  <option [value]="0">Choose...</option>
  @for(config of service.selectableOptions()?.configs; track config.id) {
    <option [value]="config.id">{{config.description}}</option>
  }
</select>
@if( service.currentConfig(); as config) {
  <div>
    Range: {{config.range}} miles
    - Max speed: {{config.speed}}
    - Cost: {{config.price | currency}}
  </div>
}
<div>
@if (service.selectableOptions()?.towHitch) {
  Tow hitch?
  <input type="checkbox" #hitch (change)="service.currentTowHitchIsSelected.set(hitch.checked)"/>
}
  <br/>
@if (service.selectableOptions()?.yoke) {
  Yoke steering wheel? <input type="checkbox" #yoke (change)="service.currentWheelIsYoke.set(yoke.checked)"  />
}
</div>

// src/app/configurator.service.ts
import {computed, effect, inject, Injectable, signal, Signal} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {toSignal} from '@angular/core/rxjs-interop';
import {CarModel, CarOptions, Color, Config} from './models.type';

@Injectable({
  providedIn: 'root'
})
export class ConfiguratorService {

  private http = inject(HttpClient);
  readonly allModels: Signal<CarModel[]> = toSignal(
    this.http.get<CarModel[]>("models"), {initialValue: []}
  );

  readonly selectableColors = computed(() => this.currentCar()?.colors);
  readonly selectableOptions = signal<CarOptions | null>(null);

  readonly currentColor = signal<Color | undefined>(undefined);
  readonly currentCar = signal<CarModel | undefined>(undefined);
  readonly currentConfig = signal<Config | undefined>(undefined);
  readonly currentWheelIsYoke = signal<boolean>(false);
  readonly currentTowHitchIsSelected = signal<boolean>(false);
  readonly currentImage = computed(
    () => {
      const car = this.currentCar();
      const color = this.currentColor();
      if (car && color)
        return `https://interstate21.com/tesla-app/images/${car.code}/${color.code}.jpg`
      else return null;
    }
  );
  readonly step2Ready: Signal<boolean> = computed(() => this.currentCar() != undefined && this.currentColor() != undefined);

  constructor() {
    effect(() => {
      if (this.currentCar()?.code)
        this.http.get<CarOptions>("options/" + this.currentCar()?.code)
          .subscribe(options => this.selectableOptions.set(options))
    });
  }


  selectModel(code: CarModel["code"]) {
    const model = this.allModels().find(model => model.code === code);
    this.currentCar.set(model);
    this.currentColor.set(model?.colors[0]);
  }

  selectColor(code: Color["code"]) {
    const color = this.selectableColors()?.find(color => color.code === code);
    this.currentColor.set(color);
  }

  selectConfig(id: string) {
    const config = this.selectableOptions()?.configs.find(c => c.id === +id);
    this.currentConfig.set(config);
  }
}

<!-- src/app/app.component.html -->
<div class="button-group">
  <!-- <button>Step 1</button> -->
  <!-- <button> -->
      <button routerLink="step1">Step 1</button>
  <button routerLink="step2" [disabled]="! service.step2Ready()">


// src/app/app.routes.ts
import { Routes } from '@angular/router';
import {Step1Component} from './step1/step1.component';
import {Step2Component} from './step2/step2.component';
import {inject} from '@angular/core';
import {ConfiguratorService} from './configurator.service';

export const routes: Routes = [
  {path: '', redirectTo: 'step1', pathMatch: "full"},
  {path: 'step1', component: Step1Component},
  {path: 'step2', component: Step2Component, canActivate: [() => inject(ConfiguratorService).step2Ready()]}
];


// import { Routes } from '@angular/router';

// export const routes: Routes = [];



> 1st attempt my solution: 

Here's a complete implementation of your car configurator with all the requirements:
Key Features Implemented:

Router Configuration:

Added routes for /step1 and /step2
Implemented a route guard that prevents navigation to step 2 unless both car and color are selected


Navigation Bar:

Added router links in the app component navigation
Step 2 link is visually disabled when requirements aren't met


Enhanced ConfiguratorService:

Added signals for current config, options, and selections
Implemented methods to handle config selection and option toggling
Added computed total cost that includes $1,000 for each selected option
Added API call to load model options using /options/:modelCode endpoint


Step 1 Component:

Complete car and color selection interface
Shows car preview image
Navigation button to step 2 (disabled until both selections made)


Step 2 Component:

Loads options via API when component initializes
Dropdown populated with available configs from API
Displays range, max speed, and cost when config is selected
Shows tow hitch and yoke steering options only when available (based on API booleans)
Each option adds $1,000 to total cost
Shows running total cost
Back navigation to step 1


Route Guard:

Prevents direct navigation to step 2 without completing step 1
Redirects back to step 1 if requirements not met



Additional Files You'll Need:
You'll also need to update your main.ts to include the HTTP client:

