# Run container images in Azure Container Instances  

Learn how Azure Container Instances can help you quickly deploy containers, how to set environment variables, and specify container restart policies.  

## Learning objectives  
After completing this module, you'll be able to:  
- Describe the benefits of Azure Container Instances and how resources are grouped.  
- Deploy a container instance in Azure by using the Azure CLI.  
- Start and stop containers using policies.  
- Set environment variables in your container instances.  
- Mount file shares in your container instances.  

## Prerequisites  
- An understanding of container concepts and terminology.  
- An understanding of cloud computing and some experience with the Azure portal.  

## Get started with Azure  
Choose the Azure account that's right for you. Pay as you go or try Azure free for up to 30 days. Sign up.  

---

### This module is part of these learning paths  
**Implement containerized solutions**  

- Introduction  
- Explore Azure Container Instances  
- Exercise - Deploy a container to Azure Container Instances using Azure CLI commands  
- Run containerized tasks with restart policies  
- Set environment variables in container instances  
- Mount an Azure file share in Azure Container Instances  
- Module assessment  
- Summary  

---

# Introduction  

Azure Container Instances (ACI) offers the fastest and simplest way to run a container in Azure, without having to manage any virtual machines and without having to adopt a higher-level service.  

## Learning outcomes  
After completing this module, you'll be able to:  
- Describe the benefits of Azure Container Instances and how resources are grouped  
- Deploy a container instance in Azure by using the Azure CLI  
- Start and stop containers using policies  
- Set environment variables in your container instances  
- Mount file shares in your container instances  

---

> Explore Azure Container Instances  
**Completed – 100 XP**

Azure Container Instances (ACI) is a lightweight service for running isolated containers without managing VMs or orchestration systems. It provides fast startup, hypervisor-level security, flexible sizing, persistent storage, and support for both Linux and Windows containers.  

Key concepts include:  
- **Container groups**: Collections of containers sharing lifecycle, resources, and networking (similar to Kubernetes pods).  
- **Deployment options**: Use ARM templates for complex scenarios or YAML for simpler deployments.  
- **Resource allocation**: CPU, memory, and optional GPU resources are summed across containers in a group.  
- **Networking**: Groups share one IP address and port namespace. Internal communication uses `localhost`.  
- **Storage**: Supports Azure Files, secrets, empty directories, and cloned Git repos.  

**Common scenarios**: web apps with content sync, application + logging, monitoring sidecars, and front-end/back-end workloads.  

---

> Exercise - Deploy a container to Azure Container Instances using Azure CLI 

In this exercise, you deploy and run a container in Azure Container Instances (ACI) using the Azure CLI. You learn how to create a container group, specify container settings, and verify that your containerized application is running in the cloud.

Tasks performed in this exercise:

Create Azure Container Instance resources in Azure
Create and deploy a container
Verify the container is running

[Deploy a container to Azure Container Instances using Azure CLI commands](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-container-services/02-run-container-aci.html)

--- 

> Run containerized tasks with restart policies  
**Completed – 100 XP**

Azure Container Instances (ACI) is well-suited for short-lived, run-once tasks like builds, tests, and rendering jobs. You’re billed only for the compute resources consumed while the container is running.  

### Restart policies  
When creating a container group, you can specify how containers restart:  
- **Always** – Containers are always restarted (default).  
- **Never** – Containers run once and are not restarted.  
- **OnFailure** – Containers restart only if the process fails (nonzero exit code).  

### Usage  
Use the `--restart-policy` parameter with `az container create` to control restart behavior. Containers set to `Never` or `OnFailure` will stop and show **Terminated** status once their task completes.  

---

---

> Set environment variables in container instances  
**Completed – 100 XP**

Environment variables let you configure containerized applications dynamically, similar to using `--env` with `docker run`. ACI supports both standard and secure environment variables for Linux and Windows containers.  

### Key Points  
- **Standard variables**: Passed at creation using `--environment-variables`.  
- **Secure variables**: Used for sensitive values (e.g., passwords, keys). Their values are hidden in container properties and only accessible inside the container.  

### Example (CLI)  
```bash
az container create \
  --resource-group myResourceGroup \
  --name mycontainer2 \
  --image mcr.microsoft.com/azuredocs/aci-wordcount:latest \
  --restart-policy OnFailure \
  --environment-variables 'NumWords'='5' 'MinLength'='8'
```

* Example (YAML with secure values)
```yaml
environmentVariables:
  - name: 'NOTSECRET'
    value: 'my-exposed-value'
  - name: 'SECRET'
    secureValue: 'my-secret-value'
```
* Deploy with:
```bash
az container create --resource-group myResourceGroup --file secure-env.yaml
```

---

>  Mount an Azure file share in Azure Container Instances  

By default, Azure Container Instances (ACI) are stateless, meaning data is lost when a container stops. To persist state, you can mount an **Azure file share** from Azure Files, which provides fully managed SMB-based file shares.  

### Key Points  
- Only **Linux containers** are supported for Azure file share mounts.  
- Containers must run as **root**.  
- Volume mounts are limited to **CIFS support**.  
- Use `az container create` to specify account name, key, share name, and mount path.  
- YAML or ARM templates are recommended for multi-container or multi-volume deployments.  

### Example (CLI)  
```bash
az container create \
  --resource-group $ACI_PERS_RESOURCE_GROUP \
  --name hellofiles \
  --image mcr.microsoft.com/azuredocs/aci-hellofiles \
  --dns-name-label aci-demo \
  --ports 80 \
  --azure-file-volume-account-name $ACI_PERS_STORAGE_ACCOUNT_NAME \
  --azure-file-volume-account-key $STORAGE_KEY \
  --azure-file-volume-share-name $ACI_PERS_SHARE_NAME \
  --azure-file-volume-mount-path /aci/logs/
```

---

> Quiz: Azure Container Instances  

1. **Which of the following methods is recommended when deploying a multi-container group that includes only containers?**  
- Azure Resource Management template  
- ✅ YAML file  
- az container create command  

2. **What is the purpose of a restart policy in Azure Container Instances?**  
- To charge customers more for compute resources used while the container is running.  
- To ensure that containers are never restarted, even if the process fails.  
- ✅ To specify when and how containers should be restarted, based on the desired behavior.  

3. **If you want to mount multiple volumes, what options are at your disposal for deployment?**  
- YAML file only  
- ✅ Azure Resource Manager template and YAML file  
- Azure Resource Manager template and PowerShell  

---

> Summary  

In this module, you learned how to:  

- Describe the benefits of Azure Container Instances and how resources are grouped  
- Deploy a container instance in Azure by using the Azure CLI  
- Start and stop containers using policies  
- Set environment variables in your container instances  
- Mount file shares in your container instances



