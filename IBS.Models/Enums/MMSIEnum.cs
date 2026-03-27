namespace IBS.Models.Enums
{
    public enum MMSIEnum
    {

    }

    /// <summary>
    /// Defines all access procedures for MMSI permission system.
    /// Grouped by module for easier management.
    /// </summary>
    public enum ProcedureEnum
    {
        #region -- MSAP Workflow --

        CreateServiceRequest,
        PostServiceRequest,
        CreateDispatchTicket,
        EditDispatchTicket,
        CancelDispatchTicket,
        SetTariff,
        ApproveTariff,
        CreateBilling,
        CreateCollection,
        CreateJobOrder,
        EditJobOrder,
        DeleteJobOrder,
        CloseJobOrder,

        #endregion -- MSAP Workflow --

        #region -- A. Receivable --

        AccessReceivable,
        CreateCustomerOrderSlip,
        CreateDeliveryReceipt,
        CreateSalesInvoice,
        CreateServiceInvoice,
        CreateCollectionReceipt,
        CreateDebitMemo,
        CreateCreditMemo,

        #endregion -- A. Receivable --

        #region -- A. Payable --

        AccessPayable,
        CreateAuthorityToLoad,
        CreatePurchaseOrder,
        CreateReceivingReport,
        CreateCheckVoucherTrade,
        CreateCheckVoucherNonTradeInvoice,
        CreateCheckVoucherNonTradePayment,
        CreateJournalVoucher,

        #endregion -- A. Payable --

        #region -- Treasury --

        AccessTreasury,
        CreateDisbursement,

        #endregion -- Treasury --

        #region -- MSAP Import --

        ManageMsapImport,

        #endregion -- MSAP Import --

        #region -- Reports --

        ViewGeneralLedger,
        ViewInventoryReport,
        ViewAccountsPayableReport,
        ViewAccountsReceivableReport,
        ViewMaritimeReport,

        #endregion -- Reports --
    }
}
