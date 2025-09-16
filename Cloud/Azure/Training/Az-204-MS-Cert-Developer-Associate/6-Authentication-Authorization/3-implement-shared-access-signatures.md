## 📌 Implement shared access signatures  
**Module**  
0 of 6 units completed  

Learn how to use shared access signatures to authorize access to storage resources.  

### Units  
- Introduction  
- Discover shared access signatures  
- Choose when to use shared access signatures  
- Explore stored access policies  
- Module assessment  
- Summary  

---

> 6.3.1 📘 Introduction

A **Shared Access Signature (SAS)** is a URI that grants restricted access rights to **Azure Storage resources**.  
You can provide a SAS to clients to delegate access to specific storage account resources.  

### 🎯 Learning Objectives
After completing this module, you'll be able to:  
- Identify the **three types** of shared access signatures  
- Explain **when to implement** shared access signatures  
- Create a **stored access policy**  

---

> 6.3.2 🔐 Discover Shared Access Signatures (SAS)

A **Shared Access Signature (SAS)** is a signed URI that grants restricted access to Azure Storage resources.  
It includes a token with query parameters that define permissions, duration, and scope of access.  
The signature is generated from SAS parameters and signed with the key used to create it, ensuring Azure can authorize access.

---

## 🏷️ Types of SAS
- **User Delegation SAS** → Secured with Microsoft Entra credentials; applies to **Blob storage only**.  ‼️
- **Service SAS** → Secured with a storage account key; grants access to **Blob, Queue, Table, or File storage**.  
- **Account SAS** → Secured with a storage account key; delegates access to multiple storage services and supports all operations.

> ✅ Best practice: Use **Microsoft Entra credentials** and user delegation SAS whenever possible for stronger security.

---

## ⚙️ How SAS Works
A SAS requires:  
1. **Resource URI** → Path to the Azure Storage resource.  
2. **SAS Token** → Defines permissions and conditions for access.  

Example SAS structure:  

- **sp** = Permissions (e.g., `r` for read, `w` for write)  
- **st** = Start time  
- **se** = Expiry time  
- **sv** = Storage API version  
- **sr** = Resource type (e.g., `b` for blob)  
- **sig** = Cryptographic signature  

---

## ✅ Best Practices
- Always use **HTTPS** to prevent man-in-the-middle attacks.  
- Prefer **user delegation SAS** over account keys.  
- Set **short expiration times** for SAS tokens.  
- Apply **least privilege** access (only grant what’s needed).  
- Consider a **middle-tier service** when SAS poses unacceptable risks.  

---

### 📌 Summary  
Shared Access Signatures (SAS) provide flexible, time-bound, and permission-controlled access to Azure Storage, but must be carefully managed for security.  

---

> 6.3.3 📌 Choose When to Use Shared Access Signatures (SAS)

A **Shared Access Signature (SAS)** provides secure, time-bound access to storage account resources for clients who don't otherwise have permissions.

---

## 🏗️ Common Scenarios

### 1. **Front-End Proxy Service**
- Clients upload/download data via a **proxy service** that handles authentication.  
- ✅ Allows validation of business rules.  
- ⚠️ Can be expensive/difficult to scale for large data volumes.

### 2. **SAS Provider Service**
- A **lightweight service** authenticates clients and issues SAS tokens.  
- Clients then access storage **directly**, reducing the need for proxy data routing.  
- ✅ Scales efficiently, but offers less business rule enforcement.

👉 Many real-world solutions use a **hybrid approach**, combining both proxy validation and direct SAS access.

---

## 📂 Copy Operations Requiring SAS
- **Blob → Blob (different accounts):** SAS required for source, optional for destination.  
- **File → File (different accounts):** SAS required for source, optional for destination.  
- **Blob ↔ File (same or different accounts):** SAS required for the source object.

---

### ✅ Summary
Use a SAS when you need secure, controlled access to Azure Storage resources—especially for direct client access or cross-account copy operations.  

---

> 6.3.4 📌 Explore Stored Access Policies

A **stored access policy** adds an extra layer of control over service-level SAS by grouping them and applying server-side restrictions. It allows you to adjust start time, expiry time, or permissions—or revoke SAS entirely after issuance.

---

## 🔑 Supported Resources
- Blob containers  
- File shares  
- Queues  
- Tables  

---

## ⚙️ Creating a Stored Access Policy
- Defined by **start time, expiry time, and permissions**.  
- Parameters can be set in the **SAS token**, the **policy**, or a **combination** (but not duplicated).  
- Created via `Set ACL` operations with a **unique identifier** (up to 64 chars).  

**Examples:**  
- **.NET:** `BlobSignedIdentifier` with `BlobAccessPolicy`.  
- **CLI:** `az storage container policy create ...`  

---

## 🔄 Modify or Revoke
- **Modify** → update ACL with new permissions/times.  
- **Revoke** → delete policy, rename identifier, or set expiry in the past.  
- Changes take effect immediately, invalidating associated SAS.  

---

### ✅ Summary  
Stored access policies let you centrally manage, update, or revoke multiple SAS for added flexibility and security.  

---

> 6.3.5 ✅ Shared Access Signatures (SAS) Quiz

1. Which of the following types of shared access signatures (SAS) applies to **Blob storage only**?  
   - Account SAS  
   - Service SAS  
   - **User delegation SAS ✅**

---

2. Which of the following best practices provides the most flexible and secure way to use a service SAS?  
   - **Associate SAS tokens with a stored access policy ✅**  
   - Always use HTTPS  
   - Implement a user delegation SAS  

---

> 6.3.6 Summary  

In this module, you learned how to:  
- Identify the three types of shared access signatures  
- Explain when to implement shared access signatures  
- Create a stored access policy  

---

✅ **One-sentence summary:** You now understand SAS types, when to use them, and how to manage access securely with stored access policies.  

---

--- ⛸️ ---