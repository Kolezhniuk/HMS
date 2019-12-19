using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Api.Utils;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Domain.Measure.Commands;
using HandMadeShop.Logic.Domain.Measure.Queries;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class MeasureController : BaseController
    {
        public MeasureController(ILogger logger, Messages messages) : base(messages, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _messages.DispatchQuery(new GetAllMeasuresQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _messages.DispatchQuery(new GetMeasureQuery() {Id = Uri.UnescapeDataString(id)});
            return Ok(result);
        }

        //TODO think about correct statuses passing.
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ApiResponse<string>> AddNew(WriteMeasureDto dto)
            => Catch(async () =>
            {
                var command = new AddMeasureCommand(dto.Name, dto.Position);
                var result = await _messages.DispatchCommand(command);
                return result.Payload;
            });

        [HttpPost("bulk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ApiResponse<bool>> Bulk(List<WriteMeasureDto> dtos)
            => Catch(async () =>
            {
                var command = new BulkInsertMeasureCommand(dtos);
                await _messages.DispatchCommand(command);
                return true;
            });

        //TODO think about escaping string id.
        [HttpPut("update/{id}")]
        public Task<ApiResponse<bool>> Bulk(string id, WriteMeasureDto dto)
            => Catch(async () =>
            {
                var command = new UpdateMeasureCommand(Uri.UnescapeDataString(id), dto.Name, dto.Position);
                await _messages.DispatchCommand(command);
                return true;
            });

        [HttpDelete("delete/{id}")]
        public Task<ApiResponse<bool>> Delete(string id)
            => Catch(async () =>
            {
                var command = new DeleteMeasureCommand(Uri.UnescapeDataString(id));
                await _messages.DispatchCommand(command);
                return true;
            });
    }
}