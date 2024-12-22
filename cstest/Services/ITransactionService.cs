using cstest.Models;

namespace cstest.Services
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction> GetTransactionById(int id);
        Task<Transaction> DeleteTransaction(int id);
    }
}