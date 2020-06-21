using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Timer time = new Timer(obj => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    welcome.Text = $"Current Time: {DateTime.UtcNow:T}";
                });
            }, null, 1000, 1000);
        }
    }
}
