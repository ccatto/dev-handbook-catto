# Azure Catto Developer Handbook

This folder contains notes, quick-start guides, and best practices for commonly used Azure services, focused on C# Web API backends, TypeScript front ends, and cloud architecture.

---

## Core Azure Services

### Compute
- **App Service** – Host web apps and APIs easily, supports .NET, Node.js, Python. Handles scaling, deployments, and monitoring.
- **Azure Functions** – Serverless, event-driven compute. Great for:
  - Pub/Sub processing
  - Background jobs
  - File/image/csv processing
- **Azure Container Apps / AKS** – Run containers in a managed environment.  
- **VMs (Virtual Machines)** – Full control over servers when needed.  

### Storage
- **Blob Storage** – Object storage for assets, images, CSVs, backups.  
- **File Storage** – Managed SMB file shares.  
- **Queue Storage** – Messaging between services.  

### Database
- **Azure SQL Database** – Managed relational SQL (best for C# Web API backend).  
- **Cosmos DB** – NoSQL, globally distributed database for flexible schemas.  
- **Azure Database for PostgreSQL / MySQL** – Managed relational DBs if you prefer open-source engines.  

### Identity & Security
- **Azure Active Directory (AAD)** – Authentication and authorization.  
- **Managed Identity** – Assign roles to Azure resources without secrets.  
- **Key Vault** – Store secrets, certificates, and keys securely.  

### Networking & CDN
- **Azure Front Door / CDN** – Global content delivery, caching, and routing.  
- **Azure DNS** – Domain routing and management.  
- **Application Gateway** – Load balancing and web application firewall.  

### DevOps / Monitoring
- **Azure DevOps Pipelines** – CI/CD pipelines for backend and frontend apps.  
- **App Insights (Application Insights)** – Telemetry, logging, performance monitoring.  
- **Monitor** – Metrics, alerts, and dashboards for all resources.  


