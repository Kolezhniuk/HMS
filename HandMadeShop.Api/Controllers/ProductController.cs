using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Logic.Domain.Product.Commands;
using HandMadeShop.Logic.Domain.Product.Queries;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(AddProductDto productDto)
        {
            var command = new AddProductCommand(productDto.Name, productDto.Price);
            var result = await _messages.DispatchCommand(command);
            return FromResult(result);
        }

        [HttpPost("upload-image/{productId}")]
        public async Task<IActionResult> OnPostUploadAsync(string productId, List<IFormFile> files)
        {
            var size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length <= 0) continue;
                var filePath = Path.GetTempFileName();

                await using var stream = System.IO.File.Create(filePath);
                await formFile.CopyToAsync(stream);
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new {count = files.Count, size});
        }

//        [HttpGet("product-category")]
//        public async Task<IActionResult> GetProductCategory(CategoryDto dto)
//        {
//            return Ok();
//        }
//
//        public async Task<IActionResult> GetProductMeasure(HandMadeShop.Dtos.Measure.MeasureDto dto)
//        {
//            return Ok();
//        }
    }
}