using API.Db.Model;
using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Mappers
{
    public class ProductMapper
    {
        public static ProductEntity MapProduct(Product product)
        {
            return new ProductEntity();
        }
    }
}
