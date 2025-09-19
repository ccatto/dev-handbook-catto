# 🔄 Swap Deployment Slots in Azure App Service

In this exercise, you deploy a **static HTML website** to Azure App Service, create a **staging slot**, update code, deploy it to staging, and then **swap staging with production**.  
This demonstrates safe app updates using **blue-green deployments**.  

⏱️ **Time required:** ~30 minutes  

---

## 📑 Table of Contents
1. [⬇️ Download & Deploy Sample App](#️-download--deploy-sample-app)
2. [🪄 Create a Staging Deployment Slot](#-create-a-staging-deployment-slot)
3. [📝 Update Code & Deploy to Staging](#-update-code--deploy-to-staging)
4. [🔄 Swap Staging & Production](#-swap-staging--production)
5. [🧹 Clean Up Resources](#-clean-up-resources)

---

## ⬇️ Download & Deploy Sample App

1. Open [Azure Portal](https://portal.azure.com) → Sign in.  
2. Click **[>_]** (Cloud Shell) → Select **Bash** environment.  
   - If asked, choose *No storage account required*.  
   - If using PowerShell, switch to Bash.  
   - In toolbar → Settings → **Go to Classic version**.  

3. Clone sample app repo:  

```bash
git clone https://github.com/Azure-Samples/html-docs-hello-world.git
```

4. Set variables:  

```bash
resourceGroup=rg-mywebapp
appName=mywebapp$RANDOM
echo $appName
```

5. Deploy static HTML app:  

```bash
cd html-docs-hello-world
az webapp up -g $resourceGroup -n $appName --sku P0V3 --html
```

6. In portal, search for your **web app name** → Open it → Click **Default domain** link to test site 🌐.

---

## 🪄 Create a Staging Deployment Slot

1. In **Cloud Shell**, create slot:  

```bash
az webapp deployment slot create -n $appName -g $resourceGroup --slot staging
```

2. In portal → Navigate to **Deployment > Deployment slots** → Confirm new slot (ends with `-staging`).

---

## 📝 Update Code & Deploy to Staging

1. Open HTML file in editor:  

```bash
code index.html
```

2. Change `<h1>` text to something like:  

```
Azure App Service Staging Slot 🚀
```

3. Save (`Ctrl+S`) and exit (`Ctrl+Q`).  

4. Zip the updated code:  

```bash
zip -r stagingcode.zip .
```

5. Deploy to **staging slot**:  

```bash
az webapp deploy -g $resourceGroup -n $appName --src-path ./stagingcode.zip --slot staging
```

6. In portal → Open **staging slot** → Click **Default domain** link → View updated site 🧪.

---

## 🔄 Swap Staging & Production

1. In portal → Go to your web app.  
2. Select **Overview** or **Deployment > Deployment slots**.  
3. Click **Swap** in toolbar.  
4. In Swap panel → Ensure:  
   - **Source:** `-staging`  
   - **Target:** Production  
5. Click **Start Swap**.  
6. Monitor progress in Notifications (bell icon 🔔).  

👉 Verify: Open **production slot** site → Refresh → Updated changes now live 🎉.

---

## 🧹 Clean Up Resources

1. Go to [Azure Portal](https://portal.azure.com).  
2. Navigate to your **resource group**.  
3. Select **Delete resource group** → Enter name → Confirm.  

⚠️ **Caution:** This deletes all resources inside the group. Be careful if you reused an existing resource group!  

---

✅ Tutorial complete! You successfully used **Azure App Service deployment slots** for a safe blue-green deployment 🔄🌐
