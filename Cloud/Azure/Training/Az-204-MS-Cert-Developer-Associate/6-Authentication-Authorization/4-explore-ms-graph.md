# 📌 Explore Microsoft Graph  
**Module**  
8 Units • Intermediate • Developer • Azure SDKs • Microsoft Graph  

Learn how Microsoft Graph facilitates the access and flow of data and how to form queries through REST and code.  

### Learning objectives  
After completing this module, you'll be able to:  
- Explain the benefits of using Microsoft Graph.  
- Perform operations on Microsoft Graph by using REST and SDKs.  
- Apply best practices to help your applications get the most out of Microsoft Graph.  
- Retrieve user profile information with the Microsoft Graph SDK.  

### Prerequisites  
- Familiarity with developer concepts and terminology.  
- Experience working with OAuth.  
- Understanding of cloud computing and some experience with the Azure portal.  

### This module is part of these learning paths  
- Implement user authentication and authorization  

### Units  
- Introduction  
- Discover Microsoft Graph  
- Query Microsoft Graph by using REST  
- Query Microsoft Graph by using SDKs  
- Apply best practices to Microsoft Graph  
- Exercise - Retrieve user profile information with the Microsoft Graph SDK  
- Module assessment  
- Summary  

---

> 6.4.1 📌 Introduction to Microsoft Graph  

Use the wealth of data in Microsoft Graph to build apps for organizations and consumers that can interact with millions of users.  

### 🎯 Learning outcomes  
After completing this module, you'll be able to:  
- Explain the benefits of using Microsoft Graph  
- Perform operations on Microsoft Graph by using REST and SDKs  
- Apply best practices to help your applications get the most out of Microsoft Graph  
- Retrieve user profile information with the Microsoft Graph SDK  

---

> 6.4.2 🔎 Discover Microsoft Graph  

Microsoft Graph is the gateway to data and intelligence in Microsoft 365, offering a unified programmability model to access data across Microsoft 365, Windows 10, and Enterprise Mobility + Security.  

### ✨ Key Points  
- **Microsoft Graph API**: Provides a single endpoint (`https://graph.microsoft.com`) with REST APIs and SDKs for accessing data, plus identity, access, compliance, and security services.  
- **Microsoft Graph Connectors**: Bring external data (e.g., Box, Google Drive, Jira, Salesforce) into Microsoft Graph to enhance Microsoft 365 experiences like Microsoft Search.  
- **Microsoft Graph Data Connect**: Streamlines secure, scalable delivery of Microsoft Graph data to Azure data stores, enabling intelligent apps with Azure tools.  ‼️


> 6.4.3 🌐 Query Microsoft Graph by using REST  

Microsoft Graph is a RESTful web API that lets you access Microsoft Cloud service resources using authentication tokens. It defines most resources, methods, and enumerations in the **microsoft.graph** OData namespace.  

### 🔑 Key Concepts  
- **Request format:**  

```HTTP
 https://graph.microsoft.com/{version}/{resource}?{query-parameters}
```

- **HTTP method**: GET, POST, PATCH, PUT, DELETE  
- **Version**: `v1.0` (production) or `beta` (preview/testing)  
- **Resource**: e.g., `me`, `user`, `group`, `drive`, `site`  
- **Query parameters**: Optional OData filters/customization  

- **Response includes:**  
- **Status code** (success/failure)  
- **Response message** (data or result)  
- **nextLink** for paging large results  

- **Resources:** Entities (with `id`) and complex types (without `id`).  
- **Permissions:** Vary by resource and action (read vs. write).  

### ⚙️ HTTP Methods  
- **GET** – Read data  
- **POST** – Create new resource / perform action  
- **PATCH** – Update values in resource  
- **PUT** – Replace resource  
- **DELETE** – Remove resource  

### 📌 Example Query  
```http
GET https://graph.microsoft.com/v1.0/me/messages?filter=emailAddress eq 'jon@contoso.com'
```

> 6.4.4 ⚡ Query Microsoft Graph by using SDKs  

The Microsoft Graph SDKs simplify building reliable apps that access Microsoft Graph by providing a **service library** (models & request builders) and a **core library** (retry handling, authentication, redirects, paging, batching).  

### 🔑 Key Features  
- **Service library** – Generated from Microsoft Graph metadata; rich, discoverable API.  
- **Core library** – Handles retries, secure redirects, authentication, paging, batching, and compression.  
- **NuGet packages:**  
  - `Microsoft.Graph` (v1.0 endpoint)  
  - `Microsoft.Graph.Beta` (beta endpoint)  
  - `Microsoft.Graph.Core` (shared core library)  

### ⚙️ Usage Examples (C#)  
**Create a client:**  
```csharp
var graphClient = new GraphServiceClient(deviceCodeCredential, scopes);
```

Read user info:
```csharp
var user = await graphClient.Me.GetAsync();
```
Create a calendar:
```csharp
var calendar = new Calendar { Name = "Volunteer" };
var newCalendar = await graphClient.Me.Calendars.PostAsync(calendar);
```

> 6.4.5  ✅ Apply Best Practices to Microsoft Graph  

This unit covers best practices to make Microsoft Graph apps more reliable, secure, and user-friendly.  

### 🔑 Key Areas  

**Authentication**  
- Acquire OAuth 2.0 tokens using MSAL.  
- Pass tokens via HTTP `Authorization: Bearer` header or Graph client constructor.  

**Consent & Authorization**  
- Use **least privilege** (only request permissions you need).  
- Use **delegated permissions** for interactive apps; **application permissions** for background services.  
- Avoid misusing app permissions in interactive scenarios.  
- Plan for **end-user vs. admin consent** and differences in **static, dynamic, and incremental consent**.  
- Handle **multi-tenant variations** (e.g., restricted user consent, custom admin policies).  

**Handling Responses**  
- **Pagination**: Use `@odata.nextLink` to fetch multiple pages.  
- **Evolvable enums**: Prepare for new/unknown enum values, opt-in with `Prefer` header if needed.  

**Data Storage**  
- Prefer **real-time API calls** over storing data.  
- If caching, ensure compliance with **terms of use, privacy policies, and proper retention/deletion** practices.  

> 6.4.6 📝 Exercise - Retrieve user profile information with the Microsoft Graph SDK  

In this exercise, you create a .NET app to authenticate with Microsoft Entra ID, request an access token, and call the Microsoft Graph API to retrieve and display user profile information. You also learn how to configure permissions and interact with Microsoft Graph from your application.  

### 🔨 Tasks Performed  
- Register an application with the Microsoft identity platform  
- Create a .NET console application that:  
  - Implements interactive authentication  
  - Uses the `GraphServiceClient` class to retrieve user profile information  

Retrieve user profile information with the Microsoft Graph SDK](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-app-auth/02-graph-user-profile.html)

> 6.4.7 ✅ Quiz  

1. **Which HTTP method is used to partially update a resource with new values?**  
- POST  
- **PATCH ✅**  
- PUT  

2. **Which of the components of the Microsoft 365 platform is used to deliver data external to Azure into Microsoft Graph services and applications?**  
- Microsoft Graph API  
- **Microsoft Graph connectors ✅**  
- Microsoft Graph Data Connect  


> 6.4.8 📘 Summary  

In this module, you learned how to:  

- Explain the benefits of using Microsoft Graph  
- Perform operations on Microsoft Graph by using REST and SDKs  
- Apply best practices to get the most out of Microsoft Graph  
- Retrieve user profile information with the Microsoft Graph SDK  

--- ⾜ ---
