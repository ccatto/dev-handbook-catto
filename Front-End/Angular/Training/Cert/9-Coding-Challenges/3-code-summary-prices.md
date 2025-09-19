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
