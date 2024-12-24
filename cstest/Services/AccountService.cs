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
                AccountType = account.AccountType == 0 ? "savings" : "checking",
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
        private readonly ITransactionRepo _transactionRepo;

        public AccountService(IAccountRepo accountRepo, ITransactionRepo transactionRepo)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<AccountDTO> CreateAccount(Account account)
        {
            try 
            {
                return AccountMapper.MAP(await _accountRepo.CreateAccount(account));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountDTO> DeleteAccount(int id)
        {
            try
            {
                return AccountMapper.MAP(await _accountRepo.DeleteAccount(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AccountDTO>> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountRepo.GetAllAccounts();
                return accounts.Select(account => AccountMapper.MAP(account));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountDTO> GetAccountById(int id)
        {
            try       
            {
                return AccountMapper.MAP(await _accountRepo.GetAccountById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountDTO> GetAccountByAccountNumber(string accountNumber)
        {
            try
            {
                return AccountMapper.MAP(await _accountRepo.GetAccountByAccountNumber(accountNumber));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AccountDTO> UpdateAccount(Account account)
        {
            try 
            {
                if (account == null)
                {
                    throw new ArgumentNullException(nameof(account));
                }
                return AccountMapper.MAP(await _accountRepo.UpdateAccount(account));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}