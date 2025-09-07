# Angular CLI - Developer Handbook

The **Angular CLI (Command Line Interface)** is a powerful tool that **simplifies development, scaffolding, building, and deployment** of Angular applications. It allows developers to generate components, services, modules, and more, while following best practices automatically.

---

## Overview

- Official tool maintained by the **Angular Team**.  
- Helps **automate repetitive tasks**, enforce project conventions, and speed up development.  
- Works seamlessly with **npm or Yarn**.  
- Provides commands for **project creation, development server, builds, testing, and deployment**.

---

## Installation

```bash
# Install Angular CLI globally using npm
npm install -g @angular/cli

# Verify installation
ng version
```

* You can also install it with Yarn:
```bash
yarn global add @angular/cli
```

### Common Angular CLI Commands
#### Project Commands
```bash
# Create a new Angular project
ng new my-app

# Serve the application in development mode
ng serve

# Build the application for production
ng build --prod

# Add Angular features or libraries
ng add @angular/material
```
### Generators
#### Angular CLI helps generate boilerplate code:
```bash
# Generate a new component
ng generate component my-component
# or shorthand
ng g c my-component

# Generate a service
ng g s my-service

# Generate a module
ng g m my-module

# Generate a directive
ng g d my-directive

# Generate a pipe
ng g p my-pipe
```

### Testing
```bash
# Run unit tests with Karma
ng test

# Run end-to-end tests with Protractor / Cypress
ng e2e
```


### Other Useful Commands
```bash
# Update Angular CLI and project dependencies
ng update @angular/cli @angular/core

# Lint the project
ng lint

# Serve with a specific port
ng serve --port 4201
```


### Best Practices

* Use CLI generators to maintain consistent file and folder structure.
* Run ng lint and ng test frequently during development.
* Take advantage of ng add to integrate libraries like Angular Material or PWA support.
* Use --dry-run option when generating code to see changes without actually creating files.