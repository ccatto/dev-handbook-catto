# 2 Implement Azure Functions:

# Outline

- Introduction
- Examine Azure App Service
- Examine Azure App Service plans
- Deploy to App Service
- Explore authentication and authorization in App Service
- Discover App Service networking features
- Exercise: Deploy a containerized app to Azure App Service
- Module assessment
- Summary


> Azure Functions is a serverless compute service that lets you run code in response to events without managing infrastructure, offering automatic scaling and cost savings. It supports triggers and bindings for easy integration with other Azure services, making it ideal for event-driven applications. Compared to Logic Apps and WebJobs, Functions is code-first, more flexible, and generally the best choice for most serverless scenarios.

> Azure Functions offers several hosting options, including Consumption, Flex Consumption, Premium, Dedicated, and Container Apps, each with different scaling, performance, and cost models. Consumption plans provide pay-as-you-go billing with automatic scaling, while Premium and Dedicated plans offer more power, longer execution times, and virtual network support. Container Apps let you run Functions in a fully managed containerized environment, ideal for microservices and custom workloads.

> Azure Functions scale automatically based on demand, with limits depending on the hosting plan. The Consumption plan scales up to 200 instances on Windows (100 on Linux), while the Flex Consumption plan scales per function with limits tied to regional memory. Premium, Dedicated, and Container Apps offer higher or configurable scaling, making them suitable for workloads that require more control or larger capacity.

1. An organization wants to implement a serverless workflow to solve a business problem. One of the requirements is the solution needs to use a designer-first (declarative) development model.  
**Which of the choices below meets the requirements?**

- Azure Functions  
- Azure Logic Apps ✅ Correct  
- WebJobs  

---

2. What is a key benefit of the Flex Consumption plan in Azure Functions hosting options?  

- It provides fully predictable billing and manual scale instances.  
- It offers high scalability with compute choices, virtual networking, and pay-as-you-go billing. ✅ Correct  
- It allows for the packaging of custom libraries with function code.  

---

3. What is the maximum number of instances for a function app on a Consumption plan in Windows?  

- 300  
- 100  
- 200 ✅ Correct  
* linux is 100 fyi;

---

## Azure Functions

- **Type**: Serverless compute, code-first (imperative).
- **Use Case**: Best for developers who want to run custom code in response to events (HTTP requests, database changes, IoT events, queues, timers).
- **Scaling**: Event-driven, automatic scaling (Consumption/Flex/Premium).
- **Flexibility**: Supports multiple languages (C#, JavaScript, Python, PowerShell, Java, etc.).
- **Best For**: Custom business logic, microservices, APIs, and event-driven workloads.

## Azure Logic Apps

- **Type**: Serverless workflow integration, designer-first (declarative).
- **Use Case**: Best for orchestrating workflows that connect services with minimal code (drag-and-drop in portal).
- **Connectivity**: Hundreds of built-in connectors (Office 365, Salesforce, SAP, Twitter, Service Bus, etc.).
- **Scaling**: Automatically scales with demand.
- **Best For**: Business process automation, integrations across SaaS and enterprise systems, low-code/no-code scenarios.

## Azure WebJobs

- **Type**: Background jobs tied to App Service.
- **Use Case**: Long-running or background tasks (file cleanup, scheduled jobs, data processing).
- **Scaling**: Scales with the App Service plan (not as dynamic as Functions).
- **Flexibility**: Runs scripts or programs (C#, PowerShell, Node.js, Python, etc.).
- **Best For**: When you already run an App Service (web app/API) and want background tasks to run alongside it.

## Summary

- **Azure Functions**: Code-first, event-driven compute (serverless apps & APIs).
- **Azure Logic Apps**: Designer-first, workflow automation & integration.
- **Azure WebJobs**: Background processing inside an App Service, good for companion tasks.

---

