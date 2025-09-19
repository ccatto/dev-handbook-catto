# 🌌 Create resources in Azure Cosmos DB for NoSQL using .NET

## 📖 Table of Contents
1. 🚀 Introduction  
2. 🏗️ Create an Azure Cosmos DB account  
3. 💻 Create a .NET console app  
4. ⚙️ Configure authentication and environment variables  
5. 📝 Add code for client, database, container, and items  
6. ▶️ Run the console app and verify results  
7. 🧹 Clean up resources  

---

## 🚀 Introduction
In this exercise, you create an **Azure Cosmos DB account** and build a **.NET console application** that uses the Microsoft Azure Cosmos DB SDK to:
- Create a database  
- Create a container  
- Add a sample item  

You will also configure authentication, perform operations programmatically, and verify results in the **Azure portal**.  
⏱️ Duration: ~30 minutes  

---

## 🏗️ Create an Azure Cosmos DB account

1. Open the [Azure Portal](https://portal.azure.com).  
2. Launch a **Cloud Shell** (Bash).  
3. Create a resource group:  

```bash
az group create --location eastus --name myResourceGroup
```

4. Create variables:  

```bash
resourceGroup=myResourceGroup
accountName=cosmosexercise$RANDOM
```

5. Create the Cosmos DB account:  

```bash
az cosmosdb create --name $accountName     --resource-group $resourceGroup
```

6. Retrieve endpoint & key:  

```bash
az cosmosdb show --name $accountName     --resource-group $resourceGroup     --query "documentEndpoint" --output tsv

az cosmosdb keys list --name $accountName     --resource-group $resourceGroup     --query "primaryMasterKey" --output tsv
```

---

## 💻 Create a .NET console app

```bash
mkdir cosmosdb
cd cosmosdb
dotnet new console
```

Add dependencies:

```bash
dotnet add package Microsoft.Azure.Cosmos --version 3.*
dotnet add package Newtonsoft.Json --version 13.*
dotnet add package dotenv.net
```

---

## ⚙️ Configure authentication

Create `.env` file:

```bash
touch .env
code .env
```

Add:

```env
DOCUMENT_ENDPOINT="YOUR_DOCUMENT_ENDPOINT"
ACCOUNT_KEY="YOUR_ACCOUNT_KEY"
```

---

## 📝 Add code for client, database, container, and items

Replace `Program.cs` with:  

```csharp
using Microsoft.Azure.Cosmos;
using dotenv.net;

string databaseName = "myDatabase";
string containerName = "myContainer";

DotEnv.Load();
var envVars = DotEnv.Read();
string cosmosDbAccountUrl = envVars["DOCUMENT_ENDPOINT"];
string accountKey = envVars["ACCOUNT_KEY"];

if (string.IsNullOrEmpty(cosmosDbAccountUrl) || string.IsNullOrEmpty(accountKey))
{
    Console.WriteLine("Please set the DOCUMENT_ENDPOINT and ACCOUNT_KEY environment variables.");
    return;
}

try
{
    // CREATE THE COSMOS DB CLIENT
    CosmosClient client = new(accountEndpoint: cosmosDbAccountUrl, authKeyOrResourceToken: accountKey);

    // CREATE A DATABASE
    Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    Console.WriteLine($"Created or retrieved database: {database.Id}");

    // CREATE A CONTAINER
    Container container = await database.CreateContainerIfNotExistsAsync(id: containerName, partitionKeyPath: "/id");
    Console.WriteLine($"Created or retrieved container: {container.Id}");

    // DEFINE A TYPED ITEM
    Product newItem = new Product
    {
        id = Guid.NewGuid().ToString(),
        name = "Sample Item",
        description = "This is a sample item in my Azure Cosmos DB exercise."
    };

    // ADD THE ITEM
    ItemResponse<Product> createResponse = await container.CreateItemAsync(item: newItem, partitionKey: new PartitionKey(newItem.id));
    Console.WriteLine($"Created item with ID: {createResponse.Resource.id}");
    Console.WriteLine($"Request charge: {createResponse.RequestCharge} RUs");
}
catch (CosmosException ex)
{
    Console.WriteLine($"Cosmos DB Error: {ex.StatusCode} - {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

public class Product
{
    public string? id { get; set; }
    public string? name { get; set; }
    public string? description { get; set; }
}
```

---

## ▶️ Run the console app and verify results

Build:

```bash
dotnet build
```

Run:

```bash
dotnet run
```

✅ Expected output:  

```
Created or retrieved database: myDatabase
Created or retrieved container: myContainer
Created item with ID: <guid>
Request charge: ~6 RUs
```

Check the **Azure Portal → Data Explorer** to verify the item.  

---

## 🧹 Clean up resources

```bash
az group delete --name myResourceGroup --yes --no-wait
```

