using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.BusinessEntities
{
    public class CartEntity
    {
        public long CartId { get; set; }
        public DateTime? PurchaseDate { get; set; }
    }
}
