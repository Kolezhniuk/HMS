using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Measure;
using HandMadeShop.Logic.Domain.Measure.Commands;
using HandMadeShop.Logic.Domain.Measure.Queries;
using HandMadeShop.Logic.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandMadeShop.Api.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class MeasureController : BaseController
    {
        private readonly Messages _messages;

        public MeasureController(Messages messages)
        {
            _messages = messages;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(MeasureDto dto)
        {
            var result = await _messages.DispatchQuery(new GetMeasureListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _messages.DispatchQuery(new GetMeasureQuery() {Id = id});
            return Ok(result);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddNew(WriteMeasureDto dto)
        {
            var command = new AddMeasureCommand(dto.Name, dto.Position);
            var result = await _messages.DispatchCommand(command);
            return FromResult(result);
        }

        [HttpPost("bulk")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Bulk(List<WriteMeasureDto> dtos)
        {
            var command = new BulkInsertMeasureCommand(dtos);
            var result = await _messages.DispatchCommand(command);
            return FromResult(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Bulk(string id, WriteMeasureDto dto)
        {
            var command = new UpdateMeasureCommand(Uri.UnescapeDataString(id), dto.Name, dto.Position);
            var result = await _messages.DispatchCommand(command);
            return FromResult(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteMeasureCommand(Uri.UnescapeDataString(id));
            var result = await _messages.DispatchCommand(command);
            return FromResult(result);
        }
    }
}