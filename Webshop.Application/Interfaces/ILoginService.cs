using Webshop.Application.DTOs;

namespace Webshop.Application.Interfaces{

    public interface ILoginService{
        Task<string> CreateAccountAsync(AccountDto account);
        Task<string> LoginAsync(LoginDataDto account);
    }
}