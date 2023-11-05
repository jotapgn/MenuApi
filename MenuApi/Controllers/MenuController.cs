using MediatR;
using MenuApi.Application.Commands.CreateMenu;
using MenuApi.Application.Commands.DeleteMenu;
using MenuApi.Application.Commands.UpdateMenu;
using MenuApi.Application.Queries.GetAllMenus;
using MenuApi.Application.Queries.GetMenuById;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route(template: "api/menu")]
    public class MenuController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <remarks>
        /// Status: 1:Active, 2:Inactive.
        /// </remarks>
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
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllMenusQuery();
            var menus = await _mediator.Send(query);

            return Ok(menus);

        }
        /// <remarks>
        /// Status: 1:Active, 2:Inactive.
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateMenuCommand command)
        {
           var menu = await _mediator.Send(command);
           if (menu == null)
                return NotFound();

           return Ok(menu);
        }
        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteMenuCommand(id);
            await _mediator.Send(command);
            return Ok();

        }

    }
}
