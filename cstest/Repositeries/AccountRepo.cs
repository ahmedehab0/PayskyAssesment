using cstest.Models;
using Microsoft.EntityFrameworkCore;
using cstest.Data;
namespace cstest.Repositeries;

public class AccountRepo : IAccountRepo
{
    private readonly ApplicationDbContext _context;

    public AccountRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Account> CreateAccount(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account> DeleteAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
        {
            return null;
        }

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetAccountByAccountNumber(string accountNumber)
    {
        return await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
    }

    public async Task<Account> GetAccountById(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<Account> UpdateAccount(Account account)
    {
        _context.Entry(account).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return account;
    }
}