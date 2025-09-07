# Docker Overview for Containerized Applications

**Docker** is a platform for building, shipping, and running applications in containers. Containers package an application and its dependencies, ensuring consistent behavior across environments.

---

## 🔹 Overview

* Containers are lightweight, portable, and isolated.
* Docker uses **images** as templates for containers.
* Enables **microservices architecture** by isolating services.
* Works on **Windows, macOS, and Linux**.
* Integrates with **CI/CD pipelines**, Kubernetes, and cloud platforms.

---

## 🔹 Common Uses

* Package and distribute applications with all dependencies.
* Run multiple services on the same host without conflicts.
* Deploy microservices and APIs in a consistent environment.
* Integrate with CI/CD pipelines for automated builds and deployments.
* Simplify local development by mimicking production environments.

---

## 🔹 Key Concepts

* **Image** → A read-only template with application and dependencies.
* **Container** → A runnable instance of an image.
* **Dockerfile** → Script to build a Docker image.
* **Volumes** → Persistent storage for containers.
* **Networks** → Connect multiple containers.
* **Docker Compose** → Define multi-container applications.

---

## 🔹 Folder / Project Structure Example

```
/my-app
│  Dockerfile
│  docker-compose.yml
│  package.json
│
├─ src
│   ├─ index.ts
│   └─ app.ts
├─ tests
│   └─ app.test.ts
```

* **Dockerfile** → Instructions to build the image.
* **docker-compose.yml** → Orchestrate multiple containers.
* **src/** → Application source code.
* **tests/** → Unit and integration tests.

---

## 🔹 Simple Dockerfile Example

```dockerfile
# Use official Node.js image
FROM node:20-alpine

# Set working directory
WORKDIR /app

# Copy package files and install dependencies
COPY package.json package-lock.json ./
RUN npm install

# Copy application source code
COPY ./src ./src

# Build and run application
CMD ["node", "src/index.js"]
```

---

## 🔹 Docker Compose Example

```yaml
version: '3.9'
services:
  app:
    build: .
    ports:
      - "3000:3000"
    volumes:
      - ./src:/app/src
    environment:
      - NODE_ENV=development

  db:
    image: postgres:16
    environment:
      POSTGRES_USER: user
      POSTGRES_PASSWORD: password
      POSTGRES_DB: mydb
    ports:
      - "5432:5432"
```

---

## 🔹 Code Flow Diagram

```
[ Source Code ]
        |
        v
[ Dockerfile Build ]
        |
        v
[ Docker Image ]
        |
        v
[ Container Runtime ]
        |
        v
[ Application Execution ]
```

---

## 🔹 Why It's Popular

* Ensures **consistency across environments**.
* Lightweight compared to virtual machines.
* **Fast deployment** and scalability.
* Simplifies **microservices architecture**.
* Integrates seamlessly with **CI/CD pipelines**.
* Supports **multi-platform builds** and cross-environment testing.

---

## 🔹 Additional Best Practices

* Use **multi-stage builds** to reduce image size.
* Minimize layers and unnecessary files in images.
* Use **.dockerignore** to exclude unnecessary files.
* Tag images for **versioning and rollback**.
* Scan images for **security vulnerabilities**.
* Use **environment variables** instead of hardcoding secrets.

---

## 🔹 Summary

Docker enables developers to package and run applications consistently across environments. It simplifies development, deployment, and scaling, making it an essential tool for modern software development, microservices, and CI/CD workflows.
