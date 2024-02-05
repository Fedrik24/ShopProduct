using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ShopProduct.Server.Handler.Service;


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
        public async Task<IActionResult> Login([FromHeader(Name = "userId")]int userId, 
            [FromHeader(Name = "password")]string username)
        {
            var query = new UserLoginQuery(userId, username);
            var result = await _mediator.Send(query);
            return result;
        }

    }
}
