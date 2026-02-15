````markdown
# Library Management System - Book API

A simple **Library Management System Web API** built using **.NET Core** and **Entity Framework Core**.  
This project allows basic CRUD operations for managing books in a library.

---

## Book Example JSON

```json
{
    "id": 2,
    "title": "Java",
    "description": "Object Oriented Programming in JAVA",
    "author": "Agaesh",
    "created": "2026-02-14T11:57:42.3311113Z",
    "updated": "2026-02-14T11:57:42.3311117Z"
}
````

---

## Technology Stack

* **Backend:** .NET Core 6+
* **ORM / Database:** Entity Framework Core (Code First)
* **Database:** SQLite / SQL Server (configurable in `appsettings.json`)
* **Validation:** EF Core validation messages for required fields and constraints

---

## Features

* Add, retrieve, update, and delete books
* EF Core validations (e.g., required fields, max length)
* OOP-based Book entity modeling

---

## API Endpoints

1. Books

| Method | Endpoint          | Description             |
| ------ | ----------------- | ----------------------- |
| GET    | `/books`      | Get all books           |
| GET    | `/books/{id}` | Get a single book by ID |
| POST   | `/books`      | Create a new book       |
| PUT    | `/books/{id}` | Update an existing book |
| DELETE | `/books/{id}` | Delete a book by ID     |

---

2. # 👤 Users API – Endpoint Table

| Method | Endpoint      | Description          | Request Body     | Success Response           | Error Response                 |
| ------ | ------------- | -------------------- | ---------------- | -------------------------- | ------------------------------ |
| GET    | `/Users`      | Get all users        | None             | 200 OK – List of users     | —                              |
| GET    | `/Users/{id}` | Get user by ID       | None             | 200 OK – User object       | 404 Not Found                  |
| POST   | `/Users`      | Create new user      | User JSON object | 201 Created – Created user | 400 Bad Request                |
| PUT    | `/Users/{id}` | Update existing user | User JSON object | 204 No Content             | 400 Bad Request, 404 Not Found |
| DELETE | `/Users/{id}` | Delete user          | None             | 204 No Content             | 404 Not Found                  |

---

# 📄 Example User JSON Structure

```json
{
  "id": 1,
  "name": "Agaesh",
  "email": "agaesh@example.com",
  "role": "MEMBER",
  "createdDate": "2026-02-19T10:00:00Z"
}
```

---



# 🔎 Response Codes Summary

| Code | Meaning                                     |
| ---- | ------------------------------------------- |
| 200  | Request successful                          |
| 201  | Resource created                            |
| 204  | Successfully processed, no content returned |
| 400  | Invalid request                             |
| 404  | Resource not found                          |

---

## Running the Project

1. Clone the repository:

```bash
git clone https://github.com/agaesh/library.git
cd library
```

2. Build the project:

```bash
dotnet build
```

3. Run the project:

```bash
dotnet run
```

4. The API will be available at: `http://localhost:5164`

5. Use tools like **Postman** or **Swagger** to test the endpoints.

---

## Example Request

**Create a new Book:**

```http
POST /api/books
Content-Type: application/json

{
    "title": "C# Fundamentals",
    "description": "Learn C# programming basics",
    "author": "Agaesh"
}
```

**Response:**

```json
{
    "id": 3,
    "title": "C# Fundamentals",
    "description": "Learn C# programming basics",
    "author": "Agaesh",
    "created": "2026-02-14T12:05:00Z",
    "updated": "2026-02-14T12:05:00Z"
}
```

---

## EF Core Validation Messages

* `Title` is required
* `Description` is required
* `Author` is required
* Max length validations applied where necessary

---

## Notes

* This project is implemented as a **junior-level CRUD system** using .NET Core Web API and EF Core
* Can be extended to full Library Management System with Members, Borrowing, etc.
* Follows **Object-Oriented Programming (OOP)** principles for entity modeling

---

**Author:** Agaesh
**Created:** 14 February 2026

```
