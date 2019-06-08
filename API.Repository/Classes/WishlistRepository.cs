using API.Db.Model;
using API.DbFactory.Interfaces;
using API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Classes
{
    public class WishlistRepository : GenericRepository, IWishlistRepository
    {
        LicentaEntities dbContext;

        public WishlistRepository(LicentaEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddProductToWishlist(long userId, long productId)
        {
            var activeWishlist = dbContext.WishLists.FirstOrDefault(ws => ws.UserId == userId && ws.IsCurrent == true);
            if (activeWishlist == null)
            {
                var newWishlist = new WishList() { UserId = userId, IsCurrent = true };
                dbContext.WishLists.Add(newWishlist);
                dbContext.SaveChanges();
                activeWishlist = newWishlist;
            }

            var product = dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return false;
            }

            var newProductWishlist = new WishListProduct() { WishListId = activeWishlist.WishListId, ProductId = product.ProductId };
            this.dbContext.WishListProducts.Add(newProductWishlist);
            return this.dbContext.SaveChanges() > 0;
        }
    }
}
