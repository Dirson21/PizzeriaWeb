using PizzeriaWeb.Dto;
using SQLHomeWork.Domain;

namespace PizzeriaWeb.Services
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetProduct(int id);
        ProductDto GetProductByName(string name);
        int CreateProduct(ProductDto product);
        void DeleteProduct(int productId);
        int UpdateProduct(ProductDto product);
    }
}
