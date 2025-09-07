# AWS RDS Overview Relational Database Service

**AWS RDS (Relational Database Service)** is a managed database service similar to Azure SQL Database. It allows you to run relational databases in the cloud without managing the underlying infrastructure. For a **C# Web API + Angular frontend** architecture, here’s a breakdown of common RDS usage and related services:

---

## 🔹 Compute / Hosting

* **Amazon EC2**

  * Hosts C# Web API if you prefer full control over the server.
* **AWS Elastic Beanstalk**

  * Managed service to deploy and scale C# Web API apps automatically.
* **AWS Lambda**

  * Serverless option for lightweight API endpoints or background tasks.
* **Amazon S3 + CloudFront**

  * Hosts Angular frontend (S3 for static files, CloudFront for CDN and caching).

---

## 🔹 Databases (RDS)

* **RDS Supported Engines:**

  * **SQL Server** (common for .NET apps)
  * **PostgreSQL**
  * **MySQL**
  * **MariaDB**
  * **Oracle**
* **Multi-AZ Deployment**

  * High availability with automatic failover.
* **Read Replicas**

  * Horizontal scaling for read-heavy workloads.
* **RDS Proxy**

  * Connection pooling for better database performance and resilience.

---

## 🔹 Networking & Security

* **Amazon VPC**

  * Private network to securely host RDS instances and APIs.
* **Security Groups & NACLs**

  * Control inbound/outbound traffic to your RDS instance.
* **AWS Secrets Manager**

  * Securely store database credentials for your Web API.

---

## 🔹 Monitoring & DevOps

* **Amazon CloudWatch**

  * Monitor RDS performance, set alarms for CPU, memory, or storage.
* **AWS CloudTrail**

  * Track API activity and changes to RDS instances.
* **AWS CodePipeline / CodeBuild**

  * CI/CD for deploying C# Web API to Elastic Beanstalk or EC2.

---

## 🔹 Typical Architecture (C# Web API + Angular Frontend with RDS)

```
[ Angular App ]  --->  [ S3 + CloudFront ]
         |
         v
   [ C# Web API on Elastic Beanstalk / EC2 / Lambda ]
         |
         v
   [ AWS RDS (SQL Server / PostgreSQL / MySQL) ]
         |
         v
   [ Optional: Redis Cache / S3 Storage ]
```

---

✅ **Summary:**
For a **C# Web API + Angular frontend** on AWS:

* **Frontend** → Angular hosted in **S3 + CloudFront**
* **Backend** → C# Web API hosted in **Elastic Beanstalk / EC2 / Lambda**
* **Database** → **RDS** (SQL Server recommended for .NET apps)
* **Security** → **VPC + Security Groups + Secrets Manager**
* **Monitoring** → **CloudWatch + CloudTrail**
