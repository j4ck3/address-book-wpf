using address_book_console.Models;
using address_book_console.Services;

namespace address_book_console.tests
{
    public class FileService_Tests
    {
        FileService fileService;

        private PersonModel person = new()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@domain.com",
            PhoneNumber = "0765546865",
            Address = "Randomgatan 122"
        };

        public FileService_Tests()
        {
            fileService = new FileService();
        }

        [Fact]
        public void Should_Create_A_File_With_Json_Data()
        {
            fileService.AddToList(person);

            Assert.True(File.Exists(fileService.filePath));
            Assert.Contains(person, fileService.persons);
        }
    }
}
