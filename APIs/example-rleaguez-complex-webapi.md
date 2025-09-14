# RLeaguez Complex Web API Example

Here is a complex Web API that I built for **RLeaguez**, a sports
scheduling app.\
Because it was not just basic CRUD, it had several layers of complexity
that made it robust and scalable.

## Core Functionality

-   **Scheduling Engine**\
    Teams could create, join, and manage leagues and tournaments.\
    The API enforced business rules, such as preventing overlapping
    games, enforcing minimum rest times between matches, and handling
    playoff brackets dynamically.

-   **Role-Based Access Control**\
    Different user roles (admin, coach, player, spectator) had different
    permissions.\
    For example, only admins could reschedule games, while players could
    only update their availability.

-   **Workflow & State Management**\
    Matches progressed through states (*Scheduled → In Progress →
    Completed → Verified*).\
    Transitions were validated in the API layer using a **state machine
    pattern**, ensuring integrity and preventing invalid updates.

## Technical Highlights

-   **CQRS + MediatR** to separate read and write operations for clarity
    and maintainability.
-   **Entity Framework Core with optimistic concurrency** to handle
    simultaneous updates (e.g., multiple coaches updating rosters at
    once).
-   **SignalR for real-time notifications** (score updates, schedule
    changes, tournament progress).
-   **Integration with external services** like Telnyx for SMS
    notifications and third-party calendar sync.
-   **Redis caching** for frequently accessed data such as league
    standings and team rosters.
-   **Background workers** for sending reminders before games and
    processing score validations asynchronously.
-   **Unit + Integration tests** for workflow rules to ensure accuracy
    and reliability.

## Why It Was Complex

This API stood out because it wasn't just about CRUD operations.\
It included:

-   Complex **state transitions** for matches and tournaments\
-   **Role-specific rules** for users\
-   **Event-driven updates** with SignalR and background workers\
-   **Third-party integrations** for notifications and scheduling\
-   A **scalable architecture** designed for thousands of concurrent
    sports participants
