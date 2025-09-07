# Automation Testing

# Automation Testing - Catto Developer Handbook

**Automation Testing** is the use of software tools to execute pre-scripted tests on an application automatically, instead of manually testing. It is essential for **repetitive, regression, and large-scale testing**, helping ensure quality while saving time.

---

## What is Automation Testing?

- Automates **functional, regression, and smoke tests**.  
- Can be run **frequently and consistently**, especially in CI/CD pipelines.  
- Reduces human error compared to manual testing.  
- Often complements manual testing for exploratory and UAT scenarios.  

---

## Why Automation Testing is Important

- Speeds up testing cycles for **rapid releases**.  
- Improves **test coverage** across browsers, devices, and environments.  
- Detects **regression bugs** early in development.  
- Integrates seamlessly with **CI/CD pipelines** for continuous quality.  
- Supports **cross-platform and cross-browser testing**.  

---

## Common Automation Tools / Frameworks

### 1. **Selenium**
- Most widely used open-source tool for **web application automation**.  
- Supports multiple languages: **C#, Java, Python, JavaScript**.  
- Can automate **browser actions**, form submissions, navigation, and validations.  
- Works with browsers like Chrome, Firefox, Edge, Safari.  

**Selenium Example (C#)**

```csharp
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

var driver = new ChromeDriver();
driver.Navigate().GoToUrl("https://example.com");

var searchBox = driver.FindElement(By.Name("q"));
searchBox.SendKeys("Automation testing");
searchBox.Submit();

Console.WriteLine(driver.Title);
driver.Quit();


#### Selenium Example (TypeScript / Node.js)

```javascript

import { Builder, By, until } from 'selenium-webdriver';
import chrome from 'selenium-webdriver/chrome';

const driver = new Builder().forBrowser('chrome').setChromeOptions(new chrome.Options()).build();

await driver.get('https://example.com');
const searchBox = await driver.findElement(By.name('q'));
await searchBox.sendKeys('Automation testing', Key.RETURN);

await driver.wait(until.titleContains('Automation testing'), 5000);
await driver.quit();

```


## Other Popular Frameworks
- **Cypress** – Modern JavaScript framework for frontend testing.
- **Playwright** – Cross-browser testing for web apps; faster than Selenium in many cases.
- **JUnit / NUnit / xUnit** – For backend unit testing in Java or .NET.
- **TestNG** – Advanced testing framework in Java.

***

## Best Practices for Automation Testing
- **Start with stable features**: Automate areas that rarely change first.
- **Use page object model (POM)**: Separates test logic from UI interactions.
- **Run tests in CI/CD pipelines**: Integrate with GitHub Actions, Azure DevOps, Jenkins, etc.
- **Maintain test data**: Use seed data or mock services to ensure repeatable tests.
- **Focus on regression**: Automate repetitive tests to prevent breaking functionality.
- **Keep tests small and modular**: Easier maintenance and debugging.
- **Include reporting**: Generate readable test reports (HTML, XML, or dashboards).
- **Cross-browser testing**: Test major browsers and screen resolutions if applicable.
- **Handle waits carefully**: Use explicit waits instead of arbitrary sleep calls to avoid flaky tests.