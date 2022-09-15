using Application.Products.Commands.CreateOrUpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ProductController : ApiControllerBase
    {
        [HttpPost]
        public async Task<int> CreateOrUpdateProduct(CreateOrUpdateProductCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
