namespace EditorialProject.UIForms.ViewModels
{
    using EditorialProject.Common.Models;
    using EditorialProject.Common.Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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

        public EditionsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadEditions();
        }

        private async void LoadEditions()
        {
            var response = await this.apiService.GetListAsync<Edition>("https://editorialprojectweb20211005133425.azurewebsites.net", "/api", "/Editions");
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