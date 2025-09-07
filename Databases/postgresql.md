# Postgresql | Catto Dev Handbook

**PostgreSQL** is a powerful, open-source relational database system known for reliability, feature richness, and standards compliance. It is widely used with C# Web APIs and Angular front ends.

---

## 🔹 Overview

* Open-source object-relational database system.
* ACID-compliant and transactional. (guarantees the reliability and integrity of our data)
* Supports advanced data types (JSON, arrays, XML, hstore).
* Extensible: functions, stored procedures, triggers, custom data types.
* Highly compatible with **ORMs** like Entity Framework Core, TypeORM, Sequelize, and Prisma.

---

## 🔹 Common Uses

* Backend databases for **web applications** (REST/GraphQL APIs).
* Enterprise-grade applications needing **data integrity** and **complex queries**.
* Analytics and reporting.
* Geo-spatial applications via PostGIS extension.
* JSON/Document storage for hybrid relational-document use cases.

---

## 🔹 Architectural Patterns / Best Practices

* **Schemas** → Organize tables and objects logically.
* **Normalization** → Reduces redundancy; improve data integrity.
* **Indexes** → Improve query performance; use B-tree, GIN, GiST indexes.
* **Transactions** → Group multiple operations atomically.
* **Views & Materialized Views** → Simplify complex queries and improve performance.
* **Stored Procedures / Functions** → Encapsulate business logic in DB layer.
* **Connection Pooling** → Use pooled connections for scalable API usage.
* **ORM Integration** → Use EF Core, Dapper, Prisma, or TypeORM for C# or Node.js backends.

---

## 🔹 Common Folder / Connection Structure in C# Web API

```
/MyWebApi
│
├─ Data
│   └─ AppDbContext.cs         # Entity Framework Core DbContext
│
├─ Repositories
│   └─ UserRepository.cs
│
├─ Services
│   └─ UserService.cs
│
├─ Controllers
│   └─ UserController.cs
```

* **DbContext** → Manages PostgreSQL connection.
* **Repositories** → CRUD operations.
* **Services** → Business logic.
* **Controllers** → HTTP request handling.

---

### Code Flow

* Client sends HTTP request.
* Controller forwards to Service layer.
* Service handles business logic.
* Repository/DbContext interacts with PostgreSQL.
* Data returns through the same path to the client.

---

## 🔹 Why It's Popular

* **Open Source & Free** → No licensing costs.
* **Standards Compliant** → SQL compliance and ACID transactions.
* **Extensible** → Functions, triggers, JSON support.
* **Scalable & Reliable** → MVCC architecture for concurrent transactions.
* **Ecosystem** → Large community, libraries, and cloud support.
* **Integration** → Works well with .NET, Node.js, Python, and more.

---

## 🔹 Additional Helpful Sections

* **Replication & High Availability** → Streaming replication, failover.
* **Backup & Restore** → pg\_dump, WAL archiving.
* **Monitoring & Performance** → pg\_stat\_activity, EXPLAIN ANALYZE.
* **Security** → Roles, schemas, row-level security.
* **Extensions** → PostGIS, UUID-OSSP, Full-Text Search.

---

## 🔹 Summary

PostgreSQL is a robust, feature-rich relational database suitable for modern web applications. It integrates well with C# Web APIs and Angular front ends, supports complex queries and transactions, and is highly extensible. Its popularity stems from performance, reliability, open-source nature, and strong ecosystem support.
