using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Dtos.DeliveryMethod;
using HandMadeShop.Logic.Domain.DeliveryMethod.Commands;
using HandMadeShop.Logic.Domain.DeliveryMethod.Queries;
using HandMadeShop.Logic.Utils;
using HandMadeShop.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class DefaultController : BaseController
    {
        private readonly Messages _messages;
        private readonly OrderService _orderService;

        public DefaultController(Messages messages, OrderService orderService)
        {
            _messages = messages;
            _orderService = orderService;
        }


        [HttpGet("repo-test")]
        public IActionResult GetAll()
        {
            var list = _messages.DispatchQuery(new GetListQuery());

            return Ok(list);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var count = await _orderService.GetOrderCount();

            return Ok(count);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeliveryMethod([FromBody] DeliveryMethodDto deliveryMethodDto)
        {
            var command = new CreateDeliveryMethodCommand(deliveryMethodDto.Name, deliveryMethodDto.Position);
            var result = await _messages.DispatchCommand(command);

            return FromResult(result);
        }
    }
}