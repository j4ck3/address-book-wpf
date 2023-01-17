using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

using address_book_app.Models;
using address_book_app.Services;

namespace address_book_app.ViewModels
{
    public partial class ContactsViewModel: ObservableObject
    {
        private readonly FileService fileService;
        public ContactsViewModel()
        {
            fileService = new FileService();
            persons = fileService.Persons();
        }

        [ObservableProperty]
        private string pageTitle = "All Contacts";

        [ObservableProperty]
        private ObservableCollection<PersonModel> persons;
    }
}