 using AddressBook.Helper;
using AddressBook.Modules;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class EmailController : Controller
    {
        [HttpPost]
        public IActionResult AddEmail(EmailAddress email)
        {
            Console.WriteLine("person id in Email: "+email.personId);
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.AddEmail(email);
            return RedirectToAction("GetPerson", "Person");
        }

        [HttpPost]
        public IActionResult UpdateEmail(EmailAddress email) 
        {
            List<EmailAddress> emails = new List<EmailAddress>();
            emails.Add(email);
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.UpdateEmailId(email);
            return View("GetEmail", emails);
        }
    }
}
