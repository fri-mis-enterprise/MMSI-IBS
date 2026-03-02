using IBS.DataAccess.Data;
using IBS.DataAccess.Repository.MasterFile.IRepository;
using IBS.Models.MasterFile;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IBS.DataAccess.Repository.MasterFile
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        private readonly ApplicationDbContext _db;

        public BankAccountRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<SelectListItem>> GetBankAccountListAsync(string company, CancellationToken cancellationToken = default)
        {
            return await _db.BankAccounts
                 .Select(ba => new SelectListItem
                 {
                     Value = ba.BankAccountId.ToString(),
                     Text = ba.AccountName
                 })
                 .ToListAsync(cancellationToken);
        }

        public async Task<bool> IsBankAccountNameExist(string accountName, CancellationToken cancellationToken = default)
        {
            return await _db.BankAccounts
                .AnyAsync(b => b.AccountName == accountName, cancellationToken);
        }

        public async Task<bool> IsBankAccountNoExist(string accountNo, CancellationToken cancellationToken = default)
        {
            return await _db.BankAccounts
                .AnyAsync(b => b.AccountNo == accountNo, cancellationToken);
        }

        public async Task UpdateAsync(BankAccount model, CancellationToken cancellationToken = default)
        {
            var existingBankAccount = await _db.BankAccounts
                .FirstOrDefaultAsync(x => x.BankAccountId == model.BankAccountId, cancellationToken)
                ?? throw new InvalidOperationException($"Bank Account with id '{model.BankAccountId}' not found.");

            existingBankAccount.AccountName = model.AccountName;
            existingBankAccount.AccountNo = model.AccountNo;
            existingBankAccount.Bank = model.Bank;
            existingBankAccount.Branch = model.Branch;
            existingBankAccount.Company = model.Company;

            if (_db.ChangeTracker.HasChanges())
            {
                await _db.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("No data changes!");
            }
        }
    }
}
