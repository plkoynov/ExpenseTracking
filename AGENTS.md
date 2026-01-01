# Agents for Backend Development

## Clean Architecture Overview

The backend is developed using Clean Architecture principles, ensuring loose coupling and separation of concerns among layers:

- **Domain Layer**: Contains core business logic, entities, value objects, and domain events.
- **Persistence Layer**: Handles database interaction (PostgreSQL), repositories, migrations, and model configurations.
- **Application Layer**: Contains application services, DTOs, validators, and contract abstractions.
- **Presentation Layer**: Handles HTTP requests with minimal API, endpoint bindings, and controllers.

### Domain Layer

#### Guidelines:

1. The domain layer should remain free of dependencies on external libraries and frameworks.
2. Use a `BaseEntity` class to provide consistency in entity design.

Example `BaseEntity`:

```csharp
public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedOn { get; set; }

    public void SetUpdatedTime() => UpdatedOn = DateTime.UtcNow;
}
```

---

### Persistence Layer

#### Guidelines:

1. Use repositories and abstractions to manage data access through Entity Framework Core.
2. Ensure database configuration and migration scripts align with PostgreSQL.

Example `IRepository` Interface:

```csharp
public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Remove(T entity);
}
```

Example `BaseRepository` Implementation:

```csharp
public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AppDbContext context;

    public BaseRepository(AppDbContext context)
    {
        this.ontext = context;
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await this.context.Set<T>().FindAsync(id, cancellationToken);

    public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await this.context.Set<T>().ToListAsync(cancellationToken);

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default) =>
        await this.context.Set<T>().AddAsync(entity, cancellationToken);

    public void Update(T entity) =>
        this.context.Set<T>().Update(entity);

    public void Remove(T entity) =>
        this.context.Set<T>().Remove(entity);
}
```

---

### Application Layer

#### Guidelines:

1. Write clean services and use abstractions for persistence logic.
2. Implement the **Unit of Work (UoW)** pattern to handle multiple repository actions in a transactional context.
3. Use DTOs for transferring objects between layers.
4. Implement extension methods for mapping between entities and DTOs.

---

#### Unit of Work Pattern

The Unit of Work ensures that multiple changes across repositories are treated as one cohesive transaction.

Example Unit of Work Interface:

```csharp
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
```

Example Unit of Work Implementation:

```csharp
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;

    public UnitOfWork(DbContext context)
    {
        this.context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await this.context.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
        this.context.Dispose();
        GC.SuppressFinalize(this);
    }
}
```

Example DTOs:

```csharp
public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CreateUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}
```

Example Service with Mapping:

```csharp
public class UserService : IUserService
{
    private readonly IRepository<User> userRepository;
    private readonly IUnitOfWork unitOfWork;

    public UserService(
        IRepository<User> userRepository,
        IUnitOfWork unitOfWork)
    {
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<UserDto?> GetUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await this.userRepository.GetByIdAsync(id, cancellationToken);
        return user?.ToDto();
    }

    public async Task<Guid> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
    {
        var user = createUserDto.ToEntity();
        await this.userRepository.AddAsync(user, cancellationToken);
        await this.unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
```

Example Mapping Extensions:

````csharp
public static class UserExtensions
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public static User ToEntity(this CreateUserDto dto)
    {
        return new User(dto.Name, dto.Email);
    }
}

---

### Presentation Layer

#### Guidelines:

1. Use DTOs to interact with application services and clients.
2. Group endpoints in separate files for better organization.

Example Mapping File:

```csharp
public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users/{id:guid}", async (Guid id, [FromServices] IUserService userService) =>
        {
            var userDto = await userService.GetUserAsync(id);
            return userDto != null ? Results.Ok(userDto) : Results.NotFound();
        });

        app.MapPost("/users", async (CreateUserDto dto, [FromServices] IUserService userService) =>
        {
            var userId = await userService.CreateUserAsync(dto);
            return Results.Created($"/users/{userId}", null);
        });
    }
}
````

# Agents for Frontend Development

## Angular Architecture Overview

The frontend is built using Angular and follows a modular structure to ensure scalability and maintainability.

---

### Project Structure

```
src/
  app/
    core/               (singleton services, interceptors)
    shared/             (reusable components, directives, pipes)
    features/           (feature modules and lazy-loaded modules)
    styles/             (global styles and theme files)
    environments/       (environment-specific configurations)
```

---

### Components

#### Guidelines:

1. Use Angular CLI to generate new components and modules.
2. DTOs received from the backend should be mapped to models in the frontend whenever necessary.

Example Component using DTOs:

```typescript
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-list',
  template: `
    <div *ngFor="let user of users">
      <span>{{ user.name }}</span>
      <button (click)="deleteUser(user.id)">Delete</button>
    </div>
  `,
})
export class UserListComponent {
  @Input() users: UserDto[] = [];
  @Output() userDeleted = new EventEmitter<string>();

  deleteUser(userId: string) {
    this.userDeleted.emit(userId);
  }
}
```

Example User DTO:

```typescript
export interface UserDto {
  id: string;
  name: string;
  email: string;
}
```

---

### Services

#### Guidelines:

1. Handle data transfer between the frontend and backend using DTOs.
2. Map DTOs to ViewModels or UI models when necessary.

Example User Service:

```typescript
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from './user.dto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly apiUrl = '/api/users';

  constructor(private http: HttpClient) {}

  getUsers(): Observable<UserDto[]> {
    return this.http.get<UserDto[]>(this.apiUrl);
  }

  deleteUser(userId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${userId}`);
  }
}
```

---

### State Management

Use `BehaviorSubject` from RxJS for lightweight state management.

Updated State Management Example:

```typescript
import { BehaviorSubject } from 'rxjs';
import { UserDto } from './user.dto';

@Injectable({
  providedIn: 'root',
})
export class UserStateService {
  private readonly users = new BehaviorSubject<UserDto[]>([]);
  users$ = this.users.asObservable();

  setUsers(users: UserDto[]) {
    this.users.next(users);
  }
}
```
