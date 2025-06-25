using customerDemoWebApiPart2_withEntityFramework.Data;
using customerDemoWebApiPart2_withEntityFramework.Models;
using customerDemoWebApiPart2_withEntityFramework.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace customerDemoWebApiPart2_withEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var createCustomer = await _customerService.CreateCustomer(customer);
            return Ok(createCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var customerInList = await _customerService.UpdateCustomer(customer);

            if (customerInList == null)
            {
                return NotFound("Invalid customer details.");
            }

            return Ok(customerInList);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);

            if (customer == null)
            {
                return NotFound("Invalid Customer Detail.");
            }

            return Ok(customer);
        }
    }
}
