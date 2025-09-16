# 11. Troubleshoot solutions by using Application Insights

> Troubleshoot solutions by using Application Insights

----

> Monitor app performance  

Learn how to use the tools offered in Application Insights to enhance the performance and stability of your applications.  

## Units  
- Introduction  
- Explore Application Insights  
- Discover log-based metrics  
- Instrument an app for monitoring  
- Select an availability test  
- Troubleshoot app performance by using Application Map  
- Exercise - Monitor an application with autoinstrumentation  
- Module assessment  
- Summary  

---

> Intro

- Describe how Application Insights works and how it collects events and metrics.
- Instrument an app for monitoring, and perform availability tests.
- Use Application Map to help you monitor performance and troubleshoot issues.

---

## Explore Application Insights  

> **Application Insights** (an extension of Azure Monitor) provides Application Performance Monitoring (APM) to track apps from development to production.  

### Key Features  
- **Live Metrics** – real-time monitoring without affecting hosts  
- **Availability Tests** – probe endpoints for uptime and responsiveness  
- **Usage Analytics** – track user interactions and feature adoption  
- **Smart Detection** – automatic anomaly/failure detection  
- **Application Map** – visualize app architecture and component health  
- **Distributed Tracing** – follow execution flow end-to-end  
- **DevOps Integration** – connect with GitHub or Azure DevOps  

### What It Monitors  
- Request/response rates, failures, and dependencies  
- Exceptions (server and browser)  
- Page views, AJAX calls, load performance  
- User/session counts  
- System metrics (CPU, memory, network)  
- Docker/Azure host diagnostics  
- Trace logs and custom events  

### Getting Started  
Telemetry is sent to Azure for analysis. You can:  
- Instrument at runtime (no code changes needed)  
- Add at development time for custom telemetry  
- Monitor client-side (web, AJAX, mobile)  
- Run availability tests from Azure servers  

---

>  Discover log-based metrics  

**Application Insights** supports two metric types:  

- **Log-based metrics** – built from stored events via Kusto queries; highly detailed, great for analysis/diagnostics, but slower and may require sampling.  
- **Standard (preaggregated) metrics** – stored as time series with key dimensions; faster at query time, ideal for dashboards and near real-time alerting.  

### Key Points  
- Use **log-based metrics** for deep analysis and ad-hoc diagnostics.  
- Use **standard metrics** for performance, dashboards, and alerts.  
- Both coexist in Application Insights; newer SDKs support preaggregation by default.  

---

> Instrument an app for monitoring  

**Instrumentation** = enabling an app to capture telemetry.  

### Methods  
- **Autoinstrumentation** – no code changes, quick setup, limited configurability, not in all languages.  
- **Manual instrumentation** – use SDKs or OpenTelemetry; allows custom events/metrics and full control.  

### Options  
- **Application Insights SDKs** – use when you need custom telemetry, control, or autoinstrumentation isn’t available.  
- **OpenTelemetry** – industry standard supported by Microsoft; unifies tracing/logging terminology.  

### Key Mapping (Insights → OpenTelemetry)  
- Autocollectors → Instrumentation libraries  
- Channel → Exporter  
- Codeless/Agent-based → Autoinstrumentation  
- Requests → Server Spans  
- Dependencies → Other Span Types  
- Operation ID → Trace ID  
- Parent ID → Span ID  

---

> Select an availability test  

Availability tests in Application Insights let you monitor uptime and responsiveness of any public HTTP/HTTPS endpoint or REST API.  

### Test types  
- **Standard test** – Recommended. Checks endpoint availability, performance, TLS/SSL validity, HTTP verbs, custom headers/data.  
- **Custom TrackAvailability test** – Use SDK method `TrackAvailability()` for custom apps.  
- **URL ping test (classic)** – Legacy; being retired Sept 30, 2026.   

✅ Up to 100 tests per Application Insights resource.  

---

> Troubleshoot app performance by using Application Map  

Application Map in Application Insights visualizes the **topology** of distributed apps, helping identify performance bottlenecks and failure hotspots.  

### Key points  
- Each node = app component or dependency with health KPIs and alerts.  
- Drill into diagnostics (App Insights events, Azure diagnostics like SQL Advisor).  
- Components = deployable parts of your app (with their own telemetry), distinct from external dependencies.  
- Supports multiple roles/resources; progressive discovery builds full topology.  
- Cloud role name identifies components (can be customized).  

✅ Use Application Map to quickly spot and troubleshoot issues across complex, multi-service applications.  

---

> Exercise - Monitor an application with autoinstrumentation  
  
In this exercise, you create an Azure App Service web app with Application Insights enabled, configure autoinstrumentation without modifying code, deploy a Blazor application, and view application metrics and error data. This approach enables full monitoring and observability without code changes, simplifying deployments and migrations.  

### Tasks performed  
- Create a web app resource with Application Insights enabled  
- Configure instrumentation for the web app  
- Create a new Blazor app and deploy it  
- View application activity in Application Insights  
- Clean up resources  

[Monitor an application with autoinstrumentation](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-app-insights/01-app-insights-auto-instrument.html)

---

> Quiz

1. Which of the following availability tests is recommended for authentication tests?  
- URL ping  
- Standard  
- ✅ Custom TrackAvailability  

2. Which of the following metric collection types provides near real-time querying and alerting on dimensions of metrics, and more responsive dashboards?  
- Log-based  
- ✅ Preaggregated  
- Azure Service Bus  

---

> Summary ✅

In this module, you learned how to:

- Describe how Application Insights works and how it collects events and metrics.  
- Instrument an app for monitoring, and perform availability tests.  
- Use Application Map to help you monitor performance and troubleshoot issues.  

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

