using aspnet_core_api_data_driven_customers_book.Models;
using Microsoft.EntityFrameworkCore;
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
            _dataContext.Customers
                .Add(customer);

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task UpdateAsync(Customer customer)
        {
            _dataContext.Customers
                .Update(customer);

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task DeleteAsync(Customer customer)
        {
            _dataContext.Customers
                .Remove(customer);

            await _dataContext.SaveChangesAsync().ConfigureAwait(false);
        }
        public async Task<List<Customer>> Get()
        {
            var customers = _dataContext.Customers.ToList();

            return await Task.FromResult(customers)
                .ConfigureAwait(false);
        }
        public async Task<Customer> GetById(int customerId)
        {
            var customer = await _dataContext.Customers
                .Where(s => s.Id == customerId)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            return customer;
        }
    }
}
