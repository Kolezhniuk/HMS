using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Logic.Domain.Product.Queries;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class ProductController : BaseController
    {
        private readonly Messages _messages;

        public ProductController(Messages messages)
        {
            _messages = messages;
        }

        //TODO implement pagination
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _messages.DispatchQuery(new GetProductListQuery());
            return Ok(list);
        }
    }
}