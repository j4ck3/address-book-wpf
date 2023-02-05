using address_book_app.ViewModels;
using System.Windows.Controls;
using System.Windows;

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
