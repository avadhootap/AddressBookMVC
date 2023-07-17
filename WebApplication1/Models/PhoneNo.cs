using AddressBook.Models;

namespace AddressBook.Modules
{
    public class PhoneNo :IsDelete
    {
        public string phoneNoId { get; set; }
        public PhoneNoType phoneNoType { get; set; }
        public  long phoneNo { get; set; }
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
