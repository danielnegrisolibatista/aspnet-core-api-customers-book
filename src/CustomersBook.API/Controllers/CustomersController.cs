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

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<CustomerModel>> Get()
        {
            List<CustomerModel> customersModel = _customerService.GetCustomers();

            return Ok(customersModel);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<CustomerModel> GetById(int id)
        {
            CustomerModel customerModel = _customerService.GetCustomerById(id);

            if (customerModel == null)
            {
                return NotFound(); 
            }

            return Ok(customerModel);
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
            CustomerModel customerModel = _customerService.GetCustomerById(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(id);

            return NoContent();
        }
    }
}