# Implement managed identities

> Learn how managed identities can help you deploy secure solutions on Azure without the need to manage credentials.

## Units
- Introduction  
- Explore managed identities  
- Discover the managed identities authentication flow  
- Configure managed identities  
- Acquire an access token  
- Module assessment  
- Summary  

---

> 🌐 Introduction  

A common challenge for developers is the management of secrets and credentials used to secure communication between different components of a solution. **Managed identities** eliminate the need for developers to handle credentials manually.  

---

## 🎯 Learning Outcomes  
After completing this module, you'll be able to:  

- 🔑 Explain the differences between **system-assigned** and **user-assigned** managed identities  
- 🔄 Describe the authentication flows for both types  
- ⚙️ Configure managed identities in Azure  
- 🔐 Acquire access tokens using **REST** and **code**  

---

> 🔍 Explore Managed Identities   

Managing secrets, credentials, certificates, and keys between services can be complex. **Managed identities** simplify this by providing an automatically managed identity in **Microsoft Entra ID**, allowing applications to authenticate to Azure resources without handling credentials.  

---

## ✨ Key Points  

- 🛡️ **Purpose**: Eliminate credential management by letting apps securely access resources like Azure Key Vault.  
- 🆔 **Types of Managed Identities**:  
  - **System-assigned**: Created with an Azure resource, lifecycle tied to that resource.  
  - **User-assigned**: Standalone resource, can be shared across multiple Azure resources.  
- 🔑 **Use Cases**:  
  - System-assigned → workloads tied to a single resource.  
  - User-assigned → workloads across multiple resources or needing consistent permissions.  
- 🔗 **Support**: Works with any Azure service that supports **Microsoft Entra authentication**.  

---

✨ With managed identities, you get **secure, credential-free authentication** across Azure.  

---

> 🔑 Discover the Managed Identities Authentication Flow  

Managed identities let Azure VMs securely authenticate to resources without storing credentials. Both **system-assigned** and **user-assigned** identities follow a similar flow using **Azure Resource Manager (ARM)**, **Microsoft Entra ID**, and the **Azure Instance Metadata Service**.  

---

## ⚙️ System-assigned Flow  
1. ARM enables the identity on the VM.  
2. ARM creates a **service principal** in Entra ID.  
3. Identity details (client ID + certificate) are stored in the VM’s **metadata service endpoint**.  
4. Roles/permissions are assigned to allow access (e.g., Key Vault, ARM).  
5. VM requests a token from metadata service → Entra ID issues JWT.  
6. App uses token to call Azure services.  

---

## ⚙️ User-assigned Flow  
1. ARM creates a standalone **user-assigned identity** + service principal.  
2. The identity is attached to the VM via metadata service.  
3. Permissions/roles granted to the identity.  
4. VM requests a token from metadata service → Entra ID issues JWT.  
5. Token is used to call Azure services.  

---

✨ **Key Idea**: Both identity types let apps on a VM get tokens via the metadata endpoint, enabling **secure, credential-free authentication** to Azure resources.  

---

> ⚙️ Configure Managed Identities  

You can configure **system-assigned** or **user-assigned** managed identities for Azure VMs either at creation or afterward.  

---

## 🔑 System-assigned  
- Requires **Virtual Machine Contributor** role.  
- Identity is created automatically and tied to the VM lifecycle.  
- Enable at creation: `az vm create --assign-identity`  
- Add to existing VM: `az vm identity assign`  

---

## 👥 User-assigned  
- Requires **VM Contributor** + **Managed Identity Operator** roles.  
- Created as a standalone resource, reusable across multiple VMs.  
- Create identity: `az identity create`  
- Attach at VM creation: `az vm create --assign-identity <IDENTITY>`  
- Attach later: `az vm identity assign --identities <IDENTITY>`  

---

## 📦 SDK Support  
Managed identities are supported across multiple SDKs:  
- **.NET, Java, Node.js, Python, Ruby** → all provide samples for working with VMs and managed identities.  

✨ **Key Idea**: System-assigned identities are simple and tied to one VM, while user-assigned identities are reusable across resources.  

* System-assigned ~= VM
* User-assigned ~= identities across resources;

---

> Acquire an Access Token ✅  

Use **DefaultAzureCredential** to request access tokens with managed identities.  
It tries multiple auth methods automatically: 
- Env → Managed Identity → VS → Azure CLI → PowerShell → Browser.  

### 🔑 Examples
```csharp
// Key Vault with system-assigned identity
var client = new SecretClient(
    new Uri("https://myvault.vault.azure.net/"), 
    new DefaultAzureCredential());

// Blob with user-assigned identity
var cred = new DefaultAzureCredential(
    new DefaultAzureCredentialOptions { ManagedIdentityClientId = "<clientId>" });
var blob = new BlobClient(new Uri("<blobUri>"), cred);

// Custom chain (MI → CLI)
var cred = new ChainedTokenCredential(
    new ManagedIdentityCredential(), new AzureCliCredential());

```
✨ Tip: DefaultAzureCredential works in dev & Azure without code changes.

### 🔑 Managed Identity Token Cheat Sheet
- Use `DefaultAzureCredential` → auto handles Env, MI, VS, CLI, PS, Browser.  
- Works in dev + Azure with no code changes.  
- For user-assigned MI → pass `ManagedIdentityClientId`.  
- Customize flow with `ChainedTokenCredential`.  

---

> 📝 Managed Identities Quiz

1. Which of the following managed identity characteristics is indicative of user-assigned identities?  
   - Shared lifecycle with an Azure resource  
   - ✅ Independent life-cycle  
   - Can only be associated with a single Azure resource  

---

2. A client app requests managed identities for an access token for a given resource. Which of the following options is the basis for the token?  
   - Oauth 2.0  
   - ✅ Service principal  
   - Virtual machine  

---

> 📌 Summary  

In this module, you learned how to:  

- 🔹 Explain the differences between **system- and user-assigned managed identities**  
- 🔹 Describe the **authentication flows** for both identity types  
- 🔹 Configure managed identities on Azure resources  
- 🔹 Acquire **access tokens** using REST and code  

---






