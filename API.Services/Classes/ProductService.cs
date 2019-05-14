using API.Repository.Classes;
using API.Repository.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Classes
{
    public class ProductService : IProductService
    {
        IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductEntity GetProductByBarCode(string barCode)
        {
            return this.productRepository.GetProductByBarCode(barCode);
        }
    }
}
