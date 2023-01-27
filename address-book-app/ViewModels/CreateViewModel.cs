using address_book_app.Models;
using address_book_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Windows.Input;

namespace address_book_app.ViewModels
{
    internal partial class CreateViewModel : ObservableObject
    {
        private readonly FileService fileService;

        [ObservableProperty]
        private string pageTitle = "Create A Contact";

        public CreateViewModel()
        {
            fileService = new FileService();
        }

        [ObservableProperty]
        private string firstName = string.Empty;
        [ObservableProperty]
        private string lastName = string.Empty;
        [ObservableProperty]
        private string email = string.Empty;
        [ObservableProperty]
        private string phoneNumber = string.Empty;
        [ObservableProperty]
        private string address = string.Empty;
        [ObservableProperty]
        private string zip = string.Empty;
        [ObservableProperty]
        private string city = string.Empty;

        [RelayCommand]
        private void AddContact()
        {
            fileService.AddToList(new PersonModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                Zip = zip,
                City = city
            });
            ClearForm();
        }





        //Helper
        public void ClearForm()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            Zip = string.Empty;
            City = string.Empty;
        }
    }
}
