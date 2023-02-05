    public class FileService_Tests
    {
        private PersonModel person = new PersonModel()
        {
            FirstName = "Firstname",
            LastName = "Lastname",
            Email = "email@domain.com",
            PhoneNumber = "070-1234567",
            Address = "Adress"
        };

        private FileService fileService = new FileService();

        [Fact]
        public void Save_One_Contact_And_Create_JSON_File_Containing_The_List()
        {
            //Act
            //Saves a contact to the list and creates a JSON file
            fileService.AddToList(person);


            //Assert
            //Checks if list contains the added contact
            Assert.Contains(person, fileService.persons);

            //Checks if file exists
            Assert.True(File.Exists(fileService.filePath));












            //FileService fileService;

            //private PersonModel person = new()
            //{
            //    FirstName = "John",
            //    LastName = "Doe",
            //    Email = "john@domain.com",
            //    PhoneNumber = "0765546865",
            //    Address = "Anytown"
            //};

            //public FileService_Tests()
            //{
            //    fileService = new FileService();
            //}

            //[Fact]
            //public void Should_Create_A_File_With_Json_Data()
            //{
            //    fileService.AddToList(person);

            //    Assert.True(File.Exists(fileService.filePath));
            //    Assert.Contains(person, fileService.persons);
            //}
        }
    }