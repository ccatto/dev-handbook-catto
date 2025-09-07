# React Overview for Frontend - Catto Dev Handbook

**React** is a popular JavaScript library for building interactive and dynamic user interfaces. It allows developers to create reusable components, manage state efficiently, and build scalable web applications.

---

## 🔹 Overview

* Developed and maintained by **Facebook**.
* Uses a **component-based architecture**.
* Virtual DOM for efficient updates and rendering.
* Supports **hooks** for state and lifecycle management.
* Compatible with TypeScript for type safety.
* Integrates well with **REST APIs**, **GraphQL**, and backend frameworks like NestJS.

---

## 🔹 Common Uses

* Single Page Applications (SPAs) with dynamic content.
* Web applications requiring reusable components and interactive UIs.
* Dashboards, e-commerce platforms, and content-heavy websites.
* Integration with backend APIs for data-driven apps.
* Progressive Web Apps (PWAs).

---

## 🔹 Key Features / Patterns

* **Components** → Build encapsulated, reusable UI pieces.
* **Hooks** → Manage state (`useState`) and side effects (`useEffect`).
* **Context API** → Share state across components without prop drilling.
* **Higher-Order Components (HOCs)** → Reuse component logic.
* **Custom Hooks** → Encapsulate reusable logic.
* **State Management Libraries** → Redux, Zustand, Recoil.
* **JSX** → Write HTML-like syntax in JavaScript.

---

## 🔹 Folder Structure Example

```
/src
│
├─ components
│   ├─ Header.tsx
│   ├─ Footer.tsx
│   └─ UserCard.tsx
│
├─ pages
│   ├─ index.tsx
│   └─ users.tsx
│
├─ services
│   └─ apiClient.ts
│
├─ hooks
│   └─ useUsers.ts
│
├─ styles
│   └─ globals.css
```

* **components/** → Reusable UI components.
* **pages/** → Page-level components or routes.
* **services/** → API client or data fetching functions.
* **hooks/** → Custom hooks for reusable logic.
* **styles/** → CSS or styling files.

---

## 🔹 Simple Code Example

```tsx
// components/UserCard.tsx
import React from 'react';

interface UserCardProps {
  name: string;
  email: string;
}

export const UserCard: React.FC<UserCardProps> = ({ name, email }) => (
  <div>
    <h3>{name}</h3>
    <p>{email}</p>
  </div>
);

// hooks/useUsers.ts
import { useState, useEffect } from 'react';

export const useUsers = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch('/api/users')
      .then(res => res.json())
      .then(data => setUsers(data));
  }, []);

  return users;
};
```

---

## 🔹 Code Flow Diagram

```
[ Client Browser ]
        |
        v
[ React Component ]
        |
        v
[ Custom Hook / Service Layer ]
        |
        v
[ Backend API (NestJS / Node) ]
        |
        v
[ Database / ORM ]
```

---

## 🔹 Why It's Popular

* Component-based architecture encourages reusability.
* Virtual DOM improves performance.
* Strong ecosystem and community support.
* Integrates easily with TypeScript.
* Works well with REST APIs, GraphQL, and serverless functions.
* Large tooling ecosystem for testing, routing, and state management.

---

## 🔹 Additional Helpful Sections

* **State Management** → Redux, Zustand, or Recoil.
* **Routing** → React Router or Next.js pages.
* **Testing** → Jest and React Testing Library.
* **Styling** → CSS Modules, Tailwind CSS, Styled Components.

---

## 🔹 Summary

React is a flexible, efficient, and widely-adopted library for building interactive user interfaces. Its component-based architecture, strong community, and compatibility with modern backend APIs make it a top choice for building scalable web applications.
