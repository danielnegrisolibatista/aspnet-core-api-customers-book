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

            return customers;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            Customer customer = await _dataContext.Customers
                    .AsNoTracking()
                    .SingleOrDefaultAsync(s => s.Id == id);

            if (customer != null)
            {
                return customer;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Customers.Add(customer);
                await _dataContext.SaveChangesAsync();

                return customer;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Customer>> Put(int id, [FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer updateCustomer = await _dataContext.Customers
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (updateCustomer != null)
                {
                    updateCustomer.FirstName = customer.FirstName;
                    updateCustomer.LastName = customer.LastName;
                    updateCustomer.Birthday = customer.Birthday;

                    _dataContext.Customers.Update(updateCustomer);
                    await _dataContext.SaveChangesAsync();

                    return updateCustomer;
                }
                else
                {
                    return NotFound(customer);
                }
            } 
            else
            {
                return BadRequest();
            }
        }
    }
}