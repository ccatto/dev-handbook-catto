# 🐳 Deploy a Containerized App to Azure App Service

In this exercise, you create an **Azure App Service web app** configured to run a containerized application by specifying a container image from **Microsoft Container Registry**.  
You’ll configure container settings, deploy the app, and verify it runs successfully in Azure.  

⏱️ **Time required:** ~15 minutes  

---

## 📑 Table of Contents
1. [🌐 Create a Web App Resource](#-create-a-web-app-resource)
2. [👀 View the Results](#-view-the-results)
3. [🧹 Clean Up Resources](#-clean-up-resources)

---

## 🌐 Create a Web App Resource

1. Go to the [Azure Portal](https://portal.azure.com) → Sign in with your Azure credentials.  
2. Select **+ Create a resource** from the *Azure Services* heading.  
3. In the search bar, type **web app** → Press Enter.  
4. In the **Web App** tile, select **Create → Web App**.  

📷 *Screenshot: Web App tile*  

Fill in the **Basics tab**:

| Setting        | Action |
|----------------|--------|
| Subscription   | Retain default |
| Resource group | Create new → `rg-WebApp` (or reuse existing) |
| Name           | Unique name, e.g., `xx-containerwebapp` (replace `xx` with initials) |
| Name slider    | Turn **off** (if shown) |
| Publish        | **Container** |
| OS             | Linux |
| Region         | Default or nearest |
| Linux Plan     | Default |
| Pricing Plan   | Free F1 |

➡️ Next, open the **Container tab**:

| Setting              | Action |
|-----------------------|--------|
| Sidecar support       | Off |
| Image Source          | Other container registries |
| Access Type           | Public |
| Registry server URL   | `mcr.microsoft.com/k8se` |
| Image and Tag         | `quickstart:latest` |
| Startup Command       | Leave blank |

5. Go to **Review + Create** → Verify → Select **Create**.  
6. Wait for deployment (~2-3 mins).  
7. Select **Go to resource** after deployment completes.  

---

## 👀 View the Results

1. In the resource overview, find **Default domain**.  
2. Click the link → Opens your web app in a new tab.  
3. ⏳ Note: It may take a few minutes for the container app to start and display.  

🎉 Congratulations, your containerized app is running in Azure!  

---

## 🧹 Clean Up Resources

To avoid extra costs, delete the resources:  

1. In [Azure Portal](https://portal.azure.com), go to the resource group you created.  
2. Select **Delete resource group**.  
3. Enter resource group name → Confirm deletion.  

⚠️ **Caution:** Deleting a resource group removes **all resources inside it**. If you reused an existing resource group, be careful!  

---

✅ Tutorial complete! You’ve deployed a containerized app to Azure App Service 🐳☁️  
