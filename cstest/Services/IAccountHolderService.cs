using cstest.Models;

namespace cstest.Services
{
    public interface IAccountHolderService
    {
        Task<AccountHolder> CreateAccountHolder(AccountHolder accountHolder);
        Task<AccountHolder>  GetAccountHolderById(int id);
        Task<AccountHolder>  UpdateAccountHolder(AccountHolder accountHolder);
        Task<AccountHolder>  DeleteAccountHolder(int id);
    }
}