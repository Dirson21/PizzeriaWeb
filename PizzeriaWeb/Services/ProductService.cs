using PizzeriaWeb.Dto;
using PizzeriaWeb.Infrastructure.Data.Model;
using PizzeriaWeb.Infrastructure.UoW;
using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public int CreateProduct(ProductDto productDto)
        {
            if (productDto == null)
            {
                throw new Exception($"{nameof(productDto)} is not found.");
            }

            int id = _productRepository.Create(productDto.ConvertToProduct());
            _unitOfWork.SaveEntitiesAsync();
            

            return id;
     
        }

        public void DeleteProduct(int productId)
        {
            Product product = _productRepository.GetById(productId);
            if (product == null)
            {
                throw new Exception($"{nameof(product)} is not found.");
            }
            _productRepository.Delete(product);
            _unitOfWork.SaveEntitiesAsync();
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
           
            int id = _productRepository.Update(product.ConvertToProduct());
            _unitOfWork.SaveEntitiesAsync();
            return id;
        }
    }
}
