using CustomersBook.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersBook.API.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task SaveAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
        Task<List<Customer>> Get();
        Task<Customer> GetById(int customerId);
    }
}
