using CustomersBook.API.Data.Repositories;
using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using CustomersBook.API.Mapper;
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

        public async Task<CustomerModel> CreateCustomer(CreateCustomerModel createCustomerModel)
        {
            Customer customer = new Customer(createCustomerModel.FirstName, createCustomerModel.LastName, createCustomerModel.Birthday);

            await _customerRepository.SaveAsync(customer);

            return customer.ConvertToCustomer();
        }

        public async Task<CustomerModel> UpdateCustomer(int id, UpdateCustomerModel updateCustomerModel)
        {
            Customer customer = await _customerRepository.GetById(id);

            if (customer == null)
            {
                return default;
            }

            customer.FirstName = updateCustomerModel.FirstName;
            customer.LastName = updateCustomerModel.LastName;
            customer.Birthday = updateCustomerModel.Birthday;

            await _customerRepository.UpdateAsync(customer);

            return customer.ConvertToCustomer();
        }
    }
}
