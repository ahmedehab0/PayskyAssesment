using cstest.Models;
using cstest.Data;
using Microsoft.EntityFrameworkCore;
namespace cstest.Repositeries;
public class AccountHolderRepo : IAccountHolderRepo
{
    private readonly ApplicationDbContext _context;
    public AccountHolderRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AccountHolder> CreateAccountHolder(AccountHolder accountHolder)
    {
        _context.AccountHolders.Add(accountHolder);
        await _context.SaveChangesAsync();
        return accountHolder;
    }
    public async Task<AccountHolder> DeleteAccountHolder(int id)
    {
        var accountHolder = await _context.AccountHolders.FindAsync(id);
        if (accountHolder == null)
        {
            return null;
        }
        _context.AccountHolders.Remove(accountHolder);
        await _context.SaveChangesAsync();
        return accountHolder;
    }
    public async Task<IEnumerable<AccountHolder>> GetAllAccountHolders()
    {
        return await _context.AccountHolders.ToListAsync();
    }
    public async Task<AccountHolder> GetAccountHolderById(int id)
    {
        return await _context.AccountHolders.FindAsync(id);
    }
    public async Task<AccountHolder> UpdateAccountHolder(AccountHolder accountHolder)
    {
        _context.Entry(accountHolder).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return accountHolder;
    }
}