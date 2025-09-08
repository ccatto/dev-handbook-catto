# Jest with TypeScript - Tech Documentation

## Overview
Jest is a delightful JavaScript testing framework with a focus on simplicity. It works seamlessly with TypeScript and provides features such as zero-config setup, snapshot testing, and built-in mocking capabilities. Jest is widely used for testing both frontend and backend applications, including React, Node.js, and Angular projects.

### Key Features
- **Zero configuration**: Works out-of-the-box for most projects.
- **Fast and safe**: Runs tests in parallel processes to maximize performance.
- **Snapshot testing**: Compare UI or output snapshots to detect unexpected changes.
- **Built-in mocking**: Supports mocks for functions, modules, and timers.
- **TypeScript support**: Works with `ts-jest` for TypeScript compilation.

## Setup with TypeScript

1. **Install Jest and ts-jest**
```bash
npm install --save-dev jest ts-jest @types/jest
```

2. **Initialize Jest configuration**
```bash
npx ts-jest config:init
```

3. **Update `package.json`**
```json
"scripts": {
  "test": "jest"
}
```

## Simple Code Example

### Example Function (math.ts)
```ts
export const sum = (a: number, b: number): number => {
  return a + b;
};
```

### Example Test (math.test.ts)
```ts
import { sum } from './math';

describe('sum function', () => {
  it('adds two numbers correctly', () => {
    expect(sum(2, 3)).toBe(5);
  });

  it('adds negative numbers correctly', () => {
    expect(sum(-2, -3)).toBe(-5);
  });
});
```

Run the tests:
```bash
npm test
```

## Comparison with Jasmine and Karma in Angular

| Feature               | Jest                             | Jasmine + Karma (Angular)                 |
|-----------------------|---------------------------------|------------------------------------------|
| Test runner           | Built-in                        | Karma                                    |
| Assertion library     | Built-in                        | Jasmine                                  |
| TypeScript support    | `ts-jest`                        | Supported but requires extra setup       |
| Configuration         | Minimal                          | More configuration needed                |
| Performance           | Fast (parallel)                  | Slower, especially with large projects  |
| Snapshot testing      | Yes                              | No                                       |
| Mocking               | Built-in mocks                   | Jasmine mocks available                  |
| Community adoption    | Very high                        | High in Angular ecosystem                |

**Summary**: Jest offers a simpler setup, faster execution, and snapshot testing out-of-the-box, making it very popular in modern TypeScript projects. Jasmine with Karma is traditionally used in Angular apps, providing tight integration but requiring more setup and slower test runs.

---

*End of Jest with TypeScript Tech Doc*

