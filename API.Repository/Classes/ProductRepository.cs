using API.Db.Model;
using API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Classes
{
    public class ProductRepository : GenericRepository, IProductRepository
    {
        LicentaEntities dbContext;

        public ProductRepository(LicentaEntities dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ProductEntity> GetAllProducts()
        {
            var products = from p in this.dbContext.Products
                          join pm in this.dbContext.ProductManufacturers on p.ProductId equals pm.ProductId
                          join m in this.dbContext.Manufacturers on pm.ManufacturerId equals m.ManufacturerId
                          join c in this.dbContext.Categories on p.CategoryId equals c.CategoryId
                          join s in this.dbContext.StockInTrades on p.ProductId equals s.ProductId
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

        public ProductEntity GetProductByBarCode(string barCode)
        {
            var product = from p in this.dbContext.Products
                          join pm in this.dbContext.ProductManufacturers on p.ProductId equals pm.ProductId
                          join m in this.dbContext.Manufacturers on pm.ManufacturerId equals m.ManufacturerId
                          join c in this.dbContext.Categories on p.CategoryId equals c.CategoryId
                          join s in this.dbContext.StockInTrades on p.ProductId equals s.ProductId
                          where p.ProductBarCode.Equals(barCode)
                          select new ProductEntity
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              ManufacturerName = m.ManufacturerName,
                              CategoryName = c.CategoryName,
                              Price = s.PricePerUnit
                          };

            return product.FirstOrDefault(); //pls work
        }
    }
}
