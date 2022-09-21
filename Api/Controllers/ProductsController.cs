using Application.Common.Dtos;
using Application.Products.Commands.CreateOrUpdateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            return await Mediator.Send(new GetProductsQuery());
        }

        [HttpPost]
        public async Task<int> CreateOrUpdateProduct(CreateOrUpdateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id});
            return NoContent();
        }
    }
}
