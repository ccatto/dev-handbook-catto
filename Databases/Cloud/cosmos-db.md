# Cosmos 

### Catto Notes

# Azure Services for C# Web API + Angular Frontend

In **Azure** they also call them **services** (similar to AWS), though sometimes you’ll hear the terms *resources* or *offerings*. For a **C# Web API + Angular frontend** architecture, here are the **most common Azure services** we use:

---

## 🔹 Compute / Hosting

* **Azure App Service**

  * Easiest way to host a C# Web API (ASP.NET Core) or Angular frontend.
  * Fully managed (handles scaling, patching, deployment slots, etc.).
* **Azure Functions**

  * Serverless option for lightweight APIs, background tasks, or event-driven processing.
* **Azure Kubernetes Service (AKS)**

  * If you containerize your backend/frontend (e.g., Docker), you can deploy on Kubernetes.
* **Azure Static Web Apps**

  * Perfect for Angular front ends (serves static files + integrates with APIs).

---

## 🔹 Storage & Databases

* **Azure SQL Database**

  * Managed relational database (common for .NET apps).
* **Azure Cosmos DB**

  * Globally distributed NoSQL DB (document, key-value, graph).
* **Azure Blob Storage**

  * For file uploads, media, or static content.
* **Azure Cache for Redis**

  * In-memory caching layer for performance.

---

## 🔹 Networking & Security

* **Azure API Management (APIM)**

  * For exposing your C# Web API securely, rate-limiting, versioning, developer portal.
* **Azure Front Door / Azure Application Gateway**

  * Load balancing, routing, SSL termination, WAF (Web Application Firewall).
* **Azure Virtual Network (VNet)**

  * Networking backbone if you need private communication between services.

---

## 🔹 Identity & Access

* **Azure Active Directory (AAD / Entra ID)**

  * Authentication & authorization for users (OAuth, OpenID Connect, SSO).
* **Azure Key Vault**

  * Securely store API keys, connection strings, and certificates.

---

## 🔹 Monitoring & DevOps

* **Azure Monitor & Application Insights**

  * Logging, performance monitoring, error tracking for Web API and Angular frontend.
* **Azure DevOps** or **GitHub Actions**

  * CI/CD pipelines for automated builds, tests, and deployments.

---

## 🔹 Typical Architecture (C# Web API + Angular Frontend)

```
[ Angular App ]  --->  [ Azure Static Web Apps / App Service ]
         |
         v
   [ Azure API Management ] ---> [ C# Web API on App Service / Functions / AKS ]
         |
         v
   [ Azure SQL / Cosmos DB / Blob Storage ]
```

---

✅ **Summary:**
For a **C# Web API + Angular frontend**, the most common Azure stack is:

* **Frontend** → Angular hosted in **Azure Static Web Apps** or **App Service**
* **Backend** → C# Web API hosted in **Azure App Service** (or Functions if serverless)
* **Database** → **Azure SQL Database**
* **Security** → **Azure AD + Key Vault**
* **Monitoring** → **App Insights + Azure Monitor**

---



