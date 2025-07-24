using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestCRUD.Models;

namespace RestCRUD.Repositories
{
    public interface ICustomerService
    {
        Task CreateAsync(Customer c);
        Task<List<CustomerDetail>> ReadAsync();
        Task UpdateAsync(Customer c);
        Task DeleteAsync(Customer c);
        
    }
}
