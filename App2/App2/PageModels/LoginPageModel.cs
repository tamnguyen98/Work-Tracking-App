using App2.PageModels.Base;
using App2.Services.Account;
using App2.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App2.PageModels
{
    class LoginPageModel : PageModelBase
    {
        private ICommand _signInCommand;
        private INavigationService _navigationService;

        public ICommand SignInCommand
        {
            get => _signInCommand;
            set => SetProperty(ref _signInCommand, value);
        }

        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        IAccountService _accountService;
        public LoginPageModel(INavigationService navService, IAccountService accountService)
        {
            _navigationService = navService;
            _accountService = accountService;
            SignInCommand = new Command(OnSignInAction);
        }

        private async void OnSignInAction(object obj)
        {
            var loginAttempt = await _accountService.LoginAsync(_username, _password);
            if (loginAttempt)
                await _navigationService.NavigateToAsync<DashboardPageModel>();
            // else break
        }
    }
}
