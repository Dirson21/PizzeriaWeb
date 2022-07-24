using Microsoft.AspNetCore.Mvc;
using PizzeriaWeb.Dto;
using PizzeriaWeb.Infrastructure.Data.Model;
using PizzeriaWeb.Services;

namespace PizzeriaWeb.Controllers
{
    [Controller]
    [Route("api/{controller}")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult GetOrders()
        {
            try
            {
                return Ok(_orderService.GetOrders());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                return Ok(_orderService.CreateOrder(orderDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult UpdateOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                return Ok(_orderService.UpdateOrder(orderDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route ("customer/{customerId}")]
        public IActionResult GetOrderByCustomerId(int customerId)
        {
            try
            {
                return Ok(_orderService.GetOrdersByCustomerId(customerId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                _orderService.DeleteOrder(orderId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
