﻿using App2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services.Statements
{
    class MockStatementServices : IStatementServices
    {
        private List<PayStatement> _items;
        public MockStatementServices()
        {
            _items = new List<PayStatement>()
            {
                new PayStatement
                {
                    Amount = 10,
                    Date = DateTime.Parse("06/12/2020"),
                    Start = DateTime.Parse("05/24/2020"),
                    End = DateTime.Parse("06/04/2020"),
                    WorkItems = new List<WorkItem>
                    {
                        new WorkItem
                        {
                            Start = DateTime.Parse("06/06/2020 12:00:00"),
                            End = DateTime.Parse("06/06/2020 13:00:00")
                        }
                    }
                }
            };
        }
        public Task<List<PayStatement>> GetStatementHistoryAsync()
        {
            return Task.FromResult(_items);
        }
    }
}
