using address_book_console.Interfaces;
using address_book_console.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace address_book_console.Services
{
    public class FileService
    {
        private readonly string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Content.json";
        // $@"{Directory.GetCurrentDirectory()}\contacts.json";

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
            Console.WriteLine(" Kontakten har skapats. Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();

        }

        public ObservableCollection<Person> Persons()
        {
            var items = new ObservableCollection<Person>();
            foreach (var person in persons)
                items.Add(person);

            return items;
        }


        public void GetByEmail(string Email)
        {
            using var sr = new StreamReader(filePath);
            persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd()) ?? null!;
            var person = persons.FirstOrDefault(x => x.Email.ToLower() == Email.ToLower());
            if (person != null)
            {
                Console.WriteLine($"" +
                $"Förnamn: {person.FirstName}\n" +
                $"Efternamn: {person.LastName}\n" +
                $"Epost-adress: {person.Email}\n" +
                $"Telefonnummer: {person.PhoneNumber}\n" +
                $"Adress: {person.Address}\n");
            }
            else {
                Console.WriteLine($" Ingen kontakt hittades med E-post adressen {Email} hittades.");
            }
        }


        public void Delete(string _Email)
        {
            Console.Clear();
            using var sr = new StreamReader(filePath);
            persons = JsonConvert.DeserializeObject<List<Person>>(sr.ReadToEnd()) ?? null!;
            var person = persons.FirstOrDefault(x => x.Email.ToLower() == _Email.ToLower());

            if (person == null)
            {
                Console.Clear();
                Console.WriteLine($"\n Ingen kontakt hittades med E-post adressen {_Email}\n Tryck valfri tangent för att återgå till menyn.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($" Kontakt som tas bort.\n\n" +
                $" Förnamn: {person.FirstName}\n" +
                $" Efternamn: {person.LastName}\n" +
                $" Epost-adress: {person.Email}\n" +
                $" Telefonnummer: {person.PhoneNumber}\n" +
                $" Adress: {person.Address}\n");

                Console.WriteLine("\n Är du säker på att du vill ta bort denna kontakt? (y/n): \n");

                string anwser = Console.ReadLine() ?? string.Empty;

                if (anwser.ToLower() == "y")
                {
                    try
                    {
                        persons.Remove(person);
                        Console.WriteLine(" Kontakten togs bort. Tryck valfri tangent för att återgå till menyn.");
                        Console.ReadKey();
                    }
                    catch{}
                }
                else
                {
                    Console.WriteLine(" Kontakten togs inte bort. Tryck valfri tangent för att återgå till menyn.");
                    Console.ReadKey();
                }
            }
        }
    }
}