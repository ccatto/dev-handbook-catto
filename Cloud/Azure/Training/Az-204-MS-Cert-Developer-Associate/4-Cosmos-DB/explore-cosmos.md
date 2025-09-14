# 4 Cosmos DB

# Develop solutions that use Azure Cosmos DB

## 🌍 Introduction to Azure Cosmos DB  

Azure Cosmos DB is a globally distributed database system that allows you to read and write data from local replicas of your database, while transparently replicating the data to all regions associated with your Cosmos account.  

### 🎯 Learning Objectives  
After completing this module, you'll be able to:  
- Identify the key benefits provided by Azure Cosmos DB  
- Describe the elements in an Azure Cosmos DB account and how they're organized  
- Explain the different consistency levels and choose the correct one for your project  
- Explore the APIs supported in Azure Cosmos DB and choose the appropriate API for your solution  
- Describe how request units impact costs  
- Create Azure Cosmos DB resources by using the Azure portal  

> Azure Cosmos DB accounts are the top-level resource, providing global distribution, high availability, and scalability, and each account can host multiple databases. Within an account, databases act as namespaces that organize containers. Containers are the fundamental unit of scalability, using partition keys to distribute data across logical and physical partitions for virtually unlimited storage and throughput. Items represent the individual data entities, and their structure varies depending on the API used, such as documents in MongoDB or rows in Cassandra.

> Azure Cosmos DB provides five consistency levels—Strong, Bounded Staleness, Session, Consistent Prefix, and Eventual—allowing developers to balance performance and availability needs. These levels form a spectrum, from Strong (most consistent) to Eventual (most available), offering flexibility for different workloads. Consistency guarantees are region-agnostic and apply across all reads and writes, regardless of the number of regions or write configurations.

> Azure Cosmos DB provides five consistency models—Strong, Bounded Staleness, Session, Consistent Prefix, and Eventual—each with distinct performance and availability tradeoffs supported by SLAs. The default consistency level is set at the account level and applies to all databases and containers, though it can be changed at any time. Strong guarantees the most recent committed write, while Bounded Staleness ensures data lags only by a configurable number of versions or time. Session, Consistent Prefix, and Eventual provide progressively weaker guarantees, making them suitable for scenarios where high performance and global distribution are more important than strict consistency.

> Azure Cosmos DB supports multiple APIs—NoSQL, MongoDB, PostgreSQL, Cassandra, Gremlin, and Table—allowing developers to work with familiar data models such as documents, key-value, graphs, and column-family. The API for NoSQL is native to Cosmos DB, offering the best integration, SQL-based querying, and earliest access to new features. Other APIs (MongoDB, PostgreSQL, Cassandra, Gremlin, and Table) provide wire protocol compatibility with their respective open-source systems, making it easier to migrate or reuse existing tools and expertise. Each API offers scalability, flexibility, and performance guarantees, so the right choice depends on your application’s data model and ecosystem needs.

> Azure Cosmos DB uses request units (RUs) to measure the cost of database operations, normalizing resources like CPU, IOPS, and memory across all APIs. A simple point read of a 1-KB item costs 1 RU, and all operations—reads, writes, or queries—are billed in RUs. You can choose between provisioned throughput mode, where you reserve RUs per second, or serverless mode, where you only pay for the RUs consumed.

> Exercise: Create an Azure Cosmos DB account

- Create the Azure account
- Add Db and container
- Add data to the db


> Knowledge check:

# Check Your Knowledge

1. **Which of the following consistency levels offers the greatest throughput?**  
- Strong  
- Session  
- Eventual ✅  

---

2. **What are request units (RUs) in Azure Cosmos DB?**  
- ✅ A unit of measurement used to express the cost of all database operations in Azure Cosmos DB.  
- A unit of time used to measure the duration of database operations.  
- A unit of storage used to measure the amount of data stored in Azure Cosmos DB.  

> Summary ✅

In this module, you learned how to:

- Identify the key benefits provided by **Azure Cosmos DB**  
- Describe the elements in an **Azure Cosmos DB account** and how they're organized  
- Explain the different **consistency levels** and choose the correct one for your project  
- Explore the **APIs supported in Azure Cosmos DB** and choose the appropriate API for your solution  
- Describe how **request units (RUs)** impact costs  
- Create **Azure Cosmos DB resources** by using the Azure portal  
