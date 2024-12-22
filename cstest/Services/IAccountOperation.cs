using cstest.Models;

namespace cstest.Services
{
    public interface IAccountOperation
    {
        Task<AccountDTO> deposit(int AccountId, decimal amount);
        Task<AccountDTO> withdraw(int AccountId, decimal amount);
        Task<AccountDTO> transfer(int fromAccountId, int toAccountId, decimal amount);
        Task<decimal> Balance(int AccountId);
    }
}