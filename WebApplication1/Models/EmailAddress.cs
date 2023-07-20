using AddressBook.Models;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Modules
{
    public class EmailAddress :IsDelete
    {
        [Required]
        public string EId { get; set; }

        [Required(ErrorMessage ="Enter Email Address")]
        [EmailAddress(ErrorMessage ="Enter valid Email Address")]
        public string EmailAdd { get; set; }

        public EmailType EmailType { get; set; }

        [Required]
        public string personId { get; set; }

        bool  IsDelete.isDelete { get; set; } = false;

        public EmailAddress() { }

        public EmailAddress(string EId, string EmailAdd, EmailType emailType,string personId)
        {
            this.EId = EId;
            this.EmailAdd = EmailAdd;
            EmailType = emailType;
            this.personId = personId;
        }
    }
}
