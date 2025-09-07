# Node Testing

# Node.js Testing - Developer Handbook

Testing is a **critical part of Node.js development** to ensure that applications are reliable, maintainable, and scalable. Node.js supports **unit, integration, and end-to-end (E2E) testing**, leveraging both JavaScript and TypeScript testing frameworks.

---

## Why Testing is Important in Node.js

- Detects **bugs early** in development.  
- Ensures **code quality and maintainability**.  
- Supports **continuous integration and deployment (CI/CD)**.  
- Allows **refactoring with confidence**.  
- Helps enforce **business logic correctness** and workflow validation.  

---

## Types of Testing

1. **Unit Testing**
   - Tests individual functions or modules.  
   - Focuses on **isolated pieces of code**.  
   - Frameworks: **Jest, Mocha, Jasmine**.  

2. **Integration Testing**
   - Tests **interaction between modules or external systems** (e.g., databases, APIs).  
   - Ensures components work together as expected.  
   - Frameworks: **Mocha, Chai, Supertest**.  

3. **End-to-End (E2E) Testing**
   - Tests the **entire application flow**.  
   - Simulates real user behavior.  
   - Frameworks: **Cypress, Playwright, Selenium (via Node bindings)**.  

---

## Popular Node.js Testing Frameworks

### 1. **Jest**
- Developed by Facebook, widely used for **unit and integration tests**.  
- Includes **mocking, snapshot testing, and coverage reports**.  

**Example (Jest)**:
```javascript
// sum.js
function sum(a, b) {
  return a + b;
}
module.exports = sum;

// sum.test.js
const sum = require('./sum');

test('adds 2 + 3 to equal 5', () => {
  expect(sum(2, 3)).toBe(5);
});


```

1. Jest
A popular, zero-configuration testing framework for JavaScript.
Used for unit, integration, and snapshot testing.
Example:
// sum.js
function sum(a, b) {
  return a + b;
}
module.exports = sum;

// sum.test.js
const sum = require('./sum');
test('adds 1 + 2 to equal 3', () => {
  expect(sum(1, 2)).toBe(3);
});

Run test:
npx jest

2. Mocha + Chai
Mocha is a flexible test runner, Chai provides assertion styles.
Great for unit and integration tests.
Example (Mocha + Chai):
```javascript
const { expect } = require('chai');
const sum = require('./sum');
describe('Sum function', () => {
  it('should return 5 for 2 + 3', () => {
    expect(sum(2, 3)).to.equal(5);
  });
});
```

Run test:
`npx mocha`

3. Supertest
Used for HTTP integration testing of Node.js APIs.
Example (Supertest + Express):
```javascript
const request = require('supertest');
const express = require('express');
const app = express();
app.get('/hello', (req, res) => res.send('Hello World!'));
describe('GET /hello', () => {
  it('responds with Hello World!', (done) => {
    request(app)
      .get('/hello')
      .expect(200)
      .expect('Hello World!', done);
  });
});
```

4. Cypress / Playwright
For end-to-end testing of web applications.
Automates browser interactions, form submissions, navigation, and validations.
Integrates with Node.js projects seamlessly.

Best Practices for Node.js Testing
- Write tests alongside code (TDD / BDD approach).
- Isolate unit tests; mock external dependencies.
- Use descriptive test names to improve readability.
- Run tests automatically in CI/CD pipelines.
- Measure coverage but don’t rely solely on 100% coverage.
- Separate test environments from production.
- Use async/await for testing asynchronous code.