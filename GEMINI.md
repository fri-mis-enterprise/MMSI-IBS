# GEMINI.md - Project Overview & Reference

## 🚀 Project Overview
**Name:** Integrated Business System (IBSWeb)
**Description:** A robust web-based Accounting and Business Management system built with ASP.NET Core. The system is architected to manage complex financial and operational workflows, now unified under the **MMSI** entity.

---

## 🛠️ Technology Stack
- **Framework:** ASP.NET Core 10.0 (C#)
- **Database:** PostgreSQL (via Npgsql and Entity Framework Core)
- **UI:** Razor Pages / MVC, JavaScript, jQuery, DataTables.net
- **Real-time:** SignalR (NotificationHub)
- **Logging:** Serilog
- **PDF Generation:** QuestPDF
- **Cloud Integration:** Google Cloud Storage (GCS), Google Drive API
- **Caching:** MemoryCache
- **Security:** ASP.NET Core Identity, Role-Based Access Control (RBAC)

---

## 🏗️ Architecture & Project Structure
The solution follows an N-Tier / Layered architecture, recently refactored for a unified entity structure:

- **`IBSWeb`**: The main web application. Most business logic and views are now consolidated into the `User` area for a streamlined experience.
- **`IBS.DataAccess`**: Data access layer. Repositories are organized by functional groups:
  - `MasterFile`: Core entities (Customers, Suppliers, Employees, etc.)
  - `Integrated`: Logistics and operational entities (ATL, COS, DR, etc.)
  - `Books`: Accounting books and inventory reports.
  - `MMSI`: Maritime-specific operations (Billing, Collections, MSAP).
- **`IBS.Models`**: Domain entities. Many models previously prefixed with `Filpride` have been renamed and moved to shared folders.
- **`IBS.DTOs`**: Data Transfer Objects for cross-layer communication.
- **`IBS.Services`**: Business logic services (e.g., `CloudStorageService`, `MonthlyClosureService`, `SubAccountResolver`).
- **`IBS.Utility`**: Common helpers, constants, and extensions.

### Key Directories in `IBSWeb`
- `/Areas/Admin`: Administrative tasks (User management, etc.)
- `/Areas/User`: Unified area containing most Controllers and Views for both Accounting/Logistics and Maritime operations.
- `/wwwroot`: Static assets (CSS, JS, images, templates).

---

## 🗝️ Core Components & Patterns
- **Unit of Work & Repository Pattern:** Centralized data access via `IUnitOfWork`.
- **Unified Area Routing:** Most functionality is routed through the `User` area: `{area=User}/{controller=Home}/{action=Index}/{id?}`.
- **Dependency Injection:** Services and repositories are registered in `Program.cs`.
- **Middleware:** `MaintenanceMiddleware` for handling system maintenance states.
- **Background Jobs:** Exposed via HTTP POST endpoints (e.g., `/jobs/start-of-the-month-service`).

---

## 📝 Common Development Tasks
### Database Migrations
- Add migration: `dotnet ef migrations add <Name> --project IBS.DataAccess --startup-project IBSWeb`
- Update database: `dotnet ef database update --project IBS.DataAccess --startup-project IBSWeb`

### Running the Project
- Development: `dotnet run --project IBSWeb`

---

## 🚩 Important Configurations
- **`appsettings.json`**: Main configuration file.
- **`Program.cs`**: Application entry point and service registration.
- **`Npgsql.EnableLegacyTimestampBehavior`**: Enabled to handle DateTime mapping with PostgreSQL.

---

## 🤝 Project Conventions
- **Naming:** Follow standard .NET PascalCase.
- **Patterns:** Prefer `UnitOfWork` for data access.
- **Authorization:** Use `[CompanyAuthorize]` or `[DepartmentAuthorize]` attributes.
- **Logging:** Use Serilog via `Log.Information()`, `Log.Error()`, etc.
