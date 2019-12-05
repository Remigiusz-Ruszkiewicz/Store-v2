using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Contracts.V1.Responses
{
    public class BasketResponse
    {
        public string ProductName { get; set; }
        public int Quantity { get; set;}
        public int Price { get; set; }
        public int Summary { get; set; }

    }
}
