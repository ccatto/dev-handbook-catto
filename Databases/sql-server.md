# SQL Server - Catto Developer Handbook

**Microsoft SQL Server** is a **relational database management system (RDBMS)** that has been around since the late 1980s. It’s widely used in enterprise environments and is known for stability, scalability, and deep integration with the Microsoft ecosystem (.NET, Azure, Power BI, etc.).

SQL Server uses **T-SQL (Transact-SQL)**, which is Microsoft’s proprietary extension of SQL, adding procedural programming, error handling, and advanced functions.

---

## Key Concepts

- **Database** – Container for tables, views, stored procedures, and functions.  
- **Table** – Holds rows of structured data.  
- **Row / Column** – A row is a record; a column defines a data field.  
- **Primary Key** – Unique identifier for each row in a table.  
- **Foreign Key** – Links tables together for relational integrity.  
- **Stored Procedure** – Precompiled T-SQL logic that can be executed from your app.  
- **Views** – Virtual tables representing the result of a query.  
- **Indexes** – Improve query performance by organizing data efficiently.  

---

## Why Use SQL Server?

- Enterprise-grade reliability and security.  
- Strong tooling: SQL Server Management Studio (SSMS), Azure Data Studio.  
- Deep integration with **C# / .NET** for backend apps.  
- Supports advanced analytics, reporting, and business intelligence.  
- Flexible deployment: on-premises, Azure SQL Database (PaaS), or SQL Server in containers.  

---

## Quick Start Example

### 1. Create a Database and Table (T-SQL)
```sql
CREATE DATABASE MyAppDB;

USE MyAppDB;

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    CreatedAt DATETIME DEFAULT GETDATE()
);

#### Insert Data

```sql
INSERT INTO Users (Name, Email)
VALUES ('Chris Catto', 'chris@example.com');

```

#### Query Data

```sql
SELECT Id, Name, Email, CreatedAt
FROM Users
WHERE Email = 'chris@example.com';


```


#### C# Example (using System.Data.SqlClient)

```sql
using var connection = new SqlConnection("Server=.;Database=MyAppDB;Trusted_Connection=True;");
connection.Open();

var command = new SqlCommand("SELECT * FROM Users WHERE Email = @email", connection);
command.Parameters.AddWithValue("@email", "chris@example.com");

using var reader = command.ExecuteReader();
while(reader.Read())
{
    Console.WriteLine(reader["Name"]);
}


```

### Tips & Best Practices

* Use stored procedures for reusable, performant backend logic.
* Index columns that are frequently queried to improve performance.
* Avoid SELECT * in production queries; specify columns explicitly.
* Use parameterized queries in C# to prevent SQL injection.
* Consider Azure SQL Database for PaaS benefits like automatic backups, scaling, and high availability.
* Learn T-SQL features like CTEs, window functions, and TRY/CATCH error handling.