
# Explore Azure Event Hubs  

> ⚡ Azure Event Hubs: Capture, secure, and scale event streaming with simple client operations.  

Learn how Azure Event Hubs captures events and how to scale your processing application.  

## Units  
- Introduction  
- Discover Azure Event Hubs  
- Explore Event Hubs Capture  
- Scale your processing application  
- Control access to events  
- Perform common operations with the Event Hubs client library  
- Exercise - Send and retrieve events from Azure Event Hubs  
- Module assessment  
- Summary  

---

> 9.2.1 📘 Introduction  

Azure Event Hubs is a **big data streaming platform and event ingestion service** capable of receiving and processing millions of events per second. Data sent to an event hub can be transformed and stored by using real-time analytics providers or batching/storage adapters.  

### 🎯 Learning Outcomes
After completing this module, you'll be able to:  
- Describe the benefits of using Event Hubs and how it captures streaming data.  
- Explain how to process events.  
- Perform common operations with the Event Hubs client library.  
- Send and retrieve events from Azure Event Hubs.  

---

> 9.2.2 🚀 Discover Azure Event Hubs  

Azure Event Hubs is a **cloud-native data streaming service** that can stream millions of events per second with low latency. It’s compatible with **Apache Kafka**, allowing you to run Kafka workloads on Azure without code changes.  

Event Hubs enables you to **ingest, buffer, store, and process streams in real time** for actionable insights. It uses a **partitioned consumer model** for scalable concurrent processing and integrates with **Azure Functions** for serverless event-driven architectures.  

### 🔑 Key Capabilities
- **Kafka compatibility** – Bring Kafka workloads without managing clusters.  
- **Schema Registry** – Centralized schema management for Event Hubs and Kafka apps.  
- **Real-time processing** – Integrates with Azure Stream Analytics (no-code editor or SQL-based queries).  

### 📌 Core Concepts
- **Producer apps** – Send events via SDKs or Kafka clients.  
- **Namespace** – Container for hubs/topics; manages capacity, security, and recovery.  
- **Event Hub / Kafka topic** – Append-only distributed log with one or more partitions.  
- **Partitions** – Scale throughput (like freeway lanes).  
- **Consumer apps** – Read events using Event Hubs SDK or Kafka clients.  
- **Consumer groups** – Allow multiple consumers to read the same stream independently.  

---

> 9.2.3 📥 Explore Event Hubs Capture  

Azure Event Hubs **automatically captures streaming data** into **Azure Blob Storage** or **Azure Data Lake Storage**. You can configure capture intervals by **time or size**, and it scales automatically with Event Hubs throughput units (Standard) or processing units (Premium).  

### 🔑 Key Benefits
- No extra admin overhead; auto-scales with Event Hubs.  
- Supports **real-time + batch pipelines** on the same stream.  
- Stores data in **Apache Avro** format for compact, schema-rich storage.  
- Works across regions (same or different from your event hub).  

### ⚙️ How It Works
- Event Hubs uses a **partitioned consumer model** with retention periods.  
- Capture writes data per partition into storage, using this naming convention:  


### 📊 Throughput & Scaling
- 1 Throughput Unit (TU) = **1 MB/s or 1,000 events/s ingress**, with 2x egress.  
- Standard tier: 1–20 TUs (can request more).  
- Capture copies data directly from **internal Event Hubs storage**, so it doesn’t consume egress quota.  

### ⏱ Capture Windowing
- Configurable by **size** and **time** (first trigger wins).  
- Each partition writes an Avro file at capture time.  
- Writes **empty files when no data** is present → useful for batch processors.  


---

> 9.2.4 📥 Explore Event Hubs Capture   

Event Hubs Capture lets you **automatically store streaming data** in **Blob Storage** or **Data Lake** at configurable **time or size intervals**, with no admin overhead. Data is stored in **Apache Avro** format and scales with Event Hubs throughput units.  

### 📊 Throughput & Scaling  
- 1 TU = **1 MB/s or 1,000 events/s ingress** (2x egress).  
- Standard: 1–20 TUs (more via request).  
- Capture bypasses egress quota.  

### ⏱ Capture Windowing  
- Triggered by **time or size** (first wins).  
- Each partition writes its own Avro file.  
- Writes **empty files** if no data, ensuring predictable cadence.  

---

> 9.2.5 🔐 Control Access to Events  

Event Hubs supports **Microsoft Entra ID** (OAuth 2.0) and **Shared Access Signatures (SAS)** for authentication & authorization.  

### 👥 Azure Roles (Entra ID)  
- **Data Owner** → Full access  
- **Data Sender** → Send only  
- **Data Receiver** → Receive only  
- Use with **managed identities** for RBAC-based access.  

### 🔑 Microsoft Entra ID  
- No credentials stored in code. ‼️ 
- App requests an **OAuth token** → used to authorize Event Hubs calls.  

### 📤 Publishers (SAS)  
- Virtual endpoints for **sending only**.  
- One publisher per client (fine-grained control).  
- Clients get **unique SAS tokens**, valid until expiry.  

### 📥 Consumers (SAS)  
- Clients need **Manage** or **Listen** rights at namespace, hub, or topic level.  
- Scope applies to all consumer groups under that entity.  

---

> 9.2.6 ⚙️ Common Operations with Event Hubs Client Library  

The `Azure.Messaging.EventHubs` library enables you to **inspect, publish, and consume** events.  

---

### 🔍 Inspect Partitions  
Use `EventHubProducerClient.GetPartitionIdsAsync()` to list available partitions.  

---

### 📤 Publish Events  
- Use `EventHubProducerClient` to send batches.  
- Can target a partition or let Event Hubs auto-assign (recommended for load balancing).  

---

### 📥 Read Events  
- Use `EventHubConsumerClient` with a **consumer group**.  
- Read all events (`ReadEventsAsync`) or from a specific partition (`ReadEventsFromPartitionAsync`).  
- Good for prototyping, **not production**.  

---

### 🚀 Process Events (Production)  
- Use `EventProcessorClient` for scalable, reliable processing.  
- Requires **Azure Storage (BlobContainerClient)** for state persistence.  
- Handles **event processing & error handling** automatically.  

---

9.2.7 📝 Exercise - Send & Retrieve Events from Azure Event Hubs  

In this exercise, you:  
- Provision **Azure Event Hubs resources** inside a resource group.  
- Build a **.NET console app** using `Azure.Messaging.EventHubs` to **send & receive events**.  
- Clean up cloud resources after completion.  

[Send and retrieve events from Azure Event Hubs](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-events-messages/02-event-hubs-send-receive.html)

---

> 9.2.8 📘 Event Hubs Quiz  

1. **Which of the following Event Hubs concepts represents an ordered sequence of events that is held in an Event Hubs?**  
- Consumer group  
- ✅ Partition  
- Event Hubs producer  

---

2. **Which of the following options represents when an event processor marks or commits the position of the last successfully processed event within a partition?**  
- ✅ Checkpointing  
- Scale  
- Load balance  

---

3. **What is a key advantage of using Microsoft Entra ID with Azure Event Hubs?**  
- It allows storing credentials directly in the application code for easier access.  
- It eliminates the need for OAuth 2.0 tokens for authentication.  
- ✅ It removes the need to store credentials in the application code by using OAuth 2.0 tokens.  

---

4. **What is the purpose of the EventHubProducerClient in the Azure Event Hubs client library?**  
- To process events from an event hub using a consumer group.  
- ✅ To publish events to an event hub, either to specific partitions or using automatic routing.  
- To manage and monitor the partitions within an event hub.  

---

> 9.2.9 # 📘 Event Hubs Module Summary  

In this module, you learned how to:  

- 📊 Describe the **benefits of Event Hubs** and how it captures streaming data.  
- ⚙️ Explain how to **process events** effectively.  
- 🛠 Perform **common operations** with the Event Hubs client library.  
- 📩 **Send and retrieve events** from Azure Event Hubs.  

> Azure Event Hubs is a highly scalable event streaming service that ingests, processes, and stores millions of events per second with low latency. It integrates with tools like Azure Functions, Stream Analytics, and client SDKs, enabling real-time processing, secure access, and seamless event publishing and consumption.

--- 🩴 footer HA ---