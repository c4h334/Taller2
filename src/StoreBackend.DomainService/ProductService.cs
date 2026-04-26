using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Infrastructure.Repositories;

namespace StoreBackend.DomainService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

        public async Task<Product> AddAsync(ProductDto product)
        {
            var entity = new Product
            {
                ProductResourceId = Guid.NewGuid(),
                Name = product.Name
            };

            return await _productRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
            }
        }
    }
}