using cstest.Models;
namespace cstest.Repositeries;
public interface IAccountRepo
{
    Task<IEnumerable<Account>> GetAllAccounts();
    Task<Account> GetAccountById(int id);
    Task<Account> GetAccountByAccountNumber(string accountNumber);
    Task<Account> CreateAccount(Account account);
    Task<Account> UpdateAccount(Account account);
    Task<Account> DeleteAccount(int id);
}