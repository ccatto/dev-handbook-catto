# 🌌 Exercise: Create Azure Cosmos DB Resources by Using the Azure Portal

**⏱ Duration:** ~10 minutes  
**🏆 XP:** 100  

---

## 📑 Table of Contents
1. 🚀 Prerequisites  
2. 🌍 Create an Azure Cosmos DB Account  
3. 🗂️ Add a Database and a Container  
4. ✍️ Add Data to Your Database  
5. 🧹 Clean Up Resources  

---

## 🚀 Prerequisites
- An **Azure account** with an active subscription.  
👉 If you don't have one, sign up for a free trial: [azure.com/free](https://azure.com/free).

---

## 🌍 Create an Azure Cosmos DB Account

1. Sign in to the [Azure portal](https://portal.azure.com).  
2. From the navigation pane, select **➕ Create a resource**.  
3. Search for **Azure Cosmos DB**, then select **Create / Azure Cosmos DB**.  
4. On the *Which API best suits your workload?* page, select **Create** under **Azure Cosmos DB for NoSQL**.  
5. Fill in the required fields:  
   - **Subscription:** Select your subscription.  
   - **Resource Group:** Create new → `az204-cosmos-rg`.  
   - **Account Name:** Enter a unique name (lowercase, numbers, `-`, 3–31 chars).  
   - **Availability Zones:** Disable.  
   - **Location:** Choose the nearest region to your users.  
   - **Capacity Mode:** **Serverless**.  
6. Select **Review + create**, then **Create**.  
7. Wait until the portal displays ✅ *Your deployment is complete*.  
8. Click **Go to resource** to open the Cosmos DB account page.  

---

## 🗂️ Add a Database and a Container

1. In your Cosmos DB account, go to **Data Explorer**.  
2. Select **New Container**.  
3. Enter settings:  
   - **Database ID:** Create new → `ToDoList`.  
   - **Container ID:** `Items`  
   - **Partition Key:** `/category`  
4. Select **OK**.  
5. Confirm that the new database and container appear in **Data Explorer**.  

---

## ✍️ Add Data to Your Database

1. In **Data Explorer**, expand the `ToDoList` database → `Items` container.  
2. Select **Items** → **New Item**.  
3. Paste the following JSON:  

```json
{
    "id": "1",
    "category": "personal",
    "name": "groceries",
    "description": "Pick up apples and strawberries.",
    "isComplete": false
}
```

4. Select **Save**.  
5. Add another item with a unique `id` and any structure you want (Cosmos DB is schema-free 🎉).  

---

## 🧹 Clean Up Resources

1. In your Cosmos DB account, select **Overview**.  
2. Click the **az204-cosmos-rg** resource group link.  
3. Select **Delete resource group**.  
4. Confirm the name to delete all resources. ⚠️ Be careful — this removes *everything* in the group.  

---

✅ You’ve successfully created and managed Azure Cosmos DB resources using the Azure portal! 🚀
