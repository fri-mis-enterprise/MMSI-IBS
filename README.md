# IBSWeb — Integrated Business System

IBSWeb is a robust web-based Accounting and Business Management system developed with ASP.NET Core. It is architected to manage complex financial and operational workflows within a single integrated platform, now unified under the **MMSI** entity.

---

## 🏢 Business Operations

The system provides a comprehensive suite of tools for business management, unified into a single streamlined interface:

### 1. Core Accounting & Logistics
Focusing on full-cycle financial management:
- **Accounts Receivable**: Customer Order Slips (COS), Delivery Receipts (DR), Sales Invoices, Service Invoices, and Collection Receipts.
- **Accounts Payable**: Authority to Load (ATL), Purchase Orders (PO), Receiving Reports (RR), and complex Check Voucher (CV) workflows (Trade, Non-Trade, Payroll).
- **Advanced Accounting**: Hierarchical Chart of Accounts, General Ledger, Journal Vouchers, and automated posting logic.
- **Treasury & Reports**: Disbursement management and a wide array of financial statements (PNL, Trial Balance, Balance Sheet, SRE).
- **Inventory**: Real-time tracking and automated valuation.

### 2. Maritime Service Assistance Program (MSAP)
Tailored operations for the maritime sector:
- **MSAP Operations**: Management of Service Requests and Dispatch Tickets.
- **Billing & Collection**: Integrated workflow from service fulfillment to billing and final collection.
- **Maritime Reporting**: Specific sales and operational reports for maritime services.
- **Master Files**: Comprehensive management of Ports, Principals, Tugboats, Vessels, and Tug Masters.

---

## 🔎 Key Features

- **Unified Entity Architecture**: Consolidation of multiple business workflows into a single cohesive structure.
- **Simplified Modular Design**: Organized into a unified User area for a streamlined user experience and better maintainability.
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
