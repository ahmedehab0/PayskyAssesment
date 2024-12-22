using cstest.Models;

public interface ITransactionRepo
    {
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task<Transaction> GetTransactionById(int id);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction> DeleteTransaction(int id);
    }