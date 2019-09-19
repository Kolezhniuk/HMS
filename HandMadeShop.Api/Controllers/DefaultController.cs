using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace HandMadeShop.Api.Controllers
{
  [ApiController]
  [Produces(MediaTypeNames.Application.Json)]
  [Route("api/v1/[controller]")]
  public class DefaultController : Controller
  {
    /// <summary>
    /// Some docs for example.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Index()
    {
      return this.Json(new {
        Status = "Success",
        StatusCode = 200,
        Response = new
        {
          Data = "some data",
          Headers = new string[]
          {
            "header 1",
            "header 2"
          }
        }
      });
    }
  }
}
