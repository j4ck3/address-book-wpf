using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using address_book_app.Models;
using address_book_app.Services;
using CommunityToolkit.Mvvm.Input;


namespace address_book_app.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        private readonly FileService file;
        public ContactsViewModel()
        {
            file = new FileService();
            persons = file.Persons();
        }

        [ObservableProperty]
        private string pageTitle = "All Contacts";

        [ObservableProperty]
        private ObservableCollection<PersonModel> persons;

    }
}