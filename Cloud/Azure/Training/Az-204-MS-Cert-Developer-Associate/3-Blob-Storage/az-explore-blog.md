

# Module: Introduction to Azure Blob Storage

Azure Blob Storage is Microsoft’s cloud-based solution for storing large amounts of **unstructured data**.  
It’s versatile and can be used for:  
- Serving images or documents to a browser  
- Storing files for distributed access  
- Streaming video and audio  

---

## Topics Covered
1. **Understanding Azure Blob Storage**  
   - Features  
   - Types of Storage Accounts  
   - Access Tiers  

2. **Understanding Azure Blob Storage**  
   - Storage Accounts  
   - Containers  
   - Blobs  

3. **Understanding Azure Storage Security and Encryption Features**


# Explore Azure Blob Storage  

**Module**  
**Progress:** 2 of 6 units completed  

Learn the core features and functionality of **Azure Blob Storage**.  

### Units  
- Introduction  
- Explore Azure Blob storage  
- Discover Azure Blob storage resource types  
- Explore Azure Storage security features  
- Module assessment  
- Summary  


> Azure Blob Storage is Microsoft’s cloud-based object storage solution optimized for massive amounts of unstructured data, such as text, media, or logs. It supports use cases like serving files to browsers, streaming content, backup and recovery, and analytics, with access available through REST APIs, CLI, PowerShell, or client libraries. Storage accounts offer standard and premium tiers with multiple redundancy and access options (Hot, Cool, Cold, Archive) to balance performance and cost based on usage patterns.

> Azure Blob Storage has three main resource types: storage accounts, containers, and blobs. A storage account provides a unique namespace and base endpoint for storing data, containers act like directories to organize blobs, and blobs are the actual data objects. Blobs come in three types: 
* block blobs for general data storage, 
* append blobs for log-like workloads, 
* page blobs for random-access files like virtual hard disks.

> Azure Storage automatically encrypts all data at rest using 256-bit AES encryption, ensuring compliance and security without requiring code changes. By default, encryption uses Microsoft-managed keys, but you can also choose customer-managed keys stored in Azure Key Vault or customer-provided keys for granular control. Additionally, client-side encryption is supported via SDKs, allowing data to be encrypted before upload and decrypted after download for extra security.

* Version 1 uses Cipher Block Chaining (CBC) mode with AES and Version 2 uses Galois/Counter Mode (GCM) mode with AES


#### Azure Blob Storage Knowledge Check

1. **Which of the following types of blobs are used to store virtual hard drive files?**  
   - Block blobs  
   - Append blobs  
   - ✅ Page blobs  

---

2. **Which of the following types of storage accounts is recommended for most scenarios using Azure Storage?**  
   - ✅ General-purpose v2  
   - General-purpose v1  
   - FileStorage  

---

3. **What is the maximum size of data that a block blob in Azure Blob storage can store?**  
   - 8-TB  
   - Unlimited  
   - ✅ 190.7-TiB  

---

4. **What are the two versions of client-side encryption available in the Azure Blob Storage and Queue Storage client libraries?**  
   - ✅ Version 1 uses Cipher Block Chaining (CBC) mode with AES and Version 2 uses Galois/Counter Mode (GCM) mode with AES  
   - Version 1 uses Advanced Encryption Standard (AES) and Version 2 uses Federal Information Processing Standards (FIPS)  
   - Version 1 uses Galois/Counter Mode (GCM) mode with AES and Version 2 uses Cipher Block Chaining (CBC) mode with AES  


### Summary

- Understanding Azure Blob Storage: Features, Types of Storage Accounts, and Access Tiers
- Understanding Azure Blob Storage: Storage Accounts, Containers, and Blobs
- Understanding Azure Storage Security and Encryption Features