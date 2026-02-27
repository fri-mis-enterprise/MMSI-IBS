# IBSWeb — Integrated Business System

IBSWeb is a robust web-based Accounting and Business Management system developed with ASP.NET Core. It is specifically architected to manage the complex financial and operational workflows of multiple business entities within a single integrated platform.

---

## 🏢 Supported Companies

The system currently supports and isolates operations for two primary entities:

### 1. Filpride (Filpride Resources Inc.)
A comprehensive business management module focusing on full-cycle accounting and logistics:
- **Accounts Receivable**: Customer Order Slips (COS), Delivery Receipts (DR), Sales Invoices, Service Invoices, and Collection Receipts.
- **Accounts Payable**: Authority to Load (ATL), Purchase Orders (PO), Receiving Reports (RR), and complex Check Voucher (CV) workflows (Trade, Non-Trade, Payroll).
- **Advanced Accounting**: Hierarchical Chart of Accounts, General Ledger, Journal Vouchers, and automated posting logic.
- **Treasury & Reports**: Disbursement management and a wide array of financial statements (PNL, Trial Balance, Balance Sheet, SRE).
- **Inventory**: Real-time tracking and automated valuation.

### 2. MMSI (MMSI)
A specialized module tailored for maritime service assistance and program management:
- **MSAP Operations**: Management of Service Requests and Dispatch Tickets.
- **Billing & Collection**: Integrated workflow from service fulfillment to billing and final collection.
- **Maritime Reporting**: Specific sales and operational reports for the maritime sector.
- **Master Files**: Specialized management of Ports, Principals, Tugboats, Vessels, and Tug Masters.

---

## 🔎 Key Features

- **Multi-Entity Architecture**: Strict logical separation between company data while sharing core infrastructure.
- **Modular Design**: Organized into specialized Areas (Filpride, MMSI, Admin, User) for better maintainability.
- **Comprehensive Audit Trail**: Every critical action is logged with user details, activity descriptions, and timestamps.
- **Period Posting Control**: Security logic to prevent data modification in closed financial periods.
- **Advanced Export Features**: Direct data export capabilities to AAS (Advanced Accounting System) formats.
- **Role-Based Access Control**: Granular permissions across different departments (Accounting, Marketing, Logistics, Finance, etc.).

---

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core 10.0 (C#)
- **Data Access**: Entity Framework Core with Npgsql (PostgreSQL)
- **Architecture**: N-Tier / Layered (DataAccess, Models, DTOs, Services, Web UI)
- **Frontend**: Razor Pages / MVC, JavaScript, jQuery, DataTables.net
- **Messaging**: SignalR for real-time notifications
- **External Integration**: Google Drive API for automated imports and Cloud Storage for attachments
- **Hosting/Deployment**: Dockerized environment, optimized for Google Cloud Platform

---

For full version history, see the [CHANGELOG](CHANGELOG.md).
