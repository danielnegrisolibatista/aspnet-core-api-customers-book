using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersBook.API.Services
{
    public interface ICustomerService
    {
        CustomerModel CreateCustomer(CreateCustomerModel createCustomerModel);
        CustomerModel UpdateCustomer(int id, UpdateCustomerModel updateCustomerModel);
        void DeleteCustomer(UpdateCustomerModel updateCustomerModel);
        CustomerModel GetCustomerById(int id);
        IEnumerable<CustomerModel> GetCustomers();
    }
}
