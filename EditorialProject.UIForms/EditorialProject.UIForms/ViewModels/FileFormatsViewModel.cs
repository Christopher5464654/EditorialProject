namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.Common.Models;
    using EditorialProject.Common.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class FileFormatsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<FileFormat> fileFormats;

        public ObservableCollection<FileFormat> FileFormats
        {
            get { return this.fileFormats; }
            set { this.SetValue(ref this.fileFormats, value); }
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
                return new RelayCommand(this.LoadFileFormats);
            }
        }

        public FileFormatsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadFileFormats();
        }

        private async void LoadFileFormats()
        {
            this.IsRefreshing = true;
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetListAsync<FileFormat>(
                url,
                "/api",
                "/FileFormats",
                "bearer",
                MainViewModel.GetInstance().Token.Token);
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }
            var myFileFormats = (List<FileFormat>)response.Result;
            this.FileFormats = new ObservableCollection<FileFormat>(myFileFormats);
        }
    }
}