# Vite - Developer Handbook

**Vite** is a modern **frontend build tool and development server** designed to provide **fast startup, hot module replacement (HMR), and optimized builds** for modern JavaScript and TypeScript projects.

---

## Overview

- Created by **Evan You** (creator of Vue.js).  
- Focuses on **speed and simplicity** by leveraging **native ES modules** in development.  
- Supports **multiple frontend frameworks**, including **Vue, React, Preact, Svelte, and vanilla JS**.  
- Integrates seamlessly with **npm, Yarn, or pnpm**.  

---

## Why Vite is Important

- **Instant server start:** Uses native ES modules, avoiding large bundle rebuilds.  
- **Hot Module Replacement (HMR):** Reflects code changes instantly in the browser.  
- **Optimized production build:** Uses **Rollup** under the hood for fast, tree-shaken bundles.  
- **Framework-agnostic:** Works with most modern JavaScript frameworks.  
- **Plugin ecosystem:** Rich ecosystem for TypeScript, JSX, CSS, and more.

---

## Angular and Vite

- Angular traditionally uses **Angular CLI (Webpack-based)** for builds and development.  
- With **Vite**, Angular projects can achieve **faster development server start times** and **hot module replacement (HMR)**.  
- Common approaches to use Vite with Angular:  
  - **Nx + Vite**: Use Nx monorepo tooling to generate Angular apps with Vite support.  
  - **vite-plugin-angular**: Community plugin to integrate Angular compilation with Vite.  
- Benefits for Angular projects:  
  - Faster rebuilds and live reloads during development.  
  - Simplified configuration compared to Angular CLI’s Webpack setup.  
  - Ability to share Vite plugins across multiple frameworks in a monorepo.

---

## Vite and Vue

- **Creator:** Evan You (also the creator of Vue.js) designed Vite to improve **Vue development experience**.  
- **Integration with Vue:** Vite provides **native support for Vue Single File Components (SFCs)**, enabling fast hot module replacement (HMR) and instant dev server start.  
- **Benefits for Vue developers:**
  - Near-instant project startup.
  - Lightning-fast updates when editing components.
  - Optimized production builds using Rollup.
- **Framework-agnostic:** Although Vite works best initially with Vue, it now fully supports React, Svelte, Angular, and other frameworks.


---

## Installation

```bash
# Using npm
npm create vite@latest my-app

# Using Yarn
yarn create vite my-app

# Using pnpm
pnpm create vite my-app
```

### Basic Commands
```bash
# Start development server
npm run dev   # or yarn dev

# Build for production
npm run build # or yarn build

# Preview production build locally
npm run preview
```

### Suggested Folder/File Structure for Vite Docs
```bash
vite/
  ├── overview.md         # This file
  ├── installation.md     # npm, Yarn, pnpm installation
  ├── commands.md         # dev, build, preview
  ├── framework-setup.md  # React, Vue, Svelte examples
  └── plugins.md          # Popular plugins and integrations
```

### Summary

Vite is a modern, fast, and flexible tool for frontend development. It reduces build times, accelerates development workflow, and simplifies configuration compared to older bundlers like Webpack.
It’s commonly used with npm or Yarn, but it’s a distinct tool in the frontend ecosystem, deserving its own documentation in a developer handbook.