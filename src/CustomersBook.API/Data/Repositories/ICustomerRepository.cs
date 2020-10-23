using CustomersBook.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomersBook.API.Data.Repositories
{
    public interface ICustomerRepository
    {
        void Save(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        List<Customer> Get();
        Customer GetById(int customerId);
    }
}
