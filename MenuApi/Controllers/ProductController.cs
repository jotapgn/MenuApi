using MediatR;
using MenuApi.Application.Commands.CreateProduct;
using MenuApi.Application.Commands.DeleteProduct;
using MenuApi.Application.Commands.UpdateProduct;
using MenuApi.Application.Queries.GetAllProductsByCategory;
using MenuApi.Application.Queries.GetAllProductsByMenu;
using MenuApi.Application.Queries.GetProductById;
using Microsoft.AspNetCore.Mvc;

namespace MenuApi.Controllers
{
    [Route(template:"api/product")]
    public class ProductController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductCommand command)
        {
            var product = await _mediator.Send(command);

            if (product == null)
                return NotFound();

           return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _mediator.Send(query);

            if(product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpGet("menu/{idMenu}")]
        public async Task<ActionResult> GetProductsByMenu(int idMenu)
        {
            var query = new GetAllProductsByMenuQuery(idMenu);
            var product = await _mediator.Send(query);

            return Ok(product);
        }
        [HttpGet("category/{idCategory}")]
        public async Task<ActionResult> GetProductsByCategory(int idCategory)
        {
            var query = new GetAllProductsByCategoryQuery(idCategory);
            var product = await _mediator.Send(query);

            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);
            var product = await _mediator.Send(command);
            return Ok();
        }
    }
}
