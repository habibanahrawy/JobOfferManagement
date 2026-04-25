# Job Offer Management System

A streamlined backend system for managing job offers and employee applications, built with **.NET 10** and **Clean Architecture**.

## 1. Project Architecture
The solution follows the **Separation of Concerns** principle through four main layers:
- **Core:** Entities, Enums, and Interfaces.
- **Application:** CQRS Pattern (MediatR), DTOs, and Business Logic.
- **Infrastructure:** Data Persistence (EF Core), Repositories, and Migrations.
- **WebAPI:** REST Endpoints and Middleware.

## 2. Technical Implementation Details
- **Integrated File Storage:** User CVs and Digital Signatures are managed via a dedicated File Service, storing relative paths to optimize database performance.
- **Service Extensions:** Clean `Program.cs` via layer-specific Service Registration methods.
- **Global Usings**

## 3. Implementation Roadmap

### Foundations
- [x] Solution Layers & Project References.
- [x] Lookup Data (Countries, Cities, Types , Categories).
- [x] Identity System with Custom User Entity.
- [x] Database Seeding & Migrations.

### Integration & Security
- [x] **JWT Authentication:** Token-based security and Role-based authorization.
- [ ] **Exception Handling:** Standardized API response format.
- [ ] **SMTP Integration:** Automated email notifications for new offers.

### Core Business Logic
- [ ] **JobOffer Module:** Implementation of CRUD operations.
- [ ] **Workflow Actions:** Employee Accept/Reject functionality.
- [ ] **Signature Logic:** Linking digital signatures to accepted offers via `AttachmentId`.

## Tech Stack
- **Framework:** .NET 10
- **ORM:** Entity Framework Core (SQL Server)
- **Patterns:** CQRS, Repository, Unit of Work
- **Libraries:** MediatR, AutoMapper, FluentValidation , Swagger UI