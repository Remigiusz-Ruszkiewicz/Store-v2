using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Contracts.V1.Requests
{
    public class NewBaskedItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
