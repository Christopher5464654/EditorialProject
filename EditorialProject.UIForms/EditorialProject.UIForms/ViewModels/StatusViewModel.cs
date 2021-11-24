namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.Common.Models;
    using EditorialProject.Common.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class StatusViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Status> statuses;

        public ObservableCollection<Status> Statuses
        {
            get { return this.statuses; }
            set { this.SetValue(ref this.statuses, value); }
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
                return new RelayCommand(this.LoadStatuses);
            }
        }

        public StatusViewModel()
        {
            this.apiService = new ApiService();
            this.LoadStatuses();
        }

        private async void LoadStatuses()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<Status>(
                url,
                "/api",
                "/Status",
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myStatuses = (List<Status>)response.Result;
            this.Statuses = new ObservableCollection<Status>(myStatuses);
        }
    }
}