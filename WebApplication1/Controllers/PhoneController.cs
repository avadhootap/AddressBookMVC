using Microsoft.AspNetCore.Mvc;
using AddressBook.Modules;
using AddressBook.Helper;

namespace WebApplication1.Controllers
{
    public class PhoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPhone(PhoneNo phone) 
        {
            PhoneHelper phoneHelper = new PhoneHelper();    
            phoneHelper.AddPhone(phone);
            string PersonId = phone.personId;
            return RedirectToAction("GetPhone", "Person",new { PersonId });
        }

        public IActionResult UpdatePhone(PhoneNo phone)
        {
            List<PhoneNo> phones = new List<PhoneNo>();
            phones.Add(phone);
            PhoneHelper phoneHelper = new PhoneHelper();
            phoneHelper.UpdatePhoneNo(phone);
            return View("GetPhone",phones);
        }
    }
}
