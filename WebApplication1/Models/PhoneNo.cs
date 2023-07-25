using AddressBook.Models;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Modules
{
    public class PhoneNo :IsDelete
    {
        [Required]
        public string phoneNoId { get; set; }

        [Required(ErrorMessage ="Enter Type")]
        public PhoneNoType phoneNoType { get; set; }

        [Required(ErrorMessage ="Enter Phone no")]
        [Phone]
        public  long phoneNo { get; set; }

        [Required]
        public string personId {get; set; }
         bool IsDelete.isDelete { get; set; }=false;
        public PhoneNo()
        {

        }

        public PhoneNo(string phoneNoId, PhoneNoType phoneNoType, long phoneNo, string personId)
        {
            this.phoneNoId = phoneNoId;
            this.phoneNoType = phoneNoType;
            this.phoneNo = phoneNo;
            this.personId = personId;

        }
    }
}
