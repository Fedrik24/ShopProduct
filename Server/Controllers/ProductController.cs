using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Handler.ServiceQuery;

namespace ShopProduct.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        private async Task<IActionResult> GetProduct()
        {
            var query = new GetItemProductQueryAsync();
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
