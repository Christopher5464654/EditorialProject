namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.Common.Models;
    using EditorialProject.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel
    {
        private static MainViewModel instance;

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }
        public TokenResponse Token { get; set; }
        public LoginViewModel Login { get; set; }
        public EditionsViewModel Editions { get; set; }
        public FileFormatsViewModel FileFormats { get; set; }
        public GenreTypesViewModel GenreTypes { get; set; }
        public LanguagesViewModel Languages { get; set; }
        public StatusViewModel Status { get; set; }

        public ICommand AboutCommand => new RelayCommand(this.LoadAboutPage);

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private async void LoadAboutPage()
        {
            await App.Navigator.PushAsync(new AboutPage());
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_icono_Editions",
                    PageName = "EditionsPage",
                    Title = "Editions"
                },
                new Menu
                {
                    Icon = "ic_icono_FormatFiles",
                    PageName = "FileFormatsPage",
                    Title = "File Formats"
                },
                new Menu
                {
                    Icon = "ic_icono_GenreTypes",
                    PageName = "GenreTypesPage",
                    Title = "Genre Types"
                },
                new Menu
                {
                    Icon = "ic_language",
                    PageName = "LanguagesPage",
                    Title = "Languages"
                },
                new Menu
                {
                    Icon = "ic_icon_image",
                    PageName = "StatusPage",
                    Title = "Status"
                },
                new Menu
                {
                    Icon = "ic_phonelink_setup",
                    PageName = "SetupPage",
                    Title = "Setup"
                },
                new Menu
                {
                    Icon = "ic_perm_device_information",
                    PageName = "AboutPage",
                    Title = "About"
                },
                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Close session"
                }
            };
            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}