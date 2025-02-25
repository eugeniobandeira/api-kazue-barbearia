using Kazue.Application.UseCases.Barber.Create;
using Kazue.Application.UseCases.Barber.GetById;
using Kazue.Domain.Request.Barber;
using Kazue.Domain.Response.Person;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers;
[Route("v1/api/barber")]
[ApiController]
public class BarberController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(RegisteredPersonResponse), StatusCodes.Status201Created)]
    //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterBarberAsync(
        [FromServices] ICreateBarberUseCase useCase,
        [FromBody] CreateBarberRequest req)
    {
        var response = await useCase.ExecuteAsync(req);

        //return CreatedAtAction(nameof(GetBarberByIdAsync), new { id = response.ID }, response);
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(RegisteredPersonResponse), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBarberByIdAsync(
        [FromServices] IGetBarberByIdUseCase useCase,
        long id)
    {
        var response = await useCase.ExecuteAsync(id);

        if (response.Id > 0)
            return Ok(response);

        return BadRequest();
    }
}
