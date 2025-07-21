using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCRUD.Models
{
    public class Customer
    {   
        public Guid CustomerId { get; set; }
        public string FullName { get; set; } 
        public string Address { get; set; }
    }
}
