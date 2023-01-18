using address_book_console.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace address_book_console.Services
{
    public class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Content.json";
        private List<Person> persons;

        public FileService()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd())!;
            }
            catch { persons = new List<Person>(); }
        }


        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(persons));
        }

        public void AddToList(Person person)
        {
            persons.Add(person);
            SaveToFile();
        }

        public ObservableCollection<Person> Persons()
        {
            var items = new ObservableCollection<Person>();
            foreach (var person in persons)
                items.Add(person);

            return items;
        }


        public void RemovePersonFromList(Person person)
        {
            var _person = GetPersonFromList(person);
            if (_person != null)
                persons.Remove(person);
        }

        public Person GetPersonFromList(Person person)
        {
            var _person = persons.FirstOrDefault(x => x.Id == person.Id);
            return _person!;
        }

        public IEnumerable<Person> GetPeopleFromList()
        {
            return persons;
        }
    }
}