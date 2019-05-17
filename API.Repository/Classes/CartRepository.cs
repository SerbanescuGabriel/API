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
            if(activeCart == null)
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
    }
}
