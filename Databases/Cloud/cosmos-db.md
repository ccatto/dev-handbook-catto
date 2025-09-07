# Azure Services - Cosmos - Catto Dev Handbook
# Azure Cosmos DB

# Cosmos DB Overview for Cloud Databases

**Azure Cosmos DB** is Microsoft’s globally distributed, multi-model database service designed for high availability, low latency, and elastic scalability. It supports multiple APIs (SQL, MongoDB, Cassandra, Gremlin, Table) and allows developers to choose the model best suited for their application.

---

## 🔹 Overview

* **Globally distributed** → Replicate data across multiple Azure regions.
* **Multi-model support** → Key-value, document, graph, and column-family.
* **Multiple APIs** → SQL (Core), MongoDB API, Cassandra API, Gremlin API, Table API.
* **99.999% availability SLA** for multi-region writes.
* **Elastic scaling** → Provisioned throughput (RU/s) or serverless.

---

## 🔹 Common Use Cases

* **Document storage** (JSON documents) for flexible, schema-less applications.
* **IoT telemetry** → Ingest high-velocity data streams.
* **E-commerce catalogs** → Dynamic product information with global access.
* **Personalization and recommendations** → Store user activity and preferences.
* **Real-time analytics** → Combine OLTP + OLAP with Azure Synapse Link.
* **Gaming leaderboards** → Handle massive concurrent users with low latency.
* **Multi-tenant SaaS apps** → Isolate customer data with partitioning.

---

## 🔹 Key Concepts

* **Database** → Logical container for collections (called containers in Cosmos).
* **Container** → Stores items (JSON documents, key-value pairs, etc.), automatically partitioned.
* **Item** → A single JSON document (analogous to a row in SQL).
* **Partition Key** → Determines how data is distributed across physical partitions.
* **Request Units (RU/s)** → Throughput unit that governs performance and cost.
* **Consistency Levels** → Choose between Strong, Bounded Staleness, Session, Consistent Prefix, and Eventual consistency.
* **Multi-region writes** → Active-active replication for global apps.

---

## 🔹 Common Architectural Patterns

* **Document Store Pattern**
  * Ideal for JSON-based data (profiles, catalogs, metadata).
* **Event Sourcing**
  * Store immutable events for real-time processing.
* **Polyglot Persistence**
  * Use Cosmos DB alongside SQL Server or Azure Blob for hybrid storage.
* **Global Distribution**
  * Deploy apps that need ultra-low latency worldwide.

---

## 🔹 Best Practices for Folder Structure (C# Web API + Cosmos DB)

/src
│ Program.cs
│ appsettings.json # Cosmos DB connection
│
├─ Models
│ └─ User.cs # POCO for Cosmos items
│
├─ Repositories
│ └─ UserRepository.cs
│
├─ Services
│ └─ UserService.cs
│
└─ Controllers
└─ UserController.cs


* **Models** → Map Cosmos DB JSON items to C# classes.
* **Repositories** → Contain Cosmos SDK queries and operations.
* **Services** → Business logic layer.
* **Controllers** → Handle HTTP routes and responses.

---

## 🔹 Code Flow Diagram

[ Client (Angular / React / Mobile App) ]
|
v
[ Controller (Web API) ]
|
v
[ Service Layer ]
|
v
[ Repository (Cosmos SDK) ]
|
v
[ Azure Cosmos DB (Global, Partitioned, Replicated) ]


* Client sends HTTP request (REST/GraphQL).
* Controller forwards request to service.
* Service applies business rules.
* Repository executes Cosmos queries (CRUD).
* Cosmos DB returns data with chosen consistency.

---

## 🔹 Why It’s Popular

* **Global distribution** with single-digit millisecond latency.
* **Flexible data models** (document, key-value, graph, column).
* **Multiple APIs** → No vendor lock-in for MongoDB, Cassandra, or Gremlin workloads.
* **Elastic scaling** → Handle unpredictable workloads.
* **High availability** → Enterprise-grade SLAs.
* **Integration** → Works with Azure Synapse, Functions, Event Hubs, and Logic Apps.

---

## 🔹 Additional Helpful Sections

* **Security**
  * Role-based access control with Azure AD.
  * Network isolation with VNETs and firewalls.
* **Performance**
  * Choose partition keys wisely.
  * Monitor RU/s consumption.
* **Monitoring**
  * Use Azure Monitor and Application Insights.
* **Backup & Restore**
  * Automated backups with point-in-time restore.

---

## 🔹 Summary

Azure Cosmos DB is a powerful NoSQL database service designed for cloud-native, globally distributed applications. It is particularly strong for **document storage** (JSON), IoT, e-commerce, and real-time analytics scenarios. With multiple APIs, strong SLAs, and tight Azure integration, Cosmos DB is a top choice for modern enterprise applications.
