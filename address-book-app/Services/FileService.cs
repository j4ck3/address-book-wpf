using address_book_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace address_book_app.Services
{
    public class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Content.json";
        private List<PersonModel> persons;

        public FileService()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                persons = JsonConvert.DeserializeObject<List<PersonModel>>(sr.ReadToEnd())!;
            }
            catch { persons = new List<PersonModel>(); }
        }


        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(persons));
        }

        public void AddToList(PersonModel person)
        {
            persons.Add(person);
            SaveToFile();
        }

        public ObservableCollection<PersonModel> Persons()
        {
            var items = new ObservableCollection<PersonModel>();
            foreach (var person in persons)
                items.Add(person);

            return items;
        }
    }
}