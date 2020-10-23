using CustomersBook.API.DTO;
using CustomersBook.API.Entities;
using System.Threading.Tasks;

namespace CustomersBook.API.Services
{
    public interface ICustomerService
    {
        Task<CustomerModel> CreateCustomer(CreateCustomerModel createCustomerModel);
        Task<CustomerModel> UpdateCustomer(int id, UpdateCustomerModel updateCustomerModel);
    }
}
