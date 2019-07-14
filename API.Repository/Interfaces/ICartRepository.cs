using API.Repository.BusinessEntities;
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
        bool AddItemToActiveCart(long userId, long productId, long quantity);

        List<ProductEntity> GetCurrentCartProducts(long userId);

        bool FinishShoping(long cartId);

        long GetCurrentCartId(long userId);

        bool AddOneProductToQuantity(long userId, long productId);

        bool SubstractOneProductToQuantity(long userId, long productId);

        bool DeleteItemFromCart(long userId, long productId);

        List<CartEntity> GetUserPurchaseHistory(long userId);

        List<ProductEntity> GetCartItemsByCartId(long cartId);
    }
}
