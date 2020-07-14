using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurante.View;
using Restaurante.Model;

namespace Restaurante
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //bool isLoggedIn = Convert.ToBoolean(Current.Properties.ContainsKey("IsLoggedIn").ToString());
            if (Setting.UserName != string.Empty && Setting.UserPassword != string.Empty)
            {
               // MainPage = new PerfilView();
                App.Current.MainPage = new NavigationPage(new PerfilView());
            }
            else
            {
                MainPage = new HomeView();
            }  
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
