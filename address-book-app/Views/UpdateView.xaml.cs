using address_book_app.Models;
using address_book_app.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows;
using address_book_app.Services;
using System.Net;

namespace address_book_app.Views
{
    /// <summary>
    /// Interaction logic for UpdateView.xaml
    /// </summary>
    public partial class UpdateView : UserControl
    {
        public UpdateView()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Content = new ContactsViewModel();
        }
    }
}
