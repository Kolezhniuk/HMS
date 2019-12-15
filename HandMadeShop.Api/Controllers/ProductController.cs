using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Api.Utils;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Logic.Domain.Measure;
using HandMadeShop.Logic.Domain.Product;
using HandMadeShop.Logic.Domain.Product.Commands;
using HandMadeShop.Logic.Domain.Product.Queries;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class ProductController : BaseController
    {
        private readonly MeasureEventListener<ProductEvent> _listener;
        private readonly Messages _messages;

        public ProductController(ILogger logger, Messages messages, MeasureEventListener<ProductEvent> listener) :
            base(logger)
        {
            _messages = messages;
            _listener = listener;
            _listener.Listen();
        }

        //TODO implement pagination
        [HttpGet]
        public Task<ApiResponse<IEnumerable<ProductListDto>>> GetAll()
            => Catch(async () => await _messages.DispatchQuery(new GetAllProductsQuery()));


        [HttpPost("add")]
        public Task<ApiResponse<string>> AddProduct([FromBody] AddProductDto productDto)
            => Catch(async () =>
            {
                var command = new AddProductCommand(productDto);
                var result = await _messages.DispatchCommand(command);
                return result.Payload;
            });


        [HttpPost("update")]
        public Task<ApiResponse<string>> AddProduct(string id, UpdateProductDto productDto)
            => Catch(async () =>
            {
                var command = new UpdateProductCommand(id, productDto);
                var result = await _messages.DispatchCommand(command);
                return result.Payload;
            });


        [HttpDelete]
        public Task<ApiResponse<bool>> DeleteProduct([FromBody] string id)
            => Catch(async () =>
            {
                var command = new DeleteProductCommand(id);
                var result = await _messages.DispatchCommand(command);
                return result.IsSuccess;
            });
    }
}