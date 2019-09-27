using HandMadeShop.Domain.Entities;
using HandMadeShop.Domain.RepositoryAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using HandMadeShop.Domain.Entities.DeliveryMethod;
using HandMadeShop.Domain.Utils;

namespace HandMadeShop.Api.Controllers
{
  [ApiController]
  [Produces(MediaTypeNames.Application.Json)]
  [Route("api/v1/[controller]")]
  public class DefaultController : Controller
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

  }
}
