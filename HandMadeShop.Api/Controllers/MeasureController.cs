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
        public MeasureController(MessageBus messageBus, ILogger logger) : base(messageBus, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await MessageBus
                .PublishQuery<GetAllMeasuresQuery, IEnumerable<MeasureDto>>(new GetAllMeasuresQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await MessageBus.PublishQuery<GetMeasureQuery, MeasureDto>
                (new GetMeasureQuery {Id = Uri.UnescapeDataString(id)});
            return Ok(result);
        }

        //TODO think about correct statuses passing.
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ApiResponse<string>> AddNew(WriteMeasureDto dto)
        {
            return Catch(async () =>
            {
                ThrowIfModelInvalid();
                var command = new AddMeasureCommand(dto.Name, dto.Position);
                var result = await MessageBus.DispatchCommand(command);
                return result.Payload;
            });
        }

        [HttpPost("bulk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public Task<ApiResponse<bool>> Bulk(List<WriteMeasureDto> dtos)
        {
            return Catch(async () =>
            {
                var command = new BulkInsertMeasureCommand(dtos);
                await MessageBus.DispatchCommand(command);
                return true;
            });
        }

        [HttpPut("update/{id}")]
        public Task<ApiResponse<bool>> Bulk(string id, WriteMeasureDto dto)
        {
            return Catch(async () =>
            {
                var command = new UpdateMeasureCommand(Uri.UnescapeDataString(id), dto.Name, dto.Position);
                await MessageBus.DispatchCommand(command);
                return true;
            });
        }

        [HttpDelete("delete/{id}")]
        public Task<ApiResponse<bool>> Delete(string id)
        {
            return Catch(async () =>
            {
                var command = new DeleteMeasureCommand(Uri.UnescapeDataString(id));
                await MessageBus.DispatchCommand(command);
                return true;
            });
        }
    }
}