﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("{customerAccountId}")]
        public IActionResult GetCustomerAccount(int customerAccountId)
        {
            try
            {
                return Ok(_customerAccountService.GetCustomerAccount(customerAccountId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
              
        }

        [HttpGet]
        [Route("login/{customerAccountLogin}")]
        public IActionResult GetCustomerAccountByLogin(string customerAccountLogin)
        {
            try
            {
                return Ok(_customerAccountService.GetCustomerAccountByLogin(customerAccountLogin));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }

        [HttpGet]
        [Route ("orders")]
        public IActionResult GetTotalPriceOrders()
        {
            try
            {
                return Ok(_customerAccountService.GetTotalPriceOrders());
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

        [HttpPut]
        [Route("{customerAccountId}")]
        public IActionResult UpdateCustomerAccount(int customerAccountId, [FromBody] CustomerAccountDto customerAccount)
        {
            try
            {
                customerAccount.Id = customerAccountId;
                return Ok(_customerAccountService.UpdateCustomerAccount(customerAccount));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{customerAccountId}")]
        public IActionResult DeleteCustomerAccount(int customerAccountId)
        {
            try
            {
                _customerAccountService.DeleteCustomerAccount(customerAccountId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
