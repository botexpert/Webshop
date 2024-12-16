using BCrypt.Net;
using Webshop.Application.DTOs;
using Webshop.Application.Interfaces;
using Webshop.Domain.Entities;
using Webshop.Domain.Interfaces;

namespace Webshop.Infrastructure.Services
{
    class LoginService : ILoginService
    {
        private readonly IAccountRepository _accountRepository;

        public LoginService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<string> CreateAccountAsync(AccountDto account)
        {
            // Hash the password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(account.Password);

            Account accountEntity = new Account()
            {
                Username = account.Username,
                Password = passwordHash,
                Role = account.Role
            };

            return await _accountRepository.CreateAccountAsync(accountEntity);
        }

        public async Task<string> LoginAsync(LoginDataDto loginData)
        {
            Account accountEntity = new Account()
            {
                Username = loginData.Username,
                Password = loginData.Password
            };

            var userAccount = await _accountRepository.GetAccountByUsername(accountEntity);

            if(BCrypt.Net.BCrypt.Verify(loginData.Password, userAccount.Password))
            {
                return userAccount.Role;
            }

            throw new Exception("Bad username or password");
        }
    }

}