using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Notifications;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;

        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductQuery());

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute(
                "GetProductById",
                new { productToReturn.Id},
                productToReturn );
        }

        [HttpGet("{Id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProduct(int Id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(Id));
            return Ok(product);

        }

        [HttpPut("{Id:int}")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product, int Id)
        {
            if (Id != product.Id)
            {
                ModelState.AddModelError("", "Invalid Id");
                return BadRequest(ModelState);
            }

            if (!await _sender.Send(new UpdateProductCommands(product))) 
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            if (!await _sender.Send(new DeleteProductCommand(Id)))
                return NotFound();
            return NoContent();
        }
    }
}
