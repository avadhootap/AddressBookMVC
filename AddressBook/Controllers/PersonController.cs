using AddressBook.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Modules;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult GetAllPerson()
        {
            PersonHelper personHelper = new PersonHelper(); 
            var persons= personHelper.GetPersons();
            return Ok(persons);
        }

        [HttpPost]
        public IActionResult AddPersons(Person person)
        {
            PersonHelper personHelper = new PersonHelper();
            
            personHelper.addPerson(person);
            return Ok();

        }
        /*
        [HttpPut]
        public IActionResult UpdateName(string id,string name)
        {
            PersonHelper personHelper = new PersonHelper();
            personHelper.UpdateFirstName(id,name);
            return NoContent();
        }
        */

        [HttpDelete]
        public IActionResult DeletePerson(string id)
        {
            PersonHelper personHelper = new PersonHelper();
            personHelper.DeletePerson(id);
            return Ok();
        }

        /*
        [HttpPut("age")]
        public IActionResult UpdateAge(string id,int age)
        {
            PersonHelper personHelper = new PersonHelper();
             personHelper.UpdateAge(id, age);
            return Ok();
        }
        */

        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson(Person person)
        {
            PersonHelper personHelper = new PersonHelper();
            personHelper.UpdatePerson(person);
            return Ok();
        }
    }
}
