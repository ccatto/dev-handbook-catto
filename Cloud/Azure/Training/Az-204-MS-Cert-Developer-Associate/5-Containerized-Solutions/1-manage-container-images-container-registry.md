# 📦 Manage Container Images in Azure Container Registry  

Learn how to use Azure Container Registry to store your container images, and automate builds and deployments.  

---

## Units  
- Introduction  
- Discover the Azure Container Registry  
- Explore storage capabilities  
- Build and manage containers with tasks  
- Explore elements of a Dockerfile  
- Exercise - Build and run a container image with Azure Container Registry Tasks  
- Module assessment  
- Summary  


> 🚀 Introduction  

Azure Container Registry (ACR) is a managed, private Docker registry service based on the open-source Docker Registry 2.0. You can create and maintain Azure container registries to store and manage your private Docker container images.  

---

## 🎯 Learning Outcomes  
After completing this module, you'll be able to:  

- Explain the features and benefits Azure Container Registry offers  
- Describe how to use ACR Tasks to automate builds and deployments  
- Explain the elements in a Dockerfile  
- Build and run an image in ACR using Azure CLI commands

---

> Discover the Azure Container Registry

Azure Container Registry (ACR) is a managed, private Docker-compatible registry for storing and managing container images and artifacts. It integrates with existing CI/CD pipelines and supports automated builds and updates through ACR Tasks. ACR offers three service tiers—Basic, Standard, and Premium—to support scenarios from learning to enterprise-scale workloads, including geo-replication and private endpoints in Premium.

---

> Explore storage capabilities

Azure Container Registry (ACR) provides enterprise-grade storage features across all tiers, including encryption-at-rest for image security and regional storage for compliance. Premium tiers add geo-replication for resiliency and performance across regions, as well as zone redundancy for high availability. Storage scales with unlimited repositories, images, and tags, though regular cleanup is recommended to maintain performance.

--- 
> Build and manage containers with tasks

Azure Container Registry (ACR) Tasks provide cloud-based, automated container image building and management. They support quick on-demand builds, automatic builds triggered by source code updates, base image updates, or schedules, and multi-step workflows for complex scenarios.

Key features:

Quick tasks: Run docker build and docker push in the cloud without a local Docker Engine.

Automated triggers: Build images on code commits, base image changes, or timer-based schedules.

Multi-step tasks: Use YAML to define workflows such as building, testing, and deploying containers or Helm charts.

Cross-platform support: Build for Linux, Windows, and Arm architectures with --platform.

ACR Tasks extend the development lifecycle into the cloud, enabling efficient, automated, and repeatable image management.

---

> Explore elements of a Dockerfile

A Dockerfile is a script containing instructions to build a Docker image. It typically defines a base image, installs dependencies, copies application files, exposes required services/ports, and specifies the command to run when the container starts.

Example highlights:

- FROM: Sets the base image (e.g., .NET 6 runtime).
- WORKDIR: Defines the working directory inside the container.
- COPY: Copies app files into the image.
- EXPOSE: Opens a port for communication (e.g., 80 for HTTP).
- CMD: Runs the application when the container launches.

Each instruction creates a layered image, which Docker caches for efficient builds.

quick sample: 
```Dockerfile
# Use the .NET 6 runtime as a base image
FROM mcr.microsoft.com/dotnet/runtime:6.0

# Set the working directory to /app
WORKDIR /app

# Copy the contents of the published app to the container's /app directory
COPY bin/Release/net6.0/publish/ .

# Expose port 80 to the outside world
EXPOSE 80

# Set the command to run when the container starts
CMD ["dotnet", "MyApp.dll"]
```

---

> Exercise: Build and run a container image with ACR Tasks

In this exercise, you build a container image from application code and push it to Azure Container Registry (ACR) using the Azure CLI. You learn to prepare your app for containerization, create an ACR instance, store the image, and run it from the registry.

Key steps:

- Create an ACR resource
- Build and push an image from a Dockerfile
- Verify the image in ACR
- Run the image from the registry

[Build and run a container image with Azure Container Registry Tasks](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-container-services/01-container-image-acr-tasks.html)

---

> Knowledge

## Check your knowledge

1. **Which of the following Azure Container Registry options support geo-replication to manage a single registry across multiple regions?**  
- Basic  
- Standard  
- ✅ Premium  

2. **Which Azure container registry tiers benefit from encryption-at-rest?**  
- ✅ Basic, Standard, and Premium  
- Basic and Standard only  
- Premium only  

---

## Summary ✅  


> In this module, you learned how to:  

- Explain the features and benefits Azure Container Registry (ACR) offers  
- Describe how to use ACR Tasks to automate builds and deployments  
- Explain the elements in a Dockerfile  
- Build and run an image in ACR using Azure CLI commands  

