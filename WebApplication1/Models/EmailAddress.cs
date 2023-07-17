using AddressBook.Models;

namespace AddressBook.Modules
{
    public class EmailAddress :IsDelete
    {
        public string EId { get; set; }
        public string EmailAdd { get; set; }

        public EmailType EmailType { get; set; }

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
