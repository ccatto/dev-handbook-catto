# Kubernetes

# Kubernetes - Developer Handbook

**Kubernetes (K8s)** is an **open-source container orchestration platform** that automates the deployment, scaling, and management of containerized applications.  

It has become a **core technology for cloud-native applications**, microservices, and DevOps pipelines, enabling teams to reliably run applications across **on-premises and cloud environments**.

---

## Why Kubernetes is Important

- **Automates container management**, including deployment, scaling, and updates.  
- Provides **high availability and fault tolerance** for applications.  
- Enables **microservices architecture** with service discovery and load balancing.  
- Supports **hybrid and multi-cloud deployments**, allowing flexibility in infrastructure.  
- Integrates with **CI/CD pipelines** and DevOps practices for modern development workflows.  

---

## Key Concepts

1. **Cluster**
   - A set of nodes (machines) that run containerized applications.  
   - Contains a **control plane** and **worker nodes**.

2. **Node**
   - A single machine (VM or physical) in the cluster that runs containers.  

3. **Pod**
   - The **smallest deployable unit** in Kubernetes, typically a single container or a group of tightly coupled containers.

4. **Deployment**
   - Defines **desired state** for Pods and manages updates/rollbacks.  

5. **Service**
   - Provides **network access** to a set of Pods (load balancing and service discovery).  

6. **ConfigMap & Secret**
   - Store configuration and sensitive information separately from code.

7. **Namespace**
   - Logical separation of resources within a cluster for **multi-tenancy** or environment separation.

8. **Ingress**
   - Manages **external HTTP/S access** to services in the cluster.

---

## Kubernetes Architecture

Cluster
```
├── Control Plane
│   ├── API Server
│   ├── Scheduler
│   ├── Controller Manager
│   └── etcd (key-value store)

└── Worker Nodes
├── kubelet
├── kube-proxy
└── Container runtime (Docker, containerd)
```