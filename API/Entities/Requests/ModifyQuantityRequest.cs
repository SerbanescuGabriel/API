using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entities.Requests
{
    public class ModifyQuantityRequest
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
    }
}