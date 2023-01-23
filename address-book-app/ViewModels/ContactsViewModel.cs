using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using address_book_app.Models;
using address_book_app.Services;
using System.Windows.Input;

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

        //public void Delete(PersonModel person)
        //{
        //    if (person is PersonModel deleteperson)
        //    {
        //        file.RemovePerson(deleteperson);
        //    }
        //}

        [ObservableProperty]
        private string pageTitle = "All Contacts";

        [ObservableProperty]
        private ObservableCollection<PersonModel> persons;



    }
}