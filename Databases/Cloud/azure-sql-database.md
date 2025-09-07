# Azure SQL Database - Catto Developer Handbook

**Azure SQL Database** is a **fully managed relational database service** provided by Microsoft Azure. It is based on **SQL Server engine**, but offers **cloud-native capabilities**, such as scaling, high availability, automated backups, and security.

---

## Overview

- **Platform-as-a-Service (PaaS)**: No need to manage infrastructure, patching, or backups manually.  
- **Compatible with SQL Server**: Supports T-SQL, stored procedures, triggers, and SQL Server tools.  
- **Scalable**: Dynamic scaling of compute and storage resources.  
- **Secure**: Built-in encryption, firewall rules, and advanced threat protection.  
- **High Availability**: Automatic replication and failover options.  
- **Integration**: Works seamlessly with .NET, Node.js, Python, Java, and Azure services.  

---

## Key Features

- **Single Database / Elastic Pool**:  
  - Single database: Dedicated resources for one application.  
  - Elastic pool: Share resources across multiple databases to optimize cost.  

- **Compute Models**:  
  - **vCore-based**: Control number of cores, memory, and storage.  
  - **DTU-based**: Database Transaction Units combine CPU, memory, and I/O.  

- **High Availability & Disaster Recovery**:  
  - **Zone-redundant** for high availability.  
  - **Geo-replication** for disaster recovery across regions.  

- **Security**:  
  - **Transparent Data Encryption (TDE)**.  
  - **Always Encrypted** for sensitive data.  
  - **Auditing and Threat Detection**.  

- **Monitoring & Performance**:  
  - **Query Performance Insight**.  
  - **Automatic tuning** for indexes and queries.  
  - Integration with **Azure Monitor** and **Log Analytics**.

---

## Common Use Cases

- **Web APIs / Backend services** with .NET or Node.js.  
- **Enterprise applications** needing managed SQL database with minimal maintenance.  
- **Multi-tenant SaaS applications** using elastic pools.  
- **Data integration** with Power BI, Azure Data Factory, and other Azure services.

---

## Example: Connecting from .NET (C#)

```csharp
using System.Data.SqlClient;

string connectionString = "Server=tcp:your-server.database.windows.net,1433;" +
                          "Initial Catalog=YourDatabase;" +
                          "Persist Security Info=False;" +
                          "User ID=your-user;Password=your-password;" +
                          "MultipleActiveResultSets=False;" +
                          "Encrypt=True;TrustServerCertificate=False;" +
                          "Connection Timeout=30;";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine("Connected to Azure SQL Database!");
}
```

### Example: Connecting from Node.js
```javascript
const sql = require('mssql');

const config = {
    user: 'your-user',
    password: 'your-password',
    server: 'your-server.database.windows.net',
    database: 'YourDatabase',
    options: {
        encrypt: true
    }
};

sql.connect(config)
   .then(() => console.log('Connected to Azure SQL Database!'))
   .catch(err => console.error('Connection error:', err));

```