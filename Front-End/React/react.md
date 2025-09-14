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

---

> ⚛️ React Component Re-Render Triggers

A React component **re-renders** when:
- **Props change** — parent passes new props.
- **State changes** — component's `useState` or `useReducer` state updates.
- **Context changes** — when a `useContext` value changes.
- **Parent re-renders** — causing children to re-render (unless memoized).
- **Force update** — manually triggered with something like `useState` hack or `forceUpdate`.

> **Optimization Tip:** Use `React.memo`, `useMemo`, and `useCallback` to avoid unnecessary re-renders.

---

## 🛡️ Middleware in React

Middleware isn’t built into React itself, but it’s common in:
- **State management libraries** like Redux (e.g., `redux-thunk`, `redux-saga`).
- **Routing** with Next.js or React Router (custom middleware-like logic).

### Typical Use Cases
- **Authentication & Authorization** – check if the user is allowed to see a route.
- **Logging / Analytics** – capture events before they reach the reducer.
- **API Calls** – intercept actions and fetch data.

✅ **Yes, you can have multiple middlewares.** They are chained and executed in order.

---


---

## 🔹 Summary

React is a flexible, efficient, and widely-adopted library for building interactive user interfaces. Its component-based architecture, strong community, and compatibility with modern backend APIs make it a top choice for building scalable web applications.

----

---

> React Re-Renders, Hooks, and Hook Cleanup Functions

Understanding re-renders and hooks is key to building performant and
maintainable React applications.

## 1. What is a Hook?

A **hook** is a special function that lets you "hook into" React
features such as state, lifecycle, and context from functional
components.\
Hooks were introduced in React 16.8 and replaced the need for many
class-based lifecycle methods.

### Rules of Hooks

-   **Call hooks only at the top level** (never inside loops,
    conditions, or nested functions).
-   **Call hooks only from React functions** (components or custom
    hooks).

------------------------------------------------------------------------

## 2. Common React Hooks

Here are some of the most commonly used hooks:

  -----------------------------------------------------------------------
  Hook                         Purpose
  ---------------------------- ------------------------------------------
  `useState`                   Manage local component state

  `useEffect`                  Perform side effects (fetching data,
                               subscriptions, timers)

  `useContext`                 Consume a React context value

  `useMemo`                    Memoize expensive computations

  `useCallback`                Memoize callback functions to avoid
                               re-creation

  `useReducer`                 Manage complex state logic (like Redux but
                               local)

  `useRef`                     Persist values across renders without
                               causing re-renders
  -----------------------------------------------------------------------

Example using `useState`:

``` jsx
import { useState } from 'react';

function Counter() {
  const [count, setCount] = useState(0);
  return (
    <button onClick={() => setCount(count + 1)}>
      Count: {count}
    </button>
  );
}
```

------------------------------------------------------------------------

## 3. Creating a Custom Hook

You can create your own hooks to encapsulate reusable logic.

Example: A custom hook for window size:

``` jsx
import { useState, useEffect } from 'react';

function useWindowSize() {
  const [size, setSize] = useState({ width: window.innerWidth, height: window.innerHeight });

  useEffect(() => {
    function handleResize() {
      setSize({ width: window.innerWidth, height: window.innerHeight });
    }

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  return size;
}

// Usage in a component
function Component() {
  const { width, height } = useWindowSize();
  return <p>Window size: {width} x {height}</p>;
}
```

------------------------------------------------------------------------

## 4. React Re-Renders

A React component re-renders when: - **State changes**: Calling
`setState` or `useState` setter updates the component. - **Props
change**: New props cause React to re-render the component with updated
data. - **Context value changes**: When a `useContext` value changes,
all consuming components re-render. - **Parent re-renders**: If a parent
re-renders, its children re-render (unless memoized).

### Avoiding Unnecessary Re-Renders

-   Use `React.memo` for pure components.
-   Use `useCallback` and `useMemo` to prevent re-creating functions and
    objects on every render.
-   Split large components into smaller ones to minimize re-render
    scope.

------------------------------------------------------------------------

## 5. Hook Cleanup Functions

Many React hooks allow you to return a **cleanup function** to handle
side effects when: - A component unmounts. - A dependency changes (for
hooks with a dependency array).

Example with `useEffect`:

``` jsx
import { useEffect } from 'react';

function Example() {
  useEffect(() => {
    const intervalId = setInterval(() => {
      console.log("Tick...");
    }, 1000);

    // Cleanup function
    return () => {
      clearInterval(intervalId);
      console.log("Interval cleared");
    };
  }, []); // Empty dependency array -> runs once on mount, cleanup on unmount

  return <div>Check the console</div>;
}
```

### Why Cleanup Functions Are Important

-   Prevent **memory leaks** (e.g., orphaned timers, event listeners).
-   Keep behavior predictable across component re-renders.
-   Free up resources when components unmount.

------------------------------------------------------------------------

## 6. Best Practices

1.  **Always clean up side effects**
    -   Event listeners, timers, subscriptions, sockets should be
        cleaned up to avoid bugs.
2.  **Use dependency arrays carefully**
    -   Missing dependencies can lead to stale data.
    -   Over-specifying dependencies can cause excessive re-renders.
3.  **Optimize performance**
    -   Combine cleanup with memoization to avoid unnecessary effect
        re-runs.

------------------------------------------------------------------------

## 7. Common Pitfalls

-   Forgetting to add dependencies to `useEffect` → stale values.
-   Forgetting to clean up → memory leaks.
-   Triggering infinite re-renders by updating state inside `useEffect`
    without proper dependencies.

------------------------------------------------------------------------

## Summary

-   Hooks allow functional components to use state, lifecycle, and other
    React features.
-   React re-renders occur on **state, prop, context, or parent
    updates**.
-   **Hook cleanup functions** help manage side effects safely.
-   Properly managing re-renders and cleanup leads to **faster and more
    stable React apps**.
