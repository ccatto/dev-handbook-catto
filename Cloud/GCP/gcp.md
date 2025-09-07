# GCP docs

# GCP Developer Handbook - Catto

This folder contains notes, quick-start guides, and best practices for commonly used Google Cloud Platform services, focused on C# Web API backends, TypeScript front ends, and cloud architecture.

---

## Core GCP Services

### Compute
- **App Engine** – Platform-as-a-Service for hosting web apps and APIs, supports .NET, Node.js, Python. Handles scaling automatically.  
- **Cloud Functions** – Serverless, event-driven compute. Great for:
  - Pub/Sub processing
  - File/image/csv processing
  - Background jobs  
- **Cloud Run** – Fully managed container hosting (serverless Docker containers).  
- **Compute Engine** – Virtual machines for full control when needed.  

### Storage
- **Cloud Storage** – Object storage for assets, media, and backups (similar to S3/Blob Storage).  
- **Filestore** – Managed file storage for apps needing shared file systems.  
- **Pub/Sub** – Messaging for event-driven architectures and serverless triggers.  

### Database
- **Cloud SQL** – Managed relational databases (PostgreSQL, MySQL, SQL Server).  
- **Firestore / Datastore** – NoSQL document database for flexible schemas.  
- **BigQuery** – Data warehouse for analytics (optional, for reporting).  

### Identity & Security
- **Cloud IAM** – Roles and permissions for resources.  
- **Secret Manager** – Secure storage for API keys, secrets, and credentials.  
- **Cloud Identity** – Authentication and user management.  

### Networking & CDN
- **Cloud CDN** – Content Delivery Network for caching and global distribution.  
- **Cloud DNS** – Domain registration and routing.  
- **Load Balancing** – Global or regional load balancers for apps and APIs.  

### DevOps / Monitoring
- **Cloud Build** – CI/CD pipelines for deploying backend and frontend apps.  
- **Cloud Monitoring / Logging** – Telemetry, metrics, and alerting for your apps.  
- **Deployment Manager / Terraform** – Infrastructure-as-Code management.  


