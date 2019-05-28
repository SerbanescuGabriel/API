using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Db.Model;
using API.DbFactory.Interfaces;
using API.Repository.Interfaces;

namespace API.Repository.Classes
{
    public class CartRepository : GenericRepository, ICartRepository
    {
        LicentaEntities dbContext;

        public CartRepository(LicentaEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddItemToActiveCart(long userId, long productId)
        {
            var activeCart = dbContext.Carts.FirstOrDefault(c => c.UserId == userId && c.IsCurrentCart == true);
            if (activeCart == null)
            {
                var newCart = new Cart { UserId = userId, IsCurrentCart = true };
                this.dbContext.Carts.Add(newCart);
                this.dbContext.SaveChanges();
                activeCart = newCart;
            }
            var product = dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            dbContext.CartProducts.Add(new CartProduct { CartId = activeCart.CartId, ProductId = product.ProductId });

            return dbContext.SaveChanges() > 0;
        }

        public bool FinishShoping(long cartId)
        {
            var productIds = dbContext.CartProducts.Where(cp => cp.CartId == cartId).Select(pc => pc.ProductId).ToList();
            foreach (long productId in productIds)
            {
                var stockProduct = dbContext.StockInTrades.FirstOrDefault(s => s.ProductId == productId);
                stockProduct.QuantityLeft--;
            }

            var cart = dbContext.Carts.FirstOrDefault(c => c.CartId == cartId);
            cart.IsCurrentCart = false;
            return dbContext.SaveChanges() > 0;
        }

        public List<ProductEntity> GetCurrentCartProducts(long userId)
        {
            var products = from p in this.dbContext.Products
                           join pm in this.dbContext.ProductManufacturers on p.ProductId equals pm.ProductId
                           join cp in this.dbContext.CartProducts on p.ProductId equals cp.ProductId
                           join cart in this.dbContext.Carts on cp.CartId equals cart.CartId
                           join m in this.dbContext.Manufacturers on pm.ManufacturerId equals m.ManufacturerId
                           join c in this.dbContext.Categories on p.CategoryId equals c.CategoryId
                           join s in this.dbContext.StockInTrades on p.ProductId equals s.ProductId
                           where cart.UserId == userId && cart.IsCurrentCart == true
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
