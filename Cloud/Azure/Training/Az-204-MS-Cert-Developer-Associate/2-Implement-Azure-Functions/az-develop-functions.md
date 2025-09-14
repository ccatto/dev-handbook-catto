# Develop Azure Functions

**800 XP**  
**Module**  
**7 Units**  
**Intermediate – Developer – Azure – Azure Functions**

Learn how to create and deploy Azure Functions.

---

## Learning objectives
After completing this module, you will be able to:

- Explain the key components of a function and how they are structured  
- Create triggers and bindings to control when a function runs and where the output is directed  
- Connect a function to services in Azure  
- Create a function by using Visual Studio Code and the Azure Functions Core Tools  

---

## Prerequisites
- Familiarity with developer concepts and terminology  
- Understanding of cloud computing  
- Some experience with the Azure portal  

---

## Get started with Azure
Choose the Azure account that's right for you. Pay as you go or try Azure free for up to 30 days. [Sign up](https://azure.microsoft.com).  

---

## This module is part of these learning paths
- Implement Azure Functions  
- Integrate with Dataverse and Azure  

---

## Units
- Introduction  
- Explore Azure Functions development  
- Create triggers and bindings  
- Connect functions to Azure services  
- Exercise – Create an Azure Function by using Visual Studio Code  
- Module assessment  
- Summary  

> A function app in Azure provides the execution context for functions and acts as the unit of deployment, management, and scaling. All functions within a function app share the same pricing plan, deployment method, and runtime version. Developers typically create and test Azure Functions locally using their preferred tools, then publish them to Azure, since portal-based editing is limited. Local development relies on project files like `host.json` for configuration and `local.settings.json` for environment-specific settings, which must be synchronized with Azure app settings when deployed.

> # Create Triggers and Bindings in Azure Functions

Triggers define how a function is invoked, and every function must have exactly **one trigger**.  
Bindings connect external resources (such as storage or databases) to a function as **input**, **output**, or both.  
They help you avoid hardcoding access to services by letting Azure provide the data as parameters.  
Definitions vary by language: `.json` configuration for JavaScript/Python/TypeScript, or attributes/annotations in C# and Java.

---

## Example: Queue Trigger with Table Output Binding

This function writes a row to **Azure Table Storage** whenever a new message arrives in an **Azure Queue**.

### function.json
```json
{
  "bindings": [
    {
      "type": "queueTrigger",
      "direction": "in",
      "name": "myQueueItem",
      "queueName": "myqueue-items",
      "connection": "MyStorageConnectionAppSetting"
    },
    {
      "type": "table",
      "direction": "out",
      "name": "tableBinding",
      "tableName": "Person",
      "connection": "MyStorageConnectionAppSetting"
    }
  ]
}

``` csharp
public static class QueueTriggerTableOutput
{
    [FunctionName("QueueTriggerTableOutput")]
    [return: Table("Person", Connection = "MyStorageConnectionAppSetting")]
    public static Person Run(
        [QueueTrigger("myqueue-items", Connection = "MyStorageConnectionAppSetting")] JObject order,
        ILogger log)
    {
        return new Person()
        {
            PartitionKey = "Orders",
            RowKey = Guid.NewGuid().ToString(),
            Name = order["Name"].ToString(),
            MobileNumber = order["MobileNumber"].ToString()
        };
    }
}

public class Person
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public string MobileNumber { get; set; }
}
```

✅ Key takeaway: Triggers start function execution, while bindings handle input/output to external services without boilerplate code.

> Azure Functions connects securely to Azure services by using application settings to store connection strings, keys, or tokens as encrypted environment variables. Instead of secrets, you can configure identity-based connections with managed identities, but the identity must be granted proper permissions using role-based access control (RBAC) or access policies.

# Exercise - Create an Azure Function by using Visual Studio Code  
**Completed**  
https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-functions/01-functions-create-vscode-http.html

In this exercise, you'll create a C# function that responds to HTTP requests. After building and testing the code locally in Visual Studio Code, you'll deploy and test the function in Azure.  

---

## Tasks
- Create your local project  
- Run the function locally  
- Deploy and execute the function in Azure  
- Clean up resources  

---

## Prerequisites
To complete this exercise, you need:  
- An **Azure subscription** (sign up if you don’t have one)  
- **Visual Studio Code** (supported platform)  
- **.NET 8** as the target framework  
- **C# Dev Kit** for Visual Studio Code  
- **Azure Functions extension** for Visual Studio Code  
- **Azure Functions Core Tools v4.x**  

Install Azure Functions Core Tools with the following commands:  


Ok so on a mac: 
```bash
brew tap azure/functions
brew install azure-functions-core-tools@4
func --version
```
then in our terminal we can use `func command`

> in order to install azure-functions command line tool the xcode version matters;

to create a new one on a mac we need to install the `Azure Functions` extension then we can open our command pallette and then create new project: 
```bash
⇧⌘P   (Shift + Command + P) #opens command pallette
Azure Functions: Create New Project...
```


Then we can basically run 
```bash
func start
```

Then we can view our localhost url; 

* Deploying 
we had to sign in to Azure

Then we have in command prompt `Create Function App in Azure...`
then in command prompt `Azure Functions: Deploy to Function App....` 

---

> Knowledge Check 

1. Which of the following choices is required for a function to run?

- Binding  
- Trigger ✅  
- Both triggers and bindings  

2. Which of the following choices supports both the in and out direction settings?

- Bindings ✅  
- Trigger  
- Connection value  
