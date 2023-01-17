using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace address_book_app.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;


        [RelayCommand]
        private void CreateView() => CurrentViewModel = new CreateViewModel();

        [RelayCommand]
        private void ContactsView() => CurrentViewModel = new ContactsViewModel();

        public MainViewModel()
        {
            currentViewModel = new ContactsViewModel();
        }

        [RelayCommand]
        private void GithubLink()
        {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/j4ck3/address-book-wpf",
                    UseShellExecute = true
                });
        }
    }
}
 