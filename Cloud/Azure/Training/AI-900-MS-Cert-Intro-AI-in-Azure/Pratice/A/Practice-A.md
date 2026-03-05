# AI-900 Practice A

---

## Q1. Which of the following is a characteristic of the Platform as a Service (PaaS) model?

- A) Provides infrastructure management, including virtual machines and storage.
- B) Offers a platform for developing and deploying applications without managing the underlying infrastructure.
- C) Requires users to manage the operating system and runtime environment.
- D) Provides software applications over the internet on a subscription basis.

**Correct Answer: B**

**Explanation:** PaaS provides a managed platform where developers can build, deploy, and run applications without worrying about the underlying infrastructure (servers, storage, networking, OS). Option A describes **IaaS** (Infrastructure as a Service). Option C also leans toward IaaS, where users manage the OS and runtime. Option D describes **SaaS** (Software as a Service), where fully built applications are delivered over the internet.

---

## Q2. A retail startup wants to launch a seasonal shopping app without buying new servers. The team expects traffic spikes and wants to provision resources quickly and release them when demand drops. Which concept best defines cloud computing in this scenario?

- A) Colocated servers
- B) On-demand
- C) Always-owned private data center
- D) Fixed capacity hosting

**Correct Answer: B**

**Explanation:** The ability to quickly provision (scale up) and release (scale down) computing resources based on actual demand — without purchasing or maintaining physical servers — is a core characteristic of cloud computing known as **on-demand self-service**. Colocated servers (A) still require you to own hardware. A private data center (C) is the opposite of cloud flexibility. Fixed capacity hosting (D) doesn't allow elastic scaling.

---

## Q3. Based on the Shared Responsibility Model table, which responsibility stays with the customer across IaaS, PaaS, and SaaS?

| Layer | IaaS | PaaS | SaaS |
|---|---|---|---|
| Physical datacenter | MS | MS | MS |
| Network controls | Shared | Shared | MS |
| OS patching | Customer | MS | MS |
| App configuration | Customer | Customer | MS |
| Data & access | Customer | Customer | Customer |

- A) OS patching
- B) Network infrastructure
- C) Physical datacenter security controls
- D) Data

**Correct Answer: D**

**Explanation:** In the Azure Shared Responsibility Model, **Data & access** is always the customer's responsibility — across IaaS, PaaS, and SaaS. Microsoft provides tools (encryption at rest, RBAC, Azure AD) but the customer decides how to configure and use them. OS patching (A) is only the customer's job in IaaS. Network controls (B) are shared in IaaS/PaaS and Microsoft's in SaaS. Physical datacenter (C) is always Microsoft's responsibility.

---

## Q4. A financial services company runs a low-latency trading system in its own datacenter and uses Azure for burst analytics during market volatility, connected securely. Is this a hybrid cloud model?

- A) True
- B) False

**Correct Answer: A (True)**

**Explanation:** This is a textbook **hybrid cloud** deployment. The trading system stays on-premises for regulatory/latency reasons, while Azure provides elastic analytics capacity during spikes (cloud bursting). The secure connection between environments is key — hybrid cloud isn't just using two things separately, it's integrating on-prem and public cloud into one environment. Azure supports this via ExpressRoute, VPN, and Azure Arc.

---

## Q5. A government agency must keep sensitive citizen records on-premises due to compliance but wants Azure for seasonal spikes on a public web portal. What is the best-fit cloud model?

- A) Hybrid
- B) Public cloud only
- C) Private cloud on premises
- D) Community cloud model

**Correct Answer: A**

**Explanation:** Another hybrid cloud scenario. Sensitive data stays on-prem for compliance; the public-facing portal bursts to Azure for elastic scale during peak demand. Public cloud only (B) would violate compliance. Private cloud only (C) means no Azure elasticity and requires buying extra hardware. Community cloud (D) is a shared infrastructure among similar orgs — not what's described here.

---

## Q6. A university online exam system has heavy usage during exams and low usage overnight. Which characteristics align with a consumption-based model? (Select 3)

- A) Upfront hardware capital spend
- B) Metered usage
- C) Fixed monthly fee
- D) Scale with demand
- E) Annual license purchase
- F) Stop when idle

**Correct Answer: B, D, F**

**Explanation:** The consumption-based (pay-as-you-go) model means costs track actual usage. **Metered usage** (B) bills on measured consumption. **Scale with demand** (D) means resources grow/shrink with load. **Stop when idle** (F) means no charges when nothing is running. The wrong answers represent traditional/fixed cost models: upfront CapEx (A), fixed monthly fees (C), and annual licenses (E) all charge regardless of actual demand.

---

## Q7. A manufacturing company runs VMs 24/7 with stable usage, wants lower costs, is willing to commit long-term, but cannot tolerate VM eviction. Which pricing model is best?

| Pricing model | Commitment | Discount | Eviction risk | Best fit |
|---|---|---|---|---|
| Pay as you go | None | Low | None | Variable usage |
| Reserved | 1–3 years | High | None | Steady workloads |
| Spot | None | Very high | High | Interruptible jobs |
| Free credits | Trial only | Temporary | None | Short testing |

- A) Spot
- B) Pay as you go
- C) Reserved
- D) Free credits

**Correct Answer: C**

**Explanation:** **Reserved instances** offer high discounts (up to ~72% vs. pay-as-you-go) with a 1–3 year commitment and zero eviction risk — perfect for steady 24/7 workloads. Spot (A) has the deepest discounts but VMs can be reclaimed with 30 seconds notice. Pay-as-you-go (B) has no commitment but minimal savings for predictable usage. Free credits (D) are trial-only, not for production.

---

## Q8. A retail company needs event-driven image processing on upload, no server management, and costs aligned with executions. Which compute approach fits best?

- A) Virtual machines with autoscale
- B) Functions
- C) App Service plan
- D) Dedicated hosts

**Correct Answer: B**

**Explanation:** **Azure Functions** is serverless compute built for event-driven workloads. It triggers on blob uploads, scales automatically from zero, requires no server management, and bills per execution + duration (GB-seconds). VMs with autoscale (A) still require server management. App Service (C) runs continuously — not purely event-driven. Dedicated hosts (D) are physical servers for isolation/compliance — the opposite of serverless.

---

## Q9. A fintech payment API faces a 10x traffic surge during flash sales. The requirement is to add/remove instances. Which cloud benefit does this demonstrate?

| Requirement | Signal | Needed outcome |
|---|---|---|
| R1 | Zone outage | Keep service online |
| R2 | 10x traffic surge | Add/remove instances |
| R3 | Rapid expansion | Deploy capacity fast |

- A) Resiliency
- B) Always-on reserved compute capacity
- C) Durability
- D) Scalability

**Correct Answer: D**

**Explanation:** R2 (add/remove instances for a 10x traffic surge) is the definition of **scalability** — adjusting resources to match demand. Resiliency (A) is about surviving failures (matches R1 — zone outage). Durability (C) is about data persistence/protection against loss. Reserved capacity (B) is for steady predictable workloads, not dynamic surges.

---

## Q10. What allows you to enforce allowed locations and required tags at scale?

- A) RBAC
- B) Azure Policy
- C) Advisor
- D) Monitor

**Correct Answer: B**

**Explanation:** **Azure Policy** enforces organizational standards across subscriptions/resources. Built-in policies include "Allowed Locations" (restrict deployments to approved regions) and "Require a tag" (block non-compliant resources). RBAC (A) controls **who** can act, not **what** configurations are allowed. Advisor (C) only recommends — doesn't enforce. Monitor (D) observes and alerts but doesn't prevent non-compliant deployments.

---

## Q11. Can published reliability guidance and Azure Service Health communications improve predictability for operations and support reliability planning?

- A) True
- B) False

**Correct Answer: A (True)**

**Explanation:** Azure Service Health provides advance notice of planned maintenance (impacted resources, time windows, required actions). Published reliability guidance includes SLAs (e.g., 99.95%, 99.99%) and service-specific maintenance behavior. Together they let teams plan around maintenance windows and make informed architectural decisions (zone-redundant, multi-region) — critical for time-sensitive workloads like live exam proctoring.

---

## Q12. A government department must enforce that all new resources deploy only in approved regions and automatically block noncompliant deployments. What should they use?

- A) Policy
- B) Role assignments
- C) Encryption at rest
- D) DDoS Protection Standard

**Correct Answer: A**

**Explanation:** **Azure Policy** with the built-in "Allowed Locations" policy (Deny effect) automatically blocks resource deployments to unapproved regions. It's centralized, auditable, and applies at scale (management group/subscription level). Role assignments (B) control who can act, not where resources go. Encryption at rest (C) protects data confidentiality. DDoS Protection (D) mitigates network attacks — unrelated to location governance.

---

## Q14. A logistics company manages dozens of Azure resources across multiple subscriptions. The team wants to deploy consistently, reduce manual operational effort, and manage resources from a centralized interface.

Which choices best support manageability in this scenario? Select 3.

- A) Local admin consoles
- B) Azure portal
- C) Manual deployments
- D) ARM templates
- E) Ad-hoc change logs
- F) Azure Automation

**Correct Answer: B, D, F**

**Explanation:** **Azure portal** (B) is the centralized web-based interface for managing all Azure resources across subscriptions from a single pane of glass. **ARM templates** (D) provide Infrastructure as Code, enabling consistent, repeatable deployments and reducing configuration drift across environments. **Azure Automation** (F) automates operational tasks such as starting/stopping VMs, running PowerShell/Python scripts, scheduling maintenance, and managing resources — significantly reducing manual effort.

Local admin consoles (A) are decentralized and require installing tools on each machine. Manual deployments (C) are error-prone and inconsistent at scale. Ad-hoc change logs (E) don't provide automation or governance — they just record what happened.

---

## Q15. A media company is migrating a legacy application that requires custom OS-level settings and a specific patching schedule. The team wants the cloud provider to manage the physical hardware, but they want control over the guest operating system and installed software. They are deciding which cloud service type best matches these responsibilities.

**Exhibit 1 — Responsibility split by service type (excerpt)**

| Responsibility | IaaS | PaaS | SaaS |
|---|---|---|---|
| Manage physical servers | Provider | Provider | Provider |
| Patch guest OS | Customer | Provider | Provider |
| Manage runtime/middleware | Customer | Provider | Provider |
| Manage application code | Customer | Customer | Provider |

- A) PaaS
- B) SaaS
- C) IaaS
- D) Fully managed app service

**Correct Answer: C**

**Explanation:** The legacy application needs **custom OS-level settings** (registry tweaks, kernel parameters, specific configs) and a **specific patching schedule** (customer controls when/how guest OS is patched). The provider manages **physical hardware** but the customer retains control over **guest OS** and **installed software**.

From the exhibit: **IaaS** (e.g., Azure Virtual Machines) means the provider handles physical servers/infrastructure, but the **customer** is responsible for **patching guest OS**, managing runtime/middleware, and installed software — exactly matching the need for custom OS control. Customer has full admin access to the VM's guest OS (Windows/Linux), enabling custom settings and patching on their timeline. This is the standard pattern for lift-and-shift migrations of legacy apps requiring OS-level customization.

PaaS (A) = provider patches/manages guest OS automatically — no control over custom OS settings or patching schedule. SaaS (B) = fully managed; provider handles everything including OS, runtime, and often the app itself — no guest OS control. Fully managed app service (D) = similar to PaaS/SaaS (e.g., Azure App Service); provider controls OS patching and runtime — customer has limited/no OS-level access.

---

## Q16. A startup is building a new customer portal and wants to deploy its own code quickly. The team does not want to patch operating systems or manage the web runtime. They still need control over application settings and systems releases.

Which cloud service type best fits this scenario?

- A) IaaS
- B) Fully managed CRM service
- C) PaaS
- D) SaaS

**Correct Answer: C**

**Explanation:** This is a textbook **Platform as a Service (PaaS)** scenario for a startup building and deploying a custom customer portal. PaaS provides a ready-to-use platform (e.g., Azure App Service, Azure Functions, or Azure Static Web Apps) where developers can push code directly (via Git, CI/CD, or containers) and deploy in minutes without provisioning servers. The provider fully manages the underlying OS, patching, servers, runtime environment (e.g., .NET, Node.js, Python, Java), scaling, and load balancing — no need to handle guest OS updates or web server configs like IIS/Apache/Nginx. Customer retains full control over app code and logic, configuration settings (app settings, connection strings, environment variables), release/deployments (slots, versioning, rollbacks), custom logic, APIs, and authentication.

Microsoft's shared responsibility model confirms: In **PaaS**, the customer manages applications, data, and configurations/settings, while the provider handles OS, runtime, middleware, and infrastructure. This matches the needs perfectly — focus on building/deploying the portal without infra overhead.

IaaS (A) = customer must patch/manage the guest OS, install/configure the web runtime, and handle server-level maintenance — exactly what they don't want. Fully managed CRM service (B) = SaaS CRM (e.g., Dynamics 365, Salesforce) — fully built software with no ability to deploy custom code or control app settings beyond basic configuration. Not for building a new custom portal. SaaS (D) = provider delivers a complete, ready-to-use application — customer has minimal/no control over code, deployments, or deep app settings — opposite of "deploy its own code."

---

## Q17. A city council wants a ticketing system for citizen requests. IT wants the vendor to handle the application system updates and platform maintenance so the council can focus only on user access and the data they enter. The service responsibilities are summarized below.

| Option | Customer manages | Provider manages |
|---|---|---|
| 1 | OS + runtime + app | Hardware |
| 2 | App code + data | OS + runtime + platform + hardware |
| 3 | Users + data | App + platform + hardware |

Which cloud service type best matches Option 3?

- A) SaaS
- B) IaaS
- C) PaaS
- D) On-premises private cloud hosting

**Correct Answer: A**

**Explanation:** **Option 3** shows the customer manages only **Users + data** (access management, entering/viewing citizen request data, configuring users/permissions), while the provider manages everything else — **App + platform + hardware** (including application updates, platform maintenance, OS, runtime, middleware, servers, etc.). This is the exact definition of **Software as a Service (SaaS)** in the shared responsibility model: The provider delivers a complete, fully managed application. The customer has **no responsibility** for the application code, updates, patching, runtime, OS, or infrastructure — they simply use the software (log in, manage users, enter/view data). The vendor handles all **application system updates** and **platform maintenance** automatically. Common SaaS examples for ticketing/citizen request systems: ServiceNow, Zendesk, Microsoft Dynamics 365 Customer Service, or Azure-based SaaS offerings like Microsoft 365-based request management tools. This matches the city council's goal perfectly: focus **only on user access and the data they enter**, with zero concern for underlying maintenance or updates.

IaaS (B) = customer manages OS + runtime + app (matches Option 1), not just users + data. PaaS (C) = customer manages app code + data (matches Option 2), still responsible for their own application code, deployments, and updates — provider handles OS/runtime/platform/hardware. On-premises private cloud hosting (D) = customer would manage almost everything (hardware included in many cases), or at best a private IaaS/PaaS setup — not vendor-managed app updates and platform maintenance.

---

## Q18. You must expose an Azure PaaS service privately to a VNet with a private IP and no public endpoint.

- A) Service endpoints
- B) Site-to-Site VPN
- C) ExpressRoute
- D) Private Link (private endpoint)

**Correct Answer: D**

**Explanation:** **Azure Private Link** (using Private Endpoints) assigns a private IP address from your virtual network directly to a PaaS service (Azure Storage, Azure SQL, Azure Cosmos DB, Azure Key Vault, etc.), fully eliminating public internet exposure and public endpoints. The private endpoint is a network interface with a private IP from your VNet that brings the service into your private network space. Traffic between your VNet and the PaaS service travels entirely over the Microsoft backbone network, never crossing the public internet. This provides the highest level of network isolation and security for PaaS services.

Service endpoints (A) restrict access to specific VNets but still use the service's public IP address — the service endpoint enables private routing to the service's public endpoint from your VNet via optimized Microsoft network paths. Site-to-Site VPN (B) and ExpressRoute (C) connect your on-premises network to Azure but don't eliminate public endpoints for PaaS services — they're about network connectivity, not PaaS service exposure control.

---

## Q19. A manufacturing company is migrating a legacy app that requires admin access to the operating system to install custom agents and drivers. The team is considering a managed application platform to reduce operations work, but they cannot lose OS-level control for this workload.

Statement: For this legacy migration, **PaaS** is the best choice because it provides full guest OS control.

- A) True
- B) False

**Correct Answer: B (False)**

**Explanation:** The statement is false. **PaaS** (e.g., Azure App Service, Azure SQL, Azure Functions) abstracts and manages the underlying guest OS — you **cannot** get admin access to install custom agents/drivers or perform OS-level customizations. PaaS provides a managed platform where the provider handles OS patching, runtime management, and infrastructure, giving you no direct OS-level control.

When a workload requires full guest OS control — such as installing custom agents, drivers, modifying registry settings, or applying specific OS-level configurations — you must use **IaaS** (Infrastructure as a Service) with Azure Virtual Machines. IaaS gives you complete administrative access to the guest OS (Windows or Linux) and full control over everything installed on the VM, though it involves more operational overhead (patching, monitoring, maintaining the OS, etc.). This is the standard approach for lift-and-shift migrations of legacy apps that depend on OS-level customizations.

---

## Q20. A healthcare provider is deploying a patient-facing application in a single Azure region and wants to reduce the risk of downtime if a datacenter fails. The team wants a design that keeps services running within that region without needing a cross-region failover plan for every outage.

Which characteristics describe availability zones? Select 3.

- A) Across paired Azure regions
- B) Separate datacenters
- C) Different regions
- D) Independent power systems
- E) Single availability set
- F) Low-latency links

**Correct Answer: B, D, F**

**Explanation:** **Availability Zones** provide high availability **within a single Azure region** by using physically separate datacenters (B) with independent power, cooling, and networking (D). These zones are connected via high-bandwidth, low-latency links (F) that enable fast synchronous replication of data and rapid failover within the region — typically under 10-30 seconds. This design protects against datacenter-level failures (power outage, network disruption, fire, etc.) without requiring cross-region failover, which has higher latency, costs, and complexity.

Availability Zones go beyond **availability sets** (E), which only protect against host-level issues (rack/server failures) within a single datacenter. Unlike paired regions (A) or different regions (C), Availability Zones keep services and data within the same region, meeting compliance requirements that mandate data residency in a specific geography while still providing resilience against datacenter failures.

---

## Q21. A university's risk team is documenting where Azure physical compute and storage hardware is housed for a compliance review. They need to clearly distinguish the physical facility from higher-level constructs like zones. They reference an Exhibit 1 — Azure infrastructure terms (excerpt) below.

**Exhibit 1 (summary table):**
- **Datacenter**: Building with compute/storage/network → **Physical facility: Yes**
- **Availability zone**: One or more datacenters in a region → **Physical facility: No**
- **Region**: Geographic area containing zones → **Physical facility: No**

Based on the exhibit, which term is the physical facility that houses Azure compute, storage, and networking equipment?

- A) Group of paired regions
- B) Datacenter
- C) Availability zone
- D) Sovereign cloud region

**Correct Answer: B**

**Explanation:** The **datacenter** is the actual physical building/facility that directly houses Azure's compute, storage, and networking hardware. This includes servers, storage systems, network switches, power infrastructure, cooling systems, and physical security — the tangible equipment and infrastructure that runs Azure services.

Higher-level abstractions are **logical constructs**, not physical locations: **Availability zones** group one or more datacenters within a region for resilience. **Regions** are geographic areas containing multiple zones/datacenters. **Paired regions** (A) are logical relationships between two regions for disaster recovery. **Sovereign cloud regions** (D) are geographic deployments for data residency and compliance requirements — but they still contain physical datacenters as the actual facilities.

The exhibit clearly identifies only the **datacenter** as "Physical facility: Yes," distinguishing it from the logical grouping constructs (zones, regions) that organize multiple physical facilities for availability, compliance, or geographic distribution.

---

## Q22. Which service helps collect, analyze, and act on telemetry from Azure resources?

- A) Azure Resource Manager
- B) Azure Key Vault
- C) Azure Monitor
- D) Azure Arc

**Correct Answer: C**

**Explanation:** **Azure Monitor** is the central service in Azure for collecting, analyzing, and acting on telemetry from Azure resources and hybrid/on-premises environments. It provides a unified platform for:

- **Collecting**: Metrics (numeric time-series data like CPU, memory, disk I/O), Logs (detailed diagnostic and activity logs), and Activity Logs (audit trail of Azure resource operations).
- **Analyzing**: Dashboards (visualizations of metrics and logs), Log Analytics (powerful query language to analyze logs), Workbooks (custom interactive reports), and insights (pre-built monitoring for specific services like VMs, containers, apps).
- **Acting**: Alerts (notifications based on metrics or log conditions), Automated actions (runbooks, functions, webhooks), Autoscale (scale resources up/down based on metrics), and Smart Groups (group related alerts to reduce noise).

Azure Resource Manager (A) is the deployment and management service for Azure resources. Azure Key Vault (B) stores and manages secrets, keys, and certificates. Azure Arc (D) extends Azure management to on-premises, edge, and multi-cloud environments — but doesn't provide the telemetry collection/analysis platform itself.

---

## Q23. A manufacturing company wants to separate Azure spend and quotas between divisions while still allowing central governance. The cloud admin captured each division's needs in the table below:

| Division | Separate invoice | Separate quotas | Central governance needed |
|---|---|---|---|
| R&D | No | No | Yes |
| RetailOps | Yes | Yes | Yes |
| Corporate IT | No | No | Yes |

Which Azure construct should you create for the RetailOps division?

- A) Resource group
- B) Management group policy scope
- C) Tags
- D) Subscription

**Correct Answer: D**

**Explanation:** The RetailOps division requires a **separate invoice** (billing isolation) and **separate quotas** (independent subscription-level limits). Create a dedicated **Azure subscription** for this division. Subscriptions provide:

- **Isolated billing**: Each subscription generates a separate invoice, enabling accurate chargeback and cost tracking by division.
- **Independent quota management**: Each subscription has its own resource quotas and limits (vCPU, storage, networking) that don't affect other subscriptions.
- **Resource boundaries**: Resources deployed in one subscription are logically isolated from others, providing separation of concerns.
- **Central governance**: Subscriptions can be placed under a common management group to apply policies, RBAC, and cost management controls centrally across all divisions.

Resource groups (A) organize resources within a subscription but don't provide billing or quota isolation. Management group policy scope (B) applies policies hierarchically but doesn't create separate billing or quota boundaries. Tags (C) are key-value pairs for organizing and tracking resources but don't provide billing or quota separation — multiple divisions could share a subscription and just use different tags.

---

## Q24. A university has multiple Azure subscriptions owned by different faculties. Central IT wants to apply consistent Azure Policy and RBAC governance across all faculties without configuring each subscription one-by-one.

Statement: Creating a management group above the subscriptions can apply governance at scale.

- A) True
- B) False

**Correct Answer: A (True)**

**Explanation:** The statement is true. **Management groups** in Azure enable central IT to organize multiple subscriptions into a hierarchy and apply governance controls at scale. When you create a management group and place subscriptions under it, you can:

- **Apply Azure Policy definitions and assignments** at the management group level once — policies automatically inherit to all child subscriptions and resource groups.
- **Assign RBAC roles** at the management group level — role assignments inherit down to all child subscriptions and resources.
- **Enforce consistent governance** across all faculties without manually configuring each subscription.
- **Manage cost and billing** through hierarchical reporting and budget management.

Management groups support a multi-level hierarchy (up to 6 levels deep), allowing nested organization (e.g., Central IT → Faculty Management Groups → Department Subscriptions). Governance applied at higher levels automatically propagates down, while lower levels can apply more restrictive or specific policies. This eliminates the need to configure each subscription individually and ensures consistent compliance across the entire organization.

---

## Q25. In Azure, ______ contain subscriptions, which contain resource groups.

- A) Resource groups
- B) Management groups
- C) Subscriptions
- D) Resources

**Correct Answer: B**

**Explanation:** The Azure resource hierarchy is: **Management groups → Subscriptions → Resource groups → Resources**. Management groups sit at the top of the hierarchy and contain multiple subscriptions. Each subscription contains one or more resource groups, which in turn contain individual resources (VMs, databases, storage accounts, etc.). This hierarchical structure enables governance to flow downward — policies, RBAC assignments, and cost controls applied at the management group level automatically inherit to all child subscriptions, resource groups, and resources.

---

## Q26. Legacy app (full OS control) + packaged microservice + event-driven fraud check. Which compute types? Select 3.

- A) Functions
- B) Containers
- C) Virtual machines
- D) Virtual network
- E) Key Vault
- F) Management groups

**Correct Answer: A, B, C**

**Explanation:** **Virtual machines** (C) provide full OS control needed for legacy applications requiring custom agents, drivers, or registry modifications. **Containers** (B) package applications and their dependencies into a portable image for consistent deployment of microservices across environments. **Functions** (A) provide event-driven, serverless code execution ideal for short-lived tasks like fraud checks triggered by API calls or queue messages.

Virtual networks (D), Key Vault (E), and Management groups (F) are not compute services — they provide networking, secrets management, and governance respectively, but don't execute application code.

---

## Q27. Which Azure resource is required to connect a VM to a virtual network with a private IP and no public address?

- A) Network security group
- B) Network interface
- C) Route table
- D) Public IP address

**Correct Answer: B**

**Explanation:** A **network interface** (NIC) is required to connect a virtual machine to a virtual network. The NIC attaches to a subnet within the VNet and provides the VM's IP configuration (private IP address). If a public IP is needed for internet access, it can be attached to the NIC, but this is optional — the VM can operate with only a private IP.

Network security groups (A) filter traffic to/from the NIC but don't provide connectivity. Route tables (C) control routing but don't connect the VM to the VNet. Public IP addresses (D) are optional and not required for private-only connectivity.

---

## Q28. Deploy same packaged runtime consistently across test and production as an image, no OS management. Best hosting option?

- A) Virtual machines
- B) Web apps
- C) App Service plans
- D) Containers

**Correct Answer: D**

**Explanation:** **Containers** package the application and its dependencies (runtime, libraries, configuration) into a portable image that can be deployed consistently across test, staging, and production environments. The container image includes everything needed to run the application, eliminating "it works on my machine" issues. Containers don't require OS management from the customer perspective — the container orchestrator (like Azure Kubernetes Service or Azure Container Instances) manages the underlying infrastructure.

Virtual machines (A) require OS management and don't guarantee consistency across environments unless images are carefully maintained. Web apps (B) and App Service plans (C) are PaaS services that focus on code deployment rather than container image-based deployments.

---

## Q29. Azure Cloud Shell requires you to install Azure PowerShell locally before running commands. True or False?

- A) True
- B) False

**Correct Answer: B (False)**

**Explanation:** The statement is false. **Azure Cloud Shell** is a browser-based interactive shell environment that provides pre-installed Azure PowerShell, Azure CLI, and other tools — no local installation required. You access Cloud Shell directly from the Azure portal (shell.azure.com), Azure mobile app, or Azure documentation pages. Cloud Shell is ideal for shared computers, kiosk scenarios, or when you need quick access to Azure management tools without installing anything locally. The session persists across browser sessions using Azure Files for storage.

---

## Q30. How can an Azure app authenticate to services without storing secrets in code or config?

- A) Service principal
- B) Managed identities for Azure resources
- C) Azure Key Vault
- D) SAS token

**Correct Answer: B**

**Explanation:** **Managed identities for Azure resources** provide Azure services (VMs, App Service, Functions, etc.) with an automatically managed Entra ID identity. The workload uses this identity to request tokens from Azure AD to authenticate to other Azure services — no credentials, secrets, or connection strings to manage or rotate. Microsoft handles identity lifecycle, automatically rotating credentials and removing the risk of leaked secrets.

Service principals (A) require managing a client secret or certificate. Azure Key Vault (C) stores secrets securely but still requires credentials to access it. SAS tokens (D) can leak and provide access that's hard to revoke without regenerating.

---

## Q31. An Azure VPN Gateway can provide an encrypted tunnel over the public internet between on-premises and Azure VNet. True or False?

- A) True
- B) False

**Correct Answer: A (True)**

**Explanation:** The statement is true. **Azure VPN Gateway** supports site-to-site (S2S) encrypted VPN tunnels over the public internet between your on-premises network and Azure virtual networks. The VPN Gateway acts as a cross-premises VPN appliance, establishing IPsec tunnels that encrypt all traffic flowing between the networks. This provides secure connectivity without requiring dedicated private circuits like ExpressRoute.

VPN Gateway also supports point-to-site (P2S) VPN for individual users to connect to Azure VNets from anywhere, and VNet-to-VNet VPN for connecting Azure VNets across regions. ExpressRoute provides private, dedicated network connections but doesn't use the public internet — it's an alternative to VPN Gateway, not a replacement.

---

## Q33. Unstructured game media + SMB file share + simple message queue. Which Azure Storage services? Select 3.

- A) Managed disk storage
- B) Queue Storage
- C) Table Storage
- D) Archive access tier
- E) Azure Files
- F) Blob Storage

**Correct Answer: B, E, F**

**Explanation:** **Blob Storage** (F) stores unstructured objects like game media assets (images, videos, audio, 3D models) — optimized for massive scale and content delivery. **Azure Files** (E) provides fully managed file shares accessible via the SMB protocol — ideal for legacy applications and file servers requiring standard file share access. **Queue Storage** (B) provides reliable, asynchronous messaging for decoupling components — simple FIFO queues for task processing and load leveling.

Managed disks (A) are block storage attached to VMs, not for object/file/queue storage. Table Storage (C) stores structured key-value data, not unstructured media. Archive tier (D) is a cold storage access tier, not a storage service type.

---

## Q34. Partner users sign in with their own org accounts and need access to one project workspace. Which identity type best represents them?

- A) Service principal
- B) Managed identity
- C) Invitation policy
- D) Guests

**Correct Answer: D**

**Explanation:** **Guest users** are external identities (users from other organizations or personal Microsoft accounts) invited to collaborate with your Azure resources. They sign in using their own organizational credentials and are granted scoped, limited access to specific resources or workspaces — ideal for partner collaboration on a single project without providing full tenant access.

Service principals (A) are non-human identities representing applications or automation, not partner users. Managed identities (B) are for Azure services, not external users. Invitation policy (C) is a configuration setting that controls how guests are invited, not an identity type itself.

---

## Q35. Require extra sign-in only for unmanaged devices or outside corporate network. Which capability enforces these "if this, then require" rules?

- A) Multifactor authentication
- B) Conditional Access
- C) Passwordless
- D) Defender for Cloud

**Correct Answer: B**

**Explanation:** **Microsoft Entra Conditional Access** evaluates sign-in context (device compliance, location, risk level, user role, application sensitivity) and applies policy decisions based on that context — the classic "if this, then require that" model. For example: "Require MFA when sign-in is from an unmanaged device" or "Block access when sign-in is from a high-risk location outside corporate network."

MFA (A) is an enforcement action, not the decision engine — Conditional Access triggers MFA based on context. Passwordless (C) changes the authentication method but doesn't evaluate sign-in context. Defender for Cloud (D) focuses on workload security posture, not sign-in policies.

---

## Q36. In Zero Trust, users and devices inside the corporate network are trusted by default and do not require ongoing verification. True or False?

- A) True
- B) False

**Correct Answer: B (False)**

**Explanation:** The statement is false. **Zero Trust** is a security model based on three core principles: **verify explicitly** (always authenticate and authorize based on all available data points), **use least privilege** (limit access with just-in-time and just-enough-access policies), and **assume breach** (minimize blast radius and segment access). In Zero Trust, network location is NOT a trusted signal — whether a request originates from inside the corporate network or from the internet, it requires the same level of verification. No user or device is trusted by default, regardless of location.

Traditional perimeter-based security models trusted internal traffic by default, but Zero Trust eliminates that assumption — every access request is continuously verified.

---

## Q37. Multiple security layers so that if one fails, others reduce risk. This is called ______.

- A) Defense in depth
- B) Shared responsibility
- C) Least privilege
- D) Single-layer perimeter

**Correct Answer: A**

**Explanation:** **Defense in depth** is a security strategy that layers multiple security controls across different levels (identity, network, application, data) so that if one control fails or is bypassed, others still provide protection. This approach acknowledges that no single security measure is perfect — redundancy and diversity of controls reduce overall risk. Examples: multi-factor authentication (identity layer), network security groups (network layer), web application firewalls (application layer), encryption (data layer).

Shared responsibility (B) describes the allocation of security duties between Microsoft and the customer, not the layered control strategy. Least privilege (C) is an access principle, not a layered approach. Single-layer perimeter (D) is the opposite of defense in depth — it relies on one defensive boundary.

---

## Q38. Which are core parts of Azure role-based access control? Select 3.

- A) Role assignment
- B) Network security group
- C) Scope inheritance
- D) Built-in roles
- E) Multifactor authentication
- F) Storage encryption

**Correct Answer: A, C, D**

**Explanation:** **Role assignments** (A) connect a principal (user, group, service principal, managed identity) to a role definition at a specific scope (management group, subscription, resource group, or resource) — this grants the access. **Built-in roles** (D) are predefined permission sets like Owner, Contributor, Reader, and specialized roles for specific services (e.g., Virtual Machine Contributor, Storage Blob Data Owner). **Scope inheritance** (C) means that permissions assigned at a higher scope (management group or subscription) automatically apply to all child resources — permissions flow down the hierarchy.

Network security groups (B) control network traffic, not RBAC. MFA (E) is an authentication mechanism, not RBAC. Storage encryption (F) is a data protection feature, not an access control mechanism.

---

## Q39. Single place for security recommendations, secure score tracking, and threat alerts across subscriptions. Which service?

- A) Conditional Access
- B) Azure Policy
- C) Microsoft Defender for Cloud
- D) Azure Monitor

**Correct Answer: C**

**Explanation:** **Microsoft Defender for Cloud** (formerly Azure Security Center) provides a unified security posture management platform across all Azure subscriptions, hybrid environments, and multi-cloud resources. It delivers security recommendations based on best practices, tracks a **secure score** to measure your security posture, and provides threat detection alerts for suspicious activities. Defender for Cloud also offers just-in-time VM access, vulnerability assessment, and compliance assessments.

Conditional Access (A) manages sign-in policies. Azure Policy (B) enforces governance and configuration rules. Azure Monitor (D) provides observability (metrics, logs) but is focused on performance and health, not security posture.

---

## Q40. Same service, different prices depending on where it's deployed. Which factor is most directly affecting price?

- A) Reserved pricing
- B) Egress
- C) Region
- D) Free tier

**Correct Answer: C**

**Explanation:** **Region** is the most direct factor causing price variations for the same Azure service configuration. Azure service rates differ by geographic region due to local factors like infrastructure costs, demand, regulatory requirements, and currency fluctuations. For example, a Standard_D2s_v3 VM in East US may have a different hourly rate than the exact same VM size in West Europe.

Reserved pricing (A) is a commitment discount model, not a geographic factor. Egress (B) refers to data transfer out of Azure, not the base service price. Free tier (D) is a promotional offering for certain services within usage limits, not a geographic pricing factor.

---

## Q41. Label resources with department and environment metadata for cost allocation and filtering. Use ______.

- A) Resource groups
- B) Management groups
- C) Subscriptions
- D) Tags

**Correct Answer: D**

**Explanation:** **Tags** are key-value metadata labels (e.g., "Department": "Finance", "Environment": "Production") that you can apply to Azure resources. Tags enable cost allocation (billing by tag), organization (filter resources by metadata), and policy enforcement (require tags on resources). Tags are flexible, user-defined, and don't affect resource runtime behavior.

Resource groups (A) are logical containers for resources that share the same lifecycle — they organize resources but don't provide granular metadata like tags. Management groups (B) organize subscriptions for governance, not individual resource labeling. Subscriptions (C) are billing and quota boundaries, not metadata labels.

---

## Q43. What is an Azure subscription?

- A) A billing container for Azure resources
- B) A virtual machine type
- C) A storage account type
- D) A backup service

**Correct Answer: A**

**Explanation:** An **Azure subscription** is a logical container used to provision and manage resources in Azure. It serves as the fundamental billing boundary — all resource usage within a subscription is tracked and billed together. Subscriptions also define access boundaries (RBAC is scoped at the subscription level), quota limits (resource quotas are per-subscription), and payment methods. You can have multiple subscriptions for different departments, environments, or billing purposes.

Virtual machines (B), storage accounts (C), and backup services (D) are all resources that exist within subscriptions, not the subscription itself.

---

## Q44. Sensor logs accessed ~once/month; immediate availability needed; want lower cost than hot storage. Which tier?

- A) Hot
- B) Archive
- C) Cool
- D) Premium

**Correct Answer: C**

**Explanation:** The **Cool** access tier is designed for data that is infrequently accessed (at least 30 days) but must remain immediately available for retrieval. It offers lower storage costs than the Hot tier while still providing millisecond-level read latency — perfect for sensor logs accessed monthly. Data in Cool can be transitioned to the Archive tier after 90+ days of no access for even lower cost.

Hot tier (A) is optimized for frequent access but has higher storage costs — suitable for data accessed daily or more often. Archive tier (B) has the lowest cost but retrieval takes hours (not immediate), violating the requirement. Premium tier (D) is for high-performance scenarios (SSD-backed) with higher costs, not infrequently accessed logs.

---

## Q45. Azure Cost Management can create budgets and alerts but cannot produce cost analysis views. True or False?

- A) True
- B) False

**Correct Answer: B (False)**

**Explanation:** The statement is false. **Azure Cost Management** provides comprehensive cost management capabilities including: **budgets and alerts** (proactive notifications when spending exceeds thresholds), **cost analysis views** (interactive dashboards for spending trends, forecasting, and breakdown by resource, tag, or time), and **optimization recommendations** (identify underutilized resources, right-size suggestions). Cost analysis is a core feature, not a missing capability — you can view spending trends, analyze costs by dimension (resource group, tag, subscription), and export data for custom reporting.

---

## Q46. Data must survive a single datacenter failure and stay within the same region. Which redundancy option?

- A) Locally-redundant storage (LRS)
- B) Geo-redundant storage (GRS)
- C) Zone-redundant storage (ZRS)
- D) Read-access geo-redundant storage (RA-GRS)

**Correct Answer: C**

**Explanation:** **Zone-redundant storage (ZRS)** replicates your data synchronously across three Azure availability zones in the same region. If a single datacenter (availability zone) fails, your data remains available from the other zones. This provides datacenter-level resilience while keeping all data within the same region — important for compliance requirements that mandate data residency.

LRS (A) replicates data three times within a single datacenter — it doesn't protect against datacenter failures. GRS (B) and RA-GRS (D) replicate data across regions (to a paired region), which violates the requirement to keep data within the same region.

---

## Q47. One storage account supporting unstructured objects + SMB file share + message queue + key-value tables. Which type?

- A) General-purpose
- B) Blob-only
- C) Premium block blobs
- D) Premium file shares

**Correct Answer: A**

**Explanation:** **General-purpose storage accounts** support all Azure Storage services: Blob Storage (unstructured objects), Azure Files (SMB file shares), Queue Storage (message queues), and Table Storage (key-value tables) — all under a single account. This is the default account type for most scenarios requiring multiple storage services.

Blob-only accounts (B) only support Blob Storage. Premium block blobs (C) are optimized for block blob performance with higher IOPS but don't support Files, Queues, or Tables. Premium file shares (D) are optimized for file share performance but don't support other storage services.

---

## Q48. AzCopy is a graphical user interface tool for browsing Azure Storage and transferring files. True or False?

- A) True
- B) False

**Correct Answer: B (False)**

**Explanation:** The statement is false. **AzCopy** is a command-line utility (not a graphical interface) optimized for high-performance data transfer to and from Azure Storage. It supports resumable transfers, parallel processing, and scripting for automation — ideal for moving large amounts of data efficiently. AzCopy runs on Windows, Linux, and macOS.

For a graphical browsing experience with Azure Storage, use **Azure Storage Explorer** — a free GUI application that lets you visually browse storage accounts, blobs, files, queues, and tables, with drag-and-drop file transfer capabilities.

---

## Q49. Which capabilities best align with Microsoft Purview? Select 3.

- A) Resource deployment denial
- B) Data catalog
- C) Role assignment control
- D) Data classification
- E) Data lineage
- F) Virtual network peering

**Correct Answer: B, D, E**

**Explanation:** **Microsoft Purview** is a unified data governance service that provides: **Data catalog** (B) for discovering, understanding, and inventorying data assets across on-premises, multi-cloud, and SaaS environments. **Data classification** (D) for automatically and manually classifying sensitive data (PII, financial, health) based on patterns and rules. **Data lineage** (E) for tracking data flow and transformation across systems — understanding where data comes from, how it's processed, and where it goes.

Resource deployment denial (A) is an Azure Policy capability. Role assignment control (C) is RBAC. Virtual network peering (F) is networking, not data governance.

---

## Q50. 120 TB of file data, limited bandwidth, cannot meet transfer timeline online. Best migration option?

- A) Azure Migrate
- B) Site Recovery
- C) Storage Explorer
- D) Azure Data Box

**Correct Answer: D**

**Explanation:** **Azure Data Box** is designed for offline bulk data transfer when network bandwidth is insufficient or transfer time is too long. Microsoft ships you a physical, secure storage device (Data Box Disk, Data Box, or Data Box Heavy depending on data volume). You copy your data to the device, ship it back to Microsoft, and the data is uploaded to your Azure Storage account. For 120 TB with limited bandwidth, this is significantly faster than online transfer.

Azure Migrate (A) is for server and application migration assessment, not data transfer. Site Recovery (B) is for disaster recovery and replication. Storage Explorer (C) requires online network transfer — not suitable for large datasets with bandwidth constraints.

---

## Q51. Cloud user accounts for app sign-in + legacy app needing domain join without managing domain controller VMs. Select 2.

- A) Microsoft Entra ID
- B) Active Directory Domain Services
- C) Entra Domain Services
- D) Azure Key Vault
- E) Azure Policy
- F) Azure Virtual Network

**Correct Answer: A, C**

**Explanation:** **Microsoft Entra ID** (formerly Azure AD) is the cloud-based identity and access management platform that provides user authentication, single sign-on (SSO), and application access for cloud users signing in to apps. **Entra Domain Services** provides managed domain services (domain join, group policy, LDAP, Kerberos) without requiring you to deploy and manage domain controller VMs — ideal for legacy applications that need traditional Active Directory features.

Active Directory Domain Services (B) requires self-managed VMs running Windows Server as domain controllers — the scenario explicitly wants to avoid this. Key Vault (C), Policy (E), and VNet (F) are not directory services.

---

## Q52. Primary goal: eliminate passwords for interactive sign-in while accessing multiple apps. Best authentication method?

- A) Multifactor authentication
- B) Passwordless
- C) Single sign-on
- D) Password hash sync

**Correct Answer: B**

**Explanation:** **Passwordless authentication** eliminates passwords entirely as a sign-in factor, replacing them with stronger alternatives like Windows Hello for Business (biometrics or PIN), FIDO2 security keys, or the Microsoft Authenticator app. Users sign in without ever typing a password, reducing phishing and credential theft risks. Passwordless provides both security and user experience benefits — no passwords to remember, manage, or reset.

MFA (A) adds a second verification step but still requires a password as the primary factor. SSO (C) reduces the number of sign-in prompts across multiple apps but doesn't remove the password requirement. Password hash sync (D) is an identity synchronization method between on-premises AD and Entra ID, not an authentication method.

---

## Q55. Which Azure service provides identity and access management capabilities?

- A) Azure Active Directory (Entra ID)
- B) Azure Virtual Network
- C) Azure Firewall
- D) Azure Load Balancer

**Correct Answer: A**

**Explanation:** **Microsoft Entra ID** (formerly Azure Active Directory) is Azure's comprehensive identity and access management service. It provides user and group management, authentication (MFA, passwordless), single sign-on (SSO) across applications, conditional access policies, and role-based access control (RBAC). Entra ID secures access to Azure resources, Microsoft 365, SaaS applications, and custom applications.

Virtual Network (B) provides networking. Firewall (C) provides network security. Load Balancer (D) distributes network traffic — none of these provide identity and access management.

---

## Q56. Which is a primary benefit of cloud computing?

- A) Increases upfront capital expenditure
- B) Software requires no updates
- C) Provides global reach and scalability
- D) Eliminates all security risks

**Correct Answer: C**

**Explanation:** **Global reach and scalability** is a primary cloud computing benefit. Azure operates datacenters in over 60 regions worldwide, enabling you to deploy applications close to users for low latency and compliance with data residency requirements. You can also scale resources dynamically (scale out by adding instances, scale up by using more powerful resources) to match demand without purchasing or provisioning physical infrastructure in advance.

Cloud computing **reduces** upfront capital expenditure (A) — you pay for what you use (pay-as-you-go). Software in cloud models still requires updates (B) — though in PaaS/SaaS, the provider handles some of this. Security is a shared responsibility (D) — cloud providers secure the infrastructure, but customers are responsible for securing their data and applications.

---

## Q57. Which is an example of a compute service in Azure?

- A) Azure Blob Storage
- B) Azure Virtual Machines
- C) Azure Active Directory
- D) Azure Traffic Manager

**Correct Answer: B**

**Explanation:** **Azure Virtual Machines** is a compute service that provides scalable, on-demand computing power to run applications, development and test environments, and data center extensions. You can choose from Windows or Linux VMs in various sizes to match your workload requirements. Compute services process and execute code and applications.

Azure Blob Storage (A) is storage, not compute. Azure Active Directory (C) is an identity service. Azure Traffic Manager (D) is a DNS-based traffic routing service — networking, not compute.

---

## Q61. Which cloud deployment model allows resources to be shared by multiple organizations?

- A) Private cloud
- B) Public cloud
- C) Hybrid cloud
- D) On-premises

**Correct Answer: B**

**Explanation:** **Public cloud** is a cloud deployment model where infrastructure is owned and operated by a third-party cloud service provider (like Microsoft Azure) and shared among multiple organizations (tenants). All customers share the same physical infrastructure, though each customer's data is logically isolated. Public cloud offers economies of scale, no capital expenditure, and pay-as-you-go pricing.

Private cloud (A) is infrastructure dedicated to a single organization — not shared. Hybrid cloud (C) combines private and public cloud, but the public component is still the part where resources are shared. On-premises (D) is on-site infrastructure owned by the organization — not a shared model.

---

## Q62. Which cloud model is best for a company that wants fully dedicated infrastructure for sensitive data?

- A) Private cloud
- B) Public cloud
- C) Hybrid cloud
- D) Community cloud

**Correct Answer: A**

**Explanation:** **Private cloud** provides infrastructure dedicated solely to one organization, with complete control over security, compliance, and data residency. This is ideal for highly sensitive data, strict regulatory requirements, or workloads that cannot share infrastructure due to security policies. Private cloud can be on-premises (in your own datacenter) or hosted by a third party but dedicated to your organization.

Public cloud (B) shares infrastructure among multiple organizations — not fully dedicated. Hybrid cloud (C) includes a public component, so not fully dedicated. Community cloud (D) is shared among similar organizations (e.g., government, healthcare) — not dedicated to one organization.

---

## Q64. In Azure, which responsibility is typically managed by the customer?

- A) Physical security of datacenters
- B) Network infrastructure
- C) Application security
- D) Hardware maintenance

**Correct Answer: C**

**Explanation:** In the Azure Shared Responsibility Model, the **customer** is responsible for securing their applications, data, and access control. This includes: application code security, data encryption (in transit and at rest), identity and access management (RBAC, MFA), network security (NSGs, WAF), and compliance. You must ensure your applications follow security best practices and that sensitive data is protected.

Physical security of datacenters (A), network infrastructure (B) within Azure, and hardware maintenance (D) are all managed by Microsoft — these are provider responsibilities in the cloud model.

---

## Q65. What is a key benefit of implementing governance and security in Azure?

- A) Automatically reduces all costs
- B) Protects resources and ensures compliance
- C) Eliminates the need for backups
- D) Removes all human errors

**Correct Answer: B**

**Explanation:** Implementing **governance and security** in Azure protects your resources, data, and applications while ensuring compliance with regulatory requirements and organizational policies. Key benefits include: preventing misconfigurations (via Azure Policy), controlling access (via RBAC), detecting threats (via Defender for Cloud), maintaining audit trails (via Activity Log), and meeting compliance standards (PCI-DSS, HIPAA, GDPR). Governance and security reduce risk and provide operational controls.

Governance and security do NOT automatically reduce all costs (A) — cost management is a separate practice. They don't eliminate the need for backups (C) — backups are still required for disaster recovery. They can't remove all human errors (D) — they reduce and control risks, but humans still make mistakes.

---

## Q66. A production storage account must not be deleted, but normal configuration changes should still be allowed. Which lock type?

- A) Read-only
- B) CanNotDelete
- C) Delete
- D) Prevent all resource changes

**Correct Answer: C**

**Explanation:** A **Delete** lock (called **CanNotDelete** in the Azure portal API) prevents the resource from being deleted while still allowing all other operations including configuration changes. This protects critical production resources from accidental deletion without blocking normal updates, scaling, or modifications.

A Read-only lock (A) blocks ALL changes to the resource, including configuration updates — too restrictive for a production storage account that needs normal operations. "Prevent all resource changes" (D) is equivalent to Read-only — not the intended behavior here.

---

## Q67. Browser-based graphical UI to manage Azure resources, no local installation. Which tool?

- A) Portal
- B) PowerShell
- C) Azure CLI
- D) Storage Explorer

**Correct Answer: A**

**Explanation:** The **Azure portal** (portal.azure.com) is a web-based graphical user interface that lets you create, configure, monitor, and manage Azure resources without any local installation. It runs in any modern web browser, providing a unified experience for discovering services, managing resources, and viewing dashboards. The portal is ideal for visual management, resource discovery, and teams that prefer GUI over command-line tools.

PowerShell (B) and Azure CLI (C) are command-line tools that require installation and typed commands. Storage Explorer (D) is a GUI tool but is specific to storage and requires local installation.

---

## Q68. Which characteristics align with infrastructure as code? Select 3.

- A) Manual portal changes
- B) Version control
- C) One-time setup only
- D) Repeatable deployments
- E) Untracked local edits
- F) Peer review

**Correct Answer: B, D, F**

**Explanation:** **Infrastructure as Code (IaC)** treats infrastructure configuration like software development code. Key characteristics include: **Version control** (B) — storing infrastructure definitions in git for change tracking, rollback, and collaboration. **Repeatable deployments** (D) — consistent, automated deployments across environments (dev, test, prod) eliminating configuration drift. **Peer review** (F) — code review process to catch issues before applying changes to production.

Manual portal changes (A) cause configuration drift and aren't tracked. One-time setup only (C) ignores ongoing iteration and maintenance — IaC is about continuous management. Untracked local edits (E) reduce auditability and collaboration — IaC requires all changes to be tracked in version control.

---

## Q70. Automated best-practice recommendations across cost, performance, reliability, and security — without changing resources automatically. Which service?

- A) Azure Monitor
- B) Microsoft Defender for Cloud
- C) Azure Advisor
- D) Azure Cost Management

**Correct Answer: C**

**Explanation:** **Azure Advisor** analyzes your Azure environment and provides personalized, automated best-practice recommendations across four categories: **Cost** (identify underutilized resources, right-size VMs), **Performance** (improve application responsiveness), **Reliability** (increase availability and resiliency), and **Security** (harden security posture). Advisor provides actionable recommendations but does NOT automatically apply changes — you review and implement them manually. This ensures you maintain control over when and how changes are applied.

Azure Monitor (A) provides observability (metrics, logs) and alerts but doesn't provide best-practice recommendations. Defender for Cloud (B) focuses on security posture and threat protection. Cost Management (D) focuses on spending analysis and budgets.

---

## Q72. What is the purpose of an Azure resource group?

- A) To group related resources for easier management
- B) To provide extra storage for resources
- C) To deploy resources automatically
- D) To monitor network traffic

**Correct Answer: A**

**Explanation:** An **Azure resource group** is a logical container that groups related Azure resources (VMs, databases, storage accounts, VNets, etc.) together for easier management. All resources in a resource group share the same lifecycle — you can deploy, update, and delete them together. Resource groups also enable: applying RBAC (role assignments) to all resources in the group, applying policies to the entire group, viewing consolidated cost tracking by group, and organizing resources by application, environment, or department.

Resource groups do NOT provide extra storage (B) — that's what storage accounts do. They don't automatically deploy resources (C) — that's what ARM templates or other deployment tools do. They don't monitor network traffic (D) — that's what Network Watcher or NSG flow logs do.

---

## Q73. Disaster recovery across two Azure regions in the same geography, with Microsoft-recommended recovery ordering. Design using a ______.

- A) Availability set
- B) Sovereign cloud region
- C) Single region
- D) Region pair

**Correct Answer: D**

**Explanation:** **Region pairs** are Microsoft-defined relationships between two Azure regions within the same geography, designed for disaster recovery and data residency. Each region is paired with another region in the same geography (e.g., East US is paired with West US). Microsoft uses region pairs for service updates — they update the paired region first before the primary region, ensuring one region is always available. This provides coordinated recovery ordering: if one region fails, the paired region is the recommended failover target.

Availability sets (A) provide high availability within a single region, not across regions. Sovereign cloud region (B) is for compliance isolation, not disaster recovery. Single region (C) cannot survive a regional outage.

---

## Q78. Deliver temporary Windows desktops to 300 students, centrally managed, scale in/out. Which option per exhibit?

- A) Availability set
- B) VM Scale Set
- C) AVD (Azure Virtual Desktop)
- D) Single VM

**Correct Answer: C**

**Explanation:** **Azure Virtual Desktop (AVD)** is purpose-built for delivering virtual desktops to end users at scale. AVD provides centralized management of desktop images, applications, and user profiles. You can scale the number of session hosts up or down based on demand — perfect for temporary desktops (students, contractors, seasonal workers) where user counts fluctuate. AVD supports multi-session Windows 10/11 (one VM serves multiple users) for cost efficiency, or single-session for dedicated desktops.

Availability sets (A) provide VM resiliency within a datacenter, not desktop delivery. VM Scale Sets (B) scales application workloads (web servers, microservices), not user desktops. Single VM (D) cannot serve 300 users — even with multiple sessions, it's impractical.

---

## Q79. Which authentication method adds a second verification step to increase security?

- A) Single sign-on
- B) RBAC
- C) Multifactor authentication (MFA)
- D) Passwordless

**Correct Answer: C**

**Explanation:** **Multifactor authentication (MFA)** requires users to provide two or more verification factors to prove their identity, significantly increasing security beyond just a password. The factors are typically: something you know (password), something you have (mobile device, hardware token, phone), and something you are (biometrics like fingerprint or face). Even if an attacker obtains the password, they can't access the account without the second factor.

Single sign-on (SSO) (A) allows users to sign in once and access multiple apps without re-authenticating — it's convenient but doesn't add a second verification factor. RBAC (B) controls permissions and access levels, not authentication factors. Passwordless (D) eliminates the password but may use MFA as part of the passwordless implementation.

---

## Q81. A hospital deploys a VNet, a VM, and a storage account. What is the virtual machine considered in Azure?

- A) Subscription
- B) Resource
- C) Management group
- D) Resource group

**Correct Answer: B**

**Explanation:** A **virtual machine** is an individual **Azure resource** — the fundamental unit managed in Azure. Resources are the actual services and components you create and manage: VMs, storage accounts, VNets, databases, etc. Resources have properties, states, and can be deployed, configured, and monitored individually.

Subscription (A) is a billing and access boundary containing multiple resources. Management group (C) is a governance container organizing subscriptions. Resource group (D) is a logical container that holds multiple related resources — the resource group itself is not a VM.

---

## Q88. Which Azure service helps plan and assess server migrations to Azure?

- A) Azure Data Box
- B) Azure Migrate
- C) Azure Key Vault
- D) Azure Monitor

**Correct Answer: B**

**Explanation:** **Azure Migrate** is a centralized service for discovering, assessing, and planning migrations of on-premises servers, applications, and databases to Azure. Key capabilities include: **Discovery** — automatically find and inventory on-premises servers and databases. **Assessment** — evaluate Azure readiness, estimate costs, and right-size recommendations (suggest appropriate VM sizes). **Planning** — dependency mapping (identify connections between servers), migration timeline, and deployment recommendations. Azure Migrate supports VMware, Hyper-V, and physical servers, plus SQL Server and web apps.

Azure Data Box (A) is for offline bulk data transfer, not migration assessment. Key Vault (C) manages secrets and certificates. Azure Monitor (D) provides observability for resources already in Azure, not pre-migration assessment.

---
