# DB General Topics

## 1. What is a Normalized Database?

A **normalized database** is structured to reduce data redundancy and improve data integrity by organizing data into **related tables**.

### Example: Users and Orders

**Users Table**

| UserID (PK) | Name  | Email                                   |
| ----------- | ----- | --------------------------------------- |
| 1           | Alice | [alice@mail.com](mailto:alice@mail.com) |
| 2           | Bob   | [bob@mail.com](mailto:bob@mail.com)     |

**Orders Table**

| OrderID (PK) | UserID (FK) | Product  | Quantity |
| ------------ | ----------- | -------- | -------- |
| 101          | 1           | Keyboard | 2        |
| 102          | 2           | Mouse    | 1        |

**Explanation:**

* **PK (Primary Key):** Unique identifier for each record in a table (`UserID`, `OrderID`).
* **FK (Foreign Key):** Links one table to another (`UserID` in Orders references Users).

---

## 2. Index

**Index:** A database object that improves query performance by allowing faster data retrieval.

**Example:**

```sql
CREATE INDEX idx_user_email ON Users(Email);
```

* This creates an index on the `Email` column to speed up searches.

**When to use:**

* Frequently searched columns
* Columns used in `JOIN`, `WHERE`, `ORDER BY`

**Avoid over-indexing:**

* Each index consumes storage and can slow `INSERT/UPDATE/DELETE` operations.

---

## 3. Query Optimization

**Problem:** Full table scan is slow for large tables.

**Solution:**

1. **Create Index:**

   ```sql
   CREATE INDEX idx_order_userid ON Orders(UserID);
   ```

   * Speeds up queries like:

     ```sql
     SELECT * FROM Orders WHERE UserID = 1;
     ```

2. **Use EXPLAIN:**

   ```sql
   EXPLAIN SELECT * FROM Orders WHERE UserID = 1;
   ```

   * Shows if the query uses an index or a full table scan.

3. **Optimize joins:** Ensure foreign keys are indexed.

4. \**Avoid SELECT *:** Only select needed columns.

---

> Database Comparison: Relational vs Non-Relational

## 1. Relational Databases (RDBs)

### Characteristics
- Structured data stored in tables (rows & columns)
- Schema is fixed (must define tables & columns upfront)
- Supports ACID transactions (Atomicity, Consistency, Isolation, Durability)
- Query language: SQL

### Common RDB Examples
| DB            | SQL Dialect / Notes | Cloud Equivalents                              |
|---------------|---------------------|-----------------------------------------------|
| SQL Server    | T-SQL              | Azure SQL Database, AWS RDS for SQL Server    |
| PostgreSQL    | PL/pgSQL           | AWS RDS for PostgreSQL, Azure Database for PostgreSQL |
| Oracle DB     | PL/SQL             | Oracle Cloud, AWS RDS for Oracle              |
| MySQL / MariaDB | Standard SQL      | AWS RDS for MySQL/MariaDB, Azure Database for MySQL |

### Pros
- Strong consistency & transactional integrity
- Mature tooling & ecosystem
- Great for structured data with complex relationships

### Cons
- Less flexible schema changes
- Scaling horizontally (across servers) can be harder than NoSQL

## 2. Non-Relational Databases (NoSQL)

### Characteristics
- Flexible, schema-less or semi-structured data
- Multiple types: Document, Key-Value, Column, Graph
- Usually eventually consistent (some offer strong consistency)
- Querying often uses APIs, not traditional SQL

### Document-Oriented NoSQL (JSON-like storage)
| DB                | Cloud / Notes                              |
|-------------------|--------------------------------------------|
| MongoDB           | Popular document store; MongoDB Atlas is cloud-managed |
| Cosmos DB         | Azure multi-model DB (supports SQL API, Mongo API, Cassandra API, etc.) |
| DynamoDB          | AWS fully-managed key-value / document DB   |
| Couchbase / Firestore | Other managed options                  |

### Pros
- Schema flexibility → great for rapidly changing or nested data
- Easy horizontal scaling (sharding)
- Good for JSON, hierarchical, or large-scale datasets

### Cons
- Some lack strong ACID across multiple documents
- Querying may be less intuitive than SQL for relational operations

## 3. Cloud Comparison
| Cloud       | Relational Options                              | NoSQL Options                              |
|-------------|-----------------------------------------------|--------------------------------------------|
| AWS         | RDS (SQL Server, PostgreSQL, MySQL, Oracle), Aurora | DynamoDB, DocumentDB (MongoDB-compatible), Neptune (graph)


### Quick Summary

* **Normalized DB:** Reduces redundancy, improves integrity.
* **PK:** Primary Key, unique ID per table.
* **FK:** Foreign Key, links tables.
* **Index:** Speeds up queries.
* **Query Optimization:** Use indexes, avoid full scans, select only needed columns.
* **Database Comparison: Relational vs Non-Relational** comparing the 2;
