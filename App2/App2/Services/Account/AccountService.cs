using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services.Account
{
    class AccountService : IAccountService
    {
        public Task<bool> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return Task.FromResult(false);
            return Task.Delay(1000).ContinueWith((task) => true);
        }
    }
}
