using Kazue.Application.UseCases.Login.DoLogin;
using Kazue.Domain.Request.Login;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers
{
    [Route("v1/api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Do login
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(RegisteredUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LoginAsync(
            [FromServices] IDoLoginUseCase useCase,
            [FromBody] LoginRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            return Ok(response);
        }
    }
}
