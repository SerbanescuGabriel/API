using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Db.Model;
using API.DbFactory.Interfaces;
using API.Repository.BusinessEntities;
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

        public bool AddItemToActiveCart(long userId, long productId, long quantity)
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
            var cartProduct = dbContext.CartProducts.FirstOrDefault(cp => cp.CartId == activeCart.CartId && cp.ProductId == product.ProductId);

            if (cartProduct == null)
            {
                dbContext.CartProducts.Add(new CartProduct { CartId = activeCart.CartId, ProductId = product.ProductId, Quantity = (int)quantity });
            }
            else
            {
                cartProduct.Quantity += (int)quantity;
            }


            return dbContext.SaveChanges() > 0;
        }

        public bool AddOneProductToQuantity(long userId, long productId)
        {
            var cartId = dbContext.Carts.FirstOrDefault(c => c.UserId == userId && c.IsCurrentCart == true).CartId;
            var productCart = dbContext.CartProducts.FirstOrDefault(pc => pc.CartId == cartId && pc.ProductId == productId);
            productCart.Quantity++;

            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteItemFromCart(long userId, long productId)
        {
            var cart = dbContext.Carts.FirstOrDefault(c => c.UserId == userId && c.IsCurrentCart == true);

            if (cart == null)
                return false;

            var productCart = dbContext.CartProducts.FirstOrDefault(cp => cp.CartId == cart.CartId && cp.ProductId == productId);

            if (productCart == null)
                return false;

            dbContext.CartProducts.Remove(productCart);

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
            cart.PurchaseDate = DateTime.Now;
            return dbContext.SaveChanges() > 0;
        }

        public List<ProductEntity> GetCartItemsByCartId(long cartId)
        {
            var products = from p in this.dbContext.Products
                           join pm in this.dbContext.ProductManufacturers on p.ProductId equals pm.ProductId
                           join cp in this.dbContext.CartProducts on p.ProductId equals cp.ProductId
                           join cart in this.dbContext.Carts on cp.CartId equals cart.CartId
                           join m in this.dbContext.Manufacturers on pm.ManufacturerId equals m.ManufacturerId
                           join c in this.dbContext.Categories on p.CategoryId equals c.CategoryId
                           join s in this.dbContext.StockInTrades on p.ProductId equals s.ProductId
                           where cart.CartId == cartId && cart.IsCurrentCart == false
                           select new ProductEntity
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               ManufacturerName = m.ManufacturerName,
                               CategoryName = c.CategoryName,
                               Price = s.PricePerUnit,
                               Quantity = cp.Quantity
                           };

            return products.ToList();
        }

        public long GetCurrentCartId(long userId)
        {
            return this.dbContext.Carts.FirstOrDefault(c => c.UserId == userId && c.IsCurrentCart == true).CartId;
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
                               Price = s.PricePerUnit,
                               Quantity = cp.Quantity
                           };

            return products.ToList();
        }

        public List<CartEntity> GetUserPurchaseHistory(long userId)
        {
            var userCarts = dbContext.Carts
                .Where(cart => cart.UserId == userId && cart.IsCurrentCart == false)
                .Select(cart => new CartEntity()
            {
                CartId = cart.CartId,
                PurchaseDate = cart.PurchaseDate
            }).ToList();

            return userCarts;
        }

        public bool SubstractOneProductToQuantity(long userId, long productId)
        {
            var cartId = dbContext.Carts.FirstOrDefault(c => c.UserId == userId && c.IsCurrentCart == true).CartId;
            var productCart = dbContext.CartProducts.FirstOrDefault(pc => pc.CartId == cartId && pc.ProductId == productId);
            if (productCart.Quantity <= 1)
            {
                return false;
            }

            productCart.Quantity--;

            return dbContext.SaveChanges() > 0;
        }
    }
}
