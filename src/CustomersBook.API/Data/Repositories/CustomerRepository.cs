using CustomersBook.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersBook.API.Data.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;
        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Save(Customer customer)
        {
            _dataContext.Customers
                .Add(customer);

            _dataContext.SaveChanges();
        }
        public void Update(Customer customer)
        {
            _dataContext.Customers
                .Update(customer);

            _dataContext.SaveChanges();
        }
        public void Delete(Customer customer)
        {
            _dataContext.Customers
                .Remove(customer);

            _dataContext.SaveChanges();
        }
        public List<Customer> Get()
        {
            var customers = _dataContext.Customers.ToList();

            return customers;
        }
        public Customer GetById(int customerId)
        {
            var customer = _dataContext.Customers
                .Where(s => s.Id == customerId)
                .SingleOrDefault();

            return customer;
        }
    }
}
