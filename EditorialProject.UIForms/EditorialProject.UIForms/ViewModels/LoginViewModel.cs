namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
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
            if (!this.Email.Equals("jane.doe@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email o Contraseña incorrecto", "Aceptar");
                return;
            }
            //await Application.Current.MainPage.DisplayAlert("Ok", "¡Listooo!", "Aceptar");
            //return;
            MainViewModel.GetInstance().Editions = new EditionsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EditionsPage());
        }
    }
}