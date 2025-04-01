using Kazue.Application.UseCases.Status.Create;
using Kazue.Application.UseCases.Status.Delete;
using Kazue.Application.UseCases.Status.Get;
using Kazue.Application.UseCases.Status.GetById;
using Kazue.Application.UseCases.Status.Update;
using Kazue.Domain.Helper;
using Kazue.Domain.Request.Status;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.Status;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers
{
    /// <summary>
    /// Controller responsible for manage data regarding status
    /// </summary>
    [Authorize(Roles = RolesHelper.ADMIN)]
    [Route("v1/api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        /// <summary>
        /// Create a status
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(
            [FromServices] ICreateStatusUseCase useCase,
            [FromBody] StatusRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            var locationUrl = Url.Action(nameof(GetByIdAsync), new { id = response.Id });

            Response.Headers.Location = locationUrl;

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Get a status by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IGetStatusByIdUseCase useCase,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id);

            if (response.Id == null)
                return BadRequest();

            return Ok(response);
        }

        /// <summary>
        /// Get the list of status
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListApiResponse<StatusResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetStatusUseCase useCase,
            [FromQuery] GetStatusRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            if (response.Response.Count != 0)
                return Ok(response);

            return NoContent();
        }

        /// <summary>
        /// UpdateAsync a status by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(StatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromServices] IUpdateStatusUseCase useCase,
            [FromBody] StatusRequest req,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id, req);

            return Ok(response);
        }

        /// <summary>
        /// Delete a status by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteStatusUseCase useCase, 
            [FromRoute] long id)
        {
            await useCase.ExecuteAsync(id);

            return NoContent();
        }
    }
}
