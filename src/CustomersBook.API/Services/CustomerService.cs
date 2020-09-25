using CustomersBook.API.Data.Repositories;
using CustomersBook.API.Models;
using System;
using System.Threading.Tasks;

namespace CustomersBook.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task CreateCustomer(Customer customer)
        {
            return _customerRepository.SaveAsync(customer);
        }

        public Task UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateAsync(customer);
        }
    }
}
