using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestCRUD.Models;
using RestCRUD.Services;

namespace RestCRUD.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly String _uri;
        private readonly String _url;

        private readonly IPlatFormHandler _clientHandler;
        HttpClient _cilent;
        JsonSerializerOptions _jsonOption;

        public List<Customer> Customers { get; private set; }
        public CustomerRepository(IPlatFormHandler clientHandler)
        {
            _uri = DeviceInfo.Platform == DevicePlatform.Android ?"http//10.0.2.2:5000" : "http://localhost:5000";
        
        }
    }
}
