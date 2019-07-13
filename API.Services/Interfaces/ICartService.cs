using API.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface ICartService
    {
        bool AddItemToActiveCart(long userId, long productId, long quantity);

        List<ProductEntity> GetCurrentCartProducts(long userId);

        bool FinishShoping(long cartId);

        long GetCurrentCartId(long userId);

        bool AddOneProductToQuantity(long userId, long productId);

        bool SubstractOneProductToQuantity(long userId, long productId);

        bool DeleteItemFromCart(long userId, long productId);
    }
}
