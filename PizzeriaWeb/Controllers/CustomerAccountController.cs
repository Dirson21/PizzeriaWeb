using Microsoft.AspNetCore.Mvc;
using PizzeriaWeb.Dto;
using PizzeriaWeb.Services;

namespace PizzeriaWeb.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CustomerAccountController: ControllerBase
    {
        private readonly ICustomerAccountService _customerAccountService;

        public CustomerAccountController(ICustomerAccountService customerAccountService)
        {
            _customerAccountService = customerAccountService;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                return Ok(_customerAccountService.GetCustomerAccounts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        
        public IActionResult CreateCustomerAccount([FromBody] CustomerAccountDto customerAccount)
        {
            try
            {
                return Ok(_customerAccountService.CreateCustomerAccount(customerAccount));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
