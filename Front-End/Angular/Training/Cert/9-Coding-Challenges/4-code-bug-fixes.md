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

> 1st attempt:
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