using EditorialProject.UIForms.ViewModels;
using EditorialProject.UIForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EditorialProject.UIForms
{
    public partial class App : Application
    {
        public static MasterPage Master { get; internal set; }
        public static NavigationPage Navigator { get; internal set; }
        
        public App()
        {
            InitializeComponent();

            MainViewModel.GetInstance().Login = new LoginViewModel();
            MainPage = new NavigationPage(new LoginPage());
            
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
