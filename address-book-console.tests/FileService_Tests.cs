using address_book_console.Models;
using address_book_console.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace address_book_console.tests
{
    public class FileService_Tests
    {

        readonly FileService fileService;

        ObservableCollection<PersonModel> listoutside = new();

        private PersonModel person = new()
        {
            FirstName = "Firstname",
            LastName = "Lastname",
            Email = "email@domain.com",
            PhoneNumber = "070-1234567",
            Address = "Adress"
        };


        public FileService_Tests()
        {
            fileService = new FileService();
            fileService.filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";


            listoutside.Add(person);

            fileService.AddToList(person);

        }


        [Fact]
        public void Should_Create_A_File_With_Json_Data()
        {
            fileService.ReadFromFile();

            Assert.True(File.Exists(fileService.filePath));
            Assert.Equal(fileService.persons, listoutside);
        }
    }
}




