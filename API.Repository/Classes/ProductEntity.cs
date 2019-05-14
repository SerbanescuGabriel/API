using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Classes
{
    public class ProductEntity
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public float? Price { get; set; }
    }
}
