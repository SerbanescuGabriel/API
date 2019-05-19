using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Interfaces
{
    public interface ICartRepository
    {
        bool AddItemToActiveCart(long userId, long productId);

        List<ProductEntity> GetCurrentCartProducts(long userId);
    }
}
