using Kazue.Application.UseCases.User.ChangePassword;
using Kazue.Application.UseCases.User.Create;
using Kazue.Application.UseCases.User.Delete;
using Kazue.Application.UseCases.User.Get;
using Kazue.Application.UseCases.User.GetById;
using Kazue.Application.UseCases.User.Update;
using Kazue.Domain.Helper;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers;

/// <summary>
/// Controller responsible for manage data regarding users
/// </summary>
[Route("v1/api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    /// <summary>
    /// Create a user
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(RegisteredUserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterAsync(
        [FromServices] ICreateUserUseCase useCase,
        [FromBody] CreateUserRequest req)
    {
        var response = await useCase.ExecuteAsync(req);

        var locationUrl = Url.Action(nameof(GetByIdAsync), new { id = response.Id });

        Response.Headers.Location = locationUrl;

        return StatusCode(StatusCodes.Status201Created, response);
    }

    /// <summary>
    /// Get a user by id
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(
        [FromServices] IGetUserByIdUseCase useCase,
        [FromRoute] Guid id)
    {
        var response = await useCase.ExecuteAsync(id);

        if (response.Id == null)
            return BadRequest();

        return Ok(response);
    }

    /// <summary>
    /// Get a list of users
    /// </summary>
    /// <param name="req"></param>
    /// <param name="useCase"></param>
    /// <returns></returns>
    [Authorize(Roles = RolesHelper.ADMIN)]
    [HttpGet]
    [ProducesResponseType(typeof(ListApiResponse<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAsync(
        [FromQuery] GetUserRequest req,
        [FromServices] IGetUserUseCase useCase)
    {
        var response = await useCase.ExecuteAsync(req);

        if (response.Response.Count != 0)
            return Ok(response);

        return BadRequest();
    }

    /// <summary>
    /// UpdateAsync user profile
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="req"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize(Roles = RolesHelper.ADMIN)]
    [HttpPut]
    [Route("{id}")]
    [Authorize]
    [ProducesResponseType(typeof(UserProfileResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync(
        [FromServices] IUpdateUserUseCase useCase,
        [FromBody] UpdateUserRequest req,
        [FromRoute] Guid id)
    {
        var response = await useCase.ExecuteAsync(id, req);

        return Ok(response);
    }

    /// <summary>
    /// UpdateAsync user password
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="req"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("change-password")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangePasswordAsync(
        [FromServices] IChangePasswordUserUseCase useCase,
        [FromBody] ChangePasswordRequest req,
        [FromRoute] Guid id)
    {
        await useCase.ExecuteAsync(id, req);

        return NoContent();
    }

    /// <summary>
    /// Delete user account
    /// </summary>
    /// <param name="useCase"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAsync(
        [FromServices] IDeleteUserUseCase useCase,
        [FromRoute] Guid id)
    {
        await useCase.ExecuteAsync(id);
        return NoContent();
    }

}
