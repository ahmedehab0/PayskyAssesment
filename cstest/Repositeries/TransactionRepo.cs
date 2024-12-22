using cstest.Models;
using System;  
using System.Collections.Generic;
using cstest.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cstest.Repositeries
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<Transaction> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return null;
            }
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }
        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }
        public async Task<Transaction> GetTransactionById(int id)
        {
            return await _context.Transactions.FindAsync(id);
        }
    }
}