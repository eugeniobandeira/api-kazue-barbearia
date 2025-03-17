using Kazue.Application.UseCases.Queue.Create;
using Kazue.Application.UseCases.Queue.Get;
using Kazue.Application.UseCases.Queue.GetById;
using Kazue.Application.UseCases.Queue.Update;
using Kazue.Application.UseCases.Service.Delete;
using Kazue.Domain.Request.Queue;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.Queue;
using Kazue.Domain.Response.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers
{
    /// <summary>
    /// Controller responsible for manage queue
    /// </summary>
    [Route("v1/api/queue")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        /// <summary>
        /// Add a registry in queue
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(QueueResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(
            [FromServices] ICreateQueueUseCase useCase,
            [FromBody] QueueRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            var locationUrl = Url.Action(nameof(GetByIdAsync), new { id = response.Id });

            Response.Headers.Location = locationUrl;

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Get a specific registry in queue
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(QueueResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IGetByIdQueueUseCase useCase,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id);

            if (response.Id == null)
                return BadRequest();

            return Ok(response);
        }

        /// <summary>
        /// Get a list of queue
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListApiResponse<QueueResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetQueueUseCase useCase,
            [FromQuery] GetQueueRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            if (response.Response.Count != 0)
                return Ok(response);

            return NoContent();
        }

        /// <summary>
        /// UpdateAsync a queue by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(QueueResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromServices] IUpdateQueueUseCase useCase,
            [FromBody] QueueRequest req,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id, req);

            return Ok(response);
        }

        /// <summary>
        /// Delete a service by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteServiceUseCase useCase, 
            [FromRoute] long id)
        {
            await useCase.ExecuteAsync(id);

            return NoContent();
        }
    }
}
