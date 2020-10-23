using System.Collections.Generic;
using System.Threading.Tasks;
using CustomersBook.API.Data.Repositories;
using CustomersBook.API.Entities;
using CustomersBook.API.DTO;
using CustomersBook.API.Services;
using Microsoft.AspNetCore.Mvc;
using CustomersBook.API.Mapper;

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
        public ActionResult<List<CustomerModel>> Get()
        {
            List<Customer> customers = _customerRepository.Get();

            return Ok(customers.ConvertToCustomers());
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<CustomerModel> GetById(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound(); 
            }

            return Ok(customer.ConvertToCustomer());
        }

        [HttpPost]
        [Route("")]
        public ActionResult<CustomerModel> Post([FromBody] CreateCustomerModel createCustomerModel)
        {
            if (createCustomerModel == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var customerModel = _customerService.CreateCustomer(createCustomerModel);

                return CreatedAtAction(nameof(GetById), new { id = customerModel.Id }, customerModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult<CustomerModel> Put(int id, [FromBody] UpdateCustomerModel customerInputModel)
        {
            if (customerInputModel == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {

                _customerService.UpdateCustomer(id, customerInputModel);

                return NoContent();
            } 
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<CustomerModel> Delete(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerRepository.Delete(customer);

            return NoContent();
        }
    }
}