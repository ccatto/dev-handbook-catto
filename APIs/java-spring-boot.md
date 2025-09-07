# Java Spring Boot API

# Java Spring Boot - Developer Handbook (APIs)

**Spring Boot** is a **Java-based framework** built on top of the Spring ecosystem that simplifies **building production-ready applications**, especially **RESTful APIs**. It provides **convention over configuration**, embedded servers, and powerful integration with databases, messaging, and cloud services.

---

## Why Spring Boot is Important

- Simplifies **Spring configuration** with auto-configuration and sensible defaults.  
- Enables **rapid development of APIs and microservices**.  
- Supports **embedded servers** (Tomcat, Jetty, Undertow) for standalone applications.  
- Integrates with **databases, security, caching, and messaging** out-of-the-box.  
- Supports **testing, monitoring, and deployment** in production environments.  

---

## Key Features for APIs

- **Spring Web (Spring MVC)**: Build RESTful services with annotations like `@RestController`, `@GetMapping`, `@PostMapping`.  
- **Dependency Injection**: Built-in support via `@Autowired` for modular and testable code.  
- **Spring Data JPA**: Simplifies database access with repository patterns.  
- **Validation**: Bean validation with `@Valid` and custom validators.  
- **Exception Handling**: Centralized error handling with `@ControllerAdvice`.  
- **Security**: Spring Security for authentication, authorization, and OAuth2 support.  
- **Testing**: Unit and integration testing support via `@SpringBootTest`, MockMvc, JUnit.  

---

## Common Patterns in Spring Boot APIs

- **RESTful API design**: Use `@RestController`, `@RequestMapping`, and proper HTTP verbs.  
- **Service layer pattern**: Separate business logic from controllers.  
- **Repository/DAO pattern**: Encapsulate database access using Spring Data JPA.  
- **DTO pattern**: Use Data Transfer Objects to decouple API responses from database models.  
- **Exception handling**: Centralize using `@ControllerAdvice` and custom exception classes.  

---

## Example: Simple REST API

**Controller:**
```java
@RestController
@RequestMapping("/api/users")
public class UserController {

    private final UserService userService;

    public UserController(UserService userService) {
        this.userService = userService;
    }

    @GetMapping("/{id}")
    public ResponseEntity<UserDto> getUser(@PathVariable Long id) {
        UserDto user = userService.getUserById(id);
        return ResponseEntity.ok(user);
    }

    @PostMapping
    public ResponseEntity<UserDto> createUser(@RequestBody @Valid UserDto userDto) {
        UserDto createdUser = userService.createUser(userDto);
        return ResponseEntity.status(HttpStatus.CREATED).body(createdUser);
    }
}
```

# Spring Boot API Example and Best Practices

## Service Layer
```java
@Service
public class UserService {

    private final UserRepository userRepository;

    public UserService(UserRepository userRepository) {
        this.userRepository = userRepository;
    }

    public UserDto getUserById(Long id) {
        return userRepository.findById(id)
                .map(UserMapper::toDto)
                .orElseThrow(() -> new RuntimeException("User not found"));
    }

    public UserDto createUser(UserDto userDto) {
        User user = UserMapper.toEntity(userDto);
        User saved = userRepository.save(user);
        return UserMapper.toDto(saved);
    }
}
```

### Repository Layer
```java
public interface UserRepository extends JpaRepository<User, Long> {}
```


# Best Practices for Spring Boot APIs

- **Use DTOs**: Separate API layer from internal models to maintain encapsulation and flexibility.
- **Apply Validation**: Validate incoming requests to ensure data integrity.
- **Centralize Exception Handling**: Implement consistent error responses across the application.
- **Implement Service Layer**: Encapsulate business logic in service classes for better organization.
- **Use Spring Profiles**: Manage environment-specific configurations (e.g., dev, prod).
- **Include Tests**: Write unit and integration tests for controllers and services to ensure reliability.
- **Document APIs**: Use OpenAPI/Swagger for clear and accessible API documentation.