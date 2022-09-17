using Application.Common.Dtos;
using Application.Products.Commands.CreateOrUpdateProduct;
using Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductController : ApiControllerBase
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
    }
}
