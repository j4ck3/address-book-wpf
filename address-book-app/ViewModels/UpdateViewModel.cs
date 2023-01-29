using address_book_app.Interfaces;
using address_book_app.Models;
using address_book_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace address_book_app.ViewModels
{
    internal partial class UpdateViewModel : ObservableObject
    {
        private readonly FileService file;

        [ObservableProperty]
        private ObservableObject currentViewModel;

       private readonly IPerson person; 

        public UpdateViewModel(PersonModel person)
        {
            file = new FileService();
            SetPerson(person);
        }

        [ObservableProperty]
        private string updateViewTitle = "Update Contact";


        private Guid id;

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


        private void SetPerson(PersonModel person)
        {
            id = person.Id;
            firstName =  person.FirstName != null ? person.FirstName.ToString() : "";
            lastName = person.LastName != null ? person.LastName.ToString() : "";
            email = person.Email != null ? person.Email.ToString() : "";
            phoneNumber = person.PhoneNumber != null ? person.PhoneNumber.ToString() : "";
            address = person.Address != null ? person.Address.ToString() : "";
            zip = person.Zip != null ? person.Zip.ToString() : "";
            city = person.City != null ? person.City.ToString() : "";
        }

        [RelayCommand]
        private void UpdateContact()
        {
            file.Update(new PersonModel
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                Zip = zip,
                City = city
            });
            //DataContext = new MainViewModel();
            //UpdateView UpdateView = new();
            //Content = UpdateView;
        }


        [RelayCommand]
        private void Cancel()
        {
            
        }
    }
}