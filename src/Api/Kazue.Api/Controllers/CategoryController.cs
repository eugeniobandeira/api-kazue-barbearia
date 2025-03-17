using Kazue.Application.UseCases.Category.Create;
using Kazue.Application.UseCases.Category.Delete;
using Kazue.Application.UseCases.Category.Get;
using Kazue.Application.UseCases.Category.GetById;
using Kazue.Application.UseCases.Category.Update;
using Kazue.Domain.Request.Category;
using Kazue.Domain.Response.Error;
using Kazue.Domain.Response.Category;
using Kazue.Domain.Response.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Kazue.Api.Controllers
{
    /// <summary>
    /// Controller responsible for manage categories
    /// </summary>
    [Route("v1/api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// Create a Category
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(
            [FromServices] ICreateCategoryUseCase useCase,
            [FromBody] CategoryRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            var locationUrl = Url.Action(nameof(GetByIdAsync), new { id = response.Id });

            Response.Headers.Location = locationUrl;

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Get a Category by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] IGetCategoryByIdUseCase useCase,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id);

            if (response.Id == null)
                return BadRequest();

            return Ok(response);
        }

        /// <summary>
        /// Get a list of Category
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ListApiResponse<CategoryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll(
            [FromServices] IGetCategoryUseCase useCase,
            [FromQuery] GetCategoryRequest req)
        {
            var response = await useCase.ExecuteAsync(req);

            if (response.Response.Count != 0)
                return Ok(response);

            return NoContent();
        }

        /// <summary>
        /// UpdateAsync a Category by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(
            [FromServices] IUpdateCategoryUseCase useCase,
            [FromBody] CategoryRequest req,
            [FromRoute] long id)
        {
            var response = await useCase.ExecuteAsync(id, req);

            return Ok(response);
        }

        /// <summary>
        /// Delete a Category by its id
        /// </summary>
        /// <param name="useCase"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] IDeleteCategoryUseCase useCase, 
            [FromRoute] long id)
        {
            await useCase.ExecuteAsync(id);

            return NoContent();
        }
    }
}
