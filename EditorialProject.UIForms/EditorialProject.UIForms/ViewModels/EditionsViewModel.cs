namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.Common.Models;
    using EditorialProject.Common.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class EditionsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Edition> editions;

        public ObservableCollection<Edition> Editions
        {
            get { return this.editions; }
            set { this.SetValue(ref this.editions, value); }
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
                return new RelayCommand(this.LoadEditions);
            }
        }

        public EditionsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadEditions();
        }

        private async void LoadEditions()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<Edition>(
                url,
                "/api",
                "/Editions",
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myEditions = (List<Edition>)response.Result;
            this.Editions = new ObservableCollection<Edition>(myEditions);
        }
    }
}