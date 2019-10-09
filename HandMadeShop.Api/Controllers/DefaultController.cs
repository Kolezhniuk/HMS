using System.Net.Mime;
using HandMadeShop.Dtos.DeliveryMethod;
using HandMadeShop.Logic.Domain.DeliveryMethod.Commands;
using HandMadeShop.Logic.Domain.DeliveryMethod.Queries;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class DefaultController : BaseController
    {
        private readonly Messages _messages;

        public DefaultController(Messages messages)
        {
            _messages = messages;
        }


        [HttpGet("repo-test")]
        public IActionResult GetAll()
        {
            var list = _messages.Dispatch(new GetListQuery());

            return Ok(list);
        }

        [HttpPost]
        public IActionResult CreateDeliveryMethod([FromBody] DeliveryMethodDto deliveryMethodDto)
        {
            var command = new CreateDeliveryMethodCommand(deliveryMethodDto.Name, deliveryMethodDto.Position);
            var result = _messages.Dispatch(command);

            return FromResult(result);
        }
    }
}