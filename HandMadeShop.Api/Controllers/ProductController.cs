using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Api.Utils;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Infrastructure.Messaging;
using HandMadeShop.Logic.Domain.Product.Commands;
using HandMadeShop.Logic.Domain.Product.Queries;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class ProductController : BaseController
    {
        public ProductController(MessageBus messageBus, ILogger logger)
            : base(messageBus, logger)

        {
        }

        //TODO implement pagination
        [HttpGet]
        public Task<ApiResponse<IEnumerable<ProductListDto>>> GetAll()
        {
            return Catch(async () => await MessageBus.PublishQuery(new GetAllProductsQuery()));
        }


        [HttpPost("add")]
        public Task<ApiResponse<string>> AddProduct([FromBody] AddProductDto productDto)
        {
            return Catch(async () =>
            {
                var command = new AddProductCommand(productDto);
                var result = await MessageBus.DispatchCommand(command);
                return result.Payload;
            });
        }


        [HttpPost("update")]
        public Task<ApiResponse<string>> AddProduct(string id, UpdateProductDto productDto)
        {
            return Catch(async () =>
            {
                var command = new UpdateProductCommand(id, productDto);
                var result = await MessageBus.DispatchCommand(command);
                return result.Payload;
            });
        }


        [HttpDelete]
        public Task<ApiResponse<bool>> DeleteProduct([FromBody] string id)
        {
            return Catch(async () =>
            {
                var command = new DeleteProductCommand(id);
                var result = await MessageBus.DispatchCommand(command);
                return result.IsSuccess;
            });
        }
    }
}