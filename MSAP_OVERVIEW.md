# MSAP Workflow Overview (Maritime Service Application)

This document provides a high-level overview of the MSAP workflow within the Integrated Business System (IBSWeb). The process follows a linear progression from service request to financial collection.

---

## 1. Service Request
**Primary Goal:** Capture operational data for maritime services.

*   **Controller:** `ServiceRequestController`
*   **Model:** `MMSIDispatchTicket`
*   **Key Actors:** Port Coordinators
*   **Process:**
    1.  **Creation:** A user creates a Service Request, entering details such as Vessel, Tugboat, Port, Terminal, and Service Type.
    2.  **Timestamps:** Crucial data points include `Date/Time Left` and `Date/Time Arrived`. These are used to calculate `TotalHours`.
    3.  **Media:** Users can upload images or videos as evidence of service.
    4.  **Posting:** Once details are complete, the user "Posts" the request.
*   **Status Transitions:**
    *   `Incomplete`: Missing required fields.
    *   `For Posting`: Ready to be moved to the next phase.
    *   `Pending`: Successfully posted and waiting for tariff setting.
    *   `Cancelled`: Terminated request.

---

## 2. Dispatch Ticket (Tariff & Approval)
**Primary Goal:** Apply financial rates to the operational data and obtain approval.

*   **Controller:** `DispatchTicketController`
*   **Model:** `MMSIDispatchTicket`
*   **Key Actors:** Accounting Staff, Administrators
*   **Process:**
    1.  **Tariff Setting:** Accounting staff reviews `Pending` tickets. If operational data is complete, the ticket moves to `For Tariff`.
    2.  **Rate Application:** The user enters `DispatchRate` and `BAFRate` (Bunker Adjustment Factor). Discounts and other tug charges (`ApOtherTugs`) are also applied here.
    3.  **Calculation:** The system calculates `DispatchBillingAmount`, `BAFBillingAmount`, and `TotalBilling`.
    4.  **Approval:** Once the tariff is set, the status becomes `For Approval`. An Administrator must review and approve the rates.
*   **Status Transitions:**
    *   `For Tariff`: Ready for rate entry.
    *   `For Approval`: Waiting for administrative sign-off.
    *   `Disapproved`: Rejected tariff, requires correction.
    *   `For Billing`: Approved and ready to be invoiced.

---

## 3. Billing
**Primary Goal:** Group services into an invoice (Billing) and record the revenue.

*   **Controller:** `BillingController`
*   **Model:** `MMSIBilling`
*   **Key Actors:** Accounting Staff
*   **Process:**
    1.  **Selection:** The user selects one or multiple Dispatch Tickets (status `For Billing`) for a single customer.
    2.  **Billing Creation:** An `MMSIBilling` record is created. The system generates a unique `MMSIBillingNumber`.
    3.  **Accounting Integration:** Upon creation (and posting), the system generates accounting entries (typically Debit: Accounts Receivable, Credit: Service Income, Credit: Output VAT).
*   **Status Transitions (Dispatch Ticket):**
    *   `Billed`: Successfully linked to a Billing record.
*   **Status Transitions (Billing):**
    *   `For Collection`: Invoiced and awaiting payment.

---

## 4. Collection
**Primary Goal:** Record payment against outstanding billings and close the transaction.

*   **Controller:** `CollectionController`
*   **Model:** `MMSICollection`
*   **Key Actors:** Cashiers / Accounting Staff
*   **Process:**
    1.  **Payment Entry:** The user records the payment (Cash, Check, or Bank Deposit).
    2.  **Allocation:** The user selects outstanding Billing records (status `For Collection`) to be cleared by this collection.
    3.  **Tax Recording:** EWT (Expanded Withholding Tax) and WVAT (Withholding VAT) are recorded if applicable.
    4.  **Final Posting:** The system generates accounting entries (typically Debit: Cash/Bank, Debit: Creditable Withholding Tax, Credit: Accounts Receivable).
*   **Status Transitions (Billing):**
    *   `Collected`: Fully paid and cleared.
*   **Status Transitions (Collection):**
    *   `Create`: Initial state of the collection record.

---

## Technical Entities Summary

| Phase | Main Entity | Key Statuses |
| :--- | :--- | :--- |
| **Service Request** | `MMSIDispatchTicket` | `Incomplete`, `For Posting` |
| **Dispatch Ticket** | `MMSIDispatchTicket` | `Pending`, `For Tariff`, `For Approval`, `For Billing` |
| **Billing** | `MMSIBilling` | `For Collection`, `Collected` |
| **Collection** | `MMSICollection` | `Create` |
