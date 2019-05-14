using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IProductService
    {
        ProductEntity GetProductByBarCode(string barCode);
    }
}
