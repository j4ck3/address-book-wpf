using address_book_console.Interfaces;
using address_book_console.Models;

namespace address_book_console.Services;
internal class Menu
{
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    //    MENU
    public void WelcomeMenu()
    {
        Console.Clear();
        Console.WriteLine("--------------Meny----------------");
        Console.WriteLine("");
        Console.WriteLine("1. Lägg till en ny Kontakt.");
        Console.WriteLine("2. Visa alla Kontakter.");
        Console.WriteLine("");
        Console.Write("Ange ett av alternativen ovan: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": CreateContact(); break;
            case "2": GetAllContacts(); break;
        }
    }

    //    CREATE CONTACT
    private void CreateContact()
    {
        Console.Clear();
        Console.WriteLine("-----Lägg till en ny kontakt------");


        IPerson person = new Person();
        Console.Write("Ange Förnamn: ");
        person.FirstName = Console.ReadLine() ?? "";
        Console.Write("Ange Efternamn: ");
        person.LastName = Console.ReadLine() ?? "";
        Console.Write("Ange E-postadress: ");
        person.Email = Console.ReadLine() ?? "";
        Console.Write("Ange Telefonnummer: ");
        person.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Ange Adress: ");
        person.Address = Console.ReadLine() ?? "";
        file.AddToList(new Person
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            PhoneNumber = person.PhoneNumber,
            Address = person.Address
        });

    }

    //    GET ALL CONTACTS
    private void GetAllContacts()
    {
        Console.Clear();
        Console.WriteLine("-----------Alla Kontakter-------------");
        Console.WriteLine("");
        var persons = file.Persons();
        foreach (var person in persons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
        Console.WriteLine("");
        Console.WriteLine("Tryck på valfri knapp för att gå till menyn.");
        Console.ReadKey();
    }

    //    GET CONTACT
    private void GetContact(Person person)
    {
        Console.Clear();
        file.GetPersonFromList(person);
        Console.WriteLine("-----------Kontakt-------------");
        Console.WriteLine($"{person.FirstName} {person.LastName}");
        Console.WriteLine(person.Email);
        Console.WriteLine(person.PhoneNumber);
        Console.WriteLine(person.Address);
        Console.WriteLine("");
        Console.WriteLine("Radera denna kontakt genom att trycka DElETE");

        ConsoleKey readKey = Console.ReadKey().Key;
        if (readKey == ConsoleKey.Delete)
        {
            DeleteContact(person);
        }
    }

    //    DELETE CONTACT
    private void DeleteContact(Person person)
    {
        file.RemovePersonFromList(person);
    }


}

