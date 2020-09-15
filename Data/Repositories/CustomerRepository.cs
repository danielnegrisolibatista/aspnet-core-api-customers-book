using aspnet_core_api_data_driven_customers_book.Data.Repositories.Interface;
using aspnet_core_api_data_driven_customers_book.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Data.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task SaveAsync(Customer customer)
        {
            await _dataContext.Customers
                .AddAsync(customer)
                .ConfigureAwait(false);
        }
        public Task UpdateAsync(Customer customer)
        {
            _dataContext.Customers
                .Update(customer);

            return Task.CompletedTask;
        }
        public Task DeleteAsync(Customer customer)
        {
            _dataContext.Customers
                .Remove(customer);

            return Task.CompletedTask;
        }
        public async Task<List<Customer>> Get()
        {
            return await _dataContext.Customers
                .ToListAsync()
                .ConfigureAwait(false);
        }
        public async Task<Customer> GetById(int customerId)
        {
            var customer = await _dataContext.Customers
                .Where(s => s.Id.Equals(customerId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (customer is null)
            {
                return null!;
            }

            return customer;
        }
    }
}
