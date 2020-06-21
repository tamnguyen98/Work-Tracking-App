using App2.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
            where TPageModelBase : PageModelBase; // push nav to nav stack
        Task GoBackAsync(); // pop from stack

    }
}
