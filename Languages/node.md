# Node 

# Node.js - Developer Handbook

**Node.js** is a **cross-platform, JavaScript runtime environment** built on Chrome’s V8 engine that allows developers to run JavaScript **outside of the browser**, enabling server-side programming.  

It has become a cornerstone of modern web development because **many frameworks, build tools, and frontend ecosystems rely on Node.js for package management, server-side rendering, automation, and task execution**.

---

## Why Node.js is Important

- Powers **backend services and APIs** using JavaScript/TypeScript.  
- Essential for **frontend build tools** like Webpack, Vite, Angular CLI, and Next.js.  
- Supports **serverless functions** and cloud deployments (AWS Lambda, Azure Functions).  
- Provides access to **npm and thousands of libraries**, enabling rapid development.  
- Widely adopted in **microservices, DevOps scripts, CI/CD pipelines**, and automation.  

---

## Brief History

- **Created in 2009** by Ryan Dahl.  
- Built on **Google’s V8 JavaScript engine** for high performance.  
- Introduced **non-blocking, event-driven architecture** for scalable I/O.  
- Quickly became the standard runtime for **full-stack JavaScript development**.  

---

## Latest Node.js Versions (as of 2025)

| Version | Release Type | Key Features |
|---------|--------------|--------------|
| **Node.js 20 LTS** | LTS | Stable, high-performance, V8 11+, enhanced timers and diagnostics, native fetch API |
| **Node.js 21 Current** | Current | Latest features, experimental modules, improved performance, security updates |

> Note: Use **LTS versions in production** for stability.

---

## Installing Node.js

### Using Node Version Manager (NVM)

**NVM** allows you to install and switch between multiple Node.js versions easily.

#### 1. Install NVM

**macOS / Linux:**
```bash
curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.39.5/install.sh | bash

### Common NVM Commands
| Command | Description |
| :--- | :--- |
| `nvm install node` | Installs the latest Node.js version |
| `nvm install 20` | Installs Node.js version 20 |
| `nvm use 20` | Switches to Node.js version 20 |
| `nvm ls` | Lists installed Node.js versions |
| `nvm alias default 20` | Sets default Node.js version to 20 |

---

### Verify Installation
You can verify the installation of Node.js and npm by running these commands in your terminal:

```
node -v
npm -v

```

---

### Alternative Installation
- **Direct download:** From the [Node.js official website](https://nodejs.org/).
- **Package managers:**
  - `brew install node` (macOS)
  - `choco install nodejs` (Windows)

---

### Key Features of Node.js
- **Event-driven, non-blocking I/O** for high concurrency.
- **Single-threaded** but scalable with asynchronous callbacks.
- **Cross-platform:** Runs on Windows, Linux, and macOS.
- **Rich ecosystem** via npm (Node Package Manager).
- **Built-in modules** for networking, file system, streams, and more.
- Supports **ES Modules (ESM)** and modern JavaScript features.
- Integrates with **TypeScript** for typed backend applications.
- **Ideal for:** real-time applications, microservices, APIs, and serverless functions.