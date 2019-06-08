using API.Repository.Interfaces;
using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services.Classes
{
    public class WishlistService: IWishlistService
    {
        private readonly IWishlistRepository wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }

        public bool AddProductToWishList(long userId, long productId)
        {
            return this.wishlistRepository.AddProductToWishlist(userId, productId);
        }
    }
}
