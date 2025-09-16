## 📌 Explore the Microsoft identity platform  

Learn the core features and functionality of the Microsoft identity platform including authentication, libraries, and app management tools.  

### Units  
- Introduction  
- Explore the Microsoft identity platform  
- Explore service principals  
- Discover permissions and consent  
- Discover conditional access  
- Module assessment  
- Summary  

---

> 6.1.2 🔑 Explore the Microsoft Identity Platform  

The Microsoft identity platform enables you to build apps that let users sign in with Microsoft or social identities, and grant secure access to APIs like Microsoft Graph.  

### Key Components  
- **Authentication service** (OAuth 2.0 & OpenID Connect)  
  - Work or school accounts (Microsoft Entra ID)  
  - Personal Microsoft accounts (e.g., Outlook.com, Xbox, Skype)  
  - Social/local accounts (Azure AD B2C, Entra External ID)  
- **Microsoft Authentication Libraries (MSAL)** & standards-compliant libraries  
- **Identity platform endpoint** with human-readable scopes  
- **Application management** via Azure portal  
- **Configuration APIs & PowerShell** for DevOps automation  

### Benefits for Developers  
- Built-in modern security features:  
  - Passwordless authentication  
  - Step-up authentication  
  - Conditional Access  
- No need to build these features manually—apps integrated with the platform benefit automatically.  

---

> 6.1.3 🔐 Explore Service Principals  

- Registering an app in Microsoft Entra ID creates:  
  - **Application object** (global blueprint) → defines tokens, resources, and actions.  
  - **Service principal** (local instance) → represents the app in a tenant with its permissions.  

### Types  
- **Application** → Local app instance in a tenant.  
- **Managed identity** → Auto-created identity for apps to access resources.  
- **Legacy** → Older apps created before modern registrations.  

👉 One application object can have many service principals (one per tenant).  


---
> 6.1.4 🔑 Discover Permissions and Consent  

Applications in the Microsoft identity platform use **OAuth 2.0** to request access to resources (like Microsoft Graph, Outlook, or Key Vault). Access is controlled through **permissions (scopes)** that define what data or actions the app can use.  

### Permission Types  
- **Delegated** → App acts as the signed-in user (requires user/admin consent). ‼️ 
- **App-only** → App runs without a user (background services, daemons; admin consent only).  

### Consent Types  
- **Static consent** → All permissions requested at registration or first sign-in.  
- **Incremental/Dynamic consent** → Request additional permissions over time as needed.  
- **Admin consent** → Required for high-privilege permissions; can apply org-wide.  

### Key Points  
- Permissions are strings like `https://graph.microsoft.com/Calendars.Read`.  
- If no resource identifier is specified, Microsoft Graph is assumed (e.g., `User.Read`).  
- Consent ensures transparency, letting users/admins know exactly what data apps can access.  

---
> 6.1.5 🔐 Discover Conditional Access  

Conditional Access in Microsoft Entra ID helps secure apps and services by enforcing policies like:  
- Multifactor authentication (MFA)  
- Allowing only Intune-enrolled devices  
- Restricting user locations or IP ranges  

### Impact on Apps  
- Most apps require no code changes.  
- Code updates are needed if the app:  
  - Uses **on-behalf-of flow**  
  - Accesses multiple services/resources  
  - Is a **single-page app** (MSAL.js)  
  - Is a web app calling a resource  

### Key Point  
Conditional Access policies may be applied or changed anytime. Apps should handle **claims challenges** (e.g., MFA prompts) to continue working seamlessly.  

---
> 6.1.6 ✅ Quiz: Microsoft Identity Platform & Conditional Access

1. Which of the types of permissions supported by the Microsoft identity platform is used by apps that have a signed-in user present?  
   - ✅ Delegated permissions  
   - App-only access permissions  
   - Both delegated and app-only access permissions  

2. Which of the following app scenarios require code to handle Conditional Access challenges?  
   - Apps performing the device-code flow  
   - ✅ Apps performing the on-behalf-of flow  
   - Apps performing the Integrated Windows authentication flow  

---
> 6.1.7 ## 📝 Summary

In this module, you learned how to:

- Identify the components of the **Microsoft identity platform**  
- Describe the three types of **service principals** and their relationship to application objects  
- Explain how **permissions and user consent** operate  
- Understand how **Conditional Access** impacts your application  

--- 👞 ---
