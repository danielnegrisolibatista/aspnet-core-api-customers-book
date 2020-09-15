using aspnet_core_api_data_driven_customers_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Data.Repositories.Interface
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
