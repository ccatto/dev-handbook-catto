# 🗝️ Implement Azure Key Vault  

> Learn how Azure Key Vault can help you keep your apps more secure, and how to set and retrieve secrets programmatically, and with Azure CLI.

## Units
- Introduction  
- Explore Azure Key Vault  
- Discover Azure Key Vault best practices  
- Authenticate to Azure Key Vault  
- Exercise - Create and retrieve secrets from Azure Key Vault  
- Module assessment  
- Summary  

---
> 🔐 Introduction  

Azure Key Vault is a cloud service for securely storing and accessing secrets.  
A *secret* can be anything you want to tightly control access to, such as:  
- 🔑 API keys  
- 🔒 Passwords  
- 📜 Certificates  
- 🧮 Cryptographic keys  

---

## 🎯 Learning outcomes  
After completing this module, you'll be able to:  
- 🌟 Describe the benefits of using Azure Key Vault  
- 🪪 Explain how to authenticate to Azure Key Vault  
- 📥 Create and retrieve secrets from Azure Key Vault  

---

> 🔎 Explore Azure Key Vault  
 
Azure Key Vault supports two main container types:  
- 🗄️ **Vaults** – store software & HSM-backed keys, secrets, and certificates.  
- 🛡️ **Managed HSM pools** – store HSM-backed keys only.  

It provides secure management for 🔑 secrets, 🔒 keys, and 📜 certificates.  
Service tiers include **Standard** (software encryption) and **Premium** (HSM-protected).  

---

## ✨ Key Benefits  
- 📌 **Centralized secrets** – store app secrets securely, accessible via URIs.  
- 🔐 **Strong security** – authentication via Microsoft Entra ID, authorization via Azure RBAC or Key Vault access policies.  
- 📊 **Monitoring** – enable logging, archive to storage, stream to event hubs, or integrate with Azure Monitor.  
- ⚙️ **Simplified administration** – supports lifecycle management, auto-scaling, regional replication, and automated SSL/TLS certificate enrollment & renewal.  

---

## 🎯 Learning outcome  
You now understand how Azure Key Vault provides centralized, secure, and scalable management for secrets, keys, and certificates.  

---

> 🛡️ Discover Azure Key Vault Best Practices  

Azure Key Vault securely stores 🔑 secrets (API keys, passwords, certificates). A **vault** is a logical group of secrets.  

---

## 🔑 Authentication Options  
- 👤 **Managed identities (✅ recommended)** – no secret rotation required, Azure handles it.  
- 📜 **Service principal + certificate** – works, but manual rotation needed.  
- 🔐 **Service principal + secret** – ❌ not recommended, hard to rotate securely.  

---

## 🔒 Security in Transit  
- Enforces **TLS** for strong authentication, privacy, and integrity.  
- Uses **Perfect Forward Secrecy (PFS)** + **RSA 2048-bit encryption** for extra protection.  

---

## 📌 Best Practices  
- 🗂️ Use **separate key vaults** per app & environment.  
- 👥 **Control access** – only allow authorized apps/users.  
- 💾 **Backup regularly** when secrets/keys/certs are updated.  
- 📊 **Enable logging & alerts** for monitoring.  
- ♻️ Enable **soft-delete & purge protection** to guard against accidental or malicious deletions.  

---

## 🎯 Learning Outcome  
You learned how to securely manage Key Vault authentication, enforce encryption, and follow best practices to protect sensitive data.  

---

> 🔐 Authenticate to Azure Key Vault  

Authentication with **Microsoft Entra ID** validates the identity of a **security principal** (anything requesting access to Azure resources).  

---

## 👥 Types of Security Principals  
- 🙋 **Users** – Real people with accounts in Microsoft Entra ID.  
- 👥 **Groups** – Collections of users; permissions apply to all members.  
- ⚙️ **Service Principals** – Represent apps or services (like a “user account” for an app).  

---

## ⚡ Service Principal Options  
- ✅ **Managed Identity (recommended)** – Azure creates/manages the identity; no credentials stored. Works with App Service, Functions, VMs.  
- 📝 **Manual Registration** – Register the app in Entra ID to create a service principal and app object.  

> 💡 **Best Practice:** Use a **system-assigned managed identity**.  

---

## 💻 Authentication in Code  
- Use the **Azure Identity client library** for seamless authentication across environments.  
  - SDKs available for: **.NET | Python | Java | JavaScript**  

---

## 🌐 Authentication with REST  
- Send **access tokens** in the `Authorization` header:  
  ```http
  PUT /keys/MYKEY?api-version=<api_version> HTTP/1.1  
  Authorization: Bearer <access_token>
```
---

> 🧪 Exercise – Create and Retrieve Secrets from Azure Key Vault  

In this exercise, you practiced working with **Azure Key Vault** by creating a vault, storing secrets, and building a .NET app to interact with it.  

## 🔨 Key Tasks  
1. 📦 **Create Azure Key Vault resources**  
2. 🔑 **Store a secret** using **Azure CLI**  
3. 💻 **Develop a .NET console app** to create & retrieve secrets  
4. 🧹 **Clean up resources** after testing  

[Create and retrieve secrets from Azure Key Vault](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-secure-solutions/01-key-vault-store-retrieve.html)

---

> 🔐 Azure Key Vault Quiz

1. **Which of the below methods of authenticating to Azure Key Vault is recommended for most scenarios?**  
- Service principal and certificate  
- Service principal and secret  
- ✅ Managed identities  

---

2. **Azure Key Vault protects data when it's traveling between Azure Key Vault and clients. What protocol does it use for encryption?**  
- Secure Sockets Layer  
- ✅ Transport Layer Security  
- Presentation Layer  

---

> 📖 Summary  

In this module, you learned how to:  

- 🔐 Describe the benefits of using **Azure Key Vault**  
- 🛡️ Explain how to **authenticate to Azure Key Vault**  
- 🔑 Create and retrieve **secrets from Azure Key Vault**  

---
🦶 Made it to the footer 👣
*** 👣 Walk on ***

