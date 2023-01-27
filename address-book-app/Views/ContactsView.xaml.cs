using address_book_app.Models;
using address_book_app.Services;
using address_book_app.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Data;
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
        private readonly MainViewModel mainViewModel;
        public ContactsView()
        {
            InitializeComponent();
            file = new FileService();
            mainViewModel = new MainViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            PersonModel? person = button.DataContext as PersonModel;
            Guid Id = person.Id;
            if (Id != null)
            {
                if (MessageBox.Show("Are you sure you want to delete the contact?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    file.RemovePerson(Id);
                }

            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            PersonModel? person = button.DataContext as PersonModel;

            UpdateView UpdateView = new();
            DataContext = new UpdateViewModel(person);
            Content = UpdateView;

        }



        //private readonly TextBox tb_firstName;

        //private readonly TextBox tb_lastName;

        //private readonly TextBox tb_email;

        //private readonly TextBox tb_phoneNumber;

        //private readonly TextBox tb_address;




        //public void PersonsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DataGrid dg = (DataGrid)sender;
        //    if (dg.SelectedItem is DataRowView row_selected)
        //    {
        //        tb_firstName.Text = row_selected["FirstName"].ToString();
        //        tb_lastName.Text = row_selected["LastName"].ToString();
        //        tb_email.Text = row_selected["Email"].ToString();
        //        tb_phoneNumber.Text = row_selected["PhoneNumber"].ToString();
        //        tb_address.Text = row_selected["Address"].ToString();
        //    }
        //}
    }
}

