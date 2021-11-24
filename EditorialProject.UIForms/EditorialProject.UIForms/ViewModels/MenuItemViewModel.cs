namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel : EditorialProject.Common.Models.Menu
    {
        public ICommand SelectMenuCommand
        {
            get
            {
                return new RelayCommand(SelectMenu);
            }
        }

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;
            //var mainViewModel = MainViewModel.GetInstance();
            switch (this.PageName)
            {
                case "EditionsPage":
                    await App.Navigator.PushAsync(new EditionsPage());
                    break;
                case "FileFormatsPage":
                    await App.Navigator.PushAsync(new FileFormatsPage());
                    break;
                case "GenreTypesPage":
                    await App.Navigator.PushAsync(new GenreTypesPage());
                    break;
                case "LanguagesPage":
                    await App.Navigator.PushAsync(new LanguagesPage());
                    break;
                case "StatusPage":
                    await App.Navigator.PushAsync(new StatusPage());
                    break;
                case "AboutPage":
                    await App.Navigator.PushAsync(new AboutPage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                default:
                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }

        }
    }
}
