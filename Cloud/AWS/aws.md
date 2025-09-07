# AWS Catto Developer Handbook 

This folder contains notes, quick-start guides, and best practices for commonly used AWS services, focused on web APIs, cloud architecture, and full-stack development.

---

## Core AWS Services

### Compute
- **Lambda** – Serverless, event-driven compute. Great for:
  - Pub/Sub processing
  - SMS notifications
  - File/image/csv processing
- **Elastic Beanstalk** – Simple hosting for web apps and APIs. Handles deployment, scaling, and monitoring.
- **ECS (Elastic Container Service)** – Run Docker containers at scale.
- **Fargate** – Serverless container execution (works with ECS or EKS).

### Storage
- **S3** – Object storage for assets, media files, and backups.
- **EBS** – Block storage for EC2 instances.
- **Glacier** – Low-cost archival storage.

### Database
- **RDS** – Managed relational databases (MySQL, PostgreSQL, SQL Server, etc.).
- **DynamoDB** – Managed NoSQL database.

### Networking & CDN
- **Route 53** – Domain registration, routing, and DNS management.
- **CloudFront** – Global Content Delivery Network (CDN) for caching assets.

### Identity & Security
- **IAM** – User, role, and permission management.
- **Cognito** – Authentication and user management for apps.

### Application Services / DevOps
- **API Gateway** – Expose REST or WebSocket APIs with Lambda integration.
- **CloudWatch** – Monitoring, logging, and alarms.
- **CloudFormation** – Infrastructure as code.
- **Amplify** – Simple hosting and CI/CD for front-end apps.

### Containers & Orchestration
- **EKS** – Kubernetes managed cluster.
- **ECS + Fargate** – Lightweight container orchestration without managing servers.

---

## Tips
1. Group resources by environment: dev, staging, prod.  
2. Use **IAM roles** carefully to follow least-privilege principle.  
3. Monitor **Lambda** timeouts and memory allocation to avoid unexpected costs.  
4. S3 buckets should have **versioning** and optionally **lifecycle rules** for cleanup.  

---


