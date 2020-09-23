using aspnet_core_api_data_driven_customers_book.Models;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Services
{
    public interface ICustomerService
    {
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}
