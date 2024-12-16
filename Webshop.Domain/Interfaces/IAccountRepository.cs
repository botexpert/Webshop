using Webshop.Domain.Entities;

namespace Webshop.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<string> CreateAccountAsync(Account account);
        Task<Account> GetAccountByUsername(Account account);
    }
}