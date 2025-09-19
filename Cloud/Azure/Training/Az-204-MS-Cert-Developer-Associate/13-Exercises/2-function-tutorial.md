# 🚀 Create an Azure Function with Visual Studio Code

In this exercise, you learn how to create a C# function that responds to HTTP requests. After creating and testing the code locally in Visual Studio Code, you deploy and test the function in Azure.

⏱️ **Time required:** ~15 minutes  

---

## 📑 Table of Contents
1. [✨ Before You Start](#-before-you-start)
2. [🛠️ Create Your Local Project](#️-create-your-local-project)
3. [💻 Run the Function Locally](#-run-the-function-locally)
4. [☁️ Deploy and Execute in Azure](#️-deploy-and-execute-in-azure)
5. [🧹 Clean Up Resources](#-clean-up-resources)

---

## ✨ Before You Start

To complete the exercise, you need:

- 🔑 An **Azure subscription** ([Sign up](https://azure.microsoft.com/free) if you don’t have one)
- 🖥️ **Visual Studio Code**
- ⚙️ **.NET 8** (target framework)
- 📦 **C# Dev Kit** for VS Code
- 🔌 **Azure Functions extension** for VS Code
- 🛠️ **Azure Functions Core Tools v4.x**  

Install Azure Functions Core Tools with:

```bash
winget uninstall Microsoft.Azure.FunctionsCoreTools
winget install Microsoft.Azure.FunctionsCoreTools
```

---

## 🛠️ Create Your Local Project

1. Open VS Code → Press **F1** → Select **Azure Functions: Create New Project...**  
2. Choose a folder for your project workspace (empty folder recommended).  
3. Provide the following at prompts:

| Prompt | Action |
|--------|---------|
| Select folder | Choose or create folder |
| Language | C# |
| Runtime | .NET 8.0 Isolated |
| Template | HTTP trigger |
| Function name | `HttpExample` |
| Namespace | `My.Function` |
| Authorization | Anonymous |

👉 VS Code generates the Azure Functions project with an HTTP trigger.

---

## 💻 Run the Function Locally

1. Open terminal in VS Code → Press **F5** to start.  
2. Copy the **endpoint URL** displayed in the terminal.  
3. In the Azure extension (Workspace → Local Project → Functions), right-click `HttpExample` → **Execute Function Now...**  
4. Enter body:

```json
{ "name": "Azure" }
```

5. Function executes locally and returns a response 🎉  
6. Press **Shift + F5** to stop.

---

## ☁️ Deploy and Execute in Azure

### 🔑 Sign in to Azure
- Open Azure icon → Select **Sign in to Azure...**  
- Authenticate in browser → Return to VS Code.  

### 📦 Create Azure Resources
Provide following at prompts:

| Prompt | Action |
|--------|---------|
| Resource | Create Function App in Azure |
| Subscription | Choose your subscription |
| App name | Unique (e.g., `myfunctionapp`) |
| Location | Region near you |
| Runtime | .NET 8.0 Isolated |
| Auth type | Secrets |

Azure creates:
- 📂 Resource group  
- 💾 Storage account  
- ⚡ Function app  
- 📊 Application Insights  

### 🚀 Deploy the Project
1. Press **F1** → Run **Azure Functions: Deploy to Function App...**  
2. Select subscription and app.  
3. Confirm overwrite → **Deploy**.  
4. View output results.  

### ▶️ Run in Azure
1. In Azure sidebar → Expand Function App → Functions.  
2. Right-click `HttpExample` → **Execute Function Now...**  
  * I think this step is not correct what I did was test in postman since if we rightclick the function it will run locally in VS code; so the URL will be something like https://myfunctionapptomato.azurewebsites.net/api/httptrigger1 then in body pass `{"name": "Azure"}` & headers content-type: app/json; 
3. Send body:

```json
{ "name": "Azure" }
```

4. 🎉 Function executes in Azure!

---

## 🧹 Clean Up Resources

1. Go to [Azure Portal](https://portal.azure.com).  
2. Navigate to your resource group.  
3. Click **Delete resource group** → Confirm deletion.  

⚠️ **Caution:** This deletes all resources in the group!

---

✅ Tutorial complete! You’ve created, tested, and deployed an Azure Function using Visual Studio Code 🚀
