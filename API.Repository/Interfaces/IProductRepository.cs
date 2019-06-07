using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface IProductRepository
    {
        ProductEntity GetProductByBarCode(string barCode);

        List<ProductEntity> GetAllProducts();
    }
}
