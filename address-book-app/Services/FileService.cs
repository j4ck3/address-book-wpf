using address_book_app.Interfaces;
using address_book_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace address_book_app.Services
{
    public class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Content.json";
        private ObservableCollection<PersonModel> persons = new();

        public FileService()
        {
            ReadFromFile();
        }

        public void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                persons = JsonConvert.DeserializeObject<ObservableCollection<PersonModel>>(sr.ReadToEnd())!;
            }
            catch { persons = new ObservableCollection<PersonModel>(); }
        }


        public void SaveToFile(ObservableCollection<PersonModel> persons)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(persons));
        }


        public void AddToList(PersonModel person)
        {
            persons.Add(person);
            SaveToFile(persons);
        }

        public ObservableCollection<PersonModel> Persons()
        {
            var items = new ObservableCollection<PersonModel>();
            foreach (var person in persons)
                items.Add(person);

            return items;
        }

        public void GetContact(Guid _Id)
        {
            ReadFromFile();
            var person = persons.FirstOrDefault(x => x.Id == _Id);
        }

        public void RemovePerson(Guid Id)
        {
            ReadFromFile();
            var person = persons.FirstOrDefault(x => x.Id == Id);

            if (person != null)
            {
                try
                {
                    persons.Remove(person);
                    SaveToFile(persons);
                }
                catch
                {
                    
                }

            }
        }
    }
}