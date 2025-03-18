using Kazue.Application.UseCases.Service.Create;
using Kazue.Application.UseCases.Service.Delete;
using Kazue.Application.UseCases.Service.Get;
using Kazue.Application.UseCases.Service.GetById;
using Kazue.Application.UseCases.Service.Update;
using Kazue.Domain.Request.Service;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.Service;
using Kazue.Domain.Response.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers
{
    /// <summary>
    /// Controller responsible for manage data regarding services
    /// </summary>
    //[Authorize]
    [Route("v1/api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        /// <summary>
        /// Create a service
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(
            [FromServices] ICreateServiceUseCase useCase,
            [FromBody] ServiceRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            var locationUrl = Url.Action(nameof(GetByIdAsync), new { id = response.Id });

            Response.Headers.Location = locationUrl;

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Get a service by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IGetServiceByIdUseCase useCase,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id);

            if (response.Id == null)
                return BadRequest();

            return Ok(response);
        }

        /// <summary>
        /// Get a list of services
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListApiResponse<ServiceResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetServiceUseCase useCase,
            [FromQuery] GetServiceRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            if (response.Response.Count != 0)
                return Ok(response);

            return NoContent();
        }

        /// <summary>
        /// UpdateAsync a service by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ServiceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromServices] IUpdateServiceUseCase useCase,
            [FromBody] ServiceRequest req,
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
