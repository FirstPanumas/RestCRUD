using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestCRUD.Models;
using RestCRUD.Services;
namespace RestCRUD.Repositories
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerService _customerRepo;

        public CustomerService(ICustomerService customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public Task CreateAsync(Customer c)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }

            return _customerRepo.CreateAsync(c);
        }
        public Task<List<CustomerDetail>> ReadAsync()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }
            return _customerRepo.ReadAsync();
        }

        public Task UpdateAsync(Customer c)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }
            return _customerRepo.UpdateAsync(c);
        }

        public Task DeleteAsync(Customer c)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }
            return _customerRepo.DeleteAsync(c);
        }

      
    }
}