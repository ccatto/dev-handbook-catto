## 📌 Implement authentication by using the Microsoft Authentication Library  
**Module**  
0 of 6 units completed  

Learn how to implement authentication by using the Microsoft Authentication Library.  

### Units  
- Introduction  
- Explore the Microsoft Authentication Library  
- Initialize client applications  
- Exercise - Implement interactive authentication with MSAL.NET  
- Module assessment  
- Summary  

---

> 6.2.1  🚀 Introduction

The **Microsoft Authentication Library (MSAL)** enables developers to acquire tokens from the Microsoft identity platform to authenticate users and access secured web APIs.  

After completing this module, you'll be able to:

- Explain the benefits of using **MSAL** and the application types and scenarios it supports  
- Instantiate both **public** and **confidential client apps** from code  
- Register an app with the **Microsoft identity platform**  
- Create an app that retrieves a token with the **MSAL.NET SDK**  

---

> 6.2.2 🔑 Explore the Microsoft Authentication Library (MSAL)

The **Microsoft Authentication Library (MSAL)** helps developers acquire tokens from the Microsoft identity platform to authenticate users and securely access APIs, including Microsoft Graph, Microsoft services, third-party APIs, and custom web APIs.  

---

## 🚀 Benefits of MSAL
- No need to directly use OAuth libraries or handle protocol details  
- Supports both **user** and **app-only** authentication  
- Built-in **token cache** with automatic refresh  
- Easy configuration through files  
- Supports multiple audiences and app scenarios  
- Provides **logging, telemetry, and actionable exceptions** for troubleshooting  

---

## 📱 Application Types
MSAL supports many platforms and frameworks, including:  
- **.NET / .NET MAUI / Xamarin / UWP / WinUI**  
- **JavaScript/TypeScript** (React, Angular, Vue, etc.)  
- **Java, Python, Go (Preview)**  
- **iOS, macOS, Android**  
- **Node.js** (Express, Electron)  

---

## 🔐 Authentication Flows
| Flow | Purpose | App Types |
|------|----------|-----------|
| **Authorization Code** | User sign-in + access to APIs | Desktop, Mobile, SPA (with PKCE), Web |
| **Client Credentials** | Server-to-server/API-to-API | Daemon apps |
| **Device Code** | User sign-in on limited-input devices (TVs, IoT, CLI) | Desktop, Mobile |
| **Implicit Grant** ⚠️ Deprecated | User sign-in (use Auth Code w/ PKCE) | SPA, Web |
| **On-Behalf-Of (OBO)** | API calling downstream API on user’s behalf | Web API |
| **ROPC (Username/Password)** ⚠️ Not recommended | Direct user sign-in with password | Desktop, Mobile |
| **Integrated Windows Auth (IWA)** | Silent token acquisition on domain-joined devices | Desktop, Mobile |

---

## 🖥️ Public vs. Confidential Clients
- **Public Clients**: Run on devices (desktop, mobile, client-side apps). Cannot store secrets. Authenticate **on behalf of users only**.  
- **Confidential Clients**: Run on servers (web apps, APIs, daemons). Can store secrets securely. Authenticate **on behalf of apps or users**.  

---

## 📌 One-Sentence Summary
**MSAL provides a unified, secure way to authenticate users and apps across platforms, manage tokens automatically, and support diverse authentication flows for modern applications.**

---

> 6.2.3 ✅ Initialize Client Applications

MSAL.NET 3.x provides application builders — **PublicClientApplicationBuilder** and **ConfidentialClientApplicationBuilder** — to configure and initialize applications via code, configuration files, or both.  

### Key Points
- **App registration required**: Gather details such as  
  - Application (client) ID  
  - Directory (tenant) ID  
  - Authority (identity provider URL + sign-in audience)  
  - Client credentials (secret or certificate)  
  - Redirect URI (for web/public client apps)  

- **Initialization examples**:  
  - Public client app:  
    ```csharp
    IPublicClientApplication app = PublicClientApplicationBuilder.Create(clientId).Build();
    ```
  - Confidential client app:  
    ```csharp
    IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId)
        .WithClientSecret(clientSecret)
        .WithRedirectUri("https://myapp.azurewebsites.net")
        .Build();
    ```

- **Builder modifiers**:  
  - `.WithAuthority()` – set authority (Azure Cloud, tenant, or custom URI)  
  - `.WithRedirectUri()` – override default redirect URI  
  - `.WithTenantId()` – override tenant ID  
  - `.WithClientId()` – override client ID  
  - `.WithComponent()`, `.WithLogging()`, `.WithTelemetry()` – debugging and telemetry options  

- **Confidential client–specific modifiers**:  
  - `.WithCertificate(X509Certificate2)`  
  - `.WithClientSecret(string)`  
  - *(mutually exclusive; using both throws an exception)*  

---

**➡️ In short:** MSAL.NET builders simplify initializing client apps with flexible configuration and modifiers for both public and confidential scenarios.  


---

> 6.2.4 📝 Exercise - Implement Interactive Authentication with MSAL.NET

In this exercise, you’ll register an app in **Microsoft Entra ID**, then build a **.NET console application** that uses **MSAL.NET** for interactive authentication and token acquisition.

---

## 🚀 What You’ll Do
- Register an application with the **Microsoft identity platform**  
- Create a **.NET console app** using `PublicClientApplicationBuilder` to configure authentication  
- Acquire a token **interactively** with the `user.read` Microsoft Graph permission  

---

## 🔑 Key Learnings
- How to configure **authentication scopes**  
- How to handle **user consent**  
- How **token caching** works across app runs  

---

## 📌 One-Sentence Summary
**You’ll build a .NET console app with MSAL.NET that performs interactive authentication, handles consent, and retrieves cached tokens for Microsoft Graph.**

[Implement interactive authentication with MSAL.NET](https://microsoftlearning.github.io/mslearn-azure-developer/instructions/azure-app-auth/01-msal-interactive-auth.html)

---

> 6.2.5 📝 MSAL Quiz

1. Which of the following MSAL libraries supports single-page web apps?  
- MSAL Node  
- ✅ MSAL.js  
- MSAL.NET  

---

2. What is the purpose of using `PublicClientApplicationBuilder` class in MSAL.NET?  
- The class creates a new Azure account.  
- ✅ To configure and instantiate a public client application that can acquire tokens and authenticate users against the Microsoft identity platform.  
- Adds a new API permission to the registered app.  

---

> 6.2.6 ✅ Module Summary

In this module, you learned how to:  

- Explain the benefits of using MSAL and the application types and scenarios it supports  
- Instantiate both public and confidential client apps from code  
- Register an app with the Microsoft identity platform  
- Create an app that retrieves a token with the MSAL.NET SDK  


--- 🩰 ---
