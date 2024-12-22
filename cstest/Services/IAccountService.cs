using cstest.Models;

namespace cstest.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>> GetAllAccounts();
        Task<AccountDTO> GetAccountById(int id);
        Task<AccountDTO> GetAccountByAccountNumber(string accountNumber);
        Task<AccountDTO> CreateAccount(Account account);
        Task<AccountDTO> UpdateAccount(Account account);
        Task<AccountDTO> DeleteAccount(int id);
    }
}