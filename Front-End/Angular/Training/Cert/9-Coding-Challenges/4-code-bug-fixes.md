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
