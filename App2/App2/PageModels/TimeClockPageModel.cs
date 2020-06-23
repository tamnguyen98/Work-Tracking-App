using App2.Models;
using App2.PageModels.Base;
using App2.Services.Account;
using App2.Services.Work;
using App2.ViewFolder.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace App2.PageModels
{
    class TimeClockPageModel : PageModelBase
    {
        bool _isClockedIn = false;
        private System.Timers.Timer _timer;
        public bool IsClockedIn
        {
            get => _isClockedIn;
            set => SetProperty(ref _isClockedIn, value);
        }
        TimeSpan _runningTotal;
        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        DateTime _currentStartTime;
        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }

        ObservableCollection<WorkItem> _workItem;

        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItem;
            set => SetProperty(ref _workItem, value);
        }

        double _todaysEarning;
        public double TodaysEarning
        {
            get => _todaysEarning;
            set => SetProperty(ref _todaysEarning, value);
        }

        ButtonModel _clockInOutButtonModel;
        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }
        private IAccountService _accountService;
        private IWorkService _workService;

        public TimeClockPageModel(IAccountService accService, IWorkService workService)
        {
            _accountService = accService;
            _workService = workService;
            //WorkItems = new ObservableCollection<WorkItem>();
            ClockInOutButtonModel = new ButtonModel("Clock In", OnClockInOutAction);
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Enabled = false;
            _timer.Elapsed += _timer_elapsed;
        }

        private void _timer_elapsed(object sender, ElapsedEventArgs e)
        {
            RunningTotal += TimeSpan.FromSeconds(1);

        }

        private double _hourlyRate;
        public override async Task InitializeAsync(object navigationDate = null)
        {
            RunningTotal = new TimeSpan();
            _hourlyRate = await _accountService.GetCurrentPayRateAsync();
            WorkItems = await _workService.GetTodaysWorkAsync();
            await base.InitializeAsync(navigationDate);
        }

        public async void OnClockInOutAction()
        {
            if (IsClockedIn)
            {
                ClockInOutButtonModel.Text = "Clock In";
                WorkItem entry = new WorkItem
                {
                    Start = CurrentStartTime,
                    End = DateTime.Now
                };
                WorkItems.Insert(0, entry);
                await _workService.LogWorkAsync(entry);
                _timer.Enabled = false;
                TodaysEarning += _hourlyRate * RunningTotal.TotalHours;
                RunningTotal = TimeSpan.Zero;
            }
            else
            {
                ClockInOutButtonModel.Text = "Clock Out";
                CurrentStartTime = DateTime.Now;
                _timer.Enabled = true;
            }
            IsClockedIn = !IsClockedIn;
        }
    }
}
