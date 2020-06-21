using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services.Account
{
    interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
