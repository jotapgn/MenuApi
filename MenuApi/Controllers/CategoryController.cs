using MediatR;
using MenuApi.Application.Commands.CreateCategory;
using MenuApi.Application.Commands.DeleteCategory;
using MenuApi.Application.Commands.UpdateCategory;
using MenuApi.Application.Queries.GetAllCategories;
using MenuApi.Application.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }
        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var query = new GetAllCategoriesQuery();
            var category = await _mediator.Send(query);

            return Ok(category);
        }
        [HttpGet(template: "{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(query);

            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] UpdateCategoryCommand command)
        {
            var category = await _mediator.Send(command);

            if (category == null)
                return NotFound();

            return Ok(category);
        }
        [HttpDelete(template: "{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand(id);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
