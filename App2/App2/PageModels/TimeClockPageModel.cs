using App2.Models;
using App2.PageModels.Base;
using App2.ViewFolder.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace App2.PageModels
{
    class TimeClockPageModel : PageModelBase
    {
        bool _isClockedIn = false;
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

        public TimeClockPageModel()
        {
            WorkItems = new ObservableCollection<WorkItem>();
            ClockInOutButtonModel = new ButtonModel("Clock In", OnClockInOutAction);
        }

        public override Task InitializeAsync(object navigationDate = null)
        {
            RunningTotal = new TimeSpan();
            return base.InitializeAsync(navigationDate);
        }

        public void OnClockInOutAction()
        {
            IsClockedIn = !IsClockedIn;
            if (IsClockedIn)
            {
                ClockInOutButtonModel.Text = "Clock In";
                WorkItems.Insert(0, new WorkItem
                {
                    Start = CurrentStartTime,
                    End = DateTime.Now
                });
            }
            else
            {
                ClockInOutButtonModel.Text = "Clock Out";
                CurrentStartTime = DateTime.Now;
            }
        }
    }
}
