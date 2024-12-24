using cstest.Models;
using cstest.Repositeries;
using cstest.Data;
using Microsoft.Extensions.Logging;

namespace cstest.Services
{
    public class SavingsAccountService : IAccountOperation
    {
        private readonly IAccountRepo _accountRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SavingsAccountService> _logger;
        public SavingsAccountService(IAccountRepo accountRepo, ITransactionRepo transactionRepo, ApplicationDbContext context, ILogger<SavingsAccountService> logger)
        {
            _accountRepo = accountRepo;
            _transactionRepo = transactionRepo;
            _context = context;
            _logger = logger;
        }

        public async Task<decimal> Balance(int AccountId)
        {
            var account = await _accountRepo.GetAccountById(AccountId);
            if (account == null)
            {
                _logger.LogError("Account not found");
                throw new Exception("Account not found");
            }
            if (account.AccountType != AccountType.savings)
            {
                _logger.LogError("Invalid account type");
                throw new Exception("Invalid account type");
            }
            return account.Balance;
        }

        public async Task<AccountDTO> deposit(int AccountId, decimal amount)
        {
            var account = await _accountRepo.GetAccountById(AccountId);
            if (account == null)
            {
                _logger.LogError("Account not found");
                throw new Exception("Account not found");
            }
            if (account.AccountType != AccountType.savings)
            {
                _logger.LogError("Invalid account type");
                throw new Exception("Invalid account type");
            }
            if (amount <= 0)
            {
                _logger.LogError("Invalid amount");
                throw new Exception("Invalid amount");
            }
            account.Balance += amount;
            var accountResult = await _accountRepo.UpdateAccount(account);
            var transaction = new Transaction
            {
                SourceAccountId = AccountId,
                DestinationAccountId = null,
                Timestamp = DateTime.Now.ToUniversalTime(),
                Amount = amount,
                Type = "Deposit"
            };
            await _transactionRepo.CreateTransaction(transaction);
            return AccountMapper.MAP(accountResult);
        }

        public async Task<AccountDTO> transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var fromAccount = await _accountRepo.GetAccountById(fromAccountId);
                    var toAccount = await _accountRepo.GetAccountById(toAccountId);
                    if (fromAccount == null || toAccount == null)
                    {
                        _logger.LogError("Account not found");
                        throw new Exception("Account not found");
                    }
                    if (fromAccount.AccountType != AccountType.savings)
                    {
                        _logger.LogError("Invalid account type");
                        throw new Exception("Invalid account type");
                    }
                    if (amount <= 0)
                    {
                        _logger.LogError("Invalid amount");
                        throw new Exception("Invalid amount");
                    }
                    if (fromAccountId == toAccountId)
                    {
                        _logger.LogError("Cannot transfer to the same account");
                        throw new Exception("Cannot transfer to the same account");
                    }
                    if (fromAccount.Balance < amount)
                    {
                        _logger.LogError("Insufficient balance");
                        throw new Exception("Insufficient balance");
                    }
                    fromAccount.Balance -= amount;
                    toAccount.Balance += amount;
                    await _accountRepo.UpdateAccount(fromAccount);
                    await _accountRepo.UpdateAccount(toAccount);
                    var transactionRecord = new Transaction
                    {
                        SourceAccountId = fromAccountId,
                        DestinationAccountId = toAccountId,
                        Timestamp = DateTime.Now.ToUniversalTime(),
                        Amount = amount,
                        Type = "Transfer"
                    };
                    await _transactionRepo.CreateTransaction(transactionRecord);
                    transaction.Commit();
                    return AccountMapper.MAP(fromAccount);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public async Task<AccountDTO> withdraw(int AccountId, decimal amount)
        {
            var account = await _accountRepo.GetAccountById(AccountId);
            if (account == null)
            {
                _logger.LogError("Account not found");
                throw new Exception("Account not found");
            }
            if (account.AccountType != AccountType.savings)
            {
                _logger.LogError("Invalid account type");
                throw new Exception("Invalid account type");
            }
            if (amount <= 0)
            {
                _logger.LogError("Invalid amount");
                throw new Exception("Invalid amount");
            }
            if (account.Balance < amount)
            {
                _logger.LogError("Insufficient balance");
                throw new Exception("Insufficient balance");
            }
            account.Balance -= amount;
            var accountResult =  await _accountRepo.UpdateAccount(account);
            var transaction = new Transaction
            {
                SourceAccountId = AccountId,
                DestinationAccountId = null,
                Timestamp = DateTime.Now.ToUniversalTime(),
                Amount = amount,
                Type = "Withdraw"
            };
            var transactionResult = await _transactionRepo.CreateTransaction(transaction);
            return AccountMapper.MAP(accountResult);
        }
    }
}