using App2.Models;
using App2.PageModels.Base;
using App2.Services.Statements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.PageModels
{
    class SummaryPageModel : PageModelBase
    {
        private string _currentPayDateRange;
        public string CurrentPayDateRange 
        {
            get => _currentPayDateRange;
            set => SetProperty(ref _currentPayDateRange, value);
        }
        private string _currentPeriodEarning;
        public string CurrentPeriodEarning 
        {
            get => _currentPeriodEarning;
            set => SetProperty(ref _currentPeriodEarning, value);
        }
        private DateTime _CurrentPeriodPayDate;
        public DateTime CurrentPeriodPayDate 
        {
            get => _CurrentPeriodPayDate;
            set => SetProperty(ref _CurrentPeriodPayDate, value);
        }
        private List<PayStatement> _statements;

        public List<PayStatement> Statements
        {
            get => _statements;
            set => SetProperty(ref _statements, value);
        }

        private IStatementServices _statementService;
        public SummaryPageModel(IStatementServices statementService)
        {
            _statementService = statementService;
        }

        public override async Task InitializeAsync(object navigationDate)
        {
            Statements = await _statementService.GetStatementHistoryAsync();
            await base.InitializeAsync(navigationDate);
        }
    }
}
