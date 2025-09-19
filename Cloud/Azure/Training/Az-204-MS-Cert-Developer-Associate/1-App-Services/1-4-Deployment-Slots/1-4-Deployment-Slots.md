# 🚀 Explore Azure App Service Deployment Slots

**Module Duration:** 57 minutes  
**Level:** Intermediate  
**Role:** Developer  
**Product:** Azure App Service  
**Units:** 8

---

## 🧠 Module Overview

In this module, you'll learn how **slot swapping** works in Azure App Service and how to:

- Perform manual and automatic swaps.
- Route traffic between different deployment slots manually and automatically.

---

## 🎯 Learning Objectives

After completing this module, you will be able to:

- ✅ Describe the **benefits** of using deployment slots.
- ✅ Understand how **slot swapping** operates in App Service.
- ✅ Perform **manual swaps** and enable **auto swap**.
- ✅ **Route traffic** between slots manually and automatically.

---

## 🔧 Prerequisites

- Experience using the Azure portal to create and manage **App Service web apps**.

> 💡 New to Azure? [Get started with Azure for free](https://azure.microsoft.com/free).

---

## 📚 Module Outline

This module is part of the **Implement Azure App Service web apps** learning path.

| Unit | Title                                                   | Duration |
|------|---------------------------------------------------------|----------|
| 1    | Introduction                                            | 3 min    |
| 2    | Explore staging environments                            | 3 min    |
| 3    | Examine slot swapping                                   | 5 min    |
| 4    | Swap deployment slots                                   | 6 min    |
| 5    | **Exercise** - Swap deployment slots in Azure App Service | 30 min   |
| 6    | Route traffic in App Service                            | 4 min    |
| 7    | Module assessment                                       | 3 min    |
| 8    | Summary                                                 | 3 min    |

---

Ready to start? Let's dive into deployment slot magic with Azure App Service! ✨


> Staging environments in Azure App Service let you deploy apps to separate slots for testing before moving them to production, ensuring seamless, zero-downtime swaps. They also provide rollback capabilities, support multiple slots per tier, and come at no extra cost within your App Service plan.

The slot's URL has the format `http://sitename-slotname.azurewebsites.net`

> Slot swapping in Azure App Service lets you move apps between deployment slots without downtime by warming up the source slot before routing traffic to it. During the process, slot-specific settings (like app settings or connection strings) can either swap or remain tied to their slot, while the production slot stays online throughout. This ensures seamless transitions, safe rollbacks, and full control over which configurations move with the app.

> Swapping deployment slots in Azure App Service lets you move changes from a staging slot into production with zero downtime, either manually, with preview, or through auto swap. You can warm up apps, customize initialization, and roll back quickly if issues occur, ensuring safe and seamless deployments.

> In this exercise, you deploy a static HTML site to Azure App Service, create a staging slot, update the app, and deploy the changes to the staging environment. You then swap the staging and production slots to promote the updates with zero downtime, demonstrating how deployment slots support safe updates and blue-green deployments.

```bash
git clone https://github.com/Azure-Samples/html-docs-hello-world.git
az webapp up -g $resourceGroup -n $appName --sku P0V3 --html
az webapp deployment slot create -n $appName -g $resourceGroup --slot staging
az webapp deploy -g $resourceGroup -n $appName --src-path ./stagingcode.zip --slot staging
```
> In Azure App Service, you can route a percentage of production traffic to a staging slot for testing or feedback before full release. Traffic can be routed automatically by setting percentages in the portal, or manually with the `x-ms-routing-name` query parameter, which lets users opt in or out of previewing the beta version.

---
1. By default, all client requests to the app's production URL (`http://<app_name>.azurewebsites.net`) are routed to the production slot. One can automatically route a portion of the traffic to another slot.  
**What is the default routing rule applied to new deployment slots?**

- 0% ✅ Correct  
- 10%  
- 20%  

---

2. Some configuration elements follow the content across a swap (not slot specific), whereas other configuration elements stay in the same slot after a swap (slot specific).  
**Which of the following settings are swapped?**

- Publishing endpoints  
- WebJobs content ✅ Correct  
- WebJobs schedulers  
