using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersBook.API.Data.Repositories;
using CustomersBook.API.Models;
using CustomersBook.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomersBook.API.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(
            ICustomerService customerService, 
            ICustomerRepository customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            List<Customer> customers = await _customerRepository.Get();

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            Customer customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound(); 
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CustomerInputModel>> Post([FromBody] CustomerInputModel customerInputModel)
        {
            if (customerInputModel == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Customer customer = new Customer(customerInputModel.FirstName, customerInputModel.LastName, customerInputModel.Birthday);

                await _customerService.CreateCustomer(customer);

                return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<CustomerInputModel>> Put(int id, [FromBody] CustomerInputModel customerInputModel)
        {
            if (customerInputModel == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Customer customer = await _customerRepository.GetById(id);

                if (customer == null)
                {
                    return NotFound();
                }

                customer.FirstName = customerInputModel.FirstName;
                customer.LastName = customerInputModel.LastName;
                customer.Birthday = customerInputModel.Birthday;

                await _customerService.UpdateCustomer(customer);

                return NoContent();
            } 
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            Customer customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            await _customerRepository.DeleteAsync(customer);

            return NoContent();
        }
    }
}