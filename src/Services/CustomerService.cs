using aspnet_core_api_data_driven_customers_book.Data.Repositories;
using aspnet_core_api_data_driven_customers_book.Models;
using System;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Services
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
