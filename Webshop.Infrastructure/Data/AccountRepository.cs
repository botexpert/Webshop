using Microsoft.EntityFrameworkCore;
using Webshop.Domain.Interfaces;
using Webshop.Domain.Entities;

namespace Webshop.Infrastructure.Data
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(WebshopDbContext context) : base(context)
        {
        }

        public async Task<Account> GetAccountByUsername(Account account)
        {
            return await _context.Accounts.SingleOrDefaultAsync(acc => acc.Username.Equals(account.Username));
        }

        public async Task<string> CreateAccountAsync(Account account)
        {
            await base.AddAsync(account);
            await base.SaveChangesAsync();
            return account.Role;
        }
    }
}
