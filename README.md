# 🎉 EventPulse

> A modern **Event Management & RSVP System** built with **ASP.NET Core Blazor Server**, **C#**, **Entity Framework Core**, and **ASP.NET Identity**.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![C#](https://img.shields.io/badge/C%23-Language-blue)
![Blazor](https://img.shields.io/badge/Blazor-Server-blueviolet)
![Entity Framework Core](https://img.shields.io/badge/EF-Core-green)
![SQLite](https://img.shields.io/badge/Database-SQLite-lightgrey)
![Status](https://img.shields.io/badge/Status-In%20Progress-orange)

---

## 📖 About the Project

EventPulse is a web-based event management system developed as a hands-on learning project while exploring **.NET** and **C#**.

The application allows users to browse events, register for available events, and automatically join a waitlist when an event reaches maximum capacity.

The project also demonstrates authentication, database relationships, CRUD operations, and business logic using modern .NET technologies.

Although the project is still under development, it reflects my learning journey and continues to evolve as I explore more advanced concepts.

---

# ✨ Features

- 👤 User Registration & Login
- 📅 Browse Available Events
- 📄 View Event Details
- ✅ RSVP Registration
- ⏳ Automatic Waitlist Management
- 👨‍💼 Admin Event Management
- 📊 Capacity Tracking
- 🎨 Responsive User Interface

---

# 🛠 Tech Stack

| Technology | Purpose |
|------------|----------|
| C# | Backend Programming |
| .NET 8 | Framework |
| ASP.NET Core Blazor Server | Frontend + Backend |
| Entity Framework Core | ORM |
| ASP.NET Identity | Authentication |
| SQLite | Database |
| Bootstrap | Responsive UI |

---

# 📂 Project Structure

```text
EventPulse
│
├── Components
├── Data
├── Models
├── Services
├── wwwroot
├── Program.cs
└── README.md
```

---

# 🗄 Database Design

## Event

- Id
- Title
- Description
- Date
- MaxCapacity

## RSVP

- Id
- EventId
- UserEmail *(currently)*
- Timestamp
- IsWaitlisted

### Relationship

```
One Event
      │
      ▼
Many RSVPs
```

---

# ⚙ Business Logic

### Registration Flow

```
User

↓

Select Event

↓

Check Capacity

↓

Seats Available?

↓

Yes
↓

Confirmed Registration

OR

No
↓

Automatically Added to Waitlist
```

Only confirmed registrations count toward an event's maximum capacity.

---

# 🚀 Getting Started

## Clone Repository

```bash
git clone https://github.com/habeeba2003/EventPulse.git
```

## Navigate

```bash
cd EventPulse
```

## Restore Packages

```bash
dotnet restore
```

## Apply Database Migrations

```bash
dotnet ef database update
```

## Run the Project

```bash
dotnet run
```

---

# 📚 Learning Outcomes

This project helped me understand:

- Blazor Components
- Entity Framework Core
- LINQ
- CRUD Operations
- Authentication using ASP.NET Identity
- Dependency Injection
- Database Relationships
- Async Programming
- Git & GitHub Workflow

---

# 🚧 Future Improvements

As I continue learning .NET and C#, I plan to improve this project by adding:

- Role-Based Authorization
- User Profile Page
- Enhanced Admin Dashboard
- Search & Filtering
- Pagination
- Email Notifications
- Automatic Waitlist Promotion
- Better Exception Handling
- Unit Testing
- Improved UI/UX

---

# 💡 Why I Built This Project

I am relatively new to **.NET** and **C#**, and I wanted to learn through building a real application instead of only following tutorials.

EventPulse is my learning project, helping me understand how different .NET technologies work together. While it isn't perfect, I continuously improve it as I learn new concepts and best practices.

---

# 👩‍💻 Author

**Habeeba Nisar**

Aspiring Software Engineer passionate about learning **.NET**, **C#**, and modern web development.

GitHub:
https://github.com/habeeba2003

---
