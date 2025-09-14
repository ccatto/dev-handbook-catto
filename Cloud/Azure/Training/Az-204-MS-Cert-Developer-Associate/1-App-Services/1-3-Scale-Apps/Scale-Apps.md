# Scale Apps in Azure App Service

**Level**: Intermediate  
**Role**: Developer  
**Product**: Azure, Azure App Service  
**XP**: 800 XP  
**Units**: 7  
**Module Type**: Learning Module  

---

## 🧠 Module Overview

Learn how autoscale operates in Azure App Service, how to identify autoscale factors, enable autoscale, and create effective autoscale conditions.

---

## 🎯 Learning Objectives

After completing this module, you'll be able to:

- Identify scenarios for which autoscaling is an appropriate solution.
- Create autoscaling rules for a web app.
- Monitor the effects of autoscaling.

---

## 📋 Prerequisites

- Experience using the Azure portal to create and manage App Service web apps

---

## 🚀 Get Started with Azure

Choose the Azure account that’s right for you. Pay as you go or try Azure free for up to 30 days. [Sign up](https://azure.microsoft.com/en-us/free/).

---

## 📚 Module Units

1. **Introduction**
2. **Examine scale out options**
3. **Identify autoscale factors**
4. **Enable autoscale in App Service**
5. **Explore autoscale best practices**
6. **Module assessment**
7. **Summary**

---

## 🔗 Related Learning Path

- [Implement Azure App Service web apps](#)

* Learning objectives
Identify scenarios for which autoscaling is an appropriate solution
Create autoscaling rules for a web app
Monitor the effects of autoscaling

> Azure App Service supports both manual scaling and automatic scaling, with two main automatic options: rule-based autoscaling and fully managed automatic scaling. Autoscaling lets you define custom rules and schedules to scale based on resource metrics like CPU or incoming requests, while automatic scaling relies on platform-managed logic based on HTTP traffic, available in Premium pricing tiers. Autoscaling offers flexibility and control but may not be ideal for long-term growth or resource-heavy workloads, where scaling up might be more effective. Automatic scaling is better suited for simplified scenarios where the platform handles scaling decisions, helping prevent backend overload and manage instance limits.

> Autoscaling in Azure App Service allows you to automatically adjust the number of instances for a web app based on defined conditions, such as resource usage metrics (CPU, memory, HTTP queue length) or scheduled times. Autoscale rules evaluate these metrics over time using aggregation and duration settings to determine when to scale in or out, with cool down periods to prevent excessive triggering. You can define multiple autoscale conditions and pair scale-out and scale-in rules to handle fluctuating workloads efficiently. Combining rules allows for flexible scaling behavior, but careful planning is needed to avoid unnecessary costs or poor performance during traffic spikes.

> To enable autoscaling in Azure App Service, navigate to your App Service Plan in the Azure portal, choose the Scale out option, and configure it using the Custom autoscale settings. You can define default and custom scale conditions based on metrics or schedules, and each condition may include rules specifying when and how to scale the instance count. Not all pricing tiers support autoscaling, so scaling up to at least the S1 tier may be necessary. Once enabled, you can monitor autoscaling activity through the Run history chart, which shows when autoscale events occurred and what conditions triggered them.

> Effective autoscaling requires thoughtful configuration to avoid conflicting rules or unnecessary scaling behavior. It's important to set different thresholds for scaling out and scaling in, maintain a margin between minimum and maximum instance counts, and select appropriate metrics and aggregation types. Avoid setting identical thresholds for scale-out and scale-in, as this can lead to "flapping" — constant scaling actions that cancel each other out. Additionally, autoscale only scales in when all scale-in rules are met, while it scales out when any scale-out rule is triggered, so planning and testing your rules carefully is key to maintaining stability and performance.

1. **Which of these statements best describes autoscaling?**

- Autoscaling requires an administrator to actively monitor the workload on a system.
- **Autoscaling is a scale out/scale in solution.** ✅
- Scaling up/scale down provides better availability than autoscaling.

---

2. **Which of these scenarios is a suitable candidate for autoscaling?**

- **The number of users requiring access to an application varies according to a regular schedule.** ✅
- The system is subject to a sudden influx of requests that grinds your system to a halt.
- Your organization is running a promotion and expects to see increased traffic to their web site for the next couple of weeks.
