using App2.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace App2.PageModels
{
    class DashboardPageModel : PageModelBase
    {
        private ProfilePageModel _profilePM;
        public ProfilePageModel ProfilePageModel
        {
            get => _profilePM;
            set => SetProperty(ref _profilePM, value);
        }

        private SettingPageModel _settingPM;
        public SettingPageModel SettingPageModel
        {
            get => _settingPM;
            set => SetProperty(ref _settingPM, value);
        }

        private SummaryPageModel _summaryPM;
        public SummaryPageModel SummaryPageModel
        {
            get => _summaryPM;
            set => SetProperty(ref _summaryPM, value);
        }
        private TimeClockPageModel _timeClockPM;
        public TimeClockPageModel TimeClockPageModel
        {
            get => _timeClockPM;
            set => SetProperty(ref _timeClockPM, value);
        }

        public DashboardPageModel(ProfilePageModel profilePM,
            SettingPageModel settingPM,
            SummaryPageModel summaryPM,
            TimeClockPageModel tcPM)
        {
            ProfilePageModel = profilePM;
            SettingPageModel = settingPM;
            SummaryPageModel = summaryPM;
            TimeClockPageModel = tcPM;
        }
        public override Task InitializeAsync(object navigationDate = null)
        {
            return Task.WhenAny(base.InitializeAsync(navigationDate),
                ProfilePageModel.InitializeAsync(null),
                SettingPageModel.InitializeAsync(null),
                SummaryPageModel.InitializeAsync(null),
                TimeClockPageModel.InitializeAsync(null));
        }
    }
}
