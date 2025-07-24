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

        private readonly IPlatformHandler _clientHandler;
        HttpClient _client;
        JsonSerializerOptions _jsonOption;

        public List<Customer> Customers { get; private set; }
        public CustomerRepository(IPlatformHandler clientHandler)
        {
            _uri = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
            _url = $"{_uri}/api/Customer";



            _clientHandler = clientHandler;
            var h = _clientHandler.GetPlatformHandler();
            if (h != null)
            {
                _client = new HttpClient(h);
            }
            else
            {
                _client = new HttpClient();
            }
            _jsonOption = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

        }

        public async Task CreateAsync(Customer c)
        {
            try
            {
                string json = JsonSerializer.Serialize(c, _jsonOption);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _client.PostAsync(_url, data);

                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("เพิ่มข้อมูลเรียบร้อย");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public async Task<List<Customer>> ReadAsync()
        {
            Customers = new List<Customer>();
            try
            {
                HttpResponseMessage res = await _client.GetAsync(_url);
                if (res.IsSuccessStatusCode)
                {
                    string data = await res.Content.ReadAsStringAsync();
                    Customers = JsonSerializer.Deserialize<List<Customer>>(data, _jsonOption);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return Customers;
        }
        public async Task UpdateAsync(Customer c)
        {
            try
            {
                string json = JsonSerializer.Serialize(c, _jsonOption);
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await _client.PutAsync(_url, data);
                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("แก้ไขข้อมูลเรียบร้อย");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                HttpResponseMessage res = await _client.DeleteAsync($"{_url}/{id}");
                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("ลบข้อมูลเรียบร้อย");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

         
    }
}