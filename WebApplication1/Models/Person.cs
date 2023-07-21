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

        [Required(ErrorMessage = "Please enter Lastname")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please enter MiddleName")]
        public string middleName { get; set; }

        [Required(ErrorMessage ="Please enter Age")]
        [Range(0,100,ErrorMessage ="Age must be Between 0 to 100")]
        public int? age { get; set; }

        [Required(ErrorMessage = "Please enter DOB")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Please enter Gender")]
        public GenderType? gender { get; set; }

        [Required(ErrorMessage = "Please enter Category")]
        public CategoryType? category { get; set; }
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
