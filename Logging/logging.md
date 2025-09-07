# Logging

# Logging - Developer Handbook

Logging is the **process of recording information about a system’s execution**, errors, and events. Proper logging helps developers **debug, monitor, and maintain applications** effectively.

---

## Why Logging is Important

- **Debugging**: Identify and diagnose issues during development or in production.  
- **Monitoring**: Track application health and performance.  
- **Audit and Compliance**: Record important user actions or system events for regulatory requirements.  
- **Troubleshooting**: Understand system behavior during errors or unexpected scenarios.  
- **Alerting**: Trigger notifications when critical issues occur.

---

## Common Logging Practices

- **Log Levels**: Organize messages by importance.
  - `Trace` / `Verbose` – Detailed information, useful for debugging.  
  - `Debug` – General debugging information.  
  - `Info` – Application flow or routine events.  
  - `Warn` – Potential issues that don’t stop execution.  
  - `Error` – Exceptions or failures requiring attention.  
  - `Fatal` / `Critical` – Application-breaking issues.  

- **Structured Logging**: Use structured formats like JSON for easier parsing and monitoring.  
- **Centralized Logging**: Aggregate logs from multiple servers or services using tools like **ELK Stack, Seq, or Splunk**.  
- **Correlation IDs**: Track requests across distributed systems for better debugging.  

---

## Logging in .NET

**Popular Libraries:**

1. **Microsoft.Extensions.Logging**  
   - Built-in logging in **.NET Core / .NET 5+**.  
   - Supports console, file, and third-party providers.  

2. **Serilog**  
   - Structured logging with **rich sinks** (files, databases, cloud services).  
   - Easy integration with ASP.NET Core and dependency injection.  

3. **NLog**  
   - Highly configurable, supports multiple targets and layouts.  

4. **log4net**  
   - Classic, widely used logging library for **.NET Framework** and .NET Core.  

**Example with Serilog in .NET Core:**
```csharp
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();
app.MapGet("/", () => "Hello Logging!");
app.Run();
```
# Logging in Node.js

## Popular Libraries

- **Winston**  
  - Flexible logging with multiple transports (console, files, databases).  
  - Supports log levels and JSON output.

- **Bunyan**  
  - Structured JSON logging with CLI tools for filtering and formatting.

- **Pino**  
  - Extremely fast JSON logger for Node.js, suitable for production.


### Example with Winston:


```javascript
const winston = require('winston');

const logger = winston.createLogger({
  level: 'info',
  format: winston.format.json(),
  transports: [
    new winston.transports.Console(),
    new winston.transports.File({ filename: 'app.log' })
  ]
});

logger.info('Application started');
logger.warn('This is a warning');
logger.error('Something went wrong');
```

# Logging with Log4js in Node.js

## Log4js
- **Type**: General-purpose logging library  
- **Purpose**: Provides a flexible, Java-inspired logging framework with hierarchical loggers, appenders, and customizable layouts.  
- **Key Features**:  
  - Supports multiple appenders (console, files, SMTP, etc.).  
  - Hierarchical logging with category-based configuration.  
  - Pattern-based log formatting (similar to Log4j).  
  - Clustering support for Node.js cluster environments.  
- **Use Case**: Ideal for enterprise applications, migrations from Java to Node.js, or when complex logging configurations are needed.

## Example Usage
```javascript
const log4js = require('log4js');

log4js.configure({
  appenders: {
    console: { type: 'console' },
    file: { type: 'file', filename: 'app.log' }
  },
  categories: {
    default: { appenders: ['console', 'file'], level: 'info' }
  }
});

const logger = log4js.getLogger();
logger.info('Application started!');
```