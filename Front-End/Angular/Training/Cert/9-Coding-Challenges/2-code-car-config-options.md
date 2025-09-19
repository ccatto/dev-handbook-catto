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
