using CustomersBook.API.Data.Repositories;
using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using CustomersBook.API.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public CustomerModel CreateCustomer(CreateCustomerModel createCustomerModel)
        {
            Customer customer = new Customer(createCustomerModel.FirstName, createCustomerModel.LastName, createCustomerModel.Birthday);

            _customerRepository.Save(customer);

            return customer.ConvertToCustomer();
        }

        public CustomerModel UpdateCustomer(int id, UpdateCustomerModel updateCustomerModel)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return default;
            }

            customer.FirstName = updateCustomerModel.FirstName;
            customer.LastName = updateCustomerModel.LastName;
            customer.Birthday = updateCustomerModel.Birthday;

            _customerRepository.Update(customer);

            return customer.ConvertToCustomer();
        }

        public void DeleteCustomer(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer != null)
            {
                _customerRepository.Delete(customer);
            }
        }

        public CustomerModel GetCustomerById(int id)
        {
            Customer customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return default;
            }

            return customer.ConvertToCustomer();
        }

        public List<CustomerModel> GetCustomers()
        {
            List<Customer> customers = _customerRepository.Get().ToList();

            if (customers == null)
            {
                return default;
            }

            return customers.ConvertToCustomers().ToList();
        }
    }
}
