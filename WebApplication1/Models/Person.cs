using AddressBook.Models;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Modules
{
    public class Person : IsDelete
    {
    
        public string personId { get; set; }
        public string title { get; set; }

        [Required(ErrorMessage ="Please enter Firstname")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Please enter lastname")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please enter middleName")]
        public string middleName { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        public int age { get; set; }

        [Required(ErrorMessage = "Please enter DOB")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please enter gender")]
        public GenderType gender { get; set; }

        [Required(ErrorMessage = "Please enter category")]
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
