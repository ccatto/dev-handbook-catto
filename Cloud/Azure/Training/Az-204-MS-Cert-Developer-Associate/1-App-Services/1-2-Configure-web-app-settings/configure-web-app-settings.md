# Configure web app settings

**Module**  
0 of 8 units completed  

Learn how to create and manage application settings, install SSL/TLS certificates to secure web traffic, enable diagnostic logging, create virtual app to directory mappings, and manage app features.

---

## Units

- Introduction  
- Configure application settings  
- Configure general settings  
- Configure path mappings  
- Enable diagnostic logging  
- Configure security certificates  
- Module assessment  
- Summary

> # Configure Application Settings in Azure App Service  

In Azure App Service, app settings and connection strings are stored as encrypted environment variables that override local configuration files and automatically restart the app when changed. Settings can be added individually or in bulk (JSON format), support deployment slot stickiness, and follow naming rules (: → __, . → _). For custom containers, environment variables can be passed using Azure CLI/PowerShell and verified via the SCM endpoint.

---

## 🔧 App Settings
- Stored as **encrypted key-value pairs**, passed as **environment variables** at startup.  
- **Linux/custom containers** → passed with `--env`.  
- **Editing triggers app restart**.  
- **Naming rules**:  
  - Allowed: letters, numbers, `.`, `_`  
  - Replace `:` with `__` (double underscore)  
  - Replace `.` with `_` (single underscore)  
- **Portal path**: *Environment variables > Application settings*  
- **Deployment slots**: settings can be *slot-specific (sticky)*.  
- **Bulk edit format (JSON)**:
  ```json
  [
    {
      "name": "<key-1>",
      "value": "<value-1>",
      "slotSetting": false
    },
    {
      "name": "<key-2>",
      "value": "<value-2>",
      "slotSetting": false
    }
  ]
```


> In Azure App Service, the General settings let you configure stack, platform, and security options for your app. You can set runtime stack versions, platform features like 32/64-bit, HTTP/2, WebSockets, Always On, and ARR affinity, as well as enforce HTTPS, TLS versions, and client certificates. Some features (like Always On or certain stacks) require higher pricing tiers.

> In Azure App Service, the Path mappings section lets you configure how requests and storage are handled. For Windows apps, you can set up handler mappings to process specific file extensions and define virtual directories/applications relative to the app root. For Linux and containerized apps, you can mount Azure Storage (Blobs or Files) into the container at a specified path, with options for basic or advanced configuration.

> Azure App Service provides built-in diagnostic logging to help debug applications by capturing application logs, web server logs, error messages, failed request traces, and deployment logs across Windows and Linux platforms. You can enable logging via the Azure portal or CLI, configure storage (file system or Azure Blob), and choose log levels ranging from Error to Verbose. Logs can be accessed directly, streamed live, or downloaded in ZIP format for further analysis.

> Azure App Service allows you to secure your applications using various types of certificates, including free managed certificates, purchased certificates, or certificates imported from Azure Key Vault or uploaded manually. The free App Service managed certificate is ideal for simple custom domain security, offering automatic renewal but with limitations such as no wildcard support or exportability. When using private certificates, they must meet specific encryption and trust requirements, and any certificate used must be bound to a custom domain with proper TLS settings.

--- 

# Quiz: App Configuration & Logging

---

### 1. In which of the following app configuration settings categories would you set the stack and SDK version?

- [ ] Application settings  
- [ ] Path mappings  
- [x] General settings ✅ **Correct**

---

### 2. Which of the following types of application logging is supported on the Linux platform?

- [ ] Web server logging  
- [ ] Failed request tracing  
- [x] Deployment logging ✅ **Correct**

