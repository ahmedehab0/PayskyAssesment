using cstest.Repositeries;
using cstest.Models;
namespace cstest.Services
{
public class AccountDTO 
{
    public int Id { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
}
}

namespace cstest.Services 
{
    public static class AccountMapper
    {
        public static AccountDTO MAP(Account account)
        {
            return new AccountDTO
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                AccountType = account.AccountType,
                Balance = account.Balance
            };
        }
    } 
}
namespace cstest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IAccountHolderRepo _accountHolderRepo;
        private readonly ITransactionRepo _transactionRepo;

        public AccountService(IAccountRepo accountRepo, IAccountHolderRepo accountHolderRepo, ITransactionRepo transactionRepo)
        {
            _accountRepo = accountRepo;
            _accountHolderRepo = accountHolderRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<AccountDTO> CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            return AccountMapper.MAP(await _accountRepo.CreateAccount(account));
        }

        public async Task<AccountDTO> DeleteAccount(int id)
        {
            return AccountMapper.MAP(await _accountRepo.DeleteAccount(id));
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            var accounts = await _accountRepo.GetAllAccounts();
            return accounts.Select(account => AccountMapper.MAP(account));
        }

        public async Task<AccountDTO> GetAccountById(int id)
        {
            return AccountMapper.MAP(await _accountRepo.GetAccountById(id));
        }

        public async Task<AccountDTO> GetAccountByAccountNumber(string accountNumber)
        {
            return AccountMapper.MAP(await _accountRepo.GetAccountByAccountNumber(accountNumber));
        }

        public async Task<AccountDTO> UpdateAccount(Account account)
        {
            var accountExists = await _accountRepo.GetAccountById(account.Id);
            if (accountExists == null)
            {
                throw new Exception("Account does not exist");
            }

            return AccountMapper.MAP(await _accountRepo.UpdateAccount(account));
        }
    }
}