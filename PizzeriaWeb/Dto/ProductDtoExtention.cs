using PizzeriaWeb.Domain;

namespace PizzeriaWeb.Dto
{
    public static class ProductDtoExtention
    {
        public static Product ConvertToProduct(this ProductDto productDto)
        {
            return new Product(productDto.Id, productDto.Name, productDto.Price);

        }
        public static ProductDto ConvertToProducttDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };
        }

    }
}
