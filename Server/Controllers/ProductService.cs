using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ShopProduct.Server.Handler.Service;


namespace ShopProduct.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductService : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProductData()
        {
            var query = new GetProductDataAsyncQuery();
            var result = await _mediator.Send(query);
            return result;
        }

    }
}
