using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services.Statements
{
    interface IStatementServices
    {
        Task<List<PayStatement>> GetStatementHistoryAsync();
    }
}
