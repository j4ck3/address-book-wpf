using address_book_console.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace address_book_console.Services
{
    public class FileService
    {
        public string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Content.json";

        public ObservableCollection<PersonModel> persons = new();
        private readonly string EscMsg = "Tryck valfri tangent för att återgå till menyn.";

        public FileService()
        {
            ReadFromFile();
        }

        public void SaveToFile(ObservableCollection<PersonModel> persons)
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(persons));
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

        public void AddToList(PersonModel person)
        {
            persons.Add(person);
            SaveToFile(persons);
            //Console.WriteLine($" Kontakten har skapats. {EscMsg}");
            //Console.ReadKey();
        }

        public ObservableCollection<PersonModel> Persons()
        {
            var items = new ObservableCollection<PersonModel>();
            foreach (var person in persons)
                items.Add(person);

            return items;
        }

        public void GetByEmail(string _Email)
        {
            ReadFromFile();
            var person = persons.FirstOrDefault(x => x.Email.ToLower() == _Email.ToLower());
            if (person != null)
            {
                Console.WriteLine($"" +
                $" Förnamn: {person.FirstName}\n" +
                $" Efternamn: {person.LastName}\n" +
                $" Epost-adress: {person.Email}\n" +
                $" Telefonnummer: {person.PhoneNumber}\n" +
                $" Adress: {person.Address}\n");

                Console.WriteLine($"{EscMsg}");
            }
            else {
                Console.WriteLine($" Ingen kontakt hittades med E-post adressen {_Email}\n{EscMsg}");
                Console.ReadKey();
            }
        }

        public void Delete(string _Email)
        {
            ReadFromFile();
            var person = persons.FirstOrDefault(x => x.Email.ToLower() == _Email.ToLower());
            if (person == null)
            {
                Console.WriteLine($"\n Ingen kontakt hittades med E-post adressen {_Email}\n{EscMsg}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($" -----------Kontakt som tas bort-------------\n\n" +
                $" Förnamn: {person.FirstName}\n" +
                $" Efternamn: {person.LastName}\n" +
                $" E-Post adress: {person.Email}\n" +
                $" Telefonnummer: {person.PhoneNumber}\n" +
                $" Adress: {person.Address}\n");

                Console.WriteLine("\n Är du säker på att du vill ta bort denna kontakt? [Y/N]: \n");

                string anwser = Console.ReadLine() ?? string.Empty;

                if (anwser.ToLower() == "y")
                {
                    try
                    {
                        persons.Remove(person);
                        SaveToFile(persons);
                        Console.WriteLine($" Kontakten togs bort. {EscMsg}");
                        Console.ReadKey();
                    }
                    catch
                    {
                        Console.WriteLine($" Något gick fel när kontakten skulle tas bort. {EscMsg}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($" Kontakten togs inte bort. {EscMsg}");
                    Console.ReadKey();
                }
            }
        }
    }
}