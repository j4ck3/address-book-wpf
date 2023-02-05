using address_book_app.Models;
using address_book_app.ViewModels;
using FluentAssertions;
using System.Collections.ObjectModel;

namespace address_book_app.tests
{
    public class ContactsViewModel_Tests
    {

        private readonly ContactsViewModel contactsViewModel;
        public ContactsViewModel_Tests()
        {
            contactsViewModel = new ContactsViewModel();
        }


        [Fact]
        public void Should_Add_Contact_To_ObservableCollection()
        {
            PersonModel person = new()
            {
                FirstName = "sputnik",
                LastName = "eriksson",
                Email = "sputnik@domain.com",
                PhoneNumber = "0745715684",
                Address = "Randomgatan 223",
                Zip = "702 00",
                City = "Anytown"
            };
            contactsViewModel.persons.Add(person);

            contactsViewModel.persons.Should().BeOfType<ObservableCollection<PersonModel>>();
            contactsViewModel.persons.Should().Contain(person);
        }
    }
}