# Implement Azure Container Apps  

Learn how Azure Container Apps can help you deploy and manage microservices and containerized apps on a serverless platform that runs on top of Azure Kubernetes Service.  

## Learning objectives  
After completing this module, you'll be able to:  

- Describe the benefits of Azure Container Instances and how resources are grouped  
- Deploy a container instance in Azure by using the Azure CLI  
- Start and stop containers using policies  
- Set environment variables in your container instances  
- Mount file shares in your container instances  

## Units  
- Introduction  
- Explore Azure Container Apps  
- Exercise - Deploy a container to Azure Container Apps with the Azure CLI  
- Explore containers in Azure Container Apps  
- Implement authentication and authorization in Azure Container Apps  
- Manage revisions and secrets in Azure Container Apps  
- Explore Dapr integration with Azure Container Apps  
- Module assessment  
- Summary  

---

> Introduction ✅  

Azure Container Apps is a serverless container service that supports microservice applications and robust autoscaling capabilities without the overhead of managing complex infrastructure.  

## Learning objectives  
After completing this module, you'll be able to:  
- Describe the features and benefits of Azure Container Apps  
- Deploy a container app in Azure by using the Azure CLI  
- Utilize Azure Container Apps built-in authentication and authorization  
- Create revisions and implement app secrets  

----

> Explore Azure Container Apps  ✅

Azure Container Apps is a serverless platform for running microservices and containerized apps on top of Azure Kubernetes Service. It supports API hosting, background jobs, event-driven processing, and microservices with dynamic autoscaling (via KEDA).

## Key Capabilities
- Autoscaling (scale-to-zero on supported triggers)  
- HTTPS ingress, internal ingress, and service discovery  
- Blue/Green and A/B traffic splitting  
- Native Dapr integration for building microservices  
- Secrets management and logging with Azure Log Analytics  
- Support for multiple revisions and lifecycle management  

## Container Apps Environments
Apps are deployed into **Container Apps environments**, which act as secure boundaries with shared networks and logging.  
- Use the same environment when you want related services to share a network, Dapr configuration, or log analytics workspace.  
- Use different environments when you need strict isolation between applications or services.  

## Microservices & Dapr
Azure Container Apps supports 
* microservices with independent scaling and versioning, 
* **Dapr adds observability, service-to-service communication, retries, and pub/sub messaging** for richer distributed systems. 

---

> Exercise - Deploy a container to Azure Container Apps with the Azure CLI ✅


In this exercise, you deploy a containerized application to Azure Container Apps using the Azure CLI. You’ll create a container app environment, deploy your container, and verify that your application is running in Azure.  

## Tasks Performed
- Create resources in Azure  
- Create an Azure Container Apps environment  
- Deploy a container app to the environment  

[Deploy a container to Azure Container Apps with the Azure CLI](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-container-services/03-deploy-to-container-apps.html)

---

> Explore containers in Azure Container Apps ✅

Azure Container Apps abstracts away Kubernetes orchestration, letting you run any Linux-based x86-64 container image without managing infrastructure. Containers automatically restart on crashes and can be configured with CPU, memory, environment variables, secrets, probes, and volume mounts via ARM templates.  

You can also run **multiple containers in a single app** (sidecar pattern), though typically each microservice is deployed as its own container app. Images can be pulled from private registries by securely storing credentials in Container Apps configuration.  

⚠️ **Limitations**:  
- No privileged containers  
- Linux-based (linux/amd64) images only  

---

> Implement authentication and authorization in Azure Container Apps ✅

Azure Container Apps includes **built-in authentication and authorization** to secure external ingress-enabled apps with minimal or no code. It works with multiple federated identity providers and should always be used with **HTTPS** (disable `allowInsecure`).  

### Key Features
- No SDK, language, or security expertise required  
- Configure to either **require authentication** or **allow unauthenticated access**  
- Middleware runs as a **sidecar container**, intercepting requests, managing sessions, and injecting identity info into HTTP headers  

### Identity Providers
- Microsoft Identity Platform (`/.auth/login/aad`)  
- Facebook (`/.auth/login/facebook`)  
- GitHub (`/.auth/login/github`)  
- Google (`/.auth/login/google`)  
- X/Twitter (`/.auth/login/twitter`)  
- Any OpenID Connect provider (`/.auth/login/<providerName>`)  

### Authentication Flow
- **Server flow**: Container Apps handles sign-in with the provider (common for browser apps).  
- **Client flow**: App signs in with provider SDK, then passes the token to Container Apps (common for native or headless apps).  

---

> Manage revisions and secrets in Azure Container Apps ✅

Azure Container Apps manages **versioning** with **revisions**, which are immutable snapshots of a container app. Revisions allow you to:  
- Release new versions or roll back to earlier ones  
- Control which revisions are active and how traffic is routed  
- Customize revision names with suffixes (default names include random strings)  

### Managing Revisions
- New revisions are created when making **revision-scope changes** (e.g., image updates, environment variables, scaling).  
- Use Azure CLI:  
  - `az containerapp update` → update app and trigger new revision if needed  
  - `az containerapp revision list` → list all revisions  

### Managing Secrets
- Secrets store **sensitive values** (e.g., connection strings) securely at the app level.  
- Key properties:  
  - Secrets are **application-scoped**, not revision-scoped  
  - Updating/deleting a secret doesn’t auto-update revisions  
  - Revisions can reference the same secret  
- To apply changes, either **deploy a new revision** or **restart an existing revision**.  
- Azure Key Vault isn’t directly integrated, but you can use **managed identity + SDK**.  

### CLI Example
```bash
az containerapp create \
  --resource-group "my-resource-group" \
  --name queuereader \
  --environment "my-environment-name" \
  --image demos/queuereader:v1 \
  --secrets "queue-connection-string=$CONNECTION_STRING" \
  --env-vars "ConnectionString=secretref:queue-connection-string"
```


### Revisions vs. Secrets

| Feature    | Revisions 🌀 | Secrets 🔑 |
|------------|--------------|------------|
| Scope      | Versioned snapshot | App-level (shared) |
| Changes    | Create new revision | No new revision |
| Use case   | Deploy / roll back versions | Store sensitive values |

---

> Explore Dapr Integration with Azure Container Apps  

Dapr (Distributed Application Runtime) simplifies building distributed, microservice-based apps with features like pub/sub messaging, secure service-to-service calls, state management, and observability. Azure Container Apps provides a **managed Dapr integration**, handling upgrades and exposing simplified APIs to boost developer productivity.

#### Key Dapr APIs
- **Service-to-service invocation**: Secure, reliable calls with mTLS.  
- **State management**: Transactions and CRUD operations.  
- **Pub/sub**: Event-driven communication via brokers.  
- **Bindings**: Trigger apps from events.  
- **Actors**: Scale burst-heavy workloads.  
- **Observability**: Tracing with Application Insights.  
- **Secrets & Configuration**: Access secure values and config stores.  

#### Core Concepts
- Dapr runs as a **sidecar** (HTTP 3500 / gRPC 50001).  
- Components provide pluggable functionality and can be **shared or scoped** to specific apps.  
- Enabled and configured via **CLI, IaC templates, or the Azure portal**.  

👉 In short: Dapr integration brings **scalable, event-driven microservices** to Azure Container Apps without extra infrastructure overhead.

---

### Quiz: Azure Container Apps  

1. **Which of the following options is true about the built-in authentication feature in Azure Container Apps?**  
- It can only be configured to restrict access to authenticated users.  
- ✅ It allows for out-of-the-box authentication with federated identity providers.  
- It requires the use of a specific language or SDK.  

2. **What is a revision in Azure Container Apps?**  
- A dynamic snapshot of a container app version.  
- A version of a container app that is actively being used.  
- ✅ An immutable snapshot of a container app version.  

---

> Summary

In this module, you learned how to:  

- Describe the features and benefits of Azure Container Apps  
- Deploy a container app in Azure by using the Azure CLI  
- Utilize Azure Container Apps built-in authentication and authorization  
- Create revisions and implement app secrets  

----
