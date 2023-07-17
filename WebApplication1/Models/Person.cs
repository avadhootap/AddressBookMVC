using AddressBook.Models;

namespace AddressBook.Modules
{
    public class Person : IsDelete
    {
        public String personId { get; set; }
        public string title { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string middleName { get; set; }

        public int age { get; set; }

        public DateTime DOB { get; set; }

        public GenderType gender { get; set; }

        public CategoryType category { get; set; }
        bool IsDelete.isDelete { get; set; } = false;

        public Person()
        {
         
        }
        
        public Person(string title, string firstName, string lastName, string middleName,int age, DateTime DOB,GenderType gender,CategoryType category)
        {
            this.title = title;
            this.firstName = firstName;   
            this.lastName = lastName;
            this.middleName = middleName;
            this.age = age;
            this.DOB = DOB;
            this.gender = gender;   
            this.category = category;
 
        }

    }
}
