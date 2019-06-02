using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entities.Requests
{
    public class AddItemToCartRequest
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public long Quantity { get; set; }
    }
}