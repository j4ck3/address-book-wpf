using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using address_book_app.Interfaces;
using address_book_app.Models;
using address_book_app.Services;
using Newtonsoft.Json;



namespace address_book_app
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> persons = new ObservableCollection<Person>();
        private readonly FileService file = new();
        public MainWindow()
        {
            InitializeComponent();
            file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Content.json";
            PopulatePersonsList();
        }

        private void PopulatePersonsList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<ObservableCollection<Person>>(file.Read());
                if (items != null)
                    persons = items;
            }
            catch { }
            lvPersons.ItemsSource = persons;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            persons.Add(new Person
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                PhoneNumber = tbPhone.Text,
                Adress = tbAddress.Text,
            });
            file.Save(JsonConvert.SerializeObject(persons));
            ClearForm();
        }

        private void ClearForm()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbPhone.Text = "";
            tbAddress.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "",
                UseShellExecute = true
            });
        }
    }
}

