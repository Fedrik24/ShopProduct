using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopProduct.Server.Handler.CommandQuery;
using ShopProduct.Server.Handler.ServiceQuery;
using ShopProduct.Shared;

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
        public async Task<IActionResult> GetProduct()
        {
            var query = new GetItemProductQueryAsync();
            var result = await _mediator.Send(query);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PurchaseItems([FromBody]UserPurchase userPurchase)
        {
            var query = new UserPurchaseItemsCommandQuery(userPurchase);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
