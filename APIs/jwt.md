# 🔑 JSON Web Token (JWT)

## What is JWT?

A JSON Web Token (JWT) is a compact, URL-safe token used for securely transmitting information between parties as a JSON object. It is widely used for authentication and authorization in web applications and APIs.

## Why JWT is Popular

* **Stateless** – no server-side session storage is required; all information is contained in the token.
* **Compact & Portable** – small in size, easy to send in HTTP headers, URLs, or cookies.
* **Self-contained** – includes claims such as user ID, roles, and expiration, allowing the server to validate requests without extra lookups.
* **Cross-platform** – works across different languages and frameworks.

## Common Use Cases

* **API Authentication** – sending JWT in the `Authorization` header as a Bearer token.
* **Single Sign-On (SSO)** – JWTs are perfect for sharing auth across multiple services or domains.
* **Information Exchange** – securely transmitting claims between services without storing sessions.

## JWT Structure

A JWT consists of **3 Base64URL-encoded parts** separated by periods (`.`):

1. **Header** – specifies the algorithm and token type.
2. **Payload** – contains claims (e.g., user info, roles, expiration).
3. **Signature** – ensures the token has not been tampered with.

### Example Signature Calculation

```text
HMACSHA256(
  base64UrlEncode(header) + "." + base64UrlEncode(payload),
  secret_key
)
```

When the server receives a JWT, it recomputes the signature and compares it with the received signature. A mismatch indicates tampering.

## Best Practices

* **Use HTTPS** to prevent token interception.
* **Set Expiration** to reduce risk of stolen tokens.
* **Validate Tokens Properly** on every request.
* **Avoid storing sensitive info** in the payload, as it can be decoded by anyone with the token.

> JWT provides a simple yet powerful way to manage stateless authentication and secure information exchange, making it a cornerstone in modern web development.
