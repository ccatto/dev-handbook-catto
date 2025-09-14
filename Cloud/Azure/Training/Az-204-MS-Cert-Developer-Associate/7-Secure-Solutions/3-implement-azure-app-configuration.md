# Implement Azure App Configuration

# Learn how to use Azure App Configuration service to centrally manage and secure your configuration settings, and to manage app features.

## Units
- Introduction  
- Explore the Azure App Configuration service  
- Create paired keys and values  
- Manage application features  
- Secure app configuration data  
- Exercise - Retrieve configuration settings from Azure App Configuration  
- Module assessment  
- Summary  

---

> 🚀 Introduction  

**Azure App Configuration** provides a centralized service to manage application settings and feature flags.  

After completing this module, you'll be able to:  
- 🔹 Explain the **benefits** of using Azure App Configuration  
- 🔹 Describe how it **stores information**  
- 🔹 Implement **feature management**  
- 🔹 Securely **access configuration data**  
- 🔹 Retrieve settings from **Azure App Configuration**  

---

> 🔎 Explore the Azure App Configuration service  

**Azure App Configuration** centralizes app settings and feature flags, reducing errors in distributed cloud apps.  

### 🌟 Benefits  
- Fully managed, quick setup  
- Flexible keys, labels & comparisons  
- Feature flag UI & point-in-time replay  
- Secure with managed identities & encryption  
- Integrates with Key Vault and frameworks  

### 🚀 Use Cases  
- Centralized config across environments  
- Dynamic setting changes without redeploy  
- Real-time feature control  

### 🧩 Integration  
- .NET / ASP.NET Core → Provider for .NET  
- Java Spring → Provider for Spring Cloud  
- Node.js → Provider for JS  
- Python → Provider for Python  
- Others → REST API  

---  
✨ *App Configuration = one secure, central source for settings & feature flags.*  

---

> 🔑 Create Paired Keys and Values  

**Azure App Configuration** stores settings as **key–value pairs**.  

### 🔹 Keys  
- Names for values; can be flat or hierarchical (`App:Service:Endpoint`).  
- Case-sensitive, Unicode-based; reserved chars: `* , \`.  
- Use hierarchical naming for readability, management, and queries.  

### 🔹 Labels  
- Optional attribute to distinguish variants of the same key ‼️
- Common use: environments (Test, Staging, Production).  
- Can simulate versions (e.g., app version, Git commit).  

### 🔹 Values  
- Unicode strings, optional content type metadata.  
- Encrypted at rest & in transit.  
- ⚠️ Not a replacement for Key Vault (don’t store secrets).  

---  
✨ *App Configuration keys = flexible, hierarchical, and labelable settings for centralized app config.*  

---

>  🚩 Manage Application Features  

**Feature management** decouples code deployment from feature release using **feature flags** (on/off switches).  

- **Feature flag** → Boolean toggle controlling code execution.  
- **Feature manager** → Handles lifecycle, caching, updates ‼️  
- **Filter** → Rules (e.g., user group, location, % rollout).  
- **Repo** → External store (e.g., Azure App Configuration) for dynamic updates.  

---  
✨ *Feature flags = controlled, flexible, and fast feature rollout.*  

---

> 🔒 Secure App Configuration Data  

You can secure Azure App Configuration data with three key methods:  

- **Customer-managed keys (CMK)** – Use Azure Key Vault + managed identities to encrypt sensitive values ‼️
- **Private endpoints** – Lock access to your virtual network, eliminating public exposure.  
- **Managed identities** – Allow App Configuration to securely access resources like Key Vault without secrets.  

---  
✨ *App Configuration security = encryption + private network + identity-based access.*  

---

> 🛠️ Exercise – Retrieve Configuration Settings from Azure App Configuration  

In this exercise, you will:  

- Create an **Azure App Configuration** resource  
- Store configuration settings via **Azure CLI**  
- Build a **.NET console app** using `ConfigurationBuilder` to retrieve values  
- Organize settings with **hierarchical keys**  
- Authenticate your app to securely access cloud-based config data  
- 🔄 Clean up resources when finished  

---  
✨ *Practice: Centralize config, retrieve with code, keep it secure.*  

Retrieve configuration settings from Azure App Configuration](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-secure-solutions/02-app-config-retrieve.html)

---

> ✅ Azure App Configuration Quiz  

1. **What is the purpose of labels in Azure App Configuration?**  
- ✅ Labels are used to differentiate key-values with the same key in App Configuration.  
- ❌ Labels are used to encrypt key-values in App Configuration.  
- ❌ Labels are used to limit the size of key-values in App Configuration.  

---

2. **What is the role of a feature manager in managing application features?**  
- ❌ A feature manager is a rule for evaluating the state of a feature flag.  
- ❌ A feature manager is a variable with a binary state of on or off.  
- ✅ A feature manager is an application package that handles the lifecycle of all the feature flags in an application.  

---

3. **What is the purpose of using customer-managed keys in Azure App Configuration?**  
- ❌ To enable authentication with Microsoft Entra ID  
- ❌ To permanently store the unwrapped encryption key  
- ✅ To encrypt sensitive information at rest  

---

> Summary: 

- ✅ Explain the benefits of using **Azure App Configuration**  
- ✅ Describe how Azure App Configuration **stores information**  
- ✅ Implement **feature management**  
- ✅ Securely **access your app configuration** information  
- ✅ Retrieve **configuration settings** from Azure App Configuration  

> Azure App Configuration centralizes and secures application settings, supports feature management, and makes it easy to store and retrieve configuration data.

--- ⛸️  footer HA ---

