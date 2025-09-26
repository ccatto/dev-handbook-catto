# 🚗 Car Configurator: Summary and Price

## Challenge Description
Update the simplified Tesla Model X Configurator ([Tesla Design](https://www.tesla.com/modelx/design)) to display a **recap of the total cost** for the selected car model and options. 💰✨

---

## Requirements ✅
- Update the **router** to add a route:
  - `http://localhost:4200/step3` → `step3.component` 🛣️
- Disallow navigation to **Step 3** until:
  - Car and color are selected in Step 1  
  - Config is selected in Step 2 ⛔
- Complete `configurator.service` to **compute the total car price** using a computed Signal ⚡
- Complete `step3.component` to display:
  - Cost of each chosen option (color, config, yoke, tow hitch, etc.) 💵
  - Properly formatted USD prices 💵💵
  - Total cost 🏷️
- Users should be able to **navigate back** to Step 1 or 2, change selections, and return to Step 3 to see updated costs 🔄

---

## Other Considerations ⚠️
- Do **not** remove any `data-test` attributes in the boilerplate.
- The project uses **mini.css** for basic styling. 🎨

---

## Example of Finished Application 🎉
The app should show **each selected option with its cost**, plus a **dynamic total price** that updates whenever a user changes the configuration.

---

## Summary 📝
By completing this challenge, you will learn how to:  
- Use **Angular router** for multi-step navigation 🛣️  
- Maintain a **computed reactive Signal** for total price calculation ⚡  
- Display **formatted monetary values** in the UI 💵  
- Ensure **state persists across steps** and updates dynamically 🔄

> 2nd attempt official solution: 

Files:
1. routes.ts
2. configurator.service.ts
3. step3.component.html
4. src/app/app.component.html

routes.ts:
added import and route for step3: 
```ts
  {path: 'step3', component: Step3Component, canActivate: [() => inject(ConfiguratorService).step3Ready()]}
```

configurator.service.ts
added step3Ready and totalCost
```ts
 readonly step3Ready: Signal<boolean> = computed(() => this.step2Ready() && this.currentConfig() != undefined);
 readonly totalCost = computed(() => {
  return (this.currentConfig()?.price ?? 0) +
   (this.currentColor()?.price || 0) +
   (this.currentWheelIsYoke() ? 1000 : 0) +
   (this.currentTowHitchIsSelected() ? 1000 : 0);
 })
 ```

step3.component.html 
added a bunch of if conditions 
```html
@if( service.currentConfig(); as config) {
  @if(service.currentColor(); as color) {
      @if(service.currentWheelIsYoke()) {

```

src/app/app.component.html
update our step 3 button:
```html

  <!-- <button routerLink="step3"> -->
      <button routerLink="step3"  [disabled]="! service.step3Ready()"
```

> 1st attempt: 

Here's a summary of all the changes:
📁 app.routes.ts

Added Step3Component import
Added route for /step3 with step3Ready() guard

📁 configurator.service.ts
New additions:

step3Ready computed signal (line 31-33)
totalPrice computed signal (lines 35-64) that calculates:

Base car price
Color price
Config price
Optional yoke price (if selected)
Optional tow hitch price (if selected)



📁 step3.component.ts

Added RouterLink import for navigation buttons

📁 step3.component.html
Complete rewrite with:

Dynamic car model display: {{ service.currentCar()?.description }}
Conditional rendering using @if syntax
Proper currency formatting: | currency:'USD':'symbol':'1.2-2'
Only shows selected options (yoke/tow hitch)
Navigation buttons to go back to Step 1 or 2
Uses the computed totalPrice() for the total

🔒 Route Protection
The app now prevents users from accessing Step 3 until:

✅ Car is selected (Step 1)
✅ Color is selected (Step 1)
✅ Config is selected (Step 2)

🔄 Reactivity
Thanks to Angular signals, when users go back and change selections, the Step 3 summary will automatically update with new prices and options!
All files should now work together to create the complete car configurator experience.