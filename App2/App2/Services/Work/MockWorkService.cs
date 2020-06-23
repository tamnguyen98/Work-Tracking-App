﻿using App2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services.Work
{
    class MockWorkService : IWorkService
    {
        public List<WorkItem> Items { get; set; }
        public MockWorkService()
        {
            Items = new List<WorkItem>();
        }

        public Task<bool> LogWorkAsync(WorkItem item)
        {
            Items.Add(item);
            return Task.FromResult(true);
        }


        public Task<ObservableCollection<WorkItem>> GetTodaysWorkAsync()
        {
            return Task.FromResult(new ObservableCollection<WorkItem>(Items));
        }
    }
}
