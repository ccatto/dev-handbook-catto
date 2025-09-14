# Entity Framework Core: Optimistic Concurrency

Optimistic concurrency is a pattern used in **Entity Framework Core** to
handle situations where multiple users attempt to update the same record
at the same time.\
Instead of locking records, EF Core detects conflicts by checking if the
data has changed since it was last read.

------------------------------------------------------------------------

## How It Works

1.  A record is read from the database.
2.  The record is modified by multiple users/processes.
3.  When a user saves changes, EF Core compares the **original values**
    with the **current database values**.
4.  If a difference is detected (i.e., someone else modified the record
    in the meantime), a **`DbUpdateConcurrencyException`** is thrown.

This ensures data consistency without requiring pessimistic locks.

------------------------------------------------------------------------

## Example: Player Entity with Concurrency Token

``` csharp
public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Example field that may be updated frequently
    public int Score { get; set; }

    // Concurrency token
    [Timestamp]
    public byte[] RowVersion { get; set; }
}
```

-   The `RowVersion` property is a **timestamp/rowversion column** in
    SQL Server.
-   EF Core automatically uses it to detect concurrency conflicts.

------------------------------------------------------------------------

## Configuring in `DbContext`

``` csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Player>() 
        .Property(p => p.RowVersion)
        .IsRowVersion()
        .IsConcurrencyToken();
}
```

------------------------------------------------------------------------

## Handling Concurrency in Code

``` csharp
using (var context = new AppDbContext())
{
    var player = await context.Players.FindAsync(1);
    player.Score += 10;

    try
    {
        await context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException ex)
    {
        // Conflict detected
        var entry = ex.Entries.Single();
        var clientValues = (Player)entry.Entity;

        // Refresh from database
        var databaseEntry = await entry.GetDatabaseValuesAsync();
        if (databaseEntry == null)
        {
            Console.WriteLine("The record was deleted by another user.");
        }
        else
        {
            var databaseValues = (Player)databaseEntry.ToObject();

            Console.WriteLine("Concurrency conflict detected!");
            Console.WriteLine($"Client Score: {clientValues.Score}");
            Console.WriteLine($"Database Score: {databaseValues.Score}");

            // Option 1: Overwrite database values
            entry.OriginalValues.SetValues(databaseEntry);

            // Option 2: Merge changes or prompt user
        }
    }
}
```

------------------------------------------------------------------------

## Strategies for Resolving Conflicts

1.  **Client Wins** (overwrite database values with client values).\
    Useful when the client's changes should always be prioritized.

2.  **Database Wins** (discard client changes and reload).\
    Useful when the latest database state should always be kept.

3.  **Merge** (combine client and database changes).\
    Useful for fields that can be merged logically (e.g., scores or
    comments).

------------------------------------------------------------------------

## Example Conflict Resolution

``` csharp
catch (DbUpdateConcurrencyException ex)
{
    foreach (var entry in ex.Entries)
    {
        if (entry.Entity is Player)
        {
            var proposedValues = entry.CurrentValues;
            var databaseValues = entry.GetDatabaseValues();

            foreach (var property in proposedValues.Properties)
            {
                var proposedValue = proposedValues[property];
                var databaseValue = databaseValues[property];

                // Example: prefer database value for score
                if (property.Name == "Score")
                {
                    proposedValues[property] = databaseValue;
                }
            }

            // Update original values
            entry.OriginalValues.SetValues(databaseValues);
        }
    }

    await context.SaveChangesAsync();
}
```

------------------------------------------------------------------------

## When to Use Optimistic Concurrency

-   High-read, low-write systems (e.g., project/task management apps,
    sports scheduling apps).
-   Environments where **locking rows would cause performance
    bottlenecks**.
-   Scenarios where **merging updates is possible and desirable**.

------------------------------------------------------------------------

## Summary

Optimistic concurrency in EF Core provides a non-blocking way to manage
concurrent updates.\
By leveraging **concurrency tokens** like `RowVersion`, you can safely
handle conflicts while keeping your application scalable and performant.
