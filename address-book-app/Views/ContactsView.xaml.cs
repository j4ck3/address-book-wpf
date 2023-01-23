using address_book_app.Models;
using address_book_app.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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
        //private ObservableCollection<PersonModel> persons;
        public ContactsView()
        {
            InitializeComponent();
            file = new FileService();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            PersonModel? person = button.DataContext as PersonModel;
            Guid Id = person.Id;
            if (Id != null)
            {
                if (MessageBox.Show("Are You sure you want to delete the contact?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    file.RemovePerson(Id);
                }

            }
        }


        //private readonly TextBox tb_firstName;

        //private readonly TextBox tb_lastName;

        //private readonly TextBox tb_email;

        //private readonly TextBox tb_phoneNumber;

        //private readonly TextBox tb_address;




        //public void PersonsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    Debug.WriteLine("sadf");
        //    DataGrid dg = (DataGrid)sender;
        //    if (dg.SelectedItem is DataRowView row_selected)
        //    {
        //        Debug.WriteLine(row_selected.ToString());
        //        tb_firstName.Text = row_selected["FirstName"].ToString();
        //        tb_lastName.Text = row_selected["LastName"].ToString();
        //        tb_email.Text = row_selected["Email"].ToString();
        //        tb_phoneNumber.Text = row_selected["PhoneNumber"].ToString();
        //        tb_address.Text = row_selected["Address"].ToString();
        //    }
        //}
    }
}

