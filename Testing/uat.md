# UAT - User Acceptance Testing

# User Acceptance Testing (UAT) - Catto Developer Handbook

**User Acceptance Testing (UAT)** is the final phase of the software testing lifecycle. It ensures that the application meets the business requirements and works as expected from the end user’s perspective before it is released to production.

---

## What is UAT?

- UAT is **performed by the end users or stakeholders**, not developers.  
- Its goal is to verify that the software **solves the intended business problem** and **meets the acceptance criteria**.  
- UAT typically happens **after functional, integration, and system testing** are complete.  
- Common types of UAT:
  - **Alpha Testing** – Internal users within the organization.  
  - **Beta Testing** – Selected external users or customers.  

---

## Why UAT is Important

- Confirms the software meets **business requirements**.  
- Reduces the risk of **critical issues in production**.  
- Improves **user satisfaction** and adoption.  
- Provides feedback on **usability, workflow, and functionality** that may not have been obvious in earlier testing phases.  

---

## How to Create UAT Scripts

UAT scripts (or test cases) guide end users on what to test. A good UAT script includes **clear steps, expected results, and acceptance criteria**.

### Steps to Create UAT Scripts:

1. **Identify Key Business Scenarios**
   - Focus on real-world tasks users will perform.
   - Examples: “Submit a new customer order,” “Update profile information,” “Generate monthly report.”

2. **Define Test Objectives**
   - What feature or business requirement is being validated?

3. **Write Clear Test Steps**
   - Step-by-step instructions for the user.
   - Example:  
     1. Log in as a standard user.  
     2. Navigate to the "Orders" page.  
     3. Click “Create New Order.”  
     4. Fill in required fields and submit.  

4. **Define Expected Results**
   - Clearly state what should happen.  
   - Example: “The new order appears in the order list with status ‘Pending’.”

5. **Include Acceptance Criteria**
   - Specific conditions that determine if the test passes or fails.

6. **Prioritize Tests**
   - Critical workflows first, then secondary features.

7. **Document Results**
   - Pass, fail, or comments for each step.  
   - Include screenshots for any defects.  

---

## Why Tab Order is Important

- Tab order defines the **keyboard navigation sequence** of interactive elements on a page.  
- Proper tab order ensures **accessibility for all users**, including those who rely on keyboards or screen readers.  
- Misaligned tab order can cause confusion and errors during UAT, especially for users testing workflow tasks.

**Best Practices:**
- Follow a **logical, top-to-bottom, left-to-right flow**.  
- Include **form fields, buttons, and interactive elements** in the tab sequence.  
- Test UAT scripts using **keyboard navigation** to ensure usability.

---

## Additional Best Practices for UAT

- **Use real-world data** that mirrors production scenarios.  
- **Include cross-browser and device checks** if applicable.  
- **Involve actual end users** to capture usability feedback.  
- **Track defects systematically** in a tool like Jira, Azure DevOps, or GitHub Issues.  
- **Review workflows and edge cases**, not just happy paths.  
- **Maintain a sign-off process** where stakeholders formally approve UAT completion before release.  

---

