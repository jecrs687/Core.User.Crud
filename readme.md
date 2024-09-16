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