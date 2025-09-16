# Udemy Practice Exam 5 

# Question 1

You are developing code that connects to an **Azure Cosmos DB** account.  
You want to know two different ways to connect using keys.

---

### ❓ Question
When working with code against Cosmos DB, what are two different ways to connect to the account using keys?

**(Select two answers.)**

- ✅ **Use the Primary Key to authenticate and connect.**  
- ✅ **Use the Secondary Key to authenticate and connect.**  
- ❌ Use a connection string that includes either the Primary Key or Secondary Key.  
- ❌ Use the Azure subscription ID directly to connect.  
- ❌ Use Azure Key Vault without any authentication to access the database.  

---

### ✅ Correct Answers

- **Use the Primary Key to authenticate and connect.**  
- **Use the Secondary Key to authenticate and connect.**

---

### 🔍 Explanation

- **Primary Key** → Provides full read/write access to your Cosmos DB account and can be used directly to connect through the SDK or connection strings.  
- **Secondary Key** → Works as a backup key, also providing full read/write access, and is useful for key rotation without downtime.  

**Other options:**  
- **Connection string with a key** → Technically works, but still relies on Primary/Secondary keys under the hood; the question specifically asks about using keys directly.  
- **Azure subscription ID** → Identifies the subscription, not used for database authentication.  
- **Azure Key Vault without authentication** → You cannot bypass authentication when accessing Key Vault.  

---

### 📖 Official Microsoft Reference
> **[Secure access to data in Azure Cosmos DB](https://learn.microsoft.com/azure/cosmos-db/secure-access-to-data)**

---

### 📝 One-Sentence Summary
> You can connect to Azure Cosmos DB using either the **Primary Key** or the **Secondary Key**, both of which provide full access.

---

## Question 2

You are working with an Azure Table Storage application and want to migrate it to Azure Cosmos DB using the Table API.

You need to understand what the migration involves.

### ❓ Question:
What does it take to migrate a Table Storage application to a Cosmos DB Table API application?

- ❌ Rewrite the entire application using the SQL API SDK.  
- ❌ Rebuild the entire database and manually copy all data.  
- ✅ **Change the connection string to point to the Cosmos DB Table API account and optionally migrate the data.**  
- ❌ Use Azure Migrate service to automatically recompile the application.

---

### ✅ Correct Answer:
**Change the connection string to point to the Cosmos DB Table API account and optionally migrate the data.**

### 🔍 Explanation:
Azure Cosmos DB Table API is wire protocol compatible with Azure Table Storage.  
This means you can reuse the same SDKs, libraries, and application code with minimal changes.  

**Key steps:**
- Update the connection string to point to your Cosmos DB Table API account.  
- Optionally migrate existing data using tools like **AzCopy**, **Azure Data Migration Tool**, or custom scripts.  

**Why not the other options?**
- **SQL API SDK** → Not needed; Table API is designed to mimic Table Storage.  
- **Manual rebuild** → Migration can be automated; no need to manually recreate everything.  
- **Azure Migrate** → Focused on VMs and servers, not database-level migrations.  

---

### 📖 Official Reference:
[Microsoft Docs: Migrate from Azure Table Storage to Azure Cosmos DB Table API](https://learn.microsoft.com/azure/cosmos-db/table/table-api-migrate)

---

**Summary:** Migrating from Table Storage to Cosmos DB Table API usually just requires changing the connection string and optionally migrating existing data.

---

## Question 3

You are designing an Azure virtual machine (VM) solution.

You need to understand:

- What is a VM Availability Set?  
- What is a VM Scale Set?  
- How they differ, and when to use one over the other.

### ❓ Question:
Which best describes VM Availability Sets and VM Scale Sets, their differences, and when to use them?

- ❌ **A VM Availability Set automatically adds or removes VMs based on demand, while a VM Scale Set ensures VMs are spread across fault and update domains for availability.**  
- ✅ **A VM Availability Set spreads VMs across fault and update domains for high availability, while a VM Scale Set automatically scales VMs up or down based on demand.**  
- ❌ Both VM Availability Sets and VM Scale Sets automatically scale VM instances based on load.  
- ❌ A VM Availability Set is used for scaling VMs up and down automatically, while VM Scale Sets are used only for high availability during planned maintenance.  

---

### ✅ Correct Answer:
**A VM Availability Set spreads VMs across fault and update domains for high availability, while a VM Scale Set automatically scales VMs up or down based on demand.**

---

### 🔍 Explanation:

**VM Availability Set:**  
- Distributes VMs across **fault domains** (different physical servers/racks) and **update domains** (different maintenance windows).  
- Provides **high availability** during hardware failures or planned maintenance.  
- **Does not auto-scale** — you must manually add/remove VMs.  

**VM Scale Set:**  
- Deploys and manages a group of **identical VMs**.  
- **Automatically scales** the number of VMs up/down based on metrics like CPU usage, memory, or a schedule.  
- Can also ensure high availability by spreading VMs across zones or fault domains.  

---

### 🔥 When to Use Which

| Situation | Use |
|----------|-----|
| High availability with **manual scaling** | **VM Availability Set** |
| **Auto-scaling** VM instances based on demand | **VM Scale Set** |

---

### ❌ Why Other Options Are Incorrect:
- **Availability Sets do not auto-scale** — they just ensure redundancy.  
- **VM Scale Sets are primarily about scaling**, but can also provide availability.  

---

### 📖 Official Microsoft Reference:
- [What is an Azure VM Availability Set?](https://learn.microsoft.com/azure/virtual-machines/availability-set-overview)  
- [What is an Azure VM Scale Set?](https://learn.microsoft.com/azure/virtual-machine-scale-sets/overview)  

---

**Summary:** VM Availability Sets focus on high availability by distributing VMs across fault and update domains, while VM Scale Sets handle automatic scaling of VMs based on demand.

---

# Question 4

You are working with Azure Virtual Machines (VMs), and you want to understand:

- What are the main groups of VM compute configurations that Azure offers?

### ❓ Question:
What are some of the main groups of VM compute configurations in Azure?

- ❌ Memory-optimized, Storage-optimized, CPU-optimized  
- ❌ General purpose, Compute-intensive, Graphics-intensive  
- ✅ **General purpose, Compute-optimized, Memory-optimized, Storage-optimized, GPU-optimized, High Performance Compute (HPC)**  
- ❌ CPU-only, Memory-only, Storage-only, GPU-only

---

### ✅ Correct Answer:
**General purpose, Compute-optimized, Memory-optimized, Storage-optimized, GPU-optimized, High Performance Compute (HPC)**

### 🔍 Explanation
Azure groups VM families by workload profile:

- **General purpose** — balanced CPU-to-memory; good for web servers, small databases, dev/test.  
- **Compute-optimized** — high CPU-to-memory; good for compute-heavy tasks like batch processing and medium-traffic web servers.  
- **Memory-optimized** — high memory-to-CPU; suited for relational DBs, in-memory caches, analytics.  
- **Storage-optimized** — high disk throughput and IOPS; best for big data, NoSQL, large databases.  
- **GPU-optimized** — VMs with GPUs for graphics, rendering, and AI/ML training/inference.  
- **High Performance Compute (HPC)** — specialized for tightly-coupled, latency-sensitive compute workloads (simulations, scientific compute, large-scale ML).

**When to pick which:** choose the family whose resource profile (CPU, memory, disk I/O, GPU, network/HPC features) matches your workload’s bottleneck.

---

### ❌ Why the other options are wrong
- The first two choices are incomplete or use imprecise labels; Azure provides GPU and HPC families as well.  
- “CPU-only / Memory-only / Storage-only / GPU-only” is a simplification that doesn’t reflect Azure’s official VM family groupings.

---

**Summary:** Azure VM families are grouped by workload needs—general, compute-, memory-, storage-, GPU-optimized, and HPC—so pick the family whose resource profile matches your workload’s primary bottleneck.

---

# Question 5

You are working with Azure Virtual Machine disks, and you need to understand:

- Which disks are managed?  
- Which disks can be unmanaged?  
- What to remember when using unmanaged disks?

### ❓ Question:
Which Azure disks are managed, which are unmanaged, and what are important considerations when using unmanaged disks?

- ✅ **Managed disks include Standard HDD, Standard SSD, and Premium SSD. Unmanaged disks are just page blobs stored manually in a storage account. Using unmanaged disks requires you to manage storage accounts and capacity yourself.**  
- ❌ Managed disks must be managed manually by users. Unmanaged disks automatically adjust capacity without user intervention.  
- ❌ Managed disks and unmanaged disks behave identically in Azure, and there is no difference between them.  
- ❌ All Azure disks are unmanaged by default; you must configure managed disks manually if needed.  

---

### ✅ Correct Answer:
**Managed disks include Standard HDD, Standard SSD, Premium SSD, and Ultra Disk. Unmanaged disks are page blobs in a storage account that you must manage yourself.**

---

### 🔍 Explanation

**Managed Disks:**  
- Azure handles the **storage account creation**, **scaling**, **availability**, and **IOPS limits** automatically.  
- Types:  
  - ✅ **Standard HDD**  
  - ✅ **Standard SSD**  
  - ✅ **Premium SSD**  
  - ✅ **Ultra Disk**  
- Simplifies management — you don't worry about storage account capacity or performance limits.

**Unmanaged Disks:**  
- Implemented as **page blobs** in a user-managed storage account.  
- You must:  
  - Monitor **storage account capacity and IOPS limits**.  
  - Distribute disks across multiple storage accounts if needed to avoid hitting limits.  
  - Ensure availability and redundancy manually.

**Key Considerations for Unmanaged Disks:**  
- Manual operational overhead (storage account quotas, scaling).  
- More prone to hitting performance limits if not carefully planned.  
- Today, **managed disks are the default and recommended option**.

---

### ❌ Why Other Options Are Wrong
- **"Managed disks must be managed manually"** → Opposite of the truth.  
- **"No difference between managed and unmanaged"** → There are major differences in responsibility and scalability.  
- **"All disks are unmanaged by default"** → Managed disks are the default in the Azure portal since 2017.

---

### 📖 Official Microsoft Reference:
- [Managed disks overview](https://learn.microsoft.com/azure/virtual-machines/managed-disks-overview)  
- [Introduction to unmanaged disks](https://learn.microsoft.com/azure/virtual-machines/virtual-machines-windows-unmanaged-disks)

---

**Summary:** Managed disks are the default and offload capacity, scaling, and availability management to Azure, while unmanaged disks require you to manually manage storage accounts and their limits.

---

# Question 6

You are working with Azure Virtual Machines and need to understand:

- How to limit traffic to and from a VM  
- Which common ports are important for security and access  

### ❓ Question:
How do you limit traffic to and from a VM in Azure, and what are some important ports to know?

- ❌ Use Azure Security Center to encrypt traffic and block all incoming requests automatically  
- ✅ **Use Azure Network Security Groups (NSGs) to allow or deny traffic based on rules. Common ports to watch include 22, 80, 443, and 3389.**  
- ❌ Use Azure Active Directory to apply traffic policies directly to the VM  
- ❌ Use Azure Traffic Manager to block unauthorized traffic  

---

### ✅ Correct Answer:
**Use Azure Network Security Groups (NSGs) to allow or deny traffic based on rules. Common ports include 22 (SSH), 80 (HTTP), 443 (HTTPS), and 3389 (RDP).**

---

### 🔍 Explanation

**Azure Network Security Groups (NSGs):**  
NSGs are the primary way to control inbound and outbound network traffic to Azure resources, including VMs.  

You can create **rules** that allow or deny traffic based on:  
- **Source/Destination** IP address or subnet  
- **Protocol** (TCP, UDP)  
- **Port number**  
- **Direction** (Inbound or Outbound)

**Important Ports to Watch:**  
- **22** → SSH (Linux VM remote access)  
- **3389** → RDP (Windows VM remote access)  
- **80** → HTTP (unsecured web traffic)  
- **443** → HTTPS (secure web traffic)  

**Security Tip:**  
Restrict remote access ports (22, 3389) to trusted IPs whenever possible to reduce attack surface.

---

### ❌ Why Other Options Are Wrong
- **Azure Security Center** → Gives recommendations but doesn’t directly filter traffic.  
- **Azure Active Directory** → Handles authentication/identity, not network filtering.  
- **Azure Traffic Manager** → Balances traffic across regions, not used for blocking traffic.  

---

### 📖 Official Microsoft Reference:
- [What is a Network Security Group?](https://learn.microsoft.com/azure/virtual-network/network-security-groups-overview)

---

**Summary:** You control VM traffic with NSGs by creating allow/deny rules, and you should monitor critical ports like 22, 3389, 80, and 443 for security.

---

# Question 7 (Mark for Review)

You are preparing to deploy a Virtual Machine (VM) in Azure and need to understand:

- Which Azure resources are required to create a VM with the desired configuration  
- What steps are needed to ensure specific features are enabled on that VM  

### ❓ Question:
Which resources are necessary to deploy a VM with the desired configuration, and what are the steps to ensure a VM has a feature enabled?

- ❌ You need only a storage account. Install desired features manually after deployment.  
- ✅ **You need a virtual network, a subnet, a public IP address (optional), a network interface card, and a disk. Use extensions or configuration at deployment time to enable features.**  
- ❌ You need an Azure Active Directory tenant and a Key Vault. Enable features using RBAC roles.  
- ❌ You need an availability set and an NSG. Enable features by scaling the VM manually after deployment.  

---

### ✅ Correct Answer:
**You need a virtual network, subnet, (optional) public IP, NIC, and disk. Use VM extensions or configuration during deployment to enable features.**

---

### 🔍 Explanation

**Resources Required to Deploy a VM:**
- **Virtual Network (VNet)** → Required for networking.  
- **Subnet** → Logical segment of the VNet where the VM resides.  
- **Network Interface Card (NIC)** → Connects the VM to the subnet.  
- **Public IP Address (Optional)** → Needed if external internet access is required.  
- **Disks** → OS disk is required; optional data disks can be attached.  

**Steps to Ensure Features Are Enabled:**
- **VM Extensions** → Install software, enable monitoring, configure management tools at deployment time.  
- **ARM Templates / Bicep** → Automate configuration and ensure consistency across environments.  
- **Desired State Configuration (DSC)** → Enforce specific settings post-deployment.  

**Best Practice:** Configure features during deployment rather than after — ensures consistency, automation, and reduces manual errors.

---

### ❌ Why Other Options Are Wrong
- **Storage Account only** → Not required for modern VMs with managed disks.  
- **Azure AD + Key Vault only** → Relevant for identity/secrets, not VM creation.  
- **Availability Set + NSG only** → Help with availability and security, but you still need networking and disks to deploy the VM.  

---

### 📖 Official Microsoft Reference:
- [Quickstart: Create a VM with Azure Portal](https://learn.microsoft.com/azure/virtual-machines/windows/quick-create-portal)

---

**Summary:** To deploy a VM, you need a VNet, subnet, NIC, (optional) public IP, and disks — and you should enable required features at deployment using extensions or ARM templates for automation.

---

# Question 8

You are working with Azure Resource Manager (ARM) templates and need to know:

- What are the main sections that make up an ARM template?  

### ❓ Question:
What are the main sections of an Azure Resource Manager (ARM) template?

- ❌ Schema, Version, Actions, Storage, Compute  
- ✅ **Parameters, Variables, Resources, Outputs**  
- ❌ Identity, Networking, Storage, Compute  
- ❌ Location, Size, ResourceGroup, Outputs  

---

### ✅ Correct Answer:
**Parameters, Variables, Resources, Outputs**

---

### 🔍 Explanation

**ARM Template Main Sections:**

- **Parameters** → Allow passing values into the template at deployment time (e.g., location, VM size).  
- **Variables** → Store and reuse calculated values, resource names, or concatenated strings.  
- **Resources** → Define which Azure resources to deploy (VMs, VNets, storage accounts, etc.).  
- **Outputs** → Return values after deployment (e.g., a public IP address or resource ID).

This structure makes templates reusable, consistent, and flexible.

---

### ❌ Why Other Options Are Wrong
- **Schema, Version, Actions, Storage, Compute** → Not actual sections of ARM templates (Schema and ContentVersion exist but are metadata, not main sections).  
- **Identity, Networking, Storage, Compute** → These are resource types, not structural sections.  
- **Location, Size, ResourceGroup, Outputs** → These are resource properties or parameters, not top-level sections.

---

### 📖 Official Microsoft Reference:
- [ARM Template Structure and Syntax](https://learn.microsoft.com/azure/azure-resource-manager/templates/template-syntax)

---

**Summary:** ARM templates have four main sections — **Parameters**, **Variables**, **Resources**, and **Outputs** — which allow flexible, repeatable deployments.


---

# Question 9

You are working with Azure Resource Manager (ARM) templates and need to understand:

- How to declare and work with variables in a template  

### ❓ Question:
How do you create and work with variables in an ARM template?

- ❌ Declare variables inside the resources section and use them only within one resource.  
- ✅ **Declare variables in a dedicated variables section and reference them throughout the template using the `variables()` function.**  
- ❌ Declare variables by modifying the parameters section and hard-coding the values.  
- ❌ Declare variables inside the outputs section to reuse them later.  

---

### ✅ Correct Answer:
**Declare variables in the `variables` section and reference them throughout the template with the `variables()` function.**

---

### 🔍 Explanation

**Variables in ARM Templates:**
- Declared under the top-level **`variables`** section.  
- Reusable anywhere in the template using:  

```jsonc
  "[variables('variableName')]"
```

- Help reduce repetition, simplify maintenance, and make templates cleaner.

```jsonc
{
  "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
  "contentVersion": "1.0.0.0",
  "variables": {
    "storageAccountName": "examplestorageacct"
  },
  "resources": [
    {
      "type": "Microsoft.Storage/storageAccounts",
      "name": "[variables('storageAccountName')]",
      "apiVersion": "2022-09-01",
      "location": "eastus",
      "properties": {}
    }
  ]
}

```
  ❌ Why Other Options Are Wrong

- Declaring inside resources → Not valid; variables must be at the template root level.
- Hard-coding in parameters → Removes flexibility and reusability.
- Declaring in outputs → Not supported; outputs can use variables but cannot define them.

📖 Official Microsoft Reference:

- Variables in ARM templates

> Summary: Define variables once in the variables section and reference them anywhere in the template with the variables() function to keep your ARM templates clean and maintainable.

---

# Question 10

You are working with Bicep and need to know:

- How to configure a deployment for a new resource  

### ❓ Question:
When working with Bicep, how do you configure a deployment for a new resource?

- ❌ Write JSON directly into a Bicep file to define resources.  
- ✅ **Use the `resource` keyword followed by the symbolic name, resource type, and properties.**  
- ❌ Use the `deploy` keyword with a list of resources.  
- ❌ Import an ARM template into the Bicep file without modifications.  

---

### ✅ Correct Answer:
**Use the `resource` keyword followed by the symbolic name, resource type, and properties.**

---

### 🔍 Explanation

In **Bicep**, resources are declared with the `resource` keyword.  

You specify:  
- **Symbolic name** → Local name you use inside the file  
- **Resource type and API version** → e.g., `Microsoft.Storage/storageAccounts@2022-09-01`  
- **Configuration properties** → Name, location, SKU, and other settings  

**Example:**
```bicep
resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: 'examplestorageacct'
  location: 'eastus'
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {}
}
```

This syntax is much cleaner and easier to read than ARM JSON templates.

❌ Why Other Options Are Wrong

- Write JSON directly → Bicep is an abstraction over JSON, not a place to embed raw JSON.
- Use deploy keyword → There is no such keyword in Bicep.
- Import ARM template → Possible to decompile ARM templates into Bicep, but not how you define new resources.

📖 Official Microsoft Reference:

- Bicep Language - Declare Resources

> Summary: In Bicep, you use the resource keyword with a symbolic name, type, and properties to configure and deploy new resources.

----

# Question 11

You are working with ARM templates or Bicep and need to know:

- How to use variables effectively during deployments  

### ❓ Question:
How do you use variables when working with Azure Bicep or ARM templates?  
(Select one answer.)

- ❌ Declare variables inside the outputs section and reference them during resource creation.  
- ❌ Declare variables inside the resources section and hard-code them per resource.  
- ✅ **Declare variables in a `variables` block and use the `variables('variableName')` function in ARM templates or simply use `variableName` in Bicep.**  
- ❌ Declare variables dynamically by modifying the schema section during deployment.  

---

### ✅ Correct Answer:
**Declare variables in a `variables` block and use the `variables('variableName')` function in ARM templates or simply use `variableName` in Bicep.**

---

### 🔍 Explanation

Variables are used to simplify templates, reduce duplication, and make them easier to maintain.  

- **In ARM Templates (JSON)**  
  - Defined in a `variables` section  
  - Referenced with the `variables('variableName')` function  

**Example (ARM JSON):**
```jsonc
{
  "variables": {
    "storageAccountName": "examplestorageacct"
  },
  "resources": [
    {
      "type": "Microsoft.Storage/storageAccounts",
      "name": "[variables('storageAccountName')]",
      "apiVersion": "2022-09-01",
      "location": "eastus",
      "properties": {}
    }
  ]
}
```
In Bicep

- Defined using the var keyword
- Referenced directly by name (no function needed)

Example (Bicep):

```bicep
var storageAccountName = 'examplestorageacct'

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-09-01' = {
  name: storageAccountName
  location: 'eastus'
  properties: {}
}
```
❌ Why Other Options Are Wrong

- Inside outputs section → You can reference variables in outputs, but you cannot declare variables there.
- Inside resources section → Variables must be declared globally, not within individual resources.
- Modifying schema section → Schema is for template metadata, not for defining variables.

📖 Official Microsoft Reference:

- Variables in ARM Templates
- Variables in Bicep

> Summary:
In ARM templates, use variables('name'); in Bicep, use var name = value and reference it directly.

---

# Question 12

You are working with Azure Resource Manager (ARM) templates and need to understand:

- The difference between **incremental** and **complete** template deployments  

### ❓ Question:
What is the difference between an incremental and a complete template deployment?

- ❌ Incremental deployment deletes all resources in the resource group not in the template; complete deployment only adds resources.  
- ✅ **Incremental deployment only updates or adds resources defined in the template; complete deployment deletes resources not present in the template.**  
- ❌ Incremental deployment always deploys resources twice for high availability; complete deployment deploys once.  
- ❌ Incremental deployment automatically scales resources, while complete deployment locks them after creation.  

---

### ✅ Correct Answer:
**Incremental deployment only updates or adds resources defined in the template; complete deployment deletes resources not present in the template.**

---

### 🔍 Explanation

**Incremental Deployment:**  
- Adds new resources and updates existing resources **listed in the template**.  
- Leaves other existing resources in the resource group untouched.  
- Safer for ongoing deployments where you don’t want to remove resources accidentally.

**Complete Deployment:**  
- Deletes any resource in the resource group that is **not defined in the template**.  
- Ensures the resource group matches the template exactly.  
- Useful for “clean slate” deployments but can remove unintended resources if not careful.

---

### ❌ Why Other Options Are Wrong
- **Deleting all resources in incremental** → Incorrect; incremental leaves unmentioned resources intact.  
- **Deploying twice for high availability** → Deployment happens once unless explicitly retried.  
- **Scaling and locking automatically** → Not related to deployment modes.

---

### 📖 Official Microsoft Reference:
- [Deployment modes - Incremental and Complete](https://learn.microsoft.com/azure/azure-resource-manager/templates/deployment-modes)

---

**Summary:** Incremental deployments add or update resources without removing others, while complete deployments remove resources not defined in the template to match it exactly.

---

# Question 13

You are working with Azure App Services and need to understand:

- The relationship between **App Service Plans** and **App Services**  

### ❓ Question:
What is the relationship between App Service Plans and App Services in Azure?

- ✅ **An App Service Plan defines the infrastructure and features (such as pricing and scaling), while App Services (like web apps, APIs) run inside the App Service Plan.**  
- ❌ An App Service Plan is the application code, and App Services provide storage for the code.  
- ❌ App Services manage the billing and networking; App Service Plans handle user authentication.  
- ❌ App Service Plans and App Services are completely independent; they don't affect each other.  

---

### ✅ Correct Answer:
**An App Service Plan defines the infrastructure and features, and App Services run inside it.**

---

### 🔍 Explanation

**App Service Plan:**  
- Determines the **compute resources** (CPU, memory, storage) available to apps.  
- Defines the **pricing tier** (Free, Shared, Basic, Standard, Premium).  
- Manages **scaling options**, including manual and auto-scaling.  

**App Services:**  
- Include **Web Apps, API Apps, Mobile Apps, and Function Apps**.  
- Are the actual applications you deploy and run.  
- Can share the same App Service Plan to save costs if resource demands are moderate.

**Key Relationship:**  
- An App Service **cannot exist without an App Service Plan**.  
- Multiple App Services can share one plan, but the plan controls their resources, pricing, and scaling.

---

### ❌ Why Other Options Are Wrong
- **App Service Plan is application code** → Incorrect; it’s infrastructure, not code.  
- **App Services handle billing and networking** → Billing is tied to the App Service Plan, not the app itself.  
- **Completely independent** → False; App Services rely on a plan to run.

---

### 📖 Official Microsoft Reference:
- [What is an Azure App Service Plan?](https://learn.microsoft.com/azure/app-service/overview-hosting-plans)

---

**Summary:** App Service Plans provide the compute, scaling, and pricing for your apps, while App Services are the applications that run inside these plans.

---

# Question 14

You are working with Azure App Services and need to know:

- Whether an App Service can be associated with more than one App Service Plan  

### ❓ Question:
Can an Azure App Service be associated with more than one App Service Plan?

- ❌ Yes, an App Service can belong to multiple App Service Plans at the same time.  
- ✅ **No, an App Service can belong to only one App Service Plan at a time.**  
- ❌ Yes, but only if the App Service is duplicated manually across regions.  
- ❌ No, App Service Plans and App Services are unrelated to each other.  

---

### ✅ Correct Answer:
**No, an App Service can belong to only one App Service Plan at a time.**

---

### 🔍 Explanation

- Each **Azure App Service** is linked to a single **App Service Plan**.  
- The **App Service Plan** provides compute resources, scaling, and pricing for the App Service.  
- To use a different plan, you must **migrate the App Service** to another plan manually, ensuring it is in the same **resource group and region**.  
- While multiple App Services can share a plan, **a single App Service cannot span multiple plans**.

---

### ❌ Why Other Options Are Wrong
- **Multiple plans at once** → Not supported; only one plan per App Service.  
- **Duplicating manually** → Creates a new app instance, not the same app linked to multiple plans.  
- **Plans and services unrelated** → False; the plan provides the hosting environment for the App Service.

---

### 📖 Official Microsoft Reference:
- [Migrate an app to another App Service Plan](https://learn.microsoft.com/azure/app-service/overview-hosting-plans#change-an-app-service-plan)

---

**Summary:** An Azure App Service can only belong to a single App Service Plan, though multiple services can share the same plan.

---

# Question 15

You are working with Azure App Services and need to know:

- Where to select the operating system and configure the app type (code, container, or static)  

### ❓ Question:
Where do you select the operating system and configure the choice between code, container, or static hosting in Azure App Service?

- ❌ You choose the OS and app type when creating the App Service Plan.  
- ❌ You choose the OS and app type inside the App Service configuration after deployment.  
- ✅ **You choose the OS during App Service creation, and the app type (code, container, or static) at the creation step as well.**  
- ❌ You cannot select the OS or app type in Azure App Service; they are assigned automatically based on your region.  

---

### ✅ Correct Answer:
**You choose the OS during App Service creation, and the app type (code, container, or static) during creation as well.**

---

### 🔍 Explanation

When creating a new App Service in Azure:

- **Operating System** → Choose **Windows**, **Linux**, or **Container**.  
- **Publish Option / App Type** → Select one of the following:
  - **Code** → Run application code directly (e.g., Node.js, .NET, Python).  
  - **Docker Container** → Deploy from a container registry.  
  - **Static Web App** → For hosting static files (handled separately in Azure Static Web Apps).  

> This selection occurs **during the creation step**, not after deployment.

---

### ❌ Why Other Options Are Wrong
- **During App Service Plan creation** → The plan only defines compute resources, not OS or app type.  
- **Inside App Service after deployment** → OS and type must be chosen at creation; changing later is difficult.  
- **Assigned automatically based on region** → False; the OS and type are manually selected regardless of region.

---

### 📖 Official Microsoft References:
- [Create an Azure App Service web app](https://learn.microsoft.com/azure/app-service/quickstart-create-app)  
- [Operating system choices for Azure App Service](https://learn.microsoft.com/azure/app-service/overview#operating-system)

---

> **Summary:** The OS and app type (code, container, or static) are selected during the App Service creation process, not in the App Service Plan or post-deployment.

---

# Question 16

You are working with Azure App Services and need to know:

- Which App Service Plan is the entry-level plan that allows scaling  

### ❓ Question:
Which Azure App Service Plan is the entry-level plan that allows scaling?

- ✅ **Basic Plan (B1 and higher)**  
- ❌ Free Plan  
- ❌ Shared Plan  
- ❌ Standard Plan (S1 and higher)  

---

### ✅ Correct Answer:
**Basic Plan (B1 and higher)**

---

### 🔍 Explanation

- **Basic Plan (B1 and higher):**  
  - Entry-level plan that supports **manual scaling**.  
  - Can **scale up** to larger VM sizes or **scale out** to more instances.  

- **Free and Shared Plans:**  
  - Do **not allow manual scaling**.  
  - Limited compute resources suitable for testing or very small workloads.  

- **Standard Plan (S1 and higher):**  
  - Supports scaling and more advanced features, but is **not entry-level**.  

---

### 📖 Official Reference:
- [App Service Plans in Azure](https://learn.microsoft.com/azure/app-service/overview-hosting-plans)

---

**Summary:** The **Basic Plan (B1 and higher)** is the entry-level Azure App Service Plan that allows scaling of compute resources.

---

# Question 17

You are working with Azure App Services and need to know:

- Which App Service Plan is required to support **deployment slots**  

### ❓ Question:
Which Azure App Service Plan is the minimum required to support deployment slots?

- ❌ Free Plan  
- ❌ Basic Plan  
- ✅ **Standard Plan (S1 and higher)**  
- ❌ Premium Plan (P1v2 and higher)  

---

### ✅ Correct Answer:
**Standard Plan (S1 and higher)**

---

### 🔍 Explanation

- **Deployment Slots:**  
  - Allow you to create **staging environments** for testing before swapping to production.  
  - Useful for zero-downtime deployments and testing new app versions.

- **Availability by Plan:**  
  - **Free and Basic Plans:** Do **not** support deployment slots.  
  - **Standard Plan (S1 and higher):** Supports deployment slots.  
  - **Premium Plans:** Also support slots, but Standard is the minimum required.  

---

### 📖 Official Reference:
- [Deployment slots in Azure App Service](https://learn.microsoft.com/azure/app-service/deploy-staging-slots)

---

**Summary:** Deployment slots are supported starting from the **Standard Plan (S1 and higher)** in Azure App Service.

----

# Question 18

You are working with Azure App Services and need to know:

- Which App Service Plans support **custom domains**  

### ❓ Question:
Which Azure App Service Plans allow the use of custom domains?

- ❌ Only Premium and Isolated Plans  
- ✅ **Basic, Standard, Premium, and Isolated Plans**  
- ❌ Free and Shared Plans  
- ❌ Only Standard and Premium Plans  

---

### ✅ Correct Answer:
**Basic, Standard, Premium, and Isolated Plans**

---

### 🔍 Explanation

- **Custom domains** allow your web app to be accessed via a domain you own instead of the default `*.azurewebsites.net`.  
- **Availability by Plan:**  
  - **Basic Plan and above (Basic, Standard, Premium, Isolated):** Support custom domains.  
  - **Free and Shared Plans:** Do **not** support custom domains.  

---

### 📖 Official Reference:
- [Add a custom domain to your Azure App Service](https://learn.microsoft.com/azure/app-service/app-service-web-tutorial-custom-domain)

---

**Summary:** Custom domains are supported starting with the **Basic Plan**, and also available in Standard, Premium, and Isolated plans.

---

# Question 19

You are working with Azure App Services and need to know:

- The minimum App Service Plan required to enable **private networking (VNet Integration)**  

### ❓ Question:
What is the minimum Azure App Service Plan required to enable private networking (VNet Integration)?

- ❌ Free Plan  
- ❌ Basic Plan  
- ✅ **Standard Plan (S1 and higher)**  
- ❌ Premium Plan (P1v2 and higher)  

---

### ✅ Correct Answer:
**Standard Plan (S1 and higher)**

---

### 🔍 Explanation

- **Regional VNet Integration:**  
  - Allows your App Service to connect to an **Azure Virtual Network (VNet)**.  
  - Requires **Standard Plan or higher**.  

- **Private Endpoint Access:**  
  - For full private network access to the app (via Private Endpoint), a **PremiumV2 or Isolated plan** is required.  

- **Free and Basic Plans:**  
  - Do **not** support VNet integration.

---

### 📖 Official Reference:
- [VNet Integration with Azure App Service](https://learn.microsoft.com/azure/app-service/overview-vnet-integration)

---

**Summary:** Regional VNet Integration is supported starting with the **Standard Plan (S1 and higher)**, while full private endpoint access requires PremiumV2 or Isolated plans.

---

# Question 20

You are working with Azure App Services and need to know:

- Whether an App Service and its App Service Plan can be deployed in different regions  

### ❓ Question:
Can an Azure App Service Plan and the App Service be deployed into different regions?

- ❌ Yes, App Services and App Service Plans can be in different regions without restrictions.  
- ✅ **No, an App Service must always be in the same region as its App Service Plan.**  
- ❌ Yes, but only if you create a Traffic Manager profile.  
- ❌ No, unless you configure regional VNet integration manually.  

---

### ✅ Correct Answer:
**No, an App Service must always be in the same region as its App Service Plan.**

---

### 🔍 Explanation

- The **App Service Plan** defines the **compute resources (VMs) and region** for the App Service.  
- An **App Service cannot exist in a different region** from its plan.  
- To deploy apps in multiple regions, you need **separate App Service Plans** in each region.  

---

### ❌ Why Other Options Are Wrong
- **Different regions without restrictions** → Not allowed; Azure enforces same-region deployment.  
- **Traffic Manager profile** → Routes traffic between regions but doesn’t split the app and plan across regions.  
- **VNet Integration** → Only relates to private networking, not the region placement.  

---

### 📖 Official Microsoft Reference:
- [Azure App Service Plan overview](https://learn.microsoft.com/azure/app-service/overview-hosting-plans)

---

**Summary:** An App Service must always be deployed in the **same region** as its App Service Plan.

---

# Question 21

You are working with an Azure App Service and need to:

- Create and manage custom variables and settings  
- Set environment variables  
- Store connection strings securely  

### ❓ Question:
How do you create custom variables and settings in Azure App Service? Where should environment variables and connection strings be configured?

- ❌ Define variables in your application code and redeploy every time you change them.  
- ✅ **Set custom variables and environment variables in the App Service Configuration settings. Store connection strings separately under the Connection Strings section in Configuration.**  
- ❌ Hard-code environment variables and connection strings directly into the App Service Plan settings.  
- ❌ Use Azure Key Vault exclusively for environment variables and connection strings; App Service cannot store them.  

---

### ✅ Correct Answer:
**Set custom variables and environment variables in the App Service Configuration settings. Store connection strings under the Connection Strings section.**

---

### 🔍 Explanation

- **App Service Configuration Settings:**  
  - Navigate to your App Service in the Azure Portal → **Configuration** under **Settings**.  
  - **Application Settings:** Add custom environment variables (key-value pairs).  
  - **Connection Strings:** Add database or other service connection strings separately.  
  - Azure automatically injects these as **environment variables** at runtime.

- **Benefits:**  
  - Changes can be made **without redeploying** your app.  
  - Centralized management of secrets and settings.

- **Other Options Explained:**  
  - **Define in code and redeploy** → Not necessary; Configuration handles it dynamically.  
  - **Hard-code in App Service Plan** → Plan manages compute resources, not app settings.  
  - **Only Azure Key Vault** → Optional; App Service itself provides built-in configuration storage.

---

### 📖 Official Microsoft References:
- [Configure apps in Azure App Service](https://learn.microsoft.com/azure/app-service/configure-common)  
- [Securely store app secrets and settings in Azure App Service](https://learn.microsoft.com/azure/app-service/app-service-key-vault-references)

---

**Summary:** Custom variables and environment variables are configured in the **App Service Configuration**, and connection strings are stored separately under **Connection Strings**, allowing updates without redeployment.

---

# Question 22

You are working with Azure and need to know:

- Which runtime is required to **host containers**  

### ❓ Question:
Which runtime is required to host containers in Azure?

- ❌ Windows runtime for App Service hosting  
- ❌ Linux runtime for App Service hosting  
- ✅ **A container runtime like Docker or containerd must be used**  
- ❌ Azure Kubernetes Service runtime  

---

### ✅ Correct Answer:
**A container runtime like Docker or containerd must be used**

---

### 🔍 Explanation

- **Container Runtime Requirement:**  
  - Azure requires a container runtime to **pull, run, and manage containers**.  
  - Common runtimes:  
    - **Docker**  
    - **containerd** (lightweight runtime often used under the hood)

- **Azure App Service:**  
  - If you select **Docker Container** during creation, the platform handles the runtime for you.  

- **Other Azure Services:**  
  - **AKS (Azure Kubernetes Service)** and **ACI (Azure Container Instances)** run containers via Docker or containerd directly.

- **Other Options Explained:**  
  - **Windows runtime** → Needs a container runtime installed to run containers.  
  - **Linux runtime** → Common for containers, but still requires Docker/containerd.  
  - **AKS runtime** → AKS itself orchestrates containers but relies on Docker/containerd internally.

---

### 📖 Official Microsoft References:
- [App Service custom containers overview](https://learn.microsoft.com/azure/app-service/containers/)  
- [Containerd in AKS](https://learn.microsoft.com/azure/aks/concepts-container-runtime)

---

**Summary:** Hosting containers in Azure requires a **container runtime like Docker or containerd**, which manages the container lifecycle.

---

# Question 23

You are working with Azure Container Registry (ACR) and need to:

- Interact with ACR from your local machine to **push, pull, or manage container images**  

### ❓ Question:
How do you interact with Azure Container Registry (ACR) from your local machine?

- ❌ Install Azure DevOps agents and configure a build pipeline.  
- ✅ **Use the Azure CLI to log in to the registry, and Docker CLI to push and pull images.**  
- ❌ Use Azure Storage Explorer to browse and upload container images.  
- ❌ Connect through SSH directly to the ACR service endpoint.  

---

### ✅ Correct Answer:
**Use the Azure CLI to log in to the registry, and Docker CLI to push and pull images.**

---

### 🔍 Explanation

To interact with ACR from your local machine:

1. **Log in to ACR using Azure CLI:**  
```bash
az acr login --name <ACRName>
```

Use Docker CLI to manage images:

- Tag an image:
```bash 
docker tag local-image <ACRName>.azurecr.io/myimage:tag
```
- push an image: 
```bash
docker push <ACRName>.azurecr.io/myimage:tag
```
- Pull an image:
```bash
docker pull <ACRName>.azurecr.io/myimage:tag
```
Azure CLI handles authentication; Docker CLI performs the container operations.

❌ Why Other Options Are Wrong

- Azure DevOps agents → Useful for automation, not direct local interaction.
- Azure Storage Explorer → For Blob Storage, not container registries.
- SSH directly to ACR → Not possible; ACR is a managed service without SSH access.

📖 Official Microsoft Reference:

Quickstart: Authenticate and use Azure Container Registry with Docker CLI

> Summary: Use Azure CLI for authentication and Docker CLI to push and pull images to interact with Azure Container Registry from your local machine.

---

# Question 24

You are working with Azure Container Instances (ACI) and need to know:

- Whether environment variables can be changed in a **running container**

### ❓ Question:
Can you change the variables in a running Azure Container Instance (ACI)?

- ❌ Yes, you can modify variables in a running container without restarting.  
- ✅ **No, environment variables are set at deployment time and cannot be changed without redeploying.**  
- ❌ Yes, but only by connecting through SSH and manually updating the environment.  
- ❌ No, unless you enable dynamic variable update mode on the container.  

---

### ✅ Correct Answer:
**No, environment variables are set at deployment time and cannot be changed without redeploying.**

---

### 🔍 Explanation

- In **ACI**, environment variables are defined **at container creation**.  
- **Changing variables requires redeployment**:  
  1. Delete the running container.  
  2. Deploy a new container with updated environment variables.  

- This aligns with **standard container practices**, where containers are immutable once running.

- **Other Options Explained:**  
  - **Modify without restart** → Not possible; containers are immutable.  
  - **SSH and modify** → Environment variables for the process cannot change dynamically.  
  - **Dynamic variable update mode** → No such feature exists in ACI or standard container platforms.

---

### 📖 Official Microsoft Reference:
- [Azure Container Instances - Configure environment variables](https://learn.microsoft.com/azure/container-instances/container-instances-environment-variables)

---

**Summary:** Environment variables in ACI are **immutable at runtime** and require **redeployment** to change.

---

# Question 25

You are working with a container hosted in Azure App Service and need to know:

- Whether environment variables can be changed after deployment  

### ❓ Question:
Can you change the environment variables of a container hosted in Azure App Service?

- ❌ No, environment variables are locked after container deployment.  
- ✅ **Yes, you can update environment variables in App Service Configuration, and the app restarts automatically.**  
- ❌ Yes, but you must manually connect to the container and edit a config file.  
- ❌ No, unless you completely remove and redeploy the App Service.  

---

### ✅ Correct Answer:
**Yes, you can update environment variables in App Service Configuration, and the app restarts automatically.**

---

### 🔍 Explanation

- **App Service Configuration:**  
  - Access via the Azure Portal → **Configuration** blade.  
  - Or use the **Azure CLI** to update environment variables.  
- **Automatic Restart:**  
  - When environment variables are updated, App Service automatically restarts the app to apply the changes.  
- **No redeployment needed:**  
  - Updates are applied externally without having to redeploy the container manually.  

- **Comparison with ACI:**  
  - Unlike Azure Container Instances, App Service allows runtime updates of environment variables.  

- **Other Options Explained:**  
  - **Locked after deployment** → Incorrect; App Service supports updates.  
  - **Manually edit inside container** → Not needed; configuration is managed externally.  
  - **Must redeploy** → Wrong; restart happens automatically without full redeployment.

---

### 📖 Official Microsoft Reference:
- [Configure environment variables for Azure App Service](https://learn.microsoft.com/azure/app-service/configure-common#application-settings)

---

**Summary:** Environment variables in an Azure App Service container can be **updated via Configuration**, triggering an **automatic app restart** without redeployment.

---

# Question 26

You are managing containers using **Azure Kubernetes Service (AKS)** or **Azure Container Apps** and need to know:

- Whether environment variables can be changed for running containers  
- How this differs from App Service or Azure Container Instances  

### ❓ Question:
In Kubernetes (AKS) or Azure Container Apps, can you change environment variables of a running container?

- ❌ No, environment variables are locked after deployment in both AKS and Azure Container Apps.  
- ✅ **Yes, you can edit the deployment configuration (or app revision), but the container must restart for changes to take effect.**  
- ❌ Yes, you can change environment variables instantly without restarting or redeploying anything.  
- ❌ No, unless you delete the entire cluster or app environment.  

---

### ✅ Correct Answer:
**Yes, you can edit the deployment configuration (or app revision), but the container must restart for changes to take effect.**

---

### 🔍 Explanation

**In Kubernetes (AKS):**  
- Environment variables are set in the **Deployment YAML** or Helm chart.  
- To update:  
  1. Modify the YAML configuration with the new environment variables.  
  2. Apply the changes using `kubectl apply -f <deployment.yaml>`.  
- Kubernetes **recreates the pods**, so containers restart to pick up new variables.

**In Azure Container Apps:**  
- Modify **revisions or configuration settings**.  
- Changing environment variables triggers Azure to create a **new app revision** automatically.  
- The app restarts seamlessly with the new configuration applied.

**Key Point:**  
- Both services require a **container restart or pod recreation** to apply environment variable changes.  
- Unlike App Service, you cannot update variables live in a running container without a restart.

---

### ❌ Other Options Explained
- **Locked after deployment** → Wrong; variables can be updated, but restart is required.  
- **Instant without restart** → Not possible; environment variables are injected at startup.  
- **Delete cluster/app** → Overkill; restarting pods or rolling out a new revision is sufficient.

---

### 📖 Official Microsoft References
- [Configure environment variables in Kubernetes](https://kubernetes.io/docs/tasks/inject-data-application/environment-variable-expose/)  
- [Environment variables in Azure Container Apps](https://learn.microsoft.com/azure/container-apps/environment-variables)

---

**Summary:** In AKS or Azure Container Apps, **environment variables can be updated**, but the **container or pod must restart** for changes to take effect.

---

# Question 27

You are working with **Azure Container Instances (ACI)** and need to know:

- Whether ACIs can run on a **private network**

### ❓ Question:
Can you have an Azure Container Instance (ACI) running on a private network?

- ❌ No, Azure Container Instances can only be deployed with a public IP address.  
- ✅ **Yes, you can deploy Azure Container Instances into an Azure Virtual Network (VNet) for private access.**  
- ❌ Yes, but only if you deploy them inside an App Service Environment (ASE).  
- ❌ No, unless you use Azure Kubernetes Service (AKS) instead.  

---

### ✅ Correct Answer:
**Yes, you can deploy Azure Container Instances into an Azure Virtual Network (VNet) for private access.**

---

### 🔍 Explanation

- **VNet Integration:**  
  - ACI can be deployed inside an **Azure Virtual Network**, giving it a **private IP**.  
  - No exposure to the **public internet** unless a public endpoint is configured.  
  - Enables secure communication with **private resources** like databases, APIs, or other services in the same VNet.

- **Use Cases:**  
  - Backend services  
  - Secure data processing  
  - Any scenario requiring restricted network access  

- **Other Options Explained:**  
  - **Only public IPs** → Incorrect; VNets are supported.  
  - **App Service Environment (ASE)** → Not applicable; ASE is for App Services.  
  - **Need AKS** → AKS can also do private networking, but ACI can independently run in a VNet.

---

### 📖 Official Microsoft Reference:
- [Deploy container instances into an Azure virtual network](https://learn.microsoft.com/azure/container-instances/container-instances-vnet)

---

**Summary:** Azure Container Instances **can run in a VNet** with a private IP, enabling secure, private network access.

---

# Question 28

You are working with **Azure Container Registry (ACR)** and need to know:

- How to authenticate when pushing, pulling, or managing container images  

### ❓ Question:
How do you authenticate against Azure Container Registry (ACR)?

- ❌ Use username and password only.  
- ✅ **Use Azure Active Directory (Azure AD) identities, managed identities, service principals, or admin account credentials.**  
- ❌ Use SSH keys only.  
- ❌ No authentication is required for public registries.  

---

### ✅ Correct Answer:
**Use Azure Active Directory (Azure AD) identities, managed identities, service principals, or admin account credentials.**

---

### 🔍 Explanation

- **Authentication Options:**  
  - **Azure AD identities:** For users or applications with role-based access.  
  - **Managed identities:** Automatically handled for VMs, App Services, or other Azure resources.  
  - **Service principals:** Application identities with specific permissions.  
  - **Admin account credentials:** Username/password generated by ACR (less secure, legacy option).  

- **Security Notes:**  
  - Prefer **Azure AD or managed identities** for production workloads.  
  - Admin account credentials are simpler but less secure.  
  - Supports **role-based access control (RBAC)** for fine-grained permissions.

- **Other Options Explained:**  
  - **Username/password only** → Not recommended; limits security.  
  - **SSH keys** → Not supported for ACR.  
  - **No authentication for public registries** → Only applies to public Docker Hub or similar, not private ACR instances.

---

### 📖 Official Microsoft Reference:
- [Authentication with Azure Container Registry](https://learn.microsoft.com/azure/container-registry/container-registry-authentication)

---

**Summary:** ACR authentication supports **Azure AD, managed identities, service principals, or admin credentials**, with role-based access preferred for security.

---

# Question 29

You are working with **Azure Container Registry (ACR)** and want to know:

- Whether you can apply **per-user, per-image access control**  

### ❓ Question:
Can you get granular, per-user control over individual images inside Azure Container Registry (ACR)?

- ❌ No, access control is registry-wide only; all users have the same permissions.  
- ✅ **Yes, by using Azure RBAC (Role-Based Access Control) scoped to individual repositories.**  
- ❌ Yes, but only if you move images to different ACR instances.  
- ❌ No, ACR does not support per-image or per-repository permissions.  

---

### ✅ Correct Answer:
**Yes, by using Azure RBAC (Role-Based Access Control) scoped to individual repositories.**

---

### 🔍 Explanation

- **Repository-Scoped Permissions:**  
  - ACR supports **Azure RBAC** at both registry and repository levels.  
  - Roles include:  
    - **AcrPull:** Read-only access to pull images.  
    - **AcrPush:** Push and pull images.  
    - **AcrDelete:** Delete images.  

- **Granular Control:**  
  - Apply roles **per repository**, allowing users to:  
    - Push to one repository while only pulling from another  
    - Restrict deletion rights to certain users  

- **Other Options Explained:**  
  - **Registry-wide only** → Incorrect; fine-grained repository scoping exists.  
  - **Move images to different registries** → Unnecessary; RBAC handles granularity.  
  - **No per-image permissions** → Incorrect; repository-level RBAC supports fine control.

---

### 📖 Official Microsoft Reference:
- [Repository-scoped permissions in Azure Container Registry](https://learn.microsoft.com/azure/container-registry/container-registry-repository-scoped-permissions)

---

**Summary:** Azure Container Registry supports **per-user, per-repository access** using RBAC, enabling fine-grained control over image operations.

---

# Question 30

You are working with **Azure Container Registry (ACR)** and want to know:

- Whether ACR can automate **image builds and deployments**  

### ❓ Question:
Can Azure Container Registry (ACR) run automated builds and deployments for your images?

- ❌ No, ACR can only store images; build and deployment must be handled externally.  
- ✅ **Yes, ACR Tasks can automate image builds, updates, and deployments based on code changes or schedule.**  
- ❌ Yes, but only if you use Azure DevOps pipelines attached to the ACR.  
- ❌ Yes, but you must manually trigger a build every time from the Azure Portal.  

---

### ✅ Correct Answer:
**Yes, ACR Tasks can automate image builds, updates, and deployments based on code changes or schedule.**

---

### 🔍 Explanation

- **ACR Tasks Features:**  
  - **Automated builds:** Trigger builds when source code changes (GitHub, Azure Repos).  
  - **Scheduled builds:** Nightly or periodic builds.  
  - **Base image update triggers:** Rebuild dependent images automatically if the base image changes.  
  - **Multi-step tasks:** Build, test, and push complex workflows in one task.  

- **Benefits:**  
  - Skip setting up a full CI/CD pipeline for simple image automation.  
  - Reduce manual intervention and maintain up-to-date container images.

- **Other Options Explained:**  
  - **Only store images** → Incorrect; ACR supports automation with ACR Tasks.  
  - **Only via Azure DevOps** → Incorrect; native ACR Tasks handle automation.  
  - **Manual triggers only** → Incorrect; ACR Tasks can be fully automated.

---

### 📖 Official Microsoft Reference:
- [Quickstart: Build and deploy container images with Azure Container Registry Tasks](https://learn.microsoft.com/azure/container-registry/container-registry-tasks-overview)

---

**Summary:** ACR Tasks allow **fully automated builds and deployments** of container images based on source changes, schedules, or base image updates.

---

# Question 31

You are working with **Azure Functions** and want to understand the purpose of the `host.json` file.

### ❓ Question:
What is the purpose of the host.json file in an Azure Functions project?

- ❌ To configure deployment slots and scaling policies for the App Service Plan.  
- ✅ **To set global runtime configuration options and behaviors for all functions in the app.**  
- ❌ To define the environment variables used by individual functions.  
- ❌ To define the environment variables used by individual functions.  

---

### ✅ Correct Answer:
**To set global runtime configuration options and behaviors for all functions in the app.**

---

### 🔍 Explanation

- **Global Configuration:**  
  - `host.json` applies settings to the **entire Function App**, affecting all individual functions.  

- **What it controls:**  
  - Timeout settings  
  - Retry policies  
  - Logging settings  
  - Binding configurations (e.g., max queue message dequeue count)  
  - JSON serialization options  

- **Benefits:**  
  - Centralized control of Function App behavior.  
  - Overrides at individual function level are possible if needed.  

- **Other Options Explained:**  
  - **Deployment slots and scaling** → Managed at App Service Plan, not `host.json`.  
  - **Environment variables** → Set in Configuration settings, not `host.json`.  
  - **Application code** → Placed in function folders, not in `host.json`.

---

### 📖 Official Microsoft Reference:
- [host.json reference for Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-host-json)

---

**Summary:** `host.json` centrally manages **global runtime behaviors** for all functions within an Azure Function App.

---

# Question 32

You are working with **Azure Functions** and want to understand the purpose of the `function.json` file.

### ❓ Question:
What is the purpose of the function.json file in an Azure Function?

- ✅ **To define the triggers, inputs, and outputs for a specific function.**  
- ❌ To store secrets like connection strings and keys for the function.  
- ❌ To configure App Service Plan settings for the Function App.  

---

### ✅ Correct Answer:
**To define the triggers, inputs, and outputs for a specific function.**

---

### 🔍 Explanation

- **Function-Specific Configuration:**  
  - `function.json` applies to **one individual function** within the Function App.  

- **What it configures:**  
  - **Trigger** → What event causes the function to run (e.g., HTTP request, queue message, blob upload).  
  - **Input Bindings** → Data sources the function can read from (e.g., a blob, a database).  
  - **Output Bindings** → Where the function writes data (e.g., storage queue, database, blob).  

- **Benefit:**  
  - Connects your function to external events and data sources **without hardcoding** them in your code.

- **Other Options Explained:**  
  - **Store secrets** → Secrets are handled via Azure Key Vault or Application Settings, not `function.json`.  
  - **Configure App Service Plan** → That is managed at the Function App or App Service Plan level, not per function.

---

### 📖 Official Microsoft Reference:
- [function.json reference for Azure Functions](https://learn.microsoft.com/azure/azure-functions/functions-triggers-bindings#functionjson)

---

**Summary:** `function.json` defines **triggers, inputs, and outputs** for a single Azure Function, connecting it to external events and data sources.

---

# Question 33

You are analyzing an **Azure Function's** `function.json` file and want to understand what information it provides.

### ❓ Question:
What information can you determine by reading a `function.json` file?

- ✅ **Which external events trigger the function, where the function reads and writes data, and details about binding configurations.**  
- ❌ Global runtime behavior like retries, timeouts, and logging settings.  
- ❌ Details about the App Service Plan size and deployment slots.  
- ❌ The Azure region where the Function App is hosted.  

---

### ✅ Correct Answer:
**Which external events trigger the function, where the function reads and writes data, and details about binding configurations.**

---

### 🔍 Explanation

- **Triggers and Bindings:**  
  - `function.json` tells you:
    - **Trigger** → What event causes the function to run (HTTP request, queue message, blob upload, etc.).
    - **Input Bindings** → Where the function reads data from.
    - **Output Bindings** → Where the function writes data.
    - **Binding configurations** → Settings for each binding (e.g., queue name, path, or connection).

- **Other Options Explained:**  
  - **Global runtime behavior** → Controlled by `host.json`, not `function.json`.  
  - **App Service Plan or deployment slots** → Managed at the App Service level, outside `function.json`.  
  - **Azure region** → Set when creating the Function App, not defined in `function.json`.  

---

### 📖 Official Microsoft Reference:
- [function.json file reference](https://learn.microsoft.com/azure/azure-functions/functions-triggers-bindings#functionjson)

---

**Summary:** `function.json` shows **triggers, input/output bindings, and binding details** for a single Azure Function.

---

# Question 34

You are learning about **Azure Functions** and want to understand what a **Function trigger** is.

### ❓ Question:
What is a Function trigger in Azure Functions?

- ❌ A Function trigger is the code that defines the logic of the function.  
- ✅ **A Function trigger is an event that causes the Azure Function to run.**  
- ❌ A Function trigger is the app configuration for scaling the function.  
- ❌ A Function trigger is an external tool that deploys a function to Azure.  

---

### ✅ Correct Answer:
**A Function trigger is an event that causes the Azure Function to run.**

---

### 🔍 Explanation

- **Definition:**  
  A trigger is **required** for every Azure Function.  
  It determines **what event starts (fires) the function execution**.

- **Examples of Triggers:**  
  - HTTP request  
  - Queue message arrival  
  - Scheduled time (Timer trigger)  
  - Blob creation or modification  

- **Key Point:**  
  - Without a trigger, the function **will not execute**.  
  - The trigger does **not** define the function’s logic itself — it only initiates it.

---

**Summary:** A Function trigger is **the event that causes the Azure Function to run**, like HTTP requests, timers, or messages.


---

# Question 35

You are learning about **Azure Active Directory (Azure AD)** and Multi-Factor Authentication (MFA).

### ❓ Question:
What are the various ways a user can satisfy MFA sign-in requirements in Azure AD?

- ✅ **Use a password combined with a verification code sent by SMS**  
- ✅ **Use a password combined with a call to a registered phone number**  
- ✅ **Use a password combined with biometric authentication through Microsoft Authenticator**  
- ❌ Use password-only authentication without any second step  
- ✅ **Use FIDO2 security keys or Windows Hello for Business as second factors**  

---

### ✅ Correct Answers:
- Password + SMS code  
- Password + phone call  
- Password + biometric (Microsoft Authenticator)  
- FIDO2 security keys or Windows Hello for Business  

---

### 🔍 Explanation:
Azure AD Multi-Factor Authentication (MFA) requires **two or more verification methods**. Users can combine their password with:

1. **SMS verification** – a code sent to a registered mobile number.  
2. **Phone call verification** – a call to a registered phone number.  
3. **Authenticator app** – like Microsoft Authenticator, using a code or biometric (fingerprint/face).  
4. **Hardware/security keys** – such as FIDO2 keys or Windows Hello for Business.

- **Password-only authentication** is **not sufficient** for MFA.  

---

**Summary:** Azure AD MFA can be satisfied using **SMS, phone call, Authenticator app (biometric), or hardware security keys** in addition to a password.

----

# Question 36

You are learning about **Azure Role-Based Access Control (RBAC)**.

### ❓ Question:
What are the four primary built-in roles used for managing Azure subscriptions and resource groups?

- ✅ **Owner**  
- ✅ **Contributor**  
- ✅ **Reader**  
- ✅ **User Access Administrator**  
- ❌ Developer  

---

### ✅ Correct Answers:
- **Owner** – Full access to all resources, including the ability to delegate access.  
- **Contributor** – Can create and manage all types of Azure resources but cannot grant access to others.  
- **Reader** – Can view resources but cannot make any changes.  
- **User Access Administrator** – Can manage user access to Azure resources.  

---

### 🔍 Explanation:
- These four roles cover the primary management scenarios in Azure.  
- **Developer** is **not a built-in role**; typical developer actions fall under **Contributor** or custom roles.  
- Other roles like **Billing Reader** exist but are limited in scope and not part of core resource management.

---

**Summary:** The four main Azure RBAC roles for managing subscriptions and resource groups are **Owner, Contributor, Reader, and User Access Administrator**.

---

# Question 37

You are learning about **identity and access management** in Azure.

### ❓ Question:
What is the purpose of an identity provider? What is a scope?

- ❌ To provide virtual machines for user workloads.  
- ✅ To securely authenticate and verify user or application identities.  
- ❌ To handle billing and resource provisioning in cloud environments.  
- ❌ To encrypt data stored in cloud services.  

---

### ✅ Correct Answer:
**To securely authenticate and verify user or application identities.**

---

### 🔍 Explanation:
- An **Identity Provider (IdP)** handles **authentication**, verifying that a user, application, or device is who they claim to be.  
- Common examples of IdPs:
  - **Azure Active Directory (Azure AD) / Microsoft Entra ID**
  - **Google Identity**
  - **Facebook Login**
  - **Okta, Auth0**, etc.
- After authentication, the IdP issues **tokens** (e.g., OAuth 2.0 or OpenID Connect tokens) used for **authorization**.  

Other options explained:

- Virtual machines, billing, or encryption → These are unrelated to identity verification.

---

**Summary:** An identity provider's primary role is to **authenticate and verify identities**, enabling secure access to applications and resources.

---

# Question 37 (Revisited)

You are learning about **identity and access management** in Azure.

### ❓ Question:
What is the purpose of an identity provider? What is a scope?

- ❌ To provide virtual machines for user workloads  
- ✅ To securely authenticate and verify user or application identities  
- ❌ To handle billing and resource provisioning in cloud environments  
- ❌ To encrypt data stored in cloud services  

---

### ✅ Correct Answer:
**To securely authenticate and verify user or application identities**

---

### 🔍 Explanation:
- An **Identity Provider (IdP)** is responsible for **authentication**—confirming that a user, application, or device is who they claim to be.  
- Common examples of IdPs include:
  - **Azure Active Directory (Azure AD) / Microsoft Entra ID**
  - **Google Identity**
  - **Facebook Login**
  - **Okta, Auth0**, etc.
- After successful authentication, the IdP issues **tokens** (like **OAuth 2.0** or **OpenID Connect** tokens) that applications can use for **authorization** to access resources.  

**Other options explained:**

- Virtual machines, billing, or encryption → These are unrelated to the role of an identity provider.

---

**Summary:** An identity provider's main function is to **authenticate and verify identities**, allowing secure access to applications and resources.  

---

# Question 38 (Updated)

You are learning about **authentication and authorization** in Azure.

### ❓ Question:
What is a scope in authentication and authorization?

- ❌ A storage location for user credentials  
- ✅ A specific permission or set of permissions that an application can request or act upon  
- ❌ A billing limit applied to a resource group  
- ❌ A network boundary for virtual machines in the cloud  

---

### ✅ Correct Answer:
**A specific permission or set of permissions that an application can request or act upon**

---

### 🔍 Explanation:
- In **OAuth 2.0** and **OpenID Connect**, a **scope** is a string that specifies **what access is being requested** by an application.  
- Scopes define:
  - The actions the app wants to perform (e.g., `"read your emails"`, `"write to your calendar"`, `"read your profile"`).  
  - The data or APIs the app is allowed to access.  

**Examples of common scopes:**
- `user.read`
- `openid`
- `email`
- `api://your-api-id/access_as_user`

✅ Scopes enable **fine-grained access control**, ensuring apps only get permissions explicitly granted to them.

**Other options explained:**
- Storage for credentials / billing / network boundaries → Incorrect; scopes define **permissions**, not locations, billing limits, or network settings.

---

**Summary:** A **scope** defines the **specific permissions** an application can request or act upon, controlling what it can access or perform.

---

# Question 39

You are learning about **identity and access management** in Azure.

### ❓ Question:
What is a service principal in Azure?

- ❌ A human user account for logging into the Azure portal  
- ✅ A dedicated identity used by applications, automation, or services to access Azure resources securely  
- ❌ An Azure subscription account used for billing purposes  
- ❌ A private storage account for sensitive application data  

---

### ✅ Correct Answer:
**A dedicated identity used by applications, automation, or services to access Azure resources securely**

---

### 🔍 Explanation:
- A **service principal** is an **application identity** created in **Azure Active Directory (Azure AD)**.  
- It allows **apps, automation scripts, or services** to authenticate and interact with Azure resources **securely**.  
- It has its own **permissions** (via Role-Based Access Control) **independent of any user accounts**.  
- Think of it as a "**user account for an application**".

✅ Service principals are essential for:
- Secure automation  
- DevOps pipelines  
- Service-to-service communication in Azure

**Other options explained:**
- Human user account → Incorrect; service principals are non-human identities.  
- Subscription account → Incorrect; subscriptions are for billing, not authentication.  
- Private storage → Incorrect; storage accounts are for data, not identities.

---

**Summary:** A service principal is a **dedicated identity for applications or services** to securely access Azure resources.

---

# Question 40

You are learning about **identity and access management** in Azure.

### ❓ Question:
Can an identity (user, application, or service principal) cross Azure boundaries?

- ❌ No, identities are locked inside their tenant and cannot cross any boundary  
- ✅ Yes, identities can cross subscription and region boundaries within the same tenant, but need special configurations to cross tenant boundaries  
- ❌ Yes, identities are fully global and automatically have access to any Azure resources worldwide  
- ❌ No, unless the resource owner exports the identity and re-imports it manually in the destination region or tenant  

---

### ✅ Correct Answer:
**Yes, identities can cross subscription and region boundaries within the same tenant, but need special configurations to cross tenant boundaries**

---

### 🔍 Explanation:
- **Within the same Azure AD tenant**:
  - Identities can access multiple subscriptions.
  - Identities can operate across multiple regions.
  - This works automatically without special setup.

- **Across different Azure AD tenants**:
  - Identities cannot cross tenants automatically.
  - Special configuration is required:
    - **Azure B2B collaboration** (invite external users).
    - **Cross-tenant access settings** in Microsoft Entra ID.
    - Guest user invitations or service principal permissions.

✅ Summary:
- **Subscriptions & regions** → identities can cross easily within a tenant.  
- **Tenant boundaries** → deliberate setup is required.

**Other options explained:**
- Locked inside a tenant → incorrect for subscriptions/regions.  
- Fully global automatic access → incorrect; explicit permissions are required.  
- Export/re-import manually → not needed; Azure has built-in cross-tenant collaboration features.

---

**Official References:**
- [Azure Active Directory B2B collaboration](https://learn.microsoft.com/azure/active-directory/external-identities/what-is-b2b)
- [Manage cross-tenant access settings (Microsoft Entra)](https://learn.microsoft.com/azure/active-directory/external-identities/cross-tenant-access-settings)

---

# Question 41

You are learning about **managed identities** in Azure.

### ❓ Question:
What are the two types of managed identities in Azure?

- ✅ System-assigned and user-assigned managed identities  
- ❌ Region-assigned and subscription-assigned managed identities  
- ❌ Admin-assigned and guest-assigned managed identities  

---

### ✅ Correct Answer:
**System-assigned and user-assigned managed identities**

---

### 🔍 Explanation:
Managed identities provide Azure resources with an automatically managed identity for authentication.

**System-assigned managed identity:**
- Tied **1:1** with a specific Azure resource.
- Lifecycle is automatic — deleted if the resource is deleted.
- Ideal for resource-specific authentication.

**User-assigned managed identity:**
- Created manually and can be **shared across multiple resources**.
- Lifecycle is independent of the resources using it.
- Ideal for scenarios where multiple resources need the same identity.

**Other options explained:**
- Region/subscription-assigned → Not valid types of managed identities.  
- Admin/guest-assigned → These are Azure AD roles, not managed identity types.  

---

**Official Reference:**
[Managed identities for Azure resources overview](https://learn.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview)

---

# Question 42

You are learning about **Azure Managed Identities**.

### ❓ Question:
Which type of Azure Managed Identity must be manually deleted?

- ❌ System-assigned managed identity  
- ✅ User-assigned managed identity  
- ❌ Both system-assigned and user-assigned managed identities  
- ❌ Neither, both are automatically deleted by Azure  

---

### ✅ Correct Answer:
**User-assigned managed identity**

---

### 🔍 Explanation:
- **User-assigned managed identity:**
  - Created as a **separate Azure resource**.
  - **Not automatically deleted** when the resource it is associated with (like a VM or App Service) is deleted.
  - Must be manually deleted if no longer needed.
  - Can be shared across multiple resources, giving flexibility.

- **System-assigned managed identity:**
  - Automatically created and tied **1:1** to a resource.
  - **Deleted automatically** when the associated resource is deleted.

Other options explained:

- Both automatically deleted → Incorrect; only system-assigned identities are auto-deleted.

---

**Official Reference:**
[User-assigned managed identities overview](https://learn.microsoft.com/azure/active-directory/managed-identities-azure-resources/overview#user-assigned-managed-identities)

> summary: User-assigned managed identities must be manually deleted because they exist independently of the resources they are attached to, unlike system-assigned identities which are deleted automatically.

---

# Question 43

What are the three types of information that can be securely stored in Azure Key Vault?

- ❌ Certificates, passwords, and user accounts  
- ✅ Keys, secrets, and certificates  
- ❌ Passwords, public IP addresses, and blob storage accounts  
- ❌ Keys, managed identities, and network security groups  

---

### ✅ Correct Answer:
**Keys, secrets, and certificates**

---

### 🔍 Explanation:

Azure Key Vault is designed to securely store sensitive information that your applications and services need. This includes:

- **Keys** → Cryptographic keys for encrypting data or signing operations.  
- **Secrets** → Passwords, API keys, or other confidential strings.  
- **Certificates** → SSL/TLS certificates for secure communications.  

Other options explained:

- User accounts, public IPs, managed identities, network security groups → These are managed in other Azure services, not Key Vault.

---

### **Summary:**  
Azure Key Vault securely stores **keys, secrets, and certificates** to protect sensitive information used by applications and services.

---

# Question 44

How can you prevent your Azure Key Vault from being accidentally deleted?

- ✅ Apply a soft delete and purge protection to the Key Vault.  
- ❌ Set the Key Vault access policy to "read-only."  
- ❌ Enable role-based access control (RBAC) and assign only Reader roles.  
- ❌ Move the Key Vault to a locked resource group.  

---

### ✅ Correct Answer:
**Apply a soft delete and purge protection to the Key Vault.**

---

### 🔍 Explanation:

Azure Key Vault provides features to protect it from accidental or intentional deletion:

- **Soft Delete** → When a Key Vault is deleted, it is retained for a retention period before permanent deletion.  
- **Purge Protection** → Prevents the permanent deletion of a Key Vault while the retention period is active, even if someone tries to purge it.

Other options explained:

- **Access policy "read-only"** → Prevents modifications but does not stop deletion.  
- **RBAC with Reader roles** → Readers cannot modify, but someone with higher privileges could still delete it.  
- **Locked resource group** → Azure does have resource locks, but soft delete and purge protection are more effective specifically for Key Vault protection.

---

### **Summary:**  
To protect an Azure Key Vault from accidental deletion, enable **soft delete** and **purge protection**.

---

# Question 45

Can you have multiple versions of a secret active at the same time in Azure Key Vault?

- ❌ Yes, you can have multiple active versions of a secret, and all versions are valid at the same time.  
- ✅ No, Azure Key Vault allows only one active version of a secret at a time; older versions remain stored but are not active unless explicitly accessed.  
- ❌ Yes, but only if you replicate the Key Vault across multiple regions.  
- ❌ No, secret versions are overwritten immediately with each update.  

---

### ✅ Correct Answer:
**No, Azure Key Vault allows only one active version of a secret at a time; older versions remain stored but are not active unless explicitly accessed.**

---

### 🔍 Explanation:

- Azure Key Vault supports multiple versions of the same secret.  
- **Only one version is considered "current" and active by default**.  
- Older versions are retained and can be explicitly accessed if needed.  

Benefits of versioning:

- Roll back to an earlier version if necessary.  
- Implement key rotation strategies.  
- Manage secret lifecycle without data loss.  

- Updating a secret automatically creates a new version, but only the latest is active unless an older version is specifically requested.

Other options explained:

- **Multiple active versions** → Incorrect; only one is active by default.  
- **Replication across regions** → Not related to secret versioning.  
- **Overwritten immediately** → Incorrect; previous versions are stored and accessible.

---

### **Summary:**  
Azure Key Vault allows multiple secret versions, but **only one version is active at a time**; older versions remain stored for rollback or reference.

---

# Question 46

What are two ways a secret can exist in Azure Key Vault but still be unusable?  
*(Select two answers.)*

- ✅ The secret is disabled.  
- ✅ The secret has expired.  
- ❌ The secret is deleted but not purged.  
- ❌ The secret is in a different Azure region.  
- ❌ The secret is locked by a firewall rule.  

---

### ✅ Correct Answers:
- **The secret is disabled**  
- **The secret has expired**

---

### 🔍 Explanation:

A secret in Azure Key Vault may exist but be unusable in the following cases:

1. **Disabled secret:**  
   - When a secret's `enabled` property is set to `false`, it remains stored in the Key Vault but cannot be used until re-enabled.

2. **Expired secret:**  
   - If a secret has an expiration date (`exp`) and the date has passed, the secret cannot be used, even though it physically exists in the vault.

Other options explained:

- **Deleted but not purged** → The secret is in a deleted state and no longer active.  
- **Different region** → The secret's usability is not affected by region; it’s tied to its Key Vault.  
- **Firewall lock** → Access might be blocked, but the secret itself is still active in the vault.

---

### **Summary:**  
A secret can exist in Azure Key Vault but be unusable if it is **disabled** or **expired**, even though it physically remains in the vault.

✅ Official Microsoft Reference:  
[Azure Key Vault secrets attributes](https://learn.microsoft.com/en-us/azure/key-vault/secrets/about-secrets#attributes)


---

# Question 47

What is the purpose of an access policy in Azure Key Vault?

- ❌ To define backup and restore settings for the vault.  
- ✅ To control who can perform specific operations like reading secrets or writing keys inside the vault.  
- ❌ To automatically rotate certificates stored inside the vault.  
- ❌ To create firewall rules that restrict access based on IP addresses.  

---

### ✅ Correct Answer:
**To control who can perform specific operations like reading secrets or writing keys inside the vault.**

---

### 🔍 Explanation:

An **access policy** in Azure Key Vault:

- Defines which **users, applications, or services** can perform specific actions such as:
  - Reading secrets
  - Writing keys
  - Managing certificates
- Acts as a **permission layer** specific to Key Vault operations.
- Without the correct access policy, even users with Azure access to the Key Vault cannot manage or retrieve the vault contents.

Other options explained:

- **Backup and restore settings** → Not controlled via access policies.  
- **Certificate rotation** → Access policies don’t handle automatic rotation.  
- **Firewall rules** → Network restrictions are separate from access policies.

---

### **Summary:**  
Access policies in Azure Key Vault are used to **control and restrict which identities can perform specific operations** on secrets, keys, and certificates.

✅ Official Microsoft Reference:  
[Azure Key Vault Security Overview](https://learn.microsoft.com/en-us/azure/key-vault/general/overview-security)

---

# Question 48

Can you get fine-grained access level control to individual secrets in Azure Key Vault?

- ❌ Yes, by assigning specific permissions at the individual secret level.  
- ✅ No, access policies apply only at the entire Key Vault level.  
- ❌ Yes, by creating separate Key Vaults for each secret.  
- ❌ No, you must use Azure Storage instead of Key Vault for fine-grained access.  

---

### ✅ Correct Answer:
**No, access policies apply only at the entire Key Vault level.**

---

### 🔍 Explanation:

- Azure Key Vault **access policies** or **RBAC permissions** apply at the **vault level**, not the individual secret level.  
- Granting a user access to read secrets allows them to read **all secrets** in that Key Vault.  
- To achieve more isolated access (e.g., a user can access only one secret), you must create **separate Key Vaults** for each secret and manage access individually.  
- Fine-grained, per-secret control **is not natively supported** within a single Key Vault.

---

### **Summary:**  
Access control in Azure Key Vault is **vault-wide**, and individual secrets cannot have separate access policies.  

✅ Official Microsoft Reference:  
[Azure Key Vault Data Plane Access Control](https://learn.microsoft.com/en-us/azure/key-vault/general/overview-security#data-plane-access-control)


---

# Question 49

Why might a developer choose to implement Azure App Configuration?

- ❌ To deploy container images into Azure Kubernetes Service (AKS).  
- ✅ To centralize application settings and feature flags across multiple apps and environments.  
- ❌ To manage user identities and permissions across Azure resources.  
- ❌ To automatically back up Azure Storage blobs.  

---

### ✅ Correct Answer:
**To centralize application settings and feature flags across multiple apps and environments.**

---

### 🔍 Explanation:

- **Azure App Configuration** centralizes application settings and **feature flags**, so developers do not need to hardcode configurations in each app.  
- Supports **multiple apps** and **environments** (development, staging, production).  
- Allows **dynamic updates** without redeploying applications.  
- Not intended for container deployments, identity management, or storage backups.

---

### **Summary:**  
Azure App Configuration helps developers **centralize and manage app settings and feature flags** across apps and environments.  

✅ Official Microsoft Reference:  
[Azure App Configuration Overview](https://learn.microsoft.com/en-us/azure/azure-app-configuration/overview)


---

# Question 50

What is a CDN, and how do you implement a CDN in Azure?

- ❌ A CDN is a centralized database for storing application settings; you implement it by using Azure App Configuration.  
- ❌ A CDN is a service that stores application code in Azure Repos; you implement it by creating a Git repository.  
- ✅ A CDN is a network of servers that cache content closer to users; you implement it by creating an Azure CDN profile and endpoint.  
- ❌ A CDN is a security service that blocks DDoS attacks; you implement it by enabling Azure DDoS Protection.  

---

### ✅ Correct Answer:
**A CDN is a network of servers that cache content closer to users; you implement it by creating an Azure CDN profile and endpoint.**

---

### 🔍 Explanation:

- **Content Delivery Network (CDN):** A globally distributed network of servers that cache and deliver web content (images, scripts, videos, etc.) based on a user’s geographic location.  
- **Benefits:**  
  - Faster load times  
  - Reduced bandwidth usage  
  - Improved user experience  
- **Azure Implementation:**  
  1. Create a **CDN profile**.  
  2. Create a **CDN endpoint** that points to your origin (Blob Storage, web app, or external source).  
- **Not Used For:** Application settings (Azure App Configuration), version control (Azure Repos), or DDoS mitigation (Azure DDoS Protection).

---

### **Summary:**  
An Azure CDN caches content closer to users for **faster delivery** and is implemented by creating a **CDN profile and endpoint**.  

✅ Official Microsoft Reference:  
[Azure CDN Overview](https://learn.microsoft.com/en-us/azure/cdn/cdn-overview)

---

# Question 51

What types of information are ideal candidates to host on a CDN?

- ✅ Large video and image files that rarely change.  
- ❌ Database transaction records.  
- ❌ User authentication credentials.  
- ❌ Encrypted secrets and connection strings.  

---

### ✅ Correct Answer:
**Large video and image files that rarely change.**

---

### 🔍 Explanation:

- **CDN Best Use:**  
  - Large static files (images, videos, PDFs)  
  - Static assets (JavaScript, CSS, HTML)  
  - Rarely changing content  
- **Benefits:**  
  - Reduced latency  
  - Lower origin server load  
  - Faster load times for users worldwide  

- **Not Suitable For:**  
  - Dynamic or transactional data (e.g., database records)  
  - Sensitive information (credentials, secrets, connection strings)

---

### **Summary:**  
Use a CDN to host **static, rarely changing content** like large images, videos, or static files for faster global delivery.  

✅ Official Microsoft Reference:  
[Typical Content Served Through a CDN](https://learn.microsoft.com/en-us/azure/cdn/cdn-overview#typical-content-served-through-a-cdn)

---

# Question 52

How does a CDN work in relation to user requests, serving data, and Time-To-Live (TTL)?

- ❌ When a user makes a request, the CDN always contacts the original server to fetch the latest data.  
- ✅ When a user makes a request, the CDN first checks its cache; if the content is cached and valid based on TTL, it serves the content directly without contacting the origin server.  
- ❌ The CDN replicates the full database and performs dynamic authentication before serving content.  
- ❌ The CDN encrypts the request and forwards it to Azure Active Directory before responding.  

---

### ✅ Correct Answer:
**When a user makes a request, the CDN first checks its cache; if the content is cached and valid based on TTL, it serves the content directly without contacting the origin server.**

---

### 🔍 Explanation:

- **CDN Request Flow:**  
  1. User requests content.  
  2. CDN edge server checks its cache.  
  3. If cached content is still valid (based on TTL):  
     - Served directly from the edge (fast, no origin call).  
  4. If not cached or expired:  
     - CDN fetches from origin server, caches it, then serves to the user.  

- **TTL (Time-To-Live):**  
  - Defines how long content stays cached.  
  - After TTL expires, CDN will re-fetch from origin on the next request.  

- **Benefits:**  
  - Reduced latency  
  - Lower origin server load  
  - Faster user experience  

---

### **Summary:**  
A CDN **serves cached content from edge servers if it is still valid (based on TTL)**, otherwise it fetches fresh content from the origin, caches it, and then serves it to the user.  

✅ Official Microsoft Reference:  
[How a CDN Works](https://learn.microsoft.com/en-us/azure/cdn/cdn-how-it-works)

---

# Question 53

What are the major components of Azure Monitor?

- ❌ Azure Logic Apps, Azure Key Vault, and Azure Functions  
- ✅ Metrics, Logs, Alerts, and Visualizations (like Dashboards and Workbooks)  
- ❌ Azure Blob Storage, Azure DevOps, and Azure Active Directory  
- ❌ Virtual Machines, Storage Accounts, and App Service Plans  

---

### ✅ Correct Answer:
**Metrics, Logs, Alerts, and Visualizations (like Dashboards and Workbooks)**

---

### 🔍 Explanation:

Azure Monitor is designed to **collect, analyze, and act on telemetry data** from Azure and on-premises resources. Its major components are:

- **Metrics:**  
  Real-time numerical data about resource performance (e.g., CPU usage, memory usage, request counts).

- **Logs:**  
  Detailed, queryable event and diagnostic data stored in a Log Analytics workspace.

- **Alerts:**  
  Automated triggers that respond to certain metric or log conditions (e.g., send emails, trigger action groups).

- **Visualizations:**  
  Dashboards, Workbooks, and Insights for monitoring, troubleshooting, and analysis.

> Azure Monitor itself does not include services like Logic Apps, DevOps, or Active Directory, though it can monitor them.

---

### **Summary:**  
**Azure Monitor’s core components are Metrics, Logs, Alerts, and Visualizations — together enabling collection, analysis, and action on telemetry data across your Azure resources.**

✅ Official Microsoft Reference:  
[Azure Monitor Overview](https://learn.microsoft.com/en-us/azure/azure-monitor/overview)

---

# Question 55

What is an availability test? How do you create a test to check if your website is responding?

- ❌ An availability test is a firewall configuration; you create it by setting up IP filtering on your web app.  
- ❌ An availability test is a manual login check; you create it by asking users to report downtime.  
- ✅ An availability test checks the website’s uptime and responsiveness; you create it by setting up a ping or URL test in Application Insights.  
- ❌ An availability test is a backup service; you create it by enabling backup policies on your App Service.  

---

### ✅ Correct Answer:
**An availability test checks the website’s uptime and responsiveness; you create it by setting up a ping or URL test in Application Insights.**

---

### 🔍 Explanation:

An **availability test** in Azure **Application Insights** is used to automatically and continuously verify if your website or service is:

- **Available** (responds successfully to requests)
- **Responsive** (returns results within an acceptable time)

How to create one:

1. Open your **Application Insights resource** in the Azure portal.
2. Select **Availability**.
3. Create a **standard URL ping test** by entering your site’s URL.
4. Optionally configure:
   - Locations (test from multiple regions)
   - Alerting (receive notifications on failures)
   - Multi-step web tests (simulate user interactions)

This helps detect outages or slowdowns before users are impacted.

> Availability tests are not related to firewall settings, backups, or manual reporting.

---

### **Summary:**  
**Availability tests in Application Insights automatically ping your site from multiple regions to verify uptime and alert you if it becomes unavailable or slow.**

✅ Official Microsoft Reference:  
[Azure Monitor Application Insights – Availability Tests](https://learn.microsoft.com/en-us/azure/azure-monitor/app/availability-overview)

---

# Question 56

What is the purpose of the Application Map in Azure Application Insights, and what must you do to get it working with your solution?

- ❌ The Application Map shows network traffic usage between virtual machines; you enable it by configuring Azure Traffic Manager.  
- ✅ The Application Map shows the architecture of your application and its dependencies; you enable it by instrumenting your app with Application Insights SDK and collecting telemetry.  
- ❌ The Application Map shows cost optimization recommendations; you enable it by connecting your App Service to Azure Advisor.  
- ❌ The Application Map shows DNS resolution times; you enable it by setting up Azure DNS Analytics.  

---

### ✅ Correct Answer:
**The Application Map shows the architecture of your application and its dependencies; you enable it by instrumenting your app with Application Insights SDK and collecting telemetry.**

---

### 🔍 Explanation:

The **Application Map** in **Azure Application Insights** helps you:

- **Visualize** your application architecture automatically.
- **See dependencies** like databases, APIs, storage accounts, and other connected services.
- **Monitor performance & failures** at each node or connection.
- **Identify bottlenecks** and failure points in distributed systems.

To make the Application Map work:

1. **Instrument your application** with Application Insights:
   - Add the SDK to your app or enable auto-instrumentation (for supported platforms like .NET, Java, Node.js).
2. Allow telemetry to be sent to Azure.
3. Application Insights will automatically build the map based on actual traffic and dependencies observed.

---

### **Summary:**  
**The Application Map provides a visual representation of your app’s architecture and dependencies, showing performance and failure data — you enable it by instrumenting your app with Application Insights to send telemetry data.**

✅ Official Microsoft Reference:  
[Application Map in Azure Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-map)

---

# Question 57

What are the three main aspects of creating an alert in Azure Monitor?

- ✅ Choosing a resource, setting a condition, and defining an action group.  
- ❌ Selecting a billing model, enabling a firewall rule, and setting up a backup policy.  
- ❌ Configuring a CDN, setting a TTL, and creating a traffic manager profile.  
- ❌ Assigning a storage account, selecting a virtual machine size, and configuring virtual networks.  

---

### ✅ Correct Answer:
**Choosing a resource, setting a condition, and defining an action group.**

---

### 🔍 Explanation:

When you create an alert in **Azure Monitor**, there are **three main steps**:

1. **Choose a Resource**  
   Select the Azure resource you want to monitor, such as:
   - Virtual Machine  
   - App Service  
   - Storage Account  

2. **Set a Condition**  
   Define what should trigger the alert, for example:
   - CPU usage > 80%  
   - HTTP request failures > a specific threshold  

3. **Define an Action Group**  
   Decide what happens when the alert fires:
   - Send an email or SMS  
   - Trigger a webhook  
   - Call an Azure Function or Logic App  

This process ensures you monitor the right resources, detect critical conditions, and respond automatically.

---

### **Summary:**  
**Creating an Azure Monitor alert involves picking a resource, defining the condition to watch, and specifying an action group to respond when the condition is met.**

✅ Official Microsoft Reference:  
[Azure Monitor Alerts Overview](https://learn.microsoft.com/en-us/azure/azure-monitor/alerts/alerts-overview)


---

# Question 58

What are some of the main ways to visualize information from Azure Monitor?

- ✅ Using Dashboards, Workbooks, Metrics Explorer, and Logs (Kusto queries)  
- ❌ By downloading CSV files manually every day and uploading them into PowerPoint  
- ❌ Through Azure Backup and Site Recovery services  
- ❌ By modifying Azure Active Directory authentication settings  

---

### ✅ Correct Answer:
**Using Dashboards, Workbooks, Metrics Explorer, and Logs (Kusto queries)**

---

### 🔍 Explanation:

Azure Monitor provides several built-in tools to help you visualize and analyze monitoring data:

1. **Dashboards**  
   - Customizable views in the Azure portal  
   - Can pin metrics, charts, and visualizations  

2. **Workbooks**  
   - Interactive reports that mix text, charts, and queries  
   - Great for analysis, storytelling, and sharing with teams  

3. **Metrics Explorer**  
   - Allows real-time exploration of metric data  
   - Useful for trend analysis and spotting anomalies  

4. **Logs (Kusto Queries)**  
   - Use KQL to query logs  
   - Visualize results as charts or graphs directly in the portal  

These tools help monitor health, diagnose issues, and gain insights across resources—without manual exports or unrelated services like Azure Backup or AAD settings.

---

### **Summary:**  
**Azure Monitor data is best visualized through Dashboards, Workbooks, Metrics Explorer, and Kusto query-based log charts.**

✅ Official Microsoft Reference:  
[Visualizing Azure Monitor Data](https://learn.microsoft.com/en-us/azure/azure-monitor/visualize/overview)

---

# Question 59

Where in Azure can you create visualizations? What are some additional tools that allow you to create visualizations?

- ✅ In Azure Monitor using Dashboards and Workbooks; additionally, you can use Power BI and Grafana for external visualizations.  
- ❌ In Azure DevOps using release pipelines; additionally, you can use Azure Kubernetes Service and Azure App Configuration.  
- ❌ In Azure Key Vault using secrets explorer; additionally, you can use Azure Policy for creating visual charts.  
- ❌ In Azure Storage Explorer; additionally, you can use Azure Active Directory groups for monitoring reports.  

---

### ✅ Correct Answer:
**In Azure Monitor using Dashboards and Workbooks; additionally, you can use Power BI and Grafana for external visualizations.**

---

### 🔍 Explanation:

- **Azure Monitor Dashboards:** Customizable, interactive views of metrics and logs.  
- **Azure Monitor Workbooks:** Detailed reports combining text, metrics, and query results for deeper insights.  
- **External tools:**  
  - **Power BI** → Business intelligence dashboards and reporting.  
  - **Grafana** → Real-time monitoring and graphing of metrics, often for IT/DevOps use.  

Other options (Azure DevOps, Key Vault, Storage Explorer, etc.) do not provide built-in capabilities for creating visualizations.

---

### **Summary:**  
**Visualizations are primarily created in Azure Monitor (Dashboards & Workbooks), with Power BI and Grafana as external options for advanced reporting.**

✅ Official Microsoft Reference:  
[Visualizing Azure Monitor Data](https://learn.microsoft.com/en-us/azure/azure-monitor/visualize/overview)

---

# Question 60

What are the different offerings within Azure API Management (APIM) for deployment of solutions? Which tier(s) get a Developer portal?

- ❌ The Basic, Developer, Standard, and Premium tiers; only the Premium tier includes a Developer portal.  
- ✅ The Consumption, Developer, Basic, Standard, and Premium tiers; all tiers except Consumption include a Developer portal.  
- ❌ Only the Consumption and Basic tiers; the Developer portal is available only in Consumption.  
- ❌ The Free, Shared, and Isolated tiers; all tiers have the Developer portal.  

---

### ✅ Correct Answer:
**The Consumption, Developer, Basic, Standard, and Premium tiers; all tiers except Consumption include a Developer portal.**

---

### 🔍 Explanation:

- **APIM Tiers:**
  - **Consumption:** Serverless, pay-per-use model — *no Developer portal included*.  
  - **Developer:** For development and testing — includes Developer portal.  
  - **Basic:** Entry-level production use — includes Developer portal.  
  - **Standard:** Mid-range production use with better scaling — includes Developer portal.  
  - **Premium:** Enterprise-level with multi-region support — includes Developer portal.  

- **Developer portal:**  
  Provides a user-friendly interface for developers to discover, try, and consume APIs. Only the Consumption tier does not include it, as it is designed for lightweight, event-driven use cases.

- **Note:** There are no "Free," "Shared," or "Isolated" tiers in APIM.

---

### **Summary:**  
**APIM offers Consumption, Developer, Basic, Standard, and Premium tiers; all except Consumption include a Developer portal for API discovery and testing.**

✅ Official Microsoft Reference:  
[Azure API Management features](https://learn.microsoft.com/en-us/azure/api-management/api-management-features)

--- 

Yippie! all done;
