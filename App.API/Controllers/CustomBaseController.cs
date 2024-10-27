using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Net;

namespace App.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result) =>
    result.Status switch
    {
        HttpStatusCode.NoContent => NoContent(),
        HttpStatusCode.Created => Created(result.UrlAsCreated, result.Data),
        _ => new ObjectResult(result) { StatusCode = (int)result.Status }
    };


    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result) =>
    result.Status switch
    {
        HttpStatusCode.NoContent => new ObjectResult(null) { StatusCode = (int)result.Status },
        _ => new ObjectResult(result) { StatusCode = (int)result.Status }
    };

}
