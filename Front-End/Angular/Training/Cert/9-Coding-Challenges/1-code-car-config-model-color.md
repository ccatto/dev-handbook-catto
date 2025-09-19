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

