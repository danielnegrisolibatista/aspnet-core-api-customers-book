using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_api_data_driven_customers_book.Data;
using aspnet_core_api_data_driven_customers_book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core_api_data_driven_customers_book.Controllers
{
    [ApiController]
    [Route("v1/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CustomersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            List<Customer> customers = await _dataContext.Customers
                .AsNoTracking()
                .ToListAsync();

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            Customer customer = await _dataContext.Customers
                    .AsNoTracking()
                    .SingleOrDefaultAsync(s => s.Id == id);

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

                _dataContext.Customers.Add(customer);
                await _dataContext.SaveChangesAsync();

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
                Customer customer = await _dataContext.Customers
                    .SingleOrDefaultAsync(s => s.Id == id);

                if (customer == null)
                {
                    return NotFound();
                }

                customer.FirstName = customerInputModel.FirstName;
                customer.LastName = customerInputModel.LastName;
                customer.Birthday = customerInputModel.Birthday;

                await _dataContext.SaveChangesAsync();

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
            Customer customer = await _dataContext.Customers
                .SingleOrDefaultAsync(s => s.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}