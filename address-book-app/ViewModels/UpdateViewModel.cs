using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address_book_app.ViewModels
{
    internal partial class UpdateViewModel : ObservableObject
    {
        [ObservableProperty]
        private string pageTitle = "All Contacts";
    }
}
