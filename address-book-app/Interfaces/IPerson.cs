using System;

namespace address_book_app.Interfaces
{
    internal interface IPerson
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Zip { get; set; }
        string City { get; set; }
    }
}
