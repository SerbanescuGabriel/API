using API.Repository.Classes;
using API.Repository.Interfaces;
using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Classes
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public bool AddItemToActiveCart(long userId, long productId, long quantity)
        {
            return this.cartRepository.AddItemToActiveCart(userId, productId, quantity);
        }

        public bool AddOneProductToQuantity(long userId, long productId)
        {
            return this.cartRepository.AddOneProductToQuantity(userId, productId);
        }

        public bool DeleteItemFromCart(long userId, long productId)
        {
            return this.cartRepository.DeleteItemFromCart(userId, productId);
        }

        public bool FinishShoping(long cartId)
        {
            return this.cartRepository.FinishShoping(cartId);
        }

        public long GetCurrentCartId(long userId)
        {
            return this.cartRepository.GetCurrentCartId(userId);
        }

        public List<ProductEntity> GetCurrentCartProducts(long userId)
        {
            return this.cartRepository.GetCurrentCartProducts(userId);
        }

        public bool SubstractOneProductToQuantity(long userId, long productId)
        {
            return this.cartRepository.SubstractOneProductToQuantity(userId, productId);
        }
    }
}
