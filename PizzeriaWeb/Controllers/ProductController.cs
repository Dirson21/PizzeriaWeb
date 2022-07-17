using Microsoft.AspNetCore.Mvc;
using PizzeriaWeb.Dto;
using PizzeriaWeb.Services;



namespace PizzeriaWeb.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductController: ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                return Ok(_productService.GetProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{productId}")]
        public IActionResult GetProduct(int ProductId)
        {
            try
            {
                return Ok(_productService.GetProduct(ProductId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("search")]
        public IActionResult GetProductByName([FromQuery] string name)
        {
            try
            {
                return Ok(_productService.GetProductByName(name)); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                return Ok(_productService.CreateProduct(productDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{productId}")]
        public IActionResult UpdateCustomerAccount([FromBody] ProductDto productDto)
        {
            try
            {
                return Ok(_productService.UpdateProduct(productDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{productId}")]
        public IActionResult DeleteCustomerAccount(int productId)
        {
            try
            {
                _productService.DeleteProduct(productId);
             
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
