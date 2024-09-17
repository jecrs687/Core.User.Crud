# User Management API Specification

## Overview

This API provides RESTful CRUD (Create, Read, Update, Delete) functionality for managing users. It exposes a single endpoint that handles all the operations related to users.

---

## Endpoints

### POST `/API/users`

Creates a new user.

### GET `/API/users`

Retrieves a list of users.

### GET `/API/users/{id}`

Retrieves details of a specific user by their ID.

### DELETE `/API/users/{id}`

Deletes a specific user by their ID.

### PUT `/API/users/{id}`

Updates the information of a specific user by their ID.

---

## User Fields

| Field Name   | Data Type | Required | Validation                                   |
|--------------|-----------|----------|----------------------------------------------|
| FirstName    | `string`  | Required | Max length: 128 characters                   |
| LastName     | `string`  | Optional | Max length: 128 characters                   |
| Email        | `string`  | Required | Must be a valid email address                |
| DateOfBirth  | `DateTime`| Required | Must be a valid date                         |

- **Email**: Every user must have a unique email address.
- **Date of Birth**: The user must be 18 years or older at the time of account creation.

---

## Validation Rules

1. **Unique Email**: No two users can share the same email address.
2. **Age Requirement**: When creating a user, they must be at least 18 years old.
3. **User Details Return**:
    - When fetching user data (either for a single user or a list of users), include both the **age** of the user and their **date of birth** in the response.

---

## Example Responses

### User Object Example:
```json
{
    "id": 1,
    "firstName": "John",
    "lastName": "Doe",
    "email": "john.doe@example.com",
    "dateOfBirth": "1990-04-15",
    "age": 34
}
```

### Error Response Example:
```json
{
    "error": "User not found",
    "stackTrace": "..."
}
```
or
```json
{
    "error": "Invalid email address",
}
```

## Project Structure

### API
The API layer is responsible for handling incoming requests and routing them to the appropriate application logic. It contains the following key folders:

- **Controllers**: Responsible for managing the logic for handling incoming requests.
- **Extensions**: Contains extension methods that enhance the functionality of various classes.
- **Filters**: Manages filters for request validation and exception handling.

### Application
The Application layer manages the core business logic of the application. Each folder within this layer represents a distinct domain of the application. For instance, the `User` folder handles all logic related to user management.

Each folder in this layer contains the following subfolders:
- **Commands**: Contains classes responsible for executing business logic.
- **Contracts**: Defines interfaces for the services used within the application.
- **Params**: Includes parameters for methods within controllers.
- **QueryParams**: Holds query parameter definitions for controller methods.
- **Requests**: Manages body classes and their validations used by controllers.
- **Services**: Contains service classes responsible for executing business logic.

### Domain
The Domain layer encapsulates the core entities, factories and small logics of the application, with the following structure:
- **Configs**: Stores application configuration files.
- **Entities**: Contains the core entity classes that represent the application's data.
- **Exceptions**: Defines custom exceptions used within the application.
- **Factory**: Manages factory classes responsible for creating objects.
- **Repositories**: Provides interfaces for repository classes that interact with the database.
- **Services**: Contains service classes that handle domain-specific business logic.
- **Models**: Defines the data models for the application.
- **Utils**: Contains utility classes that assist in various operations across the application.

### Infra
The Infra (Infrastructure) layer deals with external or internal components of the application. While the only implemented folder in this project is `Repositories`, additional folders such as `Databases`, `Caches`, `Queues`, `Storages`, and `ExternalServices` can be added to manage various infrastructure concerns.

Current subfolders include:
- **Repositories**: Contains the classes for managing database interactions.