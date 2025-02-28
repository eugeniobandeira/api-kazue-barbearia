using Kazue.Application.UseCases.User.Create;
using Kazue.Application.UseCases.User.GetById;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.Person;
using Kazue.Domain.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers;
[Route("v1/api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(RegisteredUserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterPersonAsync(
        [FromServices] ICreateUserUseCase useCase,
        [FromBody] CreateUserRequest req)
    {
        var response = await useCase.ExecuteAsync(req);

        var locationUrl = Url.Action(nameof(GetPersonByIdAsync), new { id = response.Id });

        Response.Headers.Location = locationUrl;

        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonByIdAsync(
        [FromServices] IGetUserByIdUseCase useCase,
        long id)
    {
        var response = await useCase.ExecuteAsync(id);

        if (response.Id > 0)
            return Ok(response);

        return BadRequest();
    }
}
