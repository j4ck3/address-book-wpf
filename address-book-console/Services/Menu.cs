using address_book_console.Interfaces;
using address_book_console.Models;
using Newtonsoft.Json;
using System;

namespace address_book_console.Services;
internal class Menu
{
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    //    MENU
    public void WelcomeMenu()
    {
        Console.Clear();
        Console.WriteLine(
           "--------------Meny----------------\n\n" +
           "    1. Lägg till en ny Kontakt\n" +
           "    2. Visa alla kontakter \n" +
           "    3. Visa en Kontakt\n" +
           "    4. Radera en kontak\n" +
           "\n Välj ett av alternativen ovan. ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1": CreateContact(); break;
            case "2": GetAllContacts(); break;
            case "3": GetContactByEmail(); break;
            case "4": Remove(); break;  
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
        if (persons != null)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
            Console.WriteLine("\n Tryck valfri tangent för att återgå till menyn.");
            Console.ReadKey();
            
        }
        else 
            Console.WriteLine("Inga Kontakter ännu."); 
    }

    //    GET CONTACT BY EMAIL
    private void GetContactByEmail()
    {
        Console.Clear();
        Console.WriteLine("Sök kontakt genom E-post adressen.");
        var Email = Console.ReadLine();
        if (Email != null)
        {
            file.GetByEmail(Email);
            Console.WriteLine("Tryck valfri tangent för att återgå till menyn.");
        }
        else return;
        Console.ReadKey();
    }


    //    REMOVE CONTACT EMAIL
    private void Remove()
    {
        Console.Clear();
        file.Persons();
        Console.WriteLine("Alla kontakter");
        var persons = file.Persons();
        if (persons != null)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.FirstName} - {person.Email}");
            }
        }
        else
            Console.WriteLine("Inga Kontakter ännu.");

        Console.WriteLine("Ta bort en kontakt genom att skriva kontaktens E-post adress");
        var _Email = Console.ReadLine();
        if (_Email != null)
            file.Delete(_Email);
    }
}




