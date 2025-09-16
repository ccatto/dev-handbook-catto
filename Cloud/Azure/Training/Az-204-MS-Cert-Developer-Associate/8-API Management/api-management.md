# 8. Implement API Management

# Explore API Management  
**Module**  
0 of 10 units completed  

Learn how the API Management service functions, how to transform and secure APIs, and how to create a backend API.  

## Units  
- Introduction  
- Discover the API Management service  
- Explore API gateways  
- Explore API Management policies  
- Create advanced policies  
- Secure APIs by using subscriptions  
- Secure APIs by using certificates  
- Exercise - Import and configure an API with Azure API Management  
- Module assessment  
- Summary  

---

> 🚀 Introduction  

API Management helps organizations publish APIs to external, partner, and internal developers to unlock the potential of their data and services.  

---

## 🎯 Learning Outcomes  

After completing this module, you'll be able to:  

- 🧩 **Describe** the components, and their function, of the API Management service.  
- 🌉 **Explain** how API gateways can help manage calls to your APIs.  
- 🔐 **Secure** access to APIs by using subscriptions and certificates.  
- ⚙️ **Import** and configure an API.  

---

> 🌐 Discover the API Management Service  

API Management supports API programs with **developer engagement, analytics, security, and protection**.  

---

## 🧩 Components  

- **🔀 API Gateway** – Routes calls, verifies keys, enforces limits, transforms/caches responses, emits logs.  
- **⚙️ Management Plane** – Configure settings, import APIs, package products, apply policies, analyze usage.  
- **📖 Developer Portal** – Auto docs, test APIs, manage keys, subscribe, view usage.  

---

## 📦 Products  
- Contain 1+ APIs, with title/description/terms.  
- **Open** (no subscription) or **Protected** (subscription required, auto or admin approved).  

---

## 👥 Groups  
- **Admins** 🛠️ – Manage service, APIs, products.  
- **Developers** 💻 – Authenticated portal users.  
- **Guests** 👀 – Limited, read-only access.  
- Support for **custom/external** groups.  

---

## 👤 Developers  
- User accounts in API Management.  
- Created/invited or self-sign up.  
- Join groups, subscribe to products.  

---

## 📜 Policies  
- Rules on requests/responses (e.g., XML→JSON, rate limiting).  
- Use **expressions** for flexibility.  
- Scope: **global, product, API, or operation**.  

---

> 🔎 Explore API Gateways  

An **API gateway** sits between clients and services, acting as a reverse proxy. It:  
- Routes requests and applies policies  
- Handles auth, SSL termination, and rate limiting  
- Collects telemetry  

Without a gateway:  
- Clients must track multiple endpoints  
- Coupling increases between clients and services  
- Each service must manage security, protocols, and resilience  
- Attack surface is larger  

---

## 🛠️ Gateway Types  
- **☁️ Managed** – Default Azure-hosted gateway; all traffic flows through Azure.  
- **📦 Self-hosted** – Containerized version for hybrid/multicloud; runs near backends but managed from Azure.  

---

> 8.4 ⚖️ Explore API Management Policies  

**Policies** let publishers control API behavior via configuration.  
They run **inside the gateway**, modifying inbound requests, outbound responses, or handling errors.  

---

## 🧩 Key Concepts  
- **Policy definition** – XML document with sections:  
  - `<inbound>` – modifies requests  
  - `<backend>` – before sending to backend  
  - `<outbound>` – modifies responses  
  - `<on-error>` – handles errors (inspect `context.LastError`, customize responses)  

- **Policy expressions** – Inline C# code (`@( )` or `@{ }`) using `context` and limited .NET types.  
  - Example: set headers, filter responses, dynamic transformations.  

- **Scopes** – Policies can apply at **global, product, API, or operation** level.  
  - Ordering controlled with `<base />` to merge broader scopes.  

---

## ✨ Examples  
- Add user/region headers: `<set-header>` with policy expressions.  
- Replace text in requests: `<find-and-replace>`.  
- Filter JSON response properties for certain products.  

---

> 8.5 🛠️ Create Advanced Policies  

Advanced policies in API Management let you **control execution, mock responses, log data, and manage retries**.  

---

## 📜 Key Policies  

- **🔀 Control flow** – Conditional logic (`<choose>`, `<when>`, `<otherwise>`).  
- **➡️ Forward request** – Sends requests to backend (default behavior).  
- **⏳ Limit concurrency** – Restricts concurrent requests; excess returns **429**.  
- **📡 Log to Event Hubs** – Sends request/response info to Event Hubs.  
- **🧪 Mock response** – Skips backend, returns mock/sample response.  
- **🔁 Retry** – Retries child policies until condition met or max retries hit.  
- **📤 Return response** – Stops pipeline, sends default/custom response.  

---

## 📚 Resources  
- [API Management policy reference](https://learn.microsoft.com/azure/api-management/api-management-policies)  
- [Error handling in policies](https://learn.microsoft.com/azure/api-management/api-management-error-handling-policies)  

---

> 8.6 🔐 Secure APIs by Using Subscriptions  

APIs published through API Management are typically secured with **subscription keys**.  
Requests without a valid key are rejected by the gateway.  

---

## 🗝️ Subscriptions & Keys  
- A **subscription** is a container for a pair of autogenerated keys (primary & secondary).  
- Keys can be:  
  - 🔑 Sent in **headers** (`Ocp-Apim-Subscription-Key`)  ‼️
  - 🔑 Sent in **query string** (`subscription-key`)  
- Subscriptions can be scoped to:  
  - **All APIs**  
  - **Single API**  
  - **Product** (collection of APIs, with quotas & rules)  
- Keys can be regenerated anytime for security.  

---

## 📦 Workflow  
1. Developer requests a subscription.  
2. Publisher approves (if required) and securely shares the key.  
3. Application includes the key in **every request**.  
4. If no key is provided → **401 Access Denied**.  

---

## 🔒 Other Security Options  
- OAuth 2.0  
- Client certificates  
- IP allow listing  


---

> 8.7 🔐 Secure APIs by Using Certificates  

API Management supports **TLS mutual authentication** to secure APIs with **client certificates**.  
The gateway only accepts requests with valid certificates, checked via inbound policies.  

---

## 🧾 Key Certificate Properties  
- **CA** – Must be signed by trusted authority  
- **Thumbprint** – Unique hash to verify certificate integrity  
- **Subject** – Must match expected subject name  
- **Expiration Date** – Reject expired certificates  

---

## ⚙️ How It Works  
1. Client sends request with certificate.  
2. Gateway validates against configured rules (CA, thumbprint, issuer, etc.).  
3. Invalid or missing certificates → **403 Forbidden**.  

---

## 📦 Tiers  
- **Consumption tier** – Must explicitly enable client certificates.  
- Other tiers – Certificates supported by default.  

---

## 🛠️ Policy Examples  
- ✅ Check thumbprint  
- ✅ Validate against uploaded certificates in API Management  
- ✅ Verify issuer & subject  

---

> 8.8 🧪 Exercise – Import and Configure an API with Azure API Management  

In this exercise, you:  

1. 🏗️ **Create** an Azure API Management (APIM) instance  
2. 📥 **Import** an API (OpenAPI specification)  
3. ⚙️ **Configure** backend settings (web service URL, subscription rules)  
4. 🧾 **Test** API operations to confirm functionality  

[Import and configure an API with Azure API Management](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-api-mgmt/01-api-mgmt-import-api.html)

---

> 8.9 📝 Quiz – API Management Basics  

1. Which API Management component would a developer use to create an account and subscribe to get API keys?  
   - API gateway  
   - Azure portal  
   - ✅ Developer portal  

---

2. Which API Management policy applies a policy based on a condition?  
   - forward-request  
   - ✅ choose  
   - return-response  


---

> 8.10 📘 Module Summary – API Management  

✅ **Components** – Understand the parts of the API Management service and their roles.  
✅ **API Gateways** – See how gateways manage and route API calls.  
✅ **Security** – Learn to protect APIs with subscriptions and certificates.  
✅ **Configuration** – Import and set up APIs for use.  


> 👢 footer HA