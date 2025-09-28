# 🐛 Car Configurator: Bug Fixes

## Challenge Description
Our car configurator application is mostly complete, but we identified a few **bugs** that need fixing. ⚠️

---

## Bugs Identified 📝
1. **Bug #1:**  
   - If a user creates a **Cybertruck** config and selects **"tow hitch"**, the option remains active when switching to a different model. ❌  
   - Example: Model 3 incorrectly shows the tow hitch as active.  
   ![bug1.png](bug1.png)

2. **Bug #2:**  
   - After selecting a new model, **Step 3 becomes clickable** before a car config is selected in Step 2. ❌  
   ![bug2.png](bug2.png)

3. **Bug #3:**  
   - When returning to Step 1, the **current car model and color do not appear as selected**. ❌  
   - Example: Cybertruck should be selected with the correct color.  
   ![bug3.png](bug3.png)

---

## Requirements ✅
- Fix the three bugs above:
  - Selecting a **new model** should reset all previous configs and colors 🔄
  - **Step 3** should only be enabled after selecting a config in Step 2 ⛔➡️✅
- Keep all `data-test` attributes in the boilerplate intact 🛠️

---

## Example of Fixed Application 🎉
- The app should properly **reset selections**,  
- Only allow navigation to Step 3 when appropriate,  
- Display the correct **model and color selections** on Step 1.

---

## Summary 📝
By completing this bug-fix challenge, you will learn how to:  
- Properly **manage reactive state** across multiple steps ⚡  
- Ensure **UI consistency** when switching selections 🎨  
- Enforce **step navigation rules** for a better user experience 🛣️

> 2nd official attempt: 


-----------
> 1st attempt:
---
Bug Fix Summary
Here's a complete summary of all the fixes and which files were updated:
Bug #1: Tow hitch option persists when switching models
Problem: When switching from Cybertruck (with tow hitch selected) to Model 3, the tow hitch option remained active even though Model 3 shouldn't have it.
Files Updated:

src/app/configurator.service.ts

Fix: Added reset logic in the selectModel() method to clear all options when switching models:
```
typescript
selectModel(code: CarModel["code"]) {
  const model = this.allModels().find(model => model.code === code);
  this.currentCar.set(model);
  this.currentColor.set(model?.colors[0]);
  
  // Reset options when switching models
  this.currentConfig.set(undefined);
  this.currentWheelIsYoke.set(false);
  this.currentTowHitchIsSelected.set(false);
}
```
Bug #2: Step 3 is clickable before selecting a car config
Problem: Users could navigate to Step 3 even when no config was selected in Step 2.
Files Updated:

Your main app component or navigation component (wherever step navigation is handled)

Fix: Use the existing step3Ready computed signal to disable Step 3 navigation:
```html
<button 
  [disabled]="!service.step3Ready()"
  (click)="goToStep(3)">
  Step 3: Summary
</button>
```
Bug #3: Selected model and color don't show when returning to Step 1
Problem: When navigating back to Step 1, the dropdowns showed "Choose..." instead of the currently selected model and color.
Files Updated:

src/app/step1/step1.component.html
src/app/step2/step2.component.html

Fix: Added value binding to all form controls:
Step 1 changes:
```html
<!-- Model select -->
<select #model [value]="service.currentCar()?.code || '0'" (change)="service.selectModel(model.value)">

<!-- Color select -->
<select #color [value]="service.currentColor()?.code || ''" (change)="service.selectColor(color.value)">
```
Step 2 changes:

```html
<!-- Config select -->
<select #config [value]="service.currentConfig()?.id || '0'" (change)="service.selectConfig(config.value)">

<!-- Checkboxes -->
<input type="checkbox" #hitch [checked]="service.currentTowHitchIsSelected()" (change)="service.currentTowHitchIsSelected.set(hitch.checked)"/>
<input type="checkbox" #yoke [checked]="service.currentWheelIsYoke()" (change)="service.currentWheelIsYoke.set(yoke.checked)"/>
```
Files Summary:

src/app/configurator.service.ts - Fixed Bug #1
src/app/step1/step1.component.html - Fixed Bug #3
src/app/step2/step2.component.html - Fixed Bug #3
Your navigation component - Needs update for Bug #2

The key principle across all fixes is ensuring that the UI always reflects the current state in the service, and that state changes properly cascade through the application.

---
> older notes:
--- 
<!-- src/app/step1/step1.component.html -->
<h1>Step 1: Choose your Model and color</h1>
Model:
<select #model [value]="service.currentCar()?.code || '0'" (change)="service.selectModel(model.value)">
  <option [value]="'0'">Choose...</option>
  @for(Summary of the fixes:
For Step 1 (Bug #3 fix):

Model select: Added [value]="service.currentCar()?.code || '0'" to bind the select to the current car
Color select: Added [value]="service.currentColor()?.code || ''" to bind the select to the current color

For Step 2 (Bug #3 fix):

Config select: Added [value]="service.currentConfig()?.id || '0'" to bind the select to the current config
Tow hitch checkbox: Added [checked]="service.currentTowHitchIsSelected()" to bind to the current state
Yoke checkbox: Added [checked]="service.currentWheelIsYoke()" to bind to the current state

ConfiguratorService (Bug #1 fix):
The service already has the fix in the first artifact - when selectModel() is called, it resets all the options:
typescript// Reset options when switching models
this.currentConfig.set(undefined);
this.currentWheelIsYoke.set(false);
this.currentTowHitchIsSelected.set(false);
For Bug #2:
You'll need to ensure your navigation component (wherever you have the step buttons) uses the step3Ready signal to disable Step 3 until a config is selected. If you show me your main app component or navigation, I can provide the specific fix.
These changes will:

Fix Bug #1: Options are cleared when switching models
Fix Bug #3: Form controls show the correct selected values when navigating back to previous steps
Fix Bug #2: Step 3 will only be accessible when step3Ready() is true (you'll need to implement the navigation logic)

The key insight is that Angular's template-driven forms need explicit binding with [value] and [checked] to reflect the current state from your service.