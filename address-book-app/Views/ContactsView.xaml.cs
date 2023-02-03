using address_book_app.Models;
using address_book_app.Services;
using address_book_app.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
namespace address_book_app.Views
{
    /// <summary>
    /// Interaction logic for ContactsView.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        private readonly FileService file;

        public ContactsView()
        {
            InitializeComponent();
            file = new FileService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button.DataContext is PersonModel person)
            {
                Guid Id = person.Id;
                if (Id != Guid.Empty)
                {
                    if (MessageBox.Show($"Are you sure you want to delete the contact {person.FirstName}?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        file.RemovePerson(Id);
                    }
                }
            }
        }

        private void DetailDelete_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsGrid.SelectedItem is PersonModel person)
            {
                Guid Id = person.Id;
                if (Id != Guid.Empty)
                {
                    if (MessageBox.Show($"Are you sure you want to delete the contact {person.FirstName}?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        file.RemovePerson(Id);
                    }
                }
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;

            if (button.DataContext is PersonModel person)
            {
                DataContext = new UpdateViewModel(person);
                UpdateView UpdateView = new();
                Content = UpdateView;
            }
        }


        private void DetailEdit_Click(object sender, RoutedEventArgs e)
        {
            if (PersonsGrid.SelectedItem is PersonModel person)
            {
                DataContext = new UpdateViewModel(person);
                UpdateView UpdateView = new();
                Content = UpdateView;
            }
        }


        private void PersonsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PersonsGrid.SelectedItem is PersonModel person)
            {
                tb_firstName.Text = person.FirstName;
                tb_lastName.Text = person.LastName;
                tb_email.Text = person.Email;
                tb_phoneNumber.Text = person.PhoneNumber;
                tb_address.Text = person.Address;
                tb_zip.Text = person.Zip;
                tb_city.Text = person.City;
            }
        }


    }
}