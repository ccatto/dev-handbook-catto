# Work with Azure Blob Storage  

Learn how to use the Azure Blob Storage client library to create and update Blob storage resources.  

---

## 🎯 Learning Objectives  
By the end of this module, you’ll be able to:  
- Create an application to create and manipulate data by using the Azure Storage client library for Blob storage.  
- Manage container properties and metadata by using .NET and REST.  

---

## 📚 Prerequisites  
- Familiarity with developer concepts and terminology.  
- Experience working with unstructured data solutions.  
- Basic understanding of cloud computing and the Azure portal.  

---

## 📌 Module Outline  
- **Introduction**  
- **Explore Azure Blob Storage client library**  
- **Create a client object**  
- **Exercise – Create Blob storage resources by using the .NET client library**  
- **Manage container properties and metadata by using .NET**  
- **Set and retrieve properties and metadata for blob resources by using REST**  
- **Module assessment**  
- **Summary**  

---

🔗 **This module is part of the learning path:** *Develop solutions that use Blob storage*  


> Intro
- Create an application to create and manipulate data by using the Azure Storage client library for Blob storage.
- Manage container properties and metadata by using .NET and REST.

### Summary: Explore Azure Blob Storage Client Library  

The Azure Storage client libraries for .NET (version 12.x) provide an easy way to interact with Azure Blob Storage.  
Core client classes include `BlobClient`, `BlobContainerClient`, and `BlobServiceClient`, which allow you to manage blobs, containers, and storage resources.  
Supporting packages like `Azure.Storage.Blobs.Specialized` and `Azure.Storage.Blobs.Models` extend functionality for specific blob types and utilities.  
Microsoft recommends using version 12.x for all new applications.  

### Summary: Create a Client Object  

Working with Azure Blob Storage starts with creating client objects that map to different resource levels:  
- **BlobServiceClient** → Interacts with the storage account (list, create, delete containers).  
- **BlobContainerClient** → Focused on a single container (manage containers, list/upload/delete blobs).  
- **BlobClient** → Targets a specific blob resource.  

Authentication is handled using `DefaultAzureCredential`, which obtains an access token via Microsoft Entra ID. The requesting principal must have the proper **Azure RBAC role** for blob data access.  

```csharp
using Azure.Identity;
using Azure.Storage.Blobs;

// Service-level client
var serviceClient = new BlobServiceClient(
    new Uri($"https://{accountName}.blob.core.windows.net"),
    new DefaultAzureCredential());

// Container-level client
var containerClient = serviceClient.GetBlobContainerClient(containerName);

// Blob-level client
var blobClient = containerClient.GetBlobClient(blobName);
```

> Exercise - Create Blob storage resources by using the .NET client library
Tasks performed in this exercise:

* Prepare the Azure resources
* Create a console app to create and download data
* Run the app and verify results

https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-storage/01-blob-storage-resources-dotnet.html

* Create a resource 
```bash
chris [ ~ ]$ az group create --location eastus2 --name cattoResourceGroup
{
  "id": "/subscriptions/f2576d7d-f33d-4b87-8a89-31c7301fda6b/resourceGroups/cattoResourceGroup",
  "location": "eastus2",
  "managedBy": null,
  "name": "cattoResourceGroup",
  "properties": {
    "provisioningState": "Succeeded"
  },
  "tags": null,
  "type": "Microsoft.Resources/resourceGroups"
}
```
* creating variables
```bash
resourceGroup=cattoResourceGroup
location=eastus
accountName=storageacct$RANDOM
```

*  create the Azure Storage account

```bash
az storage account create --name $accountName \
    --resource-group $resourceGroup \
    --location $location \
    --sku Standard_LRS 

echo $accountName
```
* Run the following command to retrieve the userPrincipalName from your account
```bash
userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me \
    --headers 'Content-Type=application/json' \
    --query userPrincipalName --output tsv)
```
--- 


### Summary: Manage Container Properties and Metadata with .NET  

Blob containers support both **system properties** (like access level, last modified time) and **user-defined metadata** (custom name-value pairs).  
- **System properties** are maintained by the service, some read-only, some settable.  
- **Metadata** is user-defined, stored as case-insensitive key-value pairs, and useful for tagging or categorizing resources.  

With the `.NET` client library, you can:  
- Use `GetPropertiesAsync` to fetch system properties and metadata.  
- Use `SetMetadataAsync` to add or update custom metadata on a container.  

```csharp
// Read container system properties
var props = await container.GetPropertiesAsync();
Console.WriteLine($"Public access: {props.Value.PublicAccess}");
Console.WriteLine($"Last modified: {props.Value.LastModified}");

// Set metadata
var metadata = new Dictionary<string, string> {
    { "docType", "textDocuments" },
    { "category", "guidance" }
};
await container.SetMetadataAsync(metadata);

// Read metadata
var updatedProps = await container.GetPropertiesAsync();
foreach (var item in updatedProps.Value.Metadata)
    Console.WriteLine($"{item.Key}: {item.Value}");
```

### Summary: Set and Retrieve Properties & Metadata with REST  

Blob containers and blobs support **system properties** (standard HTTP headers) and **custom metadata** (headers prefixed with `x-ms-meta-`).  
- Metadata is stored as **case-insensitive name/value pairs** and limited to **8 KB total**.  
- Metadata can only be **set or retrieved in full** — partial updates aren't supported.  
- **Properties** use standard HTTP headers (e.g., `ETag`, `Last-Modified`), while **metadata** uses the `x-ms-meta-` prefix.  

#### Retrieve metadata
Use **GET** or **HEAD** requests to return metadata headers:  
```http
GET https://<account>.blob.core.windows.net/<container>?restype=container
GET https://<account>.blob.core.windows.net/<container>/<blob>?comp=metadata
```
Set metadata

Use PUT with `x-ms-meta-` headers to overwrite existing metadata:
```http
PUT https://<account>.blob.core.windows.net/<container>?comp=metadata&restype=container
x-ms-meta-category: images
x-ms-meta-owner: admin

PUT https://<account>.blob.core.windows.net/<container>/<blob>?comp=metadata
x-ms-meta-type: text
x-ms-meta-project: demo
```
⚠️ Sending a PUT with no metadata headers clears all existing metadata on the resource.


## ✅ Check Your Knowledge

**1. Which of the following standard HTTP headers are supported for both containers and blobs when setting properties by using REST?**  
- Last-Modified ✅  
- Content-Length  
- Origin  

**2. Which of the following classes of the Azure Storage client library for .NET allows you to manipulate both Azure Storage containers and their blobs?**  
- BlobClient  
- BlobContainerClient ✅  
- BlobUriBuilder  
