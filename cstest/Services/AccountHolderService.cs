using cstest.Data;
using cstest.Repositeries;
using cstest.Models;
using System;

namespace cstest.Services
{
    public class AccountHolderService : IAccountHolderService
    {
        private readonly IAccountHolderRepo _accountHolderRepo;
        public AccountHolderService(IAccountHolderRepo accountHolderRepo)
        {
            _accountHolderRepo = accountHolderRepo;
        }
        public async Task<AccountHolder> CreateAccountHolder(AccountHolder accountHolder)
        {
            if (accountHolder == null)
            {
                throw new ArgumentNullException(nameof(accountHolder));
            }
            return await _accountHolderRepo.CreateAccountHolder(accountHolder);
        }
        public async Task<AccountHolder> DeleteAccountHolder(int id)
        {
            return await _accountHolderRepo.DeleteAccountHolder(id);
        }
        public async Task<AccountHolder> GetAccountHolderById(int id)
        {
            return await _accountHolderRepo.GetAccountHolderById(id);
        }
        public async Task<AccountHolder> UpdateAccountHolder(AccountHolder accountHolder)
        {
            if (accountHolder == null)
            {
                throw new ArgumentNullException(nameof(accountHolder));
            }
            return await _accountHolderRepo.UpdateAccountHolder(accountHolder);
        }
    }
}