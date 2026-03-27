using IBS.Models;
using IBS.Services.AccessControl;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IBSWeb.Areas.User.Controllers
{
    /// <summary>
    /// Base controller for all MSAP controllers with centralized access control
    /// </summary>
    public abstract class MmsiBaseController : Controller
    {
        protected readonly IAccessControlService AccessControl;
        protected readonly UserManager<ApplicationUser> UserManager;

        protected MmsiBaseController(IAccessControlService accessControl, UserManager<ApplicationUser> userManager)
        {
            AccessControl = accessControl;
            UserManager = userManager;
        }

        protected string GetUserId() => UserManager.GetUserId(User)!;

        /// <summary>
        /// Check if user has access to ANY of the specified procedures
        /// </summary>
        private async Task<bool> HasAccessAsync(params IBS.Models.Enums.ProcedureEnum[] procedures)
        {
            return await AccessControl.HasAnyAccessAsync(GetUserId(), procedures);
        }

        /// <summary>
        /// Check if user has access to ALL the specified procedures
        /// </summary>
        protected async Task<bool> HasAllAccessAsync(params IBS.Models.Enums.ProcedureEnum[] procedures)
        {
            return await AccessControl.HasAllAccessAsync(GetUserId(), procedures);
        }

        /// <summary>
        /// Redirect to home if user doesn't have access
        /// </summary>
        protected async Task<IActionResult> RequireAccessAsync(params IBS.Models.Enums.ProcedureEnum[] procedures)
        {
            if (!await HasAccessAsync(procedures))
            {
                TempData["error"] = "Access denied.";
                return RedirectToAction("Index", "Home", new { area = "User" });
            }

            return null!;
        }

        /// <summary>
        /// Returns a permission denied modal partial view
        /// </summary>
        protected IActionResult PermissionDenied(string? message = null, string? requiredPermission = null)
        {
            ViewData["message"] = message ?? "You don't have permission to perform this action.";
            ViewData["requiredPermission"] = requiredPermission;
            return PartialView("_PermissionDeniedModal");
        }

        // Module-specific access helpers using extension methods

        protected async Task<bool> HasJobOrderAccessAsync()
            => await AccessControl.HasJobOrderAccessAsync(GetUserId());

        protected async Task<bool> HasServiceRequestAccessAsync()
            => await AccessControl.HasServiceRequestAccessAsync(GetUserId());

        protected async Task<bool> HasDispatchTicketAccessAsync()
            => await AccessControl.HasDispatchTicketAccessAsync(GetUserId());

        protected async Task<bool> HasBillingAccessAsync()
            => await AccessControl.HasBillingAccessAsync(GetUserId());

        protected async Task<bool> HasCollectionAccessAsync()
            => await AccessControl.HasCollectionAccessAsync(GetUserId());

        protected async Task<bool> HasTariffAccessAsync()
            => await AccessControl.HasTariffAccessAsync(GetUserId());

        protected async Task<bool> HasMsapAccessAsync()
            => await AccessControl.HasMsapAccessAsync(GetUserId());

        // A. Receivable access helpers

        protected async Task<bool> HasReceivableAccessAsync()
            => await AccessControl.HasReceivableAccessAsync(GetUserId());

        protected async Task<bool> HasCustomerOrderSlipAccessAsync()
            => await AccessControl.HasCustomerOrderSlipAccessAsync(GetUserId());

        protected async Task<bool> HasDeliveryReceiptAccessAsync()
            => await AccessControl.HasDeliveryReceiptAccessAsync(GetUserId());

        protected async Task<bool> HasSalesInvoiceAccessAsync()
            => await AccessControl.HasSalesInvoiceAccessAsync(GetUserId());

        protected async Task<bool> HasServiceInvoiceAccessAsync()
            => await AccessControl.HasServiceInvoiceAccessAsync(GetUserId());

        protected async Task<bool> HasCollectionReceiptAccessAsync()
            => await AccessControl.HasCollectionReceiptAccessAsync(GetUserId());

        protected async Task<bool> HasDebitMemoAccessAsync()
            => await AccessControl.HasDebitMemoAccessAsync(GetUserId());

        protected async Task<bool> HasCreditMemoAccessAsync()
            => await AccessControl.HasCreditMemoAccessAsync(GetUserId());

        // A. Payable access helpers

        protected async Task<bool> HasPayableAccessAsync()
            => await AccessControl.HasPayableAccessAsync(GetUserId());

        protected async Task<bool> HasAuthorityToLoadAccessAsync()
            => await AccessControl.HasAuthorityToLoadAccessAsync(GetUserId());

        protected async Task<bool> HasPurchaseOrderAccessAsync()
            => await AccessControl.HasPurchaseOrderAccessAsync(GetUserId());

        protected async Task<bool> HasReceivingReportAccessAsync()
            => await AccessControl.HasReceivingReportAccessAsync(GetUserId());

        protected async Task<bool> HasCheckVoucherTradeAccessAsync()
            => await AccessControl.HasCheckVoucherTradeAccessAsync(GetUserId());

        protected async Task<bool> HasCheckVoucherNonTradeAccessAsync()
            => await AccessControl.HasCheckVoucherNonTradeAccessAsync(GetUserId());

        protected async Task<bool> HasJournalVoucherAccessAsync()
            => await AccessControl.HasJournalVoucherAccessAsync(GetUserId());

        // Treasury access helpers

        protected async Task<bool> HasTreasuryAccessAsync()
            => await AccessControl.HasTreasuryAccessAsync(GetUserId());

        protected async Task<bool> HasDisbursementAccessAsync()
            => await AccessControl.HasDisbursementAccessAsync(GetUserId());

        // MSAP Import access helpers

        protected async Task<bool> HasMsapImportAccessAsync()
            => await AccessControl.HasMsapImportAccessAsync(GetUserId());

        // Reports access helpers

        protected async Task<bool> HasGeneralLedgerReportAccessAsync()
            => await AccessControl.HasGeneralLedgerReportAccessAsync(GetUserId());

        protected async Task<bool> HasInventoryReportAccessAsync()
            => await AccessControl.HasInventoryReportAccessAsync(GetUserId());

        protected async Task<bool> HasAccountsPayableReportAccessAsync()
            => await AccessControl.HasAccountsPayableReportAccessAsync(GetUserId());

        protected async Task<bool> HasAccountsReceivableReportAccessAsync()
            => await AccessControl.HasAccountsReceivableReportAccessAsync(GetUserId());

        protected async Task<bool> HasMaritimeReportAccessAsync()
            => await AccessControl.HasMaritimeReportAccessAsync(GetUserId());
    }
}
