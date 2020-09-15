using aspnet_core_api_data_driven_customers_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_api_data_driven_customers_book.Data.Repository.Interface
{
    public interface ICustomerRepository
    {
        bool Save(Customer customer);
        bool Update(Customer customer);
        bool Delete(Customer customer);
        List<Customer> Get();

        Customer GetById(int customerId);
    }
}
