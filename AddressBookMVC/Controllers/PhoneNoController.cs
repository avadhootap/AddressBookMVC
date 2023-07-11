using AddressBook.Helper;
using AddressBook.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPhoneNos([Optional] string id)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            
            return Ok(phoneHelper.GetAllPhoneNos(id));
        }

        [HttpPost]
        public IActionResult AddPhoneNo(PhoneNo phoneNo)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            phoneHelper.AddPhone(phoneNo);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePhoneNo(PhoneNo phoneNo)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            phoneHelper.UpdatePhoneNo(phoneNo);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletePhoneNo(string id)
        {
            PhoneHelper phoneHelper = new PhoneHelper();
            phoneHelper.DeletePhoneNo(id);
            return Ok();
        }

        //[HttpGet("GetPhoneNoFromPersonId")]
        //public IActionResult GetPhoneNosByPersonId(string id)
        //{
        //    PhoneHelper phoneHelper = new PhoneHelper();
        //   return  Ok(phoneHelper.GetPhoneNoByPersonId(id));

        //}


    }
}
