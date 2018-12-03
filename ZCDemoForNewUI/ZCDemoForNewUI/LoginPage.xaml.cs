using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ZCDemoForNewUI
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void NavigateButton_OnClicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new DashboardPage());
            App.Current.MainPage = new DashboardPage();
        }
    }
}
