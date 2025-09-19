# 📦 Create Blob Storage Resources with the .NET Client Library

In this exercise, you will:

- 🚀 Create an **Azure Storage account**
- 💻 Build a **.NET console application** using the Azure Storage Blob client library
- 📂 Create containers, upload files, list blobs, and download files
- 🔑 Authenticate with Azure and verify results in the portal
- 🧹 Clean up resources when done

⏱️ **Approx. time**: 30 minutes

---

## 📑 Table of Contents

1. [Prepare Azure Resources](#-prepare-azure-resources)
2. [Create a Console App](#-create-a-console-app)
3. [Add Blob Storage Code](#-add-blob-storage-code)
4. [Run the App & Verify](#-run-the-app--verify)
5. [Clean Up Resources](#-clean-up-resources)

---

## 🔧 Prepare Azure Resources

Open the **Azure Portal** → [https://portal.azure.com](https://portal.azure.com).  
Launch **Cloud Shell** (choose **Bash**).

```bash
# Create a resource group
az group create --location eastus2 --name myResourceGroup

# Variables
resourceGroup=myResourceGroup
location=eastus
accountName=storageacct$RANDOM

resourceGroup=cattoResourceGroup
location=eastus
accountName=storageacct$RANDOM 

# Create storage account
az storage account create --name $accountName \
    --resource-group $resourceGroup \
    --location $location \
    --sku Standard_LRS 

echo $accountName
```

### 👤 Assign Role

```bash
# Get user principal
userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me     --headers 'Content-Type=application/json'     --query userPrincipalName --output tsv)

# Get resource ID
resourceID=$(az storage account show --name $accountName     --resource-group $resourceGroup     --query id --output tsv)

# Assign role
az role assignment create --assignee $userPrincipal     --role "Storage Blob Data Owner"     --scope $resourceID
```

---

## 💻 Create a Console App

```bash
# Create project folder
mkdir azstor && cd azstor

# Create .NET console app
dotnet new console

# Add packages
dotnet add package Azure.Storage.Blobs
dotnet add package Azure.Identity

# Create data folder
mkdir data
```

---

## 📝 Add Blob Storage Code

Open the editor:

```bash
code Program.cs
```

Paste this starter:

```csharp
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

Console.WriteLine("Azure Blob Storage exercise\n");

DefaultAzureCredentialOptions options = new()
{
    ExcludeEnvironmentCredential = true,
    ExcludeManagedIdentityCredential = true
};

await ProcessAsync();

Console.WriteLine("\nPress enter to exit the sample application.");
Console.ReadLine();

async Task ProcessAsync()
{
    // CREATE A BLOB STORAGE CLIENT
    string accountName = "YOUR_ACCOUNT_NAME"; 
    DefaultAzureCredential credential = new DefaultAzureCredential(options);
    string blobServiceEndpoint = $"https://{accountName}.blob.core.windows.net";
    BlobServiceClient blobServiceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), credential);

    // CREATE A CONTAINER
    string containerName = "wtblob" + Guid.NewGuid().ToString();
    Console.WriteLine("Creating container: " + containerName);
    BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
    Console.WriteLine("Container created successfully.");

    // CREATE A LOCAL FILE
    string localPath = "./data/";
    string fileName = "wtfile" + Guid.NewGuid().ToString() + ".txt";
    string localFilePath = Path.Combine(localPath, fileName);
    await File.WriteAllTextAsync(localFilePath, "Hello, World!");

    // UPLOAD FILE
    BlobClient blobClient = containerClient.GetBlobClient(fileName);
    using (FileStream uploadFileStream = File.OpenRead(localFilePath))
    {
        await blobClient.UploadAsync(uploadFileStream, overwrite: true);
    }
    Console.WriteLine("File uploaded.");

    // LIST BLOBS
    Console.WriteLine("Listing blobs:");
    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
    {
        Console.WriteLine("\t" + blobItem.Name);
    }

    // DOWNLOAD FILE
    string downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");
    BlobDownloadInfo download = await blobClient.DownloadAsync();
    using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
    {
        await download.Content.CopyToAsync(downloadFileStream);
    }
    Console.WriteLine($"Blob downloaded to: {downloadFilePath}");
}
```

---

## ▶️ Run the App & Verify

```bash
az login
dotnet run
```

- Go to your **Storage Account** in Azure Portal → **Data storage → Containers**
- Verify uploaded and downloaded files:
```bash
cd data
ls
```

---

## 🧹 Clean Up Resources

When finished:

1. Navigate to the **Resource Group** in the Azure Portal.  
2. Select **Delete resource group**.  
⚠️ This deletes **all resources** inside.

---

✅ Congratulations! You created and managed **Azure Blob Storage** with .NET!



---

Here are some additional notes: 

## 🔧 Prepare Azure Resources

### Where to Run Commands
You have **two options** for running Azure CLI commands:

**Option A: Azure Cloud Shell (Recommended for beginners)**
- Open the **Azure Portal** → [https://portal.azure.com](https://portal.azure.com)
- Click the **Cloud Shell** icon (>_) in the top toolbar
- Choose **Bash** when prompted
- ✅ **Advantage**: Pre-authenticated, no setup needed

**Option B: Local Terminal (Mac)**
- Install Azure CLI: `brew install azure-cli`
- Run `az login` first to authenticate
- ✅ **Advantage**: Work from your familiar environment

### Step 1: Set Up Variables

```bash
# Set your variables (customize these values)
resourceGroup=cattoResourceGroup
location=eastus
accountName=storageacct$RANDOM

# Display the generated account name (storage accounts need globally unique names)
echo "Your storage account name will be: $accountName"
```

**💡 Why `$RANDOM`?** Storage account names must be globally unique across all of Azure. The `$RANDOM` adds random numbers to ensure uniqueness.

### Step 2: Create the Storage Account

```bash
# Create the storage account
az storage account create \
    --name $accountName \
    --resource-group $resourceGroup \
    --location $location \
    --sku Standard_LRS \
    --allow-blob-public-access false

# Verify it was created
echo "✅ Storage account created: $accountName"
```

**Flag Explanations:**
- `--name`: Your unique storage account name
- `--resource-group`: Uses your existing `cattoResourceGroup`
- `--location`: Geographic region (`eastus` is common and cost-effective)
- `--sku`: Storage type (`Standard_LRS` = Standard Locally Redundant Storage, cheapest option)
- `--allow-blob-public-access`: Set to `false` for security

### Step 3: Save Your Account Name

**Important:** You'll need the account name later in your .NET code!

```bash
# Display your account name again - SAVE THIS!
echo "🔑 Your storage account name: $accountName"

# Optional: Save to a file for reference
echo $accountName > storage-account-name.txt
```

### Troubleshooting

**If you get "storage account name not available":**
```bash
# Generate a new random name
accountName=storageacct$RANDOM
echo "Trying new name: $accountName"
```

**To check if your resource group exists:**
```bash
az group show --name cattoResourceGroup
```

**Next:** After creating the storage account, you'll assign permissions and then move to creating your .NET console app.

Here are your next steps:
Step 1: Create the Storage Account (Retry)
Since the first attempt failed due to not being logged in, run it again:
bash# Create the storage account (now that you're logged in)
```bash
az storage account create \
    --name $accountName \
    --resource-group $resourceGroup \
    --location $location \
    --sku Standard_LRS \
    --allow-blob-public-access false
```
Note: Your account name is still saved as storageacct17453, so this should work.
Step 2: Assign Role Permissions
Once the storage account is created successfully, you need to give yourself permissions to access it:
bash# Get your user principal
```bash
userPrincipal=$(az rest --method GET --url https://graph.microsoft.com/v1.0/me --headers 'Content-Type=application/json' --query userPrincipalName --output tsv)
```
# Get the storage account resource ID
```bash
resourceID=$(az storage account show --name $accountName --resource-group $resourceGroup --query id --output tsv)
```
# Assign the Storage Blob Data Owner role to yourself
```bash
az role assignment create \
    --assignee $userPrincipal \
    --role "Storage Blob Data Owner" \
    --scope $resourceID

echo "✅ Role assignment completed"
```
Step 3: Create Your .NET Console App
bash# Create project folder and navigate to it
mkdir azstor && cd azstor

# Create .NET console app
dotnet new console

# Add required packages
dotnet add package Azure.Storage.Blobs
dotnet add package Azure.Identity

# Create data folder for files
mkdir data

echo "✅ .NET project setup complete"
Try running the storage account creation command first, and let me know if you get any errors. The role assignment step is crucial for your .NET app to authenticate properly with Azure.

---

Here are some more notes 
Perfect! Your storage account was created successfully. Let me show you how to verify everything in the Azure Portal:
🌐 Verifying in Azure Portal
Step 1: Navigate to Your Storage Account

Go to Azure Portal
In the search bar at the top, type: storageacct17453
Click on your storage account when it appears

OR

Go to Resource groups (left sidebar)
Click on cattoResourceGroup
You should see your storage account storageacct17453 listed

Step 2: Check Blob Storage
Once you're in your storage account:

In the left sidebar, under Data storage, click Containers
Right now it should be empty (that's normal - you haven't created any containers yet)
This is where your blob containers will appear after you run the .NET application

Step 3: Verify Role Assignments
To confirm your permissions are set correctly:

While in your storage account, click Access Control (IAM) in the left sidebar
Click the Role assignments tab
You should see yourself listed with the Storage Blob Data Owner role

Step 4: Note Important Information
While you're there, notice:

Storage account name: storageacct17453
Blob service endpoint: https://storageacct17453.blob.core.windows.net/

📋 What You Should See
In the Overview page:

Status: Available ✅
Location: East US ✅
Performance: Standard ✅

In Containers:

Currently empty (this is expected)
After running your .NET app, you'll see containers appear here

🎯 Next Steps
Now that everything is verified in the portal, you can proceed with creating your .NET console application:
bash# Create project folder and navigate to it
mkdir azstor && cd azstor

# Create .NET console app
dotnet new console

# Add required packages
dotnet add package Azure.Storage.Blobs
dotnet add package Azure.Identity

# Create data folder for files
mkdir data
The containers and blobs will only appear in the Azure Portal after you run your .NET application - right now having an empty "Containers" section is exactly what we expect!

---


🎯 What You've Learned
You now know how to:

Create Azure Storage accounts via CLI
Authenticate .NET apps with Azure using DefaultAzureCredential
Work with blob containers programmatically
Upload, list, and download files from Azure Blob Storage
Verify resources in the Azure Portal

🚀 Next Steps (Optional)
If you want to explore further:

Try different blob types (Block, Page, Append)
Implement blob metadata and properties
Set up blob access policies
Work with blob storage events
Explore Azure Storage security features

But yes, you've completed the core tutorial successfully! Make sure to clean up those resources to avoid unexpected charges. 💰

