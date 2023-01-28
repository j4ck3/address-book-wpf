using address_book_app.Models;
using address_book_app.Services;
using address_book_app.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Data;
using System.Linq.Expressions;
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
            PersonModel? person = button.DataContext as PersonModel;
            if (person != null)
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

        private void detailDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonModel? person = PersonsGrid.SelectedItem as PersonModel;
            if (person != null)
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

            PersonModel? person = button.DataContext as PersonModel;
            if (person != null) 
            {
                DataContext = new UpdateViewModel(person);
                UpdateView UpdateView = new();
                Content = UpdateView;
            }
        }


        private void detailEdit_Click(object sender, RoutedEventArgs e)
        {
            PersonModel? person = PersonsGrid.SelectedItem as PersonModel;

            if (person != null)
            {
                DataContext = new UpdateViewModel(person);

                UpdateView UpdateView = new();
                Content = UpdateView;
            }
        }


        private void PersonsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var person = PersonsGrid.SelectedItem as PersonModel;

            if (person != null)
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