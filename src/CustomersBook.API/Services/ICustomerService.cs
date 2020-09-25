using CustomersBook.API.Models;
using System.Threading.Tasks;

namespace CustomersBook.API.Services
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}
