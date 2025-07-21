using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestCRUD.Models;
namespace RestCRUD.Repositories
{
    public class CustomerService : ICustomerRepository
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
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

        public async Task<List<Customer>> GetCustomersAsync()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return null;
            }

            return await _customerRepo.ReadAsync();
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

            return _customerRepo.DeleteAsync(c.Customerid.ToString());

        }
    }
