# Udemy *NEW* MS Azure Developer Associate AZ-204 5 Practice Tests


## Question 1

You are designing a data governance policy for a Microsoft 365 environment.  
Your goal is to prevent users from performing any actions that would fail when **only a legal hold is active**, and all other retention policies have already expired.

**In this situation, which two operations should be explicitly blocked to meet the compliance requirements?**

---

### ✅ Correct Selection
- **Overwriting existing documents**  
- **Deleting documents**

---

### ❌ Incorrect Selection
- Adding data to documents  
- Creating new documents  

---

### 📖 Explanation of Correct Answers

**Overwriting existing documents**  
Legal hold ensures that content must remain unmodified to preserve it for legal investigations or litigation.  
When a user attempts to overwrite a document, it changes its content or metadata — violating the integrity required under a legal hold.  
Therefore, **overwriting must be blocked**.

**Deleting existing documents**  
Legal hold also prevents deletion of content.  
Even if all retention policies have expired, the legal hold alone requires that no content covered by it can be removed.  
Allowing deletion would result in potential data loss and non-compliance with legal requirements.

---

### ❌ Explanation of Incorrect Answers

**Adding new data to existing documents**  
This action might seem like it could modify a file, but not all systems treat this as a destructive action unless it overwrites existing protected content.  
However, in most implementations, "adding" is not inherently blocked by legal hold unless it alters protected data.  
It’s a gray area, but **not one of the top two actions clearly blocked under legal hold**.

**Creating new documents**  
Legal hold applies to existing content that needs to be preserved.  
It does not restrict users from creating new documents, since new content is not subject to any expired retention policies or the existing legal hold — unless it explicitly becomes part of a case later.

---

### 🔗 Reference  
[Overview of holds in Microsoft Purview](#)

---

> Question 2

After you answer a question in this section, you will **NOT** be able to return to it.  
As a result, these questions will not appear on the review screen.

You are implementing an application by using **Azure Event Grid** to push near-real-time information to customers.  
You have the following requirements:

- You must send events to thousands of customers that include hundreds of various event types.
- The events must be filtered by event type before processing.
- Authentication and authorization must be handled by using **Microsoft Entra ID**.
- The events must be published to a single endpoint.

You need to implement Azure Event Grid.

---

### ❌ Your Answer
**Yes**

---

### ✅ Correct Answer
**No**

---

### 📖 Explanation

The proposed solution — **publishing events to a partner topic and creating an event subscription for each customer** — does **not** fully meet the goal based on the provided requirements.

---

#### 🔹 Partner Topics  
Partner topics are typically used when a **third-party SaaS provider** wants to send events to a customer’s Azure subscription.  
This model is **customer-initiated**, meaning the customer creates a subscription to events published by the partner — **not the other way around**.

➡️ **In your scenario**, you are publishing events to your customers, so **custom topics (not partner topics)** are more appropriate.

---

#### 🔹 Event Filtering by Type  
While event subscriptions support filtering by event type, **creating thousands of event subscriptions (one per customer)** can become **inefficient and unscalable**, especially when all events are published to a **single endpoint**.

---

#### 🔹 Microsoft Entra ID (Azure AD) Authentication  
Authentication and authorization with **Entra ID** is supported for **custom topics and domain topics**,  
but **partner topics are designed for SaaS partners** — not for internal app-to-customer distribution.

---

#### 🔹 Requirement: Single Publishing Endpoint  
Partner topics don't align with the requirement to **publish all events to a single endpoint you manage**.  
Instead, you should use **custom topics or domain topics**, which give you full control over publishing, subscriptions, and filtering.

---

### ❌ Why the Solution Fails to Meet the Goal

- Partner topics are not designed for **publishing your own events** to customers.  
- Creating thousands of subscriptions on partner topics is **not scalable**.  
- It does not satisfy the requirement for **single endpoint management**.

---

### ✅ Recommended Solution

- **Use Azure Event Grid Domain** to create a **single publishing endpoint**.
- **Create event subscriptions per customer or group**, with **event type filtering**.
- **Use Microsoft Entra ID** for authentication on the domain topic.

---

### 🔗 Reference  
[Azure Event Grid Domain and Partner Topics](#)

---

> Question 3

You have developed and deployed an **Azure App Service** web application named **App1**.  
You also created an **Azure Key Vault** named **Vault1**, where you imported several secrets including API keys, passwords, certificates, and cryptographic keys.

Your goals are:

- ✅ Grant App1 secure access to Vault1  
- ✅ Automatically rotate credentials  
- ✅ Ensure no credentials are stored in the application code  

**What should you do to meet all the requirements?**

---

### ❌ Your Answer
- Enable App Service authentication for App1 and assign a custom RBAC role to Vault1  
- Add a TLS/SSL binding to App1  

---

### ✅ Correct Answer
**Assign a managed identity to App1**  
and grant it access to Vault1.

---

### 📖 Explanation

Assigning a **managed identity** to your App Service (**App1**) allows it to securely access Azure resources like **Key Vault** without storing credentials in code.  

Here’s why this solution works:

- Azure **automatically manages the identity’s credentials** (no secrets in code).
- You can grant that identity **Key Vault access** using Key Vault **access policies** or **Azure RBAC**.
- It supports **automatic secret rotation** using Key Vault references (e.g., in App Service app settings).
- This is the **recommended best practice** for securely accessing secrets in Azure.

---

### ❌ Explanation of Incorrect Answers

**Enable App Service authentication for App1 and assign a custom RBAC role to Vault1**  
App Service authentication controls **user sign-ins**, not app-to-app authentication.  
RBAC alone doesn’t solve the problem unless App1 has an identity (like a managed identity).  
It also does not meet the **automatic credential rotation** or **no-code-credentials** requirements.

**Add a TLS/SSL binding to App1**  
This secures traffic between the browser and App1, but has **nothing to do with Key Vault access** or secret management.  
It does not help with **secret rotation** or **credential-less access**.

**Upload a self-signed client certificate to Vault1 and update App1 to use it**  
This allows certificate-based access, but you would need to **store and manage the certificate manually**.  
That violates the "no credentials in code" requirement and does not support **automatic credential rotation** easily.

---

### 🔗 Reference  
[Grant access to Key Vault with a managed identity in App Service](#)

---

> Question 4

You are developing a web application that performs **image analysis** on user-uploaded photos and returns metadata about identified objects.

Because image processing is **resource-intensive**, you plan to use **Azure Cache for Redis** to store metadata and avoid reprocessing duplicate uploads.

**Key Requirement:**  
In the event of an **Azure data center outage**, metadata loss must be minimized.

**You need to properly configure your Azure Redis Cache instance to meet this requirement.**

---

### ✅ Correct Selection
- **Configure Azure Redis with RDB (snapshot-based) persistence**  
- **Set backup frequency to the minimum possible value**

---

### ❌ Your (Incorrect) Selection
- Configure Azure Redis with RDB persistence  
- Configure a second storage account for persistence  

---

### 📖 Explanation

**Configure Azure Redis with RDB (snapshot-based) persistence**  
RDB (Redis Database Backup) creates **point-in-time snapshots** of the Redis cache at configurable intervals.  
This allows you to **recover data** in the event of failures or outages.  
RDB is the **officially supported persistence mechanism** in Azure Cache for Redis.

**Set backup frequency to the minimum possible value**  
By reducing the snapshot/backup interval (e.g., **every 1 minute**), you minimize the amount of data that could be lost during a data center outage.  
This satisfies the requirement of **minimizing metadata loss**.

---

### ❌ Explanation of Incorrect Answers

**Configure a second storage account for persistence**  
Azure Cache for Redis persistence uses **a single Azure Storage account**.  
It does not support multiple storage accounts for redundancy.  
So this option is not valid.

**Configure Azure Redis with AOF (Append Only File) persistence**  
AOF persistence is **not supported** in Azure Cache for Redis (only available in self-hosted Redis).  
Azure’s managed Redis service relies on **RDB persistence**.

---

### 🔗 Reference  
[Azure Cache for Redis Persistence](#)

---

## Question 5

Your development team is building a new **REST API** that will store data in **Azure Blob Storage**.  
The API will be deployed to **Azure App Service**.

During development, the developers need **temporary access** to the Azure Blob storage account **for the next two months only**.  
After that, they must **no longer be able to access the storage account**.

**You need to securely grant and automatically expire their access after two months.**

---

### ✅ Correct Answer
**Generate a Shared Access Signature (SAS) for the Azure Blob storage account and provide it to all developers**

---

### ❌ Incorrect Answers
- Create and apply a lifecycle management policy that includes the last accessed date, and apply it to the Azure Blob storage account  
- Provide all developers with the storage account access key and update the API to include a UTC timestamp in the request header  
- Grant all developers access to the Azure Blob storage account using role-based access control (RBAC)

---

### 📖 Explanation

**Shared Access Signature (SAS)** tokens are the best choice for this scenario because:

- ✅ You can **define a start and expiry time** for the SAS token — ensuring that developer access **automatically expires after two months**.  
- ✅ You can **scope permissions** to specific actions (read, write, delete) and storage resources (specific containers or blobs).  
- ✅ Developers can use the SAS token without exposing storage account keys or storing permanent credentials in code.  

This approach meets all requirements: secure, time-bound, and automatically revoked.

---

### ❌ Explanation of Incorrect Answers

**Create and apply a lifecycle management policy**  
Lifecycle management policies are for **blob lifecycle automation** (e.g., moving to cool/archive tiers, deleting blobs after X days).  
They do not control **user access** to the storage account.

**Provide access key and add UTC timestamp in request header**  
Storage account access keys give **full, long-term access** to the account and do not expire automatically.  
Adding timestamps in headers does not revoke access.  
This approach is insecure and does not meet the time-bound access requirement.

**Use RBAC**  
Azure RBAC (e.g., assigning Blob Data Reader role) is great for managing **long-term, identity-based access** through Microsoft Entra ID.  
However, RBAC access does **not expire automatically** — you would have to manually revoke it after two months.

---

### 🔗 Reference  
[Grant limited access to Azure Storage resources using shared access signatures (SAS)](#)

---

You are developing an Azure-based solution to collect point-of-sale (POS) device data from 2,000 stores globally.
Each store has between 1 and 5 devices, and each device generates 2 MB of data per day.

Requirements:

All device data must be stored in Azure Blob Storage

Data must be correlated using a unique device identifier

The solution must scale easily as new stores and devices are added in the future

You are evaluating a solution to provision an Azure Notification Hub and register all devices with it.

Does this solution meet the goal?

Your answer is incorrect
Yes

Correct answer
No

Overall explanation
Azure Notification Hubs is a push-notification service designed for sending messages to mobile devices (like push alerts on iOS, Android, Windows). It is not built for collecting, ingesting, or storing data, and it cannot receive data from devices.

This makes it unsuitable for a telemetry or IoT data ingestion scenario, especially where:

Devices are producing structured data daily

Data must be sent and stored in Blob Storage

Scalability and correlation based on device identifiers are required

Instead, a better solution would be Azure IoT Hub, Event Hubs, or Azure Data Explorer, depending on your architecture.

❌ Why Notification Hub Fails:

It is not designed for data ingestion, but for sending notifications

Cannot store or route device data to Azure Blob Storage

Offers no correlation or telemetry tracking features

🔗 Microsoft Reference:

What is Azure Notification Hubs?

---

## Question 7

You are building an application that stores information about a company’s **organizational structure**.

The application must allow users to:

- Identify which employees report to a specific manager  
- Track the office location where each employee works  
- View the projects assigned to each employee  

You plan to use **Azure Cosmos DB** to store this data.

**Which Cosmos DB API is most appropriate for this use case?**

---

### ✅ Correct Answer
**Gremlin API**

---

### ❌ Incorrect Answers
- Core (SQL) API  
- Cassandra API  
- Table API  
- MongoDB API  

---

### 📖 Explanation

The **Gremlin API** is the best choice because it supports **graph-based data models**, which are ideal for modeling **hierarchical or network relationships**, such as:

- **Employee-to-manager relationships** (org chart traversal)  
- **Office assignments** (one-to-many relationships)  
- **Many-to-many relationships** such as employees assigned to multiple projects  

With **Gremlin** and graph queries, you can easily **traverse relationships** to find:

- All direct or indirect reports of a manager  
- All coworkers on a specific project  
- Employees working in the same office  

This makes it perfect for **organizational structures** where relationships matter more than individual records.

---

### ❌ Explanation of Incorrect Answers

**Core (SQL) API**  
Great for general-purpose **document storage**, but it doesn't efficiently support **relationship traversal**.  
Modeling hierarchical relationships would require manual joins or deeply nested documents — which becomes complex and inefficient.

**Cassandra API**  
A **wide-column store** optimized for high-throughput writes and scalability.  
Not ideal for querying hierarchical relationships or traversing complex networks of data.

**Table API**  
Essentially a **key-value store** (like Azure Table Storage) with very limited query capabilities.  
Not suited for complex relationships or hierarchical queries.

**MongoDB API**  
Good for flexible **document-based storage**, but still not optimized for relationship traversal.  
Would require custom aggregation pipelines or manual joins to represent an org chart.

---

### 🔗 Reference  
[Model and query graphs in Azure Cosmos DB with the Gremlin API](#)

---

# Question 8

You are developing a Java application that uses **Cassandra** for storing key-value data. You plan to migrate this to a new **Azure Cosmos DB** resource using the **Cassandra API**.

You also created an Azure Active Directory (Azure AD) group named **Cosmos DB Creators**, which should have permission to provision Cosmos DB accounts, databases, and containers.  
However, this group **must not** be able to access the keys used to access the stored data.

**You need to assign the appropriate Azure role-based access control (RBAC) permission to the group. Which role should you assign?**

---

### Options
- DocumentDB Accounts Contributor  
- Cosmos Backup Operator  
- **Cosmos DB Operator**  
- Cosmos DB Account Reader

---

### ❌ Your Answer
**Cosmos DB Account Reader** — *Incorrect*

---

### ✅ Correct Answer
**Cosmos DB Operator**

---

### 📖 Overall explanation

**Why Cosmos DB Operator is correct**  
The **Cosmos DB Operator** role is specifically designed to allow provisioning and management of Azure Cosmos DB resources (accounts, databases, containers) **without** granting access to the account keys. This enforces separation of duties: the group can create and manage resources but cannot read or list the keys used to access stored data.

**Why the other roles are incorrect**

- **DocumentDB Accounts Contributor**  
  Grants broad management permissions on Cosmos DB instances **including** the ability to read/list access keys — which violates the requirement to prevent key access.

- **Cosmos Backup Operator**  
  Focused on backup/restore operations; it does **not** provide the provisioning permissions needed in this scenario.

- **Cosmos DB Account Reader**  
  Read-only access to account properties; it does **not** allow creating databases/containers and therefore cannot fulfill the provisioning requirement.

---

### 🔗 Reference  
[Built-in roles for Azure Cosmos DB](#)


---

## Question 9

You are developing an **Azure service application** that processes data from a **mobile application** using message queues.  
However, messages may arrive **inconsistently throughout the day**.

The solution must meet the following requirements:

- ✅ The queue size must not exceed **80 GB**  
- ✅ Messages must be processed in **first-in-first-out (FIFO)** order  
- ✅ **Azure costs** must be minimized  

You are considering the following design:

- Use the **.NET API** to send messages from the mobile app to an **Azure Storage Queue**  
- Create an **Azure Virtual Machine (VM)** that is triggered by events from the Storage Queue  

**Does this solution meet the goal?**

---

### ❌ Your Answer
**Yes** — *Incorrect*

---

### ✅ Correct Answer
**No**

---

### 📖 Explanation

This solution does **not** meet the stated requirements for several reasons:

---

#### 🔹 Lack of FIFO Guarantee  
**Azure Storage Queues** provide only **best-effort ordering**, not strict FIFO.  
This violates the requirement for **first-in-first-out message processing**.

---

#### 🔹 Storage Queue Size Consideration  
While Azure Storage Queues support large total capacity (up to 500 TB per account), they are not ideal for **precise queue size management at 80 GB**, and do not provide native FIFO guarantees.

---

#### 🔹 Cost Inefficiency with Virtual Machines  
Using a **VM** for message processing introduces **continuous costs** (compute, storage, idle time).  
This is inefficient compared to **serverless, event-driven options** like Azure Functions, which scale automatically and only incur cost per execution.

---

### ✅ Better Alternative Design

- **Use Azure Service Bus Queue** with **sessions or FIFO ordering enabled**  
  (Service Bus guarantees FIFO and handles large-scale messaging reliably)  
- **Use Azure Functions** or **Logic Apps** for **serverless message processing**  
  (minimizes cost by running only when events are received)

---

### ❌ Explanation of Incorrect Design Choices

- **Azure Storage Queue** → No strict FIFO ordering  
- **Azure VM** → Expensive and less scalable compared to serverless options  
- **Manual Scaling** → Increases complexity and cost over time  

---

### 🔗 Reference  
[Azure Storage Queues vs. Service Bus Queues](#)

---

## Question 10

You are developing an **Azure service application** that processes **queue data** whenever a mobile application sends a message.  
These messages are not sent consistently, meaning the volume varies over time.

The solution must meet the following requirements:

- ✅ The queue size must not exceed **80 GB**
- ✅ Messages must be processed in **first-in-first-out (FIFO)** order
- ✅ **Minimize Azure costs**

You propose the following solution:

- Use the **.NET API** to send messages from the mobile app to an **Azure Service Bus Queue**
- Use an **Azure Windows Virtual Machine (VM)** that is triggered from the Service Bus Queue to process messages

**Does this solution meet the goal?**

---

### ❌ Your Answer
**Yes** — *Incorrect*

---

### ✅ Correct Answer
**No**

---

### 📖 Explanation

This solution only partially satisfies the requirements:

---

#### ✅ What’s Correct

- **Azure Service Bus Queues**  
  - Support **FIFO** processing (via sessions)
  - Can handle **large volumes** of messages, well beyond 80 GB

---

#### ❌ What’s Incorrect

- **Use of Virtual Machines (VMs)**  
  - VMs incur **continuous compute costs**, even when message volume is low
  - Require manual management (start/stop) or automation, adding complexity
  - Violates the requirement to **minimize costs** — especially for workloads with variable demand

---

### ✅ Better Alternative

- **Azure Service Bus Queue** with **sessions enabled** for strict FIFO  
- **Azure Functions** (serverless) with a **Service Bus trigger**  
  - Executes **only when messages are present**, minimizing costs  
  - Automatically scales with message volume  
  - Eliminates VM infrastructure management

---

### 🔗 Microsoft Reference

- [Service Bus queues, topics, and subscriptions - Features](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-queues-topics-subscriptions)
- [Azure Functions trigger for Service Bus](https://learn.microsoft.com/azure/azure-functions/functions-bindings-service-bus)

---

# Question 11

You are developing a software solution for an **autonomous transportation system**. The system uses large datasets and **Azure Batch** processing to simulate navigation scenarios for entire fleets of vehicles.

To run the simulations, you must create **compute nodes (virtual machines)** in Azure Batch.

**What should you do to create the compute nodes?**

---

### ❌ Your Answer
- In the Azure portal, create a Batch account

---

### ✅ Correct Answer
- In a .NET method, call `BatchClient.PoolOperations.CreatePool(...)`

---

### 📖 Overall explanation

To create compute nodes in Azure Batch you must create a **pool** of compute VMs. Using the .NET Batch SDK, you call:

```csharp
BatchClient.PoolOperations.CreatePool(...)
```
When creating a pool you define the VM size and number of nodes, the OS/image configuration, and any start-up or application scripts. After the pool is created, Azure Batch will automatically provision the compute nodes as specified.

❌ Explanation of Incorrect Options

- In the Azure portal, create a Batch account
This is a required prerequisite (you need a Batch account to use the service), but creating the account does not create compute nodes or pools.

- In Python, implement the class JobAddParameter
This class is used to define and submit a job, which runs on existing pools. It does not create pools or compute nodes.

- In Python, implement the class TaskAddParameter
This class is used to define tasks within a job. Tasks run on compute nodes that must already exist; TaskAddParameter does not create compute nodes.

🔗 Reference

Create and manage pools in Azure Batch (C#)

---
## Question 12

You are developing an **HTTP-triggered Azure Function App** that processes data from **Azure Storage blobs** using an output binding.

Currently, the function **times out after 4 minutes**, and you need to ensure it can complete processing the blob data without timing out.

You propose the following solution:

- Update the `functionTimeout` property in the **host.json** file to extend the timeout to **10 minutes**

**Does this solution meet the goal?**

---

### ✅ Your Answer
**No** — *Correct*

---

### 📖 Overall Explanation

Updating the `functionTimeout` in `host.json` can extend execution time, but there are **limitations based on the hosting plan**:

---

#### 🔹 Consumption Plan (default)

- Maximum timeout is **5 minutes**  
- Setting `functionTimeout` to 10 minutes **will not be honored**  
- Therefore, this change **won’t solve the timeout issue** on the Consumption Plan

---

#### 🔹 Premium or Dedicated (App Service) Plan

- You **can** set `functionTimeout` to a higher value, or even infinite using `"functionTimeout": "-1"`  
- Longer processing times are supported on these plans

---

### ❌ Why This Solution Doesn’t Meet the Goal

- **10 minutes exceeds the max allowed on the Consumption Plan**  
- The function will continue to **time out after 4–5 minutes** unless you **upgrade the hosting plan**  

---

### 🔗 Reference
[Azure Functions scale and hosting plans](#)

---

## Question 13

You are developing an application that will use **Azure Cosmos DB** for storing data.  
The application needs to process **batches of relational data** — meaning the data is structured and may involve relationships, filtering, and querying similar to working with SQL tables.

**You need to choose the most appropriate Cosmos DB API for this use case.**

---

### Options
- MongoDB API  
- Table API  
- **SQL API** — *Correct*  
- Cassandra API  

---

### 📖 Overall Explanation

The **SQL API** is the native and most feature-rich API provided by Azure Cosmos DB. It is ideal for applications that need to:

- Work with **structured, relational-like JSON documents**  
- Use **SQL-like syntax** to query data  
- Handle **batch processing, filtering, joins, and projections**  

Since you’re processing **batches of relational data**, the SQL API provides:

- Flexible querying capabilities  
- Optimized document-based storage with relationships  
- Rich indexing and query support  

---

### ❌ Explanation of Incorrect Answers

**MongoDB API**  
- Designed for apps already using MongoDB  
- Supports document storage but is **less suited for complex relational queries** if building from scratch

**Table API**  
- Very limited querying capabilities  
- Only supports **key-value lookups**  
- Not suited for relational or batch processing scenarios

**Cassandra API**  
- Optimized for **wide-column, high-throughput scenarios**  
- Good for **time-series or telemetry data**  
- Not ideal for relational batch processing

---

### 🔗 Reference
[Introduction to Azure Cosmos DB SQL API](#)

---

## Question 14

You are developing several applications for a company, and you plan to host them using **Azure App Services**.

The company requires the following for monitoring their websites:

- ✅ Check that websites are **responsive every 5 minutes**  
- ✅ Ensure the site responds within a **specific time threshold**  
- ✅ Confirm that dependent resources (like images and JavaScript files) **load properly**  
- ✅ Generate **alerts** if a website experiences issues  
- ✅ If the website fails to load, the system should **retry the request up to three times**

**You want to implement this solution using the least amount of effort.**

---

### Options
- Create a Selenium web test and run it as a scheduled task from your workstation  
- **Set up a URL ping test to query the home page** — *Correct*  
- Create an Azure Function to query the home page  
- Create a multi-step web test to query the home page  
- Create a Custom Track Availability Test to query the home page  

---

### ✅ Correct Answer
**Set up a URL ping test to query the home page**

---

### 📖 Overall Explanation

An **Azure Application Insights URL ping test** is the simplest and most effective option because it:

- Automatically **pings a public URL every 5 minutes**  
- Allows setting **timeout thresholds** for responsiveness  
- Configures **retry attempts** (default: up to 3 retries)  
- Monitors **dependent resources** such as images and scripts  
- Generates **alerts** for performance or availability issues  
- Requires **minimal setup** and integrates fully with **Azure Monitor**  

This solution meets all requirements **with the least effort**.

---

### ❌ Explanation of Incorrect Answers

**Selenium web test + Scheduled Task**  
- Requires **manual setup and maintenance**  
- Not cloud-based and lacks **Azure integration**  
- Does not scale or provide centralized monitoring  

**Azure Function to query the home page**  
- Technically feasible but requires **custom development**, error handling, logging, alerting, and scheduling — more effort than needed  

**Multi-step web test**  
- Deprecated in favor of **custom availability tests** using Azure Monitor or Playwright  
- Requires more setup  

**Custom Track Availability Test**  
- Requires **scripting with Visual Studio or Azure Monitor**  
- Provides fine control but **requires more effort** than a built-in URL ping test  

---

### 🔗 Reference
[Create a URL ping test using Application Insights](#)


---

## Question 15

You are developing **Azure-based solutions**.  

A **.NET application** must receive a message each time an **Azure Virtual Machine** finishes processing data.

**Requirements:**

- The message must be **received and processed** by the application  
- Once processed, the message should **not persist** (i.e., no duplication or storage)  

**Which .NET object should you use to receive these messages?**

---

### Options
- QueueClient  
- **SubscriptionClient** — *Correct*  
- TopicClient  
- CloudQueueClient  

---

### ✅ Correct Answer
**SubscriptionClient**

---

### 📖 Overall Explanation

**SubscriptionClient** is part of **Azure Service Bus** and is used to receive messages from a **topic subscription**. This is ideal for **publish-subscribe (pub/sub)** scenarios:

- A **topic** publishes messages  
- Multiple **subscriptions** can independently receive messages  
- Messages are **removed after successful processing**  

**Scenario Context:**

- The VM sends a message to a **Service Bus Topic** when it finishes processing  
- The .NET app uses a **SubscriptionClient** to receive the message  
- Once processed, the message is **no longer retained**, satisfying the requirement

---

### ❌ Explanation of Incorrect Answers

**QueueClient**  
- Receives messages from a **Service Bus Queue** (point-to-point)  
- Not ideal for pub/sub scenarios where multiple consumers may need the message  

**TopicClient**  
- Used to **send messages** to a topic, not to receive them  

**CloudQueueClient**  
- Part of **Azure Storage Queues**  
- Does not support **pub/sub patterns**  
- Messages persist until explicitly deleted, even after processing, which violates the requirement

---

### 🔗 Reference
[Azure.Messaging.ServiceBus - Process messages](#)

---

## Question 16

You are developing a **web application** that runs on **Azure App Service**.  

The app:

- Stores data in **Azure SQL Database**  
- Stores files in **Azure Storage**  
- Makes HTTP requests to external services, which are **OpenTelemetry-compliant**  
- Is instrumented with **Application Insights**  

**Goal:**  
Ensure that the **customer ID** of the signed-in user is associated with **all operations across the entire system**, including telemetry across services.

---

### Options
- Create a new SpanContext with the TraceFlags value set to the customer ID  
- On the current SpanContext, set the TraceId to the customer ID  
- **Add the customer ID to the CorrelationContext in the web application** — *Correct*  
- Set the HTTP header Ocp-Apim-Trace to the customer ID  

---

### ✅ Correct Answer
**Add the customer ID to the CorrelationContext in the web application**

---

### 📖 Overall Explanation

To propagate **custom identifiers** (like customer IDs) across a distributed system:

- Use **CorrelationContext** or **Activity baggage**  
- Allows context values to be **propagated across service boundaries**  
- Automatically includes them in **logs, traces, and telemetry**  
- Integrates seamlessly with **Application Insights** and **OpenTelemetry**  
- Ensures the customer ID is linked to **all downstream operations and dependencies**  

This is the **most effective and standards-compliant** approach to track user-specific operations.

---

### ❌ Explanation of Incorrect Answers

**Create a new SpanContext with TraceFlags set to the customer ID**  
- TraceFlags indicate **trace sampling**, not user identity  
- Misusing this field **does not propagate the customer ID**

**Set the TraceId to the customer ID on the current SpanContext**  
- TraceId uniquely identifies a trace  
- Overwriting it with a user ID **breaks trace linking** and violates OpenTelemetry standards

**Set the HTTP header Ocp-Apim-Trace to the customer ID**  
- This header is used for **Azure API Management tracing**, not for **end-to-end telemetry correlation**  
- Won’t associate the customer ID with telemetry across services

---

### 🔗 Reference
[Add custom properties to telemetry (Application Insights)](#)

--- 

## Question 17

You have an **Azure Queue Storage** account that contains a queue named `queue1`.  

You're developing a solution using the **Azure SDK for .NET**.  

**Requirements:**

- Use the **Azure SDK for .NET**  
- Minimize **development effort**  
- Get the **approximate message count**  

**Which method should you use in your code?**

---

### Options
- **GetProperties method of the QueueClient class** — *Correct*  
- GetProperties method of the QueueServiceClient class  
- PeekMessages method of the QueueClient class  
- GetStatistics method of the QueueServiceClient class  

---

### ✅ Correct Answer
**QueueClient.GetProperties()**

---

### 📖 Overall Explanation

To retrieve the **approximate number of messages** in a specific queue (`queue1`), use:

```csharp
QueueClient queueClient = new QueueClient(connectionString, "queue1");
QueueProperties properties = queueClient.GetProperties();
int messageCount = properties.ApproximateMessagesCount;
```

### QueueClient.GetProperties() Overview

Returns metadata about the queue, including:

- Approximate message count  
- Queue properties and metadata  
- Simple, efficient, and requires minimal code  

---

### ❌ Explanation of Incorrect Answers

**GetProperties method of the QueueServiceClient class**  
- Retrieves properties of the **entire Queue service**, not a specific queue  
- Does **not provide the message count** for `queue1`  

**PeekMessages method of the QueueClient class**  
- Retrieves **contents of messages** without dequeuing  
- Not intended for **message counts** and requires extra logic  

**GetStatistics method of the QueueServiceClient class**  
- Returns **storage account-level statistics** (replication, geo-replication)  
- Does **not provide per-queue message counts**  

---

### 🔗 Reference
[QueueClient.GetProperties Method – Azure SDK](#)

---

## Question 19

You are developing an application to manage **shipping information for cargo ships**.  

The application will use **Azure Cosmos DB** for data storage.

**Key requirements:**

- The application must be able to **run offline** while ships are at sea  
- The application must **synchronize with Azure Cosmos DB** when the ships are in port and connected  

**Goal:**  
Choose the most appropriate Azure Cosmos DB API to support **offline and online synchronization**.

---

### Options
- **Core (SQL)** — *Correct*  
- MongoDB  
- Cassandra  
- Gremlin  

---

### ✅ Correct Answer
**Core (SQL) API**

---

### 📖 Overall Explanation

The **Core (SQL) API** is the only Cosmos DB API that **natively supports offline and sync capabilities**, using:

- **Azure Mobile Apps**  
- Third-party libraries like **Microsoft Sync Framework**

It is suitable for scenarios where:

- **Offline-first architecture** is required  
- **Conflict resolution and sync** are needed when connectivity is restored  
- The data model fits **JSON documents**

Ideal for **cargo ships at sea**, allowing the app to:

- Store and process data **offline**  
- Sync back to Cosmos DB **when reconnected in port**

---

### ❌ Explanation of Incorrect Answers

**MongoDB API**  
- Does not **natively support offline synchronization**  
- Third-party libraries may offer sync, but not seamless with Cosmos DB

**Cassandra API**  
- Built for **wide-column storage**, not document-based or sync scenarios  
- Lacks **offline capabilities** or automatic sync support

**Gremlin API**  
- Designed for **graph data modeling and traversal**  
- Not suited for **document-based, offline-first scenarios**  
- Does not support **sync features**

---

### 🔗 Reference
[Offline Data Sync with Azure Cosmos DB](#)

---

## Question 20

You are developing and hosting several APIs using **Azure API Management (APIM)**.  

You need to inspect request processing inside APIM to include:

- The original request APIM received from the client and policies applied to it  
- The request sent by APIM to the backend and the response it received  
- The policies applied to the backend response before it's returned to the client  
- Any errors that occurred and the policies applied during error handling  
- Support for requests made from a REST client  

---

### Options
- **Enable the Allow tracing setting for the subscription used to inspect the API** — *Correct*  
- **Add the Ocp-Apim-Trace header with a value of true to the API call** — *Correct*  
- **Add the Ocp-Apim-Subscription-Key header with a valid subscription key** — *Correct*  
- Create and configure a custom policy and apply it to the outbound policy at API scope  
- Create and configure a custom policy and apply it to the inbound policy at global scope  

---

### ✅ Correct Actions

**1. Enable Allow tracing**  
- Must be explicitly enabled on the subscription used to call the API  
- Allows APIM to **include trace data** in the response headers  

**2. Add Ocp-Apim-Trace: true**  
- Header triggers APIM to **include detailed trace data**  
- Includes: policy evaluations, backend responses, and any errors  

**3. Add a valid Ocp-Apim-Subscription-Key**  
- Authenticates the client to access the API  
- Without it, **trace data will not be returned**, and the call may fail if the API is not open  

---

### ❌ Explanation of Incorrect Answers

**Create and configure a custom policy (outbound)**  
- Not required to enable tracing  
- Trace capabilities are **built into APIM**; custom policies are for modifying behavior, not enabling trace  

**Create and configure a custom policy (inbound)**  
- Similarly, does not activate tracing  
- May affect logged content, but **tracing itself does not require these policies**  

---

### 🔗 Reference
[Azure API Management - Trace requests](#)

---

## Question 20

You are developing and hosting several APIs using **Azure API Management (APIM)**.  

You need to inspect request processing inside APIM to include:

- The original request APIM received from the client and policies applied to it  
- The request sent by APIM to the backend and the response it received  
- The policies applied to the backend response before it's returned to the client  
- Any errors that occurred and the policies applied during error handling  
- Support for requests made from a REST client  

---

### Options
- **Enable the Allow tracing setting for the subscription used to inspect the API** — *Correct*  
- **Add the Ocp-Apim-Trace header with a value of true to the API call** — *Correct*  
- **Add the Ocp-Apim-Subscription-Key header with a valid subscription key** — *Correct*  
- Create and configure a custom policy and apply it to the outbound policy at API scope  
- Create and configure a custom policy and apply it to the inbound policy at global scope  

---

### ✅ Correct Actions

**1. Enable Allow tracing**  
- Must be explicitly enabled on the subscription used to call the API  
- Allows APIM to **include trace data** in the response headers  

**2. Add Ocp-Apim-Trace: true**  
- Header triggers APIM to **include detailed trace data**  
- Includes: policy evaluations, backend responses, and any errors  

**3. Add a valid Ocp-Apim-Subscription-Key**  
- Authenticates the client to access the API  
- Without it, **trace data will not be returned**, and the call may fail if the API is not open  

---

### ❌ Explanation of Incorrect Answers

**Create and configure a custom policy (outbound)**  
- Not required to enable tracing  
- Trace capabilities are **built into APIM**; custom policies are for modifying behavior, not enabling trace  

**Create and configure a custom policy (inbound)**  
- Similarly, does not activate tracing  
- May affect logged content, but **tracing itself does not require these policies**  

---

### 🔗 Reference
[Azure API Management - Trace requests](#)

---

Question 21:
You are building an Azure-based solution to collect point-of-sale (POS) data from 2,000 store locations worldwide.
Each store has 1 to 5 devices, and each device sends up to 2 MB of data daily.

Requirements:

Store the data in Azure Blob Storage

Ensure data is correlated by device identifier

Support future scale as more stores and devices are added

You consider the following implementation:

Provision Azure Event Grid, set the machine identifier as the partition key, and enable event capture

Does this solution meet the goal?

Your answer is incorrect
Yes

Correct answer
No

Overall explanation
While Azure Event Grid is excellent for event-driven architectures, it is not designed for directly ingesting or buffering large volumes of telemetry data like device data streams.

Here's why it does not meet the goal:

Event Grid is built for lightweight event notifications, not for bulk data ingestion or buffering high-frequency device data.

It doesn’t store data or support partitioning by a custom key (like device ID) for direct ingestion. The concept of a partition key is more applicable to Event Hubs or Cosmos DB, not Event Grid.

Enabling capture applies to Event Hubs, not Event Grid.

✅ Better Alternative:

Use Azure Event Hubs with:

Device ID as the partition key

Event Hubs Capture enabled to automatically store data in Azure Blob Storage

Scalable for large-scale ingestion of device telemetry from many sources

❌ Why the proposed solution fails:

Event Grid doesn’t support bulk data streaming

Partition key configuration and capture features are not native to Event Grid

Data correlation and partitioning are better handled by Event Hubs

🔗 Microsoft Reference:

Choose between Azure Event Grid, Event Hubs, and Service Bus

---

## Question 22

You are developing a solution that will use **Azure messaging services**.

**Goals:**

- Use a **publish-subscribe model**  
- Eliminate **constant polling** (i.e., prefer event-driven or push-based communication)  

---

### Options
- **Service Bus** — *Correct*  
- Event Hub  
- **Event Grid** — *Correct*  
- Queue  

---

### ✅ Correct Answers

**1. Service Bus (with Topics and Subscriptions)**  
- Supports **publish-subscribe (pub-sub)** through topics and subscriptions  
- Multiple subscribers can receive **copies of the same message**  
- Use **message handlers or triggers** (e.g., Azure Functions) to eliminate polling  
- Ideal for **enterprise messaging patterns**

**2. Event Grid**  
- Built specifically for **event-based publish-subscribe**  
- Delivers **push-based notifications** to handlers (Azure Functions, Logic Apps, Webhooks)  
- Highly **scalable**, no need for polling  
- Supports **filtering and event routing**

---

### ❌ Explanation of Incorrect Answers

**Event Hub**  
- Designed for **telemetry and log ingestion**, not traditional pub-sub  
- Consumers must **poll** or use **checkpointing** to read messages  
- Not a true pub-sub model

**Queue (Storage Queue)**  
- Supports **point-to-point messaging**, not pub-sub  
- Requires **polling** to receive messages  
- No native support for **multiple subscribers** or **push delivery**

---

### 🔗 Reference
[Compare Azure messaging services](#)

---

## Question 23

You are developing an **Azure App Service web app** and have enabled **Application Insights** in the production environment.

Recently, the app has been throwing multiple exceptions, and you need to:

✅ Examine the **state of the source code and variables** at the moment the exceptions are thrown.

---

### Options
- Smart Detection  
- **Snapshot Debugger** — *Correct*  
- Standard Test  
- Profiler  

---

### ✅ Correct Answer
**Snapshot Debugger**

---

### 📖 Overall Explanation

The **Snapshot Debugger** in Application Insights allows you to:

- Capture a **snapshot of the application’s call stack, variables, and state** when an unhandled exception occurs  
- Diagnose issues in production **without reproducing them locally**  
- View **local variables, parameters, and source code references** for failed requests and exceptions  

It is the ideal tool to understand what the code was doing at the moment of the exception.

---

### ❌ Explanation of Incorrect Answers

**Smart Detection**  
- Detects abnormal behaviors like failure rates or performance degradation  
- Does **not** show variable values or code state  

**Standard Test**  
- Refers to availability tests (e.g., URL ping tests)  
- Monitors app uptime, **not** exceptions or variable state  

**Profiler**  
- Analyzes application performance and slow methods  
- Does **not** capture variable values or debug exception state  

---

### 🔗 Reference
[Snapshot Debugger in Application Insights](#)

---

## Question 24

You are developing a **Logic App** to process temperature readings from IoT devices across multiple warehouses.  
These readings are sent to an **Azure Service Bus queue**, and you need to send **email alerts** if a temperature is above or below a threshold.

---

### Correct Sequence of Steps

1. **Create a blank Logic App**  
2. **Add a Logic App trigger** that fires when one or more messages arrive in the Service Bus queue  
3. **Add an action** that reads IoT temperature data from the Service Bus queue  
4. **Add a condition** that compares the temperature against the upper and lower thresholds  
5. **Add an action** that sends an email to specified personnel if the temperature is outside of those thresholds  

---

### ✅ Overall Explanation

- Start with a **blank canvas** in Logic Apps.  
- Use a **Service Bus trigger** to listen for incoming messages.  
- Retrieve and process the **temperature data** from the messages.  
- **Evaluate** the readings against predefined thresholds using a condition.  
- **Send alerts** via email when readings exceed or fall below the limits.  
- This sequence ensures **event-driven processing** without unnecessary polling or scheduling.  

---

## Question 25

You need to trigger a **Logic App** only when new temperature messages arrive from an IoT device via **Azure Service Bus**.

---

### Options
- A recurrence trigger that runs every 15 minutes  
- A trigger that reads data from Blob Storage  
- **A Logic App trigger that fires when one or more messages arrive in the queue** — *Correct*  
- A webhook trigger that listens for HTTP requests  

---

### ✅ Overall Explanation

The correct trigger for **event-driven processing** from a Service Bus queue is the **queue message arrival trigger**.  

- This avoids polling  
- Allows the Logic App to **react in real-time** to incoming messages

---

## Question 26

In a **Logic App** that processes IoT temperature data, you want to check if the temperature exceeds a set threshold.

---

### Options
- A recurrence condition  
- A data transformation step  
- A custom API connector  
- **A condition that compares the value against upper and lower limits** — *Correct*  

---

### ✅ Overall Explanation

The **Condition** action is designed to:

- Compare values  
- Apply logic based on the comparison result  

It is ideal for **checking temperature against defined thresholds** and controlling the flow of subsequent actions (e.g., sending alerts).

---

## Question 27

You are developing an application to store **business-critical data** in Azure Blob Storage.

Requirements:

- Data must **not be modified or deleted** for a user-specified interval  
- Data must be **protected from overwrites and deletes**  
- Data must be **write once, read many (WORM)**  

---

### Correct Actions

- **Enable version-level immutability support for the storage account** — *Correct*  
- **Configure a time-based retention policy for the storage account** — *Correct*  

---

### ✅ Overall Explanation

**Enable version-level immutability support**

- Applies **immutability policies** to individual blob versions  
- Ensures each version remains **tamper-proof** for a defined duration  
- Supports **WORM** (Write Once, Read Many) protection  

**Configure a time-based retention policy**

- Sets a **retention interval** during which blobs cannot be modified or deleted  
- Enforces **time-based WORM protection**, meeting the requirements  

---

### ❌ Incorrect Options

- **Create an account SAS**  
  - SAS tokens control **access permissions**, not immutability  
  - Useful for secure access, **not protection from overwrites or deletes**  

- **Enable point-in-time restore**  
  - Helps recover accidentally deleted/overwritten blobs  
  - Does **not prevent modifications or deletions**  

- **Create a service SAS**  
  - Like account SAS, manages access, **not immutability**  

- **Enable blob change feed**  
  - Provides a **log of changes** for auditing  
  - **Does not prevent changes or deletions**  

---

### 🔗 Microsoft Reference

[Immutability policies for Azure Blob Storage](https://learn.microsoft.com/azure/storage/blobs/immutable-storage-overview)

> Enable version-level immutability support and configure a time-based retention policy to enforce WORM and protect blobs from modification or deletion.

---

# Question 28

You are developing a solution that stores sensitive data in an Azure SQL Database. An external party should not be able to access the values stored in the `SSN` column of the `Person` table.

## Correct Answer
- **Enable Always Encrypted for the SSN column**

## Incorrect Answers
- Set the column encryption setting to disabled  
  *Disabling encryption removes protection for the column, allowing data to be accessed in plaintext.*

- Assign users to the Public fixed database role  
  *The Public role is assigned to all users by default and does not restrict access.*

- Store column encryption keys in the system catalog view in the database  
  *Storing keys in the database catalog makes them accessible to database admins and defeats Always Encrypted security.*

## Overall Explanation
Always Encrypted ensures sensitive data is encrypted at the client-side and remains inaccessible to SQL Server or unauthorized users, providing strong protection for sensitive columns like SSNs.

🔗 [Microsoft Reference: Always Encrypted – Azure SQL](https://learn.microsoft.com/en-us/sql/relational-databases/security/encryption/always-encrypted-database-engine)

---

# Question 29

You are developing an Azure solution and need to retrieve a secret stored in Azure Key Vault using the Azure SDK for .NET.

```csharp
string var1 = Environment.GetEnvironmentVariable("KEY_VAULT_URI");
var var2 = new ____________(new Uri(var1), new ____________());
```

## Correct Answer
- **SecretClient** and **DefaultAzureCredential**

## Incorrect Answers
- CloudClients and ClientSecretCredential  
  *CloudClients is not a valid class in the Azure SDK.*

- ClientSecretCredential and CloudClients  
  *ClientSecretCredential requires manual setup and CloudClients is invalid.*

- SecretClient and ClientSecretCredential  
  *While valid, ClientSecretCredential requires manual authentication; DefaultAzureCredential is simpler and preferred.*

## Overall Explanation
- **SecretClient**: Main client class to interact with Key Vault secrets.  
- **DefaultAzureCredential**: Automatically selects the best available credential, using developer credentials locally and managed identities in production, making it the recommended approach.

🔗 [Microsoft Reference: Quickstart – Azure Key Vault client library for .NET](https://learn.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net)

Summary Sentence:
Use SecretClient with DefaultAzureCredential to securely retrieve secrets from Azure Key Vault with minimal setup.

---

# Question 30

You are developing an application that uses the OAuth 2.0 authorization code flow to authenticate users.

## Correct Answer
- **state**

## Incorrect Answers
- code_challenge  
  *Used in PKCE for public client security, not for CSRF protection.*

- tenant  
  *Specifies the Azure AD directory, unrelated to CSRF.*

- scope  
  *Defines requested access, unrelated to CSRF.*

- client_id  
  *Identifies the application but does not protect against CSRF.*

## Overall Explanation
The **state** parameter is generated by your app and sent with the authorization request. It must match the value returned in the redirect URI. This ensures the response is valid and protects against CSRF attacks.

🔗 [Microsoft Reference: OAuth 2.0 Authorization Code Flow - Microsoft Identity Platform](https://learn.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow)

> Summary Sentence: 
Use the `state` parameter in OAuth 2.0 authorization requests to prevent CSRF attacks by validating the returned response.

---

# Question 31

You manage an Azure Key Vault named `kv1` using the Standard SKU and plan to store an asymmetric key pair. Your application `app1` must retrieve and use this key pair.

## Correct Answer
- **KeyClient**

## Incorrect Answers
- SecretClient  
  *Used for secrets like passwords or connection strings; cannot perform encryption/decryption.*

- KeyVaultSettingsClient  
  *Not a valid Azure SDK class.*

- CertificateClient  
  *Manages certificates, not standalone keys.*

## Overall Explanation
The **KeyClient** class is specifically designed to create, retrieve, and manage keys (symmetric or asymmetric) in Azure Key Vault, and supports cryptographic operations such as encryption, decryption, and key wrapping. It is the appropriate choice for accessing asymmetric key pairs programmatically.

🔗 [Microsoft Reference: Azure.Security.KeyVault.Keys – KeyClient Class](https://learn.microsoft.com/en-us/dotnet/api/azure.security.keyvault.keys.keyclient)

> Summary Sentence:
Use the `KeyClient` class to retrieve and manage asymmetric key pairs from Azure Key Vault for cryptographic operations.

---

# Question 32

You are designing network connectivity for a subnet in an Azure virtual network with 30 virtual machines.

## Requirements
- Outbound internet connections using a pool of four public IP addresses
- Inbound internet connections must be blocked

## Correct Answer
- **NAT Gateway**

## Incorrect Answers
- Azure Private Link  
  *Used for secure access to Azure PaaS services over private IPs; not relevant for outbound internet access.*

- User Defined Routes  
  *Handles custom routing but does not provide NAT or public IP pooling.*

- Azure Virtual WAN  
  *Global networking service for branch connectivity; overkill for this scenario.*

## Overall Explanation
A **NAT Gateway** allows outbound-only internet access for virtual machines using a static pool of public IP addresses, while blocking inbound connections by default. It meets the requirements for both scalability and security for the 30 VMs using 4 public IPs.

🔗 [Microsoft Reference: What is Azure Virtual Network NAT?](https://learn.microsoft.com/en-us/azure/virtual-network/nat-overview)

> **Summary:**  
A `NAT Gateway` should be used to provide outbound-only internet access with a static pool of public IPs while blocking inbound traffic.

---

# Question 33

You are developing an application that runs in multiple Azure Kubernetes Service (AKS) clusters. Pods collect large volumes of performance data that must be:

- Saved quickly (low write latency)  
- Stored durably to survive pod restarts

## Correct Answers
- **Set the provisioner value to `kubernetes.io/azure-disk`**  
  *Azure Disk provides low-latency, high-throughput, and durable storage ideal for performance-heavy workloads.*

- **Set the `skuName` parameter to `Premium_LRS`**  
  *Premium SSD-backed storage ensures fast writes and high IOPS.*

## Incorrect Answers
- `kubernetes.io/azure-file`  
  *Shared storage with higher latency; not suitable for high-throughput scenarios.*

- `reclaimPolicy: delete`  
  *Deletes storage on PVC deletion, risking data loss.*

- `reclaimPolicy: retain`  
  *Keeps storage after PVC deletion, optional but not required for pod restarts.*

## Overall Explanation
Using **Azure Disk** with **Premium_LRS** provides low-latency, durable storage for pods, ensuring that performance data is quickly written and persists across pod restarts.

🔗 [Microsoft Reference: Use Azure Disks with AKS](https://learn.microsoft.com/en-us/azure/aks/azure-disks-dynamic-pv)

**Summary:**  
Configure AKS pods with `kubernetes.io/azure-disk` and `Premium_LRS` to achieve low-latency, durable storage for performance telemetry.

---

# Question 34

You are developing an application that needs to access an Azure Virtual Machine (VM). The access lifecycle must be associated with the VM itself, not a separate identity.

```powershell
$vm = Get-AzVM -ResourceGroupName "ContosoRG" -Name "ContosoVM"
Update-AzVM -ResourceGroupName "ContosoRG" -VM $vm -AssignIdentity _______ -IdentityId _______
```

## Correct Answers
- **Set `-AssignIdentity` to `SystemAssigned`**  
  *This links the managed identity directly to the VM lifecycle, ensuring it is created and deleted along with the VM.*

- **Leave `-IdentityId` empty**  
  *`-IdentityId` is only required for User Assigned identities and should not be supplied for System Assigned identities.*

## Incorrect Answers
- `UserAssigned`  
  *Creates a separate identity not tied to the VM lifecycle.*

- Provide a valid `-IdentityId`  
  *Only required when assigning a User Assigned identity.*

## Overall Explanation
Using a **System Assigned Managed Identity** ensures the identity lifecycle matches the VM. You only need to set `-AssignIdentity` to `SystemAssigned` and leave `-IdentityId` empty. This allows the VM to securely access other Azure resources without managing a separate identity.

🔗 [Microsoft Reference: Enable system-assigned managed identity on an Azure VM (PowerShell)](https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview)

**Summary:**  
Enable a **System Assigned Managed Identity** on the VM and leave `-IdentityId` empty to tie the identity lifecycle to the VM itself.

---

# Question 35

You are developing a user portal and need to generate a report listing employees who are subject matter experts on a specific topic. The solution must allow administrators to have full control and consent over the data being accessed, including enriched user profile information.

## Correct Answer
- **Microsoft Graph Data Connect**  
  *Designed for accessing large datasets from Microsoft 365 with administrator consent and governance. Ideal for tenant-wide reporting and analytics.*

## Incorrect Answers
- Microsoft Graph connectors  
  *Used to index external data into Microsoft Search, not for accessing internal employee data for reporting.*

- Microsoft Graph API  
  *Good for real-time queries, but does not support bulk export or enterprise-scale analytics with admin consent.*

## Overall Explanation
Microsoft Graph Data Connect enables secure, administrator-consented extraction of Microsoft 365 data for analysis or reporting. It is specifically designed for enterprise-scale data access scenarios, unlike the standard Graph API or connectors.

🔗 [Microsoft Reference: What is Microsoft Graph Data Connect?](https://learn.microsoft.com/en-us/graph/data-connect-concept-overview)

> **Summary:**  
Use **Microsoft Graph Data Connect** to access tenant-wide employee data with admin consent for reporting and analytics.

---

# Question 36

A company is implementing a publish-subscribe (Pub/Sub) messaging component using Azure Service Bus.  
You are developing the first subscription application. Messages are confirmed to be arriving at the topic’s subscription in the Azure portal.  
You initialize the `SubscriptionClient` with the correct connection string, topic name, and subscription name, but your application is not consuming messages.  
You need to ensure that the subscription client begins processing all messages.

## Correct Answer
```csharp
subscriptionClient.RegisterMessageHandler(
    ProcessMessagesAsync, messageHandlerOptions);
```
# Message Handler Registration

*This registers a message handler that actively listens for and processes incoming messages using the* `ProcessMessagesAsync` *callback.*

## Incorrect Answers

* **AddRuleAsync(...)** *Used to add or modify subscription filters, not to start receiving messages.*
* **Creating a new SubscriptionClient** *Only establishes a connection — no messages are processed until a handler is registered.*
* **CloseAsync()** *Shuts down the subscription client, preventing message processing.*

## Overall Explanation

Registering the message handler is required to start pulling messages from the subscription and invoking your message-processing logic. Without this step, the client remains idle and no messages are consumed.

🔗 **Microsoft Reference:** [Receive messages using Azure Service Bus - .NET](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-get-started-with-queues)

> **Summary:** Use `subscriptionClient.RegisterMessageHandler(...)` to start processing messages from the Service Bus subscription.

---

# Question 37

You are developing a medical records document management website.  
The website stores scanned copies of patient intake forms.  
If the forms are downloaded by a third party, their contents must remain protected.  

You are evaluating options for secure storage.  

**Solution:** You store the intake forms as Azure Key Vault secrets.  

## Correct Answer  
❌ **No** – This solution does **not** meet the goal.  

## Overall Explanation  
Azure Key Vault is designed for storing **small, sensitive data** such as:  
- Passwords  
- Connection strings  
- API keys  
- Certificates  
- Cryptographic keys  

It is **not designed or optimized** for storing large binary files or documents (like PDFs).  
Secrets are limited to **25 KB in size**, making it unsuitable for scanned forms.  

### Best Practice
Store the documents in **Azure Blob Storage** and secure them by:  
- Enabling **Azure Storage Service Encryption (SSE)** or using **client-side encryption**  
- Controlling access via **SAS tokens** or **Azure AD RBAC**  

## Why the Solution Fails  
- ❌ Key Vault secrets have a **25 KB size limit**  
- ❌ Not intended for document or file storage  
- ❌ Inefficient and expensive for managing large files  

🔗 [Microsoft Reference: What can you store in Azure Key Vault?](https://learn.microsoft.com/en-us/azure/key-vault/general/about-keys-secrets-certificates)

> **Summary:**  
Azure Key Vault is not for storing large documents — use **Blob Storage with encryption and access control** instead.

--- 

# Question 38

Your company is designing an application named **App1** that will use data from an **Azure SQL Database**.  
App1 will be accessed over the internet by many users.  

You need to recommend a solution that will **improve the performance of App1** by reducing direct database load and speeding up data access.  

## Correct Answer  
✅ **Azure Cache for Redis**

## Overall Explanation  
**Azure Cache for Redis** is ideal when:  
- You want to **reduce latency** and **improve throughput** for read-heavy workloads  
- Your application frequently reads the same data (e.g., lookup tables, reference data)  
- You want to avoid repeated expensive SQL queries by caching results in memory  

Redis stores frequently accessed data in **memory**, which is much faster than querying the database every time.  
This improves **performance**, **scalability**, and **reduces load** on the database.

### ❌ Why the Other Options Are Incorrect  
- **Azure HPC Cache** – Designed for HPC workloads and caching on-premises file data, not for SQL query acceleration.  
- **ExpressRoute** – Provides private connectivity to Azure for hybrid networks, but does not improve database query performance for internet-facing apps.  
- **CDN Profile** – Best for caching static content (images, CSS, videos), not dynamic database results.  

🔗 [Microsoft Reference: Azure Cache for Redis – Improve Application Performance](https://learn.microsoft.com/en-us/azure/azure-cache-for-redis/cache-overview)

> **Summary:**  
Use **Azure Cache for Redis** to cache frequently accessed data, reduce SQL database load, and deliver faster responses for App1.

---

# Question 39

You have a **Standard tier** instance of **Azure Cache for Redis** named `redis1`, using default settings.  

You need to configure a **Maxmemory policy** that increases the amount of cache available for **read operations** (prioritizing read-heavy workloads by minimizing memory reserved for operations like replication and failover).  

## ✅ Correct Answer  
**Decrease the value of `maxmemory-reserved`**

## Overall Explanation  
In Azure Cache for Redis:  

- **`maxmemory-reserved`** specifies how much memory is reserved for internal operations like **replication**, **failover**, and **clustering** overhead.  
- If you **decrease** `maxmemory-reserved`, more memory becomes available for **user data (keys and values)**.  
- This is ideal for **read-heavy workloads**, where maximizing cache capacity improves hit ratio and performance.

### ❌ Why the Other Options Are Incorrect
- **Increase the value of `maxmemory-reserved`**  
  This would **reduce memory available for caching**, which is the opposite of what you need.  

- **Set the Maxmemory policy to `noeviction`**  
  This only prevents eviction of keys when memory is full (causing errors instead).  
  It doesn’t increase cache capacity for reads.  

- **Set the Maxmemory policy to `volatile-lru`**  
  This defines which keys to evict when memory is full (least recently used among those with TTL), but doesn’t change how much memory is available for caching.

🔗 [Microsoft Reference: Azure Cache for Redis – Performance Best Practices](https://learn.microsoft.com/en-us/azure/azure-cache-for-redis/cache-best-practices)

> **Summary:**  
For read-heavy workloads, **decrease `maxmemory-reserved`** so more memory is available for storing cached data, improving performance.

---

# Question 40

You are developing a solution that uses a **multi-partitioned Azure Cosmos DB container** and the latest Azure Cosmos DB SDK.  

The solution must meet the following requirements:  
- Send insert and update operations to **Azure Blob Storage**  
- **Immediately process** changes across all partitions  
- Allow **parallel change processing**  

## ✅ Correct Answers  
1. **Create an Azure App Service API and implement the change feed estimator of the SDK. Scale the API using multiple Azure App Service instances.**  
2. **Create a background job in Azure Kubernetes Service (AKS) and implement the change feed feature of the SDK.**

## Overall Explanation  
Both solutions leverage the **Cosmos DB change feed processor** from the SDK, which is designed for **parallel processing** of changes across multiple partitions.  

- **App Service + Change Feed Estimator**  
  - The change feed estimator monitors remaining work and helps scale out App Service instances automatically.
  - Allows immediate, scalable, and parallel change processing.

- **AKS + Change Feed SDK**  
  - You can run multiple replicas of your worker pods.
  - Excellent for long-running workloads that must scale horizontally and maintain state.
  - Provides full control over parallelization across partitions.

### ❌ Why the Other Options Are Incorrect
- **Azure Function with Cosmos DB Trigger**  
  - Convenient for simple scenarios but limited in control over parallelization across multiple partitions.
  - May introduce latency for high-throughput workloads.

- **Azure Function with FeedIterator and FeedRange**  
  - Technically works but not ideal for stateless Azure Functions due to lifecycle and coordination complexity.
  - Best practice is to use stateful, continuously running services like App Services or AKS for the pull model.

🔗 [Microsoft Reference: Change Feed in Azure Cosmos DB](https://learn.microsoft.com/en-us/azure/cosmos-db/change-feed)

> **Summary:**  
Use **App Service with the change feed estimator** or **AKS with the change feed processor** to enable **parallel, immediate processing across all partitions** while storing changes to Blob Storage.

---

# Question 41

You have developed and deployed a **web application** to **Azure App Service**, and it accesses data in an **Azure Storage account**.  
The account contains several containers and blobs with large amounts of data.  

All resources are currently deployed in a single Azure region, but you need to **move the entire storage account to a new region** and **copy all the data**.

## ✅ Correct Answer  
**Configure object replication for all blobs**

## Overall Explanation  
The **first step** in migrating a storage account to a new region is to **configure object replication** between the source storage account (current region) and the destination storage account (new region).  

- **Object Replication Benefits:**
  - Asynchronous replication of blobs at the container level.
  - Ideal for **large data sets** with minimal downtime.
  - Ensures data is **kept in sync** until the cutover.
  - Allows you to later point your application to the destination account seamlessly.

Once replication is complete, you can update the app’s configuration to use the new storage account and decommission the old one.

### ❌ Why the Other Options Are Incorrect
- **Export the ARM template**  
  - Only recreates the *infrastructure* configuration, not the *data*.

- **Initiate a storage account failover**  
  - Only works for RA-GRS accounts and is intended for disaster recovery, not planned region migration.

- **Use AzCopy**  
  - Good for manual copy jobs, but not the first step for large-scale, production migration — object replication is more efficient and automated.

- **Create a new storage account in the current region**  
  - Does not help since the requirement is to move to a *different* region.

- **Create a new subscription**  
  - Subscription scope is unrelated to region migration.

🔗 [Microsoft Reference: Configure object replication in Azure Blob Storage](https://learn.microsoft.com/en-us/azure/storage/blobs/object-replication-overview)

> **Summary:**  
Start by **configuring object replication** to a destination storage account in the target region — this ensures a smooth, asynchronous, and low-downtime data migration.

---

# Question 42

You are developing multiple **microservices** hosted in **Azure Container Apps** with **HTTP ingress enabled**.

## Requirements:
- Maintain a **single URL** for the updated microservice (used by testers)
- Ensure the system **only uses the currently deployed version** (no traffic splitting)

## ✅ Correct Answers  
- **Revision label** to maintain a single URL for test users  
- **Revision mode** to activate the current microservice only  

## Overall Explanation  
These two features work together to meet the requirements:  

- **Revision label** – ✅  
  Allows you to create a **static, user-friendly URL** that always points to a specific revision (e.g., `test.myapp.azurecontainerapps.io`).  
  This ensures testers always hit the intended version, even after redeployments.

- **Revision mode (Single)** – ✅  
  Configures the Container App to keep **only one active revision at a time**.  
  This guarantees that **all traffic routes exclusively to the current revision** (no splitting between versions).

### ❌ Why the Other Options Are Incorrect
- **Container registry**  
  - Stores container images, but has no control over revision selection or URL routing.

- **Container image**  
  - Defines the microservice’s code/image, but does not manage revisioning, labels, or traffic distribution.

🔗 [Microsoft Reference: Azure Container Apps revisions and traffic splitting](https://learn.microsoft.com/en-us/azure/container-apps/revisions)

> **Summary:**  
Use **revision labels** to give testers a consistent URL and set **revision mode to single** to ensure traffic only routes to the active microservice version.

---

# Question 43

You deploy an API to **Azure API Management**.

## Requirement:
Secure all operations on the API by **using a client certificate** and ensure the backend service **only accepts calls with a valid certificate**.

## ✅ Correct Answers  
- **Self-signed certificate**  
- **Certificate Authority (CA) certificate**  

## Overall Explanation  
These two options meet the requirement for securing backend access with certificates:

- **Self-signed certificate** – ✅  
  Can be used in API Management to secure backend communication, typically for **internal testing** or dev environments.  
  While functional, it's not the recommended approach for production due to trust and management challenges.

- **CA certificate** – ✅  
  Best practice for production. Ensures **proper certificate chain validation**, and that only trusted clients (API Management) can call the backend.

### ❌ Why the Other Options Are Incorrect
- **Azure AD token**  
  Used for user or app authentication (OAuth 2.0/JWT) but not for client certificate mutual TLS authentication.

- **Triple DES (3DES) cipher**  
  An encryption algorithm — not a method for authenticating API Management to the backend.

- **Subscription key**  
  Secures **incoming requests from API consumers**, not the **outbound call from API Management** to the backend.

🔗 [Microsoft Reference: Secure back-end services using client certificate authentication in Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/api-management-howto-mutual-certificates)

> **Summary:**  
Use a **self-signed certificate** for internal/testing scenarios or a **CA-issued certificate** for production to enforce client-certificate authentication between API Management and the backend service.

---

# Question 44  

You are developing a software solution for an **autonomous transportation system** that uses **Azure Batch** to simulate navigation across entire vehicle fleets.

## Requirement:
Create **compute nodes** (pools of virtual machines) that will perform the simulations.

## ✅ Correct Answer  
- **In the Azure portal, create a Batch account**

## Overall Explanation  
Before you can create **compute nodes (pools)** or schedule any jobs, you must first create an **Azure Batch account**.  
The Batch account acts as the control plane and is responsible for:

- Managing **pools** of compute nodes  
- Scheduling and running **jobs**  
- Handling **tasks** within jobs  

Without a Batch account, you cannot provision compute nodes or submit work.

### ❌ Why the Other Options Are Incorrect
- **TaskAddParameter**  
  Defines an individual task within a job — does not create compute nodes or pools.  

- **JobAddParameter**  
  Defines a job that runs on an existing pool — but you must have a pool first.  

- **BatchClient.PoolOperations.CreateJob**  
  This is not a valid method for creating compute nodes. The correct method would be `BatchClient.PoolOperations.CreatePool()`.

🔗 [Microsoft Reference: Create and manage an Azure Batch account](https://learn.microsoft.com/en-us/azure/batch/batch-account-create-portal)

> **Summary:**  
✅ **First step is to create a Batch account in Azure Portal** — only then can you programmatically create pools (compute nodes) and schedule jobs/tasks.

---

# Question 45  

You are developing an application hosted on an **on-premises virtual machine (VM)** that stores and retrieves data in **Azure Blob Storage** over a Site-to-Site VPN.  

## Requirements:
- Access must be secured using **Azure AD credentials**
- Must support **start time, expiry time, and read permissions**
- Must be **revocable** if the application is compromised  

## ✅ Correct Answers  
- **Shared Access Signature (SAS) token**  
- **Stored Access Policy on the Azure Storage account**  

## Overall Explanation  
### ✅ Shared Access Signature (SAS) Token  
- Provides **time-bound**, **permission-scoped** access (read, write, etc.)  
- Allows you to specify **start and expiry times**  
- Avoids exposing the storage account key  
- Can be revoked if linked to a stored access policy  

### ✅ Stored Access Policy  
- Defined at the container or storage account level  
- When associated with SAS, allows **centralized revocation** by modifying or deleting the policy  
- Recommended for secure, managed SAS token usage  

---

### ❌ Why the Other Options Are Incorrect
- **System-assigned Managed Identity**  
  - Only works for **Azure-hosted resources** (VMs, App Services, etc.), not on-premises applications.  

- **Storage Account Access Key**  
  - Grants **full control** of the storage account  
  - Cannot be scoped to read-only, not time-limited, and revocation requires key rotation (disruptive).  

🔗 [Microsoft Reference: Grant limited access to Azure Storage using SAS](https://learn.microsoft.com/en-us/azure/storage/common/storage-sas-overview)

> **Summary:**  
✅ Use a **SAS token with a stored access policy** to provide time-limited, revocable, read-only access to Blob Storage from your on-prem app.

---

# Question 46  

You are developing an **Azure Functions app** with an **Azure Blob Storage trigger**.  

## Requirements:
- Triggered **infrequently**  
- Needs **event-driven scaling**  
- Must support **deployment slots**  
- Must **minimize costs**  

## ✅ Correct Configuration
- **Hosting plan:** Premium  
- **Maximum execution time:** Unlimited  

## Overall Explanation  

### ✅ Hosting plan: Premium
- Supports **deployment slots**, unlike the Consumption plan  
- Allows **event-driven scaling**  
- Offers cost control through **per-second billing**  
- Ideal for apps requiring features not available in the Consumption plan  

### ✅ Maximum execution time: Unlimited
- Premium plan allows **unlimited execution duration**  
- Ensures functions **won’t be cut off** for long-running blob processing tasks  

---

### ❌ Incorrect Options
- **Hosting plan: Consumption**  
  - Pros: Minimizes cost, supports event-driven scale  
  - Cons: **Does not support deployment slots** (requirement not met)  

- **Maximum execution time: 230 seconds**  
  - Only applies to Consumption plan (default 5 minutes)  
  - Unnecessary in Premium, which supports unlimited duration  

🔗 [Microsoft Reference: Azure Functions hosting options](https://learn.microsoft.com/en-us/azure/azure-functions/functions-scale)  
🔗 [Microsoft Reference: Function app deployment slots](https://learn.microsoft.com/en-us/azure/azure-functions/functions-deployment-slots)

> **Summary:**  
✅ Use a **Premium hosting plan** with **unlimited execution time** to support deployment slots, event-driven scaling, and long-running blob-triggered functions.

---

# Question 47  

You are creating a **Docker image** that runs an ASP.NET Core application (`ContosoApp.dll`).  

## Requirements:
- Run a **PowerShell setup script** (`setupScript.ps1`) during **image build**  
- Start the container by running `ContosoApp.dll`  
- Dockerfile is in the **same folder** as `ContosoApp.dll` and `setupScript.ps1`  

## ✅ Correct Dockerfile Commands
- `FROM microsoft/aspnetcore:latest` – Sets the **base image** for the container  
- `WORKDIR /apps/ContosoApp` – Defines the **working directory** inside the container  
- `COPY ./ .` – Copies **all project files** into the container  
- `RUN powershell ./setupScript.ps1` – Runs the **setup script during build**  
- `CMD ["dotnet", "ContosoApp.dll"]` – Starts the **application** when the container runs  

---

### ❌ Incorrect Command
- `ENTRYPOINT ["powershell", "./setupScript.ps1"]`  
  - Runs the setup script at **container startup**, not during build  
  - Prevents the app from running as the main process  

🔗 [Microsoft Reference: Dockerfile best practices](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-tutorial-prepare-app)  

> **Summary:**  
✅ Use `FROM`, `WORKDIR`, `COPY`, `RUN`, and `CMD` to build the image, run the setup script at build time, and start `ContosoApp.dll` when the container launches.

---

# Question 48  

You develop and deploy an **Azure App Service web app** that connects to **Azure Cache for Redis**.  

## Security Requirements:
- Track the number of Redis client connections per IP address  
- Log all Redis operations performed  
- Record the region where the Redis instance was accessed  
- Send logs to a centralized security team application in Central US  

## ✅ Correct Configuration
- **Log Analytics workspace** – Centralized storage and querying of Redis metrics and logs  
- **Diagnostic setting** – Enables logging for Redis metrics and operations and routes logs to Log Analytics  

---

### ❌ Incorrect Options
- **Blob Storage account and App registration**  
  - Blob storage can archive logs but does not support analytics  
  - App registration is for identity, not logging  

- **Event Hub and Environment variable**  
  - Event Hub streams telemetry but lacks built-in querying/analytics  
  - Environment variable does not configure logging  

🔗 [Microsoft Reference: Monitor Azure Cache for Redis](https://learn.microsoft.com/en-us/azure/azure-cache-for-redis/cache-monitor-log)

> **Summary:**  
✅ Use **Log Analytics workspace** with **Diagnostic settings** to log Redis client connections, operations, region data, and route them for centralized security analysis.

---

# Question 49  

You are deploying a **microservices solution on Azure Kubernetes Service (AKS)**.  

## Requirements:
- Reverse proxying  
- Configurable traffic routing  
- TLS termination with a custom certificate  

## ✅ Correct Kubernetes Components
- **Ingress Controller** – Handles reverse proxy, TLS termination, and routing to multiple services; provides a single public IP endpoint for traffic management.  
- **Helm** – Kubernetes package manager that simplifies deployment and management of complex applications like Ingress Controllers using reusable templates.  

---

### ❌ Incorrect Options
- **CoreDNS** – Provides internal DNS resolution only; does not manage routing or TLS termination.  
- **Virtual Kubelet** – Extends AKS with serverless nodes; unrelated to routing or certificates.  
- **Draft** – Helps package and deploy apps during development; not needed for traffic routing or TLS termination.  

🔗 [Microsoft Reference: Use Ingress in AKS](https://learn.microsoft.com/en-us/azure/aks/ingress-basic)  
🔗 [Helm Overview](https://helm.sh/docs/)

> **Summary:**  
✅ Use **Ingress Controller** for routing, TLS termination, and reverse proxying, and **Helm** to deploy and manage the AKS solution efficiently.

---

# Question 50  

You are developing an application that helps users find musicians who are looking for work.  

## Requirements:
- Store information about musicians, instruments, and related data  
- Determine which musicians have played together, including groups of three or more at a specific location  

## ✅ Correct Azure Cosmos DB API
- **Gremlin** – Ideal for graph-based data modeling. Allows modeling nodes (musicians, instruments) and edges (relationships like "played with" or "performed at"). Enables complex relationship queries, such as groups of musicians performing together.  

---

### ❌ Incorrect Options
- **Core (SQL)** – Optimized for document storage; not ideal for relationship traversal.  
- **MongoDB** – Document-based; does not support graph traversal for relationship-heavy queries.  
- **Cassandra** – Wide-column store; unsuitable for complex entity relationships.  

🔗 [Microsoft Reference: Azure Cosmos DB Gremlin API (Graph database)](https://learn.microsoft.com/en-us/azure/cosmos-db/graph/introduction)  

> **Summary:**  
✅ Use **Gremlin API** in Azure Cosmos DB to model musicians and their relationships, enabling complex queries like who has played together at specific locations.

---

# Question 51  

You have deployed several APIs to Azure API Management and created a reusable policy fragment `APICounts` that emits custom metrics:  

```xml
<emit-metric value="1" namespace="custom-metrics">
```
 API Management Policy Fragment

The fragment must execute **every time an API is invoked**.

## ✅ Correct XML Elements to Complete the Policy

* `<include-fragment>` – Includes the reusable policy fragment into the API Management policy.
* `<inbound>` – Executes the fragment during the request flow, ensuring metrics are tracked on each API call.

❌ Incorrect Options

* <fragment-id> – Invalid; the correct element is <include-fragment name="...">.

* <outbound> – Executes after the backend response; too late for tracking inbound API calls.

🧠 Example Completed Policy

```xml
<policies>
  <inbound>
    <include-fragment name="APICounts" />
  </inbound>
  <base />
</policies>
```
🔗 Microsoft Reference: Use policy fragments in Azure API Management

> Summary:
✅ Use <include-fragment> inside <inbound> to ensure the APICounts policy executes on every API request.

---

# Question 52  

You plan to migrate containers with the following OS types to an Azure Kubernetes Service (AKS) cluster:

- Windows Server 2019 Nano Server  
- Windows Server 2019 Server Core  
- Windows Server 2022 Nano Server  
- Windows Server 2022 Server Core  
- Linux  

## ✅ Correct Answer
**3 node pools**  

### Explanation
AKS requires separate node pools based on **OS type and Windows version**:

1. **Linux containers** → Linux node pool  
2. **Windows Server 2019 containers** (Nano + Server Core) → Windows Server 2019 node pool  
3. **Windows Server 2022 containers** (Nano + Server Core) → Windows Server 2022 node pool  

> Nano vs Server Core does **not** require separate pools if the Windows version is the same.

### ❌ Incorrect Options
- **1** – Cannot run both Linux and Windows containers in the same pool.  
- **2** – Would not account for two different Windows versions.  
- **6** – Unnecessary; Nano vs Server Core does not require separate pools.

🔗 [Microsoft Reference: Windows Server node support in AKS](https://learn.microsoft.com/en-us/azure/aks/windows-node-support)

> **Summary:**  
✅ Minimum **3 node pools** are required: one Linux, one Windows 2019, and one Windows 2022.

---
# Question 53  

You are using **Azure Front Door** and expect inbound XML files (9 MB) to be compressed using **Brotli**, but they are not being compressed.  

## ✅ Correct Answer
**Yes** – XML MIME types are supported for compression by Azure Front Door.

### Explanation
- Azure Front Door supports **Brotli and Gzip compression** for a variety of MIME types, including:
  - `text/plain`  
  - `text/html`  
  - `application/json`  
  - **`application/xml`** and `text/xml`  
- If XML files are not being compressed, it may be due to:
  - File size exceeding the compression limit (Front Door supports up to 10 MB per object)  
  - Compression not enabled in the Front Door configuration  
  - Browser or client not sending `Accept-Encoding` headers  

> By default, XML files are compressible, so Azure Front Door **does support Brotli compression for XML**.

🔗 [Microsoft Reference: Azure Front Door compression](https://learn.microsoft.com/en-us/azure/frontdoor/front-door-compression)

> **Summary:**  
✅ XML files (application/xml or text/xml) **are supported** for Brotli compression by Azure Front Door.

---

# Question 54  

You're troubleshooting **Azure Front Door** because XML files are not being compressed.  

## ✅ Correct Answer
**No** – You do **not** need to purge edge nodes of cached content for compression to start working.

### Explanation
- **Brotli and Gzip compression** in Azure Front Door is applied **dynamically** based on:
  - File **size**
  - File **MIME type**
- Purging cached content **does not affect compression**.  
- Ensure that:
  - Compression is **enabled** in Front Door
  - XML MIME type is supported (`application/xml` or `text/xml`)  
  - Client requests include `Accept-Encoding` headers  

🔗 [Microsoft Reference: Azure Front Door compression](https://learn.microsoft.com/en-us/azure/frontdoor/front-door-compression)

> **Summary:**  
✅ Compression is handled dynamically; **purging the cache is not required**.

---

Question 55:
You're using Brotli compression with Azure Front Door.

Is Brotli a supported compression type in Azure Front Door?


Overall explanation
✅ Correct Answer:  Yes



Explanation: Azure Front Door supports both Brotli and Gzip compression for eligible file types under 1 MB.
---


# Question 56  

You develop an HTTP-triggered Azure Function app that processes Azure Storage blob data. The function is configured with an output binding to the blob.  

The function times out after four minutes, and you must ensure it completes processing the blob data without timing out.  

## ✅ Correct Answer
**Yes** – Using the Durable Functions async pattern meets the goal.

### Explanation
- **Durable Functions** allow long-running, stateful workflows beyond the default timeout limits (5 minutes for HTTP triggers on the Consumption Plan).
- They **orchestrate activities** into resumable steps, ensuring:
  - Reliability
  - Resilience
  - Completion of tasks even if the function restarts
- Ideal for **processing large blobs** or other long-running operations without timing out.

🔗 [Microsoft Reference: Durable Functions Overview](https://learn.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview)

**Summary:**  
> ✅ Using the **Durable Functions async pattern** ensures the blob processing completes reliably without hitting timeout limits.

---

# Question 57  

You are implementing an Azure Function to retrieve delivery driver profile information from your organization’s directory.  

## ✅ Correct Answer
**Code library:** Microsoft Authentication Library (MSAL)  
**API:** Microsoft Graph  

### Explanation
- **Microsoft Graph** is the recommended API for accessing user profile data (e.g., names, contact info, job titles), which is required for delivery driver profiles.
- **MSAL** is used to acquire tokens for secure authentication with Microsoft Graph.
- **Incorrect Options:**
  - **Azure Key Vault SDK/API** – Used for secrets and certificates, not user profiles.
  - **Azure Active Directory Graph / Azure Identity library** – Deprecated or designed for different authentication scenarios; MSAL + Microsoft Graph is preferred.

🔗 [Microsoft Graph documentation: Access user profiles](https://learn.microsoft.com/en-us/graph/overview)  
🔗 [MSAL documentation](https://learn.microsoft.com/en-us/azure/active-directory/develop/msal-overview)

> **Summary:**  
✅ Use **MSAL** with **Microsoft Graph** to securely retrieve delivery driver profile information.

---
# Question 58  

You are designing an Azure solution to process inventory data from stores around the world. Inventory files are saved hourly to Azure Blob Storage and must be processed based on the following requirements:

- Begin processing when new files are saved  
- Filter data by store location  
- Trigger an Azure Logic App to process and output to Cosmos DB  
- Support high availability, retry logic, and exponential back-off  

## ✅ Correct Answer
- **Event Source:** Azure Blob Storage  
- **Event Receiver:** Azure Event Grid  
- **Event Handler:** Azure Logic App  

### Explanation
- **Azure Blob Storage (Event Source):** Generates events when new files are uploaded.  
- **Azure Event Grid (Event Receiver):** Listens to Blob Storage events and routes them to other services. Supports filtering, high availability, and retry logic with exponential backoff.  
- **Azure Logic App (Event Handler):** Processes the events and integrates with Cosmos DB, triggered via Event Grid.  

❌ **Why Other Options Are Incorrect:**
- Service Bus + App Service is not suitable for blob-triggered workflows.  
- Event Hub cannot handle blob events directly and lacks filtering capabilities like Event Grid.  

🔗 [Azure Event Grid Overview](https://learn.microsoft.com/en-us/azure/event-grid/overview)  
🔗 [Event Grid triggers for Blob Storage](https://learn.microsoft.com/en-us/azure/logic-apps/logic-apps-using-event-grid-trigger)  

> **Summary:**  
✅ Use **Blob Storage → Event Grid → Logic App** for reliable, filtered, and event-driven blob processing.

---
# Question 59  

You are developing an ASP.NET Core Web API that uses Azure Application Insights for telemetry and dependency tracking. Your service reads and writes data to a third-party database (not Microsoft SQL Server). You need to ensure dependency telemetry is correctly correlated and tracked for these external database calls.

## ✅ Correct Answer
- **Telemetry.Context.Operation.Id**  
- **Telemetry.Id**  

### Explanation
- **Telemetry.Context.Operation.Id:**  
  Identifies the overall operation (e.g., HTTP request or job execution). Helps Application Insights correlate multiple telemetry events (request, trace, dependency) that are part of the same operation.  

- **Telemetry.Id:**  
  The unique ID for the specific telemetry event (e.g., a dependency call). Allows child telemetry (exceptions, logs) to be correlated back to the exact dependency call that triggered them.  

❌ **Why Other Options Are Incorrect:**  
- **Telemetry.Context.Cloud.RoleInstance:** Useful for identifying the machine or instance, but not for correlation.  
- **Telemetry.Context.Session.Id:** Tracks user sessions, not dependency correlation.  
- **Telemetry.Name:** Provides a friendly name for the telemetry, but doesn’t help with linking or correlation.  

🔗 [Telemetry correlation in Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/correlation)  

**Summary:**  
> ✅ Store **Telemetry.Context.Operation.Id** and **Telemetry.Id** in the database to enable proper correlation of external dependency calls.

---
# Question 60  

Your company is developing an Azure-hosted API. You need to implement authentication for the API with the following requirements:

- All API calls must be secure  
- Callers must not send credentials to the API  

## ✅ Correct Answer
- **Managed identity**  

### Explanation
- **Managed Identity:**  
  Allows secure authentication between Azure services **without sending credentials**. Azure automatically manages credentials internally, eliminating the need for users or services to pass secrets or passwords. This ensures secure, seamless, and passwordless authentication.  

❌ **Why Other Options Are Incorrect:**  
- **Basic:** Requires sending a username and password with each request — violates the no-credentials requirement.  
- **Anonymous:** Provides no authentication — violates the requirement that all calls must be secure.  
- **Client certificate:** Requires sending certificates with requests, which goes against the requirement that callers should not send credentials.  

🔗 [Managed identities for Azure resources](https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview)  

> **Summary:**  
✅ Use **Managed Identity** to secure API calls without requiring callers to send credentials.
