using AddressBook.Helper;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Modules;
using System;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPerson()
        {
            PersonHelper personHelper = new PersonHelper();
            var persons = personHelper.GetPersons();
            return View(persons);
        }

        public IActionResult AddPerson()
        {
          
            return View("AddPerson");
        }

      
        public IActionResult UpdatePerson(string personId) 
        {
            Console.WriteLine(personId);
            PersonHelper personHelper = new PersonHelper();

            List<Person> person = personHelper.GetPersons(personId);
            if(person != null) 
            {
                foreach (Person personItem in person)
                {
                    return View(personItem);
                }
            }
            return View();
           
            
        }

      

        [HttpPost]
        public IActionResult Add(Person person)
        {
            PersonHelper personHelper = new PersonHelper();
            personHelper.addPerson(person);
            return RedirectToAction("GetPerson");
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            PersonHelper personHelper = new PersonHelper();
            personHelper.UpdatePerson(person);
            return RedirectToAction("GetPerson");
        }

        [HttpPost]
        public IActionResult DeletePerson(string personId) 
        {
            Console.WriteLine("Person id in controller : "+ personId);
            PersonHelper person = new PersonHelper();
            person.DeletePerson(personId);
            return RedirectToAction("GetPerson");
        }


        public IActionResult AddEmail(string personId)
        {
            Console.WriteLine(personId);
            PersonHelper personHelper=new PersonHelper();
            List<Person> person = personHelper.GetPersons(personId);
            if (person != null)
            {
                foreach (Person personItem in person)
                {
                    return View("../Email/AddEmail", personItem);
                }
            }
            return View();
        }


        public IActionResult GetEmail(string personId)
        {
            Console.WriteLine(personId);
            EmailHelper emailhelper=new EmailHelper();
            List<EmailAddress> emailAddress = emailhelper.GetAllEmails(personId);
            foreach(EmailAddress email in emailAddress)
            {
                Console.WriteLine(email.EmailAdd);
            }
            return View("../Email/GetEmail", emailAddress);
        }

        public IActionResult UpdateEmail(string EId,string personId)
        {
            Console.WriteLine("Email id : "+EId);
            Console.WriteLine("Person Id : "+ personId);
            EmailHelper emailHelper=new EmailHelper();
            List<EmailAddress> emailAddress = emailHelper.GetAllEmails(personId);
            foreach (EmailAddress email in emailAddress)
            {
                if (email.EId.Equals(EId))
                {
                    return View("../Email/UpdateEmail", email);
                }
            }
            return View();
        }
        public IActionResult DeleteEmail(string EId)
        {
            EmailHelper emailHelper = new EmailHelper();
            emailHelper.deleteEmail(EId);
            return RedirectToAction("GetEmail");
        }

        public IActionResult AddPhone(string personId)
        {
            PersonHelper personHelper = new PersonHelper();
            List<Person> person = personHelper.GetPersons(personId);
            if (person != null)
            {
                foreach (Person personItem in person)
                {
                    return View("../Phone/AddPhone", personItem);
                }
            }
            return View();
            
        }

        public IActionResult GetPhone(string PersonId)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            List<PhoneNo>phoneNos=phoneHelper.GetAllPhoneNos(PersonId);
            return View("../Phone/GetPhone",phoneNos);
        }

        public IActionResult DeletePhone(string phoneNoId)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            phoneHelper.DeletePhoneNo(phoneNoId);
            return RedirectToAction("GetEmail");

        }

        public IActionResult UpdatePhone(string phoneNoId,string personID)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            List<PhoneNo>phonenos=phoneHelper.GetAllPhoneNos(personID);
            foreach(var data in phonenos)
            {
                if (data.phoneNoId.Equals(phoneNoId))
                {
                    return View("../Phone/Updatephone",data);
                }
                
            }
            return View();
        }
    }
}
