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

# 📘 Frontend Technical Documentation

## 1. Overview
This frontend implements a **Book CRUD application** with responsive design and styled UI components. It is built using **Vue 3** with Composition API and scoped CSS for maintainable, modular design.

Key features:
- Sidebar navigation
- Book list rendering with sample data
- Create, search, and filter functionality
- Responsive layouts for mobile and desktop

---

## 2. Tech Stack
- **Framework**: Vue 3 (Composition API)
- **Language**: JavaScript (ES6+)
- **Styling**: Scoped CSS, responsive media queries
- **Build Tool**: Vite
- **Server Config**: Exposed on `0.0.0.0`, port `5173`

---

## 3. Setup Instructions
```bash
# Install dependencies
npm install

# Run development server
npm run dev

# Build for production
npm run build
```

---

## 4. Project Structure
```
src/
 ├─ components/
 │   ├─ BookList.vue       # Renders list of books
 │   └─ Sidebar.vue        # Navigation sidebar
 ├─ assets/                # Images, icons
 ├─ styles/                # Global CSS
 ├─ App.vue                # Root component
 └─ main.js                # Entry point
```

## 5. Components

### BookItem.vue
- **Props**: `id`, `name`, `author`, `cover`, `status`, `createdAt`
- **Usage**: Displays book details with responsive layout.

### BookList.vue
- **Props**: `books` (array of book objects)
- **Usage**: Renders list of `BookItem` components.

### Sidebar.vue
- Provides navigation and quick access to CRUD actions.

---

## 6. Styling Guidelines
- **Create Button**: Blue background, white text, rounded corners.
- **Search Input**: Purple border, deep purple text, focus glow, styled placeholder.
- **Search Button**: Dark blue background, bold white text.
- **Filters**: Light gray pills with hover/focus states.
- **Genre Select**: Custom dropdown with SVG arrow.
- **List Container**: Scrollable on mobile, responsive flex layout on desktop.
- **Base Theme**: White background, black font.
---

## 🔧 Responsive Design Enhancements

### Mobile (≤600px)
- **Search Input**:  
  - Takes full width (`width: 100%`) for easy typing.  
  - Search button hidden or stacked below for simplicity.  
- **Filters**:  
  - Display as stacked pills with `flex-wrap: wrap` and `gap` for neat spacing.  
  - Ensure touch-friendly padding and larger tap targets.
  - 
## 8. Development Standards
- **Commit Messages**: Follow [Conventional Commits](https://www.conventionalcommits.org/):
  - `feat`: new features
  - `style`: CSS changes
  - `chore`: config updates
- **Branch Naming**: `feature/<task>` (e.g., `feature/book-crud-page`)

---

## 9. Future Improvements
- Integrate with backend API for real CRUD operations.
- Add unit tests for components.
- Improve accessibility (ARIA attributes, keyboard navigation).
- Enhance documentation with screenshots and usage examples.

---

## 10. UI

i. Desktop View
<img width="1890" height="883" alt="image" src="https://github.com/user-attachments/assets/28108c12-4b74-4455-a9d0-bb000d256389" />

ii. Mobile View

<img width="282" height="561" alt="image" src="https://github.com/user-attachments/assets/6c1f9b08-f01d-46f4-a6c9-2ee6bc713478" />
<img width="283" height="555" alt="image" src="https://github.com/user-attachments/assets/80a0fce9-d44e-4891-aae6-b2ff83e73d67" />
<img width="287" height="549" alt="image" src="https://github.com/user-attachments/assets/88c5f4c8-fccc-44c2-b70f-3566ae7e4135" />

**Author:** Agaesh
**Created:** 22 February 2026
