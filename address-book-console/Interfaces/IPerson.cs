namespace address_book_console.Interfaces
{
    public interface IPerson
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
    }
}