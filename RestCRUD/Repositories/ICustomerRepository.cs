using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestCRUD.Models;

namespace RestCRUD.Repositories
{
    public interface ICustomerRepository
    {
        Task CreateAsync(Customer c);
        Task<List<Customer>> ReadAsync();
        Task UpdateAsync(Customer c);
        Task DeleteAsync(string id);
    }
}
