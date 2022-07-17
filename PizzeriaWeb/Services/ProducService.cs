using PizzeriaWeb.Dto;
using SQLHomeWork.Domain;
using SQLHomeWork.Repositories;

namespace PizzeriaWeb.Services
{
    public class ProducService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProducService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                throw new Exception($"{nameof(productDto)} is not found.");
            }
            return _productRepository.Create(productDto.ConvertToProduct());
     
        }

        public void DeleteProduct(int productId)
        {
            Product product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception($"{nameof(product)} is not found.");
            }
            _productRepository.Delete(product);
        }

        public ProductDto GetProduct(int productId)
        {
            Product product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception($"{nameof(product)} is not found.");
            }
            return product.ConvertToProducttDto();
        }

        public ProductDto GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
            }
            Product product = _productRepository.GetByName(name);
            if (product == null)
            {
                throw new Exception($"{nameof(product)} is not found.");
            }

            return product.ConvertToProducttDto();
        }

        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetAll().ConvertAll(s => s.ConvertToProducttDto());
        }

        public int UpdateProduct(ProductDto product)
        {
            if (product == null)
            {
                throw new Exception($"{nameof(product)} is not found.");
            }
            return _productRepository.Update(product.ConvertToProduct());
        }
    }
}
