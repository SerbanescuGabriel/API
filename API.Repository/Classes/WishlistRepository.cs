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

        public List<ProductEntity> GetAllWishlistProducts(long userId)
        {
            var products = from p in this.dbContext.Products
                           join pm in this.dbContext.ProductManufacturers on p.ProductId equals pm.ProductId
                           join m in this.dbContext.Manufacturers on pm.ManufacturerId equals m.ManufacturerId
                           join c in this.dbContext.Categories on p.CategoryId equals c.CategoryId
                           join s in this.dbContext.StockInTrades on p.ProductId equals s.ProductId
                           join wlp in this.dbContext.WishListProducts on p.ProductId equals wlp.ProductId
                           join wish in this.dbContext.WishLists on wlp.WishListId equals wish.WishListId
                           where wish.UserId == userId && wish.IsCurrent == true
                           select new ProductEntity
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               ManufacturerName = m.ManufacturerName,
                               CategoryName = c.CategoryName,
                               Price = s.PricePerUnit
                           };

            return products.ToList();
        }
    }
}
