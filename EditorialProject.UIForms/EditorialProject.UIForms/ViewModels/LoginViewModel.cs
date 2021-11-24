namespace EditorialProject.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using EditorialProject.Common.Models;
    using EditorialProject.Common.Services;
    using EditorialProject.UIForms.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        private bool isRunning;

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        private bool isEnabled;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        private readonly ApiService apiService;

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
            this.IsRunning = false;
            this.Email = "jane.doe@gmail.com";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes introducir un email", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes introducir una contraseña", "Aceptar");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            var request = new TokenRequest
            {
                Username = this.Email,
                Password = this.Password
            };
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetTokenAsync(
                url,
                "/Account",
                "/CreateToken",
                request);
            this.IsRunning = false;
            this.IsEnabled = true;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email o Contraseña incorrecto", "Aceptar");
                return;
            }
            var token = (TokenResponse)response.Result;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            mainViewModel.Editions = new EditionsViewModel();
            mainViewModel.FileFormats = new FileFormatsViewModel();
            mainViewModel.GenreTypes = new GenreTypesViewModel();
            mainViewModel.Languages = new LanguagesViewModel();
            mainViewModel.Status = new StatusViewModel();
            Application.Current.MainPage = new MasterPage();
        }
    }
}