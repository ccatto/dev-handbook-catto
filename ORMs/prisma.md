# Prisma ORM Overview | Catto Dev Handbook

**Prisma** is a modern, open-source ORM for Node.js and TypeScript. It simplifies database access by generating a type-safe client, making it ideal for backend frameworks like **NestJS** or **Node.js APIs** that serve Angular frontends.

---

## 🔹 Overview

* Supports **TypeScript and JavaScript**.
* Works with multiple databases: PostgreSQL, MySQL, SQL Server, SQLite, MongoDB (preview).
* Provides a **type-safe client** that autocompletes fields and queries.
* Integrates with **NestJS**, **Express**, or any Node.js backend.
* Supports **migrations** via Prisma Migrate.

---

## 🔹 Common Uses

* Backend database access for **REST** or **GraphQL APIs**.
* CRUD operations with type safety.
* Complex queries with relationships and transactions.
* Rapid development with auto-generated **Prisma Client**.
* Migration management and database schema evolution.

---

## 🔹 Architectural Patterns / Best Practices

* **Repository Pattern** → Wrap Prisma Client calls in service/repository classes.
* **Dependency Injection (DI)** → Inject Prisma Client into NestJS services.
* **Transactions** → Use `$transaction` for atomic operations.
* **DTOs & Input Validation** → Map Prisma results to API DTOs.
* **Environment Variables** → Store database connection string in `.env`.

---

## 🔹 Folder Structure Example (NestJS)

```
/src
│  main.ts
│  app.module.ts
│
├─ prisma
│   ├─ prisma.module.ts
│   └─ prisma.service.ts
│
├─ modules
│   ├─ users
│   │   ├─ users.module.ts
│   │   ├─ users.service.ts
│   │   ├─ users.controller.ts
│   │   └─ dto
│   │       └─ create-user.dto.ts
```

* **prisma/** → Prisma client and service for DB access.
* **modules/** → Feature modules with controllers and services.
* **DTOs** → Validation and data transfer objects.

---

## 🔹 Simple Code Example

```ts
// prisma/prisma.service.ts
import { Injectable, OnModuleInit, OnModuleDestroy } from '@nestjs/common';
import { PrismaClient } from '@prisma/client';

@Injectable()
export class PrismaService extends PrismaClient implements OnModuleInit, OnModuleDestroy {
  async onModuleInit() {
    await this.$connect();
  }

  async onModuleDestroy() {
    await this.$disconnect();
  }
}

// modules/users/users.service.ts
import { Injectable } from '@nestjs/common';
import { PrismaService } from '../../prisma/prisma.service';
import { User } from '@prisma/client';

@Injectable()
export class UsersService {
  constructor(private prisma: PrismaService) {}

  async getAllUsers(): Promise<User[]> {
    return this.prisma.user.findMany();
  }

  async createUser(data: { name: string; email: string }): Promise<User> {
    return this.prisma.user.create({ data });
  }
}
```

---

## 🔹 Code Flow Diagram

```
[ Client (Angular) ]
        |
        v
[ Controller ]
        |
        v
[ Service Layer ]
        |
        v
[ Prisma Client / Database Access ]
        |
        v
[ Database (PostgreSQL / MySQL / SQL Server) ]
```

---

## 🔹 Why It's Popular

* **Type-safe queries** → Reduces runtime errors.
* **Auto-generated client** → Fast development and autocomplete.
* **Cross-database support** → Works with multiple relational databases.
* **Migrations built-in** → Prisma Migrate simplifies schema changes.
* **Easy integration** → Works well with NestJS, Express, or standalone Node.js apps.

---

## 🔹 Additional Helpful Sections

* **Transactions & Batch Operations** → Use `$transaction` for atomicity.
* **Seeding** → Use Prisma scripts to populate initial data.
* **Logging & Monitoring** → Prisma logs queries and errors.
* **Environment Management** → `.env` for database URLs and secrets.

---

## 🔹 Summary

Prisma is a modern ORM for Node.js backends, providing type-safe, high-performance database access. It integrates well with NestJS, simplifies migrations, and ensures developer productivity. Its popularity stems from type safety, auto-completion, multi-database support, and strong ecosystem.
