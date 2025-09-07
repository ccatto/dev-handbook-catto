# Next.js Overview - Catto Dev Handbook

**Next.js** is a React-based framework for building server-side rendered (SSR), static, and hybrid web applications. It is widely used for modern frontends with React or TypeScript and integrates easily with APIs and backend services like NestJS.

---

## 🔹 Overview

* Built on **React** and Node.js.
* Supports **SSR (Server-Side Rendering)**, **SSG (Static Site Generation)**, and **ISR (Incremental Static Regeneration)**.
* File-based **routing** system.
* Integrated with **API routes** for serverless functions.
* Optimized for **performance**, **SEO**, and **developer experience**.

---

## 🔹 Common Uses

* Building **modern web applications** with React.
* Frontends for **C# Web APIs, NestJS APIs, or GraphQL** backends.
* **E-commerce sites**, **dashboards**, and **content-heavy apps**.
* Static websites or hybrid static/dynamic sites.
* Serverless API endpoints using **API routes**.

---

## 🔹 Key Features / Patterns

* **File-based Routing** → Pages automatically mapped to URLs.
* **Server-Side Rendering (SSR)** → Fetch data and render on the server.
* **Static Site Generation (SSG)** → Pre-render pages at build time.
* **Incremental Static Regeneration (ISR)** → Update static pages after deployment.
* **API Routes** → Build backend endpoints within Next.js.
* **Middleware & Edge Functions** → Add authentication, logging, or custom logic.
* **Custom App & Document** → Global layout, styles, and HTML customization.

---

## 🔹 Folder Structure Example

```
/my-next-app
│  package.json
│  next.config.js
│
├─ pages
│   ├─ index.tsx
│   ├─ about.tsx
│   └─ api
│       └─ users.ts
│
├─ components
│   ├─ Header.tsx
│   └─ Footer.tsx
│
├─ lib
│   └─ apiClient.ts
│
├─ styles
│   └─ globals.css
│
├─ public
│   └─ images
```

* **pages/** → React pages and API routes.
* **components/** → Reusable UI components.
* **lib/** → API clients or helper functions.
* **styles/** → Global and component styles.
* **public/** → Static assets like images and fonts.

---

## 🔹 Simple Code Example

```tsx
// pages/index.tsx
import type { NextPage } from 'next';
import { useEffect, useState } from 'react';

const Home: NextPage = () => {
  const [message, setMessage] = useState('');

  useEffect(() => {
    fetch('/api/hello')
      .then(res => res.json())
      .then(data => setMessage(data.message));
  }, []);

  return (
    <div>
      <h1>Welcome to Next.js!</h1>
      <p>Message from API: {message}</p>
    </div>
  );
};

export default Home;

// pages/api/hello.ts
import type { NextApiRequest, NextApiResponse } from 'next';

export default function handler(req: NextApiRequest, res: NextApiResponse) {
  res.status(200).json({ message: 'Hello from Next.js API!' });
}
```

---

## 🔹 Code Flow Diagram

```
[ Client Browser ]
        |
        v
[ Next.js Page / Component ]
        |
        v
[ API Route (Optional) ]
        |
        v
[ Backend Service (NestJS / C# API) ]
        |
        v
[ Database / ORM ]
```

---

## 🔹 Why It's Popular

* **React-based** → Easy adoption for React developers.
* **SSR & SSG support** → Improves SEO and performance.
* **File-based routing** → Simplifies project structure.
* **API Routes** → Lightweight serverless endpoints.
* **Hybrid Rendering** → Mix SSR, SSG, and CSR (Client-Side Rendering) in the same app.
* **Great developer experience** → Fast refresh, TypeScript support, and integrated tooling.

---

## 🔹 Additional Helpful Sections

* **Middleware** → Authentication, logging, analytics.
* **Environment Variables** → Use `.env.local` for secrets.
* **Static Assets** → Store images, fonts, and icons in `public/`.
* **Custom \_app and \_document** → Global layout and HTML customization.

---

## 🔹 Summary

Next.js is a modern React framework for building performant, SEO-friendly, and scalable web applications. It seamlessly integrates with APIs like NestJS or C# Web API, supports multiple rendering strategies, and provides developer-friendly tooling for TypeScript and full-stack development.
