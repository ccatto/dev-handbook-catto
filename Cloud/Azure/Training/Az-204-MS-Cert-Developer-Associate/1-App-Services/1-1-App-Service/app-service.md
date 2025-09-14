# Azure App Service

> Azure App Service is a fully managed platform for building, deploying, and scaling web apps, APIs, and mobile back ends without managing infrastructure. It supports multiple programming languages, containers, CI/CD integration, deployment slots, and scaling options, making it flexible and production-ready.

> Azure App Service plans define the compute resources, region, operating system, and pricing tier that your web apps run on. Apps within the same plan share resources, scale together, and can be adjusted by changing tiers or VM configurations. Higher tiers provide dedicated or isolated compute, more scaling options, and advanced features, while Free and Shared tiers are best suited for development and testing.

> Azure App Service supports both automated and manual deployments, making it flexible for different development workflows. Automated deployment integrates with CI/CD pipelines from sources like GitHub, Azure DevOps, and Bitbucket, while manual options include Git, CLI, ZIP deploy, and FTP/S. Deployment slots let you stage updates before swapping them into production, ensuring zero-downtime releases for both code and containerized apps.

> Azure App Service includes built-in authentication and authorization, letting you secure apps with minimal or no code by integrating identity providers like Microsoft Entra ID, Google, Facebook, GitHub, and more. The platform middleware handles sign-in flows, token validation, and session management automatically, working independently of your app code. You can configure whether unauthenticated requests are allowed or rejected, while also leveraging features like token storage and logging for easier security management.

> Azure App Service provides networking features to control both inbound and outbound traffic, ensuring apps are secured and integrated properly. Inbound options include access restrictions, private endpoints, and app-assigned addresses, while outbound options include hybrid connections and virtual network integration. You can also view the outbound IP addresses used by your app directly from the Azure CLI.

```bash
# Get current outbound IP addresses for an App Service app
az webapp show \
  --resource-group <group_name> \
  --name <app_name> \
  --query outboundIpAddresses \
  --output tsv

# Get all possible outbound IP addresses
az webapp show \
  --resource-group <group_name> \
  --name <app_name> \
  --query possibleOutboundIpAddresses \
  --output tsv

```

> In this hands-on exercise, you learn how to deploy a containerized application to Azure App Service using an image from the Microsoft Container Registry. The process begins by creating a new App Service resource in the Azure portal, configuring it to run Linux-based containers, and specifying the image (mcr.microsoft.com/k8se/quickstart:latest) to deploy. You walk through the setup in the Basics and Container tabs, where you define settings like subscription, resource group, app name, operating system, region, and pricing plan, along with container registry details.

After the deployment completes, you verify the deployment by navigating to the web app’s default domain, where the containerized application runs in Azure. Since container startup can take a few minutes, patience is required before the app is visible in the browser. Finally, you clean up resources by deleting the resource group to avoid unnecessary costs.

This 15-minute exercise reinforces how to create and configure an App Service web app for containers, deploy a containerized app, and manage the lifecycle of cloud resources in Azure.

### Deploy a containerized app to Azure App Service

This exercise guides you through creating an Azure App Service web app that runs a containerized application using an image from the Microsoft Container Registry. You configure container settings, deploy the app, and then verify it is running successfully. Finally, you view the results and clean up resources once the deployment is complete.

