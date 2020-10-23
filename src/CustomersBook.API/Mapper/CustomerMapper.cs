using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersBook.API.Mapper
{
    public static class CustomerMapper
    {
        public static Customer ConvertToCustomerEntity(this CreateCustomerModel customerModel) =>
            new Customer(0, customerModel.FirstName, customerModel.LastName, customerModel.Birthday);

        public static Customer ConvertToCustomerEntity(this UpdateCustomerModel customerModel) =>
            new Customer(customerModel.Id, customerModel.FirstName, customerModel.LastName, customerModel.Birthday);

        public static IEnumerable<CustomerModel> ConvertToCustomers(this IList<Customer> customers) =>
            new List<CustomerModel>(customers.Select(s => new CustomerModel(s.Id, s.FirstName, s.LastName, s.Birthday)));

        public static CustomerModel ConvertToCustomer(this Customer customer) =>
            new CustomerModel(customer.Id, customer.FirstName.ToString(), customer.LastName, customer.Birthday);
    }
}
