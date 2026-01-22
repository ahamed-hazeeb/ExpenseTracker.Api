# ExpenseTracker API

This is a simple Expense Tracker API built using **ASP.NET Core 8**, **Entity Framework Core**, and **SQL Server**.  
It supports CRUD operations for **Users**, **Categories**, and **Expenses**.

The project follows a clean structure using **DTOs**, **Service Layer**, and **Swagger** for API documentation.

---

## 🧱 Features

- CRUD for Users
- CRUD for Categories
- CRUD for Expenses
- Expense belongs to a User and a Category
- Uses DTOs for data validation and response shaping
- Clean architecture with Service layer
- Swagger/OpenAPI documentation

---


## 🧾 Database Schema

### Users Table
| Column | Type | Notes |
|--------|------|------|
| Id | int | Primary Key |
| Name | nvarchar(100) | Required |
| Email | nvarchar(100) | Required |

### Categories Table
| Column | Type | Notes |
|--------|------|------|
| Id | int | Primary Key |
| Name | nvarchar(100) | Required |

### Expenses Table
| Column | Type | Notes |
|--------|------|------|
| Id | int | Primary Key |
| Titel | nvarchar(200) | Required |
| Amount | decimal(18,2) | Required |
| Date | datetime2 | Required |
| UserId | int | Foreign Key (Users) |
| CategoryID | int | Foreign Key (Categories) |

---

## ⚙️ Setup Instructions

### 1. Install Dependencies
Make sure you have the following installed:

- .NET 8 SDK
- SQL Server


🧪 API Endpoints
Users
| Method | URL              | Description     |
| ------ | ---------------- | --------------- |
| GET    | `/api/user`      | Get all users   |
| POST   | `/api/user`      | Create new user |
| PUT    | `/api/user/{id}` | Update user     |
| DELETE | `/api/user/{id}` | Delete user     |

Categories
| Method | URL                  | Description        |
| ------ | -------------------- | ------------------ |
| GET    | `/api/category`      | Get all categories |
| POST   | `/api/category`      | Create category    |
| PUT    | `/api/category/{id}` | Update category    |
| DELETE | `/api/category/{id}` | Delete category    |

Expenses
| Method | URL                          | Description          |
| ------ | ---------------------------- | -------------------- |
| GET    | `/api/expense/user/{userId}` | Get expenses by user |
| POST   | `/api/expense`               | Create expense       |
| PUT    | `/api/expense/{id}`          | Update expense       |
| DELETE | `/api/expense/{id}`          | Delete expense       |
