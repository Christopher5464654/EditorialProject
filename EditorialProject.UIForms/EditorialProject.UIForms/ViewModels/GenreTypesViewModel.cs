namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.Common.Models;
    using EditorialProject.Common.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class GenreTypesViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<GenreType> genreTypes;

        public ObservableCollection<GenreType> GenreTypes
        {
            get { return this.genreTypes; }
            set { this.SetValue(ref this.genreTypes, value); }
        }

        private bool isRefreshing;

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(this.LoadGenreTypes);
            }
        }

        public GenreTypesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadGenreTypes();
        }

        private async void LoadGenreTypes()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<GenreType>(
                url,
                "/api",
                "/GenreTypes",
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myGenreTypes = (List<GenreType>)response.Result;
            this.GenreTypes = new ObservableCollection<GenreType>(myGenreTypes);
        }
    }
}