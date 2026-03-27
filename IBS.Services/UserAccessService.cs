using IBS.Models.Books;
using IBS.DataAccess.Data;
using IBS.Models;
using IBS.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace IBS.Services
{
    public interface IUserAccessService
    {
        Task<bool> CheckAccess(string id, ProcedureEnum procedure, CancellationToken cancellationToken = default);
    }

    public class UserAccessService : IUserAccessService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserAccessService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckAccess(string id, ProcedureEnum procedure, CancellationToken cancellationToken = default)
        {
            var userAccess = await _dbContext.MMSIUserAccesses
                .FirstOrDefaultAsync(a => a.UserId == id, cancellationToken);

            if (userAccess == null)
            {
                return false;
            }

            switch (procedure)
            {
                #region -- MSAP Workflow --

                case ProcedureEnum.CreateServiceRequest:
                    return userAccess.CanCreateServiceRequest;
                case ProcedureEnum.PostServiceRequest:
                    return userAccess.CanPostServiceRequest;
                case ProcedureEnum.CreateDispatchTicket:
                    return userAccess.CanCreateDispatchTicket;
                case ProcedureEnum.EditDispatchTicket:
                    return userAccess.CanEditDispatchTicket;
                case ProcedureEnum.CancelDispatchTicket:
                    return userAccess.CanCancelDispatchTicket;
                case ProcedureEnum.SetTariff:
                    return userAccess.CanSetTariff;
                case ProcedureEnum.ApproveTariff:
                    return userAccess.CanApproveTariff;
                case ProcedureEnum.CreateBilling:
                    return userAccess.CanCreateBilling;
                case ProcedureEnum.CreateCollection:
                    return userAccess.CanCreateCollection;
                case ProcedureEnum.CreateJobOrder:
                    return userAccess.CanCreateJobOrder;
                case ProcedureEnum.EditJobOrder:
                    return userAccess.CanEditJobOrder;
                case ProcedureEnum.DeleteJobOrder:
                    return userAccess.CanDeleteJobOrder;
                case ProcedureEnum.CloseJobOrder:
                    return userAccess.CanCloseJobOrder;

                #endregion -- MSAP Workflow --

                #region -- A. Receivable --

                case ProcedureEnum.AccessReceivable:
                    return userAccess.CanAccessReceivable;
                case ProcedureEnum.CreateCustomerOrderSlip:
                    return userAccess.CanCreateCustomerOrderSlip;
                case ProcedureEnum.CreateDeliveryReceipt:
                    return userAccess.CanCreateDeliveryReceipt;
                case ProcedureEnum.CreateSalesInvoice:
                    return userAccess.CanCreateSalesInvoice;
                case ProcedureEnum.CreateServiceInvoice:
                    return userAccess.CanCreateServiceInvoice;
                case ProcedureEnum.CreateCollectionReceipt:
                    return userAccess.CanCreateCollectionReceipt;
                case ProcedureEnum.CreateDebitMemo:
                    return userAccess.CanCreateDebitMemo;
                case ProcedureEnum.CreateCreditMemo:
                    return userAccess.CanCreateCreditMemo;

                #endregion -- A. Receivable --

                #region -- A. Payable --

                case ProcedureEnum.AccessPayable:
                    return userAccess.CanAccessPayable;
                case ProcedureEnum.CreateAuthorityToLoad:
                    return userAccess.CanCreateAuthorityToLoad;
                case ProcedureEnum.CreatePurchaseOrder:
                    return userAccess.CanCreatePurchaseOrder;
                case ProcedureEnum.CreateReceivingReport:
                    return userAccess.CanCreateReceivingReport;
                case ProcedureEnum.CreateCheckVoucherTrade:
                    return userAccess.CanCreateCheckVoucherTrade;
                case ProcedureEnum.CreateCheckVoucherNonTradeInvoice:
                    return userAccess.CanCreateCheckVoucherNonTradeInvoice;
                case ProcedureEnum.CreateCheckVoucherNonTradePayment:
                    return userAccess.CanCreateCheckVoucherNonTradePayment;
                case ProcedureEnum.CreateJournalVoucher:
                    return userAccess.CanCreateJournalVoucher;

                #endregion -- A. Payable --

                #region -- Treasury --

                case ProcedureEnum.AccessTreasury:
                    return userAccess.CanAccessTreasury;
                case ProcedureEnum.CreateDisbursement:
                    return userAccess.CanCreateDisbursement;

                #endregion -- Treasury --

                #region -- MSAP Import --

                case ProcedureEnum.ManageMsapImport:
                    return userAccess.CanManageMsapImport;

                #endregion -- MSAP Import --

                #region -- Reports --

                case ProcedureEnum.ViewGeneralLedger:
                    return userAccess.CanViewGeneralLedger;
                case ProcedureEnum.ViewInventoryReport:
                    return userAccess.CanViewInventoryReport;
                case ProcedureEnum.ViewAccountsPayableReport:
                    return userAccess.CanViewAccountsPayableReport;
                case ProcedureEnum.ViewAccountsReceivableReport:
                    return userAccess.CanViewAccountsReceivableReport;
                case ProcedureEnum.ViewMaritimeReport:
                    return userAccess.CanViewMaritimeReport;

                #endregion -- Reports --

                default:
                    return false;
            }
        }
    }
}
