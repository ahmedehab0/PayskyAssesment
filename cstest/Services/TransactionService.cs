using cstest.Models;
using System;
using cstest.Repositeries;

namespace cstest.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;
        public TransactionService(ITransactionRepo transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }
        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            return await _transactionRepo.CreateTransaction(transaction);
        }
        public async Task<Transaction> DeleteTransaction(int id)
        {
            return await _transactionRepo.DeleteTransaction(id);
        }
        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _transactionRepo.GetTransactionById(id);
        }
    }
}