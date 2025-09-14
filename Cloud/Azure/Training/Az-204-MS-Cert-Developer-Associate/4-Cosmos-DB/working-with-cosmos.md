# Work with Azure Cosmos DB

**Module**  

Learn how to develop client and server-side programming solutions on Azure Cosmos DB.

## Units
- Introduction  
- Explore Microsoft .NET SDK v3 for Azure Cosmos DB  
- Exercise - Create resources in Azure Cosmos DB for NoSQL using .NET  
- Create stored procedures  
- Create triggers and user-defined functions  
- Explore change feed in Azure Cosmos DB  
- Module assessment  
- Summary  

## Introduction  
**Completed – 100 XP**

This module introduces both client and server-side programming on Azure Cosmos DB.  

### Learning objectives  
 
- Identify classes and methods used to create resources  
- Create resources in Azure Cosmos DB for NoSQL using .NET  
- Write stored procedures, triggers, and user-defined functions by using JavaScript  
- Implement change feed notifications

# Explore Microsoft .NET SDK v3 for Azure Cosmos DB  
**Completed – 100 XP**

This unit introduces the Azure Cosmos DB .NET SDK v3 (`Microsoft.Azure.Cosmos` NuGet package) for API for NoSQL. It standardizes terminology using **containers** (collections, graphs, or tables) and **items** (documents, edges/vertices, or rows). The SDK provides async APIs for efficient CRUD operations with Cosmos DB resources.

## Key Concepts
- **CosmosClient**:  
  - Entry point for interacting with Cosmos DB.  
  - Thread-safe; recommended to use a single instance per application lifetime.  

- **Databases**:  
  - `CreateDatabaseAsync` – Creates a database, throws if it exists.  
  - `CreateDatabaseIfNotExistsAsync` – Creates only if not present.  
  - `GetDatabase` & `ReadAsync` – Retrieve a database.  
  - `DeleteAsync` – Removes a database.  

- **Containers**:  
  - `CreateContainerIfNotExistsAsync` – Creates or retrieves a container.  
  - `GetContainer` & `ReadContainerAsync` – Retrieve container details.  
  - `DeleteContainerAsync` – Deletes a container.  

- **Items**:  
  - `CreateItemAsync` – Adds a new item (requires `id` and partition key).  
  - `ReadItemAsync` – Reads an item by ID and partition key.  
  - `GetItemQueryIterator` – Queries items using SQL-like syntax with parameters.  

## Additional Resources
- [azure-cosmos-dotnet-v3 GitHub repository](https://github.com/Azure/azure-cosmos-dotnet-v3) – Latest sample solutions and examples.  
- [Azure Cosmos DB .NET V3 SDK documentation](https://learn.microsoft.com/azure/cosmos-db/nosql/sdk-dotnet-v3) – Official examples and references.  
- [Microsoft .NET SDK v3 for Azure Cosmos DB](https://learn.microsoft.com/en-us/training/modules/work-with-cosmos-db/2-cosmos-db-dotnet-overview)

> Exercise - Create resources in Azure Cosmos DB for NoSQL using .NET  


In this exercise, you create an **Azure Cosmos DB account** and build a **.NET console application** that uses the Microsoft Azure Cosmos DB SDK to create a **database**, **container**, and **sample item**. You also configure authentication, perform database operations programmatically, and verify results in the **Azure portal**.

## Tasks
- Create an Azure Cosmos DB account  
- Build a console app to create a database, container, and item  
- Run the app and verify results in the Azure portal  

[Create resources in Azure Cosmos DB for NoSQL using .NET](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-cosmos-db/01-comosdb-create-resources-sdk.html)


> Stored Procedures

#### Create Stored Procedures  

Azure Cosmos DB supports **language-integrated, transactional JavaScript execution** for stored procedures, triggers, and user-defined functions (UDFs).  
This unit focuses on **stored procedures**.

## Key Points
- Stored procedures run inside a Cosmos DB **container** and can perform **CRUD operations** (create, read, update, query, delete).  
- They are **registered per collection** and executed in the database engine.  
- Execution is **bounded** (must complete within a limited time).  

## Examples
- **Hello World stored procedure**: returns a static `"Hello, World"` response.  

```javascript
var helloWorldStoredProc = {
    id: "helloWorld",
    serverScript: function () {
        var context = getContext();
        var response = context.getResponse();

        response.setBody("Hello, World");
    }
}
```

- **Create item stored procedure**: inserts a new document, returns its ID, and uses callback functions for error handling.  
- **Arrays as input**: input parameters are always strings, so arrays must be parsed using `JSON.parse`.  

## Transactions
- Stored procedures allow **transactional execution** across multiple operations in a container.  
- Use **continuation-based models** to handle long-running or batched operations.  

## Resources
- [How to work with stored procedures, triggers, and UDFs in Azure Cosmos DB](https://learn.microsoft.com/azure/cosmos-db/)  

---

> Create Triggers and User-Defined Functions  

Azure Cosmos DB supports **triggers** and **user-defined functions (UDFs)** to extend database operations.

## Triggers
- **Pre-triggers**: run **before** modifying an item (e.g., validate properties, add a timestamp).  
- **Post-triggers**: run **after** modifying an item (e.g., update metadata).  
- Must be explicitly registered and tied to specific operations.  
- Run **transactionally**: if a trigger fails, the whole operation is rolled back.  

## User-Defined Functions (UDFs)
- Written in **JavaScript**, used in **queries**.  
- Example: `tax(income)` UDF calculates income tax across brackets.  

## Key Point
Triggers and UDFs allow **custom logic execution** inside Azure Cosmos DB, enabling validation, metadata updates, and custom query computations.

---

> Explore Change Feed in Azure Cosmos DB  

## Key Concepts
- The **change feed** is a persistent log of inserts and updates in a container, emitted in the order they occur.  
- Deletes aren’t tracked directly, but can be simulated with a **soft delete marker** (e.g., `"deleted": true` + TTL).  
- Changes can be processed **incrementally** and distributed across multiple consumers for parallel processing.  

## Reading Change Feed
- **Push model (recommended):** Uses **Azure Functions** or the **Change Feed Processor library**. Handles state, scaling, and parallelism automatically.  
- **Pull model:** Client manually fetches changes, manages state, and controls partition scope or processing pace. Useful for advanced scenarios like data migration or throttled reads.  

## Change Feed Processor Components
1. **Monitored container** – source of changes.  
2. **Lease container** – stores state and coordinates workers.  
3. **Compute instance** – host for the processor (e.g., VM, App Service).  
4. **Delegate** – your business logic to handle each batch of changes.  

## Lifecycle
1. Read change feed.  
2. If no changes, wait (poll interval).  
3. If changes exist, pass them to delegate for processing.  
4. Update lease state and repeat.  

➡️ Use the **push model with Azure Functions** or the **.NET/Java SDK Change Feed Processor** for most scenarios.  

---

> ✅ Check Your Knowledge

### 1. What is the purpose of the context object in a stored procedure in Azure Cosmos DB?
- It provides access to the database schema and metadata.  
- It allows for the creation of new collections within the database.  
- ✅ It provides access to all operations that can be performed in Azure Cosmos DB, and access to the request and response objects.  

---

### 2. What is the role of pretriggers in Azure Cosmos DB?
- Pretriggers are automatically executed for each database operation.  
- ✅ Pretriggers are executed before modifying a database item and must be specified for each database operation where you want them to execute.  
- Pretriggers are used to execute operations after modifying a database item.  

---

### 3. What is the purpose of the lease container in the Azure Cosmos DB change feed processor?
- It stores the data from which the change feed is generated.  
- It processes the change feed across multiple workers.  
- ✅ It acts as a state storage and coordinates processing the change feed across multiple workers.  

--- 

