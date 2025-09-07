# Node.js Package Managers - Catto Developer Handbook

Package managers are tools that **automate the installation, version management, and dependency resolution** of libraries and tools in JavaScript/TypeScript projects.

---

## Overview of Popular Package Managers

### 1. npm (Node Package Manager)
- **Default package manager** for Node.js.  
- Provides a **registry of open-source packages** for JavaScript.  
- Supports **semantic versioning (semver)** and **package.json** for dependency management.  
- Built-in commands for **installing, updating, and publishing packages**.  

**Basic Commands:**
```bash
# Initialize a new project
npm init -y

# Install dependencies
npm install express

# Install a dev dependency
npm install --save-dev jest

# Run scripts
npm run build

# Update packages
npm update
```

### 2. Yarn

* Developed by Facebook to solve speed and determinism issues in npm.
* Uses yarn.lock for exact dependency versions.
* Supports workspaces for monorepos.

```bash
# Initialize a new project
yarn init -y

# Add dependencies
yarn add react

# Add dev dependencies
yarn add --dev typescript

# Run scripts
yarn build

# Upgrade packages
yarn upgrade

```

### 3. pnpm

* Modern package manager with disk-efficient, fast installs.
* Uses symlinks to share packages between projects, reducing duplication.
* Supports workspaces and monorepo setups.

```bash
# Initialize a new project
pnpm init

# Install dependencies
pnpm add express

# Install dev dependencies
pnpm add -D jest

# Run scripts
pnpm run build

# Update packages
pnpm update
```

## Key Differences

| Feature            | npm                  | Yarn                | pnpm                |
|--------------------|----------------------|---------------------|---------------------|
| **Lockfile**       | package-lock.json    | yarn.lock           | pnpm-lock.yaml      |
| **Monorepo Support** | Limited            | Workspaces          | Workspaces          |
| **Speed**          | Medium               | Fast                | Very Fast           |
| **Disk Efficiency** | Moderate            | Moderate            | High                |
| **Community**      | Very Large           | Large               | Growing             |


# Package Manager Summary

- **npm**: Default, widely adopted, great for most projects.
- **Yarn**: Fast, deterministic, monorepo-friendly.
- **pnpm**: Efficient, fast, ideal for large codebases and disk-space optimization.

All three are essential tools in modern frontend and Node.js development, and understanding them is critical for managing dependencies, scripts, and project workflows.