using AddressBook.Helper;
using AddressBookMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AddressBookMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PersonHelper personHelper = new PersonHelper();
            var persons = personHelper.GetPersons();
            return View("Person",persons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Person()
        {
            PersonHelper personHelper = new PersonHelper();
            var persons = personHelper.GetPersons();
            return View(persons);

        }

        public IActionResult AddPerson()
        {
            return View();
        }

        public IActionResult UpdatePerson()
        {
            return View();
        }

        public IActionResult AddEmail()
        {
            return View();
        }

        public IActionResult UpdateEmail()
        {
            return View();
        }

        public IActionResult AddPhone() 
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}