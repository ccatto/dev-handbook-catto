# 9. Develop event-based solutions

> Explore Azure Event Grid

Learn how to integrate Azure Event Grid into your solution, implement access control to events, and route custom events to web endpoints by using Azure CLI.  

## Units  
- Introduction  
- Explore Azure Event Grid  
- Discover event schemas  
- Explore event delivery durability  
- Control access to events  
- Receive events by using webhooks  
- Filter events  
- Exercise - Route events to a custom endpoint with Event Grid  
- Module assessment  
- Summary  

---

> 9.1.1 🚀 Introduction – Azure Event Grid  

Azure Event Grid integrates seamlessly with Azure and third-party services.  
It reduces costs by eliminating constant polling, and reliably routes events from Azure and non-Azure sources to subscriber endpoints.  

### 🎯 After completing this module, you'll be able to:  
- 🔗 Describe how Event Grid operates and connects to services and event handlers.  
- 📩 Explain how Event Grid delivers events and handles errors.  
- 🔒 Implement authentication and authorization.  
- 🎛️ Route events to a custom endpoint.  

---

> 9.1.2  📡 Explore Azure Event Grid  

Azure Event Grid is a **scalable, fully managed Pub/Sub service** that supports **HTTP** and **MQTT** protocols. It enables event-driven architectures, IoT integration, and system interoperability using the **CloudEvents 1.0 specification**.  

### 🔑 Core Concepts  
- **Publishers** → Send events (Azure services, custom apps, or partners).  
- **Events** → Smallest data unit, follow CloudEvents JSON format (max size: 1 MB).  
- **Event Sources** → Where events originate (e.g., Storage, IoT Hub, custom apps).  
- **Topics** → Containers for events (system, custom, or partner topics).  
- **Subscriptions** → Define which events to receive, with filtering & expiration options.  
- **Handlers** → Destinations for events (Azure services, webhooks, queues).  
- **Security** → Permissions required for publishing/subscribing; supports RBAC and managed identities.  

👉 Event Grid supports **push & pull delivery**, retries until successful, and ensures reliable event routing.  


---

> 9.1.3 🧩 Discover Event Schemas  

Azure Event Grid supports two schemas:  
- **Event Grid schema** (default, Azure-specific)  
- **CloudEvents v1.0 schema** (open standard for interoperability)  

### 🔑 Event Grid Schema  
- Events include required properties:  
  - `id`, `subject`, `eventType`, `eventTime` ‼️
- Optional fields: `topic`, `data`, `dataVersion`, `metadataVersion`  
- Events posted as **arrays** (max 1 MB total, 1 MB per event).  
- Charges apply in **64 KB increments**.  
- **Subjects** help subscribers filter/rout events (e.g., by path `/A/B/C` or suffix `.txt`).  

### 🌐 CloudEvents Schema  
- Open standard for **cross-platform eventing**.  
- JSON format with fields like `specversion`, `type`, `source`, `id`, `time`, `subject`, `data`.  
- Enables **consistent tooling, routing, and deserialization**.  
- Content-type differs:  
  - Event Grid schema → `application/json`  
  - CloudEvents schema → `application/cloudevents+json`  

👉 Event Grid can **input, output, and transform** between both schemas, supporting system events (e.g., Blob Storage, IoT Hub) and custom events.  

---

> 9.1.4 📦 Explore Event Delivery Durability  

Azure Event Grid ensures **durable, at-least-once delivery** of events. If delivery fails, it retries using a **fixed schedule with exponential backoff**.  

### 🔁 Retry Behavior  
- One event delivered at a time (array with single event).  
- Retries triggered unless endpoint returns **non-retriable errors**:  
  - **Azure Resources** → `400`, `413` ‼️ 
  - **Webhooks** → `400`, `413`, `401`  
- Without **Dead-Lettering**, failed events are dropped.  

### ⚙️ Retry Policy Options  
- **Max attempts**: 1–30 (default: 30).  
- **TTL**: 1–1440 minutes (default: 1440).  

### 📊 Output Batching  
- Disabled by default.  
- Options:  
  - **Max events per batch**: 1–5,000.  
  - **Preferred batch size**: in KB (may exceed if event > size).  

### 🕒 Delayed Delivery  
- If multiple failures occur, retries are **delayed** to prevent overwhelming endpoints.  

### ☠️ Dead-Lettering  
- Undelivered events can be sent to **Azure Storage**.  
- Triggered when:  
  - Event exceeds **TTL**.  
  - Event exceeds **retry limit**.  
  - Non-retriable error (`400`, `413`).  
- If storage is unavailable >4 hours → events are dropped.  

### 🏷️ Custom Delivery Properties  
- Up to **10 custom headers** per subscription.  
- Supported destinations: Webhooks, Service Bus, Event Hubs, Relay.  

--- 

> 9.1.5 🔐 Control Access to Events  

Azure Event Grid uses **Azure RBAC** to control access for managing operations like listing subscriptions, creating them, and generating keys.  

---

## 👥 Built-in Roles  

| Role | Description |
|------|-------------|
| 📖 **Event Grid Subscription Reader** | Read event subscriptions. |
| 🛠️ **Event Grid Subscription Contributor** | Manage event subscription operations. |
| 🌐 **Event Grid Contributor** | Create and manage Event Grid resources. | ‼️
| 📤 **Event Grid Data Sender** | Send events to Event Grid topics. |

🔑 Notes:  
- **Subscription Reader** & **Contributor** → Focused on managing subscriptions (important in event domains).  
- **Contributor** → Full Event Grid resource management.  

---

## 📝 Permissions for Event Subscriptions  

- For **non-WebHook handlers** (e.g., Event Hubs, Queue Storage), you need:  
  `Microsoft.EventGrid/EventSubscriptions/Write`  
- This ensures only authorized users can create subscriptions at the resource scope.  

---

## 🏷️ Topic Permissions  

- **System topics** → Write permission at the **event source resource** scope.  

---

> 9.1.6 📥 Receive Events by Using Webhooks  

Webhooks let Event Grid deliver events by **POSTing** HTTP requests with event data to your configured endpoint.  

---

## 🔑 Key Points  

- Event Grid requires **endpoint ownership validation** to prevent malicious event flooding.  
- Validation is **automatic** when using:  
  - Azure Logic Apps (Event Grid Connector)  
  - Azure Automation (via webhook)  
  - Azure Functions (Event Grid Trigger)  

---

## 🔍 Endpoint Validation  

### 1. **Synchronous Handshake**  
- Event Grid sends a **SubscriptionValidationEvent**.  
- Event contains a `validationCode`.  
- Endpoint must respond **200 OK** with the `validationCode`.  
- Supported in all Event Grid versions.  

### 2. **Asynchronous Handshake (manual)**  
- Used when synchronous response isn’t possible (e.g., Zapier, IFTTT).  
- Event includes a `validationUrl`.  
- Complete handshake by sending a **GET request** to the URL (valid 5 min).  
- Until validated, subscription state = `AwaitingManualAction`.  
- Requires endpoint to return **HTTP 200** initially.  

---

⚠️ **Note:** Self-signed certs aren’t supported. Use a certificate from a trusted CA.  

---

> 9.1.7 🎯 Filter Events  

Event Grid lets you filter events by:  

- **Event types** → choose specific events (e.g., `ResourceWriteSuccess`)  
- **Subject** → match prefix/suffix (e.g., `.jpg`, `/mycontainer/`)  
- **Advanced filters** → compare fields with operators (numbers, strings, booleans)  

---

> 9.1.8 🛠️ Exercise - Configure Event Grid to Send Events  

In this exercise, you configure **Azure Event Grid** to send events to an endpoint.  
You’ll create resources, set up subscriptions, and verify that your endpoint receives events.  

### 🔑 Tasks  
- 🌐 Create Azure Event Grid resources  
- ⚙️ Enable the Event Grid resource provider  
- 📌 Create a topic in Event Grid  
- 🔗 Create a message endpoint  
- 📨 Subscribe to the topic  
- 💻 Send an event with a .NET console app  
- 🧹 Clean up resources  

[Route events to a custom endpoint with Azure Event Grid](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-events-messages/01-event-grid-events-to-endpoint.html)

---

> 9.1.9  📝 Azure Event Grid Quiz  

---

**1. Which of the following event schema properties requires a value?**  
- Topic  
- Data  
- ✅ Subject  

---

**2. Which of the following Event Grid built-in roles is appropriate for managing Event Grid resources?**  
- ✅ Event Grid Contributor  
- Event Grid Subscription Contributor  
- Event Grid Data Sender  

---

**3. What is the purpose of the CloudEvents schema in Azure Event Grid?**  
- To provide a proprietary event schema specific to Azure services.  
- ✅ To simplify interoperability by providing a common event schema for publishing and consuming cloud-based events.  
- To replace the Event Grid event schema entirely for all event types.  

---

**4. What happens when Event Grid receives a 400 (Bad Request) or 413 (Request Entity Too Large) response code during event delivery?**  
- Event Grid retries the delivery indefinitely until the endpoint responds.  
- ✅ Event Grid schedules the event for dead-lettering if a dead-letter location is configured.  
- Event Grid immediately drops the event without further action.  

---

**5. What is the purpose of the validation handshake in Azure Event Grid when using a custom webhook endpoint?**  
- ✅ To prove ownership of the webhook endpoint before delivering events  
- To ensure the webhook endpoint is hosted on Azure infrastructure  
- To encrypt the event data being sent to the webhook endpoint  

---

> 9.1.10 Summary 🎯 Azure Event Grid Learning Objectives

- **Describe operations**  
  Understand how Event Grid works and how it connects services with event handlers.  

- **Explain event delivery**  
  Learn how Event Grid delivers events and manages errors during delivery.  

- **Implement security**  
  Configure authentication and authorization for secure event handling.  

- **Route events**  
  Send events to custom endpoints for flexible integration.  
