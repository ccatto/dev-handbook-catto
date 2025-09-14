# 10. Develop message-based solutions

> Discover Azure message queues

Learn how to integrate Azure Service Bus and Azure Queue Storage into your solution, and how to send and receive messages by using .NET.  

## Units  
- Introduction  
- Choose a message queue solution  
- Explore Azure Service Bus  
- Discover Service Bus queues, topics, and subscriptions  
- Explore Service Bus message payloads and serialization  
- Exercise - Send and receive messages from Azure Service Bus  
- Explore Azure Queue Storage  
- Create and manage Azure Queue Storage and messages by using .NET  
- Exercise - Send and receive messages from Azure Queue Storage  
- Module assessment  
- Summary  

---

> 10.1.1 📦 Introduction to Azure Queues

Azure provides two types of queue mechanisms:  

- **Service Bus Queues** – Part of Azure’s messaging infrastructure, supporting queuing, pub/sub, and advanced integration patterns across multiple protocols, domains, or environments.  
- **Storage Queues** – Part of Azure Storage, designed for large-scale message storage (millions of messages) with global access via authenticated HTTP/HTTPS requests.  

Queues are commonly used for asynchronous work processing and workload backlogs.  

### ✅ After completing this module, you’ll be able to:
- Choose the appropriate queue mechanism for your solution.  
- Explain Service Bus messaging entities and their capabilities.  
- Send and receive messages from a Service Bus queue using .NET.  
- Identify Azure Queue Storage components.  
- Create queues and manage messages in Azure Queue Storage using .NET.  

---

> 10.1.2 📌 Choosing a Message Queue Solution

- **Service Bus Queues** → Best for advanced messaging scenarios like guaranteed FIFO delivery, duplicate detection, sessions for stream-like processing, transactions, larger message sizes, and role-based access.  
- **Storage Queues** → Best for very large-scale storage (80+ GB), tracking message processing progress across workers, and requiring server-side transaction logs.  

---

> 10.1.3 🚀 Explore Azure Service Bus

Azure Service Bus is a fully managed enterprise message broker with **queues** and **topics** that decouple apps and services. Messages can carry JSON, XML, Avro, or plain text, enabling reliable, scalable communication.  

### 🔑 Use Cases
- **Messaging**: Transfer business data (orders, inventory, etc.).  
- **Decoupling**: Improve reliability; sender and receiver don’t need to be online simultaneously.  
- **Topics & subscriptions**: Enable 1-to-many messaging.  
- **Message sessions**: Ensure ordered or deferred workflows.  

### 💡 Service Bus Tiers
- **Premium**: High throughput, predictable performance, up to 100 MB messages, fixed pricing.  
- **Standard**: Variable throughput/latency, 256 KB message limit, pay-as-you-go.  

### ⚙️ Advanced Features
- **FIFO sessions**  
- **Autoforwarding** between queues/topics  
- **Dead-letter queue** for undeliverable messages  
- **Scheduled delivery & deferral**  
- **Transactions** for atomic operations  
- **Filtering & actions** for subscriptions  
- **Auto-delete on idle**  
- **Duplicate detection**  
- **Security**: SAS, RBAC, managed identities  
- **Geo-disaster recovery**  

### 🌐 Protocols & Clients
- Uses **AMQP 1.0** (ISO/IEC standard) + HTTP/REST.  
- Supports **JMS 2.0 API** (Premium).  
- SDKs for **.NET, Java, Python, JavaScript/TypeScript**.  

> Azure Service Bus is a fully managed enterprise message broker that provides reliable messaging with queues, topics, and advanced features like sessions, dead-lettering, scheduling, and duplicate detection to decouple and scale applications.

---

> 10.1.4 Service Bus Queues, Topics, and Subscriptions

- **Queues**: FIFO, one-to-one messaging with load-leveling and loose coupling.  
- **Receive Modes**:  
  - *Receive and Delete*: Simple, may lose messages on failure.  
  - *Peek Lock*: Reliable, supports retries.  
- **Topics & Subscriptions**: One-to-many publish/subscribe model; subscribers receive copies of messages.  
- **Rules & Actions**: Filters and modifies messages to support custom routing and processing.


> Service Bus provides queues for FIFO, one-to-one messaging, and topics with subscriptions for one-to-many publish/subscribe communication, with support for filters, rules, and actions to route or modify messages. It offers two receive modes—Receive and Delete and Peek Lock—to balance simplicity with reliability in message processing.

---

> 10.1.5 Service Bus Message Payloads and Serialization

- **Message Structure**: Payload (binary block) + system-defined broker properties + user-defined properties.  
- **Routing & Correlation**: Uses properties like `ReplyTo`, `MessageId`, `CorrelationId`, and `SessionId` for request/reply, multicast, and multiplexing patterns.  
- **Serialization**: Payload stored as opaque binary; `ContentType` describes format (e.g., JSON). AMQP and .NET clients provide object serialization, though explicit serialization is recommended for compatibility.  

**Summary**: Service Bus messages carry binary payloads with metadata for routing, while serialization and content type ensure compatibility across clients.  

---

> 10.1.6 Exercise - Send and Receive Messages from Azure Service Bus ✅

In this exercise, you:  
- Create and configure Azure Service Bus resources  
- Build a .NET app using the `Azure.Messaging.ServiceBus` SDK  
- Provision a Service Bus namespace and queue  
- Assign permissions  
- Send and receive messages programmatically  

### Tasks
- Create Azure Service Bus resources  
- Assign a role to your Microsoft Entra user  
- Create a .NET console app to send and receive messages  
- Clean up resources  

[Send and receive messages from Azure Service Bus](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-events-messages/03-service-bus-send-receive.html)

---

10.1.7 ## Explore Azure Queue Storage ✅

Azure Queue Storage is a service for storing large numbers of messages, accessible worldwide via authenticated HTTP/HTTPS calls.  
- Messages can be up to **64 KB** in size  
- A queue can hold **millions of messages** (limited by the storage account capacity)  
- Commonly used for **asynchronous processing backlogs**  

### Components
- **Storage Account** – entry point for all access to Azure Storage  
- **Queue** – contains sets of messages; names must be lowercase  
- **Message** – up to 64 KB; TTL defaults to 7 days, configurable beyond that in later versions  
- **URL Format** – `https://<storageaccount>.queue.core.windows.net/<queue>`  

### Summary
Azure Queue Storage provides a scalable, reliable way to queue messages for asynchronous, distributed workloads.  

---

> 10.8 ## Create and Manage Azure Queue Storage with .NET ✅

This unit shows how to work with Azure Queue Storage using .NET and the **Azure.Storage.Queues** SDK.  

### Key Packages
- `Azure.Core` – shared primitives and abstractions  
- `Azure.Storage.Common` – shared infrastructure for storage libraries  
- `Azure.Storage.Queues` – main client library for Queue Storage  
- `System.Configuration.ConfigurationManager` – access configuration files  

### Common Operations
- **Create Queue Client** → `new QueueClient(connectionString, queueName)` ‼️ 
- **Create Queue** → `queueClient.CreateIfNotExists()`  
- **Insert Message** → `queueClient.SendMessage(message)`  
- **Peek Message** → `queueClient.PeekMessages()`  
- **Update Message** → `queueClient.UpdateMessage(messageId, popReceipt, "new content", timeout)`  
- **Dequeue Message** → `ReceiveMessages()` + `DeleteMessage()` (two-step to ensure reliability)  
- **Get Queue Length** → `queueClient.GetProperties().ApproximateMessagesCount`  
- **Delete Queue** → `queueClient.Delete()`  

### Summary
With the .NET SDK, developers can easily create, send, update, peek, and delete messages in Azure Queue Storage while ensuring reliability and scalability.  

---

> 10.9 📝 Exercise - Send and Receive Messages from Azure Queue Storage  

**Completed**  
100 XP · 30 minutes  

In this exercise, you create and configure **Azure Queue Storage** resources, then build a .NET app to send and receive messages using the **Azure.Storage.Queues** SDK. You’ll provision storage resources, manage queue messages, and clean up your environment when finished.  

### ✅ Tasks Performed
- Create Azure Queue Storage resources  
- Assign a role to your Microsoft Entra user  
- Create a .NET console app to send and receive messages  
- Clean up resources  

[Send and receive messages from Azure Queue storage](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-events-messages/04-queue-storage-send-receive.html)

---

> 10.10 📋 Quiz: Azure Messaging  

1. **What is a key consideration when choosing to use Service Bus queues over Storage queues?**  
   - ✅ Your solution requires the queue to provide a guaranteed first-in-first-out (FIFO) ordered delivery.  
   - Your application must store over 80 gigabytes of messages in a queue.  
   - You require server side logs of all of the transactions executed against your queues.  

2. **What is the main difference between Service Bus queues and topics with subscriptions?**  
   - ✅ Queues allow processing of a message by a single consumer, while topics with subscriptions provide a one-to-many form of communication.  
   - Queues allow processing of a message by multiple consumers, while topics with subscriptions provide a one-to-one form of communication.  
   - Topics with subscriptions allow processing of a message by a single consumer, while queues provide a one-to-many form of communication.  

3. **What is the role of the `ContentType` property in Service Bus message payloads?**  
   - It encrypts the payload for secure transmission.  
   - It determines the size of the payload.  
   - ✅ It enables applications to describe the payload, with the suggested format for the property values being a MIME content-type description.  

4. **What is the purpose of the `QueueClient` class in Azure Queue Storage when using .NET?**  
   - It manages the configuration files for client applications.  
   - ✅ It retrieves and manipulates queues stored in Azure Queue Storage.  
   - It creates and manage messages within a specific queue.  

> 10.11 📌 Module Summary  

In this module, you learned how to:  
- Choose the right queue mechanism (Service Bus vs. Storage queues).  
- Understand Service Bus messaging entities (queues, topics, subscriptions).  
- Send and receive messages from a Service Bus queue using .NET.  
- Identify key components of Azure Queue Storage.  
- Create and manage Azure Queue Storage queues and messages using .NET.  

---

