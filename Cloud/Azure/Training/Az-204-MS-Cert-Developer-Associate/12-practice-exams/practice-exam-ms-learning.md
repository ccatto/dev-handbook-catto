# This is from a practice exam on Microsoft 

[Practice Assessment for Exam AZ-204: Developing Solutions for Microsoft Azure](https://learn.microsoft.com/en-us/credentials/certifications/azure-developer/practice/assessment?assessment-type=practice&assessmentId=35&practice-assessment-type=certification)

> Q1 Cosmos DB Consistency Level  

You manage a multiregion deployment of an Azure Cosmos DB account named **account1**.  

You need to configure the default consistency level for **account1**.  
The consistency level must **maximize throughput and minimize latency for write operations**.  

**Which consistency level should you use?**  


- bounded staleness  
- consistent prefix  
- ✅ eventual  
- session  

* The eventual consistency level maximizes throughput and minimizes latency. The bounded staleness consistency level provides lower throughput and higher latency comparing with the remaining answer choices. The consistent prefix consistency level provides higher throughput and lower latency for write operations than the session consistency level but lower throughput and higher latency than the eventual consistency levels. The session consistency level provides higher throughput and lower latency for write operations than the bounded staleness consistency level but lower throughput and higher latency than the eventual and consistent prefix consistency levels.

> Q2 Reading Azure Cosmos DB Change Feed with Push Model  

You need to read an **Azure Cosmos DB change feed** by using a **push model**.  

**Which two components can you use to achieve this goal?**  
_Each correct answer presents a complete solution._  

- ✅ Azure Functions with an Azure Cosmos DB trigger  
- ✅ Change feed processor library  
- Azure Functions with an Azure Event Grid trigger  
- Change feed pull model  

> Q3 # Monitoring Web App Response Times  

You have an **Azure web app** that occasionally experiences **high response times**.  

You need to be notified when the response time exceeds a certain threshold.  

**What should you do?**  
_Select only one answer._  

- Configure Azure Advisor alerts  
- Create a Resource Health alert in Azure Monitor  
- ✅ Implement Application Insights web tests and alerts  
- Use Azure Service Health to monitor the status of Azure services  

* Application Insights allows you to create web tests that simulate user interactions with your application and then set up alerts based on the results of these tests. Azure Monitor Resource Health alerts are used for infrastructure monitoring, not application performance. Azure Service Health provides information about Azure service issues and planned maintenance, not application performance. Azure Advisor provides best practice recommendations, not application performance alerts.

> Q # Quiz: Monitoring Real-Time Azure Integrations  

Your team is developing a new feature for an existing **Azure-based application** that relies heavily on **real-time data processing**. The feature involves integrating multiple Azure services and third-party APIs.  

You need to create a strategy to ensure that the integration of these services does not introduce any performance issues or failures. You need to design the monitoring solution to detect and address potential issues.  

**What should you do?**  
_Select only one answer._  

- Create a single availability test in Application Insights to monitor the endpoint of the new feature.  
- Deploy a custom logging solution to capture and review logs manually at the end of each day.  
- Schedule nightly runs of Azure Automation runbooks to check the health of each service individually.  
- ✅ Use Live Metrics in Application Insights to observe the activity of the deployed application in real-time.  

* Option D is correct because Live Metrics provides real-time observation of the application's activity, allowing for immediate detection and response to performance issues. Option C is incorrect as nightly checks may not be sufficient for real-time data processing needs. Option A is incorrect because a single availability test does not provide comprehensive monitoring of all integrated services. Option B is incorrect as manual review of logs is not efficient for real-time monitoring and may delay the response to issues.

---

> Question: Designing Global Monitoring for an E-commerce Platform  

An e-commerce platform is planning to **expand its services globally**. The platform is hosted on **Azure** and utilizes various Azure services and third-party integrations.  

You need to design and create a **robust monitoring solution** that can scale with the expansion and provide insights into the performance of the platform across different regions.  

**What should you do?**  
_Select only one answer._  

- ✅ Deploy multiple Application Insights instances for each region and use Azure Monitor to aggregate the data.  
- ❌ Implement a single Application Insights instance with default settings to monitor the entire platform.  
- ❌ Create web tests and alerts for each region within a single Application Insights instance.  
- ❌ Use manual instrumentation to log user activities and store them in Azure Blob Storage for later analysis.  

### Explanation  
- **Correct (A):** Multiple Application Insights instances allow localized monitoring, while Azure Monitor aggregates global insights.  
- **Incorrect (B):** A single instance may not scale for global monitoring.  
- **Incorrect (C):** Web tests/alerts alone aren’t sufficient for robust monitoring.  
- **Incorrect (D):** Blob Storage logs lack real-time monitoring and analysis.  

---

> Q: # Quiz: Ensuring Accurate Metrics in Application Insights  

A development team is using **Application Insights** to monitor their web application deployed on **Azure**. They have noticed **discrepancies in the reported metrics** due to high telemetry volume.  

You need to ensure that the reported metrics **accurately reflect the application's performance** without being affected by telemetry sampling.  

**What should you implement to achieve this goal?**  
_Select only one answer._  

- ✅ Configure Application Insights to use **preaggregated standard metrics** for dashboarding and real-time alerting.  
- ❌ Create a custom Kusto query in Application Insights to manually aggregate log-based metrics.  
- ❌ Disable all telemetry sampling in Application Insights to ensure all events are collected.  
- ❌ Increase the sampling rate in Application Insights to collect more data points for log-based metrics.  

### Explanation  
- **Correct (A):** Preaggregated standard metrics are **not affected by telemetry sampling** and ensure accurate real-time monitoring for dashboards and alerts.  
- **Incorrect (B):** Custom Kusto queries require manual aggregation and don’t solve the sampling impact.  
- **Incorrect (C):** Disabling sampling raises costs and doesn’t scale well.  
- **Incorrect (D):** Increasing the sampling rate still risks inaccuracies and higher costs.  

--

> Q: Choosing the Correct SAS Type  

You have an **Azure Storage account container** named `container1`.  

You need to configure access to the container to meet the following requirements:  
- The SAS token should be **secured with Microsoft Entra ID credentials**.  
- **Role-based access control (RBAC)** should be used.  
- The SAS token should support **granting access to containers**.  

**Which type of SAS should you use?**  
_Select only one answer._  

- ❌ account  
- ✅ user delegation  
- ❌ service  
- ❌ stored access policy  

### Explanation  
- **Correct (B):** A **user delegation SAS** is secured with Microsoft Entra ID credentials, supports RBAC, and grants access to containers.  
- **Incorrect (A):** An account SAS is secured with the account key, not Entra ID.  
- **Incorrect (C):** A service SAS applies to one storage service only and uses the account key.  
- **Incorrect (D):** A stored access policy adds restrictions to SAS tokens but does not provide Entra ID credential security or RBAC support.  

---

> Q: Optimizing Microsoft Graph Queries  

You plan to use **Microsoft Graph** to retrieve a list of users in a Microsoft Entra ID tenant.  

You need to optimize query results.  

**Which two query options should you use?**  
_Select all answers that apply._  

- ✅ $filter  
- ❌ $count  
- ❌ $orderby  
- ✅ $select  
- ❌ $expand  

### Explanation  
- **Correct:**  
  - `$filter` → Limits the results returned, reducing unnecessary data.  
  - `$select` → Restricts the attributes projected, making queries more efficient.  
- **Incorrect:**  
  - `$count` → Returns the total count of matching resources, not optimization.  
  - `$orderby` → Sorts results but doesn’t reduce payload.  
  - `$expand` → Retrieves related resources, increasing rather than optimizing the payload.  

---

> Granting App Permissions to Microsoft Graph  

You manage an **Azure App Service web app** named `app1`.  
`app1` is registered as a **multi-tenant application** in a Microsoft Entra ID tenant named `tenant1`.  

You need to grant `app1` the permission to access the Microsoft Graph API in `tenant1`.  

**Which service principal should you use?**  
_Select only one answer._  

- ❌ legacy  
- ❌ system-assigned managed identity  
- ✅ application  
- ❌ user-assigned managed identity  

### Explanation  
- **Correct:**  
  - The **application service principal** is used to configure permissions for `app1` in `tenant1` to access Microsoft Graph.  
- **Incorrect:**  
  - **Legacy** → Old app models, not relevant here.  
  - **System-assigned managed identity** → Tied to a resource lifecycle, not used for multi-tenant app permissions.  
  - **User-assigned managed identity** → Can be shared, but not used for granting Graph API permissions in this case.  

---

>  Question  
You manage a Microsoft Entra ID registered application named **app1**. App1 calls a web API, which then calls Microsoft Graph.  

You need to ensure the signed-in user identity is delegated through the request chain.  

**Which authentication flow should you use?**  

- Authorization code  
- **On-Behalf-Of ✅**  
- Client credentials  
- Implicit  

---

# Explanation  
This tests knowledge of accessing user data from Microsoft Graph, part of implementing authentication and authorization.  

The **OAuth 2.0 On-Behalf-Of (OBO) flow** is used when an application calls a web API, which in turn needs to call another API, propagating the delegated user identity and permissions through the request chain.  

- **Authorization code**: Used by apps on a device to gain access to protected resources.  
- **Client credentials**: Used by services to call other services with their own credentials (no user context).  
- **Implicit**: Browser-based, redirection flow not suitable for propagating user identity.  

✅ **Correct answer: On-Behalf-Of**  

---

> Question  
You plan to generate a shared access signature (SAS) token for **read access** to a blob in a storage account.  

You need to secure the token from being compromised.  

**What should you use?**  

- Primary account key  
- Secondary account key  
- **Microsoft Entra ID credentials assigned the Contributor role ✅**  
- Microsoft Entra ID credentials assigned the Reader role  

---

# Explanation  
This tests knowledge of **Azure Storage SAS tokens**.  

- **Best practice**: Use **Microsoft Entra ID credentials** to generate the SAS token, as they are more secure than account keys.  
- The account must have the `Microsoft.Storage/storageAccounts/blobServices/generateUserDelegationKey` permission.  
- This permission is included in built-in roles such as **Contributor**, **Storage Account Contributor**, **Storage Blob Data Contributor**, **Storage Blob Data Owner**, **Storage Blob Data Reader**, and **Storage Blob Delegator**.  
- **Account keys** (primary/secondary) can generate SAS tokens, but they are less secure and can be easily compromised.  
- **Reader role** doesn’t have the required permissions to generate a SAS.  

✅ **Correct answer: Microsoft Entra ID credentials assigned the Contributor role**  

---

> Question  
You manage an **Azure App Service web app** named `app1` and an **Azure Key Vault** named `vault1`.  

You need to ensure `app1` can authenticate and conduct operations with `vault1` **without managing secret rotation**.  
The resource required must be **deleted automatically** when the app is deleted.  

**Which authentication method should you use for app1?**  

- user-assigned managed identity  
- service principal and secret  
- service principal and certificate  
- **system-assigned managed identity ✅**  

---

# Explanation  
This tests knowledge of integrating **Azure App Service with Key Vault** for secure authentication.  

- **System-assigned managed identity** is tied to the lifecycle of the app. When the app is deleted, the identity is deleted automatically. No secrets need to be managed. ✅  
- **User-assigned managed identity** works but is independent of the app lifecycle and requires management.  
- **Service principal + secret** → requires manual secret rotation, not ideal.  
- **Service principal + certificate** → requires certificate management/rotation.  

✅ **Correct answer: System-assigned managed identity**  

* Use a **system-assigned managed identity** when you want app authentication tied to the app’s lifecycle with no secret rotation management required. ✅  

---

> Question  
You plan to create a **key namespace hierarchy** in Azure App Configuration.  

You need to separate individual key names.  

**Which character should you use?**  

- **: ✅**  
- *  
- ,  
- \  

---

# Explanation  
This tests knowledge of **key namespace hierarchy in Azure App Configuration**.  

- **Colon (:)** → Correct character to separate key names. ✅  
- **Asterisk (*)**, **comma (,)**, and **backslash (\\)** → Reserved characters and cannot be used for separation.  

✅ **Correct answer: :**  

# Summary  
Use the **colon (:)** to separate key names when creating a namespace hierarchy in Azure App Configuration. ✅  

---

> Question  
A company plans to use **Azure App Configuration** for feature flags in an application.  

The company has the following encryption requirements:  
- Customer-managed keys  
- Hardware Security Module (HSM)-protected keys  

**Which two tiers should you recommend?**  
*(Select all answers that apply)*  

- Azure App Configuration Free tier  
- **Azure App Configuration Standard tier ✅**  
- Azure Key Vault Standard tier  
- **Azure Key Vault Premium tier ✅**  

---

# Explanation  
This tests knowledge of **App Configuration and Key Vault service tiers**.  

- **App Configuration Standard** → Required for **customer-managed keys**.  
- **Key Vault Premium** → Required for **HSM-protected keys**.  
- **App Configuration Free** → Does **not** support customer-managed keys.  
- **Key Vault Standard** → Does **not** support HSM-protected keys.  

✅ **Correct answers: App Configuration Standard + Key Vault Premium**  

Summary  
For **customer-managed keys** and **HSM-protected keys**, use:  
- **Azure App Configuration Standard tier** ✅  
- **Azure Key Vault Premium tier** ✅  

---

> Question  
You need to generate a new version of a key stored in **Azure Key Vault**.  

**Which code segment should you use?**  
*(Select only one answer)*  

- `az keyvault key rotation-policy update -n mykey --vault-name mykeyvault --value path/to/policy.json`  
- `az keyvault key purge --name mykey --vault-name mykeyvault`  
- **`az keyvault key rotate --vault-name mykeyvault --name mykey` ✅**  
- `az keyvault key set-attributes --vault-name mykeyvault --name mykey –policy path/to/policy.json`  

---

# Explanation  
This tests knowledge of **key rotation with the Azure CLI**.  

- **Rotate** → Generates a **new version of the key** based on its policy.  
- **Rotation Policy Update** → Only updates the policy, does not create a new key version.  
- **Purge** → Permanently deletes a soft-deleted key.  
- **Set Attributes** → Updates properties of the key but doesn’t rotate it.  


---
### ✅ Summary  
Use **`az keyvault key rotate`** to generate a new version of an Azure Key Vault key.  

ref: [https://learn.microsoft.com/en-us/training/modules/control-azure-services-with-cli/](https://learn.microsoft.com/en-us/training/modules/control-azure-services-with-cli/)

---

> Question  

You are tasked with enhancing the security of an existing Azure web application.  
The app currently stores **sensitive configuration data** (connection strings, API keys) in its code, which raises security concerns.  

**Which two options can achieve this goal?**  
*(Select all answers that apply)*  

- Encrypt the sensitive data and store it within the application code, providing decryption keys to authorized personnel only ❌  
- **Migrate the sensitive configuration data to Azure Key Vault and utilize Managed Identities to securely access the secrets ✅**  
- Move the sensitive configuration data to a private GitHub repository and access it using GitHub credentials stored in the application settings ❌  
- **Store the sensitive configuration data in Azure App Configuration and restrict access using Azure role-based access control (RBAC) ✅**  

---

### Explanation  
- **Azure Key Vault + Managed Identities** → Secures secrets and removes credentials from code.  
- **Azure App Configuration + RBAC** → Safely manages app settings and enforces access control.  
- **Encrypting data in code** → Still insecure, as sensitive data remains in the codebase.  
- **Private GitHub repo** → Not secure; if credentials are compromised, secrets are exposed.  

---

### ✅ Summary  
Use **Azure Key Vault with Managed Identities** and **Azure App Configuration with RBAC** to securely manage sensitive app configuration data.  

---

> Question  
You manage a **multiregion deployment** of an Azure Cosmos DB account named `account1`.  

You need to configure the **default consistency level** for `account1`. The consistency level must **maximize throughput** and **minimize latency** for write operations.  

**Which consistency level should you use?**  
*(Select only one answer)*  

- bounded staleness ❌  
- consistent prefix ❌  
- **eventual ✅**  
- session ❌  

---

### Explanation  
- **Eventual consistency** → Best for **maximum throughput** and **lowest latency**, but offers the weakest consistency.  
- **Bounded staleness** → Stronger guarantees, but increases latency and lowers throughput.  
- **Consistent prefix** → Guarantees order but not immediate consistency; better than session but slower than eventual.  
- **Session** → Stronger than eventual and consistent prefix, but not optimal for max throughput/low latency.  

---

 

 > You need to read an Azure Cosmos DB change feed by using a push model.  
  
 Which two components can you use to achieve this goal? Each correct answer presents a complete solution.  
  
 Select all answers that apply.  

- **Azure Functions with an Azure Cosmos DB trigger ✅**  
- **Change feed processor library ✅**  
- Azure Functions with an Azure Event Grid trigger ❌  
- Change feed pull model ❌  

---

### Explanation  
- **Azure Functions with an Azure Cosmos DB trigger** → Connects to a container and automatically triggers on changes.  
- **Change feed processor library** → Implements the observer pattern and pushes changes to the client.  
- **Event Grid trigger** → Works on Event Grid events, not Cosmos DB change feed.  
- **Pull model** → Uses polling instead of push.  

### Summary  
Use **Azure Functions with Cosmos DB trigger** or the **Change feed processor library** for a push-based change feed model.  

## ✅ Summary  
Use **eventual consistency** in Cosmos DB when you want to **maximize throughput and minimize latency** across regions. 

---

> You manage an Azure Cosmos DB container named container1.  
> You need to use the **ReadItemAsync** method to read an item from the Azure Cosmos service.  

Which two parameters should you provide? Each correct answer presents part of the solution.  

Select all answers that apply.  

- consistencyLevel ❌  
- eTag ❌  
- **partitionKey ✅**  
- sessionToken ❌  
- **id ✅**  

---

### Explanation  
The `ReadItemAsync` method of the Cosmos DB .NET SDK requires **two mandatory parameters**:  
- **partitionKey** → specifies the logical partition where the item resides.  
- **id** → the unique identifier of the item.  

Other values such as `consistencyLevel`, `eTag`, and `sessionToken` are optional and provided via `RequestOptions`.  

### Summary of Learning Point  
To use `ReadItemAsync`, always provide the **item id** and the **partition key**.  

---

> You need to download blob content to a byte array by using an operation that automatically recovers from transient failures.  

Which code statement should you use?  

Select only one answer.  

- ❌  
```csharp
byte[] data;
BlobClient client = new BlobClient(new Uri("https://mystorageaccount.blob.core.windows.net/containers/blob.txt"), null);
Response<BlobDownloadResult> response = client.DownloadContent(data);
```

- ❌  
```csharp
BlobRequestOptions optionsWithRetryPolicy = new BlobRequestOptions();
byte[] destinationArray = blob.DownloadContent(index: 0, accessCondition: null, options: optionsWithRetryPolicy);
```

- ❌  
```csharp
byte[] data;
BlobClient client = new BlobClient(new Uri("https://mystorageaccount.blob.core.windows.net/containers/blob.txt"), null);
Response<BlobDownloadResult> response = client.DownloadContent();
data = response.Value.Content.ToArray();
```

- ✅  
```csharp
byte[] data;
BlobClientOptions options = new BlobClientOptions();
options.Retry.MaxRetries = 10;
options.Retry.Delay = TimeSpan.FromSeconds(20);
BlobClient client = new BlobClient(new Uri("https://mystorageaccount.blob.core.windows.net/containers/blob.txt"), options);
Response<BlobDownloadResult> response = client.DownloadContent();
data = response.Value.Content.ToArray();
```

---

### Explanation  
The correct code sets a retry policy using **BlobClientOptions** with properties like `Retry.MaxRetries` and `Retry.Delay`. This ensures the operation automatically recovers from transient failures while downloading blob content.  

Other code examples fail to configure retry strategies, making them less resilient.  

### Summary of Learning Point  
Use **BlobClientOptions with retry settings** (`MaxRetries`, `Delay`) when downloading blob content to ensure resiliency against transient errors.  

---

> Question 14: You need to transition blobs in the Hot access tier to an online tier if the blobs have not been modified in over 90 days.

Which code segment should you add to line 14?

```
 1  {
 2    "rules": [ 
 3      { 
 4        "name": "agingRule", 
 5        "enabled": true,
 6        "type": "Lifecycle", 
 7        "definition": { 
 8          "filters": { 
 9            "blobTypes": [ "blockBlob" ], 
10           "prefixMatch": [ "sample-container/blob1" ] 
11         }, 
12         "actions": { 
13           "baseBlob": {
14            // #TODO What here? 
15           } 
16         } 
17       } 
18     } 
19   ] 
20 }
```
### Blob Storage Lifecycle Policies

**Correct Answer:** `"tierToCool": { "daysAfterModificationGreaterThan": 90 }`

This question tests the candidate’s knowledge of blob tiers and lifecycle management policies.

* The code segment `"tierToCool": { "daysAfterModificationGreaterThan": 90 }` correctly moves blobs that have not been modified for 90 days to the Cool tier, as per the requirement.
* The code segments that include `"tierToArchive"` move blobs to the Archive tier. This is not an online access tier but an offline tier, which does not meet the implied requirement for online access.
* The code segment `"tierToCool": { "daysAfterCreationGreaterThan": 90 }` moves blobs to the Cool tier 90 days after their creation, which does not meet the requirement to move blobs after 90 days without modification.

**Reference:** [Implement Blob storage lifecycle policies - Training | Microsoft Learn](https://learn.microsoft.com/en-us/training/modules/azure-storage-blob-lifecycle-management/)

----

# 20 📦 Azure Storage Lifecycle Policy – Append Blobs

❓ **Question:**  
You need to implement an Azure Storage lifecycle policy for append blobs.  
Which rule action should you use?

---

### Options:
- 🗑️ **delete** ✅ *(Correct)*  
- 🔄 enableAutoTierToHotFromCool  
- 🧊 tierToArchive  
- ❄️ tierToCool  

---

💡 The **delete** rule action supports both block blobs and append blobs, while the other actions only support block blobs.

---

### 📝 Summary  
For append blobs, only the **delete** lifecycle rule action is supported.

---

Q21: # 🗄️ Azure Blob Storage – Rehydrating Archive Blobs

❓ **Question:**  
You need to rehydrate a blob stored in the Archive tier by changing the access tier.  
Which destination blob should you use?

---

### Options:
- 📦 A blob in the Archive tier in the same region ❌ *(Incorrect)*  
- 🌍 A blob in the Archive tier in a different region  
- ❄️ A blob in the Cool tier in a different region  
- 🧊 A blob in the Cool tier in the same region ✅ *(Correct)*  

---

💡 Blobs in the Archive tier can only be rehydrated to an online tier (**Hot or Cool**) within the **same region**.

---

### 📝 Summary  
To rehydrate from Archive, move the blob to **Cool or Hot in the same region**.

---

Q22: # 🛡️ Azure Blob Storage – Immutability for Legal Investigation

❓ **Scenario:**  
Fabrikam, Inc. is undergoing a legal investigation and must ensure that certain sensitive documents in Azure Blob Storage **cannot be modified or deleted** until the investigation concludes.  
You need an immutability policy that is **temporary** and can be **removed once the investigation ends**.  

---

### Options:
- 🗂️ Configure a container-level WORM policy with a retention interval of 5 years  
- ⚖️ Configure a legal hold policy on the container where the documents are stored ✅ *(Correct)*  
- ⏳ Configure a time-based retention policy with a retention interval of 1 year and lock the policy  
- 🔄 Enable versioning on the storage account and configure a time-based retention policy at the version level ❌ *(Incorrect)*  

---

💡 A **legal hold policy** protects data from changes or deletion until it is explicitly cleared, making it ideal for temporary requirements like investigations.

---

### 📝 Summary  
Use a **legal hold policy** for flexible, temporary immutability during investigations.

---

Q23: # 🐳 Azure Container Instances – Mounting an Azure File Share

❓ **Scenario:**  
You need to create a container in a container group and mount an **Azure file share** as a volume.  
Which code segment should you use?

---

### Options:
1. ✅ *(Correct)*  
```bash
az container create -g MyResourceGroup --name myapp --image myimage:latest \
--command-line "cat /mnt/azfile/myfile" \
--azure-file-volume-share-name myshare \
--azure-file-volume-account-name mystorageaccount \
--azure-file-volume-account-key mystoragekey \
--azure-file-volume-mount-path /mnt/azfile
```
2. ❌ (Incorrect – uses --secrets-mount-path instead of file share)
```bash
az container create -g MyResourceGroup --name myapp --image myimage:latest \
--command-line "cat /mnt/azfile/myfile" \
--azure-file-volume-share-name myshare \
--azure-file-volume-account-name mystorageaccount \
--azure-file-volume-account-key mystoragekey \
--secrets-mount-path /mnt/azfile
```
3. 
❌ (Incorrect – missing --azure-file-volume-share-name)
```bash
az container create -g MyResourceGroup –name myapp –image myimage:latest \
--command-line “cat /mnt/azfile/myfile” \
--azure-file-volume-account-name mystorageaccount \
--azure-file-volume-account-key mystoragekey \
--azure-file-volume-mount-path /mnt/azfile
```
4. 
❌ (Incorrect – uses --secrets-mount-path and missing share name)
```bash
az container create -g MyResourceGroup --name myapp --image myimage:latest \
--command-line "cat /mnt/azfile/myfile" \
--azure-file-volume-account-name mystorageaccount \
--azure-file-volume-account-key mystoragekey \
--secrets-mount-path /mnt/azfile
```
💡 The correct command must include both --azure-file-volume-share-name and --azure-file-volume-mount-path to mount an Azure file share into the container.

> 📝 Summary

To mount an Azure file share in a container group, use --azure-file-volume-share-name with --azure-file-volume-mount-path. (and no secrets)

---

Q24: 🗑️ Azure Container Registry – Deleting an Image

❓ **Scenario:**  
You need to delete an image with the tag **`dev/nginx:latest`** from an Azure Container Registry named **`devregistry`**.  
Which code segment should you use?

---

### Options:
1. ✅ *(Correct)*  
```bash
az acr repository delete --name devregistry --image dev/nginx:latest
```

2. ❌ *(Incorrect – uses `--suffix` unnecessarily)*  
```bash
az acr repository delete --name devregistry --suffix dev/nginx:latest
```

3. ❌ *(Incorrect – deletes manifest, not the image)*  
```bash
az acr manifest delete --registry devregistry -n dev/nginx:latest
```

4. ❌ *(Incorrect – mixes `--suffix` and manifest deletion)*  
```bash
az acr manifest delete --registry devregistry --suffix dev/nginx:latest --image dev/nginx:latest
```

---

💡 Use **`az acr repository delete --name <registry> --image <repo:tag>`** to remove an image from Azure Container Registry.

---

### 📝 Summary  
Run `az acr repository delete --name devregistry --image dev/nginx:latest` to delete the image from ACR.

----

Q25: # 📦 Azure Container Instances – Deploying with Azure Files Share

❓ **Scenario:**  
You need to deploy an **Azure Files share** along with a **container group** to Azure Container Instances (ACI).  
Which deployment method should you use?

---

### Options:
- 📄 YAML file ❌ *(Incorrect)*  
- 🏗️ Azure Resource Manager (ARM) template ✅ *(Correct)*  
- 🐳 Docker Compose  
- 💻 Azure CLI  

---

💡 An **ARM template** is required when deploying **additional Azure resources** (like Azure Files) alongside container groups, because YAML and other methods don’t support provisioning external services at deployment time.

---

### 📝 Summary  
Use an **ARM template** to deploy an Azure Files share with a container group in ACI.

---

Q26: A container group in Azure Container Instances has multiple containers.

The containers must restart when the process executed in the container group terminates due to an error.

You need to define the restart policy for the container group.

Which Azure CLI command should you use?

Select only one answer.

az container restart \    --name mycontainer \    --resource-group myResourceGroup \    --no-wait


az container create \    --resource-group myResourceGroup \    --name mycontainer \    --image mycontainerimage \    --restart-policy Always


az container create \    --resource-group myResourceGroup \    --name mycontainer \    --image mycontainerimage \    --restart-policy Never


az container create \    --resource-group myResourceGroup \    --name mycontainer \    --image mycontainerimage \    --restart-policy OnFailure

#todo - I think the last one; 

----

Q27 # 🏷️ Azure Container Registry – Group Isolation with Namespaces

❓ **Scenario:**  
You manage the deployment of an Azure Container Registry named **registry1** for a company.  
You need to ensure that **registry1 can be shared across multiple groups**, enabling **group isolation**.  
What should you use?

---

### Options:
- 📦 artifact  
- 🏷️ tag ❌ *(Incorrect)*  
- 📂 namespace ✅ *(Correct)*  
- 🧩 layer  

---

💡 A **namespace** in ACR allows related repositories to be grouped and identified using forward slash-delimited names, supporting **isolation across teams or groups**.

---

### 📝 Summary  
Use a **namespace** in Azure Container Registry to enable group isolation and sharing across multiple groups.

---

Q28: # 🚀 Azure Container Apps – Deploying from a Dockerfile

❓ **Scenario:**  
Your company is developing an application with a backend web API service.  
The team will use **Azure Container Apps** to host the API, and a **Dockerfile** is in the root of the repository.  
You need to deploy the container app using this Dockerfile.  

---

### Options:
- 🏞️ Use `az containerapp env create` with the `--name` parameter  
- 📦 Use `az containerapp create` with the `--image` parameter ❌ *(Incorrect)*  
- 🔧 Use `az containerapp create` with the `--containername` parameter  
- ⚡ Use `az containerapp up` with the `--source .` parameter ✅ *(Correct)*  

---

💡 The **`az containerapp up --source .`** command builds the container image from the local Dockerfile and deploys it directly to Azure Container Apps.

---

### 📝 Summary  
Run **`az containerapp up --source .`** to build and deploy a Dockerfile-based app to Azure Container Apps.

---

Q29: You develop a web application hosted on the Web Apps feature of Microsoft Azure App Service.

You need to enable and configure Azure Web Service Local Cache with 1.5 GB.

Which two code segments should you use? Each correct answer presents part of the solution.

### Options:
- ✅ *(Correct)*  
```json
"WEBSITE_LOCAL_CACHE_OPTION": "Always"
```
✅ (Correct)
```json
"WEBSITE_LOCAL_CACHE_SIZEINMB": "1500"
```
❌ (Incorrect – not a valid value)
* "WEBSITE_LOCAL_CACHE_OPTION": "Enable"
* "WEBSITE_LOCAL_CACHE_SIZEINMB": "1.5"

💡 Use "WEBSITE_LOCAL_CACHE_OPTION": "Always" to enable local cache and "WEBSITE_LOCAL_CACHE_SIZEINMB": "1500" to configure it with 1.5 GB.

📝 Summary

Set WEBSITE_LOCAL_CACHE_OPTION=Always and WEBSITE_LOCAL_CACHE_SIZEINMB=1500 to enable Local Cache with 1.5 GB.

---

Q30: # 🌐 Azure App Service – Configuring CORS for a Web App

❓ **Scenario:**  
You need to configure a **web app** to allow external requests from **https://myapps.com**.  
Which Azure CLI command should you use?

---

### Options:
- ✅ *(Correct)*  
```bash
az webapp cors add -g MyResourceGroup -n MyWebApp --allowed-origins https://myapps.com
```
❌ (Incorrect – adds managed identity, not CORS)
```bash
az webapp identity add -g MyResourceGroup -n MyWebApp --allowed-origins https://myapps.com
az webapp traffic-routing set --distribution myapps=100 --name MyWebApp --resource-group MyResourceGroup
az webapp config access-restriction add -g MyResourceGroup -n MyWebApp --rule-name external --action Allow --ids myapps --priority 200
```
💡 The az webapp cors add command configures Cross-Origin Resource Sharing (CORS) to allow requests from specific origins such as https://myapps.com.

📝 Summary

Use az webapp cors add to allow external requests from a specified origin.

---

> Q31 You manage a multi-instance deployment of an Azure App Service web app named **app1**.  

You need to ensure a client application is routed to the same instance for the life of the session.  

**Which platform setting should you use?**  
Select only one answer.  

- WebSocket  
- Always on  
- HTTP version  
- **ARR Affinity ✅**  

---

This item tests the candidate’s knowledge of configuring web app settings, which is part of creating Azure App Service Web Apps.  

In a multi-instance deployment, the **ARR Affinity** setting ensures a client application is routed to the same instance for the life of the session.  
- **WebSocket** → provides full-duplex communication.  
- **Always on** → keeps the app loaded even when idle.  
- **HTTP version** → controls protocol version (e.g., HTTP/2) but not session routing.  

---

**Summary:** ARR Affinity ensures client sessions are consistently routed to the same instance in a multi-instance Azure App Service deployment.

---

> Q32 You are developing a **Linux web app** on Azure App Service.  

You need to deploy the web app to the production environment based on the following requirements:  
- App changes must be validated in an environment identical to the production environment before moving the app to the production environment.  
- Downtime must be eliminated when the app is deployed to the production environment.  

**What should you use?**  
Select only one answer.  

- **Deployment slots ✅**  
- Auto-scaling  
- Hybrid connection  
- App cloning  

---

This item tests the candidate’s knowledge of when to use **deployment slots**.  
- **Deployment slots** → Live apps with unique host names that allow swapping configuration and content between them, enabling zero-downtime deployments.  
- **Auto-scaling** → Adjusts resources (scale up/out) based on metrics or schedules.  
- **Hybrid connection** → Provides secure access to on-premises apps.  
- **App cloning** → Copies an app to another destination, not supported for Linux apps.  

---

**Summary:** Deployment slots let you validate changes in a staging environment identical to production and swap them in with zero downtime.

---

> Q33 You develop an **App Service app hosted on Windows Platform**. Users report that the app is failing.  

You need to begin troubleshooting the app by inspecting a copy of the page that is returned when the HTTP return code is greater than 400.  

**Which type of log should you review?**  
Select only one answer.  

- application  
- web server  
- **detailed error ✅**  
- deployment  

---

This item tests the candidate’s knowledge of using logs to troubleshoot web apps.  
- **Detailed error log** → Contains copies of the error pages produced in response to HTTP codes > 400 (not sent to clients for security).  
- **Web server log** → Records raw HTTP request data (method, bytes, user agent).  
- **Application log** → Captures app-specific logging written by the application code or its components.  
- **Deployment log** → Stores details about failed deployments.  

---

**Summary:** Review detailed error logs to inspect error pages generated when HTTP responses exceed 400 codes.  

---

> Q34 A company has an **App Service web app** that requires a **TLS/SSL certificate**.  
The certificate will also be used in other App Service apps.  
The certificate must be **automatically renewed** with the least management overhead.  

You need to add the certificate.  

**What should you do?**  
Select only one answer.  

- Create a free App Service managed certificate  
- **Purchase an App Service certificate ✅**  
- Upload a certificate from a third party  
- Import a certificate from a Key Vault  

---

This item tests the candidate’s knowledge of configuring web app settings including SSL, API settings, and connection strings.  
- **App Service certificate (purchased)** → Automates request, renewal, and synchronization across multiple App Service apps with minimal management.  
- **Free App Service managed certificate** → Basic, cannot be exported, not suitable for multiple apps.  
- **Third-party certificate upload** → Possible, but requires manual renewal and management.  
- **Import from Key Vault** → Useful with third-party certs, but automation must be set up externally.  

---

**Summary:** Purchase an App Service certificate to enable automated renewal and synchronization across multiple web apps with minimal overhead.  

---

> Q35 You plan to create an **Azure Functions app** named **app1**.  

You need to ensure that app1 will satisfy the following requirements:  
- Supports automatic scaling.  
- Has event-based scaling behavior.  
- Provides a serverless pricing model.  

**Which hosting plan should you use?**  
Select only one answer.  

- App Service  
- App Service Environment  
- **Consumption ✅**  
- Functions Premium  

---

This item tests the candidate’s knowledge of selecting the appropriate hosting plan for Azure Functions.  
- **Consumption plan** → Supports autoscaling, event-based scaling, and a true serverless pricing model (pay only for executions).  
- **App Service / App Service Environment** → Provide scaling, but not serverless pricing; scaling is performance-based, not event-driven.  
- **Functions Premium** → Provides autoscaling and advanced features (e.g., VNET integration, longer execution times), but not the pure serverless pricing model.  

---

**Summary:** Use the **Consumption plan** to achieve serverless pricing with automatic, event-driven scaling in Azure Functions.  

---

> Q36 A company plans to create an **Azure Functions app**.  

You need to recommend a solution that meets the following requirements:  
- Executes multiple functions concurrently.  
- Performs aggregation on the results from the functions.  
- Avoids cold starts.  
- Minimizes costs.  

**Which two components should you recommend?**  
Each correct answer presents part of the solution.  

- The Consumption plan  
- **The Premium plan ✅**  
- **Fan-out/fan-in pattern ✅**  
- Function chaining pattern  

---

This item tests the candidate’s knowledge of **Azure Durable Functions** and hosting plans.  
- **Premium plan** → Avoids cold starts, supports unlimited execution, and provides better performance while still offering cost savings vs. App Service Environment.  
- **Fan-out/fan-in pattern** → Runs multiple functions in parallel, then aggregates results efficiently.  
- **Consumption plan** → Lowest cost, but subject to cold starts and execution time limits (10 minutes).  
- **Function chaining pattern** → Sequential execution, not concurrent, so not suitable for aggregation scenarios.  

---

**Summary:** Use the **Premium plan** with the **fan-out/fan-in pattern** to achieve concurrent execution, aggregation, and no cold starts.  

---

> Q37 You are developing an **Azure Functions app** that will be deployed to a **Consumption plan**.  
The app consumes data from a database server that has **limited throughput**.  

You need to use the **functionAppScaleLimit** property to control the number of instances of the app that will be created.  

**Which value should you use for the property setting?**  
Select only one answer.  

- 0  
- **10 ✅**  
- null  

---

This item tests the candidate’s knowledge of configuring an Azure Functions app.  
- **functionAppScaleLimit = 10** → Restricts scaling to 10 instances, protecting dependent resources with limited throughput.  
- **0 or null** → No limit (default), allowing scaling up to 200 instances on the Consumption plan.  

---

**Summary:** Set **functionAppScaleLimit to 10** to cap instance scaling and protect downstream resources with limited capacity.  

---

> Q38 You manage an **Azure API Management** instance.  

You need to limit the **maximum number of API calls** allowed from a single source for a specific time interval.  

**What should you configure?**  
Select only one answer.  

- Product  
- **Policy ✅**  
- Subscription  
- API  

---

This item tests the candidate’s knowledge of **policies in Azure API Management**.  
- **Policy** → A collection of statements applied to requests/responses that can enforce behaviors such as rate limits, quotas, or transformations.  
- **Product** → Groups APIs and defines terms of use, but cannot enforce per-source call limits.  
- **Subscription** → Provides access keys for consumers but does not enforce rate limits.  
- **API** → Represents a backend API; must rely on policies to implement restrictions.  

---

**Summary:** Configure a **policy** in Azure API Management to enforce call limits over a defined time interval.  

---

> Q39 You manage an instance of **Azure API Management**.  
You define policies at multiple scopes.  

You need to enforce a **policy evaluation order**.  

**What should you use?**  
Select only one answer.  

- **the `<base/>` element ✅**  
- the `<when/>` element  
- the `follow-redirects` attribute  
- the `condition` attribute  

---

This item tests the candidate’s knowledge of defining policies for APIs.  
- **`<base/>` element** → Ensures that policy evaluation order is enforced when policies are applied at multiple scopes.  
- **`<when/>` element** → Used within a `choose` policy for conditional branching, not order enforcement.  
- **`follow-redirects` attribute** → Part of the `forward-request` policy, controls redirect handling only.  
- **`condition` attribute** → Part of the `retry` policy, affects retry logic, not order.  

---

**Summary:** Use the **`<base/>` element** to enforce the evaluation order of policies in Azure API Management.  

---

> Q40 You plan to use **Azure API Management** for **Hybrid and multicloud API management**.  

You need to create a **self-hosted gateway** for production.  

**Which container image tag should you use?**  
Select only one answer.  

- **2.9.0 ✅**  
- v3  
- latest  
- V3-preview  

---

This item tests the candidate’s knowledge of **self-hosted gateways in Azure API Management**.  
- **2.9.0** → Uses the `{major}.{minor}.{patch}` format, pinning to a specific version, required for production stability.  
- **v3** → Always pulls the latest major version, which may introduce breaking changes.  
- **latest** → For evaluation purposes only, not recommended for production.  
- **V3-preview** → Runs preview builds, suitable only for testing new features.  

---

**Summary:** Use a **pinned version tag** like **2.9.0** for production self-hosted API Management gateways.  

---

> Q41 A company is using **Azure API Management** to expose their APIs to external partners.  
They want to ensure that:  
- APIs are accessible **only to users authenticated with OAuth 2.0**.  
- **Usage quotas** are enforced to prevent abuse.  

**Which two actions should you perform?**  
Select all answers that apply.  

- **Configure a `validate-jwt` policy to authenticate incoming requests ✅**  
- Deploy an Azure Application Gateway in front of the API Management instance  
- Implement IP filtering by defining access restriction policies  
- **Set up a `rate-limit-by-key` policy to enforce call quotas ✅**  

---

This item tests the candidate’s knowledge of **API Management security and usage policies**.  
- **`validate-jwt` policy** → Ensures OAuth 2.0 tokens are validated for secure access.  
- **`rate-limit-by-key` policy** → Enforces usage quotas and prevents abuse.  
- **Azure Application Gateway** → Provides traffic routing and WAF features, not required for OAuth 2.0 auth or quotas.  
- **IP filtering** → Restricts network access, but does not enforce OAuth 2.0 authentication or quotas.  

---

**Summary:** Use a **`validate-jwt` policy** for OAuth 2.0 authentication and a **`rate-limit-by-key` policy** to enforce quotas in API Management.  

---

> Q42 You are a **cloud solutions architect** working for a company that plans to expose their internal **Azure-hosted data processing service** to partners via APIs.  
The service handles **large datasets** and provides **analytics and reporting features**.  
The company requires:  
- Secure, controlled access  
- Enforced usage policies  
- Well-documented APIs  

**What three steps should you perform?**  
Select all answers that apply.  

- **Configure access to the APIs by setting up OAuth 2.0 user authorization in the Azure API Management instance ✅**  
- **Create an Azure API Management instance and import the existing API using the Azure portal's API import functionality ✅**  
- Define the API manually in the Azure API Management instance and set up a mock API to simulate the backend until it's fully integrated  
- Document the APIs directly within the code of the data processing service to ensure automatic synchronization with the Azure API Management instance  
- **Implement policies for the APIs in the Azure API Management instance to enforce rate limits and quotas ✅**  

---

This item tests the candidate’s knowledge of securely exposing and managing APIs with **Azure API Management**.  
- **OAuth 2.0** → Provides secure, standards-based authentication and authorization for partner access.  
- **Importing the API** → Quickly exposes the existing service through API Management.  
- **Policies** → Enforce quotas, rate limits, and other usage rules to prevent abuse.  
- **Mock API setup** → Useful for development/testing, but not for production rollout of an existing service.  
- **In-code documentation** → API Management handles documentation within the portal, not from backend code.  

---

**Summary:** Create an **API Management instance**, configure **OAuth 2.0**, and implement **policies** to securely expose and control partner access to the APIs.  

---

> Q43  You manage an **Azure Event Hub**.  

You need to ensure that multiple **load-balanced instances** of a **.NET 5.0 application** can be used to scale event processing.  

**Which event processor client should you use?**  
Select only one answer.  

- EventHubConsumerClient  
- EventProcessorHost  
- EventHubProducerClient  
- **EventProcessorClient ✅**  

---

This item tests the candidate’s knowledge of **scaling event processing applications** in Azure Event Hubs.  
- **EventProcessorClient** → Balances the load between multiple instances in modern .NET versions (such as .NET 5.0).  
- **EventHubConsumerClient** → Used for consuming events in Python and JavaScript SDKs.  
- **EventProcessorHost** → Legacy approach for earlier .NET versions.  
- **EventHubProducerClient** → Sends events into the hub, not for load-balanced consumption.  

---

**Summary:** Use **EventProcessorClient** in .NET 5.0 to enable load-balanced, scalable event processing with Azure Event Hubs.  


---

> Q44 A company is developing an **IoT solution for smart buildings** that collects telemetry data from various sensors.  
The data is sent to Azure for **real-time analysis and storage**.  

You need to implement a solution that:  
- Ingests **high volumes of events**  
- Provides **reliable delivery** to downstream processing services  
- Ensures **minimal latency**  

**Which service should you use?**  
Select only one answer.  

- Azure Blob Storage  
- Azure Event Grid  
- **Azure Event Hubs ✅**  
- Azure Service Bus  

---

This item tests the candidate’s knowledge of event ingestion services in Azure.  
- **Azure Event Hubs** → Optimized for high-throughput, real-time event streaming (millions of events per second), ideal for IoT telemetry.  
- **Azure Event Grid** → Best for lightweight event routing and serverless triggers, not high-volume streaming.  
- **Azure Service Bus** → Suited for enterprise messaging with queues and topics, not optimized for real-time IoT ingestion.  
- **Azure Blob Storage** → Used for file storage, not real-time event ingestion.  

---

**Summary:** Use **Azure Event Hubs** for real-time, high-volume IoT telemetry ingestion with minimal latency.  

---

> Q45 A company is using **Azure Event Grid** to process **e-commerce order events**.  
Event sources include **Azure Blob Storage, Azure Functions, and third-party services**.  
The company wants to ensure that the event delivery mechanism is robust and can handle failures with **minimal loss**, even when responses return **400 or 413 codes**.  

**What should you do?**  
Select only one answer.  

- Configure synchronous handshake validation for all event subscriptions to ensure immediate event delivery  
- Decrease the event time-to-live (TTL) to the minimum value to expedite event processing  
- **Enable dead-lettering to capture events that are not delivered within the specified retry schedule ✅**  
- Increase the maximum number of delivery attempts to the highest possible value to ensure all events are eventually delivered  

---

This item tests the candidate’s knowledge of **event delivery reliability in Event Grid**.  
- **Dead-lettering** → Captures undelivered events in a storage account or queue, ensuring events aren’t lost.  
- **Max delivery attempts** → Extends retries but doesn’t prevent loss if the subscriber is unavailable.  
- **Synchronous handshake validation** → Validates subscriptions, not relevant to delivery failures.  
- **Decreasing TTL** → Risky, as it increases the chance of valid events being dropped.  

---

**Summary:** Enable **dead-lettering** in Event Grid to ensure reliable event delivery by capturing undelivered events.  

---

> Q46 You have an **Azure Service Bus** instance.  

You need to provide **first-in, first-out (FIFO)** guarantee for message processing.  

**What should you configure?**  
Select only one answer.  

- dead-letter queue  
- message deferral  
- **message sessions ✅**  
- scheduled delivery  

---

This item tests the candidate’s knowledge of **FIFO message handling in Azure Service Bus**.  
- **Message sessions** → Enable ordered, exclusive handling of related message sequences, ensuring FIFO delivery.  
- **Dead-letter queue** → Stores undeliverable messages for later inspection, not FIFO-related.  
- **Message deferral** → Allows postponing processing of a message, but does not guarantee ordering.  
- **Scheduled delivery** → Submits messages for delayed processing, not ordered consumption.  

---

**Summary:** Configure **message sessions** in Azure Service Bus to guarantee FIFO message processing.  

---

> Q47 You create an **Azure Service Bus topic** with a **default message time to live (TTL)** of **10 minutes**.  

You need to send messages to this topic with a **time to live of 15 minutes**.  
The solution must **not affect other applications** that are using the topic.  

**What should you recommend?**  
Select only one answer.  

- Change the topic’s default time to live to 15 minutes.  
- Change the specific message’s time to live to 15 minutes.  
- **Create a new topic with a default time to live of 15 minutes. Send the messages to this topic. ✅**  
- Update the time to live for the queue containing the topic.  

---

This question tests the candidate's knowledge of **Azure Service Bus message expiration rules**.  

- **Default TTL (topic-level)** → Limits the maximum time messages can live. Message-level TTL **cannot exceed** this default.  
- **Changing the default TTL** → Would affect *all* applications using the topic, which violates the requirement.  
- **Message-level TTL** → Cannot override the topic-level maximum.  
- **Creating a new topic with 15 min TTL** → Isolates the change to only the messages needing longer TTL, without affecting existing apps.  

---

**Summary:**  
Create a **new topic with TTL = 15 minutes** and send those messages there to avoid impacting other applications.  

---

> Q48 You are developing a **.NET project** that will manage messages in **Azure Storage queues**.  

You need to **verify the presence of messages** in a queue **without removing them** from the queue.  

**Which method should you use?**  
Select only one answer.  

- Peek  
- **PeekMessages ✅**  
- ReceiveMessages  
- ReceiveMessageAsync  

---

This item tests knowledge of **processing messages in Azure Queue Storage**.  

- **PeekMessages** → Reads one or more messages **without dequeuing** (non-destructive). ✅  
- **Peek** → Used with **Azure Service Bus**, not Azure Storage queues.  
- **ReceiveMessages** → Retrieves and **removes** messages from the queue.  
- **ReceiveMessageAsync** → Belongs to **Azure Service Bus**, not Queue Storage.  

---

**Summary:**  
Use **`QueueClient.PeekMessages()`** when you need to check messages without removing them.  

---

> Q49 You have an application that requires **message queuing**.  

You need to recommend a solution that meets the following requirements:  
- **Automatic duplicate message detection**  
- **Ability to send 2 MB messages**  

**Which message queuing solution should you recommend?**  
Select only one answer.  

- **Azure Service Bus Premium tier ✅**  
- Azure Service Bus Standard tier  
- Azure Storage queues with locally redundant storage (LRS)  
- Azure Storage queues with zone-redundant storage (ZRS)  

---

This item tests knowledge of **Azure Service Bus capabilities**.  

- **Azure Service Bus Premium tier** → Supports **duplicate detection** ✅ and allows messages up to **100 MB**.  
- **Azure Service Bus Standard tier** → Supports duplicate detection, but only for messages up to **256 KB** ❌.  
- **Azure Storage queues (LRS or ZRS)** → No support for **duplicate detection** ❌.  

---

**Summary:**  
Use **Azure Service Bus Premium tier** for **2 MB messages** + **duplicate detection**.  

---

> Q50 A financial services company is implementing a system to process transactions that are received as messages.  
The system must ensure that transactions are processed **only once**, and in the **exact order** they are received to maintain data integrity.  

You need to design a messaging solution that guarantees **first-in-first-out (FIFO)** message delivery and processing.  

**Which two services should you use?**  
Select all answers that apply.  

- Azure Event Grid with advanced filtering ❌  
- Azure Queue Storage with visibility timeout ❌  
- **Azure Service Bus with duplicate detection ✅**  
- **Azure Service Bus with sessions enabled ✅**  

---

### Explanation:
- **Azure Service Bus with sessions enabled** → Provides **FIFO guarantees** by processing related messages in the order received.  
- **Azure Service Bus with duplicate detection** → Ensures messages are processed **exactly once** by filtering out duplicates.  
- **Azure Queue Storage with visibility timeout** → Temporarily hides messages but **does not guarantee FIFO**.  
- **Azure Event Grid** → Optimized for **pub/sub event routing**, not FIFO or guaranteed ordering.  

---

✅ **Correct solution:** Use **Azure Service Bus with sessions + duplicate detection** to ensure **ordered, once-only transaction processing**.  

----
Whew! Way to go! [MS AZ-204 Practice Test](https://learn.microsoft.com/en-us/credentials/certifications/azure-developer/practice/assessment?assessment-type=practice&assessmentId=35&practice-assessment-type=certification)
