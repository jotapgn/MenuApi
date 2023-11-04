using MediatR;
using MenuApi.Application.Commands.CreateMenu;
using MenuApi.Application.Queries.GetMenuById;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route(template: "api/menus")]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMenuCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetMenuByIdQuery(id);
            var menu = await _mediator.Send(query);

            if (menu == null)
                return NotFound();

            return Ok(menu);

        }
    }
}
