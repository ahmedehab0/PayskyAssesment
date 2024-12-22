using cstest.Models;
public interface IAccountHolderRepo
{
    Task<IEnumerable<AccountHolder>> GetAllAccountHolders();
    Task<AccountHolder> GetAccountHolderById(int id);
    Task<AccountHolder> CreateAccountHolder(AccountHolder accountHolder);
    Task<AccountHolder> UpdateAccountHolder(AccountHolder accountHolder);
    Task<AccountHolder> DeleteAccountHolder(int id);
}